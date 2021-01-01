using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Dubot.BotConsole;
using Dubot.BotConsole.Exceptions;
using Dubot.BotConsole.Managers;
using Dubot.BotConsole.Models;
using Dubot.Data.Exceptions;
using Dubot.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dubot
{    

    public class DubotConsole
    {
        public static List<CommandInfo> Commands { get; set; }
        private static DiscordSocketClient _client;
        private static CommandService _commands;
        private static IServiceProvider _services;

        static void Main(string[] args)
        {
            new DubotConsole().RunBotAsync().GetAwaiter().GetResult();
        }

        public DubotConsole()
        {
            //if (Commands == null || Commands.Count() != 0)
            //    Tasker();
        }
        public static bool IsDebugHost
        {
            get
            {
                var host = System.Net.Dns.GetHostName();
                return "Sol" == host
                || "SBSol" == host;
            }
        }

        public static DiscordSocketClient GetClient()
        {
            return _client;
        }

        public async Task RunBotAsync()
        {
            var config = new DiscordSocketConfig
            {
                MessageCacheSize = 1000,
                ExclusiveBulkDelete = true,
                AlwaysDownloadUsers = false,
                LogLevel = Discord.LogSeverity.Info,

                GatewayIntents =
                    GatewayIntents.Guilds |
                    GatewayIntents.GuildMembers |
                    GatewayIntents.GuildMessageReactions |
                    GatewayIntents.GuildMessages |
                    GatewayIntents.DirectMessages |
                    GatewayIntents.GuildPresences
            };

            _client = new DiscordSocketClient(config);

            _commands = new CommandService(new CommandServiceConfig { DefaultRunMode = RunMode.Async });
            _services = new ServiceCollection()
                        .AddSingleton(_client)
                        .AddSingleton(_commands)
                        .BuildServiceProvider();

            string botToken = (IsDebug) ? AppConfig.DebugBotToken : AppConfig.BotToken;

            System.Console.WriteLine($"{(IsDebug ? "DEBUG" : "PROD")}: Connecting to Discord using the token {botToken.Substring(0, 6)}***************");

            //event subscriptions
            _client.Log += Log;
            _client.Ready += Ready;
            //_client.ReactionAdded += GlobalChatMessenger.OnReaction;
            _client.GuildMemberUpdated += GuildMemberUpdatedAsync;
            _client.JoinedGuild += JoinedGuild;

            await RegisterCommandsAsync();

            await _client.LoginAsync(Discord.TokenType.Bot, botToken);

            await _client.StartAsync();

            await _client.SetGameAsync("Dual Universe");

            await Task.Delay(-1);
        }

        public async Task GuildMemberUpdatedAsync(SocketGuildUser arg1, SocketGuildUser arg2)
        {
            Console.WriteLine((arg1.Nickname ?? arg1.Username) + " : " + arg2.Status);

            switch (arg2.Status)
            {
                case UserStatus.Offline:
                    await UserManager.Away(arg2);
                    break;
                case UserStatus.Online:
                    UserManager.Login(arg2);
                    break;
                case UserStatus.Idle:
                    await UserManager.Away(arg2);
                    break;
                case UserStatus.AFK:
                    await UserManager.Away(arg2);
                    break;
                case UserStatus.DoNotDisturb:
                    await UserManager.Away(arg2);
                    break;
                case UserStatus.Invisible:
                    await UserManager.Away(arg2);
                    break;
            }
        }

        private Task Log(LogMessage arg)
        {
            System.Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        private async Task Ready()
        {
            UserManager.InitUsers(_client.Guilds?.ToList());
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("Dubot.BotConsole"));
            await _commands.AddModulesAsync(assembly, _services);
            Commands = _commands.Commands.ToList();
        }

        private Task ReadyAsync(DiscordSocketClient shard)
        {
            System.Console.WriteLine($"Shard Number {shard.ShardId} is connected and ready!");
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage log)
        {
            System.Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task JoinedGuild(SocketGuild arg)
        {
            UserManager.InitUsers(new List<SocketGuild> { arg });
            return Task.CompletedTask;
        }
        public static bool IsDebug
        {
            get
            {
                //HACK set to debug on production
                //return true;
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }

        public void DiscordLog(string msg)
        {
            (_client.GetChannel(791093872444047361) as SocketTextChannel).SendMessageAsync(msg);
        }

        public void Tasker()
        {
            if (_client != null)
                return;

            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                //if (Commands == null || Commands.Count() != 0)
                //    RunBotAsync().GetAwaiter().GetResult();

            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {

            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {

            });

            bw.RunWorkerAsync();
        }

        private void ResetPrefix(ulong guildId)
        {
            using (var context = new DubaseContext())
            {
                var g = context.Guilds.FirstOrDefault(x => x.GuildId == (long)guildId);
                g.CmdPrefix = "!";
                context.SaveChanges();
            }
            //GuildSettingsCache.RefreshGuild(guildId);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            SocketCommandContext context;
            int argPos = 0;
            IResult result;
            //string helpMessage;
            //CommandInfo cmd;
            bool isPrivateMessage = (arg.Channel.GetType() == typeof(SocketDMChannel));

            // If there was no message or the source was a bot, simply do nothing.
            if (message == null || message.Author.IsBot) return;

            //print private messages
            if (isPrivateMessage)
            {
                var m = $"DM {DateTime.Now.ToString("M/d h:mm tt")} - {arg.Author.Username}: {message.Content}";
                System.Console.WriteLine(m);
            }

            var chnl = arg.Channel as SocketTextChannel;
            string gPrefix = "!";
            //if (chnl?.Guild != null)
            //    gPrefix = GuildSettingsCache.GetGuild(chnl.Guild.Id)?.CmdPrefix ?? "!";

            var prefix = IsDebugHost ? "?" : gPrefix;

            //emergency prefix reset
            if (arg.Content == "PrefixEmergencyReset")
            {
                var gu = arg.Author as SocketGuildUser;
                if (gu.GuildPermissions.Has(GuildPermission.Administrator))
                    ResetPrefix(chnl.Guild.Id);
                else
                    await chnl.SendMessageAsync("`PrefixEmergencyReset` requires administrator privledges.");
            }

            //Global Messages,  Dont pass commands, messages from bots
            if (message.Content.Length > 0
                && message.Content[0] != prefix[0]
                && !message.Author.IsBot)
            {
                //await GlobalChatMessenger.BroadcastAsync(_client, message);
            }

            if (message.HasStringPrefix(prefix, ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                // Retrieves the context of the message in a format that Discord will understand natively.
                context = new SocketCommandContext(_client, message);

                try
                {
                    result = await _commands.ExecuteAsync(context, argPos, _services);

                    // Logging command usage stats
                    using (var dbContext = new DubaseContext())
                    {
                        var cName = message.Content.Split(' ')[0].Replace("!", "");
                        var cmd = dbContext.BotCommands.FirstOrDefault(c => c.CommandName.ToLower() == cName.ToLower() ||
                                                                            c.BotCommandAliases.Any(x => x.Alias.ToLower() == cName.ToLower()));
                        if (cmd != null)
                        {
                            dbContext.CommandStats.Add(new CommandStat
                            {
                                CommandId = cmd.Id,
                                CreatedDate = DateTime.Now,
                                UserId = (long)context.User.Id,
                                ErrorMessage = (result.Error != null) ? result.ErrorReason : "",
                            });
                            dbContext.ValidateSave();
                        }
                    }

                    if (result.Error != null) // && result.Error != CommandError.UnknownCommand)
                    {
                        System.Console.WriteLine(result.ErrorReason);
                        throw new UserException(result.ErrorReason, result.ErrorReason, UserException.EMOJI_PUZZLED);
                    }
                }
                catch (FormattedDbEntityValidationException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.InnerException);
                }
                catch (HttpException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.InnerException);
                    await message.Author.SendMessageAsync(ex.Reason);
                }
                catch (UserException ex)
                {
                    if (ex.Emoji != null)
                    {
                        //await message.AddReactionAsync(new Emoji(ex.Emoji));
                    }

                    if (isPrivateMessage)
                    {
                        await message.Author.SendMessageAsync(ex.UserFriendlyMessage);
                    }
                    else
                    {
                        await message.Channel.SendMessageAsync(ex.UserFriendlyMessage);
                    }
                    System.Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                    System.Console.WriteLine(ex.InnerException.Message);
                    System.Console.WriteLine(ex.InnerException.StackTrace);
                }
            }
        }
    }
}

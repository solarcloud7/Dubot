
using Dubot.Utilities;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dubot.Data.Models;
using Dubot.BotConsole.Managers;

namespace Dubot.BotConsole.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        public const string DiscordLink = "https://discord.gg/HcRhqpa";
        public static char[] delimiterChars = { ' ', ',', '.', ':' };


        [Command("permissions")]
        public async Task PermissionsAsync()
        {
            var client = Context.Guild.CurrentUser;
            var cp = client.GetPermissions((Context.Channel as SocketGuildChannel));
            var gp = client.GuildPermissions;

            //GP
            var gpTable = new Table("Permission", "");
            
            foreach (GuildPermission p in Enum.GetValues(typeof(GuildPermission)))
            {
                gpTable.AddRow(
                    Enum.GetName(typeof(GuildPermission), p),
                    gp.Has(p).ToString());
            }
            await ReplyAsync($"***Guild Permission***" + gpTable.ToString());

            //CP
            var cpTable = new Table("Permission", "");
            foreach (ChannelPermission p in Enum.GetValues(typeof(ChannelPermission)))
            {
                cpTable.AddRow(
                  Enum.GetName(typeof(ChannelPermission), p),
                  cp.Has(p).ToString());
            }
            await ReplyAsync($"***Channel Permission***" + cpTable.ToString());
        }


        [Command("help")]
        public async Task HelpAsync(string command = "")
        {
            if (string.IsNullOrEmpty(command))
            {
                await ReplyAsync($"Command Name **{command}** does not exist.  ```!Commands (to get a list of commands)\n!help [command name] (help on a specific command) ```");
                return;
            }

            //using (var context = new CloudBotSuiteEntities())
            //{

            //    var cmd = context.BotCommands
            //        .Include(x => x.BotCommandAlias)
            //        .Include(x => x.BotCommandParameters)
            //        .Where(x => x.CommandName.Equals(command, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            //    if (cmd == null)
            //    {
            //        cmd = context.BotCommands
            //            .Include(x => x.BotCommandAlias)
            //            .Include(x => x.BotCommandParameters)
            //            .Where(x => x.BotCommandAlias.Any(a => a.Alias.Equals(command, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            //        if (cmd == null)
            //        {
            //            await ReplyAsync($"Command Name **{command}** does not exist.  ```!Commands (to get a list of commands)\n!help [command name] (help on a specific command) ```");
            //            return;
            //        }
            //    }

            //    #region ref
            //    /*visualizer
            //    * {
            //       "embed": {
            //       "title": "Command: !delstat",
            //       "description": "Delstat deletes the statistic for the day.  only 1 stat can be saved per day",
            //       "url": "http://cloudbot.solarcloudconsulting.com/Home/BotCommands",
            //       "color": 13527828,
            //       "footer": {
            //           "icon_url": "https://cdn.discordapp.com/embed/avatars/0.png",
            //           "text": "Hades Star Cloud Bot"
            //       }, 
            //       "author": {
            //           "name": "!delstat",
            //           "url": "http://cloudbot.solarcloudconsulting.com/Home/BotCommands"
            //       },
            //       "fields": [
            //           {
            //           "name": "*Alias*:",
            //           "value": "```!ds``````!dstat ```"
            //           },
            //           {
            //           "name": "*Parameters*:",
            //           "value": "none:```!ds```level and @mention```!dstat [level] [@mention] ```"
            //           },
            //           {
            //           "name": "*Example*:",
            //           "value": "```!ds @solarcloud7```"
            //           },
            //           {
            //           "name": "Get More Info at:",
            //           "value": "[Cloud Bot Website](http://cloudbot.solarcloudconsulting.com/)",
            //               "inline": true
            //           }
            //       ]
            //       }
            //   }*/
            //    #endregion

            //    var builder = new EmbedBuilder()
            //    {
            //        Author = new EmbedAuthorBuilder()
            //        {
            //            Name = $"!{cmd.CommandName}",
            //            Url = "http://cloudbot.solarcloudconsulting.com/Home/BotCommands"
            //        },
            //        Color = new Color().Random(),
            //        Url = "http://cloudbot.solarcloudconsulting.com/Home/BotCommands",
            //        //Timestamp = DateTime.Now,
            //        Description = cmd.Summary,
            //        //ThumbnailUrl = member.GetAvatarUrl(),
            //        //ImageUrl = "https://cdn.discordapp.com/attachments/439149831425097729/487720933843402767/bitmap.png",//member.GetAvatarUrl(),
            //        Footer = new EmbedFooterBuilder
            //        {
            //            IconUrl = Context.Client.CurrentUser.GetAvatarUrl(),
            //            Text = "Hades Star Cloud Bot",
            //        },

            //    };

            //    builder.Fields.Add(new EmbedFieldBuilder { Name = "*Aliases*:", Value = $"```{FormatAlias(cmd)}```" });
            //    builder.Fields.Add(new EmbedFieldBuilder { Name = "*Parameters*:", Value = $"```{FormatParams(cmd)}```" });

            //    if (!string.IsNullOrEmpty(cmd.Example))
            //        builder.Fields.Add(new EmbedFieldBuilder { Name = "*Example*:", Value = $"```{cmd.Example} ```" });

            //    builder.Fields.Add(new EmbedFieldBuilder
            //    { Name = "Get More Info at:", Value = "[Cloud Bot Website](http://cloudbot.solarcloudconsulting.com/)" });

            //    var embed = builder.Build();
            //    await ReplyAsync("", false, embed);

            //}
        }

        //private string FormatAlias(BotCommand bc)
        //{
        //    var format = "";

        //    var paramLine = "";
        //    if (bc.BotCommandParameters.Any())
        //    {
        //        var param = bc.BotCommandParameters.First();
        //        var plist = param.ParamName.Split(delimiterChars);
        //        foreach (var p in plist)
        //        {
        //            paramLine += $"[{p}] ";
        //        }
        //    }

        //    foreach (var a in bc.BotCommandAlias)
        //    {
        //        format += $"!{a.Alias} {paramLine}\n";
        //    }
        //    return format;
        //}

        //private string FormatParams(BotCommand bc)
        //{
        //    var paramGroup = "";
        //    foreach (var param in bc.BotCommandParameters)
        //    {
        //        var plist = param.ParamName.Split(delimiterChars);
        //        var paramLine = "";
        //        foreach (var p in plist)
        //        {
        //            paramLine += $"[{p}] ";
        //        }

        //        paramGroup += $"!{param.BotCommand.CommandName} {paramLine} \n";
        //    }
        //    return paramGroup;
        //}

        [Command("Commands")]
        public async Task GetCommandList()
        {
            var channel = await Context.User.GetOrCreateDMChannelAsync();

            using (var context = new DubaseContext())
            {
                // https://stackoverflow.com/questions/60347952/ambiguous-call-when-using-linq-extension-method-on-dbsett
                var moduleGroup = context.BotCommands.AsQueryable().Where(x => x.Display.HasValue && x.Display.Value).GroupBy(x => x.Module);

                foreach (var Module in moduleGroup)
                {
                    var moduleName = Module.FirstOrDefault().Module;

                    var table = new Table($"Command {moduleName.Truncate(10)}", "Parameters", "Alias");

                    foreach (var command in Module)
                    {
                        table.AddRow(command.CommandName,
                                command.ParamDisplay,
                                command.AliasDisplay
                                );
                    }

                    //table.ToStringNoFormat().ChunksUpto(1971);
                    foreach (string chunk in table.AsStringChunks())
                    {
                        await channel.SendMessageAsync(chunk);
                    }
                }
            }
        }

        [Command("welcome")]
        public async Task WelcomeAsync()
        {
            await UserManager.WelcomeEmbed(Context.User as SocketGuildUser);
        }

        [Command("support")]
        [Alias("sup")]
        public async Task SupportAsync()
        {
            await ReplyAsync($"Learn more about Cloud Bot and get support at:\n {DiscordLink}");
        }
    }


}

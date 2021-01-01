using Discord;
using Discord.WebSocket;
using Dubot.Data.Exceptions;
using Dubot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Managers
{
    public static class UserManager
    {

        public async static void InitUsers(List<SocketGuild> guildList)
        {
            try
            {
                using (var context = new DubaseContext())
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var newGuilds = 0;
                    var newMembers = 0;
                    var guilds = 0;
                    var members = 0;

                    foreach (var guild in guildList)
                    {
                        if (guild.Name == "Discord Bot List")
                            continue;

                        if (guild.Name == null)
                            Console.WriteLine("null name in guild: " + guild.Id);

                        guilds++;
                        members += guild.Users.Count();

                        //Add guild if no guild
                        var guildDB = context.Guilds.FirstOrDefault(g => g.GuildId == (long)guild.Id);
                        if (guildDB == null)
                        {
                            context.Guilds.Add(new Guild
                            {
                                GuildId = (long)guild.Id,
                                Name = guild.Name ?? "",
                                Owner = guild.Owner.Username,
                                CmdPrefix = "!"
                            });
                            newGuilds++;
                        }
                        else
                        {
                            guildDB.Name = guild.Name;
                            guildDB.Owner = guild?.Owner?.Username ?? "none";
                        }


                        var privateIndex = 0;
                        foreach (var member in guild.Users.Where(x => x.Status == UserStatus.Online).ToList())
                        {
                            if (!context.Users.Any(u => u.Id == (long)member.Id))
                            {
                                //create
                                context.Users.Add(new User
                                {
                                    Id = (long)member.Id,
                                    LastSeen = DateTime.Now,
                                    UserName = member.Username,
                                    //GuildId = (long)member.Guild.Id
                                });
                                newMembers++;
                                privateIndex++;
                                if (privateIndex > 10)
                                {
                                    context.ValidateSave();
                                    privateIndex = 0;
                                    Console.WriteLine($"Added 10x new users");
                                }
                            }

                            if (!context.GuildMembers.Any(gm => gm.GuildId == (long)guild.Id && gm.UserId == (long)member.Id))
                                context.GuildMembers.Add(new GuildMember
                                {
                                    GuildId = (long)guild.Id,
                                    Nickname = member.Nickname,
                                    UserId = (long)member.Id,
                                    UserName = member.Username,
                                });
                        }

                    }


                    context.ValidateSave();

                    Console.WriteLine($"Total Guilds: {guilds}");
                    Console.WriteLine($"Total Members: {members}");
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine($"InitUsers took {elapsedMs}ms.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InitUsers: " + ex.Message);
            }
        }

        public static void Login(SocketGuildUser user)
        {
            if (IsBlackList(user))
                return;

            using (var context = new DubaseContext())
            {
                var gm = context.GetOrCreateGuildMember(user);
                if (gm?.User != null)
                {
                    gm.User.LastSeen = DateTime.Now;
                    context.SaveChanges();
                }

            }
        }

        public static bool IsBlackList(SocketGuildUser user)
        {
            if (user.IsBot)
                return true;

            if (user.Guild.Name == "Discord Bot List")
                return true;

            return false;
        }

        public static bool IsOnline(SocketGuildUser user)
        {
            return user.Status == UserStatus.Online;
        }

        public static async Task Away(SocketGuildUser user)
        {
            if (IsBlackList(user))
                return;

            try
            {
                using (var context = new DubaseContext())
                {
                    var gm = context.GetOrCreateGuildMember(user);
                    if (gm?.User != null)
                    {
                        gm.User.LastSeen = DateTime.Now;
                        await context.SaveChangesAsync();
                    }

                }
            }
            catch (Exception ex)
            {
                var inner = ex?.InnerException?.Message ?? "";
                var inner2 = ex?.InnerException?.InnerException?.Message ?? "";
                Console.WriteLine("Away: " + ex.Message + inner + inner2);
            }
        }

        public static string Seen(SocketGuildUser user)
        {
            if (user.Status == UserStatus.Online) return "Now";

            using (var context = new DubaseContext())
            {
                var _user = context.Users.FirstOrDefault(u => u.Id == (long)user.Id);

                if (_user == null)
                    return "Never";
                else
                    return $"<@{user.Id}> was last seen {_user.LastSeen.DisplayTime()}";

            }
        }

        public async static Task WelcomeEmbed(SocketGuildUser user)
        {
            var builder = new EmbedBuilder()
            .WithTitle($"Welcome {user.Username}!")
            .WithDescription("This appears to be your first time here! We are a very **competitive**, profesional corporation for Hades Star! Now that you know something about us, tell us something about you!")
            .WithColor(new Color(0x8D8434))
            .WithTimestamp(DateTimeOffset.Now)
            .WithFooter(footer =>
            {
                footer.WithText("Did you know we are recruiting!")
                    .WithIconUrl("https://cdn.discordapp.com/app-icons/429082137703088130/29221e4e1aa2a79332c4d9caf8472181.png");
            })
            .WithThumbnailUrl("https://cdn.discordapp.com/app-icons/429082137703088130/29221e4e1aa2a79332c4d9caf8472181.png")
            .WithAuthor(author =>
            {
                author.WithName("The Force")
                .WithIconUrl("https://cdn.discordapp.com/app-icons/429082137703088130/29221e4e1aa2a79332c4d9caf8472181.png");
            })
            .AddField("Bot Commands:", "Learn more about us.  Start by typing: ```!help```");

            var embed = builder.Build();

            await UserExtensions.SendMessageAsync(user, "", false, embed);
        }
    }
}

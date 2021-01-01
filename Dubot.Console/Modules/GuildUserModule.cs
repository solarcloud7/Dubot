using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Dubot.BotConsole.Managers;
using Dubot.Data.Models;
using Dubot.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Modules
{
    public class GuildUserModule : BaseModule
    {
        [Command("seen")]
        public async Task SeenAsync(SocketGuildUser user)
        {
            if (Context.Message.MentionedUsers.Count > 0)
            {
                await ReplyAsync(UserManager.Seen(user));
            }

            await Context.Message.DeleteAsync();
        }

        [Command("cseen")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ChannelSeenAsync()
        {
            //validation
            if (!IsFromGuildChat())
                return;

            var cUsers = (Context.Channel as SocketTextChannel)?.Users;

            var table = new Table("Name", "Last Seen");

            using (var context = new DubaseContext())
            {
                var now = DateTime.Now;
                Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

                foreach (var user in cUsers)
                {
                    var dbUser = context.Users.FirstOrDefault(u => u.Id == (long)user.Id);
                    if (dbUser == null || string.IsNullOrEmpty(dbUser.UserName))
                        continue;

                    var dName = dbUser.DisplayName((long)Context.Guild.Id);
                    var lastSeen = UserManager.IsOnline(user) ? now : (dbUser.LastSeen.HasValue) ? dbUser.LastSeen.Value : DateTime.MinValue;
                    list.Add(dName, lastSeen);
                }

                list.OrderByDescending(x => x.Value)
                    .ForEach(x => table.AddRow(x.Key, x.Value.DisplayTime()));
            }

            foreach (var chunk in table.AsStringChunks())
            {
                await ReplyAsync(chunk);
            }

            await Context.Message.DeleteAsync();
        }
    }
}

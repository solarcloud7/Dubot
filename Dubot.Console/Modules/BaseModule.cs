using Discord.Commands;
using Discord.WebSocket;
using Dubot.BotConsole.Exceptions;
using Dubot.BotConsole.Managers;
using Dubot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Modules
{
    public class BaseModule : ModuleBase<SocketCommandContext>
    {
        protected User GetUser()
        {
            using (var context = new DubaseContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == (long)Context.User.Id);
            }
        }

        #region Validation
        /// <summary>
        /// Validates the Context.User for specified role.  Sends Message if fail.
        /// </summary>
        /// <param name="role"></param>
        /// <returns>bool</returns>
        public async Task<bool> HasRole(string role)
        {
            var hasRole = ((SocketGuildUser)Context.User).Roles.Any(r => r.Name == role);
            if (hasRole == false)
                await ReplyAsync($"{Context.User.DisplayName()} does not have the role of '{role}' ...");

            return hasRole;
        }
        /// <summary>
        /// Validates Context.User sent comand from Guild Chat. Sends Message if fail.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsFromGuildChat()
        {
            var IsFromGuildChat = Context.Guild != null && Context.Guild.Id != 0;
            if (IsFromGuildChat == false)
                throw new RequiresDiscordGuildException();

            return IsFromGuildChat;
        }

        public async Task<bool> IsAdmin()
        {
            var IsAdmin = ((SocketGuildUser)Context.User).GuildPermissions.Administrator;
            if (IsAdmin == false)
                await ReplyAsync($"{Context.User.DisplayName()} is not a discord admin ...");

            return IsAdmin;
        }
        #endregion
    }
}

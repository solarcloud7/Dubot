using System;
using System.Collections.Generic;
using System.Text;

namespace Dubot.BotConsole.Exceptions
{
    public class RequiresDiscordGuildException : UserException
    {
        public RequiresDiscordGuildException() : base("Command executed outside of Discord Guild", "")
        {
            this.UserFriendlyMessage = "Please run that command from inside a Discord Guild.";
        }
    }
}

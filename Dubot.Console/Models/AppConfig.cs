using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Dubot.BotConsole.Models
{
    public static class AppConfig
    {
        public static string BotToken { get { return ConfigurationManager.AppSettings["BotToken"]; } }
        public static string DebugBotToken { get { return ConfigurationManager.AppSettings["DebugBotToken"]; } }
       
    }
   
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Dubot.Data
{
    public static class AppConfig
    {
        public static string ConnectionString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dubot.Data.Models
{
    public partial class BotCommand
    {
        public string ParamDisplay
        {
            get
            {
                string display = "";
                for (int i = 0; i < BotCommandParameters.Count(); i++)
                {
                    display += $"[{BotCommandParameters.ElementAt(i).ParamName}]";

                    display += (i == BotCommandParameters.Count() - 1) ? "," : "";
                }
                return display;
            }
        }

        public string AliasDisplay
        {
            get
            {
                string display = "";
                for (int i = 0; i < this.BotCommandAliases.Count(); i++)
                {
                    display += $"[{this.BotCommandAliases.ElementAt(i).Alias}]";

                    display += (i == this.BotCommandAliases.Count() - 1) ? "," : "";
                }
                return display;
            }
        }
    }
}

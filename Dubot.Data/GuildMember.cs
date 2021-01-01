using Dubot.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dubot.Data.Models
{
    public partial class GuildMember
    {
        public string DisplayName
        {
            get
            {
                string name = (!string.IsNullOrEmpty(this.Nickname)) ? this.Nickname : this.UserName;

                return name.FirstLetterToUpperCase()
                    .Replace(".", "") // Only remove "." from names.  It breaks  ```prolog formatting
                    .Sanitize();
            }
        }

        public string DisplayNameShort
        {
            get
            {
                string name = (!string.IsNullOrEmpty(this.Nickname)) ? this.Nickname : this.UserName;

                if (name.Length > 18 && name.IndexOf(" ") != -1)
                {
                    // Attempt to reduce the length of the name, should be OK since there's a space.
                    name = name.Substring(0, name.IndexOf(" "));
                }

                if (name.Length > 18)
                {
                    // Name is *still* too long, just force it!
                    name = name.Substring(0, 18);
                }
                return name.FirstLetterToUpperCase()
                    .Replace(".", "") // Only remove "." from names.  It breaks  ```prolog formatting
                    .Sanitize();
            }
        }
    }
}

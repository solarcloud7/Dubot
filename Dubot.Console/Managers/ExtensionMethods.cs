using Discord;
using Discord.WebSocket;
using Dubot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Managers
{
    public static class ExtentionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static bool IsFirst<T>(this List<T> items, int index)
        {
            return index == 0;
        }

        public static bool IsLast<T>(this List<T> items, int index)
        {
            return items.Count == index + 1;
        }

        public static string PadRight(this int i, int padding)
        {
            return i.ToString().PadRight(padding);
        }

        public static string DisplayName(this SocketUser u)
        {
            var user = u as SocketGuildUser;
            var name = (!string.IsNullOrEmpty(user.Nickname)) ? user.Nickname : user.Username;
            return name.FirstLetterToUpperCase().Sanitize();
        }


        public static string DisplayTime(this Nullable<DateTime> datetime)
        {
            return DisplayTime(datetime ?? DateTime.MinValue);
        }

        public static string DisplayTime(this DateTime datetime)
        {
            var past = DateTime.Now - datetime;

            if (past.TotalSeconds < 1)
            {
                return "Now";
            }
            else if (past.TotalMinutes < 1)
            {
                return $"{past.Seconds} sec ago";
            }
            else if (past.TotalHours < 1)
            {
                return $"{past.Minutes} min {past.Seconds} sec ago";
            }
            else if (past.TotalDays < 1)
            {
                return $"{past.Hours} hr {past.Minutes} min ago";
            }
            else if (past.TotalDays < 365)
            {
                return $"{(int)past.TotalDays} d {past.Hours} hr ago";
            }
            else if (past.TotalDays > 5000)
            {
                return $"Never";
            }
            else
            {
                return $"> 1 year ago";
            }
        }

        public static string DisplayTimeSpanShort(this TimeSpan timeSpan)
        {
            if (timeSpan.TotalSeconds < 1)
            {
                return "0s";
            }
            else if (timeSpan.TotalMinutes < 1)
            {
                return $"{timeSpan.Seconds}s";
            }
            else if (timeSpan.TotalHours < 1)
            {
                return $"{timeSpan.TotalMinutes:0.#}m";
            }
            else if (timeSpan.TotalDays < 1)
            {
                return $"{timeSpan.TotalHours:0.#}hr";
            }
            else if (timeSpan.TotalDays < 365)
            {
                return $"{(int)timeSpan.TotalDays:0.#}d";
            }
            else if (timeSpan.TotalDays > 5000)
            {
                return $"Na";
            }
            else
            {
                return $"+1yr";
            }
        }


        public static string DisplayTimeShort(this DateTime datetime)
        {
            var past = DateTime.Now - datetime;

            if (past.TotalSeconds < 1)
            {
                return "0s";
            }
            else if (past.TotalMinutes < 1)
            {
                return $"{past.Seconds}s";
            }
            else if (past.TotalHours < 1)
            {
                return $"{past.TotalMinutes:0.#}m";
            }
            else if (past.TotalDays < 1)
            {
                return $"{past.TotalHours:0.#}hr";
            }
            else if (past.TotalDays < 365)
            {
                return $"{(int)past.TotalDays:0.#}d";
            }
            else if (past.TotalDays > 5000)
            {
                return $"Na";
            }
            else
            {
                return $"+1yr";
            }
        }

        private static string p(int i)
        {
            return (i == 1) ? "" : "s";
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;

            if (value.Length <= maxLength)
            {
                return value;
            }
            else
            {
                var newstring = value.Substring(0, maxLength);
                return newstring + "...";
            }
        }
        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static List<string> SplitString(this string str, int chunkSize)
        {
            List<string> chunks = new List<string>();
            while (str.Length > chunkSize)
            {
                chunks.Add(str.Substring(0, chunkSize));
                str = str.Substring(chunkSize);
            }
            chunks.Add(str);
            return chunks;
        }

        public static string Sanitize(this string s)
        {
            s = s.Replace("'", "")
                .RemoveSpecialChars();

            return s;
        }

        public static string RemoveSpecialChars(this string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if ((c >= '0' && c <= '9')
                    || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || c == '.' || c == '_'
                    || c == '[' || c == ']' || c == '|')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static IEnumerable<string> ChunksUpto(this string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }


        public static Color Random(this Color color)
        {
            Random rnd = new Random();
            return new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
        public static string DisplayName(this User user, long guildId)
        {
            if (guildId == 0)
                return "";
            var name = user.GuildMembers.FirstOrDefault(m => m.GuildId == guildId && m.UserId == user.Id)?.DisplayName;

            if (string.IsNullOrEmpty(name))
                name = user.UserName;

            if (string.IsNullOrEmpty(name))
                return "";

            return name;
        }

        public static GuildMember Get(this DbSet<GuildMember> gm, ulong guildId, ulong userId)
        {
            return gm.FirstOrDefault(m => m.GuildId == (long)guildId && m.UserId == (long)userId);
        }
              

        public static async Task<bool> SafeDeleteAsync(this IUserMessage m)
        {
            try
            {
                var channel = DubotConsole.GetClient().GetChannel(m.Channel.Id) as SocketTextChannel;
                if ((channel != null))
                {
                    var message = await channel.GetMessageAsync(m.Id);
                    if (message != null)
                    {
                        await message.DeleteAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SafeDelete fail: {m.Content}");
                return false;
            }
        }

        public static GuildMember GetOrCreateGuildMember(this DubaseContext context, SocketGuildUser sgUser)
        {

            if (string.IsNullOrEmpty(sgUser.Username))
            {
                Console.WriteLine($"{sgUser.Id} username was null!!!!!");
                return null;
            }

            User user = context.Users
                .Include(x => x.GuildMembers)
                .FirstOrDefault(x => x.Id == (long)sgUser.Id);

            if (user == null)
            {
                user = new User
                {
                    Id = (long)sgUser.Id,
                    LastSeen = DateTime.Now,
                    UserName = sgUser.Username,
                };
                context.Users.Add(user);
            }

            var gm = user.GuildMembers.FirstOrDefault(x => x.GuildId == (long)sgUser.Guild.Id);
            if (gm == null)
            {
                gm = new GuildMember
                {
                    GuildId = (long)sgUser.Guild.Id,
                    Nickname = sgUser.Nickname,
                    UserId = (long)sgUser.Id,
                    UserName = sgUser.Username,
                };
                user.GuildMembers.Add(gm);

            }
            context.SaveChanges();
            return gm;
        }

        //NOT sanitized
        public static string NickOrUsername(this SocketUser u)
        {
            var user = u as SocketGuildUser;
            var name = (!string.IsNullOrEmpty(user.Nickname)) ? user.Nickname : user.Username;
            return name.FirstLetterToUpperCase();
        }

        public static async Task<string> GetEmojiAsync(this SocketGuild senderGuild)
        {
            var i = senderGuild.Emotes.FirstOrDefault(x => x.Name == "cbicon");
            if (i == null)
            {
                try
                {
                    i = await CreateIconAsync(senderGuild);
                    return $"<{(i.Animated ? "a" : "")}:{i.Name}:{i.Id}>";
                }
                catch (System.Exception)
                {
                    Console.WriteLine($"Icon error for {senderGuild.Name}");
                    return "";
                }
            }
            else
            {
                return $"<{(i.Animated ? "a" : "")}:{i.Name}:{i.Id}>";
            }
        }

        public static async Task<GuildEmote> CreateIconAsync(SocketGuild guild)
        {
            var url = guild.IconUrl;
            //new Image()
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Open a stream to point to the data stream coming from the Web resource.
            Stream myStream = myWebClient.OpenRead(url);
            //myStream.Seek(0, SeekOrigin.Begin);
            var i = new Image(myStream);

            var x = await guild.CreateEmoteAsync("cbicon", i);
            myStream.Close();
            return x;
        }

        public static async Task SendBulkDirectMessage(this SocketTextChannel channel, List<SocketGuildUser> users, string message)
        {
            //sometimes members disabled bot private messages.
            string unableMembers = "";
            foreach (var user in users)
            {
                try
                {
                    var dmch = await user.GetOrCreateDMChannelAsync();
                    await dmch.SendMessageAsync(message);
                }
                catch (Exception ex)
                {
                    unableMembers += user.Mention + "";
                    Console.WriteLine($"Alert Failed for {user.Username}: {ex.Message}");
                }
            }

            //add info about the message
            if (!string.IsNullOrEmpty(unableMembers))
            {
                message = message + $"*Direct Message disabled for the following users:*\n{unableMembers}";
            }
            await channel.SendMessageAsync(message);
        }
    }
}

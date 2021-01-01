using Discord;
using Discord.Commands;
using Dubot.BotConsole.Managers;
using Dubot.Data.Models;
using Dubot.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Modules
{
    public class DuItemModule : ModuleBase<SocketCommandContext>
    {

        [Command("categories")]
        public async Task DisplayCategoriesAsync()
        {
            var table = new Table("Id", "Category");

            using (var context = new DubaseContext())
            {
                var itemCategories = context.ItemCategories.AsQueryable().Take(10).ToList();
                //.OrderBy(x => x.FullPath);

                var i = 1;
                foreach (var category in itemCategories)
                {
                    table.AddRow(i.ToString(), category.FullPath);
                    i++;
                }

                foreach (string chunk in table.AsStringChunks())
                {
                    await Context.Channel.SendMessageAsync(chunk);
                }
            }
        }

        [Command("items")]
        public async Task DisplayItemsAsync()
        {

            using (var context = new DubaseContext())
            {
                var items = context.Items
                    .Include(x => x.Category)
                    //show parent category up to 5x deep
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .OrderBy(x => x.CategoryId)
                    .ThenBy(x => x.ItemName);

                var table = new Table("Id", "Item Names", "Category");

                var i = 1;
                foreach (var item in items)
                {
                    table.AddRow(i.ToString(), item.ItemName, item.CategoryName);
                    i++;
                }

                foreach (string chunk in table.AsStringChunks("All Items"))
                {
                    await Context.Channel.SendMessageAsync(chunk);
                }
            }
        }

        /// <summary>
        /// Search all items for a match and display data for 1 OR a list to be more specific
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [Command("item")]
        public async Task DisplayItemAsync(string search)
        {

            using (var context = new DubaseContext())
            {
                // search items
                var items = context.Items
                    .Include(x => x.Category)
                    //show parent category up to 5x deep
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)
                    .ThenInclude(x => x.ParentCategory)

                    .Where(x => x.ItemName.Contains(search))
                    .OrderBy(x => x.ItemName);

                // must have at least 1
                if (items.Count() == 0)
                {
                    await ReplyAsync($"No Matches for `{search}`");
                    return;
                }

                // if more than one result,  return list and have user be more specific
                if (items.Count() > 1)
                {
                    var table = new Table("Id", "Item Names");

                    var i = 1;
                    foreach (var item in items)
                    {
                        table.AddRow(i.ToString(), item.ItemName);
                        i++;
                    }

                    foreach (string chunk in table.AsStringChunks("Posible Matches"))
                    {
                        await Context.Channel.SendMessageAsync(chunk);
                    }
                }
                // Only 1 result should show an embed
                else
                {
                    var item = items.First();
                    var embed = GetEmbed(item);

                    await ReplyAsync("", false, embed);
                }



            }
        }

        private Embed GetEmbed(Item item)
        {
            var builder = new EmbedBuilder()
            {
                Author = new EmbedAuthorBuilder()
                {
                    Name = item.ItemName,
                },
                Color = new Color().Random(),
                //Timestamp = DateTime.Now,
                //Description = "description",
                //ThumbnailUrl = member.GetAvatarUrl(),
                //ImageUrl = "https://cdn.discordapp.com/attachments/439149831425097729/487720933843402767/bitmap.png",//member.GetAvatarUrl(),
                Footer = new EmbedFooterBuilder
                {
                    IconUrl = Context.Client.CurrentUser.GetAvatarUrl(),
                    Text = "Made with DuBot",

                },
                Fields = new List<EmbedFieldBuilder>()
                {
                  new EmbedFieldBuilder()
                  {
                      Name = "Category",
                      Value = item.Category.FullPath
                  }
                },
            };
            return builder.Build();
        }
    }
}

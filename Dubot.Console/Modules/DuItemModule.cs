using Discord.Commands;
using Dubot.Data.Models;
using Dubot.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubot.BotConsole.Modules
{
    public class DuItemModule : ModuleBase<SocketCommandContext>
    {

        [Command("ducategories")]
        public async Task DisplayCategoriesAsync()
        {
            var table = new Table("Id","Category");

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

    }
}

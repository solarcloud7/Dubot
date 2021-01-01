using System;
using System.Collections.Generic;
using System.Text;

namespace Dubot.Data.Models
{
    public partial class ItemCategory
    {

        public String FullPath
        {
            get
            {
                return GetParentCategory(this);
            }
        }

        private string GetParentCategory(ItemCategory itemCategory)
        {
            if(itemCategory.ParentCategory == null)
            {
                return "";
            }
            else
            {
                return GetParentCategory(itemCategory.ParentCategory) + "-" + itemCategory.CategoryName;
            }
        }
    }
}
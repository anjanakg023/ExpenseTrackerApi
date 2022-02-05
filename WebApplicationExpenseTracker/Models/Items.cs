using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class Items
    {
        public Items()
        {
            ItemList = new HashSet<ItemList>();
        }

        public int ItemId { get; set; }
        public int? CategoryId { get; set; }
        public string Itemname { get; set; }
        public int? Itemcost { get; set; }
        public int? Itembill { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<ItemList> ItemList { get; set; }
    }
}

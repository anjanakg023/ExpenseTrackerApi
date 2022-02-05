using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class ItemList
    {
        public ItemList()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int Itemlistid { get; set; }
        public int? Itemid { get; set; }

        public virtual Items Item { get; set; }
        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}

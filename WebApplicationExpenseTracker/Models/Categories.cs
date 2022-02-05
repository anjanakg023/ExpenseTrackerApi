using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Items = new HashSet<Items>();
        }

        public int CategoryId { get; set; }
        public string Categoryname { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}

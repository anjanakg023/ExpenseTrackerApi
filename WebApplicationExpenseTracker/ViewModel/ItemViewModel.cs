using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationExpenseTracker.ViewModel
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string Itemname { get; set; }
        public int? Itemcost { get; set; }
        public string Categoryname { get; set; }
    }
}

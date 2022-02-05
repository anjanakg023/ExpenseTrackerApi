using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class Expenses
    {
        public int Expenseid { get; set; }
        public int? UserId { get; set; }
        public int? Itemlistid { get; set; }
        public DateTime? Expensedate { get; set; }
        public int? Totalexpense { get; set; }

        public virtual ItemList Itemlist { get; set; }
        public virtual Users User { get; set; }
    }
}

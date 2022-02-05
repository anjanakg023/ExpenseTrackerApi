using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationExpenseTracker.ViewModel
{
    public class ExpenseViewModel
    {
        public DateTime? Expensedate { get; set; }
        public string Categoryname { get; set; }
        public string Itemname { get; set; }
        public int Expenseid { get; set; }
        public string month { get; set; }
    }
}

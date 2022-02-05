using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class Users
    {
        public Users()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public string Useraddress { get; set; }
        public string LoginId { get; set; }

        public virtual Login Login { get; set; }
        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}

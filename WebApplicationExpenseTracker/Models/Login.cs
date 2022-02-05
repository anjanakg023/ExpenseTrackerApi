using System;
using System.Collections.Generic;

namespace WebApplicationExpenseTracker.Models
{
    public partial class Login
    {
        public Login()
        {
            Users = new HashSet<Users>();
        }

        public string LoginId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}

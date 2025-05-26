using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } // Admin or Member
        public string PasswordHash { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }

}
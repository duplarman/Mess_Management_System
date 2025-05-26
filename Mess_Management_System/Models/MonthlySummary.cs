using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class MonthlySummary
    {
        public int MonthlySummaryId { get; set; }
        public int MemberId { get; set; }
        public DateTime Month { get; set; }
        public int TotalMeals { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal MealCost { get; set; }
        public decimal Balance { get; set; }

        public virtual Member Member { get; set; }
    }

}
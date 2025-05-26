using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public int MemberId { get; set; }
        public DateTime MealDate { get; set; }
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }

        public virtual Member Member { get; set; }
    }
}
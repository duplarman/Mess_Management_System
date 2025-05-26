using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class MealRate
    {
        public int MealRateId { get; set; }
        public decimal TotalMarket { get; set; }
        public int TotalMeals { get; set; }
        public decimal RatePerMeal { get; set; }
        public DateTime Month { get; set; }
    }
}
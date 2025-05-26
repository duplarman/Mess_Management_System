using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class MessDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MealRate> MealRates { get; set; }
        public DbSet<MonthlySummary> MonthlySummaries { get; set; }
        public DbSet<Notice> Notices { get; set; }

        public MessDbContext() : base("DefaultConnection") { }
    }
}
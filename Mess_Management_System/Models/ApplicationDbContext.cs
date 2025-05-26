using System.Data.Entity;

namespace Mess_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MealRate> MealRates { get; set; }
        public DbSet<MonthlySummary> MonthlySummaries { get; set; }
        public DbSet<Notice> Notices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<Meal>()
                .HasRequired(m => m.Member)
                .WithMany(m => m.Meals)
                .HasForeignKey(m => m.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Member)
                .WithMany(m => m.Payments)
                .HasForeignKey(p => p.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonthlySummary>()
                .HasRequired(ms => ms.Member)
                .WithMany()
                .HasForeignKey(ms => ms.MemberId)
                .WillCascadeOnDelete(false);
        }
    }
} 
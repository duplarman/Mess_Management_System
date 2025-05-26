namespace Mess_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        MarketId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasedBy = c.String(),
                    })
                .PrimaryKey(t => t.MarketId);
            
            CreateTable(
                "dbo.MealRates",
                c => new
                    {
                        MealRateId = c.Int(nullable: false, identity: true),
                        TotalMarket = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalMeals = c.Int(nullable: false),
                        RatePerMeal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Month = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MealRateId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MealDate = c.DateTime(nullable: false),
                        Breakfast = c.Int(nullable: false),
                        Lunch = c.Int(nullable: false),
                        Dinner = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Role = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MonthlySummaries",
                c => new
                    {
                        MonthlySummaryId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Month = c.DateTime(nullable: false),
                        TotalMeals = c.Int(nullable: false),
                        TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MealCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MonthlySummaryId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlySummaries", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Payments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Meals", "MemberId", "dbo.Members");
            DropIndex("dbo.MonthlySummaries", new[] { "MemberId" });
            DropIndex("dbo.Payments", new[] { "MemberId" });
            DropIndex("dbo.Meals", new[] { "MemberId" });
            DropTable("dbo.Notices");
            DropTable("dbo.MonthlySummaries");
            DropTable("dbo.Payments");
            DropTable("dbo.Members");
            DropTable("dbo.Meals");
            DropTable("dbo.MealRates");
            DropTable("dbo.Markets");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Mess_Management_System.Models;
using Mess_Management_System.Services;

namespace Mess_Management_System.Services.Implementation
{
    public class MealService : BaseService<Meal>, IMealService
    {
        public MealService(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Meal> GetMealsByDate(DateTime date)
        {
            return Find(m => m.Date.Date == date.Date);
        }

        public IEnumerable<Meal> GetMealsByMember(int memberId, DateTime startDate, DateTime endDate)
        {
            return Find(m => m.MemberId == memberId && m.Date >= startDate && m.Date <= endDate);
        }

        public int GetTotalMealsByMember(int memberId, int year, int month)
        {
            return Find(m => m.MemberId == memberId && m.Date.Year == year && m.Date.Month == month)
                .Sum(m => m.Breakfast + m.Lunch + m.Dinner);
        }

        public DataTable GetDailyMealSummary(DateTime date)
        {
            var meals = GetMealsByDate(date);
            var dataTable = new DataTable();

            dataTable.Columns.Add("MemberId", typeof(int));
            dataTable.Columns.Add("MemberName", typeof(string));
            dataTable.Columns.Add("Breakfast", typeof(int));
            dataTable.Columns.Add("Lunch", typeof(int));
            dataTable.Columns.Add("Dinner", typeof(int));
            dataTable.Columns.Add("Total", typeof(int));

            foreach (var meal in meals)
            {
                var row = dataTable.NewRow();
                row["MemberId"] = meal.MemberId;
                row["MemberName"] = meal.Member?.Name ?? "Unknown";
                row["Breakfast"] = meal.Breakfast;
                row["Lunch"] = meal.Lunch;
                row["Dinner"] = meal.Dinner;
                row["Total"] = meal.Breakfast + meal.Lunch + meal.Dinner;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable GetMonthlyMealSummary(int year, int month)
        {
            var meals = Find(m => m.Date.Year == year && m.Date.Month == month);
            var dataTable = new DataTable();

            dataTable.Columns.Add("MemberId", typeof(int));
            dataTable.Columns.Add("MemberName", typeof(string));
            dataTable.Columns.Add("TotalMeals", typeof(int));

            var memberMeals = meals.GroupBy(m => m.MemberId)
                .Select(g => new
                {
                    MemberId = g.Key,
                    MemberName = g.First().Member?.Name ?? "Unknown",
                    TotalMeals = g.Sum(m => m.Breakfast + m.Lunch + m.Dinner)
                });

            foreach (var memberMeal in memberMeals)
            {
                var row = dataTable.NewRow();
                row["MemberId"] = memberMeal.MemberId;
                row["MemberName"] = memberMeal.MemberName;
                row["TotalMeals"] = memberMeal.TotalMeals;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
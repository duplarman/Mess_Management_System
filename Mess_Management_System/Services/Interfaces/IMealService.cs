using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IMealService 
    {
        IEnumerable<Meal> GetMealsByDate(DateTime date);
        IEnumerable<Meal> GetMealsByMember(int memberId, DateTime startDate, DateTime endDate);
        int GetTotalMealsByMember(int memberId, int year, int month);
        DataTable GetDailyMealSummary(DateTime date);
        DataTable GetMonthlyMealSummary(int year, int month);
    }
} 
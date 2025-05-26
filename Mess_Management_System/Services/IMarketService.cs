using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IMarketService : IBaseService<Market>
    {
        IEnumerable<Market> GetMarketsByDate(DateTime date);
        IEnumerable<Market> GetMarketsByDateRange(DateTime startDate, DateTime endDate);
        decimal GetTotalMarketCost(int year, int month);
        DataTable GetDailyMarketSummary(DateTime date);
        DataTable GetMonthlyMarketSummary(int year, int month);
    }
} 
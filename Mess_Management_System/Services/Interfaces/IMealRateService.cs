using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IMealRateService : IBaseService<MealRate>
    {
        MealRate GetCurrentMealRate();
        MealRate GetMealRateByMonth(int year, int month);
        decimal CalculateMealRate(int year, int month);
        void UpdateMealRate(int year, int month, decimal rate);
        DataTable GetMealRateHistory(int year);
    }
} 
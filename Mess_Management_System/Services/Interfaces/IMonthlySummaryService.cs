using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IMonthlySummaryService : IBaseService<MonthlySummary>
    {
        MonthlySummary GetSummaryByMember(int memberId, int year, int month);
        IEnumerable<MonthlySummary> GetSummariesByMonth(int year, int month);
        void GenerateMonthlySummaries(int year, int month);
        DataTable GetMonthlyReport(int year, int month);
        void UpdateMemberSummary(int memberId, int year, int month);
    }
} 
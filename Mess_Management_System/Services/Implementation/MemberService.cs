using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mess_Management_System.Models;
using Mess_Management_System.Services;

namespace Mess_Management_System.Services.Implementation
{
    public class MemberService : BaseService<Member>, IMemberService
    {
        private readonly IMealService _mealService;
        private readonly IPaymentService _paymentService;
        private readonly IMonthlySummaryService _monthlySummaryService;

        public MemberService(
            ApplicationDbContext context,
            IMealService mealService,
            IPaymentService paymentService,
            IMonthlySummaryService monthlySummaryService) : base(context)
        {
            _mealService = mealService;
            _paymentService = paymentService;
            _monthlySummaryService = monthlySummaryService;
        }

        public IEnumerable<Member> GetActiveMembers()
        {
            return Find(m => m.IsActive);
        }

        public decimal GetCurrentBalance(int memberId)
        {
            var member = GetById(memberId);
            if (member == null)
                throw new ArgumentException("Member not found", nameof(memberId));

            var currentMonth = DateTime.Now;
            var summary = _monthlySummaryService.GetSummaryByMember(memberId, currentMonth.Year, currentMonth.Month);
            return summary?.TotalDue ?? 0;
        }

        public IEnumerable<MonthlySummary> GetMonthlySummary(int memberId, int year, int month)
        {
            var member = GetById(memberId);
            if (member == null)
                throw new ArgumentException("Member not found", nameof(memberId));

            return _monthlySummaryService.GetSummariesByMonth(year, month)
                .Where(s => s.MemberId == memberId);
        }

        public DataTable GetMemberMealHistory(int memberId, DateTime startDate, DateTime endDate)
        {
            var meals = _mealService.GetMealsByMember(memberId, startDate, endDate);
            var dataTable = new DataTable();

            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Breakfast", typeof(int));
            dataTable.Columns.Add("Lunch", typeof(int));
            dataTable.Columns.Add("Dinner", typeof(int));
            dataTable.Columns.Add("Total", typeof(int));

            foreach (var meal in meals)
            {
                var row = dataTable.NewRow();
                row["Date"] = meal.Date;
                row["Breakfast"] = meal.Breakfast;
                row["Lunch"] = meal.Lunch;
                row["Dinner"] = meal.Dinner;
                row["Total"] = meal.Breakfast + meal.Lunch + meal.Dinner;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable GetMemberPaymentHistory(int memberId, DateTime startDate, DateTime endDate)
        {
            var payments = _paymentService.GetPaymentsByDateRange(startDate, endDate)
                .Where(p => p.MemberId == memberId);
            var dataTable = new DataTable();

            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Amount", typeof(decimal));
            dataTable.Columns.Add("TransactionId", typeof(string));
            dataTable.Columns.Add("Remarks", typeof(string));

            foreach (var payment in payments)
            {
                var row = dataTable.NewRow();
                row["Date"] = payment.Date;
                row["Amount"] = payment.Amount;
                row["TransactionId"] = payment.TransactionId;
                row["Remarks"] = payment.Remarks;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
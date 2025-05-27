using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IMemberService : IBaseService<Member>
    {
        IEnumerable<Member> GetActiveMembers();
        decimal GetCurrentBalance(int memberId);
        IEnumerable<MonthlySummary> GetMonthlySummary(int memberId, int year, int month);
        DataTable GetMemberMealHistory(int memberId, DateTime startDate, DateTime endDate);
        DataTable GetMemberPaymentHistory(int memberId, DateTime startDate, DateTime endDate);
    }
} 
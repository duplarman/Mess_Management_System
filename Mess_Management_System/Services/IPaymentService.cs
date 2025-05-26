using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface IPaymentService : IBaseService<Payment>
    {
        IEnumerable<Payment> GetPaymentsByMember(int memberId);
        IEnumerable<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate);
        decimal GetTotalPaymentsByMember(int memberId, int year, int month);
        DataTable GetPaymentSummary(int year, int month);
        decimal GetMemberBalance(int memberId);
    }
} 
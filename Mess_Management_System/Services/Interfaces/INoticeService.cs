using System;
using System.Collections.Generic;
using System.Data;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public interface INoticeService : IBaseService<Notice>
    {
        IEnumerable<Notice> GetActiveNotices();
        IEnumerable<Notice> GetNoticesByDateRange(DateTime startDate, DateTime endDate);
        void DeactivateNotice(int noticeId);
        void ExtendNoticeExpiry(int noticeId, DateTime newExpiryDate);
        DataTable GetNoticeBoard();
    }
} 
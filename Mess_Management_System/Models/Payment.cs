using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public virtual Member Member { get; set; }
    }

}
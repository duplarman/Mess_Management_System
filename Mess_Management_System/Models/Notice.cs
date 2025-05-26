using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedOn { get; set; }
    }

}
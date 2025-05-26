using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mess_Management_System.Models
{
    public class Market
    {
        public int MarketId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchasedBy { get; set; }
    }

}
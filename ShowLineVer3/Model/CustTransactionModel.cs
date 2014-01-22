using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class CustTransactionModel
    {
        public string TransactionID { get; set; }
        public string EventDetails { get; set; }
        public string Venue { get; set; }
        public string TicketType { get; set; }
        public string SeatInfo { get; set; }
        public string BookingDate { get; set; }
        public string TotalAmount { get; set; }
        public string EventDate { get; set; }
        public string Qty { get; set; }
    }
}
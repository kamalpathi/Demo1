using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class PayementDetailsModel
    {
        public string TicketType { get; set; }
        public string TicketPrice { get; set; }
        public string EventSPID { get; set; }
        public string AMT { get; set; }
        public string Qty { get; set; }
        public string TotAmt { get; set; }
    }
}
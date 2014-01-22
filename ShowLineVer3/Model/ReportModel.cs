using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class ReportModel
    {
        public string VenueName { get; set; }
        public string city { get; set; }
        public string EventTitle { get; set; }
        public string TicketType { get; set; }
        public string TicketPrice { get; set; }
        public string EventDate { get; set; }
        public string EventFromTime { get; set; }
        public string EventToTime { get; set; }
        public string StreetAddress { get; set; }        
        public string StateProvision { get; set; }
        public string ZipCode { get; set; }
        public string custfirstname { get; set; }
        public string TicketCheckoutDate { get; set; }
        public string BarCodeGen { get; set; }
        public string EventLayout { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class ConfirmationModel
    {
        public string TICKETTYPE { get; set; }
        public string TICKETPRICE { get; set; }
        public string Entry { get; set; }
        public string TransactionID { get; set; }
        public string CustFirstName { get; set; }
        public string VenueName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateProvision { get; set; }
        public string ZipCode { get; set; }
        public string Eventdate { get; set; }
        public string FROMTM { get; set; }
        public string TOTIME { get; set; }
        public string EventTitle { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class EventTransactionDetailsModel
    {
        public string EventTitle { get; set; }
        public string SeatNo { get; set; }
        public string TicketType { get; set; }
        public string TicketPrice { get; set; }
        public string CustFirstName { get; set; }
        public string USERID { get; set; }
        public string TicketStatus { get; set; }
        public string TransactionID { get; set; }
        public string BARCODEGEN { get; set; }
        public string TRANSACTIONDETAILS { get; set; }
        public string EXact_Message { get; set; }
        public string Bank_Resp_Code { get; set; }
        public string Bank_Message { get; set; }
        public string ISVALID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class TicketSeatModel
    {       
        public string EventSPID { get; set; }
       
        public string TicketType { get; set; }
       
        public int SeatesBooked { get; set; }
       
        public string CUSTID { get; set; }
      
        public string FullName { get; set; }      
        
    }
}
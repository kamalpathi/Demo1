using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class EventTicketDetailsModel
    {
        
        public string LocationName { get; set; }

        
        public string EventTitle { get; set; }

        
        public string EventDesc { get; set; }

        
        public string Artists { get; set; }

        
        public string Genre { get; set; }

        
        public string ImagePath { get; set; }

        
        public string EventDate { get; set; }

        
        public string EVENTFROMTIME { get; set; }

        
        public string EVENTTOTIME { get; set; }

        //[DataMember]
        //public EventTicketPriceDetailModel EventPrice { get; set; }

        
        public string EVENTPRICEDETAILS { get; set; }

        
        public string EVENTPRICE { get; set; }

        public string VenueImagePath { get; set; }

        public string VenueName { get; set; } 
        public string StreetAddress { get; set; } 
        public string City { get; set; } 
        public string StateProvision { get; set; }
        public string ZipCode { get; set; }
        public string SeatLeft { get; set; }
    }
}
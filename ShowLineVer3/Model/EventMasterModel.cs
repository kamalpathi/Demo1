using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class EventMasterModel
    {
        public string EventID { get; set; }
        public string EventTypeID { get; set; }
        public string EventSubtypeID { get; set; }
        public string VenueID { get; set; }
        public string LocationID { get; set; }
        public string StateID { get; set; }
        public string CountryID { get; set; }
        public string EventTitle { get; set; }
        public string EventDesc { get; set; }
        public string Artists { get; set; }
        public string Genre { get; set; }
        public string ImagePath { get; set; }
        public string EventDate { get; set; }
        public string CancelationDate { get; set; }
        public string TotalSeats { get; set; }
        public string BookedSeats { get; set; }
        public string EventLayout { get; set; }
        public string VenueName { get; set; }
        public string EventType { get; set; }
        public string EventSubTypeDesc { get; set; }
        public string SmallImagePath { get; set; }
        public bool FEATURESHOW { get; set; }
        public bool SPECIALIMAGE { get; set; }
    }

    public class EventTimeDetailsModel
    {
        public DateTime EventFromTime { get; set; }
        public DateTime EventToTime { get; set; }
        public int EventTimeID { get; set; }
    }

    public class EventPriceDetailsModel
    {
        public string EventPriceDetails { get; set; }
        public string EventPrice { get; set; }
        public int EventTotalSeat { get; set; }
        public string EventPriceID { get; set; }
        public int SrNo { get; set; }
    }
    
    public class EventTypeModel
    {
        public int EventTypeID { get; set; }
        public string  EventType { get; set; }
    }

    public class EventSubTypeModel
    {
        public int EventSubTypeID { get; set; }
        public string EventSubTypeDesc { get; set; }        
    }

    

}
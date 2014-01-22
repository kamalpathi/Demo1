using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class VenueDetailsModel
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateProvision { get; set; }
        public string ZipCode { get; set; }
        public string VenueImage { get; set; }
        public string TicketBackgroundImage { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowLineVer3.Model
{
    public class EventListingModel
    {
        public string EventID { get; set; }

        public string EventTitle { get; set; }

        public string EventDate { get; set; }

        public string EventDesc { get; set; }

        public string ImagePath { get; set; }

        public string VenueName
        {
            get;
            set;
        }

        public string SmallImagePath { get; set; }

        public string FeatureShow { get; set; }

        public string SpecialImage { get; set; }
    }
}
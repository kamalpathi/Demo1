using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;

namespace ShowLineVer3.ViewModel
{
    public class EventVenueViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        //SELECT EVENTTITLE,VenueName,StreetAddress,City,StateProvision,ZipCode FROM Event INNER JOIN Venue ON EVENT.VenueID = Venue.VenueID WHERE EventSPID='E03061304390215'

        public EventVenueModel GetEventVenueModelDetails(string EventID)
        {
            try
            {
                string sql = "SELECT EVENTTITLE,ImagePath,EventDate,EventFromTime,EventToTime, VenueName,StreetAddress,City,StateProvision,ZipCode FROM Event INNER JOIN Venue ON EVENT.VenueID = Venue.VenueID INNER JOIN EventTimeDetails ON EVENT.EventSPID = EventTimeDetails.EventSPID WHERE EVENT.EventSPID='" + EventID + "'";

                EventVenueModel _eventVenueModel = new EventVenueModel();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmdDel = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmdDel.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventVenueModel.EventName = dr["EVENTTITLE"].ToString();
                            _eventVenueModel.EventToTime = dr["EventToTime"].ToString();
                            _eventVenueModel.EventFromTime = dr["EventFromTime"].ToString();
                            _eventVenueModel.EventDate = dr["EventDate"].ToString();
                            _eventVenueModel.EventImage = dr["ImagePath"].ToString();
                            _eventVenueModel.VenueName = dr["VenueName"].ToString();
                            _eventVenueModel.StreetAddress = dr["StreetAddress"].ToString();
                            _eventVenueModel.City = dr["City"].ToString();
                            _eventVenueModel.StateProvision = dr["StateProvision"].ToString();
                            _eventVenueModel.ZipCode = dr["ZipCode"].ToString();
                        }
                    }
                }

                return _eventVenueModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
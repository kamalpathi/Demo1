using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;

namespace ShowLineVer3.ViewModel
{
    public class VenueDetailsViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<VenueDetailsModel> GetVenueDetails()
        {
            try
            {
                List<VenueDetailsModel> _venueDetailsModel = new List<VenueDetailsModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM  Venue", conn))
                    {
                        conn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _venueDetailsModel.Add(new VenueDetailsModel
                            {
                                VenueID = Convert.ToInt32(dr["VenueID"]),
                                VenueName = dr["VenueName"].ToString(),
                                StreetAddress = dr["StreetAddress"].ToString(),
                                City = dr["City"].ToString(),
                                StateProvision = dr["StateProvision"].ToString(),
                                ZipCode = dr["ZipCode"].ToString(),
                                VenueImage = dr["VenueImage"].ToString() == @"\ShowlineImages\." ? @"\ShowlineImages\NoImage.jpg" : dr["VenueImage"].ToString(),
                                TicketBackgroundImage = dr["TicketBackgroundImage"].ToString()
                            });
                        }
                    }
                }

                return _venueDetailsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveVenueDetails(VenueDetailsModel venueDetailsModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO  Venue(VenueName, StreetAddress, City, StateProvision, ZipCode, VenueImage) VALUES('" + venueDetailsModel.VenueName + "','" + venueDetailsModel.StreetAddress + "','" + venueDetailsModel.City + "','" + venueDetailsModel.StateProvision + "','" + venueDetailsModel.ZipCode + "','" + venueDetailsModel.VenueImage + "')" , conn))                    
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VenueDetailsModel GetVenueDetailsByID(string VenueID)
        {
            try
            {
                VenueDetailsModel _venueDetailsModel = new VenueDetailsModel();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM  Venue Where VenueID='" + VenueID + "'", conn))
                    {
                        conn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            _venueDetailsModel.VenueID = Convert.ToInt32(dr["VenueID"]);
                            _venueDetailsModel.VenueName = dr["VenueName"].ToString();
                            _venueDetailsModel.StreetAddress = dr["StreetAddress"].ToString();
                            _venueDetailsModel.City = dr["City"].ToString();
                            _venueDetailsModel.StateProvision = dr["StateProvision"].ToString();
                            _venueDetailsModel.ZipCode = dr["ZipCode"].ToString();
                            _venueDetailsModel.VenueImage = dr["VenueImage"].ToString();
                            _venueDetailsModel.TicketBackgroundImage = dr["TicketBackgroundImage"].ToString();
                        }
                    }
                }

                return _venueDetailsModel;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteVenueDetails(string VenueID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_DELETE_VENUEDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@VENUEID", SqlDbType.Int).Value = VenueID;

                        cmd.ExecuteNonQuery();
                        return "true";
                    }
                }
            }
            catch (SqlException sq)
            {
                ErrHandler.WriteError(sq.Message);                
                if (sq.Message.ToString().Contains("REFERENCE"))
                {
                    return "Ref";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
                return "false";
            }
        }

        public bool UpdateVenueDetails(VenueDetailsModel venueDetailsModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATE_VENUE", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = venueDetailsModel.VenueID;
                        cmd.Parameters.Add("@VenueName", SqlDbType.VarChar,50).Value = venueDetailsModel.VenueName;
                        cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar,200).Value = venueDetailsModel.StreetAddress;
                        cmd.Parameters.Add("@City", SqlDbType.VarChar,100).Value = venueDetailsModel.City;
                        cmd.Parameters.Add("@StateProvision", SqlDbType.VarChar,100).Value = venueDetailsModel.StateProvision;
                        cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar,20).Value = venueDetailsModel.ZipCode;
                        cmd.Parameters.Add("@VenueImage", SqlDbType.VarChar).Value = venueDetailsModel.VenueImage;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }

        public List<EventListModel> GetEventList(string VenueID,string EVENTDATE)
        {
            try
            {
                List<EventListModel> _eventListModel = new List<EventListModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SL_PRO_RPT_GETEVENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = Convert.ToInt32(VenueID);
                        cmd.Parameters.Add("@EventDate", SqlDbType.VarChar, 20).Value = EVENTDATE;
                        SqlDataReader da;

                        da = cmd.ExecuteReader();

                        while (da.Read())
                        {
                            _eventListModel.Add(new EventListModel { EventName = da["EventTitle"].ToString(), EventSPID = da["EventSPID"].ToString() });
                        }
                    }
                }

                return _eventListModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public List<EventListModel> GetEventByDate(string EventDate)
        {
            //cmd.CommandText = "SELECT name FROM server WHERE code = @code";
            //cmd.Parameters.AddWithValue("@code", TextBox1.Text);

            try
            {
                List<EventListModel> _eventListModel = new List<EventListModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT EventSPID,EventTitle FROM Event WHERE EVENTDATE = @EvtDate UNION SELECT EventSPID,EventTitle FROM TicketSeatDetails_2012_2013 WHERE EVENTDATE = @EvtDate", conn))
                    {
                        cmd.Parameters.AddWithValue("@EvtDate", EventDate);
                        
                        SqlDataReader da;

                        da = cmd.ExecuteReader();

                        while (da.Read())
                        {
                            _eventListModel.Add(new EventListModel { EventName = da["EventTitle"].ToString(), EventSPID = da["EventSPID"].ToString() });
                        }
                    }
                }

                return _eventListModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }   

        }
    }

    public class EventListModel
    {
        public string EventName { get; set; }
        public string EventSPID { get; set; }
    }
}
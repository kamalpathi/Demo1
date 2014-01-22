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
    public class EventListingPageViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<EventListingModel> GetEventDetails(int CountryID, int StateID,string EventName)
        {
            List<EventListingModel> _eventListingModel = new List<EventListingModel>();
            try
            {
                using (DataTable dt = new DataTable("EventDetails"))
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        using (SqlCommand cmd = new SqlCommand("PROC_EVENTLIST", conn))
                        {
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@COUNTRYID", SqlDbType.Int).Value = CountryID;
                            cmd.Parameters.Add("@STATEID", SqlDbType.Int).Value = StateID;
                            cmd.Parameters.Add("@SEARCHBY", SqlDbType.VarChar, 50).Value = EventName;


                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    _eventListingModel.Add(new EventListingModel
                                    {
                                        EventID = dr["EventSPID"].ToString(),
                                        EventDate = dr["EventDate"].ToString(),
                                        EventDesc = dr["EventDesc"].ToString().Trim(),
                                        EventTitle = dr["EventTitle"].ToString().Trim(),
                                        ImagePath = dr["ImagePath"].ToString(),
                                        VenueName = dr["VenueName"].ToString(),
                                        FeatureShow = dr["FEATURESHOW"].ToString(),
                                        SmallImagePath = dr["SMALLIMAGEPATH"].ToString(),
                                        SpecialImage = dr["SPECIALIMAGE"].ToString()
                                         
                                        //RowNo = i++,
                                        //EventID = Convert.ToInt32(dr["EventID"]),
                                        //EventTypeID = Convert.ToInt32(dr["EventTypeID"]),
                                        //EventType = dr["EventType"].ToString(),
                                        //EventSubTypeID = Convert.ToInt32(dr["EventSubtypeID"]),
                                        //EventSubTypeDesc = dr["EventSubTypeDesc"].ToString(),
                                        //VenueID = Convert.ToInt32(dr["VenueID"]),
                                        //VenueName = dr["VenueName"].ToString(),
                                        //LocationID = Convert.ToInt32(dr["LocationID"]),
                                        //LocationName = dr["LocationName"].ToString(),
                                        //StateID = Convert.ToInt32(dr["StateID"]),
                                        //StateName = dr["StateName"].ToString(),
                                        //CountryID = Convert.ToInt32(dr["CountryID"]),
                                        //CountryName = dr["CountryName"].ToString(),
                                        //EventDesc = dr["EventDesc"].ToString(),
                                        //ImagePath = dr["ImagePath"].ToString(),
                                        //EventDate = Convert.ToDateTime(dr["EventDate"]),
                                        //CancelationDate = dr["CancelationDate"].ToString(),
                                        //EventTitle = dr["EventTitle"].ToString()
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);               
            }

            return _eventListingModel;


        }

        public List<EventListingModel> GetEventDetailswithPage(int CountryID, int StateID)
        {
            List<EventListingModel> _eventListingModel = new List<EventListingModel>();


            try
            {
                using (DataTable dt = new DataTable("EventDetails"))
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        using (SqlCommand cmd = new SqlCommand("PROC_EVENTLISTWITHPAGE", conn))
                        {
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@COUNTRYID", SqlDbType.Int).Value = CountryID;
                            cmd.Parameters.Add("@STATEID", SqlDbType.Int).Value = StateID;
                            //cmd.Parameters.Add("@pg", SqlDbType.Int).Value = Convert.ToInt16(txtHidden.Value);
                            cmd.Parameters.Add("@pgSize", SqlDbType.Int).Value = 5;

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    _eventListingModel.Add(new EventListingModel
                                    {
                                        EventID = dr["EventSPID"].ToString(),
                                        EventDate = dr["EventDate"].ToString(),
                                        EventDesc = dr["EventDesc"].ToString().Trim(),
                                        EventTitle = dr["EventTitle"].ToString().Trim(),
                                        ImagePath = dr["ImagePath"].ToString(),
                                        VenueName = dr["VenueName"].ToString()
                                        //RowNo = i++,
                                        //EventID = Convert.ToInt32(dr["EventID"]),
                                        //EventTypeID = Convert.ToInt32(dr["EventTypeID"]),
                                        //EventType = dr["EventType"].ToString(),
                                        //EventSubTypeID = Convert.ToInt32(dr["EventSubtypeID"]),
                                        //EventSubTypeDesc = dr["EventSubTypeDesc"].ToString(),
                                        //VenueID = Convert.ToInt32(dr["VenueID"]),
                                        //VenueName = dr["VenueName"].ToString(),
                                        //LocationID = Convert.ToInt32(dr["LocationID"]),
                                        //LocationName = dr["LocationName"].ToString(),
                                        //StateID = Convert.ToInt32(dr["StateID"]),
                                        //StateName = dr["StateName"].ToString(),
                                        //CountryID = Convert.ToInt32(dr["CountryID"]),
                                        //CountryName = dr["CountryName"].ToString(),
                                        //EventDesc = dr["EventDesc"].ToString(),
                                        //ImagePath = dr["ImagePath"].ToString(),
                                        //EventDate = Convert.ToDateTime(dr["EventDate"]),
                                        //CancelationDate = dr["CancelationDate"].ToString(),
                                        //EventTitle = dr["EventTitle"].ToString()
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }

            return _eventListingModel;


        }
    }
}
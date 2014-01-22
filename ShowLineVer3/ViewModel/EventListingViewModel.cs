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
    public class EventListingViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<EventListingModel> GetEventListing()
        {
            List<EventListingModel> _eventListingModel = new List<EventListingModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_EVENTLIST", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@COUNTRYID", SqlDbType.Int).Value = 58;
                        cmd.Parameters.Add("@STATEID", SqlDbType.Int).Value = 5;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventListingModel.Add(new EventListingModel
                            {
                                EventID = dr["EventSPID"].ToString(),
                                EventDate = Convert.ToDateTime(dr["EventDate"]).ToString("dd/MMM/yyyy HH:mm"),
                                EventDesc = dr["EventDesc"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                FeatureShow = dr["FeatureShow"].ToString(),
                                SmallImagePath = dr["SmallImagePath"].ToString(),
                                SpecialImage = dr["SpecialImage"].ToString()
                            });
                        }
                    }
                }

                return _eventListingModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

        public string BannerImage()
        {
            try
            {

                string Imgpath = "";

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT BannerImage FROM bannerImage", conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Imgpath = dr["BannerImage"].ToString();
                        }
                    }
                }

                return Imgpath;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return "";
            }
        }
    }
}
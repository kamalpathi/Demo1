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
    public class GetEventDetailsViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<EventMasterModel> GetEventDetailsProc(int VenueID,int PageSize, int PageNumber,string searchBy)
        {
            List<EventMasterModel> _proc_GetEventDetails_Model = new List<EventMasterModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("PROC_GETEVENTDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = VenueID;
                        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = PageSize;
                        cmd.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                        cmd.Parameters.Add("@filter", SqlDbType.VarChar, 20).Value = searchBy;     


                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _proc_GetEventDetails_Model.Add(new EventMasterModel
                            {
                                EventID = dr["EventSPID"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                VenueID = dr["VenueID"].ToString(),
                                VenueName = dr["VenueName"].ToString(),                                
                                ImagePath = "http://showsline.com/mywebsite" +  dr["ImagePath"].ToString(),
                                EventDate = dr["EvtDate"].ToString(),
                                FEATURESHOW = Convert.ToBoolean(dr["FEATURESHOW"]),
                                SPECIALIMAGE = Convert.ToBoolean(dr["SPECIALIMAGE"])
                            });
                        }
                    }
                }

                return _proc_GetEventDetails_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CountEventDetails(int VenueID, string SearchBy)
        {
            int retVal = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    string sqlQuery;

                    sqlQuery = "";

                    if (SearchBy == "")
                    {
                        if (VenueID == 0)
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT WHERE EVENTDATE >=  DATEADD(D,-1,GETDATE())";
                        }
                        else
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT Where VenueID = '" + VenueID + "' AND EVENTDATE >=  DATEADD(D,-1,GETDATE())";
                        }
                    }
                    else
                    {
                        if (VenueID == 0)
                        {
                            sqlQuery = "SELECT *  FROM  Event WHERE EventTitle LIKE '%'" + SearchBy + "%' AND EVENTDATE >= DATEADD(D,-1,GETDATE())";
                        }
                        else
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT Where VenueID = '" + VenueID + "' AND EventTitle LIKE '%'" + SearchBy + "%' AND EVENTDATE >= DATEADD(D,-1,GETDATE())";
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();
                        retVal = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public bool EventsSetting(string EventID, bool SpecialImage, bool FeatureImage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE EVENT SET FEATURESHOW = '" + FeatureImage + "' , SPECIALIMAGE = '" + SpecialImage + "' WHERE EventSPID = '" + EventID + "'", conn))
                    {
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

        public List<EventMasterModel> GetHistoryEventDetailsProc(int VenueID, int PageSize, int PageNumber, string searchBy)
        {
            List<EventMasterModel> _proc_GetEventDetails_Model = new List<EventMasterModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("PROC_GETHISTORYEVENTDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = VenueID;
                        cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = PageSize;
                        cmd.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                        cmd.Parameters.Add("@filter", SqlDbType.VarChar, 20).Value = searchBy;


                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _proc_GetEventDetails_Model.Add(new EventMasterModel
                            {
                                EventID = dr["EventSPID"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                VenueID = dr["VenueID"].ToString(),
                                VenueName = dr["VenueName"].ToString(),
                                ImagePath = "http://showsline.com/mywebsite" + dr["ImagePath"].ToString(),
                                EventDate = dr["EvtDate"].ToString(),
                                FEATURESHOW = Convert.ToBoolean(dr["FEATURESHOW"]),
                                SPECIALIMAGE = Convert.ToBoolean(dr["SPECIALIMAGE"])
                            });
                        }
                    }
                }

                return _proc_GetEventDetails_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CountHistoryEventDetails(int VenueID, string SearchBy)
        {
            int retVal = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    string sqlQuery;

                    sqlQuery = "";

                    if (SearchBy == "")
                    {
                        if (VenueID == 0)
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT WHERE EVENTDATE < DATEADD(D,-1,GETDATE())";
                        }
                        else
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT Where VenueID = '" + VenueID + "' AND EVENTDATE <  DATEADD(D,-1,GETDATE())";
                        }
                    }
                    else
                    {
                        if (VenueID == 0)
                        {
                            sqlQuery = "SELECT *  FROM  Event WHERE EventTitle LIKE '%'" + SearchBy + "%' AND EVENTDATE <  DATEADD(D,-1,GETDATE())";
                        }
                        else
                        {
                            sqlQuery = "SELECT COUNT(*) FROM EVENT Where VenueID = '" + VenueID + "' AND EventTitle LIKE '%'" + SearchBy + "%' AND EVENTDATE <  DATEADD(D,-1,GETDATE())";
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();
                        retVal = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
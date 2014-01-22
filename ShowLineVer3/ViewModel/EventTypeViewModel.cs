using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;
using System.Data;

namespace ShowLineVer3.ViewModel
{
    public class EventTypeViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();


        public List<EventTypeModel> GetEventType()
        {
            try
            {
                List<EventTypeModel> _eventTypeModel = new List<EventTypeModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_GetEventTypeList", conn))
                    {
                        conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventTypeModel.Add(new EventTypeModel { EventTypeID = Convert.ToInt32(dr["EventTypeID"]), EventType = dr["EventType"].ToString() });
                        }
                    }
                }

                return _eventTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<EventSubTypeModel> GetEventSubType(int EventTypeID)
        {
            try
            {
                List<EventSubTypeModel> _eventSubTypeModel = new List<EventSubTypeModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_GetEventSubTypeList", conn))
                    {
                        conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EventType", SqlDbType.Int).Value = EventTypeID;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventSubTypeModel.Add(new EventSubTypeModel { EventSubTypeID = Convert.ToInt32(dr["EventSubTypeID"]), EventSubTypeDesc = dr["EventSubTypeDesc"].ToString() });
                        }
                    }
                }

                return _eventSubTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
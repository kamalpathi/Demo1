using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;
using BarcodeLib;
using System.Web.UI.WebControls;


namespace ShowLineVer3.ViewModel
{
    public class EventsEntryPageViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public bool InsertEventMaster(EventMasterModel eventMasterModel, List<EventTimeDetailsModel> eventTimeDetailsModel, List<EventPriceDetailsModel> eventPriceDetailsModel)
        {
            try
            {
                string EVENTID = "";

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {                            
                            using (SqlCommand cmd = new SqlCommand("proc_INSERT_EVENT", conn, trans))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add("@EventTypeID", SqlDbType.Int).Value = eventMasterModel.EventTypeID;
                                cmd.Parameters.Add("@EventSubtypeID", SqlDbType.Int).Value = eventMasterModel.EventSubtypeID;
                                cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = eventMasterModel.VenueID;
                                cmd.Parameters.Add("@EventTitle", SqlDbType.VarChar, 200).Value = eventMasterModel.EventTitle;
                                cmd.Parameters.Add("@EventDesc", SqlDbType.VarChar).Value = eventMasterModel.EventDesc;
                                cmd.Parameters.Add("@Artists", SqlDbType.VarChar, 500).Value = eventMasterModel.Artists;
                                cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 500).Value = eventMasterModel.Genre;
                                cmd.Parameters.Add("@EventImg", SqlDbType.VarChar).Value = eventMasterModel.ImagePath;
                                cmd.Parameters.Add("@EventID", SqlDbType.VarChar, 22).Value = eventMasterModel.EventID;
                                cmd.Parameters.Add("@EventDate", SqlDbType.VarChar, 22).Value = eventMasterModel.EventDate;
                                cmd.Parameters.Add("@EvenLayOut", SqlDbType.VarChar).Value = eventMasterModel.EventLayout;
                                cmd.Parameters.Add("@SmallImage", SqlDbType.VarChar).Value = eventMasterModel.SmallImagePath;

                                cmd.ExecuteNonQuery();

                                EVENTID = eventMasterModel.EventID;
                            }



                            for (int i = 0; i < eventTimeDetailsModel.Count; i++)
                            {
                                using (SqlCommand cmd = new SqlCommand("proc_INSERT_EventTime", conn, trans))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@EventFromTime", SqlDbType.VarChar, 35).Value = eventTimeDetailsModel[i].EventFromTime.ToString();
                                    cmd.Parameters.Add("@EventToTime", SqlDbType.VarChar, 35).Value = eventTimeDetailsModel[i].EventToTime.ToString();
                                    cmd.Parameters.Add("@EventSPID", SqlDbType.VarChar, 22).Value = eventMasterModel.EventID;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            for (int j = 0; j < eventPriceDetailsModel.Count; j++)
                            {
                                using (SqlCommand cmd = new SqlCommand("proc_insert_eventprice", conn, trans))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@eventpricedetails", SqlDbType.VarChar, 100).Value = eventPriceDetailsModel[j].EventPriceDetails.ToString();
                                    cmd.Parameters.Add("@eventprice", SqlDbType.VarChar, 6).Value = eventPriceDetailsModel[j].EventPrice.ToString();
                                    cmd.Parameters.Add("@eventtotalseat", SqlDbType.Int).Value = eventPriceDetailsModel[j].EventTotalSeat.ToString();
                                    cmd.Parameters.Add("@eventspid", SqlDbType.VarChar, 22).Value = eventMasterModel.EventID;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();

                            GenerateBarCode(EVENTID);
                        }
                        catch (Exception ex)
                        {
                            ErrHandler.WriteError(ex.Message);
                            trans.Rollback();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex1)
            {
                ErrHandler.WriteError(ex1.Message);
                return false;
            }
        }

        public void GenerateBarCode(string EventSPID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT BARCODEGEN FROM TicketSeatDetails WHERE EventSPID ='" + EventSPID + "'", conn))
                    {
                        conn.Open();
                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            GenrateBarcode_Image(dr["BARCODEGEN"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
            }

        }

        public void GenerateBarCode(string EventSPID, string TicketType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT BARCODEGEN FROM TicketSeatDetails WHERE EventSPID ='" + EventSPID + "' AND TicketType ='" + TicketType + "'", conn))
                    {
                        conn.Open();
                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            GenrateBarcode_Image(dr["BARCODEGEN"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }

        }

        protected bool GenrateBarcode_Image(string Barcode_Value)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            try
            {
                b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                Image img = new Image();
                System.Drawing.Image imm = b.Encode(type, Barcode_Value.ToUpper(), System.Drawing.Color.Black, System.Drawing.Color.White, 250, 60);
                imm.Save(HttpContext.Current.Server.MapPath("~/Barcode/") + Barcode_Value + ".png", System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);        
                return false;
            }
        }
       
        public EventMasterModel GetEventDetails(string EventID)
        {
            try
            {
                EventMasterModel eventMasterModel = new EventMasterModel();
 
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_EVENTMASTER", conn))
                    {

                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EventSPID", SqlDbType.VarChar, 22).Value = EventID;
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            eventMasterModel.EventTypeID = dr["EventTypeID"].ToString();
                            eventMasterModel.EventType = dr["EventType"].ToString();
                            eventMasterModel.EventSubtypeID = dr["EventSubtypeID"].ToString();
                            eventMasterModel.EventSubTypeDesc = dr["EventSubTypeDesc"].ToString();
                            eventMasterModel.VenueID = dr["VenueID"].ToString();
                            eventMasterModel.VenueName = dr["VenueName"].ToString();
                            eventMasterModel.EventTitle = dr["EventTitle"].ToString();
                            eventMasterModel.EventDesc = dr["EventDesc"].ToString();
                            eventMasterModel.Artists = dr["Artists"].ToString();
                            eventMasterModel.Genre = dr["Genre"].ToString();
                            eventMasterModel.ImagePath = dr["ImagePath"].ToString();
                            eventMasterModel.EventID = dr["EventSPID"].ToString();
                            eventMasterModel.EventDate = dr["EventDate"].ToString();
                            eventMasterModel.EventLayout = dr["EventLayout"].ToString();
                            eventMasterModel.SmallImagePath = dr["SmallImagePath"].ToString();
                        }
                    }
                }

                return eventMasterModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
                return null;
            }
        }

        public EventTimeDetailsModel GetEventTimeDetails(string EventID)
        {
            try
            {
                EventTimeDetailsModel _eventTimeDetailsModel = new EventTimeDetailsModel();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_EVENTTIMEDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EventSPID", SqlDbType.VarChar, 22).Value = EventID;
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventTimeDetailsModel.EventFromTime = Convert.ToDateTime(dr["EventFromTime"]);
                            _eventTimeDetailsModel.EventToTime = Convert.ToDateTime(dr["EventToTime"]);
                            _eventTimeDetailsModel.EventTimeID = Convert.ToInt32(dr["EventTimeID"]); 
                        }
                    }
                }

                return _eventTimeDetailsModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
                return null;
            }
        }

        public List<EventPriceDetailsModel> GetEventPriceDetails(string EventID)
        {
            try
            {
                List<EventPriceDetailsModel> _eventPriceDetailsModel = new List<EventPriceDetailsModel>();
                int srNos = 1;
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_EVENTPRICEDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EventSPID", SqlDbType.VarChar, 22).Value = EventID;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventPriceDetailsModel.Add(new EventPriceDetailsModel
                            {
                                EventPriceID = dr["EventPriceID"].ToString(),
                                EventPriceDetails = dr["EventPriceDetails"].ToString(),
                                EventPrice = Convert.ToInt32(dr["EventPrice"]).ToString(),
                                EventTotalSeat = Convert.ToInt32(dr["EventTotalSeat"]),
                                SrNo = srNos
                            });
                            srNos++;
                        }
                    }
                }

                return _eventPriceDetailsModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);           
                return null;
            }
        }

        public bool DeleteEventDetails(string EventSPID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_DELETE_EVENTLIST", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EVENTSPID", SqlDbType.VarChar, 22).Value = EventSPID;

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);           
                return false;
            }
        }

        public bool DeleteEventDetails(string EventSPID,string DeleteAll)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_DELETE_EVENTLIST", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EVENTSPID", SqlDbType.VarChar, 22).Value = EventSPID;
                        cmd.Parameters.Add("@DELETEALL", SqlDbType.VarChar, 1).Value = DeleteAll;

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
                return false;
            }
        }

        public bool UpdateEventMaster(EventMasterModel eventMasterModel, List<EventTimeDetailsModel> eventTimeDetailsModel)
        {
            try
            {
                string EVENTID = "";

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATE_EVENT_NEW", conn, trans))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add("@EventTypeID", SqlDbType.Int).Value = eventMasterModel.EventTypeID;
                                cmd.Parameters.Add("@EventSubtypeID", SqlDbType.Int).Value = eventMasterModel.EventSubtypeID;
                                cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = eventMasterModel.VenueID;
                                cmd.Parameters.Add("@EventTitle", SqlDbType.VarChar, 200).Value = eventMasterModel.EventTitle;
                                cmd.Parameters.Add("@EventDesc", SqlDbType.VarChar).Value = eventMasterModel.EventDesc;
                                cmd.Parameters.Add("@Artists", SqlDbType.VarChar, 500).Value = eventMasterModel.Artists;
                                cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 500).Value = eventMasterModel.Genre;
                                cmd.Parameters.Add("@EventImg", SqlDbType.VarChar).Value = eventMasterModel.ImagePath;
                                cmd.Parameters.Add("@EventID", SqlDbType.VarChar, 22).Value = eventMasterModel.EventID;
                                cmd.Parameters.Add("@EventDate", SqlDbType.VarChar, 22).Value = eventMasterModel.EventDate;
                                cmd.Parameters.Add("@EvenLayOut", SqlDbType.VarChar).Value = eventMasterModel.EventLayout;
                                cmd.Parameters.Add("@SmallImage", SqlDbType.VarChar).Value = eventMasterModel.SmallImagePath;

                                cmd.ExecuteNonQuery();

                                EVENTID = eventMasterModel.EventID;
                            }



                            for (int i = 0; i < eventTimeDetailsModel.Count; i++)
                            {
                                using (SqlCommand cmd = new SqlCommand("proc_UPDATE_EventTime", conn, trans))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@EventFromTime", SqlDbType.VarChar, 35).Value = eventTimeDetailsModel[i].EventFromTime.ToString();
                                    cmd.Parameters.Add("@EventToTime", SqlDbType.VarChar, 35).Value = eventTimeDetailsModel[i].EventToTime.ToString();
                                    cmd.Parameters.Add("@EventSPID", SqlDbType.VarChar, 22).Value = eventMasterModel.EventID;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            ErrHandler.WriteError(ex.Message);
                            trans.Rollback();
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex1)
            {
                ErrHandler.WriteError(ex1.Message);
                return false;
            }
        }
    }
}
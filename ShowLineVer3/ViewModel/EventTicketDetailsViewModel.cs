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
    public class EventTicketDetailsViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<EventTicketDetailsModel> GetEventTicketDetailsList(string EvtID)
        {
            List<EventTicketDetailsModel> _eventTicketDetailsModel = new List<EventTicketDetailsModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("PROC_GETEVENT_TICKET_DETAILS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EVENTID", SqlDbType.VarChar, 22).Value = EvtID;
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _eventTicketDetailsModel.Add(new EventTicketDetailsModel
                            {
                                LocationName = dr["LocationName"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                EventDesc = dr["EventDesc"].ToString(),
                                Artists = dr["Artists"].ToString(),
                                Genre = dr["Genre"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                EventDate = dr["EventDate"].ToString(),
                                EVENTFROMTIME = dr["EVENTFROMTIME"].ToString(),
                                EVENTTOTIME = dr["EVENTTOTIME"].ToString(),
                                EVENTPRICEDETAILS = dr["EVENTPRICEDETAILS"].ToString(),
                                EVENTPRICE = Convert.ToInt32(dr["EVENTPRICE"]).ToString(),
                                VenueImagePath = dr["VenueImage"].ToString(),
                                VenueName = dr["VenueName"].ToString(),
                                StreetAddress = dr["StreetAddress"].ToString(),
                                City = dr["City"].ToString(),
                                StateProvision = dr["StateProvision"].ToString(),
                                ZipCode = dr["ZipCode"].ToString(),
                                SeatLeft = dr["SEATLEFT"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
            return _eventTicketDetailsModel;
        }

        public bool UpdateTicketStatus(string TransID,string EventID,string ResCode,string Msg,string BankResponse,string BankMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATETICKETSTATUS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TRANSID", SqlDbType.VarChar, 22).Value = TransID;
                        cmd.Parameters.Add("@EVENTSPID", SqlDbType.VarChar, 22).Value = EventID;
                        cmd.Parameters.Add("@TRANSACTIONDTL", SqlDbType.VarChar, 22).Value = ResCode;
                        cmd.Parameters.Add("@EXTMSG", SqlDbType.VarChar).Value = Msg;
                        cmd.Parameters.Add("@BNKRESCODE", SqlDbType.VarChar).Value = BankResponse;
                        cmd.Parameters.Add("@BNKMSG", SqlDbType.VarChar).Value = BankMessage;

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
    }
}
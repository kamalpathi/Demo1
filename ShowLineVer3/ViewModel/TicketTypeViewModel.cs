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
    public class TicketTypeViewModel : IDisposable
    {
        private bool disposed = false;
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();
        
        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                ConnString = null;
                //clsWE.Dispose();
            }

            // Note disposing has been done.
            disposed = true;
        }

        ~TicketTypeViewModel()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }

        #endregion

        public bool DeleteTicket(int TicketID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ADMIN_DELETE_TICKET_DETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EVENTPRICEID", SqlDbType.Int).Value = TicketID;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        public bool UpdateTicketType(string TicketName, string TicketPrice, int TicketID,int TotalSeats)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ADMIN_TICKET_DETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TICKETNAME", SqlDbType.VarChar, 50).Value = TicketName;
                        cmd.Parameters.Add("@TICKETPRICE", SqlDbType.Float).Value = Convert.ToSingle(TicketPrice);
                        cmd.Parameters.Add("@EVENTPRICEID", SqlDbType.Int).Value = TicketID;
                        cmd.Parameters.Add("@TOTALSEATS", SqlDbType.Int).Value = TotalSeats;
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        public bool AddTickets(string TicketName, string TicketPrice, string TicketSPID, int TotalSeats)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_insert_eventprice", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@eventpricedetails", SqlDbType.VarChar, 100).Value = TicketName;
                        cmd.Parameters.Add("@eventprice", SqlDbType.VarChar, 6).Value = TicketPrice;
                        cmd.Parameters.Add("@eventtotalseat", SqlDbType.Int).Value = TotalSeats;
                        cmd.Parameters.Add("@eventspid", SqlDbType.VarChar, 22).Value = TicketSPID;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        public bool CheckTicketName(string TicketName, string TicketSPID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT EventPriceDetails FROM EventPriceDetails WHERE EventSPID=@ESPID AND EventPriceDetails = @TT ", conn))
                    {
                        cmd.Parameters.AddWithValue("@ESPID", TicketSPID);
                        cmd.Parameters.AddWithValue("@TT", TicketName);

                        string ttName = Convert.ToString(cmd.ExecuteScalar());

                        if (ttName.ToString().ToUpper() == TicketName.ToUpper())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }
                }                
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                throw;
            }

            
        }
        
        public void TicketDetails(string EventSPID,out string ticketFromTime, out string  ticketToTime,out string EventName)
        {
            try
            {
                ticketFromTime = "";
                ticketToTime = "";
                EventName = "";

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select EventTitle, EventfromTime,EventToTime  from Event  INNER JOIN EventTimeDetails ON EVENT.EventSPID = EventTimeDetails.EventSPID WHERE EVENT.EventSPID=@ESPID  ", conn))
                    {
                        cmd.Parameters.AddWithValue("@ESPID", EventSPID);

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ticketToTime = dr["EventToTime"].ToString();
                            ticketFromTime = dr["EventfromTime"].ToString();
                            EventName = dr["EventTitle"].ToString();                             
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                throw;
            }

        }

    }
}
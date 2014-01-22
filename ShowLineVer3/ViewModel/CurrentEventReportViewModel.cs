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
    public class CurrentEventReportViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<CurrentEventReport> GetAdminDetails()
        {
            List<CurrentEventReport> _currentEventReport = new List<CurrentEventReport>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_CURRENT_SALES", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _currentEventReport.Add(new CurrentEventReport
                            {
                                TicketPrice = dr["TicketPrice"].ToString(),
                                TicketSold = dr["TicketSold"].ToString(),
                                BOOKINGTYPE = dr["BOOKINGTYPE"].ToString(),
                                EventDate = Convert.ToDateTime(dr["EventDate"].ToString()).ToString("dd/MMM/yyyy"),
                                EventSPID = dr["EventSPID"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                TicketType = dr["TicketType"].ToString(),
                                TransactionDetails = dr["TransactionDetails"].ToString()
                            });                           
                        }
                    }
                }

                return _currentEventReport;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

        public List<CurrentEventReport> GetAllEventReport(string FromDate,string Todate, string Event)
        {
            List<CurrentEventReport> _currentEventReport = new List<CurrentEventReport>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_ALL_SALES_REPORT", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar, 20).Value = FromDate;
                        cmd.Parameters.Add("@TODATE", SqlDbType.VarChar, 20).Value = Todate;
                        cmd.Parameters.Add("@EVENT", SqlDbType.VarChar, 200).Value = Event;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _currentEventReport.Add(new CurrentEventReport
                            {
                                TicketPrice =  string.Format("{0:0.00}", dr["TicketPrice"]),
                                TicketSold = dr["TicketSold"].ToString(),
                                BOOKINGTYPE = dr["BOOKINGTYPE"].ToString(),
                                EventDate = Convert.ToDateTime(dr["EventDate"].ToString()).ToString("dd/MMM/yyyy"),
                                EventSPID = dr["EventSPID"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                TicketType = dr["TicketType"].ToString(),
                                TransactionDetails = "" ,
                                TPrice = string.Format("{0:0.00}", dr["TPrice"]),
                            });
                        }
                    }
                }

                return _currentEventReport;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

        public List<CurrentEventReport> GetAllEventReportVenuWise(string Event,int VenueID)
        {
            List<CurrentEventReport> _currentEventReport = new List<CurrentEventReport>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_ALL_SALES_REPORT_VENUWISE", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        cmd.Parameters.Add("@EVENT", SqlDbType.VarChar, 200).Value = Event;
                        cmd.Parameters.Add("@VENUID", SqlDbType.Int).Value = VenueID;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _currentEventReport.Add(new CurrentEventReport
                            {
                                TicketPrice = dr["TicketPrice"].ToString(),
                                TicketSold = dr["TicketSold"].ToString(),
                                BOOKINGTYPE = dr["BOOKINGTYPE"].ToString(),
                                EventDate = Convert.ToDateTime(dr["EventDate"].ToString()).ToString("dd/MMM/yyyy"),
                                EventSPID = dr["EventSPID"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                TicketType = dr["TicketType"].ToString(),
                                TransactionDetails = ""
                            });
                        }
                    }
                }

                return _currentEventReport;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

    }
}
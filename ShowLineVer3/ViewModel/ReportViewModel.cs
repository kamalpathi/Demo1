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
    public class ReportViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<ReportModel> ReportList(string TransactionID,string TicketType)
        {
            try
            {
                List<ReportModel> _reportModel = new List<ReportModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_CUST_REPORT", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 22).Value = TransactionID;
                        cmd.Parameters.Add("@TICKETTYPE", SqlDbType.VarChar, 100).Value = TicketType;

                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _reportModel.Add(new ReportModel
                            {
                                VenueName = dr["VenueName"].ToString(),
                                city = dr["city"].ToString(),
                                EventTitle = dr["EventTitle"].ToString(),
                                TicketType = dr["TicketType"].ToString(),
                                TicketPrice = dr["TicketPrice"].ToString(),
                                EventDate = dr["EventDate"].ToString(),
                                EventFromTime = dr["EventFromTime"].ToString(),
                                EventToTime = dr["EventToTime"].ToString(),
                                StreetAddress = dr["StreetAddress"].ToString(),
                                StateProvision = dr["StateProvision"].ToString(),
                                ZipCode = dr["ZipCode"].ToString(),
                                custfirstname = dr["custfirstname"].ToString(),
                                TicketCheckoutDate = dr["TicketCheckoutDate"].ToString(),
                                BarCodeGen = dr["Barcodegen"].ToString(),
                                EventLayout = dr["EventLayout"].ToString().Substring(1,dr["EventLayout"].ToString().Length - 1 )
                            });                            
                        }
                    }
                }
                return _reportModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
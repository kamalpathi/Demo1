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
    public class CustTransactionViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public bool InsertCustTransaction(List<CustTransactionModel> custTransactionModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    for (int i = 0; i < custTransactionModel.Count; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand("SL_PROC_CUST_TRANSACTION_DETAILS", conn))
                        {
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = custTransactionModel[i].TransactionID.ToString();
                            cmd.Parameters.Add("@EventDetails", SqlDbType.VarChar, 50).Value = custTransactionModel[i].EventDetails;
                            cmd.Parameters.Add("@Venue", SqlDbType.VarChar, 100).Value = custTransactionModel[i].Venue;
                            cmd.Parameters.Add("@TicketType", SqlDbType.VarChar, 20).Value = custTransactionModel[i].TicketType;
                            cmd.Parameters.Add("@SeatInfo", SqlDbType.VarChar, 50).Value = custTransactionModel[i].SeatInfo;
                            cmd.Parameters.Add("@BookingDate", SqlDbType.Int).Value = custTransactionModel[i].BookingDate;
                            cmd.Parameters.Add("@TotalAmount", SqlDbType.VarChar, 100).Value = custTransactionModel[i].TotalAmount;

                            cmd.ExecuteNonQuery();
                        }
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
    }
}
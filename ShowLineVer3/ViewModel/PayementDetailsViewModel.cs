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
    public class PayementDetailsViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<PayementDetailsModel> PaymentTicketDetails(string TranID)
        {
            try
            {
                List<PayementDetailsModel> _payementDetailsModel = new List<PayementDetailsModel>();
 
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_GET_PAYMENT_TICKETDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 22).Value = TranID;

                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _payementDetailsModel.Add(new PayementDetailsModel
                            {
                                EventSPID = dr["EVENTSPID"].ToString(),
                                TicketType = dr["TICKETTYPE"].ToString(),
                                TicketPrice = Convert.ToInt32(dr["TICKETPRICE"]).ToString(),
                                Qty = Convert.ToInt32(dr["QTY"]).ToString(),
                                AMT = Convert.ToInt32(dr["AMT"]).ToString(),
                                TotAmt = dr["totamt"].ToString()
                            });
                        }

                        return _payementDetailsModel;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
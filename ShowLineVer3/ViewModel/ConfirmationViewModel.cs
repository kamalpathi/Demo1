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
    public class ConfirmationViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<ConfirmationModel> GetTicketConfirmationDetails(string TID)
        {
            try
            {
                List<ConfirmationModel> _confirmationModel = new List<ConfirmationModel>();
 
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_TicketConfirmation", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50).Value = TID;

                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _confirmationModel.Add(new ConfirmationModel
                            {
                                TICKETTYPE = dr["TICKETTYPE"].ToString(),
                                TICKETPRICE = dr["TICKETPRICE"].ToString(),
                                Entry = dr["entry"].ToString(),
                                TransactionID = dr["TransactionID"].ToString(),
                                CustFirstName = dr["CustFirstName"].ToString(),
                                VenueName = dr["VenueName"].ToString(),
                                StreetAddress = dr["StreetAddress"].ToString(),
                                City = dr["City"].ToString(),
                                StateProvision = dr["StateProvision"].ToString(),
                                ZipCode = dr["ZipCode"].ToString(),
                                Eventdate = dr["eventdate"].ToString(),
                                FROMTM = dr["FROMTM"].ToString(),
                                TOTIME = dr["TOTIME"].ToString(),
                                EventTitle = dr["EventTitle"].ToString()
                            });
                        }
                        return _confirmationModel;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

    }
}
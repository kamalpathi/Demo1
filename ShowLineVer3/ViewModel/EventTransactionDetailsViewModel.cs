using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;

namespace ShowLineVer3.ViewModel
{
    public class EventTransactionDetailsViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public List<EventTransactionDetailsModel> GetEventTransactionDetails(string EventID)
        {
            try
            {
                List<EventTransactionDetailsModel> _eventListModel = new List<EventTransactionDetailsModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    string QUERY = "SELECT  EventTitle,SeatNo,TicketType,TicketPrice,CustFirstName,USERID,TicketStatus,TransactionID,BARCODEGEN,TRANSACTIONDETAILS,EXact_Message,Bank_Resp_Code,Bank_Message,ISVALID FROM TicketSeatDetails INNER JOIN EVENT ON TicketSeatDetails.EventSPID = EVENT.EventSPID WHERE TicketStatus = 'CN' AND TicketSeatDetails.EventSPID =@EvtID AND TRANSACTIONDETAILS NOT LIKE 'CASH' " +
                                   " UNION "  +
                                   " SELECT  EventTitle,SeatNo,TicketType,TicketPrice,CustFirstName,USERID,TicketStatus,TransactionID,BARCODEGEN,TRANSACTIONDETAILS,EXact_Message,Bank_Resp_Code,Bank_Message,'' AS ISVALID  FROM TicketSeatDetails_2012_2013 WHERE TicketStatus = 'CN' AND EventSPID =@EvtID AND TRANSACTIONDETAILS NOT LIKE 'CASH'";

                    using (SqlCommand cmd = new SqlCommand(QUERY, conn))
                    {
                        cmd.Parameters.AddWithValue("@EvtID", EventID);

                        SqlDataReader da;

                        da = cmd.ExecuteReader();

                        while (da.Read())
                        {
                            _eventListModel.Add(new EventTransactionDetailsModel
                            {
                                Bank_Message = da["Bank_Message"].ToString(),
                                Bank_Resp_Code = da["Bank_Resp_Code"].ToString(),
                                BARCODEGEN = da["BARCODEGEN"].ToString(),
                                CustFirstName = da["CustFirstName"].ToString(),
                                EventTitle = da["EventTitle"].ToString(),
                                EXact_Message = da["EXact_Message"].ToString(),
                                ISVALID = da["ISVALID"].ToString(),
                                SeatNo = da["SeatNo"].ToString(),
                                TicketPrice = da["TicketPrice"].ToString(),
                                TicketStatus = da["TicketStatus"].ToString(),
                                TicketType = da["TicketType"].ToString(),
                                TRANSACTIONDETAILS = da["TRANSACTIONDETAILS"].ToString(),
                                TransactionID = da["TransactionID"].ToString(),
                                USERID = da["USERID"].ToString()
                            }
                            );
                        }
                    }
                }

                return _eventListModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
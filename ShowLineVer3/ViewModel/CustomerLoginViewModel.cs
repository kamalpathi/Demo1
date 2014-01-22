using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ShowLineVer3.Model;

namespace ShowLineVer3.ViewModel
{
    public class CustomerLoginViewModel : IDisposable
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();
        private bool disposed;

        public bool CustomerLogin(string UserName, string Password,out string userName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_proc_CustomerLogin", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 200);
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@isAuthenticate", SqlDbType.Bit);
                        cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar,50);

                        cmd.Parameters["@UserName"].Value = UserName;
                        cmd.Parameters["@Password"].Value = Password;
                        cmd.Parameters["@isAuthenticate"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@FIRSTNAME"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool IsAuthentication = Convert.ToBoolean(cmd.Parameters["@isAuthenticate"].Value);
                        userName = cmd.Parameters["@FIRSTNAME"].Value.ToString();
                        
                        return IsAuthentication;
                    }
                }
            }
            catch (Exception ex)
            {
                userName = "";
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }
        
        public string CustomerRegistration(string UserName, string Password,string MobileNo,string FirstName, string LastName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmdAuth = new SqlCommand("SELECT Count(*) FROM Customer where UserID= @USERNM", conn))
                    {                        
                        
                        cmdAuth.Parameters.AddWithValue("@USERNM", UserName);

                        object retval = cmdAuth.ExecuteScalar();

                        if (Convert.ToInt32(retval) >= 1)
                        {
                            return "Email ID already exits.";
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("SL_proc_CustomerRegistrator", conn))
                            {
                                //conn.Open();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 200).Value = UserName;
                                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
                                cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 20).Value = MobileNo;
                                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 200).Value = FirstName;
                                cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar, 200).Value = LastName;

                                cmd.ExecuteNonQuery();

                                return "User Added sucessfully.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return "Ooops something went wrong. Please try again.";
            }
        }
        
        public string CustomerChangePassword(string userid, string password, string oldpassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmdAuth = new SqlCommand("SELECT password FROM Customer where UserID= '" + userid + "'", conn))
                    {
                        object retval = cmdAuth.ExecuteScalar();

                        if (Convert.ToString(retval) != oldpassword)
                        {
                            return "Password mismatch.";
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("Update Customer SET Password = '" + password + "' WHERE UserID= '" + userid + "'", conn))
                            {
                                cmd.ExecuteNonQuery();                                

                                return "User Added sucessfully.";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return "Ooops something went wrong. Please try again.";
            }
        }

        public List<CustomerModel> GetCustomerDetails(string userid)
        {
            try
            {
                List<CustomerModel> custModel = new List<CustomerModel>();
 
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmdAuth = new SqlCommand("SELECT FirstName, LastName, Address1, Address2, City, State, Zip, Phone FROM Customer WHERE userID= '" + userid + "'", conn))
                    {
                        SqlDataReader dr;
                        dr = cmdAuth.ExecuteReader();

                        while (dr.Read())
                        {
                            custModel.Add(new CustomerModel
                            {
                                firstname = dr["FirstName"].ToString(),
                                lastname = dr["LastName"].ToString(),
                                address1 = dr["Address1"].ToString(),
                                address2 = dr["Address2"].ToString(),
                                city = dr["City"].ToString(),
                                state = dr["State"].ToString(),
                                mobileno = dr["Phone"].ToString(),
                                zip = dr["Zip"].ToString()
                            });
                        }                        
                    }

                }

                return custModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }


        public bool UpdateCustomerDetails(CustomerModel customerModel, string emailid)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATE_CUSTOMER_DETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = customerModel.firstname;
                        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = customerModel.lastname;
                        cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 200).Value = customerModel.address1;
                        cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 200).Value = customerModel.address2;
                        cmd.Parameters.Add("@City", SqlDbType.VarChar, 200).Value = customerModel.city;
                        cmd.Parameters.Add("@State", SqlDbType.VarChar, 200).Value = customerModel.state;
                        cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 50).Value = customerModel.zip;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = customerModel.mobileno;
                        cmd.Parameters.Add("@USERID", SqlDbType.VarChar, 200).Value = emailid;

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

        public List<CustTransactionModel> GetCustTransactionDetails(string UID)
        {
            try
            {
                List<CustTransactionModel> custTransModel = new List<CustTransactionModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    string qry ="SELECT transactionID,EventTitle,CONVERT(VARCHAR,EventDate,106) AS EventDate , " ;
                    qry = qry + " VENUENAME,TicketType,CONVERT(VARCHAR,TicketCheckoutDate,106) AS BookingDate,TicketPrice, SUM(TicketPrice) as AMT , Count(*) as Qty    ";
                    qry = qry + " FROM TicketSeatDetails " ;
                    qry = qry + " INNER JOIN Event ON Event.EventSPID = TicketSeatDetails.EventSPID  " ;
                    qry = qry + " INNER JOIN VENUE ON Event.VenueID = VENUE.VenueID" ;
//                    qry = qry + " where USERID= '"+ UID + "'" ;
                    qry = qry + " where USERID= @UID AND TicketStatus='CN'";//+kk
                    qry = qry + " GROUP BY transactionID,EventTitle,CONVERT(VARCHAR,EventDate,106),VENUENAME,TicketType, CONVERT(VARCHAR,TicketCheckoutDate,106),TicketPrice,TicketPrice  ORDER BY BookingDate ";



                    using (SqlCommand cmdAuth = new SqlCommand(qry, conn))
                    {
                        cmdAuth.Parameters.AddWithValue("@UID", UID);//+kk

                        SqlDataReader dr;
                        dr = cmdAuth.ExecuteReader();

                        while (dr.Read())
                        {
                            custTransModel.Add(new CustTransactionModel
                            {
                                TransactionID = dr["transactionID"].ToString(),
                                EventDetails = dr["EventTitle"].ToString(),
                                EventDate = dr["EventDate"].ToString(),
                                Venue = dr["VENUENAME"].ToString(),
                                TicketType = dr["TicketType"].ToString(),
                                BookingDate = dr["BookingDate"].ToString(),
                                SeatInfo = dr["TicketPrice"].ToString(),
                                TotalAmount = dr["amt"].ToString(),
                                 Qty = dr["Qty"].ToString()
                            });                            
                        }
                    }
                }

                return custTransModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

        public string UpdateForgotPassword(string userName, string pwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    using (SqlCommand cmdAuth = new SqlCommand("SELECT Count(*) FROM Customer where UserID= '" + userName + "'", conn))
                    {
                        object retval = cmdAuth.ExecuteScalar();

                        if (Convert.ToInt32(retval) == 0)
                        {
                            return "Email ID does not exits.";
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATEPWD", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@UID", SqlDbType.VarChar, 200).Value = userName;
                                cmd.Parameters.Add("@PWD", SqlDbType.VarChar, 50).Value = pwd;

                                cmd.ExecuteNonQuery();

                                return "User Added sucessfully.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return "Ooops something went wrong. Please try again.";
            }
        }

        public List<CustomerModel> GetAllCustomerDetails(int VenueID, int PageSize, int PageNumber, string searchBy)
        {
            try
            {
                List<CustomerModel> custModel = new List<CustomerModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    using (SqlCommand cmdAuth = new SqlCommand("PROC_GETCUSTOMERDETAILS", conn))
                    {
                        cmdAuth.CommandType = CommandType.StoredProcedure;
                        cmdAuth.Parameters.Add("@VenueID", SqlDbType.Int).Value = VenueID;
                        cmdAuth.Parameters.Add("@pageSize", SqlDbType.Int).Value = PageSize;
                        cmdAuth.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                        cmdAuth.Parameters.Add("@filter", SqlDbType.VarChar, 20).Value = searchBy;   

                        SqlDataReader dr;
                        dr = cmdAuth.ExecuteReader();

                        while (dr.Read())
                        {
                            custModel.Add(new CustomerModel
                            {
                                firstname = dr["FirstName"].ToString(),
                                lastname = dr["LastName"].ToString(),
                                address1 = dr["Address1"].ToString(),
                                address2 = dr["Address2"].ToString(),
                                city = dr["City"].ToString(),
                                state = dr["State"].ToString(),
                                mobileno = dr["Phone"].ToString(),
                                zip = dr["Zip"].ToString(),
                                UserID = dr["UserID"].ToString(),
                                RowNumber = dr["RowNumber"].ToString()
                            });
                        }
                    }
                }

                return custModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                throw ex;
            }
        }


        public int CountCustomerDetails(string SearchBy)
        {
            int retVal = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    string sqlQuery;

                    sqlQuery = "";

                    if (SearchBy == "")
                    {
                        sqlQuery = "SELECT COUNT(*) FROM Customer";
                        
                    }
                    else
                    {
                        sqlQuery = "SELECT COUNT(*) FROM Customer Where FirstName Like '%" + SearchBy + "%' OR LastName  LIKE '%" + SearchBy + "%'  OR Address1  LIKE '%" + SearchBy + "%' OR Address2  LIKE '%" + SearchBy + "%' OR City  LIKE '%" + SearchBy + "%' OR State  LIKE '%" + SearchBy + "%' OR Zip  LIKE '%" + SearchBy + "%' OR Phone LIKE '%" + SearchBy + "%' OR UserID LIKE '%" + SearchBy + "%'";
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();
                        retVal = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #region IDisposable Members
               

        ~CustomerLoginViewModel()
        {
               this.Dispose();
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
                this.disposed = true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ConnString = null;                
            }

            // clean up unmanaged resources
        }
        #endregion


    }
}
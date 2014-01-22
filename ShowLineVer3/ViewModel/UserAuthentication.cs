using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ShowLineVer3.ViewModel
{
    public class UserAuthentication
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public bool AdminLogin(string UserName, string Password,out string VenueID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_proc_AdminLogin", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 200);
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@isAuthenticate", SqlDbType.Bit);
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int);


                        cmd.Parameters["@UserName"].Value = UserName;
                        cmd.Parameters["@Password"].Value = Password;
                        cmd.Parameters["@isAuthenticate"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@VenueID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool IsAuthentication = Convert.ToBoolean(cmd.Parameters["@isAuthenticate"].Value);
                        VenueID = cmd.Parameters["@VenueID"].Value.ToString();

                        return IsAuthentication;
                    }
                }
            }
            catch (Exception ex)
            {
                VenueID = "-1";
                throw ex;	
            }
        }

        public bool UpdateUserPassword(string UserId, string Password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATEPASSWORD", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USERID", SqlDbType.VarChar, 200);
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);


                        cmd.Parameters["@USERID"].Value = UserId;
                        cmd.Parameters["@Password"].Value = Password;
                        

                        cmd.ExecuteNonQuery();                     

                        return true;
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
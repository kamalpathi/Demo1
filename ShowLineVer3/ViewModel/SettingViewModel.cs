using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShowLineVer3.ViewModel
{
    public class SettingViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public bool UpdateAdminDetails(string userName,string oldpwd,string Newpwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATEADMINPWD", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@OLDPWD", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@NEWPWD", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@isAuthenticate", SqlDbType.Int);
                        
                        cmd.Parameters["@USERNAME"].Value = userName;
                        cmd.Parameters["@OLDPWD"].Value = oldpwd;
                        cmd.Parameters["@NEWPWD"].Value = Newpwd;

                        cmd.Parameters["@isAuthenticate"].Direction = ParameterDirection.Output;
                        //cmd.Parameters["@VenueID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        bool IsAuthentication = Convert.ToBoolean(cmd.Parameters["@isAuthenticate"].Value);
                        

                        return IsAuthentication;
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
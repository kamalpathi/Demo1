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
    public class AdminViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        //insert 
        public string InsertAdminDetails(AdminModel adminModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    //cmd.CommandText = "SELECT name FROM server WHERE code = @code";
                    //cmd.Parameters.AddWithValue("@code", TextBox1.Text);

                    using (SqlCommand cmdAuth = new SqlCommand("SELECT Count(*) FROM AdminUser where AdminEmailID= @USERID", conn))
                    {
                        cmdAuth.Parameters.AddWithValue("@USERID",adminModel.AdminEmailID);
                        object retval = cmdAuth.ExecuteScalar();

                        if (Convert.ToInt32(retval) >= 1)
                        {
                            return "Email ID already exits.";
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("SL_PROC_INSERTADMINDETAILS", conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@AdminUserID", SqlDbType.Int).Value = adminModel.AdminUserID;
                                cmd.Parameters.Add("@AdminUserName", SqlDbType.VarChar, 50).Value = adminModel.AdminUserName;
                                cmd.Parameters.Add("@AdminFullName", SqlDbType.VarChar, 100).Value = adminModel.AdminFullName;
                                cmd.Parameters.Add("@AdminMobNo", SqlDbType.VarChar, 20).Value = adminModel.AdminMobNo;
                                cmd.Parameters.Add("@AdminUserPassword", SqlDbType.VarChar, 50).Value = adminModel.AdminUserPassword;
                                cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = adminModel.VenueID;
                                cmd.Parameters.Add("@AdminEmailID", SqlDbType.VarChar, 100).Value = adminModel.AdminEmailID;
                                cmd.Parameters.Add("@UserType", SqlDbType.VarChar, 10).Value = adminModel.UserType;

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
                throw ex;
            }
        }

        ////update
        public bool UpdateAdminDetails(AdminModel adminModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_UPDATEADMINDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AdminUserID", SqlDbType.Int).Value = adminModel.AdminUserID;
                        cmd.Parameters.Add("@AdminUserName", SqlDbType.VarChar, 50).Value = adminModel.AdminUserName;
                        cmd.Parameters.Add("@AdminFullName", SqlDbType.VarChar, 100).Value = adminModel.AdminFullName;
                        cmd.Parameters.Add("@AdminMobNo", SqlDbType.VarChar, 20).Value = adminModel.AdminMobNo;                        
                        cmd.Parameters.Add("@VenueID", SqlDbType.Int).Value = adminModel.VenueID;
                        cmd.Parameters.Add("@AdminEmailID", SqlDbType.VarChar, 100).Value = adminModel.AdminEmailID;
                        cmd.Parameters.Add("@UserType", SqlDbType.VarChar, 10).Value = adminModel.UserType;

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

        ////delete
        public string DeleteAdminDetails(int AdminID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_DELETEADMINDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ADMINID", SqlDbType.Int).Value = AdminID;

                        cmd.ExecuteNonQuery();
                        return "true";
                    }
                }
            }
            catch (SqlException sq)
            {
                ErrHandler.WriteError(sq.Message);
                throw sq;
                //if (sq.Message.ToString().Contains("REFERENCE"))
                //{
                //    return "Ref";
                //}
                //else
                //{
                //    return "false";
                //}
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);                
                throw ex;
            }
        }
               

        public List<AdminModel> GetAdminDetails(string  SearchBy,int VenueID)
        {
            List<AdminModel> _adminModel = new List<AdminModel>();
 
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_GETADMINDETAILS", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SEARCHCBY", SqlDbType.VarChar, 50).Value = SearchBy;
                        cmd.Parameters.Add("@VENUEID", SqlDbType.Int).Value = VenueID;

                        SqlDataReader dr =cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _adminModel.Add(new AdminModel
                            {
                                AdminUserID = Convert.ToInt32(dr["AdminUserID"]),
                                AdminUserName = dr["AdminUserName"].ToString(),                                
                                AdminFullName = dr["AdminFullName"].ToString(),
                                AdminMobNo = dr["AdminMobNo"].ToString(),
                                VenueID = dr["VenueID"].ToString(),
                                AdminEmailID = dr["AdminEmailID"].ToString(),
                                VenueName = dr["VenueName"].ToString(),
                                UserType = dr["UserType"].ToString()
                            });
                        }                        
                    }
                }

                return _adminModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }

        public AdminModel GetAdminDetails(int AdminID)
        {
            AdminModel _adminModel = new AdminModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_GETADMINDETAILS_BYID", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ADMINID", SqlDbType.Int).Value = AdminID;                       

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                               _adminModel.AdminUserID = Convert.ToInt32(dr["AdminUserID"]);
                               _adminModel.AdminUserName = dr["AdminUserName"].ToString();
                               _adminModel.AdminFullName = dr["AdminFullName"].ToString();
                               _adminModel.AdminMobNo = dr["AdminMobNo"].ToString();
                               _adminModel.VenueID = dr["VenueID"].ToString();
                               _adminModel.AdminEmailID = dr["AdminEmailID"].ToString();
                               _adminModel.UserType = dr["UserType"].ToString();
                              // _adminModel.VenueName = dr["VenueName"].ToString();
                            
                        }
                    }
                }

                return _adminModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }
    }
}
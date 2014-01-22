using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShowLineVer3.Model;

namespace ShowLineVer3.ViewModel
{
    public class BannerImageViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();

        public bool SaveBannerImage(string bannerPath,string BannerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmdDel = new SqlCommand("TRUNCATE TABLE BannerImage", conn))
                    {
                        conn.Open();
                        cmdDel.ExecuteNonQuery();

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO BannerImage(BannerID,BannerImage) VALUES('" + BannerID + "','" + bannerPath + "')", conn))
                        {
                            
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        public BannerImageModel GetBannerImage()
        {
            try
            {
                BannerImageModel _bannerImageModel = new BannerImageModel();
 
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM  BannerImage", conn))
                    {
                        conn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _bannerImageModel.BannerID = dr["BannerID"].ToString();
                            _bannerImageModel.BannerImagePath = dr["BannerImage"].ToString();                             
                        }
                    }
                }

                return _bannerImageModel;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return null;
            }
        }
    }
}
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
    public class GalleryViewModel
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MainConnectionDB"].ToString();


        public List<GalleryModel> GetGalleryImage()
        {
            try
            {
                List<GalleryModel> _galleryModel=  new List<GalleryModel>();

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM  GalleryImage", conn))
                    {
                        conn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            _galleryModel.Add(new GalleryModel
                            {
                                GalleryID = dr["GalleryID"].ToString(),
                                GalleryImagePath = dr["GalleryImagePath"].ToString(),
                                Description = dr["Description"].ToString()
                            });                            
                        }
                    }
                }

                return _galleryModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool SaveGalleryImage(GalleryModel _galleryModel)
        {
            try
            {               

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO GalleryImage VALUES('" + _galleryModel.GalleryID + "','" + _galleryModel.GalleryImagePath + "','" + _galleryModel.Description + "')", conn))
                    {
                        conn.Open();

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

        public bool DeleteGalleryImage(string ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SL_PROC_DELETE_GALLERY_IMAGE", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@GALLERYID", SqlDbType.VarChar, 22).Value = ID;

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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminPanel
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["SVenue"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='SessionExpire.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Error : " + ex.Message + "')");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDataList();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Error : " + ex.Message + "')");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);
            }

        }

        protected void BindDataList()
        {
            try
            {
                GalleryViewModel _galleryViewModel = new GalleryViewModel();
                List<GalleryModel> _galleryModel = new List<GalleryModel>();

                _galleryModel = _galleryViewModel.GetGalleryImage();
                hdval.Value = _galleryModel.Count.ToString();

                dlImages.DataSource = _galleryModel;
                dlImages.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string GalleryID;
                bool retVal = true;

                if (filenm.Value != "")
                {

                    string ID = SaveImage(out GalleryID);

                    GalleryViewModel _galleryViewModel = new GalleryViewModel();
                    GalleryModel _galleryModel = new GalleryModel();

                    _galleryModel.GalleryID = GalleryID;
                    _galleryModel.GalleryImagePath = ID;
                    _galleryModel.Description = "";

                    retVal = _galleryViewModel.SaveGalleryImage(_galleryModel);

                    BindDataList();

                    if (retVal == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!.','Event Gallery');</script>", false);
                    }
                    else if (retVal == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>EnabelBtn();</script>", false);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>ConfirmMsg('Gallery Image Saved Sucessfully.','Event Gallery');</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>ConfirmMsg('Select Image for gallery.','Event Gallery');</script>", false);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Error : " + ex.Message + "')");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);
            }           
        }

        protected string SaveImage(out string GalleryID)
        {
            try
            {
                string s = filenm.Value;
                string[] file;
                string ext = "";
                string d;
                var r = new Random();


                file = s.Split('.');
                d = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                ext = "G" + d;

                string t = file[file.Length - 1].ToString();

                string baseImageLocation = Server.MapPath(@"\BannerImages\");
                HttpFileCollection files = Request.Files;
                HttpPostedFile httpPostedFile = files["filenm"];
                string fileExt = Path.GetExtension(httpPostedFile.FileName).ToLower();
                string fileName = Path.GetFileName(httpPostedFile.FileName);

                //FileInfo myfileinf = new FileInfo(hdBanner.Value);
                //myfileinf.Delete();

                if (fileName != "")
                {
                    //if (fileExt == ".jpg" || fileExt == ".gif")
                    //httpPostedFile.SaveAs(baseImageLocation + fileName);
                    httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                }

                GalleryID = ext;
                return @"\BannerImages\" + ext + "." + file[file.Length - 1].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                bool retVal = true;

                if (e.CommandName == "delete")
                {
                    GalleryViewModel _galleryViewModel = new GalleryViewModel();

                    string info = e.CommandArgument.ToString();

                    string[] arg = new string[2];

                    char[] splitter = { ';' };

                    arg = info.Split(splitter);

                    retVal = _galleryViewModel.DeleteGalleryImage(arg[0]);


                    string baseImageLocation = Server.MapPath(@"\BannerImages\");

                    string[] sp = arg[1].Split('\\');
                    string d = sp[sp.Length - 1];
                    string ext = baseImageLocation + d;
                    string renfile = baseImageLocation + "Del" + d;
                    File.Move(ext, renfile);

                    BindDataList();

                    if (retVal == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!.','Event Gallery');</script>", false);
                    }
                    else if (retVal == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Gallery", "<script type='text/javascript'>ConfirmMsg('Gallery Image Deleted Sucessfully.','Event Gallery');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Error : " + ex.Message + "')");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);
            }            
        }

    }
}
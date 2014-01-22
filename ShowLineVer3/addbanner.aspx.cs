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
    public partial class addbanner : System.Web.UI.Page
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
                    GetBannerDetails();
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
        
        private void GetBannerDetails()
        {
            try
            {
                BannerImageViewModel _bannerImageViewModel = new BannerImageViewModel();
                BannerImageModel _bannerImageModel = new BannerImageModel();

                _bannerImageModel = _bannerImageViewModel.GetBannerImage();
                img_prev.Src = _bannerImageModel.BannerImagePath;
                hdBanner.Value = _bannerImageModel.BannerID;
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

        protected void savebannerimage_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string s = filenm.Value;
                string[] file = s.Split('.');
                string t = file[file.Length - 1].ToString();
                string ext = "";              

                var r = new Random();
                string d = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                ext = "B" + d;


                string baseImageLocation = Server.MapPath("~\\BannerImages\\");
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

                BannerImageViewModel _bannerImageViewModel = new BannerImageViewModel();
                bool retval = _bannerImageViewModel.SaveBannerImage("~\\BannerImages\\" + ext + "." + file[file.Length - 1].ToString(), ext);

                if (retval == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Banner", "<script type='text/javascript'>ConfirmMsg('Banner Saved Sucessfully.','Add Banner');</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Banner", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Banner');</script>", false);
                }

                GetBannerDetails();
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
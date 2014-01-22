using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3
{
    public partial class settings : System.Web.UI.Page
    {
        string uname = "";

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
                if (Session["UNM"] != null)
                {
                    uname = Session["UNM"].ToString();
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

        protected void cmdPwd_ServerClick(object sender, EventArgs e)
        {
            try
            {
                SettingViewModel _settingViewModel = new SettingViewModel();
                bool retval = _settingViewModel.UpdateAdminDetails(uname, txtoldpwd.Value.Trim(), txtNewpwd.Value.Trim());

                if (retval == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Admin Settings", "<script type='text/javascript'>ConfirmMsg('Password Saved Sucessfuly.','Admin Settings');</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Admin Settings", "<script type='text/javascript'>ConfirmMsg('Authentication Failed.','Admin Settings');</script>", false);
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
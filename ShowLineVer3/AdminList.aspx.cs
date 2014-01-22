using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminPanel
{
    public partial class AdminList : System.Web.UI.Page
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
                    GetAdminList("");
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

        private void GetAdminList(string SearchBy)
        {
            try
            {
                AdminViewModel _adminViewModel = new AdminViewModel();
                List<AdminModel> _adminModel = new List<AdminModel>();

                _adminModel = _adminViewModel.GetAdminDetails(SearchBy, 0);
                gvAdminList.DataSource = _adminModel;
                gvAdminList.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvAdminList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    Response.Redirect("/CreateAdminUser.aspx?AD=" + e.CommandArgument + "");
                }

                if (e.CommandName == "delete")
                {
                    AdminViewModel _adminViewModel = new AdminViewModel();
                    string Retval =  _adminViewModel.DeleteAdminDetails(Convert.ToInt32(e.CommandArgument));

                    if (Retval == "true")
                    {
                        GetAdminList("");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('User deleted sucessfully');", true);
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

        protected void AddUser_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("/CreateAdminUser.aspx");//-kk redirect
                            Response.Redirect("/CreateAdminUser.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

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
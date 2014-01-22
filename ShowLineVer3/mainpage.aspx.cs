using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;

namespace ShowLineVer3.AdminPanel
{
    public partial class mainpage : System.Web.UI.Page
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
               //$("li:has('a'):contains('Master')").remove();
               //     $("li:has('a'):contains('Reports')").remove();
               //     $("li:has('a'):contains('Controls')").remove();

            try
            {
                if (Session["SVenue"] != null)
                {
                    string VID = Session["SVenue"].ToString();
                    //string jquery = "";

                    //if (VID != "0")
                    //{                    
                    //    jquery = "$('li:has('a'):contains('VenueDetails')').remove();";
                    //    ClientScript.RegisterStartupScript(typeof(Page), "a key","<script type=\"text/javascript\">"+ jquery +"</script>");

                    //    jquery = "$('li:has('a'):contains('BookingDetails')').remove();";
                    //    ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");

                    //    jquery = "$('li:has('a'):contains('UserCreation')').remove();";
                    //    ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");

                    //    jquery = "$('li:has('a'):contains('AddBanner')').remove();";
                    //    ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");

                    //    jquery = "$('li:has('a'):contains('Gallery')').remove();";
                    //    ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");
                    //}

                    UserAccessModel();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private void UserAccessModel()
        {
            try
            {
                //Session["UserType"]
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AdminPanel", "javascript:UserAccess('" + Session["SVenue"].ToString() + "');", true);
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }
    }
}
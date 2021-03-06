﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminPanel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                UserAuthentication _userAuthentication = new UserAuthentication();
                string VenueID;
                bool retval = _userAuthentication.AdminLogin(UserNm.Value, tpassword.Value, out VenueID);
                if (retval == true)
                {
                    Session["SVenue"] = VenueID;
                    Session["UNM"] = UserNm.Value;
//                    Response.Redirect("~/mainpage.aspx");
                            Response.Redirect("~/mainpage.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "User Authentication", "<script type='text/javascript'>ConfirmMsg('Invalid Username or password.','User Authentication');</script>", false);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }
    }
}
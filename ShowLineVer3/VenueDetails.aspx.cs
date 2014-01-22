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
    public partial class VenueDetails : System.Web.UI.Page
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
                    GetVenueDetails();
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

        private void GetVenueDetails()
        {
            try
            {
                List<VenueDetailsModel> _venueDetailsModel = new List<VenueDetailsModel>();
                VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                _venueDetailsModel = _venueDetailsViewModel.GetVenueDetails();

                //gvVenueDetails.DataSource = _venueDetailsModel;
                //gvVenueDetails.DataBind();

                gvVenueDetailsList.DataSource = _venueDetailsModel;
                gvVenueDetailsList.DataBind();
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

        protected void AddVenue_ServerClick(object sender, EventArgs e)
        {
            try
            {
//                Response.Redirect("/addvenue.aspx"); //kk redirect
                            Response.Redirect("/addvenue.aspx", false);
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

        //protected void gvVenueDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    try
        //    {
        //        string selectedVenueCode = "";
        //        bool isRedirect = true;
        //        try
        //        {
        //            selectedVenueCode = gvVenueDetails.Rows[e.NewSelectedIndex].Cells[2].Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            //Common.WriteLog("Method " + ex.TargetSite, ex.Message);
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "selection", "alert('Error Occured while selecting Venue Details');", true);
        //            isRedirect = false;
        //        }
        //        if (isRedirect)
        //            Response.Redirect("~/AdminPanel/addvenue.aspx?Ecode=" + selectedVenueCode + "&" + "Query=U");

        //    }
        //    catch (Exception ex)
        //    {
        //       // we.WriteExceptionInFile("DriverMaster-gvDriverDetails_SelectedIndexChanging :" + ex.ToString(), CompanyCode);
        //    }
        //}

        protected void gvVenueDetailsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    Response.Redirect("/addvenue.aspx?Ecode=" + e.CommandArgument + "");
                }

                if (e.CommandName == "delete")
                {
                    VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                    string retVal = _venueDetailsViewModel.DeleteVenueDetails(e.CommandArgument.ToString());

                    if (retVal == "Ref")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Event having a reference with Venue. Cannot be deleted.','Add Event Details');</script>", false);
                    }
                    else if (retVal == "false")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!.','Add Event Details');</script>", false);
                    }
                    else if (retVal == "true")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Venue Deleted Sucessfully.','Add Event Details');</script>", false);
                    }

                    GetVenueDetails();
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
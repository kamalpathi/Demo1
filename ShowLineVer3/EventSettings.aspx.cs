﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3
{
    public partial class EventSettings : System.Web.UI.Page
    {
        int VenueID = 0;
        int pagesize = 10;

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
                if (Session["SVenue"] != null)
                {
                    VenueID = Convert.ToInt32(Session["SVenue"]);

                    if (!IsPostBack)
                    {
                        CountEventList(VenueID, "");
                        GetEventList(VenueID, pagesize, 0, "");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='SessionExpire.aspx'", true);
                    //Response.Redirect("http://showsline.com/admin.aspx");//-kk redirect
                            //Response.Redirect("http://showsline.com/admin.aspx", false);
                            //Context.ApplicationInstance.CompleteRequest();

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

        private void GetEventList(int VenueID, int PageSize, int PageNumber, string searchBy)
        {
            try
            {
                GetEventDetailsViewModel _getEventDetailsViewModel = new GetEventDetailsViewModel();
                List<EventMasterModel> _eventMasterModel = new List<EventMasterModel>();

                //ToDo Get Venue ID of Admin LogedIn
                _eventMasterModel = _getEventDetailsViewModel.GetEventDetailsProc(VenueID, PageSize, PageNumber, searchBy);
                gvEvenSettings.DataSource = _eventMasterModel;
                SetCloumn(true);
                gvEvenSettings.DataBind();
                SetCloumn(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void drdpPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetEventList(VenueID, pagesize, drdpPage.SelectedIndex, txtSearchBy.Text.Trim());
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

        protected void searchEvent_ServerClick(object sender, EventArgs e)
        {
            try
            {
                CountEventList(VenueID, txtSearchBy.Text.Trim());
                GetEventList(VenueID, pagesize, 0, txtSearchBy.Text.Trim());
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

        protected void CountEventList(int VenueID, string searchBy)
        {
            try
            {
                GetEventDetailsViewModel _getEventDetailsViewModel = new GetEventDetailsViewModel();
                int EventListCount = _getEventDetailsViewModel.CountEventDetails(VenueID, searchBy);
                BindDataToDropDown(EventListCount);
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

        private void BindDataToDropDown(Single Count)
        {
            try
            {
                if (drdpPage.Items.Count > 0)
                {
                    for (int i = drdpPage.Items.Count - 1; i >= 0; i--)
                        drdpPage.Items.RemoveAt(0);
                    drdpPage.Items.Capacity = 0;
                }
                ListItem lstItem = null;
                int pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Convert.ToSingle(Count) / pagesize)));
                if (pages < 2)
                {
                    lstItem = new ListItem();
                    lstItem.Text = Convert.ToString(1);
                    lstItem.Value = Convert.ToString(1);
                    drdpPage.Items.Add(lstItem);
                }
                else
                {
                    for (int i = 0; i < pages; i++)
                    {
                        lstItem = new ListItem();
                        lstItem.Text = Convert.ToString(i + 1);
                        lstItem.Value = Convert.ToString(i + 1);
                        drdpPage.Items.Add(lstItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvEvenSettings_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvEvenSettings.EditIndex = -1;
                GetEventList(VenueID, pagesize, drdpPage.SelectedIndex, txtSearchBy.Text.Trim());
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

        protected void gvEvenSettings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblFEATURESHOW = (Label)e.Row.Cells[7].FindControl("lblFEATURESHOW");
                    Label lblSPECIALIMAGE = (Label)e.Row.Cells[8].FindControl("lblSPECIALIMAGE");
                    CheckBox chkSI = (CheckBox)e.Row.Cells[4].FindControl("chkSpecialImage");
                    CheckBox chkFS = (CheckBox)e.Row.Cells[6].FindControl("chkFeatureShow");
                    
                    if (lblFEATURESHOW.Text == "True")
                    {
                        chkFS.Checked = true;
                    }
                    else
                    {
                        chkFS.Checked = false;
                    }

                    if (lblSPECIALIMAGE.Text == "True")
                    {
                        chkSI.Checked = true;
                    }
                    else
                    {
                        chkSI.Checked = false;
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

        protected void gvEvenSettings_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvEvenSettings.EditIndex = e.NewEditIndex;
                GetEventList(VenueID, pagesize, drdpPage.SelectedIndex, txtSearchBy.Text.Trim());
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

        protected void gvEvenSettings_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow grd = gvEvenSettings.Rows[e.RowIndex];
                CheckBox chkSpecialImageStatus = (CheckBox)grd.FindControl("chkSpecialImage");
                CheckBox chkFeatureShowStatus = (CheckBox)grd.FindControl("chkFeatureShow");
                Label lblEventSPID = (Label)grd.FindControl("lblEventID");

                 GetEventDetailsViewModel _getEventDetailsViewModel = new GetEventDetailsViewModel();
                 bool retval = _getEventDetailsViewModel.EventsSetting(lblEventSPID.Text, chkSpecialImageStatus.Checked, chkFeatureShowStatus.Checked);

                 if (retval == true)
                 {
                     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "sqlSuccess", "alert('Event Setting updated successfully');", true);
                 }
                 gvEvenSettings.EditIndex = -1;
                 GetEventList(VenueID, pagesize, drdpPage.SelectedIndex, txtSearchBy.Text.Trim());

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

        private void SetCloumn(bool flag)
        {
            try
            {
                //GridViewDriverAttendance.Columns[0].Visible = flag;
                gvEvenSettings.Columns[6].Visible = flag;
                gvEvenSettings.Columns[7].Visible = flag;
                gvEvenSettings.Columns[8].Visible = flag;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminReport
{
    public partial class rptTransactionDetails : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["SVenue"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='/SessionExpire.aspx'", true);
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
                string parameter = Request["__EVENTARGUMENT"]; // parameter

                if (Request["__EVENTTARGET"] == "GetEvents")
                {
                    GetEvent(parameter);
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

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {

                if (ddEventList.SelectedItem != null)
                {
                    EventTransactionDetailsViewModel _eventTransactionDetailsViewModel = new EventTransactionDetailsViewModel();
                    List<EventTransactionDetailsModel> _eventTransactionDetailsModel = new List<EventTransactionDetailsModel>();

                    _eventTransactionDetailsModel = _eventTransactionDetailsViewModel.GetEventTransactionDetails(ddEventList.SelectedItem.Value);
                    gvTransactionDetails.DataSource = _eventTransactionDetailsModel;
                    gvTransactionDetails.DataBind();
                }
                else
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"alert('Validation : Select Event')");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);
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

        protected void GetEvent(string EventDate)
        {
            try
            {
                VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                List<EventListModel> _eventListModel = new List<EventListModel>();

                _eventListModel = _venueDetailsViewModel.GetEventByDate(EventDate);

                ddEventList.DataSource = _eventListModel;
                ddEventList.DataTextField = "EventName";
                ddEventList.DataValueField = "EventSPID";
                ddEventList.DataBind();


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
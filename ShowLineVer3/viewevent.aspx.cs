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
    public partial class viewevent : System.Web.UI.Page
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

                   // Response.Redirect("http://showsline.com/admin.aspx");//-kk
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
                EventList.DataSource = _eventMasterModel;
                EventList.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EventList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    //Response.Redirect("/addevent-details.aspx?EO=" + e.CommandArgument + ""); //kk redirect
                    Response.Redirect("/addevent-details.aspx?EO=" + e.CommandArgument + "", false);
                    Context.ApplicationInstance.CompleteRequest();

                }

                if (e.CommandName == "delete")
                {
                    EventsEntryPageViewModel _eventMasterDAL = new EventsEntryPageViewModel();
                    if (_eventMasterDAL.DeleteEventDetails(e.CommandArgument.ToString(), "TRUE") == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Deleted Sucessfully.','Add Event Details');</script>", false);
                    }

                    GetEventList(0, 20, 0, "");
                }

                if (e.CommandName == "update")
                {
                    Response.Redirect("/EditTicketDetails.aspx?EO=" + e.CommandArgument + "", false);
                    Context.ApplicationInstance.CompleteRequest();

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
                throw ex;
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
    }
}
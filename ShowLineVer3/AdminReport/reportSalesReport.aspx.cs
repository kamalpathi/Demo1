using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;
using System.IO;
using System.Drawing;

namespace ShowLineVer3.AdminReport
{
    public partial class reportSalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["SVenue"] != null)
                {
                    if (!IsPostBack)
                    {
                        GetVenueDetails();

                        List<CurrentEventReport> cabListModel = new List<CurrentEventReport>();
                        CurrentEventReportViewModel _CurrentEventReportViewModel = new CurrentEventReportViewModel();

                        cabListModel = _CurrentEventReportViewModel.GetAllEventReport("01/OCt/2013", "01/OCt/2013", "1111");
                        gvTransactionDetails.DataSource = cabListModel;
                        gvTransactionDetails.DataBind();

                    }

                    string parameter = Request["__EVENTARGUMENT"]; // parameter

                    if (Request["__EVENTTARGET"] == "GetEvents")
                    {
                        GetEvent(parameter);
                    }
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='/SessionExpire.aspx'", true);
                    Response.Redirect("/SessionExpire.aspx", false);
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

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<CurrentEventReport> cabListModel = new List<CurrentEventReport>();
                CurrentEventReportViewModel _CurrentEventReportViewModel = new CurrentEventReportViewModel();

                cabListModel = _CurrentEventReportViewModel.GetAllEventReport(txtEventDate.Value, txtEventDate.Value, ddEventList.SelectedItem.Value);
                gvTransactionDetails.DataSource = cabListModel;
                gvTransactionDetails.DataBind();

            }
            catch (Exception ex)
            {
            }
           
        }

        protected void GetEvent(string VenuID)
        {
            try
            {
                //if (hdValue.Value != "1")
                {
                    VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                    List<EventListModel> _eventListModel = new List<EventListModel>();

                    if (txtEventDate.Value == "")
                    {
                        _eventListModel = _venueDetailsViewModel.GetEventList(VenuID, "ALL");
                    }
                    else
                    {
                        _eventListModel = _venueDetailsViewModel.GetEventList(VenuID, txtEventDate.Value);
                    }

                    ddEventList.DataSource = _eventListModel;
                    ddEventList.DataTextField = "EventName";
                    ddEventList.DataValueField = "EventSPID";
                    ddEventList.DataBind();

                    //ListItem lst = new ListItem();
                    //lst.Text = "ALL";
                    //lst.Value = "ALL";
                    //ddEventList.Items.Insert(0, lst);

                    //hdValue.Value = "1";
                    //ddEventList.Items.Add(lst);
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

        protected void GetVenueDetails()
        {
            try
            {
                VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                List<VenueDetailsModel> _venueDetailsModel = new List<VenueDetailsModel>();
                VenueDetailsModel _venueDetails = new VenueDetailsModel();

                if (Convert.ToInt32(Session["SVenue"].ToString()) == 0)
                {
                    _venueDetailsModel = _venueDetailsViewModel.GetVenueDetails();
                    ddVenue.DataSource = _venueDetailsModel;
                    ddVenue.DataTextField = "VenueName";
                    ddVenue.DataValueField = "VenueID";
                    ddVenue.DataBind();
                }
                else
                {
                    _venueDetails = _venueDetailsViewModel.GetVenueDetailsByID(Session["SVenue"].ToString());

                    ListItem lst = new ListItem();
                    lst.Text = _venueDetails.VenueName;
                    lst.Value = _venueDetails.VenueID.ToString();
                    ddVenue.Items.Add(lst);
                }

                ListItem lst1 = new ListItem();
                lst1.Text = "--SELECT--";
                lst1.Value = "--SELECT--";
                ddVenue.Items.Insert(0, lst1);
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

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "EventReport.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvTransactionDetails.AllowPaging = false;
            //Change the Header Row back to white color
            gvTransactionDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < gvTransactionDetails.HeaderRow.Cells.Count; i++)
            {
                gvTransactionDetails.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            //This loop is used to apply stlye to cells based on particular row
            foreach (GridViewRow gvrow in gvTransactionDetails.Rows)
            {
                gvrow.BackColor = Color.White;
                if (j <= gvTransactionDetails.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            gvTransactionDetails.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}
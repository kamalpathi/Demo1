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
    public partial class EditTicketDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["EO"] != null)
                {
                    hdEventSPID.Value = Request.QueryString["EO"];
                    GetTicketDetails();
                }
            }
        }

        private void GetTicketDetails()
        {
            try
            {
                EventsEntryPageViewModel eventsEntryPageViewModel = new EventsEntryPageViewModel();
                List<EventPriceDetailsModel> _eventPriceDetailsModel = new List<EventPriceDetailsModel>();
                _eventPriceDetailsModel = eventsEntryPageViewModel.GetEventPriceDetails(Request.QueryString["EO"]);
                gvTicketDetails.DataSource = _eventPriceDetailsModel;
                gvTicketDetails.DataBind();

                GetEventDetails();
            }
            catch (Exception EX)
            {

            }
        }

        private void GetEventDetails()
        {
            using (TicketTypeViewModel ttm = new TicketTypeViewModel())
            {
                string ticketFromTime="";
                string ticketToTime = "";
                string EventName= "";
                ttm.TicketDetails(hdEventSPID.Value, out ticketFromTime, out ticketToTime, out  EventName);
                lblEventName.Text = EventName;
                lblEventTime.Text = ticketFromTime + " - " + ticketToTime;

            }
        }

        protected void gvTicketDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;

                txtTicketType.Text = gvTicketDetails.Rows[e.NewSelectedIndex].Cells[2].Text;
                txtTotalSeats.Text = gvTicketDetails.Rows[e.NewSelectedIndex].Cells[3].Text;
                txtTicketPrice.Text = gvTicketDetails.Rows[e.NewSelectedIndex].Cells[4].Text;

                hdEventID.Value = gvTicketDetails.Rows[e.NewSelectedIndex].Cells[1].Text;
            }
            catch (Exception ex)
            {
                //we.WriteExceptionInFile("PackageMaster-gvPackage_SelectedIndexChanging :" + ex.ToString(), CompanyCode);
            }
        }

        protected void gvTicketDetails_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void gvTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (txtTicketPrice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Ticket Price.','Add Event Details');</script>", false);
                return;
            }

            if (txtTicketType.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Ticket Type.','Add Event Details');</script>", false);
                return;
            }

            if (txtTotalSeats.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Total Seats.','Add Event Details');</script>", false);
                return;
            }

            if (hdEventSPID.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Session Expired.','Add Event Details');</script>", false);
                Response.Redirect("/viewevent.aspx", false);
                return;
            }
                       

            using (TicketTypeViewModel ttm = new TicketTypeViewModel())
            {
                bool RetVal = false ;
                RetVal = ttm.CheckTicketName(txtTicketType.Text, hdEventSPID.Value.ToString());

                if (RetVal == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Ticket Type alerady Exists.','Add Event Details');</script>", false);
                    GetTicketDetails();
                    return;
                }

                RetVal = ttm.AddTickets(txtTicketType.Text, txtTicketPrice.Text, hdEventSPID.Value.ToString(), Convert.ToInt32(txtTotalSeats.Text));

                if (RetVal == true)
                {
                    EventsEntryPageViewModel eep = new EventsEntryPageViewModel();
                    eep.GenerateBarCode(hdEventSPID.Value, txtTicketType.Text);
                    eep = null;

                    txtTicketPrice.Text = "";
                    txtTicketType.Text = "";
                    txtTotalSeats.Text = "";
                    hdEventID.Value = "";

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Saved Sucessfully.','Add Event Details');</script>", false);
                    GetTicketDetails();
                }
            }
        }

        protected void gvTicketDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (TicketTypeViewModel ttm = new TicketTypeViewModel())
            {
                bool RetVal = ttm.DeleteTicket(Convert.ToInt32(gvTicketDetails.Rows[e.RowIndex].Cells[1].Text));

                if (RetVal == true)
                {                    
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Deleted Sucessfully.','Add Event Details');</script>", false);
                    GetTicketDetails();
                }
            }
        }
        
        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            if (txtTicketPrice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Ticket Price.','Add Event Details');</script>", false);
                return;
            }

            if (txtTicketType.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Ticket Type.','Add Event Details');</script>", false);
                return;
            }

            if (txtTotalSeats.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Enter Total Seats.','Add Event Details');</script>", false);
                return;
            }

            if (hdEventID.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Select Ticket Type to Edit.','Add Event Details');</script>", false);
                return;
            }

            using (TicketTypeViewModel ttm = new TicketTypeViewModel())
            {
                bool RetVal = ttm.UpdateTicketType(txtTicketType.Text, txtTicketPrice.Text, Convert.ToInt32(hdEventID.Value), Convert.ToInt32(txtTotalSeats.Text));

                if (RetVal == true)
                {
                    EventsEntryPageViewModel eep = new EventsEntryPageViewModel();
                    eep.GenerateBarCode(hdEventSPID.Value, txtTicketType.Text);
                    eep = null;

                    txtTicketPrice.Text = "";
                    txtTicketType.Text = "";
                    txtTotalSeats.Text = "";
                    hdEventID.Value = "";                   

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Saved Sucessfully.','Add Event Details');</script>", false);
                    GetTicketDetails();
                }
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            txtTicketPrice.Text = "";
            txtTicketType.Text = "";
            txtTotalSeats.Text = "";
            hdEventID.Value = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
    }
}
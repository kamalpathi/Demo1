using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.WebSite
{
    public partial class events_List : System.Web.UI.Page
    {
        string EID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ID"].ToString() != null)
                {
                    EID = Request.QueryString["ID"].ToString();
                }

                if (!IsPostBack)
                {

                    GetEventDetails(EID);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void GetEventDetails(string EventID)
        {
            try
            {
                EventTicketDetailsViewModel _eventTicketDetailsViewModel = new EventTicketDetailsViewModel();
                List<EventTicketDetailsModel> _eventTicketDetailsModel = new List<EventTicketDetailsModel>();
                _eventTicketDetailsModel = _eventTicketDetailsViewModel.GetEventTicketDetailsList(EventID);

                if (_eventTicketDetailsModel != null)
                {
                    lblEventName.Text = _eventTicketDetailsModel[0].EventTitle;
                    imgEvent.Src = _eventTicketDetailsModel[0].ImagePath;
                    lblEvtDate.Text = Convert.ToDateTime(_eventTicketDetailsModel[0].EventDate).ToString("dd MMM,yyyy");
                    lblEvtDate.Text += " " + Convert.ToDateTime(_eventTicketDetailsModel[0].EVENTFROMTIME).ToString("HH:mm");
                    lblEvtDate.Text += " - " + Convert.ToDateTime(_eventTicketDetailsModel[0].EVENTTOTIME).ToString("HH:mm");
                    lblEventDetails.Text = _eventTicketDetailsModel[0].EventDesc;

                    lblLocationName.Text = _eventTicketDetailsModel[0].LocationName;
                    ImgVenue.Src = ".." + _eventTicketDetailsModel[0].VenueImagePath;
                }

                for (int i = 0; i < _eventTicketDetailsModel.Count; i++)
                {

                    ListItem lst = new ListItem();
                    decimal Eventprice = 0;

                    decimal.TryParse(_eventTicketDetailsModel[i].EVENTPRICE.ToString(), out Eventprice);
                    lst.Value = Eventprice.ToString();
                    lst.Text = _eventTicketDetailsModel[i].EVENTPRICEDETAILS.ToString();
                    ddTicketType.Items.Add(lst);

                }

                _eventTicketDetailsModel = null;

                _eventTicketDetailsViewModel = null;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

       
        protected void ddQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double val = Convert.ToDouble(ddQty.SelectedItem.Value);
                double currencys = Convert.ToDouble(ddTicketType.SelectedItem.Value);
                USDPrice.Value =  (currencys * val).ToString();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void Checkout_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/WebSite/Payment.aspx?EID=" + EID + "&TNO=" + ddQty.Text + "&ddType=" + ddTicketType.SelectedItem.Text + "&ddA=" + ddTicketType.SelectedItem.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }
    }
}
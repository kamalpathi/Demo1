using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.WebSite
{
    public partial class Confirmation : System.Web.UI.Page
    {
        string EID = "";
        string TID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EncryptDecrypt _EncryptDecrypt = new EncryptDecrypt();

                EID = _EncryptDecrypt.Decrypt_QueryString(Request.QueryString["EID"].ToString());
                TID = _EncryptDecrypt.Decrypt_QueryString(Request.QueryString["TID"].ToString());

                _EncryptDecrypt = null;

                hTID.Value = TID;

                if (!IsPostBack)
                {
                    GetBookingDetails(TID);
                    GetEventDetails();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        private void GetBookingDetails(string TID)
        {
            try
            {
                ConfirmationViewModel _confirmationViewModel = new ConfirmationViewModel();
                List<ConfirmationModel> _confirmationModel = new List<ConfirmationModel>();

                _confirmationModel = _confirmationViewModel.GetTicketConfirmationDetails(TID);

                rptTicketDetails.DataSource = _confirmationModel;
                rptTicketDetails.DataBind();

                transactionID.Text = TID;
                customerName.Text = _confirmationModel[0].CustFirstName.ToString();
                eventName.Text = _confirmationModel[0].EventTitle.ToString();
                //eventDate.Text = _confirmationModel[0].Eventdate.ToString() + " " + _confirmationModel[0].FROMTM.ToString() + " - " + _confirmationModel[0].TOTIME.ToString();
                eventDate.Text = Convert.ToDateTime(_confirmationModel[0].Eventdate.ToString()).ToString("dd/MMM/yyyy");// +" " + _confirmationModel[0].FROMTM.ToString();//kk  +" - " + _confirmationModel[0].TOTIME.ToString();
                VenueDetails.Text = _confirmationModel[0].VenueName.ToString();// +" " + _confirmationModel[0].StreetAddress.ToString() + " " + _confirmationModel[0].City.ToString() + " " + _confirmationModel[0].StateProvision.ToString();
                lblStreetAddress.Text = _confirmationModel[0].StreetAddress.ToString();
                lblCity.Text = _confirmationModel[0].City.ToString();
                lblState.Text = _confirmationModel[0].StateProvision.ToString();
                lblZip.Text = _confirmationModel[0].ZipCode.ToString();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        private void InsertBookingDetails()
        {

        }

        protected void btnBookAnotherTicket_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("~/ContentMain.aspx");//-kk redirect
                Response.Redirect("http://showsline.com/default.aspx?action=logout", false);
                            Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void printTicket_ServerClick(object sender, EventArgs e)
        {
            try
            {                
                Response.Redirect("http://showsline.com/Report.aspx?TT=ALL&TID=" + TID);  //kk print
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        private void GetEventDetails()
        {
            try
            {
                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                string simg = _eventListingViewModel.BannerImage().Replace("~", "");

                bannerImg.Src = simg;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                // Response.Redirect("Default.aspx"); //-kk redirect
                Response.Redirect("http://showsline.com/Default.aspx?action=logout", false);
                Context.ApplicationInstance.CompleteRequest();

            }

        }
    }
}
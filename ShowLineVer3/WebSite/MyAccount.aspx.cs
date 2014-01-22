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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    //show Login Screen
                }

                if (!IsPostBack)
                {
                    GetEventDetails();
                    //GetListing();
                }
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
                //    EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                //    List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                //    rcontent.DataSource = _eventListingModel.Take(4);
                //    rcontent.DataBind();

                //    rQuickBook.DataSource = _eventListingModel;
                //    rQuickBook.DataBind();

                //    rFeatured.DataSource = _eventListingModel.Take(4);
                //    rFeatured.DataBind();

                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                _eventListingModel = _eventListingViewModel.GetEventListing();

                rcontent.DataSource = _eventListingModel.Take(4);
                rcontent.DataBind();

                rQuickBook.DataSource = _eventListingModel;
                rQuickBook.DataBind();

                rFeatured.DataSource = _eventListingModel.Take(4);
                rFeatured.DataBind();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }


        //protected void GetListing()
        //{
        //    EventListingPageViewModel _eventListingPageViewModel = new EventListingPageViewModel();
        //    List<EventListingModel> _eventListingModel = new List<EventListingModel>();
        //    _eventListingModel = _eventListingPageViewModel.GetEventDetails(58, 5);
        //    EventDetails.DataSource = _eventListingModel;
        //    EventDetails.DataBind();
        //}
    }
}
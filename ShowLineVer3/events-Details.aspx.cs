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
    public partial class events_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["searchby"] != null)
                    {
                        GetListing(Request.QueryString["searchby"].ToString());
                    }
                    else
                    {
                        GetListing("");
                    }
                    GetEventDetails();

                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private void GetEventDetails()
        {
            try
            {
                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                _eventListingModel = _eventListingViewModel.GetEventListing();

                //rcontent.DataSource = _eventListingModel; //-kk .Take(4);
                //rcontent.DataBind();

                rQuickBook.DataSource = _eventListingModel.Take(10);  //+kk added 10;
                rQuickBook.DataBind();

                //rFeatured.DataSource = _eventListingModel.Take(4);
                //rFeatured.DataBind();

                var featureshow = _eventListingModel.Where(m => m.FeatureShow == "True");

                rFeatured.DataSource = featureshow.Take(5); //_eventListingModel.Take(4);
                rFeatured.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void GetListing(string SearchBy)
        {
            try
            {
                EventListingPageViewModel _eventListingPageViewModel = new EventListingPageViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();
                _eventListingModel = _eventListingPageViewModel.GetEventDetails(58, 5, SearchBy);
                //EventDetails.DataSource = _eventListingModel;
                //EventDetails.DataBind();

                rcontent.DataSource = _eventListingModel; //-kk .Take(4);
                rcontent.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

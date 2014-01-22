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
    public partial class GalleryImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadGallery();
            GetEventDetails();
        }

        protected void UploadGallery()
        {
            GalleryViewModel _galleryViewModel = new GalleryViewModel();
            List<GalleryModel> _galleryModel = new List<GalleryModel>();

            _galleryModel = _galleryViewModel.GetGalleryImage();

            rptImageScroll.DataSource = _galleryModel;
            rptImageScroll.DataBind();

            //<a href="images/galleryImages/cubagallery-img-4.jpg" title="Lorem ipsum dolor sit amet Fourth Image">
            //        <img src="images/galleryImages/cubagallery-img-4.jpg" /></a> 

            //GalleryViewModel _galleryViewModel = new GalleryViewModel();
            //List<GalleryModel> _galleryModel = new List<GalleryModel>();


            //_galleryModel = _galleryViewModel.GetGalleryImage();

            //foreach (var item in _galleryModel)
            //{
            //    phGallery.Controls.Add(new LiteralControl("<a href=" + item.GalleryImagePath + " title=" + item.Description + ">"));
            //    phGallery.Controls.Add(new LiteralControl("<img src=" + item.GalleryImagePath + "/>"));
            //    phGallery.Controls.Add(new LiteralControl("</a>"));
            //}

        }

        private void GetEventDetails()
        {
            try
            {
                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                _eventListingModel = _eventListingViewModel.GetEventListing();

                //var eventList = _eventListingModel.Where(m => m.SpecialImage == "True");
                //rswitchBigPic.DataSource = eventList.Take(5); //_eventListingModel.Where(m => m.SpecialImage == "True"); //+kk added take(5);
                //rswitchBigPic.DataBind();



                ////rnav.DataSource = _eventListingModel.Take(5);  //+kk added 5
                //rnav.DataSource = eventList.Take(5);
                ////rnav.DataSource = _eventListingModel.Where(m => m.SpecialImage == "True");  //+kk added 5
                //rnav.DataBind();

                //var amascroll = _eventListingModel.Where(m => m.SmallImagePath != "");

                //ramazon_scroller_mask.DataSource = amascroll;
                //ramazon_scroller_mask.DataBind();

                ////rcontent.DataSource = _eventListingModel.Take(5); //+kk changed to  5
                //rcontent.DataSource = amascroll.Take(7); //+kk changed to  5
                //rcontent.DataBind();


                rQuickBook.DataSource = _eventListingModel.Take(10);  //+kk added 10
                rQuickBook.DataBind();

                var featureshow = _eventListingModel.Where(m => m.FeatureShow == "True");

                rFeatured.DataSource = featureshow.Take(5); //_eventListingModel.Take(4);
                rFeatured.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
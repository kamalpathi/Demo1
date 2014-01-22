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
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadGallery();
        }

        protected void UploadGallery()
        {
            GalleryViewModel _galleryViewModel = new GalleryViewModel();
            List<GalleryModel> _galleryModel = new List<GalleryModel>();

            _galleryModel = _galleryViewModel.GetGalleryImage();

            rptImageScroll.DataSource = _galleryModel;
            rptImageScroll.DataBind();

            //galleryDataList.DataSource = _galleryModel;
            //galleryDataList.DataBind();
        }
    }
}
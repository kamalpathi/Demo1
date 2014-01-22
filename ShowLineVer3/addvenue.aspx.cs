using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminPanel
{
    public partial class addvenue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["Ecode"] != null)
                    {
                        if (Request.QueryString["Ecode"].ToString() != "")
                        {
                            GetVenueDetails(Request.QueryString["Ecode"]);
                            btnUpdate.Visible = true;
                            btnSave.Visible = false;
                        }
                        else
                        {
                            btnUpdate.Visible = false;
                            btnSave.Visible = true;
                        }
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePage() == true)
                {
                    VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                    VenueDetailsModel _venueDetailsModel = new VenueDetailsModel();

                    _venueDetailsModel.VenueName = txtVenueName.Value;
                    _venueDetailsModel.StreetAddress = txtStreetAddress.Value;
                    _venueDetailsModel.City = txtCity.Value;
                    _venueDetailsModel.StateProvision = txtStateProvision.Value;
                    _venueDetailsModel.ZipCode = txtZipCode.Value;

                    string FileName = SaveImage();
                    _venueDetailsModel.VenueImage = FileName;

                    bool retval = _venueDetailsViewModel.SaveVenueDetails(_venueDetailsModel);

                    if (retval == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Venue details added sucessfully.','Add Event Details');</script>", false);
                        //Response.Redirect("/VenueDetails.aspx");//-kk redirect
                            Response.Redirect("/VenueDetails.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected string SaveImage()
        {
            try
            {
                string s = filenm.Value;
                string[] file;
                string ext = "";
                string d;
                var r = new Random();

                if (s == "")
                {
                    file = VenueImagePath.Value.Split('.');
                    string[] sp = file[0].Split('\\');
                    d = sp[sp.Length - 1];
                    ext = d;
                }
                else
                {
                    file = s.Split('.');
                    d = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                    ext = "V" + d;
                }

                string t = file[file.Length - 1].ToString();



                string baseImageLocation = Server.MapPath(@"\ShowlineImages\");
                HttpFileCollection files = Request.Files;
                HttpPostedFile httpPostedFile = files["filenm"];
                string fileExt = Path.GetExtension(httpPostedFile.FileName).ToLower();
                string fileName = Path.GetFileName(httpPostedFile.FileName);

                //FileInfo myfileinf = new FileInfo(hdBanner.Value);
                //myfileinf.Delete();

                if (fileName != "")
                {
                    //if (fileExt == ".jpg" || fileExt == ".gif")
                    //httpPostedFile.SaveAs(baseImageLocation + fileName);
                    httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                }

                return @"\ShowlineImages\" + ext + "." + file[file.Length - 1].ToString();
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        protected void GetVenueDetails(string VenueID)
        {
            try
            {
                VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                VenueDetailsModel _venueDetailsModel = new VenueDetailsModel();
                _venueDetailsModel = _venueDetailsViewModel.GetVenueDetailsByID(VenueID);
                hdVenueID.Value = _venueDetailsModel.VenueID.ToString();
                txtVenueName.Value = _venueDetailsModel.VenueName;
                txtStreetAddress.Value = _venueDetailsModel.StreetAddress;
                txtCity.Value = _venueDetailsModel.City;
                txtStateProvision.Value = _venueDetailsModel.StateProvision;
                txtZipCode.Value = _venueDetailsModel.ZipCode;
                VenueImagePath.Value = _venueDetailsModel.VenueImage;
                img_prev.Src = _venueDetailsModel.VenueImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePage() == true)
                {
                    VenueDetailsViewModel _venueDetailsViewModel = new VenueDetailsViewModel();
                    VenueDetailsModel _venueDetailsModel = new VenueDetailsModel();

                    _venueDetailsModel.VenueName = txtVenueName.Value;
                    _venueDetailsModel.StreetAddress = txtStreetAddress.Value;
                    _venueDetailsModel.City = txtCity.Value;
                    _venueDetailsModel.StateProvision = txtStateProvision.Value;
                    _venueDetailsModel.ZipCode = txtZipCode.Value;
                    _venueDetailsModel.VenueID = Convert.ToInt32(hdVenueID.Value);

                    string FileName = SaveImage();
                    _venueDetailsModel.VenueImage = FileName;

                    bool retval = _venueDetailsViewModel.UpdateVenueDetails(_venueDetailsModel);

                    if (retval == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Venue details updated sucessfully.','Add Event Details');</script>", false);
                       // Response.Redirect("/VenueDetails.aspx"); //-kk redirect
                            Response.Redirect("/VenueDetails.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Venue Details", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private bool ValidatePage()
        {
            try
            {
                bool retval = true;

                if (txtVenueName.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please enter Venue Details.','Add Venue Details: Validation','txtVenueName');</script>", false);
                }

                if (txtStreetAddress.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please enter Address.','Add Venue Details: Validation','txtStreetAddress');</script>", false);
                }

                if (txtCity.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please enter City.','Add Venue Details: Validation','txtCity');</script>", false);
                }

                if (txtStateProvision.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please enter State.','Add Venue Details: Validation','txtCity');</script>", false);
                }

                if (txtZipCode.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please enter Zip Code.','Add Venue Details: Validation','txtCity');</script>", false);
                }

                if (filenm.Value == "" && VenueImagePath.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Venue Validation", "<script type='text/javascript'>CheckValidation('Please Select Venue Image.','Add Venue Details: Validation','lstVenueDetails');</script>", false);
                }

                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
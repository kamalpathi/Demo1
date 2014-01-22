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
    public partial class addevent_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetVenueDetails();
                GetEventType();

                if (Request.QueryString["EO"] != null)
                {
                    EditEventDetails(Request.QueryString["EO"]);
                }
                else
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (ValidatePage() == true)
            {
                //BIG IMAGE

                string s = filenm.Value;
                string[] file = s.Split('.');
                string t = file[file.Length - 1].ToString();
                string ext = "";

                var r = new Random();
                string d = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                ext = "E" + d;

                string baseImageLocation = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection files = Request.Files;
                HttpPostedFile httpPostedFile = files["filenm"];
                string fileExt = Path.GetExtension(httpPostedFile.FileName).ToLower();
                string fileName = Path.GetFileName(httpPostedFile.FileName);
                
                //SMALL IMAGE

                string sm = filenm.Value;
                string[] filesm = sm.Split('.');
                string tsm = filesm[filesm.Length - 1].ToString();
                string extSM = "";

                string dsm = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                extSM = "S" + dsm;

                string baseImageLocationsm = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection filessm = Request.Files;
                HttpPostedFile httpPostedFilesm = filessm["filenm"];
                string fileExtsm = Path.GetExtension(httpPostedFilesm.FileName).ToLower();
                string fileNamesm = Path.GetFileName(httpPostedFilesm.FileName);

                // TICKET IMAGE

                string sTm = filenm.Value;
                string[] filesTm = sTm.Split('.');
                string tsTm = filesTm[filesTm.Length - 1].ToString();
                string extSTM = "";

                string dsTm = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                extSTM = "T" + dsTm;

                string baseImageLocationsTm = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection filessTm = Request.Files;
                HttpPostedFile httpPostedFilesTm = filessTm["filenm"];
                string fileExtsTm = Path.GetExtension(httpPostedFilesTm.FileName).ToLower();
                string fileNamesTm = Path.GetFileName(httpPostedFilesTm.FileName);
                //

                EventsEntryPageViewModel _eventMasterDAL = new EventsEntryPageViewModel();
                EventMasterModel eventMasterModel = new EventMasterModel();
                List<EventTimeDetailsModel> eventTimeDetailsModel = new List<EventTimeDetailsModel>();

                List<EventPriceDetailsModel> eventPriceDetailsModel = new List<EventPriceDetailsModel>();

                eventMasterModel.EventTypeID = ddEventType.SelectedItem.Value;
                eventMasterModel.EventSubtypeID = ddEvebtSubType.SelectedItem.Value.ToString();
                eventMasterModel.VenueID = ddVenueDetails.SelectedItem.Value;
                eventMasterModel.EventTitle = txtEventTitle.Value.Trim();
                eventMasterModel.EventDesc = txtEventDesc.Value.Trim();
                eventMasterModel.Artists = txtArtist.Value.Trim();
                eventMasterModel.Genre = txtGenre.Value.Trim();
                eventMasterModel.ImagePath = "/ShowlineImages/" + ext + "." + file[file.Length - 1].ToString();
                eventMasterModel.SmallImagePath = "/ShowlineImages/" + extSM + "." + filesm[filesm.Length - 1].ToString();
                eventMasterModel.EventLayout = "/ShowlineImages/" + extSTM + "." + filesTm[filesTm.Length - 1].ToString();
                eventMasterModel.EventID = ext;
                eventMasterModel.EventDate = txtEventDate.Value;

                eventTimeDetailsModel.Add(new EventTimeDetailsModel
                    {
                        EventFromTime = Convert.ToDateTime(txtEventDate.Value + " " + txtFromTime.Value),
                        EventToTime = Convert.ToDateTime(txtEventDate.Value + " " + txtTotTime.Value)
                    });

                if (txtTicketType1.Value.Trim() != "" || txtTotalSeat1.Value.Trim() != "" || txtTicketPrice1.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType1.Value.Trim(), EventPrice = txtTicketPrice1.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat1.Value.Trim()) });
                }

                if (txtTicketType2.Value.Trim() != "" || txtTotalSeat2.Value.Trim() != "" || txtTicketPrice2.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType2.Value.Trim(), EventPrice = txtTicketPrice2.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat2.Value.Trim()) });
                }

                if (txtTicketType3.Value.Trim() != "" || txtTotalSeat3.Value.Trim() != "" || txtTicketPrice3.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType3.Value.Trim(), EventPrice = txtTicketPrice3.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat3.Value.Trim()) });
                }

                if (txtTicketType4.Value.Trim() != "" || txtTotalSeat4.Value.Trim() != "" || txtTicketPrice4.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType4.Value.Trim(), EventPrice = txtTicketPrice4.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat4.Value.Trim()) });
                }


                if (_eventMasterDAL.InsertEventMaster(eventMasterModel, eventTimeDetailsModel, eventPriceDetailsModel) == true)
                {
                    if (fileName != "")
                    {
                        httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                    }

                    if (fileNamesm != "")
                    {
                        httpPostedFilesm.SaveAs(baseImageLocationsm + ext + "." + filesm[filesm.Length - 1].ToString());
                    }


                    if (fileExtsTm != "")
                    {
                        httpPostedFilesTm.SaveAs(baseImageLocationsTm + ext + "." + filesTm[filesTm.Length - 1].ToString());
                    }

                    ClearAllControl();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Saved Sucessfully.','Add Event Details');</script>", false);                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                }

            }
        }
        
        private bool ValidatePage()
        {
            bool retval = true;

            if (txtEventTitle.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Event Title.','Add Event Details: Validation','txtEventTitle');</script>", false);
            }

            if (txtEventDesc.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Event Description.','Add Event Details: Validation','txtEventDesc');</script>", false);
            }

            if (txtArtist.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Artist Name.','Add Event Details: Validation','txtArtist');</script>", false);
            }

            if (txtGenre.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Genre.','Add Event Details: Validation','txtGenre');</script>", false);
            }

            if (txtEventDate.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Event Date.','Add Event Details : Validation','txtEventDate');</script>", false);
            }

            if (txtFromTime.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Event From Time.','Add Event Details: Validation','txtFromTime');</script>", false);
            }

            if (txtTotTime.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Event To Time.','Add Event Details: Validation','txtTotTime');</script>", false);
            }

            if (txtTicketPrice1.Value == "" && txtTicketPrice2.Value == "" && txtTicketPrice3.Value == "" && txtTicketPrice4.Value == "")
            {
                retval = false;                
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Ticket Details.','Add Event Details: Validation','txtTicketPrice1');</script>", false);
            }

            if (txtTotalSeat1.Value == "" && txtTotalSeat2.Value == "" && txtTotalSeat3.Value == "" && txtTotalSeat4.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Total Seat.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
            }

            if (txtTicketPrice1.Value == "" && txtTicketPrice2.Value == "" && txtTicketPrice3.Value == "" && txtTicketPrice4.Value == "")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Ticket price.','Add Event Details: Validation','txtTicketPrice1');</script>", false);
            }

            if (ddEventType.Text.ToString().Contains("Choose"))
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please Select Event Type.','Add Event Details: Validation','cmdEventType');</script>", false);
            }

            if (ddEvebtSubType.Text.Contains("Choose"))
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please Select Event Sub Type.','Add Event Details: Validation','cmbEventSubType');</script>", false);
            }


            if (ddVenueDetails.Text.Contains("Select"))
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please Select Venue Details.','Add Event Details: Validation','lstVenueDetails');</script>", false);
            }

            if (filenm.Value == "" && hdImagePath.Value =="")
            {
                retval = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please Select Event Image.','Add Event Details: Validation','lstVenueDetails');</script>", false);
            }

            bool isNum;
            double Num;
            int NumInt;

            if (txtTotalSeat1.Value != "")
            {
                isNum = Int32.TryParse(txtTotalSeat1.Value, out NumInt);
                
                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTotalSeat2.Value != "")
            {
                isNum = Int32.TryParse(txtTotalSeat2.Value, out NumInt);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTotalSeat3.Value != "")
            {
                isNum = Int32.TryParse(txtTotalSeat3.Value, out NumInt);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTotalSeat4.Value != "")
            {
                isNum = Int32.TryParse(txtTotalSeat4.Value, out NumInt);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTicketPrice1.Value != "")
            {
                isNum = double.TryParse(txtTicketPrice1.Value, out Num);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTicketPrice2.Value != "")
            {
                isNum = double.TryParse(txtTicketPrice2.Value, out Num);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTicketPrice3.Value != "")
            {
                isNum = double.TryParse(txtTicketPrice3.Value, out Num);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            if (txtTicketPrice4.Value != "")
            {
                isNum = double.TryParse(txtTicketPrice4.Value, out Num);

                if (!isNum)
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTotalSeat1');</script>", false);
                }
            }

            return retval;
        }

        protected void GetVenueDetails()
        {
            try
            {
                List<VenueDetailsModel> _venueDetails = new List<VenueDetailsModel>();
                VenueDetailsViewModel venueList = new VenueDetailsViewModel();

                _venueDetails = venueList.GetVenueDetails();

                foreach (var item in _venueDetails)
                {
                    ListItem lst = new ListItem();
                    lst.Text = item.VenueName;
                    lst.Value = item.VenueID.ToString();
                    ddVenueDetails.Items.Add(lst);
                }
            }
            catch
            {

            }
        }

        private void GetEventType()
        {
            List<EventTypeModel> _EventTypeModel = new List<EventTypeModel>();
           

            EventTypeViewModel _eventTypeViewModel = new EventTypeViewModel();
           
            _EventTypeModel = _eventTypeViewModel.GetEventType();

           foreach (var item in _EventTypeModel)
           {
               ListItem lst = new ListItem();
               lst.Text = item.EventType;
               lst.Value = item.EventTypeID.ToString();
               ddEventType.Items.Add(lst);
           }
         

           _EventTypeModel = null;
         
           _eventTypeViewModel = null;
        }

        public void GetEventSubType(int EventID)
        {
            ddEvebtSubType.Items.Clear();
            List<EventSubTypeModel> _eventSubTypeModel = new List<EventSubTypeModel>();

            EventTypeViewModel _eventTypeViewModel = new EventTypeViewModel();
            _eventSubTypeModel = _eventTypeViewModel.GetEventSubType(EventID);

            foreach (var item in _eventSubTypeModel)
            {
                ListItem lst = new ListItem();
                lst.Text = item.EventSubTypeDesc;
                lst.Value = item.EventSubTypeID.ToString();
                ddEvebtSubType.Items.Add(lst);
            }

          
            _eventSubTypeModel = null;
            _eventTypeViewModel = null;
        }        

        protected void ddEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEventSubType(Convert.ToInt32(ddEventType.SelectedItem.Value));
        }

        private void ClearAllControl()
        {
            txtEventTitle.Value = "";
            txtEventDesc.Value = "";
            txtArtist.Value ="";
            txtGenre.Value = "";
            txtEventDate.Value = "";
            txtFromTime.Value = "";
            txtTotTime.Value = "";

            txtTicketType1.Value = "";
            txtTicketType2.Value = "";
            txtTicketType3.Value = "";
            txtTicketType4.Value = "";
            
            txtTotalSeat1.Value = "" ;
            txtTotalSeat2.Value = "" ;
            txtTotalSeat3.Value = "" ;
            txtTotalSeat4.Value = "";
            
            txtTicketPrice1.Value = "" ;
            txtTicketPrice2.Value = "" ;
            txtTicketPrice3.Value = "" ;
            txtTicketPrice4.Value = "";

        }

        private void EditEventDetails(string EventSPID)
        {
            EventsEntryPageViewModel eventsEntryPageViewModel = new EventsEntryPageViewModel();
            EventMasterModel _eventMasterModel = new EventMasterModel();

            _eventMasterModel = eventsEntryPageViewModel.GetEventDetails(EventSPID);

            if (_eventMasterModel != null)
            {
                txtEventTitle.Value = _eventMasterModel.EventTitle;
                txtEventDesc.Value = _eventMasterModel.EventDesc;
                txtArtist.Value = _eventMasterModel.Artists;
                txtGenre.Value = _eventMasterModel.Genre;
                txtEventDate.Value = _eventMasterModel.EventDate;
                ddEventType.SelectedValue= _eventMasterModel.EventTypeID;
                GetEventSubType(Convert.ToInt32(_eventMasterModel.EventTypeID));
                
                img_prev.Src = _eventMasterModel.ImagePath;
                imgSmallImg.Src = _eventMasterModel.SmallImagePath;
                ImgTicketImage.Src = _eventMasterModel.EventLayout;
                
                ddEvebtSubType.SelectedValue = _eventMasterModel.EventSubtypeID;
                ddVenueDetails.SelectedValue = _eventMasterModel.VenueID;
                hdEventID.Value = _eventMasterModel.EventID;

                hdImagePath.Value = _eventMasterModel.ImagePath;
                hdEventImagePath.Value = _eventMasterModel.SmallImagePath;
                hdTicketImagePath.Value = _eventMasterModel.EventLayout;

                txtEventDate.Value = Convert.ToDateTime(_eventMasterModel.EventDate).ToString("dd/MMM/yyyy");
            }

            EventTimeDetailsModel _eventTimeDetailsModel = new EventTimeDetailsModel();
            _eventTimeDetailsModel = eventsEntryPageViewModel.GetEventTimeDetails(EventSPID);

            if (_eventTimeDetailsModel != null)
            {
                txtFromTime.Value = _eventTimeDetailsModel.EventFromTime.ToString("HH:mm");
                txtTotTime.Value = _eventTimeDetailsModel.EventToTime.ToString("HH:mm");
                EventTimeID.Value = _eventTimeDetailsModel.EventTimeID.ToString();
            }


            List<EventPriceDetailsModel> _eventPriceDetailsModel = new List<EventPriceDetailsModel>();
            _eventPriceDetailsModel = eventsEntryPageViewModel.GetEventPriceDetails(EventSPID);


            int i = 1;

            if (_eventPriceDetailsModel != null)
            {
                foreach (var item in _eventPriceDetailsModel)
                {
                    if (i == 1)
                    {
                        EPID1.Value = item.EventPriceID;
                        txtTicketType1.Value = item.EventPriceDetails;
                        txtTotalSeat1.Value = item.EventTotalSeat.ToString();
                        txtTicketPrice1.Value = item.EventPrice;
                    }

                    if (i == 2)
                    {
                        EPID2.Value = item.EventPriceID;
                        txtTicketType2.Value = item.EventPriceDetails;
                        txtTotalSeat2.Value = item.EventTotalSeat.ToString();
                        txtTicketPrice2.Value = item.EventPrice;
                    }

                    if (i == 3)
                    {
                        EPID3.Value = item.EventPriceID;
                        txtTicketType3.Value = item.EventPriceDetails;
                        txtTotalSeat3.Value = item.EventTotalSeat.ToString();
                        txtTicketPrice3.Value = item.EventPrice;
                    }

                    if (i == 4)
                    {
                        EPID4.Value = item.EventPriceID;
                        txtTicketType4.Value = item.EventPriceDetails;
                        txtTotalSeat4.Value = item.EventTotalSeat.ToString();
                        txtTicketPrice4.Value = item.EventPrice;
                    }

                    i++;
                }    
            }

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            if (ValidatePage() == true)
            {
                string s = filenm.Value;
                string[] file;
                string ext = "";

                if (s == "")
                {
                    file = hdImagePath.Value.Split('.');
                }
                else
                {
                    file = s.Split('.');

                }

                string t = file[file.Length - 1].ToString();
                var r = new Random();
                string d = hdEventID.Value;
                ext = d;
                string baseImageLocation = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection files = Request.Files;
                HttpPostedFile httpPostedFile = files["filenm"];
                string fileExt = Path.GetExtension(httpPostedFile.FileName).ToLower();
                string fileName = Path.GetFileName(httpPostedFile.FileName);


                #region SmallImagePath

                string sm = filesmallimage.Value;
                string[] filesm;
                string extsm = "";
                string dsm = "S" + hdEventID.Value;

                if (sm == "")
                {
                    filesm = hdEventImagePath.Value.Split('.');
                }
                else
                {
                    filesm = sm.Split('.');                   
                }

                string tsm = filesm[filesm.Length - 1].ToString();
                r = new Random();
               
                extsm = dsm;
                string baseImageLocationsm = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection filessm = Request.Files;
                HttpPostedFile httpPostedFilesm = filessm["filesmallimage"];
                string fileExtsm = Path.GetExtension(httpPostedFilesm.FileName).ToLower();
                string fileNamesm = Path.GetFileName(httpPostedFilesm.FileName);

                #endregion


                #region TicketImage

                string sTm = filebackgroundimage.Value;
                string[] filesTm;
                string extsTm = "";
                string dsTm = "T" + hdEventID.Value;

                if (sTm == "")
                {
                    filesTm = hdTicketImagePath.Value.Split('.');
                }
                else
                {
                    filesTm = sTm.Split('.');
                }

                string tTm = filesTm[filesTm.Length - 1].ToString();
                r = new Random();
               
                extsTm = dsTm;
                string baseImageLocationsTm = Server.MapPath("~\\ShowlineImages\\");
                HttpFileCollection filessTm = Request.Files;
                HttpPostedFile httpPostedFilesTm = filessTm["filebackgroundimage"];
                string fileExtsTm = Path.GetExtension(httpPostedFilesTm.FileName).ToLower();
                string fileNamesTm = Path.GetFileName(httpPostedFilesTm.FileName);


                #endregion



                EventsEntryPageViewModel _eventMasterDAL = new EventsEntryPageViewModel();
                EventMasterModel eventMasterModel = new EventMasterModel();
                List<EventTimeDetailsModel> eventTimeDetailsModel = new List<EventTimeDetailsModel>();

                List<EventPriceDetailsModel> eventPriceDetailsModel = new List<EventPriceDetailsModel>();

                eventMasterModel.EventTypeID = ddEventType.SelectedItem.Value;
                eventMasterModel.EventSubtypeID = ddEvebtSubType.SelectedItem.Value.ToString();
                eventMasterModel.VenueID = ddVenueDetails.SelectedItem.Value;
                eventMasterModel.EventTitle = txtEventTitle.Value.Trim();
                eventMasterModel.EventDesc = txtEventDesc.Value.Trim();
                eventMasterModel.Artists = txtArtist.Value.Trim();
                eventMasterModel.Genre = txtGenre.Value.Trim();
                eventMasterModel.ImagePath = "/ShowlineImages/" + ext + "." + file[file.Length - 1].ToString();
                eventMasterModel.SmallImagePath = "/ShowlineImages/" + extsm + "." + filesm[filesm.Length - 1].ToString();
                eventMasterModel.EventLayout = "/ShowlineImages/" + extsTm + "." + filesTm[filesTm.Length - 1].ToString();
                eventMasterModel.EventID = ext;
                eventMasterModel.EventDate = txtEventDate.Value;

                eventTimeDetailsModel.Add(new EventTimeDetailsModel
                {
                    EventFromTime = Convert.ToDateTime(txtEventDate.Value + " " + txtFromTime.Value),
                    EventToTime = Convert.ToDateTime(txtEventDate.Value + " " + txtTotTime.Value)
                });

                if (txtTicketType1.Value.Trim() != "" || txtTotalSeat1.Value.Trim() != "" || txtTicketPrice1.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType1.Value.Trim(), EventPrice = txtTicketPrice1.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat1.Value.Trim()) });
                }

                if (txtTicketType2.Value.Trim() != "" || txtTotalSeat2.Value.Trim() != "" || txtTicketPrice2.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType2.Value.Trim(), EventPrice = txtTicketPrice2.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat2.Value.Trim()) });
                }

                if (txtTicketType3.Value.Trim() != "" || txtTotalSeat3.Value.Trim() != "" || txtTicketPrice3.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType3.Value.Trim(), EventPrice = txtTicketPrice3.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat3.Value.Trim()) });
                }

                if (txtTicketType4.Value.Trim() != "" || txtTotalSeat4.Value.Trim() != "" || txtTicketPrice4.Value.Trim() != "")
                {
                    eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType4.Value.Trim(), EventPrice = txtTicketPrice4.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat4.Value.Trim()) });
                }

                if (_eventMasterDAL.DeleteEventDetails(hdEventID.Value) == true)
                {

                    if (_eventMasterDAL.InsertEventMaster(eventMasterModel, eventTimeDetailsModel, eventPriceDetailsModel) == true)
                    {
                        if (fileName != "")
                        {
                            httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                        }

                        if (fileNamesm != "")
                        {
                            httpPostedFilesm.SaveAs(baseImageLocation + extsm + "." + filesm[filesm.Length - 1].ToString());
                        }

                        if (fileNamesTm != "")
                        {
                            httpPostedFilesTm.SaveAs(baseImageLocation + extsTm + "." + filesTm[filesTm.Length - 1].ToString());
                        }
                        
                        ClearAllControl();

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Saved Sucessfully.','Add Event Details');</script>", false);
                        //Response.Redirect("~/viewevent.aspx");//-kk redirect
                            Response.Redirect("~/viewevent.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                }

            }
        }
    }
}
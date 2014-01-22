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
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["SVenue"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='SessionExpire.aspx'", true);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetVenueDetails();
                    GetEventType();

                    if (Request.QueryString["EO"] != null)
                    {
                        EditEventDetails(Request.QueryString["EO"]);
                        LockTextBox("true");
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                    }
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

                    string sm = filesmallimage.Value;
                    string[] filesm = sm.Split('.');
                    string tsm = filesm[filesm.Length - 1].ToString();
                    string extSM = "";

                    string dsm = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                    extSM = "S" + dsm;

                    string baseImageLocationsm = Server.MapPath("~\\ShowlineImages\\");
                    HttpFileCollection filessm = Request.Files;
                    HttpPostedFile httpPostedFilesm = filessm["filesmallimage"];
                    string fileExtsm = Path.GetExtension(httpPostedFilesm.FileName).ToLower();
                    string fileNamesm = Path.GetFileName(httpPostedFilesm.FileName);

                    // TICKET IMAGE

                    string sTm = filebackgroundimage.Value;
                    string[] filesTm = sTm.Split('.');
                    string tsTm = filesTm[filesTm.Length - 1].ToString();
                    string extSTM = "";

                    string dsTm = DateTime.Now.ToString("ddMMyyhhmmss") + r.Next(100);
                    extSTM = "T" + dsTm;

                    string baseImageLocationsTm = Server.MapPath("~\\ShowlineImages\\");
                    HttpFileCollection filessTm = Request.Files;
                    HttpPostedFile httpPostedFilesTm = filessTm["filebackgroundimage"];
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
                            EventFromTime = Convert.ToDateTime(txtFromTime.Value),
                            EventToTime = Convert.ToDateTime(txtTotTime.Value)
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

                    if (txtTicketType5.Value.Trim() != "" || txtTotalSeat5.Value.Trim() != "" || txtTicketPrice5.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType5.Value.Trim(), EventPrice = txtTicketPrice5.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat5.Value.Trim()) });
                    }

                    if (txtTicketType6.Value.Trim() != "" || txtTotalSeat6.Value.Trim() != "" || txtTicketPrice6.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType6.Value.Trim(), EventPrice = txtTicketPrice6.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat6.Value.Trim()) });
                    }

                    if (txtTicketType7.Value.Trim() != "" || txtTotalSeat7.Value.Trim() != "" || txtTicketPrice7.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType7.Value.Trim(), EventPrice = txtTicketPrice7.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat7.Value.Trim()) });
                    }

                    if (txtTicketType8.Value.Trim() != "" || txtTotalSeat8.Value.Trim() != "" || txtTicketPrice8.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType8.Value.Trim(), EventPrice = txtTicketPrice8.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat8.Value.Trim()) });
                    }

                    if (txtTicketType9.Value.Trim() != "" || txtTotalSeat9.Value.Trim() != "" || txtTicketPrice9.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType9.Value.Trim(), EventPrice = txtTicketPrice9.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat9.Value.Trim()) });
                    }

                    if (txtTicketType10.Value.Trim() != "" || txtTotalSeat10.Value.Trim() != "" || txtTicketPrice10.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType10.Value.Trim(), EventPrice = txtTicketPrice10.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat10.Value.Trim()) });
                    }

                    if (txtTicketType11.Value.Trim() != "" || txtTotalSeat11.Value.Trim() != "" || txtTicketPrice11.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType11.Value.Trim(), EventPrice = txtTicketPrice11.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat11.Value.Trim()) });
                    }

                    if (txtTicketType12.Value.Trim() != "" || txtTotalSeat12.Value.Trim() != "" || txtTicketPrice12.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType12.Value.Trim(), EventPrice = txtTicketPrice12.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat12.Value.Trim()) });
                    }

                    if (txtTicketType13.Value.Trim() != "" || txtTotalSeat13.Value.Trim() != "" || txtTicketPrice13.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType13.Value.Trim(), EventPrice = txtTicketPrice13.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat13.Value.Trim()) });
                    }

                    if (txtTicketType14.Value.Trim() != "" || txtTotalSeat14.Value.Trim() != "" || txtTicketPrice14.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType14.Value.Trim(), EventPrice = txtTicketPrice14.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat14.Value.Trim()) });
                    }

                    if (txtTicketType15.Value.Trim() != "" || txtTotalSeat15.Value.Trim() != "" || txtTicketPrice15.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType15.Value.Trim(), EventPrice = txtTicketPrice15.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat15.Value.Trim()) });
                    }


                    if (_eventMasterDAL.InsertEventMaster(eventMasterModel, eventTimeDetailsModel, eventPriceDetailsModel) == true)
                    {
                        if (fileName != "")
                        {
                            httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                        }

                        if (fileNamesm != "")
                        {
                            httpPostedFilesm.SaveAs(baseImageLocationsm + extSM + "." + filesm[filesm.Length - 1].ToString());
                        }


                        if (fileExtsTm != "")
                        {
                            httpPostedFilesTm.SaveAs(baseImageLocationsTm + extSTM + "." + filesTm[filesTm.Length - 1].ToString());
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
        
        private bool ValidatePage()
        {
            try
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

                if (txtTicketType1.Value == "" && txtTicketType2.Value == "" && txtTicketType3.Value == "" && txtTicketType4.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter Ticket Details.','Add Event Details: Validation','txtTicketType1');</script>", false);
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

                if (filenm.Value == "" && hdImagePath.Value == "")
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
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat2');</script>", false);
                    }
                }

                if (txtTotalSeat3.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat3.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat3');</script>", false);
                    }
                }

                if (txtTotalSeat4.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat4.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat4');</script>", false);
                    }
                }

                if (txtTotalSeat5.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat5.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat5');</script>", false);
                    }
                }

                if (txtTotalSeat6.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat6.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat6');</script>", false);
                    }
                }

                if (txtTotalSeat7.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat7.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat7');</script>", false);
                    }
                }

                if (txtTotalSeat8.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat8.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat8');</script>", false);
                    }
                }

                if (txtTotalSeat9.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat9.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat9');</script>", false);
                    }
                }

                if (txtTotalSeat10.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat10.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat10');</script>", false);
                    }
                }

                if (txtTotalSeat11.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat11.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat11');</script>", false);
                    }
                }

                if (txtTotalSeat12.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat12.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat12');</script>", false);
                    }
                }

                if (txtTotalSeat13.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat13.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat13');</script>", false);
                    }
                }

                if (txtTotalSeat14.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat14.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat14');</script>", false);
                    }
                }

                if (txtTotalSeat15.Value != "")
                {
                    isNum = Int32.TryParse(txtTotalSeat15.Value, out NumInt);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Seat details.','Add Event Details: Validation','txtTotalSeat15');</script>", false);
                    }
                }


                if (txtTicketPrice1.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice1.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice1');</script>", false);
                    }
                }

                if (txtTicketPrice2.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice2.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice2');</script>", false);
                    }
                }

                if (txtTicketPrice3.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice3.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice3');</script>", false);
                    }
                }

                if (txtTicketPrice4.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice4.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice4');</script>", false);
                    }
                }

                if (txtTicketPrice5.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice5.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice5');</script>", false);
                    }
                }

                if (txtTicketPrice6.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice6.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice6');</script>", false);
                    }
                }

                if (txtTicketPrice7.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice7.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice7');</script>", false);
                    }
                }

                if (txtTicketPrice8.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice8.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice8');</script>", false);
                    }
                }

                if (txtTicketPrice9.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice9.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice9');</script>", false);
                    }
                }

                if (txtTicketPrice10.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice10.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice10');</script>", false);
                    }
                }

                if (txtTicketPrice11.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice11.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice11');</script>", false);
                    }
                }

                if (txtTicketPrice12.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice12.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice12');</script>", false);
                    }
                }

                if (txtTicketPrice13.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice13.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice13');</script>", false);
                    }
                }

                if (txtTicketPrice14.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice14.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice14');</script>", false);
                    }
                }

                if (txtTicketPrice15.Value != "")
                {
                    isNum = double.TryParse(txtTicketPrice15.Value, out Num);

                    if (!isNum)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter valid Ticket Price details.','Add Event Details: Validation','txtTicketPrice15');</script>", false);
                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Error : " + ex.Message + "')");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", sb.ToString(), false);

                return false;
            }
        }

        protected void GetVenueDetails()
        {
            try
            {
                List<VenueDetailsModel> _venueDetails = new List<VenueDetailsModel>();
                VenueDetailsModel _VenueDetailsModel = new VenueDetailsModel();
 
                VenueDetailsViewModel venueList = new VenueDetailsViewModel();

                //TODO
                if (Convert.ToInt32(Session["SVenue"].ToString()) == 0)
                {
                    _venueDetails = venueList.GetVenueDetails();

                    foreach (var item in _venueDetails)
                    {
                    ListItem lst = new ListItem();
                    lst.Text = item.VenueName;
                    lst.Value = item.VenueID.ToString();
                    ddVenueDetails.Items.Add(lst);
                    }

                }
                else
                {
                    _VenueDetailsModel = venueList.GetVenueDetailsByID(Session["SVenue"].ToString());

                    ListItem lst = new ListItem();
                    lst.Text = _VenueDetailsModel.VenueName;
                    lst.Value = _VenueDetailsModel.VenueID.ToString();
                    ddVenueDetails.Items.Add(lst);
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

        private void GetEventType()
        {
            try
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

        public void GetEventSubType(int EventID)
        {
            try
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

        protected void ddEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetEventSubType(Convert.ToInt32(ddEventType.SelectedItem.Value));
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

        private void ClearAllControl()
        {
            try
            {
                txtEventTitle.Value = "";
                txtEventDesc.Value = "";
                txtArtist.Value = "";
                txtGenre.Value = "";
                txtEventDate.Value = "";
                txtFromTime.Value = "";
                txtTotTime.Value = "";

                txtTicketType1.Value = "";
                txtTicketType2.Value = "";
                txtTicketType3.Value = "";
                txtTicketType4.Value = "";
                txtTicketType5.Value = "";
                txtTicketType6.Value = "";
                txtTicketType7.Value = "";
                txtTicketType8.Value = "";
                txtTicketType9.Value = "";
                txtTicketType10.Value = "";
                txtTicketType11.Value = "";
                txtTicketType12.Value = "";
                txtTicketType13.Value = "";
                txtTicketType14.Value = "";
                txtTicketType15.Value = "";

                txtTotalSeat1.Value = "";
                txtTotalSeat2.Value = "";
                txtTotalSeat3.Value = "";
                txtTotalSeat4.Value = "";
                txtTotalSeat5.Value = "";
                txtTotalSeat6.Value = "";
                txtTotalSeat7.Value = "";
                txtTotalSeat8.Value = "";
                txtTotalSeat9.Value = "";
                txtTotalSeat10.Value = "";
                txtTotalSeat11.Value = "";
                txtTotalSeat12.Value = "";
                txtTotalSeat13.Value = "";
                txtTotalSeat14.Value = "";
                txtTotalSeat15.Value = "";

                txtTicketPrice1.Value = "";
                txtTicketPrice2.Value = "";
                txtTicketPrice3.Value = "";
                txtTicketPrice4.Value = "";
                txtTicketPrice5.Value = "";
                txtTicketPrice6.Value = "";
                txtTicketPrice7.Value = "";
                txtTicketPrice8.Value = "";
                txtTicketPrice9.Value = "";
                txtTicketPrice10.Value = "";
                txtTicketPrice11.Value = "";
                txtTicketPrice12.Value = "";
                txtTicketPrice13.Value = "";
                txtTicketPrice14.Value = "";
                txtTicketPrice15.Value = "";

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

        private void EditEventDetails(string EventSPID)
        {
            try
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
                    ddEventType.SelectedValue = _eventMasterModel.EventTypeID;
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

                        if (i == 5)
                        {
                            EPID5.Value = item.EventPriceID;
                            txtTicketType5.Value = item.EventPriceDetails;
                            txtTotalSeat5.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice5.Value = item.EventPrice;
                        }

                        if (i == 6)
                        {
                            EPID6.Value = item.EventPriceID;
                            txtTicketType6.Value = item.EventPriceDetails;
                            txtTotalSeat6.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice6.Value = item.EventPrice;
                        }

                        if (i == 7)
                        {
                            EPID7.Value = item.EventPriceID;
                            txtTicketType7.Value = item.EventPriceDetails;
                            txtTotalSeat7.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice7.Value = item.EventPrice;
                        }

                        if (i == 8)
                        {
                            EPID8.Value = item.EventPriceID;
                            txtTicketType8.Value = item.EventPriceDetails;
                            txtTotalSeat8.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice8.Value = item.EventPrice;
                        }

                        if (i == 9)
                        {
                            EPID9.Value = item.EventPriceID;
                            txtTicketType9.Value = item.EventPriceDetails;
                            txtTotalSeat9.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice9.Value = item.EventPrice;
                        }

                        if (i == 10)
                        {
                            EPID10.Value = item.EventPriceID;
                            txtTicketType10.Value = item.EventPriceDetails;
                            txtTotalSeat10.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice10.Value = item.EventPrice;
                        }

                        if (i == 11)
                        {
                            EPID11.Value = item.EventPriceID;
                            txtTicketType11.Value = item.EventPriceDetails;
                            txtTotalSeat11.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice11.Value = item.EventPrice;
                        }

                        if (i == 12)
                        {
                            EPID12.Value = item.EventPriceID;
                            txtTicketType12.Value = item.EventPriceDetails;
                            txtTotalSeat12.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice12.Value = item.EventPrice;
                        }

                        if (i == 13)
                        {
                            EPID13.Value = item.EventPriceID;
                            txtTicketType13.Value = item.EventPriceDetails;
                            txtTotalSeat13.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice13.Value = item.EventPrice;
                        }

                        if (i == 14)
                        {
                            EPID14.Value = item.EventPriceID;
                            txtTicketType14.Value = item.EventPriceDetails;
                            txtTotalSeat14.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice14.Value = item.EventPrice;
                        }

                        if (i == 15)
                        {
                            EPID15.Value = item.EventPriceID;
                            txtTicketType15.Value = item.EventPriceDetails;
                            txtTotalSeat15.Value = item.EventTotalSeat.ToString();
                            txtTicketPrice15.Value = item.EventPrice;
                        }

                        i++;
                    }
                }

                btnSave.Visible = false;
                btnUpdate.Visible = true;
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

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            try
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
                    string dsm = "S" + hdEventID.Value.Substring(1, hdEventID.Value.Length - 1);

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
                    string dsTm = "T" + hdEventID.Value.Substring(1, hdEventID.Value.Length - 1);

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
                        EventFromTime = Convert.ToDateTime(txtFromTime.Value),
                        EventToTime = Convert.ToDateTime(txtTotTime.Value)
                        //EventFromTime = Convert.ToDateTime(txtEventDate.Value + " " + txtFromTime.Value),
                        //EventToTime = Convert.ToDateTime(txtEventDate.Value + " " + txtTotTime.Value)
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

                    if (txtTicketType5.Value.Trim() != "" || txtTotalSeat5.Value.Trim() != "" || txtTicketPrice5.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType5.Value.Trim(), EventPrice = txtTicketPrice5.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat5.Value.Trim()) });
                    }

                    if (txtTicketType6.Value.Trim() != "" || txtTotalSeat6.Value.Trim() != "" || txtTicketPrice6.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType6.Value.Trim(), EventPrice = txtTicketPrice6.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat6.Value.Trim()) });
                    }

                    if (txtTicketType7.Value.Trim() != "" || txtTotalSeat7.Value.Trim() != "" || txtTicketPrice7.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType7.Value.Trim(), EventPrice = txtTicketPrice7.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat7.Value.Trim()) });
                    }

                    if (txtTicketType8.Value.Trim() != "" || txtTotalSeat8.Value.Trim() != "" || txtTicketPrice8.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType8.Value.Trim(), EventPrice = txtTicketPrice8.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat8.Value.Trim()) });
                    }

                    if (txtTicketType9.Value.Trim() != "" || txtTotalSeat9.Value.Trim() != "" || txtTicketPrice9.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType9.Value.Trim(), EventPrice = txtTicketPrice9.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat9.Value.Trim()) });
                    }

                    if (txtTicketType10.Value.Trim() != "" || txtTotalSeat10.Value.Trim() != "" || txtTicketPrice10.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType10.Value.Trim(), EventPrice = txtTicketPrice10.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat10.Value.Trim()) });
                    }

                    if (txtTicketType11.Value.Trim() != "" || txtTotalSeat11.Value.Trim() != "" || txtTicketPrice11.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType11.Value.Trim(), EventPrice = txtTicketPrice11.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat11.Value.Trim()) });
                    }

                    if (txtTicketType12.Value.Trim() != "" || txtTotalSeat12.Value.Trim() != "" || txtTicketPrice12.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType12.Value.Trim(), EventPrice = txtTicketPrice12.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat12.Value.Trim()) });
                    }

                    if (txtTicketType13.Value.Trim() != "" || txtTotalSeat13.Value.Trim() != "" || txtTicketPrice13.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType13.Value.Trim(), EventPrice = txtTicketPrice13.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat13.Value.Trim()) });
                    }

                    if (txtTicketType14.Value.Trim() != "" || txtTotalSeat14.Value.Trim() != "" || txtTicketPrice14.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType14.Value.Trim(), EventPrice = txtTicketPrice14.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat14.Value.Trim()) });
                    }

                    if (txtTicketType15.Value.Trim() != "" || txtTotalSeat15.Value.Trim() != "" || txtTicketPrice15.Value.Trim() != "")
                    {
                        eventPriceDetailsModel.Add(new EventPriceDetailsModel { EventPriceDetails = txtTicketType15.Value.Trim(), EventPrice = txtTicketPrice15.Value.Trim(), EventTotalSeat = Convert.ToInt32(txtTotalSeat15.Value.Trim()) });
                    }


                    if (_eventMasterDAL.UpdateEventMaster(eventMasterModel, eventTimeDetailsModel) == true)
                    {
                        if (fileName != "")
                        {
                            //FileInfo fileInfoPath = new FileInfo(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                            //if (fileInfoPath.Exists)
                            //{
                            //    fileInfoPath.Delete();
                            //}

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
                        Response.Redirect("~/viewevent.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    }


                    //if (_eventMasterDAL.DeleteEventDetails(hdEventID.Value) == true)
                    //{

                    //    if (_eventMasterDAL.InsertEventMaster(eventMasterModel, eventTimeDetailsModel, eventPriceDetailsModel) == true)
                    //    {
                    //        if (fileName != "")
                    //        {
                    //            httpPostedFile.SaveAs(baseImageLocation + ext + "." + file[file.Length - 1].ToString());
                    //        }

                    //        if (fileNamesm != "")
                    //        {
                    //            httpPostedFilesm.SaveAs(baseImageLocation + extsm + "." + filesm[filesm.Length - 1].ToString());
                    //        }

                    //        if (fileNamesTm != "")
                    //        {
                    //            httpPostedFilesTm.SaveAs(baseImageLocation + extsTm + "." + filesTm[filesTm.Length - 1].ToString());
                    //        }

                    //        ClearAllControl();

                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ConfirmMsg('Event Saved Sucessfully.','Add Event Details');</script>", false);
                    //        //Response.Redirect("~/viewevent.aspx"); //kk redirect
                    //        Response.Redirect("~/viewevent.aspx", false);
                    //        Context.ApplicationInstance.CompleteRequest();

                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    //    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Details", "<script type='text/javascript'>ErrorMsg('Unexpected error occured.Plese refresh the page and try again!','Add Event Details');</script>", false);
                    //}

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

        protected void LockTextBox(string blnValue)
        {
            txtTicketPrice1.Attributes.Add("readonly", blnValue);
            txtTicketPrice2.Attributes.Add("readonly", blnValue);
            txtTicketPrice3.Attributes.Add("readonly", blnValue);
            txtTicketPrice4.Attributes.Add("readonly", blnValue);
            txtTicketPrice5.Attributes.Add("readonly", blnValue);
            txtTicketPrice6.Attributes.Add("readonly", blnValue);
            txtTicketPrice7.Attributes.Add("readonly", blnValue);
            txtTicketPrice8.Attributes.Add("readonly", blnValue);
            txtTicketPrice9.Attributes.Add("readonly", blnValue);
            txtTicketPrice10.Attributes.Add("readonly", blnValue);
            txtTicketPrice11.Attributes.Add("readonly", blnValue);
            txtTicketPrice12.Attributes.Add("readonly", blnValue);
            txtTicketPrice13.Attributes.Add("readonly", blnValue);
            txtTicketPrice14.Attributes.Add("readonly", blnValue);
            txtTicketPrice15.Attributes.Add("readonly", blnValue);

            txtTicketType1.Attributes.Add("readonly", blnValue);
            txtTicketType2.Attributes.Add("readonly", blnValue);
            txtTicketType3.Attributes.Add("readonly", blnValue);
            txtTicketType4.Attributes.Add("readonly", blnValue);
            txtTicketType5.Attributes.Add("readonly", blnValue);
            txtTicketType6.Attributes.Add("readonly", blnValue);
            txtTicketType7.Attributes.Add("readonly", blnValue);
            txtTicketType8.Attributes.Add("readonly", blnValue);
            txtTicketType9.Attributes.Add("readonly", blnValue);
            txtTicketType10.Attributes.Add("readonly", blnValue);
            txtTicketType11.Attributes.Add("readonly", blnValue);
            txtTicketType12.Attributes.Add("readonly", blnValue);
            txtTicketType13.Attributes.Add("readonly", blnValue);
            txtTicketType14.Attributes.Add("readonly", blnValue);
            txtTicketType15.Attributes.Add("readonly", blnValue);

            txtTotalSeat1.Attributes.Add("readonly", blnValue);
            txtTotalSeat2.Attributes.Add("readonly", blnValue);
            txtTotalSeat3.Attributes.Add("readonly", blnValue);
            txtTotalSeat4.Attributes.Add("readonly", blnValue);
            txtTotalSeat5.Attributes.Add("readonly", blnValue);
            txtTotalSeat6.Attributes.Add("readonly", blnValue);
            txtTotalSeat7.Attributes.Add("readonly", blnValue);
            txtTotalSeat8.Attributes.Add("readonly", blnValue);
            txtTotalSeat9.Attributes.Add("readonly", blnValue);
            txtTotalSeat10.Attributes.Add("readonly", blnValue);
            txtTotalSeat11.Attributes.Add("readonly", blnValue);
            txtTotalSeat12.Attributes.Add("readonly", blnValue);
            txtTotalSeat13.Attributes.Add("readonly", blnValue);
            txtTotalSeat14.Attributes.Add("readonly", blnValue);
            txtTotalSeat15.Attributes.Add("readonly", blnValue);

        }
    }
}
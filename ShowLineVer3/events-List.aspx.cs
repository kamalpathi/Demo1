using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;
using ShowLineVer3.ShowLineServiceReference;

namespace ShowLineSite
{
    public partial class events_List : System.Web.UI.Page
    {
        string EID;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
#if DEBUG
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);
#else
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);
#endif
            }

            if (Session["SessVal"] != null)
            {
                if (Session["SessVal"].ToString() == "0")
                {
#if DEBUG
                     this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);
#else
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);
#endif
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            ViewState["update"] = Session["update"];
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EID = Request.QueryString["ID"].ToString();
                //string ETitle = Request.QueryString["EN"].ToString();
                
                if (!IsPostBack)
                {
                    //if (Request.QueryString["EN"] != null)
                    //{
                    //    Page.Title ="ShowsLine - " + Request.QueryString["EN"].ToString() + " at Spin Nightclub";
                    //}
                    //else
                    //{
                    //    Page.Title = "Showsline";
                    //}
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString()); // Assign the Session["update"] with unique value 
                    GetEventDetails(EID);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected void GetEventListing()
        {
            try
            {
                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                _eventListingModel = _eventListingViewModel.GetEventListing();
                int cnt = 1;


                foreach (var item in _eventListingModel)
                {
                    //phQuickBook.Controls.Add(new LiteralControl("<li style='color:white;'>"));
                    //LinkButton lb = new LinkButton();
                    //lb.Text = item.EventTitle;
                    //lb.ForeColor = Color.FromArgb(119, 135, 142);
                    //lb.PostBackUrl = "events-List.aspx?ID=" + item.EventID + "&EN=" + item.EventTitle;
                    //phQuickBook.Controls.Add(lb);
                    //phQuickBook.Controls.Add(new LiteralControl("</li>"));    


                    //phSlideShow.Controls.Add(new LiteralControl("<div>"));
                    //phSlideShow.Controls.Add(new LiteralControl("<a title='' href='#'>"));
                    //phSlideShow.Controls.Add(new LiteralControl("<img class='pic' src='" + item.ImagePath + "' style='width:100%' />"));
                    //phSlideShow.Controls.Add(new LiteralControl("</a>"));
                    //phSlideShow.Controls.Add(new LiteralControl("<p>"));
                    //if (item.EventDesc.Length < 100)
                    //{
                    //    phSlideShow.Controls.Add(new LiteralControl("<strong>" + item.EventDesc + "</strong>"));
                    //}
                    //else
                    //{
                    //    phSlideShow.Controls.Add(new LiteralControl("<strong>" + item.EventDesc.Substring(0, 150) + "..." + "</strong>"));
                    //}
                    //phSlideShow.Controls.Add(new LiteralControl("<br/>"));
                    //phSlideShow.Controls.Add(new LiteralControl("</p>"));
                    //phSlideShow.Controls.Add(new LiteralControl("</div>"));


                    //if (cnt <= 4)
                    //{
                    //    phTitle.Controls.Add(new LiteralControl("<li>"));
                    //    phTitle.Controls.Add(new LiteralControl("<a href='#'>" + item.EventTitle + "<br/>"));
                    //    phTitle.Controls.Add(new LiteralControl(item.EventDate.ToString("dd/MMM/yyyy") + "<br/>"));
                    //    phTitle.Controls.Add(new LiteralControl("</a></li>"));
                    //}



                    //phSubMenuEvent.Controls.Add(new LiteralControl("<li>"));
                    //phSubMenuEvent.Controls.Add(new LiteralControl("<a href='#'>"));
                    //phSubMenuEvent.Controls.Add(new LiteralControl("<img src='" + item.ImagePath + "' width='124' height='180' alt='tag'/>"));
                    //phSubMenuEvent.Controls.Add(new LiteralControl("</a></li>"));


                    //if (cnt <= 4)
                    //{
                    //    phFeaturedShow.Controls.Add(new LiteralControl("<li><a title='" + item.EventTitle + "' href='events-List.aspx?ID=" + item.EventID + "&EN=" + item.EventTitle + "'>" + item.EventTitle + "</a>"));
                    //    phFeaturedShow.Controls.Add(new LiteralControl("<ul>"));

                    //    if (item.EventDesc.Length > 100)
                    //    {
                    //        phFeaturedShow.Controls.Add(new LiteralControl("<li>" + item.EventDesc.Substring(0, 100) + "..."));
                    //    }
                    //    else
                    //    {
                    //        phFeaturedShow.Controls.Add(new LiteralControl("<li>" + item.EventDesc));
                    //    }
                    //    phFeaturedShow.Controls.Add(new LiteralControl("</ul></li>"));
                    //}


                    //if (cnt < 4)
                    //{
                    //    //phContent.Controls.Add(new LiteralControl("<h3>" + item.EventTitle + "  <span style='color:red;'>" + item.EventDate.ToString("dd/MMM/yyyy") + "</span></h3>"));
                    //    phContent.Controls.Add(new LiteralControl("<h3><a title='" + item.EventTitle + "' href='events-List.aspx?ID=" + item.EventID + "&EN=" + item.EventTitle + "'>" + item.EventTitle + " </a><span style='color:red;'>" + item.EventDate.ToString("dd/MMM/yyyy") + "</span></h3>"));

                    //    phContent.Controls.Add(new LiteralControl("<p><a title='" + item.EventTitle + "' href='events-List.aspx?ID=" + item.EventID + "&EN=" + item.EventTitle + "'><img src='" + item.ImagePath + "'  width='75' height='75' alt='tag'/></a>" + item.EventDesc));
                    //    phContent.Controls.Add(new LiteralControl("</p>"));
                    //    //phContent.Controls.Add(new LiteralControl("<p>" + item.EventDate.ToString("dd/MMM/yyyy") +"</p>"));
                    //}

                    cnt++;
                    //<h3>Lorem ipsum dolor sit amet</h3>
                    //<p><img src="images/bob-dylan-tickets-75x75.jpg" />"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    //<p>"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                }


                //     <div> <a title="" href="#">
                //    <img class="pic" src="images/006.jpg" />
                //</a>
                //        <p>
                //<strong>Description Title 1</strong>
                //<br/>
                //          Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor</p>
                //      </div>




                //phQuickBook
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnBuyTicket_ServerClick(object sender, EventArgs e)
        {

        }

        protected void GetEventDetails(string EventID)
        {
            try
            {
                EventTicketDetailsViewModel _eventTicketDetailsViewModel = new EventTicketDetailsViewModel();
                List<EventTicketDetailsModel> _eventTicketDetailsModel = new List<EventTicketDetailsModel>();
                _eventTicketDetailsModel = _eventTicketDetailsViewModel.GetEventTicketDetailsList(EventID);

                if (_eventTicketDetailsModel.Count > 0)
                {
                    if (_eventTicketDetailsModel != null || _eventTicketDetailsModel.Count > 0)
                    {
                        lblEventName.Text = _eventTicketDetailsModel[0].EventTitle;
                        imgEvent.Src = _eventTicketDetailsModel[0].ImagePath;
                        lblEvtDate.Text = Convert.ToDateTime(_eventTicketDetailsModel[0].EVENTFROMTIME).ToString("dd/MMM/yyyy");
                        lblEvtDate.Text += "  " + Convert.ToDateTime(_eventTicketDetailsModel[0].EVENTFROMTIME).ToString("HH:mm");
                        //lblEvtDate.Text += " To : " + Convert.ToDateTime(_eventTicketDetailsModel[0].EVENTTOTIME).ToString("HH:mm");//-kk

                        //lblEventDetails.Text = _eventTicketDetailsModel[0].EventDesc;
                        lblEventDetails.Value = _eventTicketDetailsModel[0].EventDesc;
                        lblVenueName.Text = _eventTicketDetailsModel[0].VenueName + "<br/> &nbsp&nbsp&nbsp" + _eventTicketDetailsModel[0].StreetAddress + "," + _eventTicketDetailsModel[0].City + "<br/> &nbsp&nbsp&nbsp" + _eventTicketDetailsModel[0].StateProvision + "," + _eventTicketDetailsModel[0].ZipCode;
                        imgVenue.Src = _eventTicketDetailsModel[0].VenueImagePath;
                        rptTicketDetails.DataSource = _eventTicketDetailsModel;
                        rptTicketDetails.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>Msg('Server is busy. Please try again!','Event Checkout','txtEmail');</script>", false);
                }



                //for (int i = 0; i < _eventTicketDetailsModel.Count; i++)
                //{
                //    if (i % 2 == 0)
                //    {
                //        phTicketprice.Controls.Add(new LiteralControl("<li class='even'>"));
                //    }
                //    else
                //    {
                //        phTicketprice.Controls.Add(new LiteralControl("<li class='odd'>"));
                //    }

                //    phTicketprice.Controls.Add(new LiteralControl("<div class='ticket-type column float-l blue-strong'>" + _eventTicketDetailsModel[i].EVENTPRICEDETAILS + "</div>"));

                //    phTicketprice.Controls.Add(new LiteralControl("<div class='ages column float-l'>18+</div>"));
                //    var outvalue = decimal.Parse(_eventTicketDetailsModel[i].EVENTPRICE, NumberStyles.Currency);
                //    phTicketprice.Controls.Add(new LiteralControl("<div class='price column float-l'>$ " + Convert.ToInt32(outvalue) + "</div>"));

                //    phTicketprice.Controls.Add(new LiteralControl("<div id='sfee135127' class='fee column float-l sfee'> $ 2.25</div>"));
                //    phTicketprice.Controls.Add(new LiteralControl(" <div class='quantcheck quantity column float-r'>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<select name='tt_135127' id='tt_135127' class='changeMe qty'>"));
                //    phTicketprice.Controls.Add(new LiteralControl(" <option></option>"));
                //    phTicketprice.Controls.Add(new LiteralControl(" <option value='1'>01</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='2'>02</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='3'>03</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='4'>04</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='5'>05</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='6'>06</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='7'>07</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='8'>08</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='9'>09</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<option value='10'>10</option>"));
                //    phTicketprice.Controls.Add(new LiteralControl(" </select>"));
                //    phTicketprice.Controls.Add(new LiteralControl("</div>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<br/>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<div class='clear-b'></div>"));
                //    phTicketprice.Controls.Add(new LiteralControl("<div class='clear-b'></div>"));
                //    phTicketprice.Controls.Add(new LiteralControl("</li>"));
                //}

                _eventTicketDetailsModel = null;

                _eventTicketDetailsViewModel = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void CheckOut_ServerClick(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>ShowLoading();</script>", false);

                if (ValidatePage() == true)
                {
                    if (Session["UserName"] != null)
                    {
                        TicketCarting();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Login", "ShowProcessing()", true);

                        //ScriptManager.RegisterStartupScript(this, GetType(), "Login", "ShowProcessing()", true);
                        //SignIn.Visible = true;
                        //Response.Redirect("/WebSite/LoginPage.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        protected void SignIn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                AuthenticateAndTicket();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private void AuthenticateAndTicket()
        {
            try
            {
                bool IsAuthenticate = false;

                if (IsValdateLoginUser() == true)
                {
                    using (CustomerLoginViewModel _custLoginViewModel = new CustomerLoginViewModel())
                    {
                        //BINU
                        //IsAuthenticate = _custLoginViewModel.CustomerLogin(txtEmail.Value, txtPassword.Value);
                    }

                    if (IsAuthenticate == true)
                    {
                        Session["UserName"] = txtEmail.Value;
                        Session["FullName"] = txtFullName.Value;
                        TicketCarting();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Invalid EmailID or Password.','Event Checkout: Validation','txtEmail');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected bool IsValdateLoginUser()
        {
            try
            {
                bool retval = true;

                if (!Regex.IsMatch(txtEmail.Value, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Please enter valid Email ID.','Event Checkout: Validation','txtEmail');</script>", false);
                }

                if (txtEmail.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Please enter Email ID.','Event Checkout: Validation','txtEmail');</script>", false);
                }

                if (txtPassword.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Please enter password.','Event Checkout: Validation','txtEmail');</script>", false);
                }

                if (hdType.Value == "Register")
                {
                    if (txtConfirmPassword.Value == "")
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Enter to confirm the password.','Event Checkout: Validation','txtEmail');</script>", false);
                    }

                    if (txtConfirmPassword.Value != txtPassword.Value)
                    {
                        retval = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>EMsg('Password mismatch.','Event Checkout: Validation','txtEmail');</script>", false);
                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TicketCarting()
        {
            try
            {
                int TotalAmt = 0;
                bool InvalidTicket = false;

                List<TicketSeatModel> _LticketSeatModel = new List<TicketSeatModel>();
                //List<TicketSeatModel> _LticketSeatModel = new List<TicketSeatModel>();


                foreach (RepeaterItem item in rptTicketDetails.Items)
                {
                    switch (item.ItemType)
                    {
                        case ListItemType.Item:
                            {
                                DropDownList chk = (DropDownList)item.FindControl("dd");
                                Label lbl = (Label)item.FindControl("lblEventPrice");
                                Label lblseat = (Label)item.FindControl("lblSeatLeft");
                                Label lblTicketDetails = (Label)item.FindControl("lblEventDetails");

                                //string d = chk.Text;
                                //string f = lbl.Text;
                                if (Convert.ToInt32(chk.Text) > Convert.ToInt32(lblseat.Text))
                                {
                                    if (lblseat.Text == "0")
                                    {
                                        InvalidTicket = true;
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('The event you are trying to book for has been sold out. We regret the incovenience.');", true);
                                        break;
                                    }
                                    else
                                    {
                                        InvalidTicket = true; //

                                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                        sb.Append(@"<script language='javascript'>");

                                        if (Convert.ToInt32(lblseat.Text) == 1)
                                        {
                                            sb.Append(@"alert('Only  " + lblseat.Text + " seat is avaliable.')");
                                        }
                                        else
                                        {
                                            sb.Append(@"alert('Only  " + lblseat.Text + " seats are avaliable.')");
                                        }                                        
                                        sb.Append(@"</script>");
                                                                                
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Transaction Decline", sb.ToString(), false);
                                        break;
                                    }
                                }

                                if (chk.Text != "0")
                                {
                                    if (InvalidTicket == false)
                                    {
                                        TotalAmt += Convert.ToInt32(chk.Text) * Convert.ToInt32(lbl.Text);

                                        _LticketSeatModel.Add(new TicketSeatModel
                                        {
                                            CUSTID = Session["UserName"].ToString(),
                                            EventSPID = EID,
                                            SeatesBooked = Convert.ToInt32(chk.Text),
                                            FullName = Session["FullName"].ToString(),
                                            TicketType = lblTicketDetails.Text
                                        });
                                    }

                                    //proxy.SetTicketTemporyRegistration(_ticketSeatModel, "ShowLine#$5how!in3", "5how$*L!n3");
                                }
                                break;
                            }
                        case ListItemType.AlternatingItem:
                            {
                                DropDownList chk = (DropDownList)item.FindControl("dd");
                                Label lbl = (Label)item.FindControl("lblEventPrice");
                                Label lblseat = (Label)item.FindControl("lblSeatLeft");
                                Label lblTicketDetails = (Label)item.FindControl("lblEventDetails");

                                if (Convert.ToInt32(chk.Text) > Convert.ToInt32(lblseat.Text))
                                {
                                    if (lblseat.Text == "0")
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('The event you are trying to book for has been sold out. We regret the incovenience.');", true);
                                        break;
                                    }
                                    else
                                    {
                                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                        sb.Append(@"<script language='javascript'>");

                                        if (Convert.ToInt32(lblseat.Text) == 1)
                                        {
                                            sb.Append(@"alert('Only  " + lblseat.Text + " seat is avaliable.')");
                                        }
                                        else
                                        {
                                            sb.Append(@"alert('Only  " + lblseat.Text + " seats are avaliable.')");
                                        }                                
                                        sb.Append(@"</script>");

                                        
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Transaction Decline", sb.ToString(), false);
                                        break;
                                    }
                                }

                                //string d = chk.Text;
                                //string f = lbl.Text;
                                if (chk.Text != "0")
                                {
                                    if (InvalidTicket == false)
                                    {
                                        TotalAmt += Convert.ToInt32(chk.Text) * Convert.ToInt32(lbl.Text);

                                        _LticketSeatModel.Add(new TicketSeatModel
                                        {
                                            CUSTID = Session["UserName"].ToString(),
                                            EventSPID = EID,
                                            SeatesBooked = Convert.ToInt32(chk.Text),
                                            FullName = Session["FullName"].ToString(),
                                            TicketType = lblTicketDetails.Text
                                        });
                                    }

                                    //proxy.SetTicketTemporyRegistration(_ticketSeatModel, "ShowLine#$5how!in3", "5how$*L!n3");
                                }

                                break;
                            }
                    }
                }


                if (_LticketSeatModel.Count > 0)
                {
                    using (ShowLineVer3.ShowLineServiceReference.Service1Client proxy = new ShowLineVer3.ShowLineServiceReference.Service1Client())
                    {
                        //proxy.SetTicketTemporyRegistration(_LticketSeatModel, "ShowLine#$5how!in3", "5how$*L!n3");
                        string retval = proxy.SetTicketTemporyRegistration(_LticketSeatModel.ToArray(), "ShowLine#$5how!in3", "5how$*L!n3");

                        if (!String.IsNullOrEmpty(retval))
                        {
                            EncryptDecrypt _EncryptDecrypt = new EncryptDecrypt();

                            EID = _EncryptDecrypt.Encrypt_QueryString(EID);
                            retval = _EncryptDecrypt.Encrypt_QueryString(retval);
                            string dd = _EncryptDecrypt.Encrypt_QueryString(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"));

                            _EncryptDecrypt = null;

                            string urlVal = @"https://showsline.com/Website/SPayment.aspx?EID=" + (EID) + "&TID=" + retval + "&PID=" + dd;
                            //string urlVal = @"http://showsline.com/Website/SPayment.aspx?EID=" + (EID) + "&TID=" + retval + "&PID=" + dd;
                        

                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='" + urlVal + "'", true);
                                                        
                        }
                        else
                        {
                            //MEsage Server Busy
                        }
                    }
                }
                //Session["PD"] = TotalAmt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool ValidatePage()
        {
            try
            {
                bool valBool = true;
                bool IsSelected = false;

                foreach (RepeaterItem item in rptTicketDetails.Items)
                {

                    switch (item.ItemType)
                    {
                        case ListItemType.Item:
                            {
                                DropDownList chk = (DropDownList)item.FindControl("dd");
                                if (chk.Text == "0" && IsSelected == false)
                                {
                                    valBool = false;
                                }
                                else
                                {
                                    IsSelected = true;
                                    valBool = true;
                                }
                                break;
                            }
                        case ListItemType.AlternatingItem:
                            {
                                DropDownList chk = (DropDownList)item.FindControl("dd");
                                if (chk.Text == "0" && IsSelected == false)
                                {
                                    valBool = false;
                                }
                                else
                                {
                                    IsSelected = true;
                                    valBool = true;
                                }

                                break;
                            }
                    }
                }

                if (valBool == false)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Login", "SubmitChekout()", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>Msg('You must purchase at least 1 ticket.','Event Checkout: Validation','txtEmail');</script>", false);

                    //ScriptManager.RegisterStartupScript(this, GetType(), "Login", "alert('You must purchase at least 1 ticket", true);
                }

                return valBool;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void FormSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (hdType.Value == "SendPassword")
                {
                    SendEmailProcess _sendProcess = new SendEmailProcess();
                    string body = string.Empty;

                    using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailFormat.html")))
                    {
                        body = reader.ReadToEnd();
                    }

                    string retval = "";
                    string retvalEx = _sendProcess.SendEmail(txtEmail.Value.Trim(), body, out retval);
                    UserAuthentication _userauth = new UserAuthentication();
                    bool retvalAuth = _userauth.UpdateUserPassword(txtEmail.Value.Trim(), retval);

                    if (retvalAuth == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login", "<script type='text/javascript'>Msg('Password send.','User Registration');</script>", false);
                    }
                    hdType.Value = "SignIn";

                }
                else if (IsValdateLoginUser() == true)
                {
                    if (hdType.Value == "SignIn")
                    {
                        AuthenticateAndTicket();
                    }
                    else if (hdType.Value == "Register")
                    {
                        if (CreateUser() == true)
                        {
                            AuthenticateAndTicket();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Event Checkout", "<script type='text/javascript'>ShowLoading();</script>", false);
            try
            {
                if (Session["SessVal"] == null)
                {
                    if (ValidatePage() == true)
                    {
                        if (Session["UserName"] != null)
                        {
                            //if (Session["update"].ToString() == ViewState["update"].ToString()) // If page not Refreshed 
                            {
                                TicketCarting();
                                Session.Remove("UserName");
                                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                                Session["SessVal"] = "0";
                            }
                        }
                        else
                        {
                            Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                            ScriptManager.RegisterStartupScript(this, GetType(), "Login", "ShowProcessing('" + EID + "')", true);
                            //SignIn.Visible = true;
                            //Response.Redirect("/WebSite/LoginPage.aspx");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private bool CreateUser()
        {
            try
            {
                bool IsAuthenticate = false;

                string retvalstr = "";

                using (CustomerLoginViewModel _custLoginViewModel = new CustomerLoginViewModel())
                {
                    //BINU
                    // retvalstr = _custLoginViewModel.CustomerRegistration(txtEmail.Value.Trim(), txtPassword.Value.Trim(), "1111111111", txtFullName.Value.Trim());
                }

                if (retvalstr.Contains("Email ID"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>Msg('Email ID already exits.','User Registration');</script>", false);
                    IsAuthenticate = false;
                }
                else if (retvalstr.Contains("User Added"))
                {
                    Session["UserName"] = txtEmail.Value;
                    Session["FullName"] = txtFullName.Value;

                    IsAuthenticate = true;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Email ID already exits.');</script>", false);
                }

                return IsAuthenticate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ForgetPassword()
        {


        }


    }
}
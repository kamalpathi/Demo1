using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.WebSite
{
    public partial class SPayment : System.Web.UI.Page
    {
        string EID = "";
        string TID = "";
        int viewCountSum = 0;
        int viewTotalCountSum = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["ssSessVal"] != null)
            {
                if (Session["ssSessVal"].ToString() == "0")
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["EID"]))
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["TID"]))
                    {
                        EncryptDecrypt _EncryptDecrypt = new EncryptDecrypt();

                        EID = _EncryptDecrypt.Decrypt_QueryString(Request.QueryString["EID"].ToString());
                        TID = _EncryptDecrypt.Decrypt_QueryString(Request.QueryString["TID"].ToString());
                        string dd = _EncryptDecrypt.Decrypt_QueryString(Request.QueryString["PID"].ToString());

                        TimeSpan ts = DateTime.Now.Subtract(Convert.ToDateTime(dd));

                        double cdd = ts.TotalMinutes;

                        if (cdd > 10)
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);                            
                        }

                        _EncryptDecrypt = null;
                        GetEventDetails();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Server is busy.Please try again.')</script>", false);
                        Session.Abandon();
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);

                        //Response.Redirect("~/Default.aspx");//-kk redirect
                        //Response.Redirect("http://showline.com/Default.aspx?action=logout", false);
                        //Context.ApplicationInstance.CompleteRequest();

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Server is busy.Please try again.')</script>", false);
                    Session.Abandon();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myUniqueKey", "self.parent.location='http://showsline.com/Default.aspx?action=logout'", true);

                    //                    Response.Redirect("~/Default.aspx");//-kk redirect
                    //Response.Redirect("http://showline.com/Default.aspx", false);
                    //Context.ApplicationInstance.CompleteRequest();
                }

                if (!IsPostBack)
                {
                    //EID ="E03061310544648";
                    //TID = "T270613020522395";
                    txtCard.Text = "";
                    txtCardNumber.Text = "";
                    txtCVV.Text = "";

                    GetTicketDetails(TID);
                    GetVenueEventDetails();
                }
                else
                {
                    //Session.Abandon();
                    //Response.Redirect("~/Default.aspx");
                }

            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void GetTicketDetails(string TID)
        {
            try
            {
                List<PayementDetailsModel> _payementDetailsModel = new List<PayementDetailsModel>();
                PayementDetailsViewModel _payementDetailsViewModel = new PayementDetailsViewModel();

                _payementDetailsModel = _payementDetailsViewModel.PaymentTicketDetails(TID);

                var t = _payementDetailsModel.Sum(tamt => Convert.ToInt32(tamt.AMT));
                viewCountSum = t;

                totval.Value = viewCountSum.ToString(); //kk
                viewTotalCountSum = t + 2 + 2;

                rptPayment.DataSource = _payementDetailsModel;
                rptPayment.DataBind();

                //paymentSubTotal.Text = t.ToString();

            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }

        }


        protected void GetVenueEventDetails()
        {
            try
            {
                EventVenueViewModel _eventVenueViewModel = new EventVenueViewModel();
                EventVenueModel _eventVenueModel = new EventVenueModel();

                _eventVenueModel = _eventVenueViewModel.GetEventVenueModelDetails(EID);

                if (_eventVenueModel != null)
                {
                    EvtImage.Src = _eventVenueModel.EventImage;
                    lblEventName.Text = _eventVenueModel.EventName;
                    lblStreetAddress.Text = _eventVenueModel.StreetAddress;
                    lblCity.Text = _eventVenueModel.City;
                    lblState.Text = _eventVenueModel.StateProvision;
                    lblZip.Text = _eventVenueModel.ZipCode;
                    lblDateTime.Text = Convert.ToDateTime(_eventVenueModel.EventDate).ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(_eventVenueModel.EventFromTime).ToString("HH:mm");// +" - " + Convert.ToDateTime(_eventVenueModel.EventToTime).ToString("HH:mm"); //-kk
                    lblVenueName.Text = _eventVenueModel.VenueName;

                }

            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePage() == true)
                {

                    if (!String.IsNullOrEmpty(EID) && !String.IsNullOrEmpty(TID))
                    {
                        //PAYMENT PROCEDURE


                        //UPDATE TICKET STATUS
                        //***************+kk Authorize.net payment

                        // By default, this sample code is designed to post to our test server for
                        // developer accounts: https://test.authorize.net/gateway/transact.dll
                        // for real accounts (even in test mode), please make sure that you are
                        // posting to: https://secure.authorize.net/gateway/transact.dll

                        Dictionary<string, string> post_values = new Dictionary<string, string>();

                        //String post_url = "https://test.authorize.net/gateway/transact.dll";
                        //post_values.Add("x_login", "5bpPR895DF");
                        //post_values.Add("x_tran_key", "67Rg3v72XqkZk6aL");
                        
                        //the API Login ID and Transaction Key must be replaced with valid values
                        //+kk

                        //Live
                        String post_url = "https://secure.authorize.net/gateway/transact.dll";  //live
                        post_values.Add("x_login", "5S2n9j3uBaR");
                        post_values.Add("x_tran_key", "5g94d9E3wwGUnC6E");


                        post_values.Add("x_delim_data", "TRUE");
                        post_values.Add("x_delim_char", "|");
                        post_values.Add("x_relay_response", "FALSE");

                        post_values.Add("x_type", "AUTH_CAPTURE");
                        post_values.Add("x_method", "CC");
                        post_values.Add("x_card_num", txtCardNumber.Text);//6011000000000012
                        post_values.Add("x_exp_date", ccMonth.Text + ccYear.Value);//"0515");
                        post_values.Add("x_card_code", txtCVV.Text);//+kk CCV

                        post_values.Add("x_amount", totval.Value);//"15.00");
                        post_values.Add("x_description", "SHOWSLINE WEB");

                        //+kk required only id addr verification is doing
                        /*post_values.Add("x_first_name", "John");
                        post_values.Add("x_last_name", "Doe");
                        post_values.Add("x_address", "1234 Street");
                        post_values.Add("x_state", "WA");
                        post_values.Add("x_zip", "98004");*/
                        // Additional fields can be added here as outlined in the AIM integration
                        // guide at: http://developer.authorize.net

                        // This section takes the input fields and converts them to the proper format
                        // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
                        String post_string = "";

                        foreach (KeyValuePair<string, string> post_value in post_values)
                        {
                            post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
                        }
                        post_string = post_string.TrimEnd('&');

                        // The following section provides an example of how to add line item details to
                        // the post string.  Because line items may consist of multiple values with the
                        // same key/name, they cannot be simply added into the above array.
                        //
                        // This section is commented out by default.
                        /*
                        string[] line_items = {
                            "item1<|>golf balls<|><|>2<|>18.95<|>Y",
                            "item2<|>golf bag<|>Wilson golf carry bag, red<|>1<|>39.99<|>Y",
                            "item3<|>book<|>Golf for Dummies<|>1<|>21.99<|>Y"};
	
                        foreach( string value in line_items )
                        {
                            post_string += "&x_line_item=" + HttpUtility.UrlEncode(value);
                        }
                        */

                        // create an HttpWebRequest object to communicate with Authorize.net
                        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
                        objRequest.Method = "POST";
                        objRequest.ContentLength = post_string.Length;
                        objRequest.ContentType = "application/x-www-form-urlencoded";

                        // post data is sent as a stream
                        StreamWriter myWriter = null;
                        myWriter = new StreamWriter(objRequest.GetRequestStream());
                        myWriter.Write(post_string);
                        myWriter.Close();

                        // returned values are returned as a stream, then read into a string
                        String post_response;
                        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                        using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
                        {
                            post_response = responseStream.ReadToEnd();
                            responseStream.Close();
                        }

                        string[] response_array = post_response.Split('|');

                        // the response string is broken into an array
                        // The split character specified here must match the delimiting character specified above

                        // individual elements of the array could be accessed to read certain response
                        // fields.  For example, response_array[0] would return the Response Code,
                        // response_array[2] would return the Response Reason Code.
                        // for a list of response fields, please review the AIM Implementation Guide

                        if (response_array[0] == "1")
                        {//Approved
                            EventTicketDetailsViewModel _eventTicketDetailsViewModel = new EventTicketDetailsViewModel();
                            // _eventTicketDetailsViewModel.UpdateTicketStatus(TID, EID, result.CTR, result.EXact_Resp_Code, result.Bank_Resp_Code + " MSG :  " + result.EXact_Message, result.Bank_Message);//-kk
                            _eventTicketDetailsViewModel.UpdateTicketStatus(TID, EID, response_array[4], response_array[0], response_array[2] + " MSG :  " + response_array[3], response_array[3]);//+kk
                            _eventTicketDetailsViewModel = null;

                            EncryptDecrypt _EncryptDecrypt = new EncryptDecrypt();
                            EID = _EncryptDecrypt.Encrypt_QueryString(EID);
                            TID = _EncryptDecrypt.Encrypt_QueryString(TID);
                            _EncryptDecrypt = null;

                            txtCardNumber.Text = "";
                            txtCVV.Text = "";
                            txtCard.Text = "";

                            Session["ssSessVal"] = "0";
                            Response.Redirect("http://showsline.com/WebSite/Confirmation.aspx?EID=" + EID + "&TID=" + TID, false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(@"<script language='javascript'>");
                            sb.Append(@"alert('Transaction Declined : " + response_array[3] + "')");
                            //sb.Append(@"lbl.style.color='red';");
                            sb.Append(@"</script>");

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Transaction Decline : '" + result.EXact_Message + "' );", true);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Transaction Decline", sb.ToString(), false);

                            //Response.Redirect("~/WebSite/Decline.aspx?EID=" + EID + "&TID=" + TID); //for test, To be replaced with Decline page, put "result.EXact_Message" message in the decline page.
                        }

                        //******************************

                        txtCardNumber.Text = "";
                        txtCVV.Text = "";
                        txtCard.Text = "";



                        //Response.Redirect("~/WebSite/Confirmation.aspx?EID=" + EID + "&TID=" + TID);
                        //////+kk
                        /*try
                        {
                            E4.ServiceSoapClient ws = new E4.ServiceSoapClient();
                            E4.Transaction txn = new E4.Transaction();
                            // set correct credential values, to be replaced with "live" values
                            txn.ExactID = "AD3533-06";
                            txn.Password = "n92b65pm";

                            txn.Transaction_Type = "00";
                            txn.Card_Number = txtCardNumber.Text;// "4111111111111111";  //visa 4111111111111111 
                            //txn.Card_Number = "5500000000000004"; //master card  
                            //txn.Card_Number = "6011000000000004"; //Discover card  
                            //txn.Card_Number = "3566002020140006"; //JCB card  
                            txn.CardHoldersName = txtCard.Text;// "test name 1";
                            //txn.DollarAmount =  "10.00";
                            //txn.Expiry_Date = "1114"; //mmyy
                            txn.DollarAmount = totval.Value; //"10.00";
                            txn.Expiry_Date = ccMonth.Text + ccYear.Value; //"1114"; //mmyy


                            txn.VerificationStr2 = txtCVV.Text;// "123";  //CVV
                            txn.CVD_Presence_Ind = "1";

                            E4.TransactionResult result = ws.SendAndCommit(txn);

                            Console.WriteLine(result.CTR);
                            Console.WriteLine("e4 resp code: " + result.EXact_Resp_Code);
                            Console.WriteLine("e4 message: " + result.EXact_Message);
                            Console.WriteLine("e4 CVV Result: " + result.CVV2);
                            Console.WriteLine("bank resp code: " + result.Bank_Resp_Code);
                            Console.WriteLine("bank message: " + result.Bank_Message);

                            if (result.EXact_Resp_Code == "00") //Approved
                            {
                                EventTicketDetailsViewModel _eventTicketDetailsViewModel = new EventTicketDetailsViewModel();
                                _eventTicketDetailsViewModel.UpdateTicketStatus(TID, EID, result.CTR, result.EXact_Resp_Code, result.Bank_Resp_Code + " MSG :  " + result.EXact_Message, result.Bank_Message);
                                _eventTicketDetailsViewModel = null;

                                Response.Redirect("~/WebSite/Confirmation.aspx?EID=" + EID + "&TID=" + TID, false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                            //Response.Redirect("~/WebSite/Confirmation.aspx?EID=" + EID + "&TID=" + TID);
                            else
                            {
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(@"<script language='javascript'>");
                                sb.Append(@"alert('Transaction Declined : " + result.EXact_Message + "')");
                                //sb.Append(@"lbl.style.color='red';");
                                sb.Append(@"</script>");

                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Transaction Decline : '" + result.EXact_Message + "' );", true);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Transaction Decline", sb.ToString(), false);

                                //Response.Redirect("~/WebSite/Decline.aspx?EID=" + EID + "&TID=" + TID); //for test, To be replaced with Decline page, put "result.EXact_Message" message in the decline page.
                            }
                        }
                        catch (Exception ex1)
                        {
                            ErrHandler.WriteError(ex1.Message);

                            if (ex1.Message.ToUpper().Contains("TOO BUSY"))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Service Not responding.Please try after sometime.');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Unexpected error occur please try after sometime.');", true);
                            }
                            Response.Redirect("/WebSite/events-List?ID=" + EID + "&EN=" + "");
                        }
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected bool ValidatePage()
        {
            bool retval = true;

            if (txtCardNumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Enter Card Number.')</script>", false);
                retval = false;
            }

            if (txtCard.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Enter Card Holder Name.')</script>", false);
                retval = false;
            }

            if (txtCVV.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Enter Security Code(CVV).')</script>", false);
                retval = false;
            }
/*
            int n;
            bool isNumeric = int.TryParse(txtCVV.Text, out n);

            if (isNumeric == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Enter valid CVV Number.')</script>", false);
                retval = false;
            }

            isNumeric = int.TryParse(txtCardNumber.Text, out n);

            if (isNumeric == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>alert('Enter valid Card Number.')</script>", false);
                retval = false;
            }
*/
            return retval;
        }


        protected void rptPayment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    int viewCount = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "AMT"));
            //    viewCountSum += viewCount;
            //}
        }

        public string SubtotalP()
        {
            try
            {
                return viewCountSum.ToString();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Unexpected error occur please try after sometime.');", true);
                Response.Redirect("/WebSite/events-List?ID=" + EID + "&EN=" + "");
                return "";
            }
        }

        public string totalAmtP()
        {
            try
            {
                return viewTotalCountSum.ToString();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Unexpected error occur please try after sometime.');", true);
                Response.Redirect("/WebSite/events-List?ID=" + EID + "&EN=" + "");
                return "";
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
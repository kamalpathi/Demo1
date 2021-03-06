﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.AdminPanel
{
    public partial class CreateAdminUser : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["SVenue"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='/Admin.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["SVenue"] != null)
                    {
                        GetVenueDetails();
                        string VID = Session["SVenue"].ToString();
                        if (VID == "0")
                        {
                            ListItem lst;

                            lst = new ListItem();
                            lst.Text = "Admin";
                            lst.Value = "Admin";
                            ddUserType.Items.Add(lst);

                            lst = new ListItem();
                            lst.Text = "POS";
                            lst.Value = "POS";
                            ddUserType.Items.Add(lst);
                        }
                        else
                        {
                            ListItem lst = new ListItem();
                            lst.Text = "POS";
                            lst.Value = "POS";
                            ddUserType.Items.Add(lst);

                            ddVenueDetails.SelectedValue = VID;
                            ddVenueDetails.Enabled = false;

                        }

                        if (Request.QueryString["AD"] != null)
                        {
                            hdAdminID.Value = Request.QueryString["AD"].ToString();
                            GetAdminDetailsByID(Convert.ToInt32(Request.QueryString["AD"]));
                            btnSave.Visible = false;
                            btnUpdate.Visible = true;
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
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        private void GetAdminDetailsByID(int ID)
        {
            try
            {
                AdminViewModel _adminViewModel = new AdminViewModel();
                AdminModel _adminModel = new AdminModel();
                _adminModel = _adminViewModel.GetAdminDetails(ID);
                txtFullName.Value = _adminModel.AdminFullName;
                txtMobileNo.Value = _adminModel.AdminMobNo;
                ddVenueDetails.SelectedValue = _adminModel.VenueID;
                txtUserName.Value = _adminModel.AdminUserName;
                txtEmailID.Value = _adminModel.AdminEmailID;
                ddUserType.SelectedValue = _adminModel.UserType;
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
                string retvalstr = "";

                if (ValidatePage() == true)
                {
                    AdminViewModel _adminViewModel = new AdminViewModel();
                    AdminModel _AdminModel = new AdminModel();

                    _AdminModel.UserType = ddUserType.Text;
                    _AdminModel.AdminFullName = txtFullName.Value;
                    _AdminModel.AdminMobNo = txtMobileNo.Value;
                    _AdminModel.VenueID = ddVenueDetails.SelectedValue;
                    _AdminModel.AdminUserName = txtUserName.Value;
                    _AdminModel.AdminEmailID = txtEmailID.Value;


                    //SendEmailProcess _sendProcess = new SendEmailProcess();
                    //string body = string.Empty;

                    //using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailFormat.html")))
                    //{
                    //    body = reader.ReadToEnd();
                    //}

                    //string retval ="" ;
                    //string retvalEx = _sendProcess.SendEmail(txtEmailID.Value, body, out retval);


                    string pwd = GenerateRandomCode();
                    _AdminModel.AdminUserPassword = pwd;

                    retvalstr = _adminViewModel.InsertAdminDetails(_AdminModel);

                    if (retvalstr.Contains("Email ID"))
                    {                        
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Email ID already Registered.');", true);
                    }
                    else if (retvalstr.Contains("User Added"))
                    {
                        bool retval = SendEmail(txtEmailID.Value, pwd);

                        if (retval == false)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Unexpected error occured.Plese refresh the page and try again!');", true);                            

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Data saved sucessfully');", true);                                                        
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

        private bool ValidatePage()
        {
            try
            {
                bool retval = true;

                if (ddUserType.Text == "Select")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Select User Type.','Add User');</script>", false);
                }

                if (txtFullName.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Enter User's Full name.','Add User');</script>", false);
                }

                if (txtMobileNo.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Enter Mobile Number.','Add User');</script>", false);
                }

                if (ddVenueDetails.Text.Contains("Select"))
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Select Venue Detail.','Add User');</script>", false);
                }

                if (txtUserName.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Enter User Name.','Add User');</script>", false);
                }

                if (txtEmailID.Value == "")
                {
                    retval = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Enter Email Id.','Add User');</script>", false);
                }

                return retval;
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
                    AdminViewModel _adminViewModel = new AdminViewModel();
                    AdminModel _AdminModel = new AdminModel();

                    _AdminModel.AdminUserID = Convert.ToInt32(hdAdminID.Value);
                    _AdminModel.UserType = ddUserType.Text;
                    _AdminModel.AdminFullName = txtFullName.Value;
                    _AdminModel.AdminMobNo = txtMobileNo.Value;
                    _AdminModel.VenueID = ddVenueDetails.SelectedValue;
                    _AdminModel.AdminUserName = txtUserName.Value;
                    _AdminModel.AdminEmailID = txtEmailID.Value;

                    bool retval;
                    retval = _adminViewModel.UpdateAdminDetails(_AdminModel);

                    if (retval == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Data saved sucessfully.','Add User');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add User", "<script type='text/javascript'>ConfirmMsg('Unexpected error occured.Plese refresh the page and try again!','Add User');</script>", false);
                    }

                    //Response.Redirect("/AdminList.aspx");//-kk redirect
                            Response.Redirect("/AdminList.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        //Seding Email

        protected bool SendEmail(string UserEmailID, string GenPwd)
        {
            try
            {
                string body = this.PopulateBody("Guest",
                    "Your Password",
                    "http://www.showsline.com",
                    "", GenPwd);
                this.SendHtmlFormattedEmail(UserEmailID, "Your Password.", body);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;                
            }
        }

        private string PopulateBody(string userName, string title, string url, string description, string Pawd)
        {
            try
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailFormat.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", userName);
                body = body.Replace("{Title}", title);
                body = body.Replace("{Url}", url);
                body = body.Replace("{Description}", description);
                body = body.Replace("{Pwd}", Pawd);
                return body;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];

                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GenerateRandomCode()
        {
            try
            {
                Random r = new Random();
                string s = "";
                for (int j = 0; j < 5; j++)
                {
                    int i = r.Next(3);
                    int ch;
                    switch (i)
                    {
                        case 1:
                            ch = r.Next(0, 9);
                            s = s + ch.ToString();
                            break;
                        case 2:
                            ch = r.Next(65, 90);
                            s = s + Convert.ToChar(ch).ToString();
                            break;
                        case 3:
                            ch = r.Next(97, 122);
                            s = s + Convert.ToChar(ch).ToString();
                            break;
                        default:
                            ch = r.Next(97, 122);
                            s = s + Convert.ToChar(ch).ToString();
                            break;
                    }
                    r.NextDouble();
                    r.Next(100, 1999);
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
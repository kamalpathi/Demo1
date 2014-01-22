using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.ViewModel;
//using System.Web;
//using System.Web.Mail;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using ShowLineVer3.Model;

namespace ShowLineVer3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["action"] != null)
                {
                    Response.Clear();
                    Session.Abandon();
                    //Response.Write("Success");
                    //Response.Redirect("Default.aspx?action=logout", false);
                    //Response.Redirect("Default.aspx");//-kk redirect
                    Response.Redirect("http://showsline.com/Default.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                    //Response.End(); //-kk
                }

                if (!IsPostBack)
                {
                    GetEventDetails();
                }

                Session["Login"] = "Main"; 

                if (Session["FullName"] != null)
                {
                    toggle.Attributes["class"] = "displayNone";
                    toggleLogin.Attributes["class"] = "display";
                    lblusername.InnerText = "Hi ," + Session["FullName"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsAuthenticate = false;
                string userName;
                if (IsValdateLoginUser() == true)
                {
                    using (CustomerLoginViewModel _custLoginViewModel = new CustomerLoginViewModel())
                    {
                        IsAuthenticate = _custLoginViewModel.CustomerLogin(txtUserName.Text, txtPwd.Text, out userName);
                    }

                    if (IsAuthenticate == true)
                    {
                        Session["UserName"] = txtUserName.Text;
                        Session["FullName"] = userName;
                        toggle.Attributes["class"] = "displayNone";
                        toggleLogin.Attributes["class"] = "display";


                        if (userName != "")
                        {
                            lblusername.InnerText = "Hi," + userName;
                        }
                        else
                        {
                            lblusername.InnerText = "Hi , Guest ";
                        }


                        //if (userName != "")
                        //{
                        //    lblUsrNm.Text = "Hi , " + userName;
                        //}
                        //else
                        //{
                        //    lblUsrNm.Text = "Hi , Guest ";
                        //}

                        if (acc.Value == "T") //value from account login
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>javascript:LoadPage('WebSite/CustAccountDetails.aspx',this);</script>", false);
                        }
                        else if (acc.Value != "") //Value comming form checkout form
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>javascript:LoadPage('events-List.aspx?ID=" + acc.Value + "',this);</script>", false);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>javascript:Checkout();</script>", false);                         
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Invalid Email ID or password.','User Registration');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //bool IsAuthenticate = false;
                string retvalstr = "";

                if (IsValdateRegisterUser() == true)
                {
                    string pwd = GenerateRandomCode();

                    using (CustomerLoginViewModel _custLoginViewModel = new CustomerLoginViewModel())
                    {
                        retvalstr = _custLoginViewModel.CustomerRegistration(txtREmailID.Text, pwd, txtMobileNo.Text, txtFirstName.Text.Trim(), txtLastName.Text.Trim());
                    }

                    if (retvalstr.Contains("Email ID"))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Email ID already Registered.','User Registration');</script>", false);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Duty Updation", "javascript:alert('CheckValidation()');", true);
                    }
                    else if (retvalstr.Contains("User Added"))
                    {

                        SendEmail(txtREmailID.Text, pwd);

                        Session["UserName"] = txtREmailID.Text;
                        Session["FullName"] = txtFirstName.Text;

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Password has been sent to your email ID.','User Registration');</script>", false);

                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtREmailID.Text = "";
                        txtMobileNo.Text = "";                        
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Email ID already exits.');</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Please enter valid data.','User Registration');</script>", false);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }

        protected bool IsValdateLoginUser()
        {
            try
            {
                bool retval = true;

                if (txtUserName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter valid Email ID.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtPwd.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter password.','User Registration');</script>", false);
                    retval = false;
                }

                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected bool IsValdateRegisterUser()
        {
            try
            {
                bool retval = true;

                if (txtREmailID.Text.Length > 100)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter valid Email ID.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtFirstName.Text.Length > 50)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Max 50 character in first name.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtLastName.Text.Length > 50)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Max 50 character in last name.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtMobileNo.Text.Length > 20)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Max 20 character in Mobile Number.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtREmailID.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter Email ID.','User Registration');</script>", false);
                    retval = false;
                }

                RegexUtilities validEmail = new RegexUtilities();
                if (validEmail.IsValidEmail(txtREmailID.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter Valid Email ID.','User Registration');</script>", false);
                    retval = false;
                }
                validEmail = null;


                if (txtFirstName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter First Name.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtLastName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter Last Name.','User Registration');</script>", false);
                    retval = false;
                }

                if (txtMobileNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter Mobile Number.','User Registration');</script>", false);
                    retval = false;
                }

                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SendEmail(string UserEmailID,string GenPwd)
        {
            try
            {
                string body = this.PopulateBody("Guest",
                    "Your Password",
                    "http://www.showsline.com",
                    "", GenPwd);
                this.SendHtmlFormattedEmail(UserEmailID, "Your Password.", body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string PopulateBody(string userName, string title, string url, string description,string Pawd)
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
                Response.Redirect("Default.aspx?action=logout", false);
                            Context.ApplicationInstance.CompleteRequest();

            }

        }

        protected void myaccount_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    acc.Value = "T";

                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>OpenLoginPanel();</script>", false);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>OpenLogin();</script>", false);
                }
                else
                {
                    //javascript:LoadPage('events-Details.aspx',this)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>javascript:LoadPage('WebSite/CustAccountDetails.aspx',this);</script>", false);

                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }
        }
               
        protected void searchfor_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchBy.Value))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>javascript:LoadPage('events-Details.aspx?searchby=" + searchBy.Value + "',this);</script>", false);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "javascript:alert('Server is busy.Please try after sometime.');", true);
            }

        }

        private bool ValidateForgotPwd()
        {
            try
            {
                bool retval = true;

                if (txtUserName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Enter valid Email ID.','User Registration');</script>", false);
                    retval = false;
                }

                return retval;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnForgotPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForgotPwd() == true)
                {
                    using (CustomerLoginViewModel _custLoginViewModel = new CustomerLoginViewModel())
                    {
                        string pwd = GenerateRandomCode();

                        string retvalstr = _custLoginViewModel.UpdateForgotPassword(txtUserName.Text, pwd);

                        if (retvalstr.Contains("Email ID"))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Email ID does not exits.','User Registration');</script>", false);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Duty Updation", "javascript:alert('CheckValidation()');", true);
                        }
                        else if (retvalstr.Contains("User Added"))
                        {
                            SendEmail(txtUserName.Text, pwd);
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Password has been sent to your email ID.','User Registration');</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Validation", "<script type='text/javascript'>CheckValidation('Server is busy. Please try after sometime.','User Registration');</script>", false);
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
    }
}
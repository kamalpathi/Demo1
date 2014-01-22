using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace ShowLineVer3.ViewModel
{
    public class SendEmailProcess
    {
        public string SendEmail(string UserEmailID, string srEmailFormat, out string GenPwd)
        {
            try
            {
                GenPwd = GenerateRandomCode();

                string body = this.PopulateBody("Guest","Your Password","http://www.showsline.com","", GenPwd, srEmailFormat);
                this.SendHtmlFormattedEmail(UserEmailID, "Your Password.", body);

                return "true";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string PopulateBody(string userName, string title, string url, string description, string Pawd, string EmailFormat)
        {
            try
            {
                string body = string.Empty;
                //using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailFormat.html")))
                //{
                //    body = reader.ReadToEnd();
                //}

                body = EmailFormat;

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
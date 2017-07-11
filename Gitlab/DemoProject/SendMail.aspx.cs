using MailBee.SmtpMail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoProject
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hai
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string ddltext = ddlTemplate.SelectedValue;

            if (ddltext=="Select")
            {
                Response.Write("<script>alert('Please Select Template')</script>");
            }
            else if (ddltext=="Template1")
            {
                string body = ReadHtml(ddltext);
               bool status= SendHtmlFormattedEmailMailbee("recepientEmail1@domain.com", "Subject", body);
               if (status)
               {
                   Response.Write("<script>alert('Mail Sent')</script>");
               }
               else
               {
                   Response.Write("<script>alert('Some error while sending mail')</script>");
               }
            }
            else if (ddltext=="Template2")
            {
                string body = ReadHtml(ddltext);
                bool status = SendHtmlFormattedEmailMailbee("recepientEmail2@domain.com", "Subject", body);
                if (status)
                {
                    Response.Write("<script>alert('Mail Sent')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some error while sending mail')</script>");
                }
                
            }else
            {
                string body = ReadHtml(ddltext);
                bool status = SendHtmlFormattedEmailMailbee("recepientEmail3@domain.com", "Subject", body);
                if (status)
                {
                    Response.Write("<script>alert('Mail Sent')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some error while sending mail')</script>");
                }
            }
        }
        public bool SendHtmlFormattedEmailMailbee(string recepientEmail, string subject, string body)
        {
            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-31F9F661F915F943F9D9C38AF266-7B6";//Demo Key
                MailBee.SmtpMail.Smtp ObjSmtp = new MailBee.SmtpMail.Smtp();
                ObjSmtp.Message.From.AsString = ConfigurationManager.AppSettings["UserName"].ToString();
                ObjSmtp.Message.To.AsString = recepientEmail;
                ObjSmtp.Message.Subject = subject;
                ObjSmtp.Message.BodyHtmlText = body;
                SmtpServer server = new SmtpServer(ConfigurationManager.AppSettings["Host"], ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
                server.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                ObjSmtp.SmtpServers.Add(server);
                ObjSmtp.Send();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
        public string ReadHtml(string filename)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~\\html\\"+filename+".html")))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}
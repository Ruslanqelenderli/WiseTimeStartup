using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.Email
{
    public class EmailHelper
    {
        public bool SendEmail(string userEmail,string subject, string link)
        {
            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("wisetimehr@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("wisetimehr@gmail.com", "qiyrkmziryfrzhwl");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;


            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return false;


        }
    }
}

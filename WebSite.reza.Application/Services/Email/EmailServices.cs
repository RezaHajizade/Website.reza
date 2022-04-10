using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.reza.Application.Services.Email
{
    public class EmailServices
    {
        public Task Execute(string UserEmail,string body,string subject)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 1000000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("rezahajizadedev@gmail.com", "RezahDev9977");
            MailMessage message = new MailMessage("rezahajizadedev@gmail.com", UserEmail, subject, body);
            message.IsBodyHtml = true;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            client.Send(message);
            return Task.CompletedTask;
            

        }
    }
}

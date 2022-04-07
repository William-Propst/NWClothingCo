using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace NWClothingCo.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender() 
        {
        
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromEmail = "nwclothingcoemail@gmail.com";
            string fromPassword = "wdutjhgedplcmkxy";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }
    }
}

using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace GrainImplementation
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        public Task<string> SendEmailAsync(string email)
        {
            //todo send e-mail
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("test39315@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Confirmare";
                mail.Body = "<h1> Intrebarea dumneavoastra a fost publicata <h1>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("test39315@gmail.com", "calultroian73?");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);

                }

            }

                return Task.FromResult(email);
        }
    }
}

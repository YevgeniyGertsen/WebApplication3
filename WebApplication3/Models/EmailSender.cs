using System.Net.Mail;
using System.Net;
using Twilio.TwiML.Messaging;

namespace WebApplication3.Models
{
    public class EmailSender : IMessage
    {
        public bool SendMessage(string to, string subject, string message)
        {
            #region setting send email
            var fromAddress = new MailAddress("gersen.e.a@gmail.com", "From Name");
            var toAddress = new MailAddress(to, "To Name");
            const string fromPassword = "hppc dzmw iull lxvk";
            #endregion

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message
            })
            {
                try
                {
                    smtp.Send(mailMessage);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
    }
}

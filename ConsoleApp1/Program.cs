using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML.Voice;

namespace ConsoleApp1
{
    internal class Program
    {
        //info@satbayevproject.kz
        //$r998r9Zx

        //https://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail
        //hppc dzmw iull lxvk

        static void Main(string[] args)
        {
            var fromAddress = new MailAddress("gersen.e.a@gmail.com", "From Name");
            var toAddress = new MailAddress("gersen.e.a@gmail.com", "To Name");
            const string fromPassword = "hppc dzmw iull lxvk";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message2 = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message2);
            }

            //Recovery code
            //B8MYJLEF8BUZ62AURRPAMNRH


            const string accountSid = "AC96a4253c3d08fa134394648150af0679";
            const string authToken = "874374e4c5d3ce0ae4e9ef93068703ed";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Привет! Это тестовое SMS.",
                from: new PhoneNumber("+18126136069"), // Тестовый номер Twilio
                to: new PhoneNumber("+77772094343") // Кому отправляем
            );

            Console.WriteLine($"SMS отправлено! SID: {message.Sid}");

        }
    }
}

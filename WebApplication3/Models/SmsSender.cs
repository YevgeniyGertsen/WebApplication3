using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;

namespace WebApplication3.Models
{
    public class SmsSender : IMessage
    {
        public bool SendMessage(string to, string subject, string message)
        {
            const string accountSid = "AC96a4253c3d08fa134394648150af0679";
            const string authToken = "874374e4c5d3ce0ae4e9ef93068703ed";

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var result = MessageResource.Create(
                        body: message,
                        from: new PhoneNumber("+18126136069"),
                        to: new PhoneNumber(to));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

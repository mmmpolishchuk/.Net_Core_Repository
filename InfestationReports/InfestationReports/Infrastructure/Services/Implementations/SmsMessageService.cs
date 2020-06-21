using System;
using InfestationReports.Infrastructure.Services.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace InfestationReports.Infrastructure.Services.Implementations
{
    public class SmsMessageService : IMessageService<Sms>
    {
        public void SendMessage()
        {
            const string accountSid = "ACc93fa377e979d6d7c88fdd4704a6e854";
            const string authToken = "5d81447a5a2873d8e4a71161d50c4118";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there!",
                from: new Twilio.Types.PhoneNumber("+13343266271"),
                to: new Twilio.Types.PhoneNumber("+380508375475")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
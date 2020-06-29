using System;
using Castle.Core.Configuration;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using MimeKit;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace InfestationReports.Infrastructure.Services.Implementations
{
    public class MessageSendingService : IMessageService
    {
        private InfestationConfiguration InfestConfiguration { get; }

        public MessageSendingService(IOptions<InfestationConfiguration> options)
        {
            InfestConfiguration = options.Value;
        }
        public void SendMessage(string subject, string text, SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Email:
                {
                    // Add email message
                    MimeMessage email = new MimeMessage();

                    var from = new MailboxAddress("Admin", InfestConfiguration.FromEmail);
                    email.From.Add(@from);

                    var to = new MailboxAddress("User", InfestConfiguration.ToEmail);
                    email.To.Add(to);

                    // 587 port
                    email.Subject = subject;

                    // Add email body
                    BodyBuilder bodyBuilder = new BodyBuilder
                    {
                        TextBody = text,
                        HtmlBody = text
                    };

                    email.Body = bodyBuilder.ToMessageBody();

                    // Send message
                    using (SmtpClient client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                        client.Connect(InfestConfiguration.GoogleSmtpServer, 465, true);
                        client.Authenticate(InfestConfiguration.ToEmail,
                            InfestConfiguration.EmailPassword);
                        client.Send(email);
                        client.Disconnect(true);
                    }

                    break;
                }
                case SenderType.Sms:
                {
                    TwilioClient.Init(InfestConfiguration.AccountSid, InfestConfiguration.AuthToken);

                    var sms = MessageResource.Create(
                        body: subject + "\r\n" + text,
                        @from: new Twilio.Types.PhoneNumber(InfestConfiguration.FromPhone),
                        to: new Twilio.Types.PhoneNumber(InfestConfiguration.ToPhone)
                    );

                    Console.WriteLine(sms.Sid);

                    break;
                }
            }
        }
    }
}
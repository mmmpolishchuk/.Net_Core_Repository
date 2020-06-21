using System.Net.Mail;
using Microsoft.Extensions.Configuration.UserSecrets;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Twilio.TwiML.Voice;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace InfestationReports.Infrastructure.Services.Implementations
{
    public class EmailMessageService : IMessageService<Email>
    {
        public IConfiguration Configuration { get; }

        public EmailMessageService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SendMessage() 
        {
           // Add email message
            MimeMessage message = new MimeMessage();

            var from = new MailboxAddress("Admin", Configuration.GetValue<string>("EmailAddressFrom"));
            message.From.Add(from);

            var to = new MailboxAddress("User", Configuration.GetValue<string>("EmailAddressTo"));
            message.To.Add(to);
            
            // 587 port
            message.Subject = "Email from Admin";

            // Add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Hello Kitty";
            bodyBuilder.HtmlBody = "<h1>Hello Kitty</h1>";

            message.Body = bodyBuilder.ToMessageBody();

            // Send message
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(Configuration.GetValue<string>("EmailAddressTo"),
                    Configuration.GetValue<string>("EmailPass"));
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
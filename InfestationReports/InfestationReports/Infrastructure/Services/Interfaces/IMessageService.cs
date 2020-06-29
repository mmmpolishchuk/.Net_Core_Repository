using InfestationReports.Infrastructure.Services.Implementations;

namespace InfestationReports.Infrastructure.Services.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(string subject, string text, SenderType senderType);
    }

    // public class Email
    // {`
    // }
    //
    // public class Sms
    // {
    // }
}
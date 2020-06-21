namespace InfestationReports.Infrastructure.Services.Interfaces
{
    public interface IMessageService<T>
    {
        void SendMessage();
    }

    public class Email
    {
    }

    public class Sms
    {
    }
}
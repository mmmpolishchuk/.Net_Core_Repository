using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfestationReports.Infrastructure.Configuration
{
    public class InfestationConfiguration
    {
        public string GoogleSmtpServer { get; set; }
        public string FromPhone { get; set; }
        public string ToPhone { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string EmailPassword { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public bool CancelSending { get; set; }
        public int ExpirationCacheTime { get; set; }
        public int DelayTime { get; set; }
        public string ContentType { get; set; }
    }
}
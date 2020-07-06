using System;

namespace InfestationReports.Infrastructure.BackgroundServiceFolder
{
    public static class HelperHostedServiceClass
    {
        public static readonly string CacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
    }
}
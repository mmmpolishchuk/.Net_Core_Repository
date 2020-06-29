using Microsoft.AspNetCore.Builder;

namespace InfestationReports.Infrastructure.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UserInfoSender(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestInfoMiddleware>();
        }
        
        
    }
}
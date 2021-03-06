using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _1.Introduction_StartupClass
{
    public class NotStartupClass
    {
        private IConfiguration _iConfiguration;

        public NotStartupClass(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _1.Introduction._Startup
{
    public class NotStartupClass
    {
        private IConfiguration _iConfiguration;

        public NotStartupClass(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(_iConfiguration["Logging:LogLevel:Microsoft.Hosting.Lifetime"]);
                });
            });
        }
    }
}

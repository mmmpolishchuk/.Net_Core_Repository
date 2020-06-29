using System;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Middlewares;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using InfestationReports.Models.Repositories.NewsRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;

namespace InfestationReports
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<InfestationContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("InfestationDbConnectionNew")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfestationContext>();

            services.AddScoped<INewsRepository, SqlNewsRepository>();
            services.AddScoped<IHumanRepository, SqlHumanRepository>();
            services.AddTransient<IMessageService, MessageSendingService>();

            // використання даних із appsettings.json
            var section = Configuration.GetSection("Infestation");
            var phoneSection = Configuration.GetSection("Infestation:PhoneNumbers");
            var emailsSection = Configuration.GetSection("Infestation:Emails");
            var twilioInfo = Configuration.GetSection("Twilio");

            services.Configure<InfestationConfiguration>(section);
            services.Configure<InfestationConfiguration>(phoneSection);
            services.Configure<InfestationConfiguration>(emailsSection);
            services.Configure<InfestationConfiguration>(twilioInfo);

            services.AddDbContext<InfestationContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("InfestationDbConnectionNew"))
                    .UseLazyLoadingProxies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseWhen(context => context.Request.Path == "/Human/Create", builder => { builder.UserInfoSender(); });

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=News}/{action=Index}/{id?}");
            });
        }
    }
}

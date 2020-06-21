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
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<InfestationContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("InfestationDbConnectionNew")));
            services.AddScoped<INewsRepository, SqlNewsRepository>();
            services.AddScoped<IHumanRepository, SqlHumanRepository>();
            services.AddScoped<IMessageService<Sms>, SmsMessageService>();
            services.AddScoped<IMessageService<Email>, EmailMessageService>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<InfestationContext>();
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using HeyCurator_MVC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HeyCurator_MVC.HostedServices;
using HeyCurator_MVC.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HeyCurator_MVC.MessageService;
using HeyCurator_MVC.ActionFilters;
using HeyCurator_MVC.Hubs;

namespace HeyCurator_MVC
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSession();

            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(GlobalRouting));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            
            services.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            /* IHostedServices  */
            services.AddHostedService<InventoryControlBackgroundService>();
            // Hoster Service Event Trigger
            services.AddSingleton<ICBEventTrigger>();

            /* Database Accessing Services */
            services.AddScoped<DataAccessService>();
            services.AddScoped<DatabaseListService>();
            services.AddScoped<CreateService>();
            services.AddScoped<HeyCuratorMailService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<ItemCountService>();
            services.AddScoped<RecordAccessService>();
            services.AddScoped<ExpiredItemUpdateService>();
            services.AddScoped<LowItemCountService>();
            /* Model Behind the scenes services for auto creating values and relations */
            services.AddScoped<ItemDateService>();

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
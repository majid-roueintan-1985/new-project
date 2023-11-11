using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bnpp.Web
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
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc();
            services.AddRazorPages();

            

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/home/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            #endregion

            #region DataBase Context

            services.AddDbContext<BnppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BnppConnection"));
            });

            services.AddDbContext<ChemistryContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ChemistryDBConnection"));
            });

            services.AddDbContext<TransientContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TransientDBConnection"));
            });
            #endregion

            #region IoC  

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMechanicalService, MechanicalService>();
            services.AddTransient<IElectricalService, ElectricalService>();
            services.AddTransient<IStructureService, StructureService>();
            services.AddTransient<IOperationalService, OperationalService>();
            services.AddTransient<IManagementServise, ManagementServise>();
            services.AddTransient<IBasicDataService, BasicDataService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IMechanismService, MechanismService>();
            services.AddTransient<ICommissioningService, CommissioningService>();
            services.AddTransient<ISensorService, SensorService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IMaintenanceService,MaintenanceService>();
            services.AddTransient<IInspectionService,InspectionService>();
            services.AddTransient<IChangeService,ChangeService>();
            services.AddTransient<IBackupService,BackupService>();
            services.AddTransient<IDamageabilityService, DamageabilityService>();
            services.AddTransient<IUnitsService, UnitsService>();
            #region Chemistry
            services.AddTransient<IChemistryService, ChemistryService>();

            #endregion

            #region Transient
            services.AddTransient<ITransientService, TransientService>();
            #endregion

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Not Found Page
            //app.Use(async (context, next) =>
            //{
            //    await next();

            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Response.Redirect("Access Denied");
            //    }
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("login.html");
            //app.UseDefaultFiles(options);


            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                    name: "MyAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(

                    name: "Default",
                    pattern: "{controller=Home}/{action=Login}/{id?}"
                );
            });
            
        }
    }
}

using DNELms.Data;
using DNELms.Model;
using DNELms.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DNELms.Dapper;
using Microsoft.AspNetCore.Identity;
using DNELms.ModelMappers;
using DNELms.DBContexts.Data;
using DNELms.DBContexts.NoSchoolContext;
using DNELms.DBContexts.SchoolContext;
using DNELms.BAL;
using DNELms.Core.Infrastructure;
using DNELms.Core;
using Autofac;
using DNELms.DataRepository;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System;

namespace DNELms
{
    public class Startup
    {
        IEngine engine;
        IWebHostEnvironment _webHostEnvironment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        IServiceCollection services;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.services = services;
            #region DBContexts

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DNELmsContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<NoSchoolContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            services.AddDatabaseDeveloperPageExceptionFilter();
            
            #region Identity


            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var externalConfig = Configuration.GetSection("ExternalAuth").Get<ExternalAuth>();
            services.Configure<ApplicationUser>(Configuration.GetSection("ApplicationUser"));
            services.Configure<ExternalAuth>(Configuration.GetSection("ExternalAuth"));
            #endregion

            #region Angular's
            services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                 .AddProfileService<CustomProfileService>();
            var authBuilder = services.AddAuthentication();
            if (externalConfig.GoogleEnabled)
            {
                authBuilder.AddGoogle(g =>
                {
                    g.ClientId = externalConfig.GoogleClientId;
                    g.ClientSecret = externalConfig.GoogleClientSecret;
                });
            }
            if (externalConfig.FaceBookEnabled)
            {
                authBuilder.AddFacebook(f =>
                {
                    f.AppId = externalConfig.FaceBookAppId;
                    f.AppSecret = externalConfig.FaceBookAppSecret;
                });
            }
            
            authBuilder.AddIdentityServerJwt();
            #endregion

            #region Common

            services.AddModelMapper();
            services.AddDapper();
            services.AddControllersWithViews();
            var razor = services.AddRazorPages();
#if DEBUG
            razor.AddRazorRuntimeCompilation();
#endif
         //   _logger.LogInformation("#if DEBUG");
            services.AddDataRepositry();
            services.AddDependencies();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/DNELms";
            });
            #endregion
     
            #region RegisterAutoFac/CoreFeatures
            engine = EngineContext.Create();
            CommonHelper.DefaultFileProvider = new DNEFileProvider(_webHostEnvironment.WebRootPath);
            #endregion
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "D.N.E LMS", Version = "v1" });
            });
        } 
        public void ConfigureContainer(ContainerBuilder builder)
        {
           engine.RegisterDependencies(builder, services.BuildServiceProvider());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> _logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "D.N.E LMS v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            _logger.LogInformation("First con");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            _logger.LogInformation("2nd con");
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                       name: "api",
                       areaName: "api",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "api-noa",
                    areaName: "api",
                    pattern: "{area:exists}/{controller=Home}/{id?}");
                endpoints.MapRazorPages();
            });
            _logger.LogInformation("routing");
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            _logger.LogInformation("spa");
        }
    }
}

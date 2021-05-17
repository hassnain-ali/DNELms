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

namespace DNELms
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

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var externalConfig = Configuration.GetSection("ExternalAuth").Get<ExternalAuth>();
            services.Configure<ApplicationUser>(Configuration.GetSection("ApplicationUser"));
            services.Configure<ExternalAuth>(Configuration.GetSection("ExternalAuth"));
            #region Angular's
            services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                 .AddDeveloperSigningCredential()
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
            services.AddDapper();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

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
        }
    }
}

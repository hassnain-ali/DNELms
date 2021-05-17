using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

[assembly: HostingStartup(typeof(DNELms.Areas.Api.ApiHostingStartup))]
namespace DNELms.Areas.Api
{
    public class ApiHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                //{
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidateLifetime = true,
                //        ValidateIssuerSigningKey = true,
                //        ValidIssuer = context.Configuration["Jwt:Issuer"],
                //        ValidAudience = context.Configuration["Jwt:Issuer"],
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["Jwt:Key"]))
                //    };
                //});
                // configure strongly typed settings object
                //services.AddTransient<IStartupFilter, ApiHostingConfigureFilter>();
                services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.WriteIndented = false;
                });
                //services.AddControllers().AddNewtonsoftJson(x =>
                //{
                //    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                //    x.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //    x.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                //});
            });
        }

    }
    //public class ApiHostingConfigureFilter : IStartupFilter
    //{
    //    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    //    {
    //        return app =>
    //        {
    //            app.UseMiddleware<JwtMiddleware>();
    //            next(app);
    //        };
    //    }
    //}
}

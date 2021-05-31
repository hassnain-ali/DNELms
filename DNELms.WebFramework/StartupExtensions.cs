using DNELms.WebFramework.EmailSend;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace DNELms.WebFramework
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddEmailSenders(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped((serviceProvider) =>
            {
                return new SmtpClient()
                {
                    Host = config.GetValue<string>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    Credentials = new NetworkCredential(
                            config.GetValue<string>("Email:Smtp:Username"),
                            config.GetValue<string>("Email:Smtp:Password")
                        ),
                    EnableSsl = config.GetValue<bool>("Email:Smtp:EnableSsl")
                };
            });
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
    }
}

using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DNELms.Areas.Identity.IdentityHostingStartup))]
namespace DNELms.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
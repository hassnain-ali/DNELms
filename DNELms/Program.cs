using Autofac.Extensions.DependencyInjection;
using DNELms.Keys;
using DNELms.Models;
using DNELms.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DNELms
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (IServiceScope services = host.Services.CreateScope())
            {
                await CreateDefaults(services.ServiceProvider);
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        #region Defaults
        static async Task CreateDefaults(IServiceProvider service)
        {
            UserManager<ApplicationUser> userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var item in new AspNetUserRoles().AsEnumerable())
            {
                if (!await roleManager.Roles.AnyAsync(s => s.Name.Equals(item.Value)))
                {
                    await roleManager.CreateAsync(new(item.Value) { NormalizedName = item.Value.ToUpper() });
                }
            }
            ApplicationUser defaultUserModel = service.GetRequiredService<IOptions<ApplicationUser>>().Value;
            ApplicationUser identityUser = defaultUserModel;
            if (await userManager.FindByEmailAsync(identityUser.Email) == null)
            {
                var result = await userManager.CreateAsync(identityUser);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(identityUser, defaultUserModel.FlatPassword);
                    await userManager.AddToRoleAsync(identityUser, AspNetUserRoles.Admin.ToString());
                }
            }
        }
        #endregion
    }
}

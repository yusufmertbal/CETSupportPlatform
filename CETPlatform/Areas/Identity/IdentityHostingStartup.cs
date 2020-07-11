using System;
using CETPlatform.Areas.Identity.Data;
using CETPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CETPlatform.Areas.Identity.IdentityHostingStartup))]
namespace CETPlatform.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CETPlatformContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CETPlatformContextConnection")));

                services.AddDefaultIdentity<CETPlatformUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<CETPlatformContext>();
            });
        }
    }
}
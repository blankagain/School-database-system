using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School_1.Areas.Identity.Data;
using School_1.Data;

[assembly: HostingStartup(typeof(School_1.Areas.Identity.IdentityHostingStartup))]
namespace School_1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<School_1Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("School_1ContextConnection")));

                services.AddDefaultIdentity<School_1User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<School_1Context>();
            });
        }
    }
}
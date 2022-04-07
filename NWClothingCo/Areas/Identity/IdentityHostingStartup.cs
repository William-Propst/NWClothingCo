using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NWClothingCo.Areas.Identity.Data;
using NWClothingCo.Data;

[assembly: HostingStartup(typeof(NWClothingCo.Areas.Identity.IdentityHostingStartup))]
namespace NWClothingCo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NWClothingCoDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NWClothingCoDbContextConnection")));

                services.AddDefaultIdentity<NWClothingCoUser>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                    .AddEntityFrameworkStores<NWClothingCoDbContext>();
            });
        }
    }
}
using System;
using BikeRentalMVC.Areas.Identity.Data;
using BikeRentalMVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BikeRentalMVC.Areas.Identity.IdentityHostingStartup))]
namespace BikeRentalMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BikeRentalMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BikeRentalMVCContextConnection")));

                services.AddDefaultIdentity<BikeRentalMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BikeRentalMVCContext>();
            });
        }
    }
}
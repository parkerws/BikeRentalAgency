using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Context;
using BikeRentalAgency.Controllers;
using BikeRentalAgency.Data;
using BikeRentalAgency.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BikeRentalAgency
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
            services.AddControllers();
            services.AddDbContext<BikeRentalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserDatabase")));
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("IdentityDatabase")));
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>()
            //    .AddDefaultTokenProviders();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                    //name: "default",
                    //pattern: "{controller=admin}/{action=bikes}");
            });
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}

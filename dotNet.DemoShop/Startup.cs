using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.DemoShop.Models;
using dotNet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNet.DemoShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /* appsetting gets read out and arrives in an instance of IConfiguration
           which get passed into the application via constructor injection */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // services collection
        // instances are created with addScoped() and can be used through constructor injection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            /* bring in basic functionality for working with Identity -> Indicate Identity needs 
               Entity Framework to store its data */
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            // method to register a service with its interfaces into the services collection
            // Create an instance per request, which remains active throughout the entire request
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            // invoke the GetCart() method on the ShoppingCart class for the user
            // IServiceProvider
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            // bring in support for GetCart()
            services.AddHttpContextAccessor();
            services.AddSession();
            // add all the services will be used in the application
            services.AddControllersWithViews();
            // add support for Razor Pages
            services.AddRazorPages();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // middleware for debugging messages 
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // middleware for serving static files and files in wwwroot
            app.UseStaticFiles();
            // middleware to support session
            // MUST called before routing
            app.UseSession();


            // convention-based routing
            app.UseRouting();
            // enable to use ASP.NET Core Identity
            // Register/Login/Logout functions
            app.UseAuthentication();
            // Must login or have the access right before accessing to certain pages
            app.UseAuthorization();

            // map an incoming request with an action on a controller
            app.UseEndpoints(endpoints =>
            {
                // see https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}");
                // add endpoint for Razor Page
                endpoints.MapRazorPages();
                
            });
        }
    }
}

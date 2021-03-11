using Assignment_5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Add DbContext to this service a booksotredbcontext type, and passing in options
            services.AddDbContext<BookstoreDbContext>(options =>
           {
               //sets the options to use sqlserver to access what's connected to the connection string
               options.UseSqlite(Configuration["ConnectionStrings:OnlineBookstoreConnection"]);
           });
            //Each request will get its own repository
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            //Add this service to our project
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Sets up a session when the site is loaded
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Not sure what this one did, but helped with highlighting the correct link
                endpoints.MapControllerRoute("catpage",
                   "{category}/{page:int}",
                   new { Controller = "Home", action = "Index" });

                //This will improve the URL/Route looks
                endpoints.MapControllerRoute(
                    "pagination", "Projects/{page}", 
                    new { Controller = "Home", action = "Index", page = 1 });

                //Gives the user the ability to filter by category, ex. "/..."
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}

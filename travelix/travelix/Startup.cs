using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;
using travelix.Service;

namespace travelix
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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddMvc();

            services.AddDbContext<TravelixContext>(item => item.UseSqlServer(Configuration.GetConnectionString("TravelixConnect")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GennericRepository<>));
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBookTourService, BookTourService>();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Dashboard",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=Dashboard}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "SignInAdmin",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=SignIn}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Tour",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=Tour}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Customer",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=Customer}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "News",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=News}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Address",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=Address}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "BookTour",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=BookTour}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "ProfileAdmin",
                    areaName: "Administrator",
                    pattern: "Administrator/{controller=Profile}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "HomePage",
                    areaName: "User",
                    pattern: "User/{controller=HomePage}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "SignInSignUp",
                    areaName: "User",
                    pattern: "User/{controller=SignInSignUp}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "TourList",
                    areaName: "User",
                    pattern: "User/{controller=TourList}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "NewsList",
                    areaName: "User",
                    pattern: "User/{controller=NewsList}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "TourDetail",
                    areaName: "User",
                    pattern: "User/{controller=TourDetail}/{action=Index}/{id?}");
            });
        }
    }
}

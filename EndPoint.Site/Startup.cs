using EndPoint.Site.Helpers;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Carts;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;
using WebSite.reza.Application.Services.Common.Queries.GetSlider;
using WebSite.reza.Application.Services.Finances.Commands.AddRequestPay;
using WebSite.reza.Application.Services.Finances.Queries.GetRequestPay;
using WebSite.reza.Application.Services.HomePages.AddNewSlider;
using WebSite.reza.Application.Services.HomePages.Commands.AddHomePageImages;
using WebSite.reza.Application.Services.HomePages.Queries.GetHomePageImages;
using WebSite.reza.Application.Services.Orders.Commands.AddNewOrder;
using WebSite.reza.Application.Services.Orders.Queries;
using WebSite.reza.Application.Services.Orders.Queries.GetOrdersForAdmin;
using WebSite.reza.Application.Services.Orders.Queries.GetRequestPayForAdmin;
using WebSite.reza.Application.Services.Products.Facade_Pattern;
using WebSite.reza.Application.Services.Products.FacadePattern;
using WebSite.reza.Application.Services.Users.Commands.UserStatusChange;
using WebSite.reza.Common.Roles;
using WebSite.reza.Domain.Entities.Users;
using WebSite.reza.Persistence.Contexts;
using static EndPoint.Site.Helpers.AddMyClaims;

namespace EndPoint.Site
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


            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/SignIn");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/SignIn");
            });



            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();



            //FacadInject
            services.AddScoped<IProductFacadForAdmin, ProductFacadForAdmin>();
            services.AddScoped<IProductFacadForSite, ProductFacadForSite>();


            //.................
            services.AddScoped<IAddNewSliderService, AddNewSliderService>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageImageService, AddHomePageImageService>();
            services.AddScoped<IGetHomePageImageService, GetHomePageImageService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<CookiesManager, CookiesManager>();
            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService, GetRequestPayService>();
            services.AddScoped<IAddNewOrderService, AddNewOrderService>();
            services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
            services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();








            //services.AddDbContext<DataBaseContext>(
            //    p => p.UseSqlServer("DefaultConnection"));

            string ConectionString = @"Data Source=DESKTOP-Q2K2KBR;Initial Catalog=Reza-StoreDb2;Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(ConectionString));

            services.AddControllersWithViews();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<Role>()
                .AddErrorDescriber<CustomIdentityError>();


            services.Configure<IdentityOptions>(option =>
            {
                //user setting
                option.User.RequireUniqueEmail = true;


                //password setting
                option.Password.RequiredLength = 6;

                //LokOut setting
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);


            
            });

            services.ConfigureApplicationCookie(option =>
            {
                //cookie setting
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                option.LoginPath = "/Account/login";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.SlidingExpiration = true;
            });

            // services.AddScoped<IUserClaimsPrincipalFactory<User>, AddMyClaims>();
            services.AddScoped<IClaimsTransformation, AddClaim>();   

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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

              
            });
        }
    }
}

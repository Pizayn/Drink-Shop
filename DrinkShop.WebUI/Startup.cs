using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Business.Abstract;
using Drink.Business.Concrete;
using Drink.DataAccess.Abstract;
using Drink.DataAccess.Concrete;
using DrinkShop.Business.Abstract;
using DrinkShop.Business.Concrete;
using DrinkShop.WebUI.Entities;
using DrinkShop.WebUI.MiddleWares;
using DrinkShop.WebUI.Services;
using DrinkShop.WebUI.ValidationRules;
using DrinkShopCore.DataAccess.Abstract;
using DrinkShopCore.DataAccess.Concrete;
using DrinkShopCore.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkShop.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddFacebook(options =>
                {
                    options.AppId = "337741160193357";
                    options.AppSecret = "4e7b87b68cf2bc398fabc1cad8047fdc";
                })

                .AddCookie();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddScoped<IOrderLineService, OrderLineManager>();
            services.AddScoped<IOrderLineDal, OrderLineDal>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();

            services.AddScoped<ISubCategoryDal, SubCategoryDal>();
            

            services.AddDbContext<CustomIdentityDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DrinkShop;Trusted_Connection=true "));
          
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddSession();
            services.AddDistributedMemoryCache();//bunu eklemezsek session aktifleştirilmemiş hatası alınır



            services.AddMvc();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();

            app.UseAuthentication();
           
           
            app.UseMvcWithDefaultRoute();
            
           
        }
    }
}

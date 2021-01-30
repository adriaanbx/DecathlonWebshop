using DecathlonWebshop.Auth;
using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using DecathlonWebshop.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop
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
            services.AddDbContextPool<AppDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
             {
                 options.Password.RequiredLength = 8;
                 options.Password.RequireNonAlphanumeric = true;
                 options.Password.RequireUppercase = true;
                 options.User.RequireUniqueEmail = true;
             })
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();

            services.AddAuthentication().AddGoogle(o =>
            {
                o.ClientId = Configuration["Authentication:Google:ClientId"];
                o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            //add anti forgery, against CSRF = Cross Site Request Forgery, as a global filter
            //will automatically include antiforgeryvalidation on all potentially unsafe requests like a post and a put
            services.AddMvc(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            //services.AddAntiforgery();  

            //Add controller localization
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            //Add view localization
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                options => { options.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("fr"),
                        new CultureInfo("nl"),
                        new CultureInfo("en-US"),
                    };

                    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                });

            services.AddAuthorization(Options =>
            {
                Options.AddPolicy("DeleteProduct", policy => policy.RequireClaim("Delete Product", "Delete Product")); //Claims-based authorization
                Options.AddPolicy("AddProduct", policy => policy.RequireClaim("Add Product", "Add Product")); //Claims-based authorization
                Options.AddPolicy("MinimumOrderAge", policy => policy.Requirements.Add(new MinimumOrderAgeRequirement(18))); //Policy-based authorization
            });

            services.AddControllersWithViews();

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

            app.UseAuthentication();
            app.UseAuthorization();

            //Check the culture of the incoming request for the translations
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

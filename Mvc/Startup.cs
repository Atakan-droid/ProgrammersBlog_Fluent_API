using Business.AutoMapper.Profiles;
using Business.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mvc
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile),typeof(ArticleProfile));
            services.LoadMyServices();
            services.ConfigureApplicationCookie(options=> 
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Admin/User/Login");
                options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Amin/User/Logout");
                options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name="ProgrammersBlog",
                    HttpOnly=true, //only server site 
                    SameSite=Microsoft.AspNetCore.Http.SameSiteMode.Strict, //look strict only our site
                    SecurePolicy=Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest, //has to be ALWAYS
                };
                //user after logged in they don't need to login again at least 7 days
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Admin/User/AccessDenied");
                
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); //page status
            }
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name:"Admin",
                    areaName:"Admin",
                    pattern:"Admin/{controller=Home}/{action=index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute(); //default home controller
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace mvc_basics_assign_1_3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddMvc()//enable ous to use MVC
                .AddRazorRuntimeCompilation();//needed if you want to use and use Browserlink & one more line of code in the Configure method below.
                                              // also need to install two NuGet packages
                                              // 1: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
                                              //    controll its the right version 3.1.10 for a Core 3.1 MVC project.
                                              // 2: Microsoft.VisualStudio.Web.BrowserLink
                                              //    controll its the right version 2.2.0 for a Core 3.1 MVC project.
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();//needed if you want to use and use Browserlink & one more line of code in the ConfigureServices method above.
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();//opens up access to the wwwroot folder so we can use our files there like css/javascript/images...
            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "CompareNumber",
                    pattern: "GuessingGame",
                    defaults: new { controller = "CompareNumber", action = "TestNumber" });

                endpoints.MapControllerRoute(
                    name: "Temperature",
                    pattern: "Fever-Check-Model",
                    defaults: new { controller = "TemperatureModel", action = "CheckModel" });

                endpoints.MapControllerRoute(
                    name: "checkFever",
                    pattern: "Fever-Check",
                    defaults: new { controller = "Temperature", action = "Check" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            // Загружаем отдельные элементы для вставки в шаблон: боковое меню и футер
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "views", "shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "views", "shared", "sideBar.html"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "index.html");

                    // Загружаем шаблон страницы, вставляя в него элементы
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/testing", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "testing.html");

                    // Загружаем шаблон страницы, вставляя в него элементы
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/about", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "about.html");

                    // Загружаем шаблон страницы, вставляя в него элементы
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/static/css/index.css", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "css", "index.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });

                endpoints.MapGet("/static/css/about.css", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "css", "about.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });


                endpoints.MapGet("/static/js/index.js", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "js", "index.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });

                endpoints.MapGet("/static/js/testing.js", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "js", "testing.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });

                endpoints.MapGet("/static/js/about.js", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "js", "about.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            });
        }
    }
}
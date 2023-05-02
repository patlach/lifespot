using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Text;

namespace LifeSpot
{
    public static class EndpointsMapper
    {
        /// <summary>
        /// Mapping Css files
        /// </summary>
        /// <param name="builder"></param>
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "index.css", "about.css" };

            foreach (var file in cssFiles)
            {
                builder.MapGet($"/static/css/{file}", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "css", file);

                    var css = await File.ReadAllTextAsync(cssPath);

                    await context.Response.WriteAsync(css);
                });
            }
        }

        /// <summary>
        /// Mapping JS files
        /// </summary>
        /// <param name="builder"></param>
        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "about.js", "testing.js" };

            foreach (var file in jsFiles)
            {
                builder.MapGet($"/static/js/{file}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "static", "js", file);

                    var js = await File.ReadAllTextAsync(jsPath);

                    await context.Response.WriteAsync(js);
                });
            }
        }

        /// <summary>
        /// Mapping HTML files
        /// </summary>
        /// <param name="builder"></param>
        public static void MapHtml(this IEndpointRouteBuilder builder)
        {
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "views", "shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "views", "shared", "sidebar.html"));
            string sliderHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "views", "shared", "slider.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "index.html");
                var viewText = await File.ReadAllTextAsync(viewPath);

                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/testing", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "testing.html");
                var viewText = await File.ReadAllTextAsync(viewPath);

                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/about", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "views", "about.html");
                var viewText = await File.ReadAllTextAsync(viewPath);

                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml)
                    .Replace("<!--SLIDER-->", sliderHtml);

                await context.Response.WriteAsync(html.ToString());
            });
        }

        /// <summary>
        /// Mapping Image files
        /// </summary>
        /// <param name="builder"></param>
        public static void MapImage(this IEndpointRouteBuilder builder)
        {
            var imageFiles = new[] { "london.jpg", "ny.jpg", "spb.jpg" };

            foreach (var file in imageFiles)
            {
                builder.MapGet($"/static/image/{file}", async context =>
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "static", "image", file);

                    var image = await File.ReadAllBytesAsync(imagePath);

                    await context.Response.Body.WriteAsync(image);
                });
            }
        }
    }
}

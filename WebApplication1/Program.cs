using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Text;
using System.Text.RegularExpressions;
using WebApplication1.Interface;
using WebApplication1.Interface.Realization;
using WebApplication1.Middleware;
using WebApplication1.Service;
using static System.Net.WebRequestMethods;

namespace WebApplication1
{
    class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IParsing, ParseCatFacts>();
            builder.Services.AddTransient<IParsing, ParseCoinDesk>();
            builder.Services.AddTransient<ParsingService>();
            

            var app = builder.Build();

            app.UseMiddleware<ParsingMiddleware>();
            app.UseWhen(context => context.Request.Path.Equals("/"), app =>
            {
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.SendFileAsync("html/Index.html");
                });

            });

            app.Run();

        }

      
    }

}


using WebApplication1.Interface;
using WebApplication1.Interface.Realization;
using WebApplication1.Service;

namespace WebApplication1.Middleware
{
    public class ParsingMiddleware
    {
        private RequestDelegate _next;

        public ParsingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Equals("/ParseCatFact"))
            {
                ParsingService service = new ParsingService(new ParseCatFacts());
                await service._parsing.Parse(context.Request);
                try
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("html/Parsing.html");
                }
                catch
                {
                    await context.Response.WriteAsync("Не получилось :(");
                }

            }
            else if (context.Request.Path.Equals("/ParseCoinDesk"))
            {
                ParsingService service = new ParsingService(new ParseCoinDesk());
                await service._parsing.Parse(context.Request);
                try
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("html/Parsing.html");
                }
                catch
                {
                    await context.Response.WriteAsync("Не получилось :(");
                }
            }
            else
            {
                await _next.Invoke(context);
            }
            
            
        }
    }
}

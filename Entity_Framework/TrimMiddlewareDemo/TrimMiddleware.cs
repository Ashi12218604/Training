using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class TrimMiddleware
{
    private readonly RequestDelegate _next;

    public TrimMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
        {
            var body = await reader.ReadToEndAsync();

            // remove extra spaces
            body = body.Replace("   ", "").Replace("  ", "");

            var bytes = Encoding.UTF8.GetBytes(body);

            context.Request.Body = new MemoryStream(bytes);
            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}
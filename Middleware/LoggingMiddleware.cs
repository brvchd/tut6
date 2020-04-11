using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tut6.Services;

namespace tut6.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IDbService dbSerivce)
        {
            string path = httpContext.Request.Path;
            string queryString = httpContext.Request?.QueryString.ToString();
            string method = httpContext.Request.Method.ToString();
            string bodyParameters = String.Empty;

            using(var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true ))
            {
                bodyParameters = await reader.ReadToEndAsync();
            }

            var LogWriter = new FileStream("requestLog.txt", FileMode.Create);
            using(var writer = new StreamWriter(LogWriter))
            {
                string text = $"Path: {path} \nQueryString:{queryString} \nMethod: {method} \nBody Parameters: {bodyParameters}";
                writer.WriteLine(text);
            }

            await _next(httpContext);
        }

    }
}
 
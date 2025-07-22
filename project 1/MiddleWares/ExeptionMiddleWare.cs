using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using project_1.Errors;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace project_1.MiddleWares
{
    public class ExeptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExeptionMiddleWare> logger;
        private readonly IHostEnvironment environment;

        public ExeptionMiddleWare(RequestDelegate next, ILogger<ExeptionMiddleWare> logger, IHostEnvironment environment)
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context); //move to next middleware
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                //log ex at database 
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                var exceptionErrorResponse = environment.IsDevelopment() ?
                    new ApiExeptionResponse(500, ex.Message, ex.StackTrace.ToString())
                    :
                    new ApiExeptionResponse(500);

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(exceptionErrorResponse,options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace SGRH.Api.Middleware
{
    public class GlobalExecptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExecptionMiddleware> _logger;

        public GlobalExecptionMiddleware(ILogger<GlobalExecptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new ProblemDetails 
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Error en el Servidor",
                    Title = "Error en el SServidor",
                    Detail = "Ha ocurrido un error en nuestro servidor"
                };

                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
                    
            }

        }
    }
}

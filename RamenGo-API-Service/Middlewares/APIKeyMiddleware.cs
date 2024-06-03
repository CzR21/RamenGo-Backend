using Microsoft.AspNetCore.Cors;
using RamenGo_API_Application.Models;
using RamenGo_API_Domain.Options;

namespace RamenGo_API_Service.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly APIKeyOption _apiKeyOption;

        public APIKeyMiddleware(RequestDelegate next, APIKeyOption apiKeyOption)
        {
            _next = next;
            _apiKeyOption = apiKeyOption;
        }

        //[EnableCors("AllowAllOrigins")]
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey) || !_apiKeyOption.Secret.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsJsonAsync(new ErrorModel()
                {
                    Error = "x-api-key header missing"
                });
                
                return;
            }
            else
            {
                await _next(context);
            }
        }
    }
}

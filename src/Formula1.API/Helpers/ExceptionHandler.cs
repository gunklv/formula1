using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleErrorAsync(HttpContext httpContext, Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";

            string responseMessage = $"{httpContext.Response.StatusCode} - {exception.Message}";

            return httpContext.Response.WriteAsync(responseMessage);
        }
    }
}

﻿namespace HAN.OOSE.ICDE.API.Middleware
{
    public class HttpRequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpRequestLoggerMiddleware> _logger;

        public HttpRequestLoggerMiddleware(RequestDelegate next, ILogger<HttpRequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            _logger.LogInformation($"Incomming: HTTP {request.Method} {request.Path}");

            await _next(context);

            var response = context.Response;

            _logger.LogInformation($"Outgoing: HTTP-code {response.StatusCode}");
        }
    }
}

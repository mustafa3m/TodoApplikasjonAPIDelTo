﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TodoApplikasjonAPIDelTo.Middleware

{

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"HTTP {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Response status code: {context.Response.StatusCode}");
        }
    }



}

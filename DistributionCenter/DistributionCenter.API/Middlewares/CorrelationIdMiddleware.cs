using DistributionCenter.Core;
using DistributionCenter.Core.Contexts.CorrelationId;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DistributionCenter.API.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public CorrelationIdMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.Headers.TryGetValue(Constants.HttpContextHeaderKeys.CORRELATION_ID, out var correlationIds);
            var correlationId = correlationIds.FirstOrDefault() ?? Guid.NewGuid().ToString();

            if (!Guid.TryParse(correlationId, out Guid guidCorrelationId))
            {
                context.Response.StatusCode = 400;
                var responseMessage = $"The header {Constants.HttpContextHeaderKeys.CORRELATION_ID} has invalid format. The expected format is Guid.";
                await context.Response.WriteAsJsonAsync(responseMessage);

                _logger.LogError(
                    new ArgumentException(responseMessage, nameof(correlationId)), 
                    $"Exception occurred while handling CorrelationId"
                );
                return;
            }

            if (!string.IsNullOrWhiteSpace(CorrelationIdContext.GetCorrelationId()))
            {
                context.Response.StatusCode = 400;
                var responseMessage = $"The header {Constants.HttpContextHeaderKeys.CORRELATION_ID} is already set for the context";
                await context.Response.WriteAsJsonAsync(responseMessage);

                _logger.LogError(
                    new InvalidOperationException(responseMessage), 
                    "Exception occurred while handling CorrelationId"
                );
                return;
            }

            CorrelationIdContext.SetCorrelationId(correlationId);
            context.Items[Constants.HttpContextHeaderKeys.CORRELATION_ID] = correlationId;

            // Serilog
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next.Invoke(context);
            }
        }
    }
}

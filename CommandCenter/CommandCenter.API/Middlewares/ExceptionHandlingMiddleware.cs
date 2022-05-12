using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CommandCenter.Core.Extensions;
using CommandCenter.Core.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CommandCenter.Core.Resources.Base;
using CommandCenter.Core;

namespace CommandCenter.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, $"NotFoundException occured");
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.NotFound,
                    ex.Message,
                    ex.InnerException?.Message ?? Constants.DEFAULT_ERROR_MESSAGE
                );
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError(ex, $"ModelValidationException occured");
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.InternalServerError,
                    ex.Message,
                    ex.InnerException?.Message ?? Constants.DEFAULT_ERROR_MESSAGE,
                    ex.Errors
                );
            }
            catch (DomainException ex)
            {
                _logger.LogError(ex, $"DomainException occured");
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.InternalServerError,
                    ex.Message,
                    ex.InnerException?.Message ?? Constants.DEFAULT_ERROR_MESSAGE
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured");
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.BadRequest,
                    ex.Message,
                    ex.InnerException?.Message ?? Constants.DEFAULT_ERROR_MESSAGE
                );
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            string title,
            string? detail
            )
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;

            await httpContext.Response.WriteAsync(
                new ErrorDetailsResource((int)httpStatusCode, title, detail).ToJson());
        }

        private async Task HandleExceptionAsync(
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            string title,
            string? detail,
            IReadOnlyDictionary<string, IEnumerable<string>> errors
            )
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;

            await httpContext.Response.WriteAsync(
                new ErrorDetailsResource((int)httpStatusCode, title, detail, errors).ToJson());
        }
    }
}

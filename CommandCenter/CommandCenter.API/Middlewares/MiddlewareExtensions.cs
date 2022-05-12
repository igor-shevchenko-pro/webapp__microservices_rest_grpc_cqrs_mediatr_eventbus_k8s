using Microsoft.AspNetCore.Builder;

namespace CommandCenter.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationId.CorrelationIdMiddleware>();
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

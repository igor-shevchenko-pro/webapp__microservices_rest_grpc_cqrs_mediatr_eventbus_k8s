using Microsoft.AspNetCore.Builder;

namespace DistributionCenter.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdMiddleware>();
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Wolfife.Common.Middlewares;

namespace Wolfife.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 请求日志记录中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
        /// <summary>
        /// 异常处理中间件, 放置在UseEndpoints()前即可
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomizedExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
        /// <summary>
        /// 未认证请求返回信息处理中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomizedAuthorizationHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UnAuthenticTokenMiddleware>();
        }
        /// <summary>
        /// 处理Get的Options请求
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseOptionsRequestHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<OptionsMiddleware>();
        }
    }
}

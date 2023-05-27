using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Wolfife.Common.Exceptions;

namespace Wolfife.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private const string CONTENT_TYPE = "application/json;charset=utf-8";

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                var features = context.Features;
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task HandleException(HttpContext context, Exception e)
        {
            var errorData = await ExceptionHandler.HandleExceptionAsync(e);
            var statusCode = errorData.statusCode;

            string errorMessage = errorData.loggerMessage;

            //log error to file
            var ip = context.Connection.RemoteIpAddress.ToString();
            _logger.LogError($"主机IP:{ip},错误信息：{errorMessage}");
            _logger.LogWarning($"Exception Type: {e.GetType().Name}");

            var returnDtoJsonString = errorData.headerResultJsonString;

            context.Response.ContentType = CONTENT_TYPE;
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(returnDtoJsonString);
        }
    }
}
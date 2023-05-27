using System;
using System.Net;
using System.Threading.Tasks;
using Wolfife.Common.Config;
using Wolfife.Common.Extensions;

namespace Wolfife.Common.Exceptions
{
    public class ExceptionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public ExceptionHandler() { }
        public static bool IsProduct => ConfigurationManager.CurrentEnvironment == "Product";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static async Task<(string headerResultJsonString, string loggerMessage, HttpStatusCode statusCode)>
            HandleExceptionAsync(Exception e)
        {
            var statusCode =
                e is CustomizedBaseException || e is ArgumentNullException
                || e is ArgumentException || e is InvalidOperationException
                ? HttpStatusCode.OK
                : HttpStatusCode.InternalServerError;

            string error = e.ReadException();

            //It means expected exception was handled when statusCode equals to HttpStatusCode.Ok
            // ,it show return the exception message
            var message = statusCode == HttpStatusCode.OK ? e.Message : "抱歉，出错了";

            var json = HeaderResult.Error(message, statusCode).ToString();
            await Task.CompletedTask;

            return (headerResultJsonString: json, loggerMessage: error, statusCode);
        }
    }
}

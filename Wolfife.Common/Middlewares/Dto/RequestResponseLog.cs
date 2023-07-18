using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolfife.Common.Extensions;

namespace Wolfife.Common.Middlewares.Dto
{
    public class RequestResponseLog
    {
        private readonly ILogger<RequestResponseLog> _logger;
        protected RequestResponseLog()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="aliyunLogger"></param>
        public RequestResponseLog(ILogger<RequestResponseLog> logger)
        : this()
        {
            this._logger = logger;
        }
        /// <summary>
        /// request url
        /// </summary>
        public string Url { get; set; }
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> OriginHeaders { get; set; } = new Dictionary<string, string>();
        public string Method { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public DateTime ExcuteStartTime { get; set; }
        public DateTime ExcuteEndTime { get; set; }

        #region Private fields
        private long requestTimestamp;
        private long responseTimestamp;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var headerJson = this.Headers.ToJson();
            StringBuilder contentBuilder = new StringBuilder("-----------------------------------------\r\n");
            contentBuilder.AppendLine($" request header:{headerJson}");

            if (!string.IsNullOrWhiteSpace(this.RequestBody))
            {
                contentBuilder.AppendLine($" request body:{this.RequestBody}");
            }
            if (!string.IsNullOrWhiteSpace(this.ResponseBody))
            {
                contentBuilder.AppendLine($" response body  :{this.ResponseBody}");
            }

            return contentBuilder.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Obsolete("Not activated", true)]
        public IEnumerable<string> CreatePrintLog()
        {
            requestTimestamp = this.ExcuteStartTime.ToLong();
            responseTimestamp = this.ExcuteEndTime.ToLong();
            yield return $"[{requestTimestamp}]request headers:{this.Headers.ToJson()}";
            if (!string.IsNullOrWhiteSpace(this.RequestBody))
            {
                yield return $"[{requestTimestamp}]request body:{this.RequestBody}";
            }
            if (!string.IsNullOrWhiteSpace(this.ResponseBody))
            {
                yield return $"[{responseTimestamp}]response body:{this.ResponseBody}";
            }
        }
        /// <summary>
        /// print log async
        /// </summary>
        /// <returns></returns>
        public async Task PrintAsync()
        {
            await Task.Run(() =>
            {
                this.PrintRequest();
                this.PrintResponse();
            });
        }
        /// <summary>
        /// print request
        /// </summary>
        private void PrintRequest()
        {
            Build();
            if (!string.IsNullOrWhiteSpace(this.RequestBody))
            {
                _logger.LogInformation($"[{requestTimestamp}]request body:{this.RequestBody}");
            }
        }
        /// <summary>
        /// print response
        /// </summary>
        private void PrintResponse()
        {
            requestTimestamp = this.ExcuteStartTime.ToLong();
            if (this.Headers.Any())
            {
                _logger.LogInformation($"[{requestTimestamp}]request headers:{this.Headers.ToJson()}");
            }
            if (!string.IsNullOrWhiteSpace(this.ResponseBody))
            {
                responseTimestamp = this.ExcuteEndTime.ToLong();
                _logger.LogInformation($"response body:{this.ResponseBody}");
            }
        }
        /// <summary>
        /// build timestamp and request url
        /// </summary>
        private void Build()
        {
            requestTimestamp = this.ExcuteStartTime.ToLong();
            responseTimestamp = this.ExcuteEndTime.ToLong();
            SetRequestUrlToHeaders();
        }
        /// <summary>
        /// add the request url to origin headers
        /// </summary>
        private void SetRequestUrlToHeaders()
        {
            this.OriginHeaders["RequestUrl"] = this.Url;
        }
    }
}

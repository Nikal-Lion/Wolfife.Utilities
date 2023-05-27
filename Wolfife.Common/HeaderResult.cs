using System.Net;
using Wolfife.Common.Extensions;

namespace Wolfife.Common
{

    /// <summary>
    /// 返回参数
    /// </summary>
    public class HeaderResult
    {
        public HeaderResult()
        {
            this.IsSucceed = false;
        }

        internal HeaderResult(bool result, string message, HttpStatusCode httpStatusCode) : this()
        {
            this.IsSucceed = result;
            this.Message = message;
            this.StatusCode = httpStatusCode;
        }

        #region Properties
        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool IsSucceed { get; internal set; }
        /// <summary>
        /// 信息通知
        /// </summary>
        public virtual string Message { get; internal set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }
        #endregion

        #region static methods
        /// <summary>
        ///  response with message
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static HeaderResult Success(string msg)
        {
            return Success(msg, HttpStatusCode.OK);
        }
        /// <summary>
        /// response with message and status code
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        internal static HeaderResult Success(string msg, HttpStatusCode statusCode)
        {
            return new HeaderResult(true, msg, statusCode);
        }
        /// <summary>
        /// response error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static HeaderResult Error(string error)
        {
            return Error(error, HttpStatusCode.BadRequest);
        }
        /// <summary>
        /// response error with status code
        /// </summary>
        /// <param name="error"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        internal static HeaderResult Error(string error, HttpStatusCode statusCode)
        {
            return new HeaderResult(false, error, statusCode);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJson();
        }
    }

    public class HeaderResult<T> : HeaderResult
    {
        public HeaderResult()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            IsSucceed = false;
        }
        internal HeaderResult(bool result, string message, HttpStatusCode httpStatusCode) : base(result, message, httpStatusCode)
        {

        }
        internal HeaderResult(T data, bool result, int total, string message, HttpStatusCode httpStatusCode)
            : base(result, message, httpStatusCode)
        {
            this.Result = data;
            this.Total = total;
        }

        /// <summary>
        /// 分页总条数
        /// </summary>
        //[JsonIgnore]
        public int Total { get; internal set; }

        /// <summary>
        /// 返回的类型
        /// </summary>
        public virtual T Result { get; internal set; }

        internal static HeaderResult<T> Success(T data, string msg)
        {
            return Success(data, msg, HttpStatusCode.OK);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        internal static HeaderResult<T> Success(T data, string msg, HttpStatusCode statusCode)
        {
            return Success(data, 0, msg, statusCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static HeaderResult<T> Success(T data, int total, string msg)
        {
            return Success(data, total, msg, HttpStatusCode.OK);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        /// <param name="msg"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        internal static HeaderResult<T> Success(T data, int total, string msg, HttpStatusCode statusCode)
        {
            return new HeaderResult<T>(data, true, total, msg, statusCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static new HeaderResult<T> Error(string error)
        {
            return new HeaderResult<T>(false, error, HttpStatusCode.BadRequest);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static new HeaderResult<T> Error(string error, HttpStatusCode statusCode)
        {
            return new HeaderResult<T>(false, error, statusCode);
        }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}

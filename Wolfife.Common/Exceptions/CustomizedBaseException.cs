using System;
using System.Runtime.Serialization;

namespace Wolfife.Common.Exceptions
{
    /// <summary>
    /// 自定义的异常类型-抽象类型
    /// </summary>
    public abstract class CustomizedBaseException : Exception
    {
        public CustomizedBaseException()
        {
        }

        internal CustomizedBaseException(string message) : base(message)
        {
        }

        internal CustomizedBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomizedBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
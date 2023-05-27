using System;
using System.Runtime.Serialization;

namespace Wolfife.Common.Exceptions
{
    public class BusinessException : CustomizedBaseException
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

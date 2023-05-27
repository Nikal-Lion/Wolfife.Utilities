using System;

namespace Wolfife.Common.Exceptions
{
    /// <summary>
    /// 领域层业务异常
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        {

        }
    }
}

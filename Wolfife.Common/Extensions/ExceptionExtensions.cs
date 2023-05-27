using System;
using System.Text;

namespace Wolfife.Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorBuilder"></param>
        public static string ReadException(this Exception ex)
        {
            StringBuilder errorBuilder = new StringBuilder();

            errorBuilder.AppendLine($"错误信息:{ex.Message}");
            errorBuilder.AppendLine($"堆栈信息:{ex.StackTrace}");

            if (ex.InnerException != null)
            {
                errorBuilder.Append($"内部异常:{ex.InnerException}");
                errorBuilder.Append(ex.InnerException.ReadException());
            }
            return errorBuilder.ToString();
        }
    }
}

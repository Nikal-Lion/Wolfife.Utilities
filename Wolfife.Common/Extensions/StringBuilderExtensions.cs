using System.Text;

namespace Wolfife.Common.Extensions
{

    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 补充内容
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static StringBuilder AppendIf(this StringBuilder stringBuilder, string appendContent, bool append)
        {
            return append ? stringBuilder.Append(appendContent) : stringBuilder;
        }
    }
}
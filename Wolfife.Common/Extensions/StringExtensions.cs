using System;

namespace Wolfife.Common.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// 忽略大小写进行比较
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IgEqual(this string s, string t)
        {
            if (t == null || s == null) { return false; }

            return string.Compare(s, t, true) == 0;
        }
        /// <summary>
        /// 忽略大小写进行比较
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IgEqual(this string source, Enum target)
        {
            return IgEqual(source, target.ToString());
        }

        /// <summary>
        /// to int value
        /// </summary>
        /// <param name="s"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ToInt(this string s, int def = -1)
        {
            if (string.IsNullOrEmpty(s))
                return def;

            return int.TryParse(s, out int intVal) ? intVal : def;
        }
        /// <summary>
        /// 字符串非空判断
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>是否不为空</returns>
        public static bool NotNullAndNotWhiteSpace(this string source)
            => !string.IsNullOrWhiteSpace(source);

        /// <summary>
        /// 为空字符串使用默认值
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">默认值不能为空</exception>
        public static string DefaultIfEmpty(this string source, string defaultValue)
            => source.NotNullAndNotWhiteSpace()
                ? source
                : (defaultValue.NotNullAndNotWhiteSpace() ? defaultValue : throw new ArgumentNullException(defaultValue));
    }
}
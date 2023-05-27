using System;
using System.ComponentModel;

namespace Wolfife.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举的DescriptionAttribute
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum @enum)
        {
            var objType = @enum.GetType();
            //取属性上的自定义特性
            var field = objType.GetField(@enum.ToString());
            if (field != null)
            {
                var objAttrs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objAttrs != null && objAttrs.Length > 0 && objAttrs[0] is DescriptionAttribute attribute)
                {
                    return attribute.Description;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static T ToEnum<T>(this string enumString)
            where T : struct
        {
            if (string.IsNullOrWhiteSpace(enumString))
            {
                return default;
            }
            //忽略大小写
            if (Enum.TryParse(enumString, ignoreCase: true, out T @enum))
                return @enum;
            return default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string[] ToArray(this Enum t)
        {
            return t.ToString().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

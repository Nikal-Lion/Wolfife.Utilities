using System;

namespace Wolfife.Common.Extensions
{
    public static class DateTimeExtensions
    {
        internal static DateTime TimestampBeginTime => new DateTime(1970, 1, 1);
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static long ToLong(this DateTime time)
        {
            var startTime = TimeZoneInfo.ConvertTimeFromUtc(TimestampBeginTime, TimeZoneInfo.Local);
            return (long)(time - startTime).TotalSeconds;
        }
    }
}

using System;

namespace Wolfife.Common.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeOffsetExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToLong(this DateTimeOffset time)
        {
            var startTime = TimeZoneInfo.ConvertTimeFromUtc(DateTimeExtensions.TimestampBeginTime, TimeZoneInfo.Local);
            return (long)(time.DateTime - startTime).TotalSeconds;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Wolfife.Common.Comparers
{
    /// <summary>
    /// 忽略大小写-比较器
    /// </summary>
    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        bool IEqualityComparer<string>.Equals(string x, string y)
        {
            return string.Compare(x, y, true, CultureInfo.InvariantCulture) == 0;
        }
        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            return obj.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }
    }
}

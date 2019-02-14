using System;

namespace Utility
{
    public static class DateTimeConverter
    {
        public static DateTime ToDateTime(this string date, string format)
        {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }
        public static TimeSpan ToTimeSpan(this double second)
        {
            return TimeSpan.FromSeconds(second);
        }
        public static double ToSecond(this TimeSpan time)
        {
            return time.TotalSeconds / 3600;
        }
    }
}

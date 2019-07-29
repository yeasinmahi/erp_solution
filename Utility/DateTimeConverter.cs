using System;

namespace Utility
{
    public static class DateTimeConverter
    {
        public static DateTime ToDateTime(this string date, string format)
        {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }
        public static DateTime ToDateTime(this string date)
        {
            return DateTime.Parse(date,System.Globalization.CultureInfo.InvariantCulture);
        }
        public static TimeSpan ToTimeSpan(this double second)
        {
            return TimeSpan.FromSeconds(second);
        }
        public static double ToSecond(this TimeSpan time)
        {
            return time.TotalSeconds / 3600;
        }
        public static DateTime FirstDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime LastDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.AddMonths(1).FirstDay().AddDays(-1).Day);
        }
    }
}

using System;

namespace Utility
{
    public class DateTimeConverter
    {
        public static DateTime StringToDateTime(string date, string format)
        {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }
        public static TimeSpan ConvertSecondToTimespan(double second)
        {
            return TimeSpan.FromSeconds(second);
        }
        public static double ConvertTimeSpanToSecond(TimeSpan time)
        {
            return time.TotalSeconds / 3600;
        }
    }
}

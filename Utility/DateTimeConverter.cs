using System;

namespace Utility
{
    public class DateTimeConverter
    {
        public static DateTime StringToDateTime(string date, string format)
        {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}

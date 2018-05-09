using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

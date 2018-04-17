using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GLOBAL_BLL
{
    public static class DateFormat
    {
        public static DateTime? GetDateAtSQLDateFormat(string dateString)
        {
            if ("" + dateString == "") return null;

            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
            return Convert.ToDateTime(dateString, dtf);
        }
    }
}

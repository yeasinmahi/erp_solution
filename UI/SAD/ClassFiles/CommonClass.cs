using System;
using System.Globalization;

#pragma warning disable 1587
/// <summary>
/// Developped By Akramul Haider
/// Common classes used to all
/// </summary>
#pragma warning restore 1587
namespace UI.ClassFiles
{
    public static class CommonClass
    {
        public static string GetGlobalMessage()
        {
            string[] msg = new string[4];

            msg[0] = "Please change your password at every month.";
            msg[1] = "Akij Group ERP Solution will make your life easy.";
            msg[2] = "Thank you for using Akij Group ERP Solution.";
            msg[3] = "Welcome to AKIJ Group.   Welcome to AKIJ Group.   Welcome to AKIJ Group.";

            Random r = new Random();
            return msg[r.Next(0, 3)];
        }
        public static string GetDateAtLocalDateFormat(DateTime dte)
        {
            try
            {
                return string.Format("{0:dd/MM/yyyy hh:mm tt}", dte);
            }
            catch
            {
                return "";
            }
        }
        public static string GetDateAtLocalDateFormat(object dte)
        {
            try
            {
                return string.Format("{0:dd/MM/yyyy hh:mm tt}", dte);
            }
            catch
            {
                return "";
            }
        }
        public static string GetTimeAtLocalDateFormat(object dte)
        {
            try
            {
                return string.Format("{0:hh:mm tt}", dte);
            }
            catch
            {
                return "";
            }
        }
        public static DateTime GetDateAtSQLDateFormat(string dateString)
        {
            if ("" + dateString == "") return DateTime.Now;

            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
            return Convert.ToDateTime(dateString, dtf);
        }
        public static string GetDateShortAtSQLDateFormat(DateTime dte)
        {
            return String.Format("{0:MM/dd/yyyy}", dte);
        }
        public static DateTime? GetDateAtSQLDateFormatAllowNULL(string dateString)
        {
            if ("" + dateString == "") return null;

            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
            return Convert.ToDateTime(dateString, dtf);
        }
        public static string GetTimeFromMinute(string minutes)
        {
            if (minutes == null || minutes == "" || minutes == "0")
                return "0:00";
            int min = int.Parse(minutes);
            return "" + (min / 60) + ":" + (min % 60);
        }
        public static string GetShortDateAtLocalDateFormat(DateTime dte)
        {
            return String.Format("{0:dd/MM/yyyy}", dte);
        }
        public static string GetLongDateAtLocalDateFormat(DateTime dte)
        {
            return String.Format("{0:dd/MM/yyyy}", dte);
        }
        public static string GetLonDateAtLocalDateFormat(object dte)
        {
            return String.Format("{0:dd/MM/yyyy}", dte);
        }
        public static string GetShortDateAtLocalDateFormat(object dte)
        {
            return String.Format("{0:dd/MM/yyyy}", dte);
        }
        public static string TranLed(object tran)
        {
            if (Convert.ToDouble(String.Format("{0:F2}", tran)) > 0)
            {
                return String.Format("{0:F2}", tran);
            }
            else
                return "";
        }
        public static object CheckedQuantity(object stockQ, object requestQ)
        {
            if ((decimal.Parse(stockQ.ToString())) < (decimal.Parse(requestQ.ToString())) && (decimal.Parse(requestQ.ToString())) > 0)
            {
                return "<font color=#FF0000>" + requestQ.ToString() + "</font>";

            }
            else
            {
                return "<font color=#A0A0A0>" + requestQ.ToString() + "</font>";

            }


        }
        public static string SendSmsForAFBL(object _Location, object _TARGET, object _SALES, object _VARIANCE, object _NEXTTARGET)
        {
            string saleDate = GetShortDateAtLocalDateFormat(System.DateTime.Now.AddDays(-1));
            if ((System.DateTime.Now.DayOfWeek.ToString()).Equals("Saturday", StringComparison.CurrentCultureIgnoreCase))
            {
                saleDate = GetShortDateAtLocalDateFormat(System.DateTime.Now.AddDays(-2));
            }
            return _Location + ", " + saleDate + "TARGET= " + _TARGET + ", SALES= " + _SALES + ", VARIANCE= " + _VARIANCE + "," + GetShortDateAtLocalDateFormat(System.DateTime.Today) + "TARGET= " + _NEXTTARGET;

        }
        public static string AlertMessageForDashBoard
            (
              object isOverSpeed
            //, object overSpeedTime
            , object isHalt
            //, object haltTime
            , object isGetDataStop
            //, object stopTime
            , object timeOut
            , object point
            , object sendingTime
            , object todayStopTime
            , object speed
            )
        {
            /*DateTime dtOS, dtHt, dtSt;
        
            try { dtOS = DateTime.Parse("" + overSpeedTime); }
            catch { dtOS = DateTime.Now.AddYears(-50); }

            try { dtHt = DateTime.Parse("" + haltTime); }
            catch { dtHt = DateTime.Now.AddYears(-50); }

            try { stopTime = DateTime.Parse("" + stopTime); }
            catch { stopTime = DateTime.Now.AddYears(-50); }*/

            DateTime dteTDStop = new DateTime();
            DateTime dteSending = new DateTime();

            try
            {
                dteSending = DateTime.Parse("" + sendingTime);
                dteTDStop = DateTime.Parse("" + todayStopTime);
            }
            catch
            {
                dteSending = DateTime.Now.AddYears(-100);
                dteTDStop = DateTime.Now.AddYears(-100);
            }

            if (dteSending.AddDays(2) < DateTime.Now)
            {
                return "<font color=#000000><b>Disconnected</b></font>";
            }

            if (isOverSpeed != null && (("" + isOverSpeed) != ""))
            {
                if (bool.Parse(isOverSpeed.ToString()))
                {
                    return "<font color=#FF0000><b>Over Speed</b></font>";
                }
            }

            if (float.Parse("" + speed) > 0)
            {
                return "<font color=#00AA00><b>Running</b></font> ";
            }

            if (dteTDStop.AddHours(1) < DateTime.Now)
            {
                return "<font color=#909090>Temp. Sleep</font>";
            }

            if (isGetDataStop != null && (("" + isGetDataStop) != ""))
            {
                if (bool.Parse(isGetDataStop.ToString()))
                {
                    return "<font color=#A0A0A0>In Sleep Mode</font>";
                }
            }

            if (isHalt != null && (("" + isHalt) != ""))
            {
                if (bool.Parse(isHalt.ToString()))
                {
                    return "<font color=#990000><b>Halt</b></font>";
                }
            }

            if ((timeOut == null || ("" + timeOut) == "") && ("" + point) != "")
            {
                return "<font color=#9999FF><b>In</b></font> " + point;
            }

            return "<font color=#000000>Stopped</font> ";
        }
        public static string GetFormettingNumber(double number)
        {
            return string.Format("{0:F2}", number);
            //return "";
        }

    

        public static string GetFormettingNumber(object number)
        {
            return string.Format("{0:F2}", number);
            //return "";
        }
        public static string GetFormettingNumber(decimal number)
        {
            return string.Format("{0:F2}", number);
            //return "";
        }

        public static string GetFormettingNumberfourdigit(decimal number)
        {
            return string.Format("{0:N4}", number);
            //return "";
        }


        public static string GetHoldStock(object current, object physical)
        {

            string stock = "" + (Convert.ToInt32(physical) - Convert.ToInt32(current));
            return stock;

        }

        public static string GetMonthNameByValue(int month)
        {
            if (month == 1) return "JAN";
            if (month == 2) return "FEB";
            if (month == 3) return "MAR";
            if (month == 4) return "APR";
            if (month == 5) return "MAY";
            if (month == 6) return "JUN";
            if (month == 7) return "JUL";
            if (month == 8) return "AUG";
            if (month == 9) return "SEP";
            if (month == 10) return "OCT";
            if (month == 11) return "NOV";
            if (month == 12) return "DEC";
            return "";
        }

        public static string MonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Common
    {

        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        public static StreamWriter GetStreamWriter(string path)
        {
            return !File.Exists(path) ? File.CreateText(path) : null;
        }
        public enum ModulaFileName
        {
            Item,
            Order,
            OrderLine,
            StrockUpdate
        }

        public static string GetModulaFullPath(string path, Enum fileName)
        {
            return path + fileName.ToString("F") + ".txt";
        }

        public static string ConvertUpperCamelCaseToTitle(string value)
        {
            var s = Regex.Replace(value, "([A-Z])", " $1").Trim();
            return ConvertToTitleCase(s);
        }
        public static string ConvertToTitleCase(string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }

        public static List<string> CreateAutoSearch(DataTable dt, string prefix, string textField, int valueField)
        {
            if (dt.Rows.Count > 0)
            {
                prefix = prefix.Trim().ToLower();
                DataTable tbl = new DataTable();
                try
                {
                    var rows = from row in dt.AsEnumerable()
                               where row.Field<string>(textField).ToLower().Contains(prefix) ||
                                     row.Field<int>(valueField).ToString().Contains(prefix)
                               select row;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return new List<string>();
                }

                if (tbl.Rows.Count > 0)
                {
                    List<string> retStr = new List<string>();
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr.Add(tbl.Rows[i][textField] + " [" + tbl.Rows[i][valueField] + "]");
                    }

                    return retStr;
                }
            }
            return new List<string>();

        }
        public static int GetIdFromString(string text)
        {
            string[] arr = text.Split(new[] { '[', ']' }, StringSplitOptions.None);
            string id = arr[1];
            return Convert.ToInt32(id);
        }
        public static string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        public static string GetIpAddress()
        {
            string ipAddress = null;
            var hostname = Environment.MachineName;
            var host = Dns.GetHostEntry(hostname);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAddress = Convert.ToString(ip);
                }
            }
            return ipAddress;
        }
    }
}

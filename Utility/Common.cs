using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Utility
{
    public static class Common
    {
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        public static object GetPropertyValue(object obj, string name)
        {
            return obj.GetType().GetProperty(name)?.GetValue(obj, null);
        }

        public static StreamWriter GetStreamWriter(string path)
        {
            return !File.Exists(path) ? File.CreateText(path) : null;
        }

        public enum TosterType
        {
            Success,
            Error,
            Warning
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

        public static string ToTitle(this string value)
        {
            var s = Regex.Replace(value, "([A-Z])", " $1").Trim();
            return ConvertToTitleCase(s);
        }

        private static string ConvertToTitleCase(string value)
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

        public static int SelectedValue(this DropDownList ddl)
        {
            if (ddl?.SelectedItem != null)
            {
                return Convert.ToInt32(ddl.SelectedItem.Value);
            }
            return 0;
        }
        public static bool SetDdlSelectedValue(DropDownList ddl, string value)
        {
            if (ddl.Items.FindByValue(value) != null)
            {
                ddl.SelectedValue = value;
                return true;
            }
            return false;
        }
        public static bool SetDdlSelectedText(DropDownList ddl, string text)
        {
            ListItem item = ddl.Items.FindByText(text);
            if (item != null)
            {
                ddl.SelectedValue = item.Value;
                return true;
            }
            return false;
        }

        public static string SelectedText(this DropDownList ddl)
        {
            if (ddl?.SelectedItem != null)
            {
                return ddl.SelectedItem.Text;
            }
            return string.Empty;
        }

        public static bool LoadDropDown(DropDownList ddl, DataTable dt, string value, string text)
        {
            if (dt.Rows.Count <= 0) return false;
            try
            {
                ddl.DataSource = dt;
                ddl.DataValueField = value;
                ddl.DataTextField = text;
                ddl.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadDropDownWithSelect(DropDownList ddl, DataTable dt, string value, string text)
        {
            bool isLoad = LoadDropDown(ddl, dt, value, text);
            if (isLoad)
            {
                ddl.Items.Insert(0, new ListItem("Select", "0"));
            }
            return isLoad;
        }

        public static bool LoadDropDownWithAll(DropDownList ddl, DataTable dt, string value, string text)
        {
            bool isLoad = LoadDropDown(ddl, dt, value, text);
            ddl.Items.Insert(0, new ListItem("All", "0"));
            return isLoad;
        }

        public static void UnLoad(this DropDownList ddl)
        {
            ddl.Items.Clear();
        }

        public static void UnLoadWithSelect(this DropDownList ddl)
        {
            UnLoad(ddl);
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void UnLoadWithAll(this DropDownList ddl)
        {
            UnLoad(ddl);
            ddl.Items.Insert(0, new ListItem("All", "0"));
        }
        public static void Clear(ControlCollection controls,List<Control> exceptControls)
        {
            
            foreach (Control ctrl in controls)
            {
                if (exceptControls!=null)
                {
                    if (exceptControls.Contains(ctrl))
                    {
                        continue;
                    }
                }
                

                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is DropDownList)
                {
                    SetDdlSelectedValue(((DropDownList)ctrl), "0");
                }
                else if (ctrl is CheckBoxList)
                {
                    ((CheckBoxList)ctrl).SelectedIndex = 0;
                }
                else if (ctrl is ListBox)
                {
                    ((ListBox)ctrl).SelectedIndex = 0;
                }
                else if (ctrl is RadioButtonList)
                {
                    ((RadioButtonList)ctrl).SelectedIndex = 0;
                }
                else
                {
                    Clear(ctrl.Controls,exceptControls);
                }
            }
        }
        public static Control GetControlThatCausedPostBack(Page page)
        {
            //initialize a control and set it to null
            Control ctrl = null;

            //get the event target name and find the control
            string ctrlName = page.Request.Params.Get("__EVENTTARGET");
            if (!String.IsNullOrEmpty(ctrlName))
                ctrl = page.FindControl(ctrlName);

            //return the control to the calling method
            return ctrl;
        }

        public static int GetOnlyNumber(this string s)
        {
            string result = Regex.Match(s, @"\d+").Value;
            int.TryParse(result, out int num);
            return num;
        }

        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }
    }
}
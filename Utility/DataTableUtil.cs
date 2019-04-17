using System;
using System.Data;
using System.Linq;
using System.Reflection;
#pragma warning disable 168

namespace Utility
{
    public static class DataTableUtil
    {
        public static bool AddRow(this DataTable dt, object obj)
        {
            try
            {
                var sampleDataRow = dt.NewRow();
                PropertyInfo[] propertyInfos = Common.GetProperties(obj);

                foreach (PropertyInfo p in propertyInfos)
                {
                    sampleDataRow[p.Name] = Common.GetPropertyValue(obj, p.Name);
                }
                dt.Rows.Add(sampleDataRow);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private static EnumerableRowCollection<DataRow> GetRows<T>(this DataTable dt, string columnName, T value)
        {
            EnumerableRowCollection<DataRow> query = null;
            if (typeof(T) == typeof(int))
            {
                var intValue = Convert.ToInt32(value);
                query = dt.AsEnumerable().Where(r => r.Field<int>(columnName) == intValue);
            }
            else if (typeof(T) == typeof(string))
            {
                var strValue = Convert.ToString(value);
                query = dt.AsEnumerable().Where(r => r.Field<string>(columnName) == strValue);
            }
            else if (typeof(T) == typeof(bool))
            {
                var strValue = Convert.ToString(value);
                query = dt.AsEnumerable().Where(r => r.Field<string>(columnName) == strValue);
            }
            else if (typeof(T) == typeof(DateTime))
            {
                var strValue = DateTime.Parse(value.ToString());
                query = dt.AsEnumerable().Where(r => r.Field<DateTime>(columnName) == strValue);
            }
            return query;
        }
        public static DataRow GetRow<T>(this DataTable dt, string columnName, T value)
        {
            DataRow row = null;
            if (typeof(T) == typeof(int))
            {
                var intValue = Convert.ToInt32(value);
                row = dt.AsEnumerable().SingleOrDefault(x=>x.Field<int>(columnName) == intValue);
                //row =  (from DataRow dr in dt.Rows
                //    where dr[columnName]!=null && (int)dr[columnName] == intValue
                //       select dr).FirstOrDefault();
            }
            else if (typeof(T) == typeof(string))
            {
                var strValue = Convert.ToString(value);
                row  = (from DataRow dr in dt.Rows
                    where dr[columnName] != null && (string)dr[columnName] == strValue
                             select dr).FirstOrDefault();
            }
            else if (typeof(T) == typeof(bool))
            {
                var strValue = Convert.ToBoolean(value);
                row = (from DataRow dr in dt.Rows
                    where dr[columnName] != null && (bool)dr[columnName] == strValue
                       select dr).FirstOrDefault();
            }
            else if (typeof(T) == typeof(DateTime))
            {
                var strValue = DateTime.Parse(value.ToString());
                row = (from DataRow dr in dt.Rows
                    where dr[columnName] != null && (DateTime)dr[columnName] == strValue
                    select dr).FirstOrDefault();
            }
            return row;
        }
        public static bool RemoveRow<T>(this DataTable dt, string columnName, T value)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            EnumerableRowCollection<DataRow> query = dt.GetRows<T>(columnName, value);

            if (query != null)
            {
                foreach (var row in query.ToList())
                    row.Delete();
                dt.AcceptChanges();
                return true;
            }
            return false;

        }
        public static bool IsExist<T>(this DataTable dt, string columnName, T value)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            EnumerableRowCollection<DataRow> query = dt.GetRows<T>(columnName, value);
            return query != null && query.ToList().Count > 0;
        }
        public static string ToHtmlTable(this DataTable dt)
        {
            string html = "<table style='border:1px solid black;'>";
            int countColumn = dt.Columns.Count;
            int countRow = dt.Rows.Count;
            //add header row
            html += "<tr style='border:1px solid black; font-weight:bold; background-color:black; color:white'>";
            html += "<td style='border:1px solid grey;'>SN</td>";
            for (int i = 0; i < countColumn; i++)
                html += "<td style='border:1px solid grey;'>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < countRow; i++)
            {
                html += "<tr style='border:1px solid black;'> ";
                html += "<td style='border:1px solid grey;'>" + (i + 1) + "</td>";
                for (int j = 0; j < countColumn; j++)
                    html += "<td style='border:1px solid black;'>" + dt.Rows[i][j] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
    }
}

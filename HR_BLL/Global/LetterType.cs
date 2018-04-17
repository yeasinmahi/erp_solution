using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.LetterTypeTDSTableAdapters;
using System.Data;
using HR_DAL.Global.EmployeeListTDSTableAdapters;

namespace HR_BLL.Global
{
    public class LetterType
    {
        private static EmployeeListTDS.TblEmployeeDataTable table = null;

        public LetterTypeTDS.TblHrLetterDataTable GetOfferLetterType()
        {
            TblHrLetterTableAdapter ta = new TblHrLetterTableAdapter();
            return ta.GetLetterTypeData();
        }

        public static string[] GetEmployeeDataForAutoFill(string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                try
                {
                    var rows = from tmp in table//[Convert.ToInt32(ht[unitID])]Convert.ToInt32(ht[unitID])
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    var rows = from tmp in table//COAs[Convert.ToInt32(ht[unitID])]
                               where tmp.strEmployeeName.ToLower().StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + "," + tbl.Rows[i]["strEmployeeCode"];
                }

                return retStr;
            }
            else
            {
                return null;
            }
                        
        }
        public static void Reload()
        {
            TblEmployeeTableAdapter ta = new TblEmployeeTableAdapter();
            table = ta.GetEmployeeListData();
        }
        private static void Inatialize()
        {
            if (table == null)
            {
                TblEmployeeTableAdapter ta = new TblEmployeeTableAdapter();
                table = ta.GetEmployeeListData();
            }
        }

    }
}

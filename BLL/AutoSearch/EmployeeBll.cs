
using DAL.AutoSearch.EmployeeTdsTableAdapters;
using System;
using System.Data;

namespace BLL.AutoSearch
{
    public class EmployeeBll
    {
        string[] results;
        string[] emps = new string[0];
        private DataTable dt = new DataTable();
        public string[] GetAllEmployee(string prefix)
        {
            prefix = prefix.ToLower();
            sprEmployeeAutoSearchTableAdapter adp = new sprEmployeeAutoSearchTableAdapter();
            if (dt.Rows.Count < 1)
            {
                dt = adp.GetData(1, 0, 0);
            }
            if (prefix.Trim().Length >= 3)
            {
                if (dt.Rows.Count > 0)
                {
                    if (emps.Length < 1)
                    {
                        emps = new string[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            emps[i] = dt.Rows[i]["strEmployeeName"] + " [" + dt.Rows[i]["intEmployeeID"] + "][" + dt.Rows[i]["strEmployeeCode"] + "]";
                        }
                    }
                    results = Array.FindAll(emps, x => x.ToLower().Contains(prefix));
                    return results;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}

using HR_DAL.KPI;
using HR_DAL.KPI.KPI_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.KPI
{
    public class AutoSearchKPI_BLL
    {
        private static KPI_TDS.EmployeeSearchDataTable[] tableEmployee = null;
        private static KPI_TDS.EmpSupervisorSearchDataTable[] tableEmpSupervisor = null;
        int e;

        public string[] GetEmployeeNameHRJobstation(string job, string prefix)
        {


            tableEmployee = new KPI_TDS.EmployeeSearchDataTable[Convert.ToInt32(job)];
            EmployeeSearchTableAdapter adpCOA = new EmployeeSearchTableAdapter();
            tableEmployee[e] = adpCOA.EmpSearchGetData(Convert.ToInt32(job));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmployee[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableEmployee[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || Convert.ToString(tmp.intEmployeeID).ToLower().Contains(prefix)
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public string[] GetEmployeeNameSupervisor(string enroll, string prefix)
        {
            tableEmpSupervisor = new KPI_TDS.EmpSupervisorSearchDataTable[Convert.ToInt32(enroll)];
            EmpSupervisorSearchTableAdapter adpCOA = new EmpSupervisorSearchTableAdapter();
            tableEmpSupervisor[e] = adpCOA.EmployeeSuperVisorGetData(Convert.ToInt32(enroll));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmpSupervisor[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableEmpSupervisor[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || Convert.ToString(tmp.intEmployeeID).ToLower().Contains(prefix)
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strEmployeeName"]+ "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }
    }
}

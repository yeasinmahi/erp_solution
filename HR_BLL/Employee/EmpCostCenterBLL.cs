using HR_DAL.Employee.EmpCostCenterTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.Employee;

namespace HR_BLL.Employee
{
    public class EmpCostCenterBLL
    {
        private static EmpCostCenterTDS.tblCostCenterDataTable[] tableCustsName = null;
      
        int e;
        public DataTable GetUnitListe()
        {
            try
            {
                tblUnitTableAdapter objemp = new tblUnitTableAdapter();
                return objemp.GetUnitList();
            }
            catch { return new DataTable(); }
        }

        public DataTable getEmpbyunit(int unitid)
        {
            try
            {
                QRYEMPLOYEEPROFILEALLTableAdapter objemp = new QRYEMPLOYEEPROFILEALLTableAdapter();
                return objemp.GetEmployeeListByUnit(unitid);
            }
            catch { return new DataTable(); }
        }

        public void getupdate(int costid, int enroll)
        {
            try
            {
                tblEmployeeTableAdapter objemp = new tblEmployeeTableAdapter();
                 objemp.GetUpdate(costid.ToString(), enroll);
            }
            catch {}
        }
        public string[] GetCstomer(string unitid, string prefix)
        {
            int ysnActive = 1;
            tableCustsName = new EmpCostCenterTDS.tblCostCenterDataTable[Convert.ToInt32(ysnActive)];
            tblCostCenterTableAdapter Vehicle = new tblCostCenterTableAdapter();
            tableCustsName[e] = Vehicle.GetCostCenterList(int.Parse(unitid));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCustsName[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strCCName
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
                        var rows = from tmp in tableCustsName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strCCName.ToLower().Contains(prefix)
                                   orderby tmp.strCCName
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
                    retStr[i] = tbl.Rows[i]["strCCName"] + "," + "[" + tbl.Rows[i]["intCostCenterID"] + "]";
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

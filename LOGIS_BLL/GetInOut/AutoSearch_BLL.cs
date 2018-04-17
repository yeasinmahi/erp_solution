using LOGIS_DAL.GetInOut.VehicleGetInOutTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LOGIS_BLL.GetInOut
{
    public class AutoSearch_BLL
    {
        //public List<string> AutoSearchEmployeesData(string strSearchKey)
        //{
        //    List<string> result = new List<string>();
        //    SpareDataTable1TableAdapter SpareItemList = new SpareDataTable1TableAdapter();
        //    DataTable oDT = new DataTable();
        //    oDT = SpareItemList.ItemListGetData(strSearchKey);
        //    if (oDT.Rows.Count > 0)
        //    {
        //        for (int index = 0; index < oDT.Rows.Count; index++)
        //        {
        //            result.Add(oDT.Rows[index]["strItemName"].ToString());
        //        }

        //    }
        //    return result;
        //}

        public List<string> AutoSearchVehicle(string strSearchKey)
        {
            List<string> result = new List<string>();
            TblDataVehicleTableAdapter vehiclesearchar = new TblDataVehicleTableAdapter();
           // SpareDataTable1TableAdapter SpareItemList = new SpareDataTable1TableAdapter();
            DataTable oDTs = new DataTable();
            oDTs = vehiclesearchar.SearchKeyGetData(strSearchKey);
            if (oDTs.Rows.Count > 0)
            {
                for (int index = 0; index < oDTs.Rows.Count; index++)
                {
                    result.Add(oDTs.Rows[index]["strRegNo"].ToString());
                }

            }
            return result;
        }

        public List<string> AutoSearchCorporateEmployee(string strSearchKeyemp)
        {
           List<string> result2 = new List<string>();
           EmpSearchDataTableTableAdapter Corpemployeelist = new EmpSearchDataTableTableAdapter();
            DataTable oDT3 = new DataTable();
            oDT3 = Corpemployeelist.CorporateemployeeGetDataBy(strSearchKeyemp);
            if (oDT3.Rows.Count > 0)
            {
                for (int index = 0; index < oDT3.Rows.Count; index++)
                {
                    result2.Add(oDT3.Rows[index]["strItemName"].ToString());
                }

            }
            return result2;
        }
      

        public List<string> AutoSearchEmployee(string strSearchKeyemp, int intjobid)
        {
            List<string> result = new List<string>();
            EmpSearchDataTableTableAdapter employeelist = new EmpSearchDataTableTableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = employeelist.EmployeeSearchGetDataBy(strSearchKeyemp, intjobid);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strItemName"].ToString());
                }

            }
            return result;
        }
    }
}

using HR_DAL.Settlement.HRTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HR_BLL.Settlement
{
    public class HRClass
    {

        public DataTable GetEmpList(string loginid, string station, string prefix) 
        {
            EmployeeListJobStationWiseTableAdapter adp = new EmployeeListJobStationWiseTableAdapter();
            try
            { return adp.GetEmpList(int.Parse(station), prefix, int.Parse(loginid)); }
            catch { return new DataTable(); }
        }

        public DataTable GetUnitList()
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            try
            { return adp.GetUnitList(); }
            catch { return new DataTable(); }
        }

        public DataTable GetJobStationList(int intUnitID)
        {
            TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
            try
            { return adp.GetJobStationList(intUnitID); }
            catch { return new DataTable(); }
        }

        public DataTable SearchEmployeeList(int intJobStationID)
        {
            QryEmployeeProfileAllSearchEmployeeListTableAdapter adp = new QryEmployeeProfileAllSearchEmployeeListTableAdapter();
            try
            { return adp.SearchEmployeeList(intJobStationID); }
            catch { return new DataTable(); }
        }
              
        public DataTable GetEnrollByEmpCode(string strEmpCode)
        {
            TblEmployeeTableAdapter adp = new TblEmployeeTableAdapter();           
            try
            { return adp.GetEnrollDataByCode(strEmpCode); }//adp.GetEnrollByEmpCode(strEmpCode); }
            catch { return new DataTable(); }
        }
        


    }
}
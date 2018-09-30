using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.Reports.EmployeeDetailsReportTableAdapters;
namespace HR_BLL.Reports
{
    public class EmployeeDetailsReport
    {
        public DataTable GetUnit(int? intUserId)
        {
            sprGetUnitTableAdapter adp = new sprGetUnitTableAdapter();
            return adp.GetUnitDataByUserId(intUserId);
        }

        public DataTable GetJobStation(int UnitId, int intlogInId)
        {
            sprGetJobStationTableAdapter adp = new sprGetJobStationTableAdapter();
            return adp.GetJobStationDataByUnitId(UnitId, intlogInId);
        }
        public DataTable GetDepartment()
        {
            GetDepartmentTableAdapter adp = new GetDepartmentTableAdapter();
            return adp.GetDepartmentDataByJobStation();
        }

        public DataTable GetDesignation(int intJobStationId)
        {
            GetDesignationTableAdapter adp = new GetDesignationTableAdapter();
            return adp.GetDesignationData(intJobStationId);
        }

        public DataTable getEmployeeAttendance(DateTime date,int unitid,int jobstationid,int dept, int designation,int intPart,string xml)
        {
            SprReport_AttendanceTimeviewTableAdapter adp = new SprReport_AttendanceTimeviewTableAdapter();
            return adp.GetEmployeeAttendance(date,unitid,jobstationid,dept,designation,intPart,xml);
        }

        //public string InsertXml(string xml)
        //{
        //    string msg = "";
        //    sprReport_tblAttendanceDeleteLogTableAdapter adp = new sprReport_tblAttendanceDeleteLogTableAdapter();
        //    try
        //    {
        //          adp.InsertAttendanceData(xml);
        //          msg = "Deleted Successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //    return msg;
        //}
        public string InsertXml(string xml)
        {
            string msg = "";
            sprReport_tblAttendanceDeleteLogTableAdapter adp = new sprReport_tblAttendanceDeleteLogTableAdapter();
            try
            {
                  adp.InsertAttendanceData(xml);
                msg = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //return new DataTable();
            }
            return msg;
        }
    }
}

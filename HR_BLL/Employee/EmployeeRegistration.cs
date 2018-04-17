using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HR_DAL.Employee.EmpRegistrationTDSTableAdapters;

namespace HR_BLL.Employee
{
    public class EmployeeRegistration
    {
        public string InsertEmpRegistration(string fullname, string shortname, string nationalId, string contact, string bloodGroup, string factorycode,
        int intReligion, string empEmail, string presentAdd, int dayOffId, string gender, string permanentAdd, int groupId, int unitId, int jobStationID,
        int jobType, int designationID, int departmentID, int dutyCategoryID, string contactPeriod, int teamID, int presentShiftID, DateTime joinDate,
        DateTime appointmentDate, string superviserCode, string strFloorAccess, string bankName, string bankBranch, string bankAccountNo, decimal salTotal, string photourl,
        string documenturl, string documenttype, int loginUserID, int bank, int branch, int dist, DateTime birth)
        {
            SprEmployeeRegistrationTableAdapter adapter = new SprEmployeeRegistrationTableAdapter();
            string rtnMessage = "";
            try
            {
                adapter.EmployeeRegistrationData(fullname, shortname, nationalId, contact, bloodGroup, factorycode, intReligion, empEmail, presentAdd,
                dayOffId, gender, permanentAdd, groupId, unitId, jobStationID, jobType, designationID, departmentID, dutyCategoryID, contactPeriod,
                teamID, presentShiftID, joinDate, superviserCode, strFloorAccess, bankName, bankBranch, bankAccountNo, salTotal, photourl, documenturl, documenttype, loginUserID, bank, branch, dist,
                birth, ref rtnMessage);
            }
            catch (Exception ex) { rtnMessage = ex.ToString(); }
            return rtnMessage;
        }

        public DataTable GetEmployeeProfileByEmpCode(string empCode)
        {
            Spr_GetEmployeeProfileByEmpCodeTableAdapter objGetProfile = new Spr_GetEmployeeProfileByEmpCodeTableAdapter();
            return objGetProfile.GetEmployeeProfileData(empCode);
        }

        public string UpdateEmployeeProfile(string empCode, string fullname, string email, int religionid, int dayoffid, int groupid, 
        int unitid, int stationid, int jobtypeid, int departmentid, int designationid, int dutycategoryid, string contactperiod,
        string bankname, string branchname, string accountno, decimal totalsalary, decimal basicsalary, string contactno,
        string permanentAdd, string presentAdd, int intActive, int intHold, string supervisor, string photourl,
        string documenturl, string documenttype, int loginUserID, int bank, int branch, int dist, DateTime birth, string strFloorAccess)
        {
            SprEmployeeProfileUpdateTableAdapter adapter = new SprEmployeeProfileUpdateTableAdapter();
            string rtnMessage = "";
            try
            {
                adapter.EmployeeUpdateData(empCode, fullname, email, religionid, dayoffid, groupid, unitid, stationid, jobtypeid, departmentid,
                designationid, dutycategoryid, contactperiod, bankname, branchname, accountno, totalsalary, basicsalary, contactno, permanentAdd,
                presentAdd, intActive, intHold, supervisor, photourl, documenturl, documenttype, loginUserID, bank, branch, dist, birth, strFloorAccess,ref rtnMessage);
            }
            catch (Exception ex) { rtnMessage = ex.ToString(); }
            return rtnMessage;
        }
        
        public DataTable GetEmployeeProfileByEnrol(int enrol)
        {
            try
            {
                SprEmployeeSearchByEnrolTableAdapter objProfbyenrol = new SprEmployeeSearchByEnrolTableAdapter();
                return objProfbyenrol.tasprEmployeeSearchByEnrol(enrol);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetFlorrList()
        {
            try
            {
                TblFloorNameTableAdapter objProfbyenrol = new TblFloorNameTableAdapter();
                return objProfbyenrol.GetFloorList();
            }
            catch { return new DataTable(); }
        }

    }   
}

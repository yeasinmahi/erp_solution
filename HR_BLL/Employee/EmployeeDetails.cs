using HR_DAL.Employee.EmployeeInfoDetailTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Employee
{
   public class EmployeeDetails
    {
        public DataTable getEmployeeDetails(int id)
        {
            QRYEMPLOYEEPROFILEALLTableAdapter details = new QRYEMPLOYEEPROFILEALLTableAdapter();
            return details.GetEmployeeDetailsByEmployeeId(id);
        }

        public void insertEmployeePersonalData(int intEmployeeId, string strFatherName, string strMotherName, string strSpouseName, string strPermanentVillage, string strPermanentPostOffice, string strPermanentPoliceStation, string strPermanentDistrict, string strPresentHouseNo, int intPresentRoadNo, string strPresentPostOffice,
                      string strPresentPoliceStation, string strPresentDistrict)
        {
            tblEmployeeInfoDetailTableAdapter adp = new tblEmployeeInfoDetailTableAdapter();
            adp.InsertEmployeePersonalDetails(intEmployeeId, strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, strPresentHouseNo, intPresentRoadNo, strPresentPostOffice,
                         strPresentPoliceStation, strPresentDistrict);
        }
        public DataTable getEmployeeUpdateInfoList()
        {
            EmpPersonalInfoUpdateListTableAdapter adp = new EmpPersonalInfoUpdateListTableAdapter();
            return adp.GetEmpPersonalUpdateData();
        }

        public DataTable getEmployeePersonalDataByEmpId(int id)
        {
            TblEmployeeInfoDetailsDataTableAdapter adp = new TblEmployeeInfoDetailsDataTableAdapter();
            return adp.GetEmployeePersonalDataByEmpId(id);
        }
        public DataTable CountEmpId(int id)
        {
            EmpPersonalInfoUpdateListTableAdapter adp = new EmpPersonalInfoUpdateListTableAdapter();
            return adp.CountDataByEmpId(id);
        }
        public void updateEmployeeDetailById(string strFatherName, string strMotherName, string strSpouseName, string strPermanentVillage, string strPermanentPostOffice, string strPermanentPoliceStation, string strPermanentDistrict, string strPresentHouseNo, int intPresentRoadNo, string strPresentPostOffice,
                         string strPresentPoliceStation, string strPresentDistrict, int intEmployeeId)
        {
            tblEmployeeInfoDetailTableAdapter adp = new tblEmployeeInfoDetailTableAdapter();
            adp.UpdateEmployeeInfoDetailById(strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, strPresentHouseNo, intPresentRoadNo, strPresentPostOffice,
                         strPresentPoliceStation, strPresentDistrict, intEmployeeId);
        }
    }
}

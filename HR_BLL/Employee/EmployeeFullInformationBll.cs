using HR_DAL.Employee.EmployeeFullInformationTableAdapters;
using System;
using System.Data;

namespace HR_BLL.Employee
{
    public class EmployeeFullInformationBll
    {
        public string Insert(int intEnroll, string strEmpCardNo, string strEmpName, string strFathersName, string strMothersName, string strParmanentAddress, string strNIDNo, DateTime dteLastPromotionalDate, int intPresentDesignationID, string strPresentDesignation, int intPresentDepartmentID, string strPresentDepartment, decimal monPresentSalary, DateTime dteJoiningDate, int intJoiningDesignationID, string strJoiningDesignation, decimal monJoiningSalary, string strNameOfPreviousOrg, string strPreviousOrgDesignation, decimal monPreviousOrgSalary, int intActionBy)
        {
            string strMessage = string.Empty;
            sprPersonalInformationTableAdapter adp = new sprPersonalInformationTableAdapter();
            adp.Insert1(intEnroll, strEmpCardNo, strEmpName, strFathersName, strMothersName, strParmanentAddress, strNIDNo, dteLastPromotionalDate, intPresentDesignationID, strPresentDesignation, intPresentDepartmentID, strPresentDepartment, monPresentSalary, dteJoiningDate, intJoiningDesignationID, strJoiningDesignation, monJoiningSalary, strNameOfPreviousOrg, strPreviousOrgDesignation, monPreviousOrgSalary, intActionBy, ref strMessage);
            return strMessage;
        }
        public DataTable GetDesignation()
        {
            tblUserDesignationTableAdapter adp = new tblUserDesignationTableAdapter();
            return adp.GetData();
        }
        public DataTable GetDepartment()
        {
            tblDepartmentTableAdapter adp = new tblDepartmentTableAdapter();
            return adp.GetData();
        }
        public DataTable GetEmployeeInfo(int enroll)
        {
            qryEmployeeDetailsTableAdapter adp = new qryEmployeeDetailsTableAdapter();
            return adp.GetEmployeeInformationByEnroll(enroll);
        }
        public DataTable GetEmployeeInfo(string code)
        {
            qryEmployeeDetailsTableAdapter adp = new qryEmployeeDetailsTableAdapter();
            return adp.GetEmployeeInformationByCode(code);
        }
    }
}

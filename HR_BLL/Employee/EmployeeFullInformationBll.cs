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
        public DataTable GetLevelOfEducation()
        {
            tblLevelOfEducationTableAdapter adp = new tblLevelOfEducationTableAdapter();
            return adp.GetData();
        }
        public DataTable GetGradeList()
        {
            tblResultGradeListTableAdapter adp = new tblResultGradeListTableAdapter();
            return adp.GetData();
        }
        public DataTable GetExamList()
        {
            tblExamListTableAdapter adp = new tblExamListTableAdapter();
            return adp.GetData();
        }
        public DataTable GetEducationBoard()
        {
            tblEducationBoardTableAdapter adp = new tblEducationBoardTableAdapter();
            return adp.GetData();
        }
        public string InsertEdicationInfo(int intPart, int intEnroll, int intEducationID,string strEducationName, int intResultID, string strResult, int intExamID, string strExamName,decimal numCGPAMarks,decimal numScale, string strConcentrationMajorGroup, int intBoardID, string strBoard, string strInstituteName, int intYearOfPassing, string strDurationYear, string strAchievement, int intActionBy, bool ysnActive, int intEducationInfoID)
        {
            string message = string.Empty;
            sprEducationInformationTableAdapter adp = new sprEducationInformationTableAdapter();
            adp.Insert1(intPart,intEnroll,intEducationID,strEducationName,intResultID,strResult,intExamID,strExamName,numCGPAMarks,numScale,strConcentrationMajorGroup,intBoardID,strBoard,strInstituteName,intYearOfPassing,strDurationYear,strAchievement,intActionBy,ysnActive,intEducationInfoID,ref message);
            return message;
        }
        public string InsertExperienceInfo(int intPart, int intEnroll, string strCompanyName, string strCompanyLocation, string strCompanyBusiness, string strDesignation, string strDepartment, string strResponsibilities, DateTime dteEmploymentPeriodFrom, DateTime dteEmploymentPeriodTo, string strCurrentlyWorking, string strExpertiseSkill, int intActionBy)
        {
            string message = string.Empty;
            sprEmploymentHistoryTableAdapter adp = new sprEmploymentHistoryTableAdapter();
            adp.Insert1(intPart, intEnroll, strCompanyName, strCompanyLocation, strCompanyBusiness, strDesignation, strDepartment, strResponsibilities, dteEmploymentPeriodFrom, dteEmploymentPeriodTo, strCurrentlyWorking, strExpertiseSkill, intActionBy, true, 0, ref message);
            return message;
        }
        public string InsertTrainigInfo(int intPart, int intEnroll, string strTrainingTitle, string strTopicsCovered, string strInstitute, string strLocation, int intCountry, string strCountry, int intTrainingYear, string strDuration, int intActionBy)
        {
            string message = string.Empty;
            sprTrainingHistoryTableAdapter adp = new sprTrainingHistoryTableAdapter();
            adp.Insert1(intPart, intEnroll, strTrainingTitle, strTopicsCovered, strInstitute, strLocation, intCountry, strCountry, intTrainingYear, strDuration, true, intActionBy, 0, ref message);
            return message;
        }
        public DataTable GetCountry()
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            return adp.GetData();
        }

    }
}

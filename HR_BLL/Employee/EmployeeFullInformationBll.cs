using HR_DAL.Employee.EmployeeFullInformationTableAdapters;
using System;
using System.Data;
using Utility;

namespace HR_BLL.Employee
{
    public class EmployeeFullInformationBll
    {
        public string Insert(int intEnroll, string strEmpCardNo, string strEmpName, string strFathersName, string strMothersName, string strParmanentAddress,string strPresentAddress, string strNIDNo, DateTime? dteLastPromotionalDate, int intPresentDesignationID, string strPresentDesignation, int intPresentDepartmentID, string strPresentDepartment, decimal monPresentSalary, DateTime dteJoiningDate, int intJoiningDesignationID, string strJoiningDesignation, decimal monJoiningSalary, string strResponsibilities, string strNameOfPreviousOrg, string strPreviousOrgDesignation, decimal monPreviousOrgSalary, int intActionBy)
        {
            string strMessage = string.Empty;
            sprPersonalInformationTableAdapter adp = new sprPersonalInformationTableAdapter();
            adp.Insert1(intEnroll, strEmpCardNo, strEmpName, strFathersName, strMothersName, strParmanentAddress,strPresentAddress, strNIDNo, dteLastPromotionalDate, intPresentDesignationID, strPresentDesignation, intPresentDepartmentID, strPresentDepartment, monPresentSalary, dteJoiningDate, intJoiningDesignationID, strJoiningDesignation, monJoiningSalary,strResponsibilities, strNameOfPreviousOrg, strPreviousOrgDesignation, monPreviousOrgSalary, intActionBy, ref strMessage);
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
        public DataTable GetExamList(int levelOfEducation)
        {
            tblExamListTableAdapter adp = new tblExamListTableAdapter();
            return adp.GetData(levelOfEducation);
        }
        public DataTable GetEducationBoard()
        {
            tblEducationBoardTableAdapter adp = new tblEducationBoardTableAdapter();
            return adp.GetData();
        }
        public string InsertEdicationInfo(int intPart, int intEnroll, int intEducationID, string strEducationName, int intResultID, string strResult, int intExamID, string strExamName, decimal numCGPAMarks, decimal numScale, string strConcentrationMajorGroup, int intBoardID, string strBoard, string strInstituteName, int intYearOfPassing, string strDurationYear, string strAchievement, int intActionBy, bool ysnActive, int intEducationInfoID)
        {
            string message = string.Empty;
            sprEducationInformationTableAdapter adp = new sprEducationInformationTableAdapter();
            adp.Insert1(intPart, intEnroll, intEducationID, strEducationName, intResultID, strResult, intExamID, strExamName, numCGPAMarks, numScale, strConcentrationMajorGroup, intBoardID, strBoard, strInstituteName, intYearOfPassing, strDurationYear, strAchievement, intActionBy, ysnActive, intEducationInfoID, ref message);
            return message;
        }
        public string InsertExperienceInfo(int intPart, int intEnroll, string strCompanyName, string strCompanyLocation, string strCompanyBusiness, string strDesignation, string strDepartment, string strResponsibilities, DateTime dteEmploymentPeriodFrom, DateTime? dteEmploymentPeriodTo, string strCurrentlyWorking, string strExpertiseSkill, int intActionBy)
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
        public string InsertWorkInfo(int intEnroll, string strOtherDetails, int intActionBy)
        {
            string message = string.Empty;
            sprOthersInformationTableAdapter adp = new sprOthersInformationTableAdapter();
            adp.Insert1(1, intEnroll, strOtherDetails, intActionBy, true, 0, ref message);
            return message;
        }
        public DataTable UpdateImageInfo(string imageUrl, int enroll)
        {
            DataTable2TableAdapter adp = new DataTable2TableAdapter();
            return adp.UpdateImage(imageUrl, enroll);
        }
        public DataTable GetImageInfo(int enroll)
        {
            tblPersonalInformationTableAdapter adp = new tblPersonalInformationTableAdapter();
            return adp.GetImageInfo(enroll);
        }
        public DataTable GetWorkInfo(int enroll)
        {
            tblOthersInformationTableAdapter adp = new tblOthersInformationTableAdapter();
            return adp.GetData(enroll);
        }
        public DataTable GetTrainigInfo(int enroll)
        {
            tblTrainingHistoryTableAdapter adp = new tblTrainingHistoryTableAdapter();
            return adp.GetData(enroll);
        }
        public DataTable GetExperience(int enroll)
        {
            tblEmploymentHistoryTableAdapter adp = new tblEmploymentHistoryTableAdapter();
            return adp.GetData(enroll);
        }
        public DataTable GetEducationInfo(int enroll)
        {
            tblEducationInformationTableAdapter adp = new tblEducationInformationTableAdapter();
            return adp.GetData(enroll);
        }
        public DataTable DeleteWorkTitle(int id)
        {
            tblOthersInformation1TableAdapter adp = new tblOthersInformation1TableAdapter();
            return adp.Delete1(id);
        }
        public DataTable DeleteTraining(int id)
        {
            tblTrainingHistory1TableAdapter adp = new tblTrainingHistory1TableAdapter();
            return adp.Delete1(id);
        }
        public DataTable DeleteExperience(int id)
        {
            tblEmploymentHistory1TableAdapter adp = new tblEmploymentHistory1TableAdapter();
            return adp.Delete1(id);
        }
        public DataTable DeleteEducation(int id)
        {
            tblEducationInformation1TableAdapter adp = new tblEducationInformation1TableAdapter();
            return adp.Delete1(id);
        }
        public DataTable GetTodatysAttendance(int enroll)
        {
            tblEmployeeAttendanceTableAdapter adp = new tblEmployeeAttendanceTableAdapter();
            return adp.GetData(enroll, DateTime.Now.ToString("yyyy/MM/dd"));
        }
    }
}

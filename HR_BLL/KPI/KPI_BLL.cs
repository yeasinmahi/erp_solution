using HR_DAL.KPI.KPI_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.KPI
{
    public class KPI_BLL
    {

        public string InsertKPIinformation(int intType, string filePathForXMLKPI, DateTime evdate, int enroll, int p,int p2)
        {
            SprEmpKPIPerformanceTableAdapter insertkpi = new SprEmpKPIPerformanceTableAdapter();
            insertkpi.sprKPIGetData(intType, filePathForXMLKPI, evdate, enroll, 0,0);
            string message = "Successfully";
            return message;
        }

        public DataTable Employeeview(int intType, int p1, DateTime evdate, int enroll, int monthrange,int kpitype)
        {
            SprEmpKPIPerformanceTableAdapter empview = new SprEmpKPIPerformanceTableAdapter();
            return empview.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, monthrange,kpitype);
        }

        public DataTable TypeView()
        {
            TblEmployeePerformanceGradingTypeTableAdapter typeview = new TblEmployeePerformanceGradingTypeTableAdapter();
            return typeview.TypeGetData();
        }

        public DataTable EmployeeviewYearly(int intType, int p, DateTime evdate, int enroll, int yearrange, int kpitype)
        {
            SprEmpKPIPerformanceTableAdapter empviewyear = new SprEmpKPIPerformanceTableAdapter();
            return empviewyear.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, yearrange, kpitype);
        }

        public DataTable gradesummery()
        {
                 TblEmployeePerformanceGradesTableAdapter gradeummery=new TblEmployeePerformanceGradesTableAdapter();
            return gradeummery.GradesSummeryGetData();
        }

        public DataTable UnitNameKPI()
        {
            TblUnitTableAdapter unitname = new TblUnitTableAdapter();
            return unitname.UnitNameGetData();
        }

        public DataTable JobstaTIONNAME(int unit)
        {
            TblUnitTableAdapter jobname = new TblUnitTableAdapter();
            return jobname.JobStationGetData(unit);
        }

        public DataTable EmployeeKPIView(int intType, int p, DateTime evdate, int jobstation, int monthrange, int kpitype)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, Convert.ToString(0), evdate, jobstation, monthrange, kpitype);
        }

        public DataTable ExaminedView(int intType, int p1, DateTime evdate, int enroll, int p2, int p3)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, 0, 0);
        }

        public DataTable EmployeeDetalisPerformance(int intType, int p, DateTime evdate, int enroll, int intMonth, int intYear)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, intMonth, intYear);
        }

        

        public DataTable KPIEmployeeJobDescriptionXML(int intType, string xmlStringEmployee, DateTime evdate, int enroll, int monthrange, int kpitype)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, xmlStringEmployee, evdate, enroll, monthrange, kpitype);
        }

        

        public DataTable EmployeeJDC(int intType, int p, DateTime evdate, int enroll, int month, int year)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, month, year);
        }

        public DataTable EmployeeBehavour(int intType, int p, DateTime evdate, int enroll, int month, int year)
        {
            SprEmpKPIPerformanceTableAdapter behaviour = new SprEmpKPIPerformanceTableAdapter();
            return behaviour.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, month, year);
        }

        public DataTable ExamineIssueallxmlinsert(int intPart, string xmlStringKPIEX, string xmlStringKPIJDC, string xmlStringKPIBehave, DateTime evdate, int kpienroll, int dtmonth, int enroll,int tskw,int jdw)
        {
            SprEmpKPIPerformanceExamineTableAdapter exmpins = new SprEmpKPIPerformanceExamineTableAdapter();
            return exmpins.SprExamineXmlGetData(intPart, xmlStringKPIEX, xmlStringKPIJDC, xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll, tskw, jdw);
        }

        public DataTable ExamineIssueJDCandBehaviorxmlinsert(int intPart, int p, string xmlStringKPIJDC, string xmlStringKPIBehave, DateTime evdate, int kpienroll, int dtmonth, int enroll,int tskw,int jdw)
        {
            SprEmpKPIPerformanceExamineTableAdapter exmpinsjdc = new SprEmpKPIPerformanceExamineTableAdapter();
            return exmpinsjdc.SprExamineXmlGetData(intPart, Convert.ToString(0), xmlStringKPIJDC, xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll,tskw, jdw);
        }

       

      

       

        public DataTable EmpJobDescription(int enroll)
        {
            TblEmployeePerformJobDesViewTableAdapter kpbhave = new TblEmployeePerformJobDesViewTableAdapter();
            return kpbhave.EmpJDCViewssGetData(enroll);
        }

        public DataTable EmployeeJDCTotalsum(int intType, int p, DateTime evdate, int enroll, int month, int year)
        {
            SprEmpKPIPerformanceTableAdapter kpempview = new SprEmpKPIPerformanceTableAdapter();
            return kpempview.sprKPIGetData(intType, Convert.ToString(0), evdate, enroll, month, year);
        }

        public DataTable ExamineIssueTaskandBehaviorxmlinsert(int intPart, string xmlStringKPIEX, int p, string xmlStringKPIBehave, DateTime evdate, int kpienroll, int dtmonth, int enroll,int tskw,int jdw)
        {
            SprEmpKPIPerformanceExamineTableAdapter exmpinsjdc = new SprEmpKPIPerformanceExamineTableAdapter();
            return exmpinsjdc.SprExamineXmlGetData(intPart, xmlStringKPIEX, Convert.ToString(0), xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll, tskw, jdw);
   
        }
    }
}

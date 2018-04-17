using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using HR_DAL.Reports.SalaryReports_TDSTableAdapters;

namespace HR_BLL.Reports
{
   public class SalaryReportInfo
    {
       public DataTable GetSalaryReportData(DateTime dteSalaryGenerateDate, int? intUnitID, int intJobStationId)
       {
           //Summary    :   This function will use to get Salary report data to generate salay report
           //Created    :   Md. Yeasir Arafat / Mar-14-2012
           //Modified   :   
           //Parameters :   salary generate date , unit id and job station

           ReportGetEmployeeSalaryReportDetailsTableAdapter tbl = new ReportGetEmployeeSalaryReportDetailsTableAdapter();
           return tbl.GetSalaryReportData(dteSalaryGenerateDate, intUnitID, intJobStationId);
       }
       public DataTable SalaryStatementByEmployeeId(int? intUserID, string empCode)
       {
           //Summary    :   This function will use to generate employee's salary info
           //Created    :   Md. Yeasir Arafat / Apr-21-2012
           //Modified   :   
           //Parameters :   empCode

           SalaryStatementByEmployeeIdTableAdapter tbl = new SalaryStatementByEmployeeIdTableAdapter();
           return tbl.GetData(intUserID, empCode);
       }

       public DataTable GetSalaryAdviceandSupporting(int? unit, int? station, DateTime date, string viewtype)
       {
           try
           {
               SprSalaryAdviceToBankTableAdapter tbladp = new SprSalaryAdviceToBankTableAdapter();
               return tbladp.GetAdviceSupportingData(unit, station, date, viewtype);
           }
           catch
           { return new DataTable(); }
       }


    }
}

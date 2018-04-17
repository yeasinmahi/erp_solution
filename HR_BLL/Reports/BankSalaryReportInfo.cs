using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Reports.ReportDataTDSTableAdapters;

namespace HR_BLL.Reports
{
   public class BankSalaryReportInfo
    {
       public DataTable GetSalaryReportData(DateTime dteSalaryGenerateDate, int? intUnitID, int intJobStationId)
       {
           //Summary    :   This function will use to get Salary report data to generate salay report
           //Created    :   Md. Yeasir Arafat / Mar-14-2012
           //Modified   :   
           //Parameters :   salary generate date , unit id and job station

           ReportGetEmployeeSalaryReportDetailsTableAdapter objReportGetEmployeeSalaryReportDetailsTableAdapter = new ReportGetEmployeeSalaryReportDetailsTableAdapter();
           objReportGetEmployeeSalaryReportDetailsTableAdapter = new ReportGetEmployeeSalaryReportDetailsTableAdapter();
           return objReportGetEmployeeSalaryReportDetailsTableAdapter.GetSalaryReportData(dteSalaryGenerateDate, intUnitID, intJobStationId);
       }
    }
}

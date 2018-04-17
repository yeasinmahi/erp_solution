using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.PaySlip.PayslipTDSTableAdapters;

namespace HR_BLL.PaySlip
{
    public class PayslipGenerator
    {
        public DataTable DataForGeneratePayslip(int? unitID, int? jobSationID, DateTime dteSalaryGenerationDate)
        {
            //Summary    :   This function will use to generate payslip
            //Created    :   Md. Yeasir Arafat / Mar-18-2012
            //Modified   :   
            //Parameters :   unitID,jobSationID,dteSalaryGenerationDate

            GeneratePayslipByUnitJobSationAndSalaryGenerationDateTableAdapter objGeneratePayslipByUnitJobSationAndSalaryGenerationDateTableAdapter = new GeneratePayslipByUnitJobSationAndSalaryGenerationDateTableAdapter();
            return objGeneratePayslipByUnitJobSationAndSalaryGenerationDateTableAdapter.GeneratePayslipByUnitJobsationAndSalaryGenationDate(unitID, jobSationID, dteSalaryGenerationDate);
        }
        public DataTable DataForGeneratePayslipByEmployeeID(int? empID, int? unitID, int? jobSationID, DateTime dteSalaryGenerationDate)
        {
            //Summary    :   This function will use to generate employee wise payslip
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :   empID,unitID,jobSationID,dteSalaryGenerationDate

            GeneratePayslipByEmployeeIDTableAdapter objGeneratePayslipByEmployeeIDTableAdapter = new GeneratePayslipByEmployeeIDTableAdapter();
            return objGeneratePayslipByEmployeeIDTableAdapter.GeneratePayslipByEmployeeID(empID,unitID, jobSationID, dteSalaryGenerationDate);
        }

        public DataTable GetDataForGeneratePaySlip(int? unitID, int? jobSationID, DateTime dtePayrollGenerationdate)
        {
            //Summary    :   This function will use to load paySlip DataGrid
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :   unitID,jobSationID,dteSalaryGenerationDate

            GetDataForGeneratePaySlipTableAdapter objGetDataForGeneratePaySlipTableAdapter = new GetDataForGeneratePaySlipTableAdapter();
            return objGetDataForGeneratePaySlipTableAdapter.GetDataForGeneratePaySlip(unitID, jobSationID, dtePayrollGenerationdate);
        }
    }
}

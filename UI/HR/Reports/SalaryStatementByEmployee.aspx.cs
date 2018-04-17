using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;
using HR_BLL.Employee;
using System.Data;
using HR_BLL.Reports;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class SalaryStatementByEmployee : BasePage
    {
        SalaryReportInfo objSalaryReportInfo = new SalaryReportInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to get employeeID by userId and than load report
            //Created    :   Md. Yeasir Arafat / June-05-2012
            //Modified   :   
            //Parameters :


            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
                ShowReportDetails();
            }

        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to show report 
            //Created    :   Md. Yeasir Arafat / June-05-2012
            //Modified   :   
            //Parameters :   

            objSalaryReportInfo = new SalaryReportInfo();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objSalaryReportInfo.SalaryStatementByEmployeeId(int.Parse(hdnUserID.Value), null);//here employee code is null because this form is run by user id

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/EmployeesSalaryStatement.rdlc");

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsSalaryStatement";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }
    }
}
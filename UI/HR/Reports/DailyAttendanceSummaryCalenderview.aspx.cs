using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Employee;
using HR_BLL.Reports;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class DailyAttendanceSummaryCalenderview : BasePage
    {
        EmployeeAttendanceReports objEmployeeAttendanceReports = new EmployeeAttendanceReports();
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to get employeeID by userId and than load report
            //Created    :   Md. Yeasir Arafat / Apr-16-2012
            //Modified   :   
            //Parameters :

            if (!IsPostBack)
            {
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
                pnlUpperControl.DataBind();
                hdnEmployeeID.Value = objEmployeeBasicInfo.GetEmployeeIdByUserIdOrEmpcode(int.Parse(hdnUserID.Value.ToString()), null);

                ShowReportDetails(int.Parse(hdnEmployeeID.Value), DateTime.Now.Month, DateTime.Now.Year);
            }
            /*Create a Drillthrough even handler for load report after clicking on >> button */
            ReportViewer1.Drillthrough += new DrillthroughEventHandler(DemoDrillthroughEventHandler);
        }

        private void ShowReportDetails(int intEmployeeID, int intMonthID, int intYearId)
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Md. Yeasir Arafat / Apr-16-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId

            #region Load Employee's Basic Information
            DataTable oDT_EmpInfo = new DataTable();
            oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(int.Parse(hdnUserID.Value.ToString()), null);
            if (oDT_EmpInfo.Rows.Count > 0)
            {
                hdnName.Value = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                hdnUnitName.Value = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                hdnDepartmentName.Value = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                hdnDesignation.Value = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
            }
            #endregion

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/DailyAttendanceSummaryCalenderview.rdlc");
            objEmployeeAttendanceReports = new EmployeeAttendanceReports();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objEmployeeAttendanceReports.AttenanceDailySummaryReportCalanderView(intEmployeeID, intMonthID, intYearId);
            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("intEmployeeId", intEmployeeID.ToString()));
                parameters.Add(new ReportParameter("MonthNum", intMonthID.ToString()));
                parameters.Add(new ReportParameter("Year", intYearId.ToString()));

                //add employeee's information parameter
                parameters.Add(new ReportParameter("Name", hdnName.Value.ToString()));
                parameters.Add(new ReportParameter("UnitName", hdnUnitName.Value.ToString()));
                parameters.Add(new ReportParameter("DepartmentName", hdnDepartmentName.Value.ToString()));
                parameters.Add(new ReportParameter("Designation", hdnDesignation.Value.ToString()));

                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsAttendanceDailySummaryCalendarview";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }
        void DemoDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
        {
            //Summary    :   This function will use to load report again due to <</>>  buttton click 
            //Created    :   Md. Yeasir Arafat / Apr-16-2012
            //Modified   :   
            //Parameters :   

            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            int intEmployeeID = int.Parse(hdnEmployeeID.Value.ToString());
            int intMonthID = int.Parse(DrillThroughValues[1].Values[0].ToString());
            int intYearId = int.Parse(DrillThroughValues[2].Values[0].ToString());

            /*Get report data source*/
            objEmployeeAttendanceReports = new EmployeeAttendanceReports();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objEmployeeAttendanceReports.AttenanceDailySummaryReportCalanderView(intEmployeeID, intMonthID, intYearId);

            /*Bind data source with report*/
            LocalReport localReport = (LocalReport)e.Report;
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("odsAttendanceDailySummaryCalendarview", oDTReportData));
            localReport.EnableHyperlinks = true;

            /*Add parameter to the report*/
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("intEmployeeId", intEmployeeID.ToString()));
            parameters.Add(new ReportParameter("MonthNum", intMonthID.ToString()));
            parameters.Add(new ReportParameter("Year", intYearId.ToString()));

            //add employeee's information parameter
            parameters.Add(new ReportParameter("Name", hdnName.Value.ToString()));
            parameters.Add(new ReportParameter("UnitName", hdnUnitName.Value.ToString()));
            parameters.Add(new ReportParameter("DepartmentName", hdnDepartmentName.Value.ToString()));
            parameters.Add(new ReportParameter("Designation", hdnDesignation.Value.ToString()));

            localReport.SetParameters(parameters);
            localReport.Refresh();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Reports;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_BLL.Global;
using UI.ClassFiles;


namespace UI.HR.Reports
{
    public partial class PublicDailyAttendanceSummaryTimeview : BasePage
    {
        static int intLoginUerId;
        static int intjobStationID;
        EmployeeAttendanceReports objEmployeeAttendanceReports = new EmployeeAttendanceReports();
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to get employeeID by userId and than load report
            //Created    :   Md. Yeasir Arafat / June-28-2012
            //Modified   :   
            //Parameters :


            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
            }

            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        }
        /*[WebMethod]
        [ScriptMethod]
        public static string[] GetAutoFillEmployeeListBySearchKey(string prefixText, int count)
        {
            //Summary    :   This function will use to get data for auto suggetion searchbox
            //Created    :   Md. Yeasir Arafat / June-28-2012
            //Modified   :   
            //Parameters :

            return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        }*/
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to show report
            //Created    :   Md. Yeasir Arafat / June-28-2012
            //Modified   :   
            //Parameters :

            if (!String.IsNullOrEmpty(AutoCompleteBox.Text))
            {
                string strSearchKey = AutoCompleteBox.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdfEmpCode.Value = searchKey[1];
                hdnEmployeeID.Value = objEmployeeBasicInfo.GetEmployeeIdByUserIdOrEmpcode(null, hdfEmpCode.Value);

                ShowReportDetails(int.Parse(hdnEmployeeID.Value), DateTime.Now.Month, DateTime.Now.Year, hdfEmpCode.Value);
            }
        }

        private void ShowReportDetails(int intEmployeeID, int intMonthID, int intYearId, string strEmpCode)
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Md. Yeasir Arafat / June-28-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId

            #region Load Employee's Basic Information
            DataTable oDT_EmpInfo = new DataTable();
            oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(null, strEmpCode);
            if (oDT_EmpInfo.Rows.Count > 0)
            {
                hdnName.Value = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                hdnUnitName.Value = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                hdnDepartmentName.Value = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                hdnDesignation.Value = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
            }
            #endregion

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/DailyAttendanceSummaryTimeview.rdlc");
            //string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/Copy of DailyAttendanceSummaryTimeview.rdlc");
            objEmployeeAttendanceReports = new EmployeeAttendanceReports();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objEmployeeAttendanceReports.DailyAttendanceSummaryTimeview(strEmpCode, DateTime.Parse((txtFromDate.Text == "" ? DateTime.Now.ToShortDateString() : txtFromDate.Text)), DateTime.Parse((txtToDate.Text == "" ? DateTime.Now.ToShortDateString() : txtToDate.Text)));
            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(MySubreportProcessingEventHandler);

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
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
                reportDataSource.Name = "odsAttendanceDailySummaryTimeview";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }
        private void MySubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            //You can get parameter from main report 
            //int paramname = int.Parse(e.Parameters[0].Values[0].ToString());
            //You can also add parameter in sub report if you  need like main report
            string dteAttendanceDate = e.Parameters["dteAttendanceDate"].Values[0].ToString();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objEmployeeAttendanceReports.DailyAttendanceSummaryTimeviewSubreport(hdfEmpCode.Value.ToString(), DateTime.Parse(dteAttendanceDate));

            //Now add sub report data source     
            e.DataSources.Add(new ReportDataSource("odsDailyAttendanceSummaryTimeviewSubreport", oDTReportData));
        }
    }
}
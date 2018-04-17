using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using Microsoft.Reporting.WebForms;
using HR_BLL.Global;
using HR_BLL.Reports;
using System.Data;
using HR_DAL.Reports;
using HR_BLL.Employee;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeAttendanceDateWise : BasePage
    {

        ReportDataTDS.SprEmployeeDateWiseAttendanceDataTable objDataTbl = null;
        static int intLoginUerId;
        static int intjobStationID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        }

        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetEmployeeList(string prefixText, int count)
        //{
        //    return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        //}
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
            string empCode = txtEmpNameCode.Text;
            string[] spltData = empCode.Split(',');
            string empStrCode = spltData[1];

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/DatewiseAttendanceInfo.rdlc");
            EmployeeAttendanceReports objDatewiseAttendanceReport = new EmployeeAttendanceReports();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objDatewiseAttendanceReport.GetEmployeeDateWiseAttendance(empStrCode, txtFrmDate.Text, txtToDate.Text, rdoType.SelectedIndex);
            objDataTbl = objDatewiseAttendanceReport.GetEmployeeDateWiseAttendance(empStrCode, txtFrmDate.Text, txtToDate.Text, rdoType.SelectedIndex);

            if (oDTReportData.Rows.Count > 0)
            {
                DateWiseAttendanceReportViewer.Reset(); //important
                DateWiseAttendanceReportViewer.ProcessingMode = ProcessingMode.Local;
                LocalReport objReport = DateWiseAttendanceReportViewer.LocalReport;
                objReport.ReportPath = path;
                string dateVal = "From: " + txtFrmDate.Text + "      To: " + txtToDate.Text;

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("UnitName", objDataTbl[0].strJobStationName.ToString().ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", objDataTbl[0].strStationAddress.ToString().ToUpper()));
                parameters.Add(new ReportParameter("Title", "Daily Attendance Summary"));
                parameters.Add(new ReportParameter("Date", dateVal));

                DateWiseAttendanceReportViewer.LocalReport.SetParameters(parameters);
                DateWiseAttendanceReportViewer.ShowParameterPrompts = false;
                DateWiseAttendanceReportViewer.ShowPromptAreaButton = false;
                DateWiseAttendanceReportViewer.LocalReport.Refresh();

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsDailyEmployyAttendance";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


            #region No Need These Parameters
            //string ReportParameters = "";
            //ReportParameters = ReportParameters + (ReportParameters != "" ? "AND" : ReportParameters);

            //if (!String.IsNullOrEmpty(ddlUnit.SelectedValue.ToString()))
            //{
            //    ReportParameters = ReportParameters + (ReportParameters != "" ? "AND" : ReportParameters);
            //    ReportParameters = ReportParameters + ddlUnit.SelectedValue.ToString();
            //}

            //if (!String.IsNullOrEmpty(ddlJobStation.SelectedValue.ToString()))
            //{
            //    ReportParameters = ReportParameters + (ReportParameters != "" ? "AND" : ReportParameters);
            //    ReportParameters = ReportParameters + ddlJobStation.SelectedValue.ToString();
            //}
            //if (!String.IsNullOrEmpty(txtEmpNameCode.Text))
            //{
            //    string empCode = txtEmpNameCode.Text;
            //    string[] spltData = empCode.Split(',');
            //    string empStrCode = spltData[1];
            //    ReportParameters = ReportParameters + (ReportParameters != "" ? "AND" : ReportParameters);
            //    ReportParameters = ReportParameters + empStrCode;
            //}
            //if (!String.IsNullOrEmpty(txtDate.Text))
            //{
            //    ReportParameters = ReportParameters + (ReportParameters != "" ? "AND" : ReportParameters);
            //    ReportParameters = ReportParameters + txtDate.Text;
            //}

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Focus", "window.open('ReportViewer.aspx?ReportName=DatewiseAttendanceInfo&ReportParameters=" + ReportParameters + "',null,'height=900, width=750,status= no, resizable= no, scrollbars=no, toolbar=no,location=no,menubar=no ');", true);
            #endregion

        }

    }
}
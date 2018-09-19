using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Employee;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_BLL.Benifit.Report;
using System.Text.RegularExpressions;
using HR_BLL.Global;
using System.Web.Services;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.Benifit.Report
{
    public partial class PfEmployeesBalance : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Benifit/Report/PfEmployeesBalance.aspx";
        string stop = "stopping HR/Benifit/Report/PfEmployeesBalance.aspx";

        static int intLoginUerId;
        static int intjobStationID;
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to get employeeID by userId and than load report
            //Created    :   Md. Yeasir Arafat / September-17-2012
            //Modified   :   
            //Parameters :


            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

            }
            //intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            //intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            //result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            result = objAutoSearch_BLL.AutoSearchEmployeesData(1056, 1, strSearchKey);
            return result;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to show report
            //Created    :   Md. Yeasir Arafat / September-17-2012
            //Modified   :   
            //Parameters :

            var fd = log.GetFlogDetail(start, location, "btnShowReport_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/Report/PfEmployeesBalance.aspx btnShowReport_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!String.IsNullOrEmpty(txtSearchEmployee.Text))
            {
                string strSearchKey = txtSearchEmployee.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdfEmpCode.Value = searchKey[1];

                ShowReportDetails(hdfEmpCode.Value);
            }
            fd = log.GetFlogDetail(stop, location, "btnShowReport_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void ShowReportDetails(string strEmpCode)
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Md. Yeasir Arafat / September-17-2012
            //Modified   :   
            //Parameters :   strEmpCode

            var fd = log.GetFlogDetail(start, location, "ShowReportDetails", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/Report/PfEmployeesBalance.aspx ShowReportDetails", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            #region Load Employee's Basic Information
            DataTable oDT_EmpInfo = new DataTable();
            oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(null, strEmpCode);
            if (oDT_EmpInfo.Rows.Count > 0)
            {
                hdnName.Value = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                hdnUnitName.Value = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                hdnDepartmentName.Value = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                hdnDesignation.Value = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
                hdnJoiningDate.Value = DateTime.Parse(oDT_EmpInfo.Rows[0]["dteJoiningDate"].ToString()).ToString("MMMM-dd-yyyy");
            }
            #endregion

            string path = HttpContext.Current.Server.MapPath("~/HR/Benifit/Report/ReportTemplate/PfEmployeesBalance.rdlc");
            PfEmployeesBalance_BLL objPfEmployeesBalance_BLL = new PfEmployeesBalance_BLL();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objPfEmployeesBalance_BLL.PfEmployeesBalance(strEmpCode);
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
                parameters.Add(new ReportParameter("strEmployeeName", hdnName.Value.ToString()));
                parameters.Add(new ReportParameter("strUnit", hdnUnitName.Value.ToString()));
                parameters.Add(new ReportParameter("strDepatrment", hdnDepartmentName.Value.ToString()));
                parameters.Add(new ReportParameter("strDesignation", hdnDesignation.Value.ToString()));
                parameters.Add(new ReportParameter("dteJoiningDate", hdnJoiningDate.Value.ToString()));

                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsPfEmployeesBalance";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "ShowReportDetails", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

    }
}
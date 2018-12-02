using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HR_BLL.Employee;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeProfile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/EmpProfile.rdlc");
            EmployeeBasicInfo empProfile = new EmployeeBasicInfo();
            DataTable oDTReportData = new DataTable();
            oDTReportData = (DataTable)empProfile.GetEmployeeProfileData(int.Parse(ddlJobStation.SelectedValue));
            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.ReportPath = path;

                string dateVal = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("JobStation", ddlJobStation.SelectedItem.Text));
                parameters.Add(new ReportParameter("JobStationAddress", "Dhaka-100"));
                parameters.Add(new ReportParameter("Title", "Employee Profile"));
                parameters.Add(new ReportParameter("Date", dateVal));

                ReportViewer1.LocalReport.SetParameters(parameters);


                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsEmpProfile";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_BLL.Reports;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeStatusMonthly : BasePage
    {
        int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = int.Parse(Session[SessionParams.USER_ID].ToString());
            //userID = 1;
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Mir Mezbah Uddin / Apr-28-2012
            //Modified   :   
            //Parameters :   JobStation,Date


            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/EmpMonthlyAttandanceReport.rdlc");
            DataTable oDTReportData = new DataTable();
            //string unitName = "", unitAddress = "";



            bool ysnOB = true;
            DateTime selectedDate = CommonClass.GetDateAtSQLDateFormat(txtDate.Text);

            EmployeeStatus empStatus = new EmployeeStatus();
            oDTReportData = empStatus.EmpMonthlyStatusMonthly(int.Parse(ddlJobStation.SelectedValue), selectedDate);

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                string monthName = GetMonthName(selectedDate.Month);

                ////if (txtFrom.Text.Trim() == "")
                ////{
                ////    dateVal = "As on: " + txtTo.Text;
                ////}
                ////else
                ////{
                ////    dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                ////}

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("JobStation", "Job Station: " + ddlJobStation.SelectedItem.ToString()));
                parameters.Add(new ReportParameter("Month", "Month of " + monthName.ToUpper() + ", " + selectedDate.Year));
                parameters.Add(new ReportParameter("Title", "Employee Monthly Status"));
                //parameters.Add(new ReportParameter("Date", dateVal));
                //parameters.Add(new ReportParameter("Total", "Total"));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsEmpMonthlyAttandanceReport";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }

        private string GetMonthName(int monthID)
        {
            if (monthID == 1)
                return "January";
            else if (monthID == 2)
                return "February";
            else if (monthID == 3)
                return "March";
            else if (monthID == 4)
                return "April";
            else if (monthID == 5)
                return "May";
            else if (monthID == 6)
                return "June";
            else if (monthID == 7)
                return "July";
            else if (monthID == 8)
                return "August";
            else if (monthID == 9)
                return "September";
            else if (monthID == 10)
                return "October";
            else if (monthID == 11)
                return "November";
            else
                return "December";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using HR_BLL.Benifit;
using HR_BLL.Reports;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Reports
{
    public partial class UnitwiseBonusDetails_Report : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Reports/BonusDetailsUnitwise_Report.aspx";
        string stop = "stopping HR/Reports/BonusDetailsUnitwise_Report.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToShortDateString();
                pnlUpperControl.DataBind();
                hdnLoginUserID.Value = Session[SessionParams.USER_ID].ToString();
            }
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShowReport_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Reports/BonusDetailsUnitwise_Report.aspx btnShowReport_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            //Summary    :   This function will use to Show Unitwise Bonus report
            //Created    :   Md. Yeasir Arafat / July-30-2012
            //Modified   :   
            //Parameters :


            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/BonusDetailsUnitwise.rdlc");
            BonusReport objBonusReport = new BonusReport();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objBonusReport.GetUnitwiseBonusDetails(int.Parse(ddlBonusType.SelectedValue.ToString()), DateTime.Parse(txtDate.Text), int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlJobStation.SelectedValue.ToString()));
            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.ReportPath = path;
                ReportDataSource reportDataSource = new ReportDataSource();


                string bonusName = oDTReportData.Rows[0]["strBonusName"].ToString() + "," + oDTReportData.Rows[0]["intYearId"].ToString() + "  ";
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("BonusName", bonusName));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                reportDataSource.Name = "odsUnitwiseBonusDetails";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "btnShowReport_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
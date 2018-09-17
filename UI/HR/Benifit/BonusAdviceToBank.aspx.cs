using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using System.Data;
using Microsoft.Reporting.WebForms;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Benifit
{
    public partial class BonusAdviceToBank : Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Benifit/BonusAdviceToBank.aspx";
        string stop = "stopping HR/Benifit/BonusAdviceToBank.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/BonusAdviceToBank.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {

                string intUnitID = Request.QueryString["intUnitID"];
                string intBonusId = Request.QueryString["intBonusId"];
                ShowReportDetails(intUnitID, intBonusId);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void ShowReportDetails(string intUnitID, string intBonusId)
        {
            var fd = log.GetFlogDetail(start, location, "ShowReportDetails", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/BonusAdviceToBank.aspx ShowReportDetails", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/BonusAdviceToBank.rdlc");

                Bonus_BLL objBonus_BLL = new Bonus_BLL();
                DataTable oDTReportData = new DataTable();
                oDTReportData = objBonus_BLL.GetUnitwiseBonusDetailsByUnitID(int.Parse(intUnitID), int.Parse(intBonusId));

                if (oDTReportData.Rows.Count > 0)
                {
                    ReportViewer1.Reset(); //important
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.EnableHyperlinks = true;

                    LocalReport objReport = ReportViewer1.LocalReport;
                    objReport.DataSources.Clear();
                    objReport.ReportPath = path;

                    string bonusName = oDTReportData.Rows[0]["strBonusName"].ToString() + "," + oDTReportData.Rows[0]["intYearId"].ToString() + "  ";
                    string monthName = oDTReportData.Rows[0]["strMonthName"].ToString();
                    string monthYear = monthName + ", " + oDTReportData.Rows[0]["intYearId"].ToString() + "  ";
                    // Add Parameter 
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    parameters.Add(new ReportParameter("MonthYear", monthYear));
                    parameters.Add(new ReportParameter("BonusName", bonusName));
                    ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.ShowParameterPrompts = false;
                    ReportViewer1.ShowPromptAreaButton = false;
                    ReportViewer1.LocalReport.Refresh();

                    //Add Datasourdce
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "odsReportData";
                    reportDataSource.Value = oDTReportData;
                    objReport.DataSources.Add(reportDataSource);
                    objReport.Refresh();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
            catch (Exception ex)
            {

            }

            fd = log.GetFlogDetail(stop, location, "ShowReportDetails", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
    }
}
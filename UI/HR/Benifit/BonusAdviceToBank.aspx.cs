using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace UI.HR.Benifit
{
    public partial class BonusAdviceToBank : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string intUnitID = Request.QueryString["intUnitID"];
                string intBonusId = Request.QueryString["intBonusId"];
                ShowReportDetails(intUnitID, intBonusId);
            }
        }

        private void ShowReportDetails(string intUnitID, string intBonusId)
        {
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

        }
    }
}
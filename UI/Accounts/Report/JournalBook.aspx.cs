using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.Books;

using System.Globalization;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.Accounts.Report;
using UI.ClassFiles;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.Accounts.Report
{
    public partial class JournalBook : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Report\\JournalBook";
        string stop = "stopping Accounts\\Report\\JournalBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                // txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {
                //SetReport();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Mir Mezbah Uddin / Apr-24-2012
            //Modified   :   
            //Parameters :   UnitName,UnitAddress,Date
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Report\\JournalBook   Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/JournalBook.rdlc");
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "";
            int userID = int.Parse(Session["sesUserID"].ToString());
            int unitID = int.Parse(ddlUnit.SelectedValue);
            bool ysnOB = true;


            JournalBookC jb = new JournalBookC();
            oDTReportData = jb.GetJournalBook(unitID, userID, txtFrom.Text, txtTo.Text, ref unitName, ref unitAddress);

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                string dateVal = "";
                if (txtFrom.Text.Trim() == "")
                {
                    dateVal = "As on: " + txtTo.Text;
                }
                else
                {
                    dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                }

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("Title", "Journal Book"));
                parameters.Add(new ReportParameter("Date", dateVal));
                //parameters.Add(new ReportParameter("Total", "Total"));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsJournalBook";
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
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        /*public void SetReport()
        {
            DataTable table = null;
            string unitName = "", unitAddress = "";       
            JournalBookC jb = new JournalBookC();
        
            int userID = int.Parse(Session["sesUserID"].ToString());
            int unitID = int.Parse(ddlUnit.SelectedValue);
        
            table = jb.GetJournalBook(unitID, userID, txtFrom.Text, txtTo.Text, ref unitName, ref unitAddress);

            if (table.Rows.Count > 0)
            {
           
                rd.Load(Server.MapPath("JournalBook.rpt"));
                rd.SetDataSource(table);

                ParameterDiscreteValue pv = new ParameterDiscreteValue();

                pv.Value = unitName.ToUpper();
                rd.SetParameterValue("UnitName", pv);

                pv.Value = unitAddress;
                rd.SetParameterValue("UnitAddress", pv);

                pv.Value = "Journal Book";
                rd.SetParameterValue("Title", pv);

                if (txtFrom.Text == "")
                {
                    pv.Value = "Upto: " + txtTo.Text;
                }
                else
                {
                    pv.Value = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                }
                rd.SetParameterValue("Date", pv);

                ReportViewer1.ReportSource = rd;
            }
            else
            {
                ReportViewer1.ReportSource = null;
            }
        }*/
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CrystalReportViewer1.ReportSource = null;
        }

        /*void Page_Unload(Object sender, EventArgs e)
        {
            rd.Close();
            rd.Dispose();
        }*/

        /*protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rd.Dispose();
            rd.Clone();
            rd.Close();
            CrystalReportViewer1.Dispose();
        }*/
    }
}

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
using UI.ClassFiles;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.Accounts.Report
{
    public partial class CashBook : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Report\\CashBook";
        string stop = "stopping Accounts\\Report\\BankBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {
                //ShowReportDetails();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ShowReportDetails();

        }

        //public void SetReport()
        //{
        //    DataTable table = null;
        //    string unitName = "", unitAddress = "";
        //    CashBookC cb = new CashBookC();

        //    int userID = int.Parse(Session["sesUserID"].ToString());
        //    int unitID = int.Parse(ddlUnit.SelectedValue);
        //    bool ysnOB = true;

        //    table = cb.GetCashBook(txtFrom.Text, txtTo.Text, unitID, ysnOB, userID, ref unitAddress, ref unitName);

        //    if (table.Rows.Count > 0)
        //    {
        //        rd = new ReportDocument();
        //        rd.Load(Server.MapPath("CashBook.rpt"));
        //        rd.SetDataSource(table);

        //        ParameterDiscreteValue pv = new ParameterDiscreteValue();

        //        pv.Value = unitName.ToUpper();
        //        rd.SetParameterValue("UnitName", pv);

        //        pv.Value = unitAddress;
        //        rd.SetParameterValue("UnitAddress", pv);

        //        pv.Value = "Cash Book";
        //        rd.SetParameterValue("Title", pv);

        //        if (txtFrom.Text == "")
        //        {
        //            pv.Value = "Upto: " + txtTo.Text;
        //        }
        //        else
        //        {
        //            pv.Value = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
        //        }
        //        rd.SetParameterValue("Date", pv);

        //        pv.Value = "Total";
        //        rd.SetParameterValue("Total", pv);

        //        CrystalReportViewer1.ReportSource = rd;
        //    }
        //    else
        //    {
        //        CrystalReportViewer1.ReportSource = null;
        //    }
        //}
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CrystalReportViewer1.ReportSource = null;
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Md. Yeasir Arafat / Apr-16-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Report\\CashBook   Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/Cashbook.rdlc");
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "";
            int userID = int.Parse(Session[SessionParams.USER_ID].ToString());
            int unitID = int.Parse(ddlUnit.SelectedValue);
            bool ysnOB = true;

            CashBookC cb = new CashBookC();
            oDTReportData = cb.GetCashBook(txtFrom.Text, txtTo.Text, unitID, ysnOB, userID, ref unitAddress, ref unitName);

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
                parameters.Add(new ReportParameter("Title", "Cash Book"));
                parameters.Add(new ReportParameter("Date", dateVal));
                parameters.Add(new ReportParameter("Total", "Total"));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsCashbook";
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

        //void Page_Unload(Object sender, EventArgs e)
        //{
        //    /*rd.Close();
        //    rd.Dispose();*/
        //}

        //protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        //{
        //    rd.Dispose();
        //    rd.Clone();
        //    rd.Close();
        //    CrystalReportViewer1.Dispose();
        //}



    }
}

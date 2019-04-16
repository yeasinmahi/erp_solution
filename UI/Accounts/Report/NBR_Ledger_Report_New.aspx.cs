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
using BLL.Accounts.ChartOfAccount;
using System.Web.Services;
using System.Web.Script.Services;
using BLL.Accounts.Ledger;

using BLL.Accounts.SubLedger;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Report
{
    public partial class NBR_Ledger_Report_New : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Report\\Ledger";
        string stop = "stopping Accounts\\Report\\Ledger";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                rdoCodeRange.Attributes.Add("onClick", "ShowHide()");
                pnlMarque.DataBind();
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {

            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCOAList(string prefixText, int count)
        {
            string str = HttpContext.Current.Session["sesType"].ToString();

            if (str == "sub")
            {
                return ChartOfAccStaticDataProvider.GetCOASubLedgerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (str == "led")
            {
                return ChartOfAccStaticDataProvider.GetCOALedgerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (str == "conLed")
            {
                return ChartOfAccStaticDataProvider.GetCOAControlLedgerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }

            return new string[0];

        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            //CrystalReportViewer1.ReportSource = null;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            // CrystalReportViewer1.ReportSource = null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SetReport();
        }

        private void PrepareTableLegSub(DataTable oDTReportData, string accountName, string accountCode, string unitName, string unitAddress, bool? isAssetOrLiabilities)
        {
            if (oDTReportData.Rows.Count > 0)
            {
                if (oDTReportData.Rows[0]["dteDate"].ToString() == "")
                {
                    //############## Calling Ladger Report ############//
                    string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/Ledger.rdlc");

                    ReportViewer1.Reset(); //important
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.EnableHyperlinks = true;

                    LocalReport objReport = ReportViewer1.LocalReport;
                    objReport.DataSources.Clear();
                    objReport.ReportPath = path;

                    string dateVal = "";

                    if (txtFrom.Text.Trim() == "")
                    {
                        if (isAssetOrLiabilities == true) dateVal = "As On " + txtTo.Text;
                        else dateVal = "Upto: " + txtTo.Text;
                    }
                    else
                    {
                        dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                    }
                    // Add Parameter 
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    parameters.Add(new ReportParameter("AccountName", accountName));
                    parameters.Add(new ReportParameter("AccountCode", "Account Code: " + accountCode));
                    parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                    parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                    parameters.Add(new ReportParameter("Title", "Schedule"));
                    parameters.Add(new ReportParameter("Date", dateVal));
                    ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.ShowParameterPrompts = false;
                    ReportViewer1.ShowPromptAreaButton = false;
                    ReportViewer1.LocalReport.Refresh();

                    //Add Datasourdce
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "odsLadger";
                    reportDataSource.Value = oDTReportData;
                    objReport.DataSources.Add(reportDataSource);
                    objReport.Refresh();
                }
                else
                {
                    //############ Calling SubLadger Report ###############//
                    string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/SubLedger.rdlc");

                    ReportViewer1.Reset(); //important
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.EnableHyperlinks = true;

                    LocalReport objReport = ReportViewer1.LocalReport;
                    objReport.DataSources.Clear();
                    objReport.ReportPath = path;

                    string dateVal = "";

                    if (txtFrom.Text.Trim() == "")
                    {
                        if (isAssetOrLiabilities == true) dateVal = "As On " + txtTo.Text;
                        else dateVal = "Upto: " + txtTo.Text;
                    }
                    else
                    {
                        dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                    }
                    // Add Parameter 
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    parameters.Add(new ReportParameter("AccountName", accountName));
                    parameters.Add(new ReportParameter("AccountCode", "Account Code: " + accountCode));
                    parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                    parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                    parameters.Add(new ReportParameter("Title", "Subsidiary Ledger"));
                    parameters.Add(new ReportParameter("Date", dateVal));
                    ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.ShowParameterPrompts = false;
                    ReportViewer1.ShowPromptAreaButton = false;
                    ReportViewer1.LocalReport.Refresh();

                    //Add Datasourdce
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "odsSubLedger";
                    reportDataSource.Value = oDTReportData;
                    objReport.DataSources.Add(reportDataSource);
                    objReport.Refresh();
                }
            }
            else
            {
                ReportViewer1.Reset();//CrystalReportViewer1.ReportSource = null;
            }
        }
        private void SetReportLegSub()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Report\\Ledger  Ledger Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DataTable oDTReportData = new DataTable();
                string accountName = "", accountCode = "", unitName = "", unitAddress = "";
                bool? isAssetOrLiabilities = false;

                char[] ch = { '[', ']' };
                string[] temp = txtCOA.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (rdoCodeRange.SelectedValue == "one" && txtCOA.Text.Trim() != "")
                {
                    LedgerC sl = new LedgerC();
                    oDTReportData = sl.GetLedgerByCode(txtFrom.Text, txtTo.Text, temp[temp.Length - 1], Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
                    PrepareTableLegSub(oDTReportData, accountName, accountCode, unitName, unitAddress, isAssetOrLiabilities);
                }
                else if ((rdoCodeRange.SelectedValue == "range" && txtCrFr.Text.Trim() != "" && txtCrTo.Text.Trim() != "") || (rdoCodeRange.SelectedValue == "parent" && txtP.Text.Trim() != ""))
                {
                    //##### Calling SubLedgerCodeRenge Report #############//

                    string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/SubLedgerCodeRange.rdlc");

                    SubLedgerC sl = new SubLedgerC();
                    if (rdoCodeRange.SelectedValue == "range")
                    {
                        oDTReportData = sl.GetSubLedgerByCodeRange(txtFrom.Text, txtTo.Text, txtCrFr.Text, txtCrTo.Text, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
                    }
                    else if (rdoCodeRange.SelectedValue == "parent")
                    {
                        oDTReportData = sl.GetSubLedgerByCodeRange(txtFrom.Text, txtTo.Text, txtP.Text, "", Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
                    }

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
                            if (isAssetOrLiabilities == true) dateVal = "As On " + txtTo.Text;
                            else dateVal = "Upto: " + txtTo.Text;
                        }
                        else
                        {
                            dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                        }
                        // Add Parameter 
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        parameters.Add(new ReportParameter("AccountName", accountName));
                        parameters.Add(new ReportParameter("AccountCode", "Account Code: " + accountCode));
                        parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                        parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                        parameters.Add(new ReportParameter("Title", "Subsidiary Ledger"));
                        parameters.Add(new ReportParameter("Date", dateVal));
                        ReportViewer1.LocalReport.SetParameters(parameters);
                        ReportViewer1.ShowParameterPrompts = false;
                        ReportViewer1.ShowPromptAreaButton = false;
                        ReportViewer1.LocalReport.Refresh();

                        //Add Datasourdce
                        ReportDataSource reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "odsSubLegderCodeRange";
                        reportDataSource.Value = oDTReportData;
                        objReport.DataSources.Add(reportDataSource);
                        objReport.Refresh();
                    }
                    else
                    {
                        ReportViewer1.Reset();//CrystalReportViewer1.ReportSource = null;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                }
                else
                {
                    ReportViewer1.Reset();//CrystalReportViewer1.ReportSource = null;
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

        private void SetReportDrCr()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Report\\Ledger  Ledger Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (txtCOA.Text.Trim() != "")
                {
                    //######### Calling Report LedgerDrCr #########//
                    string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/LedgerDrCr.rdlc");
                    DataTable oDTReportData = new DataTable();
                    string accountName = "", accountCode = "", unitName = "", unitAddress = "";
                    bool? isAssetOrLiabilities = false;

                    char[] ch = { '[', ']' };
                    string[] temp = txtCOA.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                    LedgerC sl = new LedgerC();
                    oDTReportData = sl.GetLedgerByCodeDrCr(txtFrom.Text, txtTo.Text, temp[temp.Length - 1], Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);

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
                            if (isAssetOrLiabilities == true)
                                dateVal = "As On " + txtTo.Text;
                            else dateVal = "Upto: " + txtTo.Text;
                        }
                        else
                        {
                            dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                        }


                        // Add Parameter 
                        List<ReportParameter> parameters = new List<ReportParameter>();
                        parameters.Add(new ReportParameter("AccountName", accountName));
                        parameters.Add(new ReportParameter("AccountCode", "Account Code: " + accountCode));
                        parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                        parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                        parameters.Add(new ReportParameter("Title", "Dr. Cr. Schedule"));
                        parameters.Add(new ReportParameter("Date", dateVal));
                        ReportViewer1.LocalReport.SetParameters(parameters);
                        ReportViewer1.ShowParameterPrompts = false;
                        ReportViewer1.ShowPromptAreaButton = false;
                        ReportViewer1.LocalReport.Refresh();

                        //Add Datasourdce
                        ReportDataSource reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "odsLedgerDeditCredit";
                        reportDataSource.Value = oDTReportData;
                        objReport.DataSources.Add(reportDataSource);
                        objReport.Refresh();

                    }
                    else
                    {
                        ReportViewer1.Reset(); // CrystalReportViewer1.ReportSource = null;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }
                else
                {
                    ReportViewer1.Reset(); // CrystalReportViewer1.ReportSource = null;
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
        private void SetReport()
        {
            if (RadioButtonList1.SelectedValue == "sub")
            {
                SetReportLegSub();
            }
            else
            {
                if (RadioButtonList2.SelectedValue == "gen")
                {
                    SetReportLegSub();
                }
                else
                {
                    SetReportDrCr();
                }
            }

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "sub")
            {
                rdoCodeRange.Visible = true;
                RadioButtonList2.Visible = false;
            }
            else
            {
                RadioButtonList2.Visible = true;
                rdoCodeRange.Visible = false;
            }

            Session["sesType"] = RadioButtonList1.SelectedValue;

            // CrystalReportViewer1.ReportSource = null;
            txtCOA.Text = "";
        }
        protected void RadioButtonList1_Load(object sender, EventArgs e)
        {
            Session["sesType"] = RadioButtonList1.SelectedValue;
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

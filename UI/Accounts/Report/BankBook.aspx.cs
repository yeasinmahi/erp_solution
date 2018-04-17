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
using System.Web.Services;
using System.Web.Script.Services;
using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using BLL.Accounts.Books;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;

namespace UI.Accounts.Report
{

    public partial class BankBook : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
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
            return ChartOfAccStaticDataProvider.GetCOADataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            //CrystalReportViewer1.ReportSource = null;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            //CrystalReportViewer1.ReportSource = null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    :   Md. Yeasir Arafat / Apr-16-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId


            string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/Bankbook.rdlc");
            DataTable oDTReportData = new DataTable();



            string accountName = "", accountCode = "", unitName = "", unitAddress = "";
            bool? isAssetOrLiabilities = false;

            //char[] ch = { '[', ']' };
            //string[] temp = txtCOA.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            BankBookC bb = new BankBookC();
            oDTReportData = bb.GetBankBook(ddlAccount.SelectedValue, txtFrom.Text, txtTo.Text, ddlUnit.SelectedValue, true, Session["sesUserID"].ToString()
                , ref accountCode, ref accountName, ref unitAddress, ref unitName);

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
                parameters.Add(new ReportParameter("AccountName", accountName));
                parameters.Add(new ReportParameter("AccountCode", "Account Code: " + accountCode));
                parameters.Add(new ReportParameter("Total", "Total"));
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("Title", "Bank Book"));
                parameters.Add(new ReportParameter("Date", dateVal));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsBankBook";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }




        protected void ddlAccount_DataBound(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // GetReport();
                ShowReportDetails();
            }
        }


    }
}

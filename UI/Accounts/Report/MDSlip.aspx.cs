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

using BLL.Accounts.MDSlip;

using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;

namespace UI.Accounts.Report
{
    public partial class MDSlip : BasePage
    {
        //ReportDocument rpt=new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {
                // GetReport();
            }
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


            string path = HttpContext.Current.Server.MapPath("~/Accounts/Report/ReportTemplates/MdSlip.rdlc");
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "", userName = ""; ;
            decimal? limlitWC = 0, limitPL = 0, usedWC = 0, usedPL = 0, cashinHand = 0, cashAtBank = 0;
            string reportType = "Daily Receipts and Payments Statement";

            string unitID = ddlUnit.SelectedValue;
            string userID = Session[SessionParams.USER_ID].ToString();
            MDSlipC mdslip = new MDSlipC();
            oDTReportData = mdslip.GetDataForMDSlip(CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), int.Parse(unitID), int.Parse(userID), ref unitName, ref unitAddress, ref userName, ref usedWC, ref usedPL, ref limlitWC, ref limitPL, ref cashinHand, ref cashAtBank);



            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                string dateVal = txtFrom.Text;


                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("unitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("unitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("reportType", reportType));
                parameters.Add(new ReportParameter("dateParam", dateVal));


                parameters.Add(new ReportParameter("WCLimit", limlitWC.ToString()));
                parameters.Add(new ReportParameter("PLLimit", limitPL.ToString()));
                parameters.Add(new ReportParameter("WCUsed", usedWC.ToString()));
                parameters.Add(new ReportParameter("PLUsed", usedPL.ToString()));
                parameters.Add(new ReportParameter("CAH", cashinHand.ToString()));
                parameters.Add(new ReportParameter("CAB", cashAtBank.ToString()));


                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsMDSlip";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }

        //private void GetReport()
        //{
        //    string unitName = "";
        //    string unitAddress = "";
        //    string userName = "";
        //    string reportType = "Daily Receipts and Payments Statement";
        //    string date = txtFrom.Text;
        //    decimal? limlitWC=0, limitPL=0, usedWC=0, usedPL=0,cashinHand=0, cashAtBank=0; 

        //    string unitID = ddlUnit.SelectedValue;
        //    string userID = Session["sesUserID"].ToString();



        //    rpt = new ReportDocument();


        //    MDSlipC mdslip = new MDSlipC();        
        //    DataTable tbl = mdslip.GetDataForMDSlip(CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), int.Parse(unitID), int.Parse(userID), ref unitName, ref unitAddress, ref userName,ref usedWC,ref usedPL,ref limlitWC,ref limitPL,ref cashinHand,ref cashAtBank);



        //    if (tbl.Rows.Count > 0)
        //    {
        //        rpt.Load(Server.MapPath("MDSlip.rpt"));
        //        rpt.SetDataSource(tbl);

        //        ParameterDiscreteValue uName = new ParameterDiscreteValue();
        //        ParameterDiscreteValue uAddress = new ParameterDiscreteValue();
        //        ParameterDiscreteValue rptType = new ParameterDiscreteValue();
        //        ParameterDiscreteValue dateParam1 = new ParameterDiscreteValue();

        //        ParameterDiscreteValue WC = new ParameterDiscreteValue();
        //        ParameterDiscreteValue PL = new ParameterDiscreteValue();
        //        ParameterDiscreteValue WCused = new ParameterDiscreteValue();
        //        ParameterDiscreteValue PLused = new ParameterDiscreteValue();
        //        ParameterDiscreteValue monCAH = new ParameterDiscreteValue();
        //        ParameterDiscreteValue monCAB = new ParameterDiscreteValue();

        //        uName.Value = unitName.ToUpper();
        //        uAddress.Value = unitAddress;
        //        rptType.Value = reportType;
        //        dateParam1.Value = "As on " + date;
        //        WC.Value = limlitWC;
        //        PL.Value = limitPL;
        //        WCused.Value = usedWC;
        //        PLused.Value = usedPL;
        //        monCAH.Value=cashinHand;
        //        monCAB.Value = cashAtBank;

        //        rpt.SetParameterValue("unitName", uName);
        //        rpt.SetParameterValue("unitAddress", uAddress);
        //        rpt.SetParameterValue("reportType", rptType);
        //        rpt.SetParameterValue("dateParam", dateParam1);


        //        rpt.SetParameterValue("WCLimit", WC);
        //        rpt.SetParameterValue("PLLimit", PL);
        //        rpt.SetParameterValue("WCUsed", WCused);
        //        rpt.SetParameterValue("PLUsed", PLused);
        //        rpt.SetParameterValue("CAH", monCAH);
        //        rpt.SetParameterValue("CAB", monCAB);


        //        CrystalReportViewer1.ReportSource = rpt;
        //    }
        //    else
        //    {
        //        CrystalReportViewer1.ReportSource = null;
        //    }

        //}

        //void Page_Unload(Object sender, EventArgs e)
        //{
        //    /*rpt.Close();
        //    rpt.Dispose();*/
        //}


        //protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        //{
        //    rpt.Dispose();
        //    rpt.Clone();
        //    rpt.Close();
        //    CrystalReportViewer1.Dispose();
        //}
    }
}

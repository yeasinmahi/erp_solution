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


using DAL.Accounts.Banking;
using System.Text;
using BLL;
using BLL.Accounts.Banking;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Banking.Report
{

    public partial class DepositSlip : BasePage
    {
        int top = 347, count = 0, pageCount = 1, valueMain = 0;
        StringBuilder sbDiv = new StringBuilder();
        //  ReportDocument rd = new ReportDocument();
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\Report\\DepositSlip";
        string stop = "stopping Accounts\\Banking\\Report\\DepositSlip";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = txtFrom.Text;
            }
            else
            {
                //GetReport();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            //CrystalReportViewer1.ReportSource = null;
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CrystalReportViewer1.ReportSource = null;
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CrystalReportViewer1.ReportSource = null;
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
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Report\\DepositSlip  Deposit Slip Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string path = HttpContext.Current.Server.MapPath("~/Accounts/Banking/Report/ReportTemplates/DepositSlip.rdlc");
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "";
            int userID = int.Parse(Session[SessionParams.USER_ID].ToString());
            int unitID = int.Parse(ddlUnit.SelectedValue);
            bool ysnOB = true;
            decimal totAmount = 0;


            /*JournalBookC jb = new JournalBookC();
            oDTReportData = jb.GetJournalBook(unitID, userID, txtFrom.Text, txtTo.Text, ref unitName, ref unitAddress);*/

            DepositSlipC ds = new DepositSlipC();
            oDTReportData = ds.GetAllDatas(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlBranch.SelectedValue, ddlAccount.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), CommonClass.GetDateAtSQLDateFormat(txtTo.Text), chkChq.Checked, chkDD.Checked, chkPO.Checked, chkDS.Checked, chkAdj.Checked, chkAdv.Checked, ref totAmount, ref unitName, ref unitAddress);

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
                parameters.Add(new ReportParameter("Title", "Diposit Slip"));
                parameters.Add(new ReportParameter("Date", "Date: " + CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now)));
                parameters.Add(new ReportParameter("Bank", "Bank: " + ddlBank.SelectedItem.Text));
                parameters.Add(new ReportParameter("Branch", "Branch: " + ddlBranch.SelectedItem.Text));
                parameters.Add(new ReportParameter("AccountNo", "Acc. No: " + ddlAccount.SelectedItem.Text));
                parameters.Add(new ReportParameter("ForAG", "FOR " + unitName.ToUpper()));
                parameters.Add(new ReportParameter("ForBank", "FOR " + ddlBank.SelectedItem.Text.ToUpper()));
                parameters.Add(new ReportParameter("AccOfficer", "ACCOUNTS OFFICER"));
                parameters.Add(new ReportParameter("Manager", "OFFICER/MANAGER"));
                //parameters.Add(new ReportParameter("totAmount", "OFFICER/MANAGER"));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsDepositSlip";
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

        /*private void GetReport()
        {
            pnlSolo.Visible = false;
            DataTable table = null;
            string unitName = "", unitAddress = "";
            decimal totAmount = 0;

            DepositSlipC ds = new DepositSlipC();
            table = ds.GetAllDatas(Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlBranch.SelectedValue, ddlAccount.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), CommonClass.GetDateAtSQLDateFormat(txtTo.Text), chkChq.Checked, chkDD.Checked, chkPO.Checked, chkDS.Checked, chkAdj.Checked, chkAdv.Checked, ref totAmount, ref unitName, ref unitAddress);        
            if (table.Rows.Count > 0)
            {
            
                rd.Load(Server.MapPath("DepositSlip.rpt"));
                rd.SetDataSource(table);

                ParameterDiscreteValue pv = new ParameterDiscreteValue();

                pv.Value = unitName.ToUpper();
                rd.SetParameterValue("UnitName", pv);

                pv.Value = unitAddress;
                rd.SetParameterValue("UnitAddress", pv);
                        
                pv.Value = "Date: " + CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                rd.SetParameterValue("Date", pv);

                pv.Value = "Statement Of Bank Deposit";
                rd.SetParameterValue("Title", pv);

                pv.Value = "Total";
                rd.SetParameterValue("Total", pv);

                pv.Value = "Bank: "+ddlBank.SelectedItem.Text;
                rd.SetParameterValue("Bank", pv);

                pv.Value = "Branch: "+ddlBranch.SelectedItem.Text;
                rd.SetParameterValue("Branch", pv);

                pv.Value = "Acc. No: "+ddlAccount.SelectedItem.Text;
                rd.SetParameterValue("AccountNo", pv);

                AmountFormat af = new AmountFormat();
                pv.Value = af.GetTakaInWords(totAmount, "Taka", "Only.");
                rd.SetParameterValue("InWords", pv);

                pv.Value = "FOR " + unitName.ToUpper(); 
                rd.SetParameterValue("ForAG", pv);

                pv.Value = "FOR " + ddlBank.SelectedItem.Text.ToUpper(); 
                rd.SetParameterValue("ForBank", pv);

                pv.Value = "ACCOUNTS OFFICER";
                rd.SetParameterValue("AccOfficer", pv);

                pv.Value = "OFFICER/MANAGER";
                rd.SetParameterValue("Manager", pv);

                CrystalReportViewer1.ReportSource = rd;
            }
            else
            {
                CrystalReportViewer1.ReportSource = null;
            }
        }*/
        /* protected void btnSolo_Click(object sender, EventArgs e)
         {
             //CrystalReportViewer1.ReportSource = null;
             pnlSolo.Visible = true;

             string unitName = "", unitAddress = "";
             decimal totAmount = 0;
        
             StringBuilder sb = new StringBuilder();
        
             DepositSlipC ds = new DepositSlipC();        
             DepositSlipTDS.SprAccountsVoucherBankGetDepositSlipDataTable table = ds.GetAllDatas(Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlBranch.SelectedValue, ddlAccount.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), CommonClass.GetDateAtSQLDateFormat(txtTo.Text), chkChq.Checked, chkDD.Checked, chkPO.Checked, chkDS.Checked, chkAdj.Checked, chkAdv.Checked, ref totAmount, ref unitName, ref unitAddress);
             AmountFormat af = new AmountFormat();
             string dte = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);

             foreach (DepositSlipTDS.SprAccountsVoucherBankGetDepositSlipRow row in table)
             {

                 if (count % 2 == 0)
                 {
                     sb.Append(@"<a href=""#"" onclick=""ShowPopUp('DepositSlipPop.aspx','divSolo" + pageCount + @"'," + count + @")""class=""link"">Print Page " + pageCount + @"</a></br>");

                     if (pageCount == 1)
                     {
                         sbDiv.Append("<div id='divSolo" + pageCount + @"' style=""display:none"">");
                     }
                     else
                     {
                         sbDiv.Append(@"</div><div id='divSolo" + pageCount + @"' style=""display:none"">");
                     }

                     pageCount++;
                     valueMain = 0;
                 }

                 AddSlip(ddlBank.SelectedValue, ddlBranch.SelectedItem.Text, dte, ddlAccount.SelectedItem.Text, unitName
                     , row.strType + "-" + row.strChequeNo
                     + "</br>" + row.strDepositorBank
                     + ",</br>" + row.strDepositorBranch
                     , af.SetCommaInAmount(row.monAmount, "", ""), af.GetTakaInWords(row.monAmount, "", "Only."));
            
             }

             lblSolo.Text = sb.ToString();
             lblSoloDiv.Text = sbDiv.ToString();

         }

         private void AddSlip(string bnkID, string branch, string date, string accNo, string accName, string details, string amount, string inWords)
         {
             int value = top * valueMain;

             sbDiv.Append(@"<div style=""position:absolute; z-index:0; top:" + (value + 0) + @"px;"">
                 <img src=""Images/" + ddlUnit.SelectedValue + @".png"" height=""300px"" width=""720px""/>
             </div>           
             <span style=""position:absolute; top:" + (value + 35) + @"px; left:150px; width: 130px;"">" + branch + @"</span>
             <span style=""position:absolute; top:" + (value + 35) + @"px; left:560px; width: 130px;"">" + branch + @"</span>
             <span style=""position:absolute; top:" + (value + 60) + @"px; left:210px;"">" + date + @"</span>
             <span style=""position:absolute; top:" + (value + 60) + @"px; left:630px;"">" + date + @"</span>
             <span style=""position:absolute; top:" + (value + 70) + @"px; left:20px;"">" + accNo + @"</span>
             <span style=""position:absolute; top:" + (value + 70) + @"px; left:435px;"">" + accNo + @"</span>
             <span style=""position:absolute; top:" + (value + 90) + @"px; left:40px;"">" + accName + @"</span>
             <span style=""position:absolute; top:" + (value + 90) + @"px; left:390px;"">" + accName + @"</span>   
             <span style=""position:absolute; top:" + (value + 140) + @"px; left:15px; width:130px; height: 70px;"">" + details + @"</span>
             <span style=""position:absolute; top:" + (value + 140) + @"px; left:330px; width:180px; height: 70px;"">" + details + @"</span>        
             <span style=""position:absolute; top:" + (value + 180) + @"px; left:165px; width: 130px;"">" + amount + @"</span>
             <span style=""position:absolute; top:" + (value + 180) + @"px; left:585px; width: 130px;"">" + amount + @"</span>  
             <span style=""position:absolute; top:" + (value + 215) + @"px; left:165px; width: 130px;"">" + amount + @"</span>
             <span style=""position:absolute; top:" + (value + 215) + @"px; left:585px; width: 130px;"">" + amount + @"</span>   
             <span style=""position:absolute; top:" + (value + 240) + @"px; left:80px; width: 230px;"">" + inWords + @"</span>
             <span style=""position:absolute; top:" + (value + 240) + @"px; left:400px; width: 300px;"">" + inWords + @"</span>   
             <span id=""spn0" + count + @""" style=""position:absolute; top:" + (value + 280) + @"px; left:20px;""></span>
             <span id=""spn1" + count + @""" style=""position:absolute; top:" + (value + 280) + @"px; left:335px;""></span>");

             count++;
             valueMain++;
         }

         void Page_Unload(Object sender, EventArgs e)
         {
            rd.Close();
             rd.Dispose();
         }
         protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
         {
             rd.Dispose();
             rd.Clone();
             rd.Close();
             CrystalReportViewer1.Dispose();
         }*/
    }
}

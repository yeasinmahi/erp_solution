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
using BLL.Accounts.Voucher;
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;


namespace UI.Accounts.Banking.Report
{

    public partial class ChqBudget : BasePage
    {
        //ReportDocument rd = new ReportDocument();
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\Report\\ChqBudget";
        string stop = "stopping Accounts\\Banking\\Report\\ChqBudget";
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
                GetReport();
            }
        }
        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            //CrystalReportViewer1.ReportSource = null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetReport();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetReport();
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetReport();
        }

        private void GetReport()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Report\\ChqBudget   Account Checque Budget  Report ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DataTable dt = new DataTable();

            DataTable table = null;
             string unitName = "", unitAddress = "";

             Budget bd = new Budget();
             table = bd.GetBudget(Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlBranch.SelectedValue, ddlAccount.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), bool.Parse(ddlDrCr.SelectedValue), ref unitName, ref unitAddress);
             GridView1.DataSource = table;
             GridView1.DataBind();
                /*if (table.Rows.Count > 0)
                {

                    rd.Load(Server.MapPath("ChqBudget.rpt"));
                    rd.SetDataSource(table);

                    ParameterDiscreteValue pv = new ParameterDiscreteValue();

                    pv.Value = unitName.ToUpper();
                    rd.SetParameterValue("UnitName", pv);

                    pv.Value = unitAddress;
                    rd.SetParameterValue("UnitAddress", pv);

                    pv.Value = ddlDrCr.SelectedItem.Text;
                    rd.SetParameterValue("Title", pv);

                    pv.Value = "Date: " + txtFrom.Text;
                    rd.SetParameterValue("Date", pv);

                    pv.Value = "Total";
                    rd.SetParameterValue("Total", pv);

                    pv.Value = "Grand Total";
                    rd.SetParameterValue("Grand", pv);

                    CrystalReportViewer1.ReportSource = rd;
                }
                else
                {
                    CrystalReportViewer1.ReportSource = null;
                }*/
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
        /*protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rd.Dispose();
            rd.Clone();
            rd.Close();
            CrystalReportViewer1.Dispose();
        }*/
    }

}
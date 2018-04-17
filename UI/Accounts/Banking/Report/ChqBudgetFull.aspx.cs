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
using UI.ClassFiles;

namespace UI.Accounts.Banking.Report
{

    public partial class ChqBudgetFull : BasePage
    {
        //ReportDocument rd = new ReportDocument();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void GetReport()
        {
            DataTable table = null;
             string unitName = "", unitAddress = "";

             Budget bd = new Budget();
             table = bd.GetBudgetFull(Session["sesUserID"].ToString(), CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), bool.Parse(ddlDrCr.SelectedValue), ref unitName, ref unitAddress);
             GridView1.DataSource = table;
             GridView1.DataBind();
             /* if (table.Rows.Count > 0)
             {
            
                 rd.Load(Server.MapPath("ChqBudgetFull.rpt"));
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

                 pv.Value = "Sub Total";
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
        /*protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rd.Dispose();
            rd.Clone();
            rd.Close();
            CrystalReportViewer1.Dispose();
        }*/
    }

}

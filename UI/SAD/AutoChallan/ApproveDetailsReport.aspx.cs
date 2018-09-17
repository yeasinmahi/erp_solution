using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL;
using HR_BLL.BulkSMS;
using SAD_BLL.AutoChallanBll;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.AutoChallan
{
    public partial class ApproveDetailsReport : System.Web.UI.Page
    {
        DataTable dtReports = new DataTable();
        challanandPending Report = new challanandPending();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\AutoChallan\\ApproveDetailsReport";
        string stop = "stopping SAD\\AutoChallan\\ApproveDetailsReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
               // int enroll = int.Parse("1040");
                string promotionname = Session["slipno"].ToString();

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\AutoChallan\\ApproveDetailsReport Incentive Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    if (enroll != 1040)
                {
                  DataTable  dtReportss = new DataTable();
                    dtReportss = Report.getDiractorsirApprovedetails(promotionname);
                    dgvtrgt.DataSource = dtReportss;
                    dgvtrgt.DataBind();
                }
                else
                {
                    dtReports = new DataTable();
                    dtReports = Report.getApproveDetailsAccount(promotionname);
                    dgvtrgt.DataSource = dtReports;
                    dgvtrgt.DataBind();
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



                dtReports = new DataTable();
                dtReports = Report.getTotalAmount(promotionname);

                decimal TotalAmount = decimal.Parse(dtReports.Rows[0]["amount"].ToString());
                DateTime fromdate = DateTime.Parse(dtReports.Rows[0]["dtefromdate"].ToString());
                DateTime todate = DateTime.Parse(dtReports.Rows[0]["dtetodate"].ToString());
                Session["TotalAmount"] = TotalAmount;
                Session["fromdate"] = fromdate;
                Session["todate"] = todate;

                if (enroll == int.Parse("1040"))
                {
                    Button1.Visible = true;

                }
                else
                {
                    Button1.Visible = false;
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\AutoChallan\\ApproveDetailsReport Incentive Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                decimal TotalAmount = decimal.Parse(Session["TotalAmount"].ToString());
            DateTime fromdate = DateTime.Parse(Session["fromdate"].ToString());
            DateTime todate = DateTime.Parse(Session["todate"].ToString());
            string narrations = "Being Trade Offer Bill Amount :" + TotalAmount + " Duration from " + fromdate + " To " + todate;
            decimal monIncentiveTotal = decimal.Parse(TotalAmount.ToString());

            dtReports = new DataTable();
            dtReports = Report.getJvReport(narrations, monIncentiveTotal);
            string JVnumbers = dtReports.Rows[0]["JVNumber"].ToString();

            if (dgvtrgt.Rows.Count > 0)
            {
                for (int index = 0; index < dgvtrgt.Rows.Count; index++)
                {

                    string intCustid = ((Label)dgvtrgt.Rows[index].FindControl("intCustID")).Text.ToString();
                    decimal intAccountid = decimal.Parse(((Label)dgvtrgt.Rows[index].FindControl("lblintAccID")).Text.ToString());
                    decimal amount = decimal.Parse(((TextBox)dgvtrgt.Rows[index].FindControl("lblAmount")).Text.ToString());
                    string strAccName = ((Label)dgvtrgt.Rows[index].FindControl("lblCustName")).Text.ToString();
                    string dtefromdate = ((Label)dgvtrgt.Rows[index].FindControl("lbldtefromDate")).Text.ToString();
                    string dttodate = ((Label)dgvtrgt.Rows[index].FindControl("lbldteToDate")).Text.ToString();
                    amount = -1 * amount;
                    string strnarations = "Distributor Trade Offer Bill Amount" + Convert.ToString(amount) + "Tk. Duration from  " + dtefromdate + " To " + dttodate;
                    Report.getinsertJv(JVnumbers, intAccountid, strnarations, amount, strAccName);

                }

                Report.getJVInsertTotalAmount(JVnumbers, narrations, monIncentiveTotal);


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
    }
}
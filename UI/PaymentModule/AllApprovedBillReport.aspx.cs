using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.PaymentModule
{
    public partial class AllApprovedBillReport : BasePage
    {
        #region Variable & Object Declaration 
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/AllApprovedBillReport.aspx";
        string stop = "stopping PaymentModule/AllApprovedBillReport.aspx";

        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intUnitID;
        DateTime dteFDate, dteTDate;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/AllApprovedBillReport.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                if (!IsPostBack)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetUnitList(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }
                }

                lblUnitName.Visible = false;
                lblReportName.Visible = false;
                lblFromToDate.Visible = false;
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/AllApprovedBillReport.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dteFDate = DateTime.Parse(txtFrom.Text);
                dteTDate = DateTime.Parse(txtTo.Text);

                lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlUnit.SelectedItem.ToString();
                lblReportName.Text = "Approved Bill Statement";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");
                
                dt = objVoucher.GetAllApproveReport(intUnitID, dteFDate, dteTDate);
                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblReportName.Visible = true;
                    lblFromToDate.Visible = true;

                    dgvReportForPaymentV.DataSource = dt;
                    dgvReportForPaymentV.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlUnit.SelectedItem.ToString();
            dgvReportForPaymentV.DataSource = "";
            dgvReportForPaymentV.DataBind();

            lblUnitName.Visible = false;
            lblReportName.Visible = false;
            lblFromToDate.Visible = false;
        }

























    }
}
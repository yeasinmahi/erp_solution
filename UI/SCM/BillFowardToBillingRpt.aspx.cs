using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class BillFowardToBillingRpt : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\BillFowardToBillingRpt";
        string stop = "stopping SCM\\BillFowardToBillingRpt";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SCM\\BillFowardToBillingRpt Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objPo.GetPoData(40, "", intWh, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
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

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvBill.DataSource = "";
                dgvBill.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
			var fd = GetFlogDetail("starting SCM\\BillForwardToBillingRpt Show", null);

			Flogger.WriteDiagnostic(fd);

			// starting performance tracker
			var tracker = new PerfTracker("Performance on SCM\\BillForwardToBillingRpt Show", "", fd.UserName, fd.Location,
				fd.Product, fd.Layer);

			try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                lblWHs.Text = ddlWH.SelectedItem.ToString();
                string dept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept.ToString() + '"' + "/></voucher>".ToString();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objPo.GetPoData(41, xmlData ,intWh, 0, DateTime.Now, enroll);
                if(dt.Rows.Count>0)
                {
                    lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                    dgvBill.DataSource = dt;
                    dgvBill.DataBind();
                }
               
            }
            catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}

			fd = GetFlogDetail("stopping SCM\\BillForwardToBillingRpt Show", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();

			 
		}

		private FlogDetail GetFlogDetail(string message, Exception ex)
		{
			return new FlogDetail
			{
				Product = "ERP",
				Location = "SCM",
				Layer = "BillForwardToBillingReport\\Show",
				UserName = Environment.UserName,
				Hostname = Environment.MachineName,
				Message = message,
				Exception = ex
			};
		}

	}
}
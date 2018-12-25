using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class BillFowardToBillingRpt : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly PoGenerate_BLL _bll = new PoGenerate_BLL();
        private int _enroll, _intWh;
        private readonly SeriLog _log = new SeriLog();
        private readonly string _location = "SCM";
        private readonly string _start = "starting SCM\\BillFowardToBillingRpt";
        private readonly string _stop = "stopping SCM\\BillFowardToBillingRpt";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = _log.GetFlogDetail(_start, _location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SCM\\BillFowardToBillingRpt Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    _enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    _dt = _bll.GetPoData(40, "", _intWh, 0, DateTime.Now, _enroll);
                    ddlWH.DataSource = _dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = _log.GetFlogDetail(_stop, _location, "Show", ex);
                    Flogger.WriteError(efd);
                }

                fd = _log.GetFlogDetail(_stop, _location, "Show", null);
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
            catch
            {
                // ignored
            }
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
                _enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                _intWh = int.Parse(ddlWH.SelectedValue);
                lblWHs.Text = ddlWH.SelectedItem.ToString();
                string dept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + "/></voucher>";

                _intWh = int.Parse(ddlWH.SelectedValue);
                _dt = _bll.GetPoData(41, xmlData, _intWh, 0, DateTime.Now, _enroll);
                if (_dt.Rows.Count > 0)
                {
                    lblUnitName.Text = _dt.Rows[0]["strUnit"].ToString();
                    dgvBill.DataSource = _dt;
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
using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;
namespace UI.SCM
{
    public partial class PoDocAttachment : BasePage
    {
        private DataTable _dt = new DataTable();
        private PoGenerate_BLL _objPo = new PoGenerate_BLL(); private Payment_All_Voucher_BLL _obj = new Payment_All_Voucher_BLL();
        private int _intWh; private string[] _arrayKey; private string _strType; private char[] _delimiterChars = { '[', ']' };

        private SeriLog _log = new SeriLog();
        private string _location = "SCM";
        private string _start = "starting SCM\\PoDocAttachment";
        private string _stop = "stopping SCM\\PoDocAttachment";
        private string _perform = "Performance on SCM\\PoDocAttachment";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DefaltPageLoad(); Page.Header.DataBind();
            }
            else { }
        }

        private void DefaltPageLoad()
        {
            var fd = _log.GetFlogDetail(_start, _location, "DefaltPageLoad", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(_perform + " " + "DefaltPageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                _dt = _objPo.GetUnit();
                ddlUnit.LoadWithAll(_dt, "intUnitId", "strUnit");

                if (ddlUnit.SelectedValue == "0")
                {
                    txtAllSupplier.Enabled = true;
                    txtSupplier.Enabled = false;
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
                    txtAllSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
                else
                {
                    txtAllSupplier.Enabled = false;
                    txtSupplier.Enabled = true;
                    txtAllSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }

                _dt.Clear();
                _dt = _objPo.GetPoData(21, "", 0, 0, DateTime.Now, Enroll);
                ddlDept.DataSource = _dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
                _dt.Clear();

                string dept = ddlDept.SelectedItem.ToString();
                if (dept == "Local") { dept = "Local Purchase"; }
                else if (dept == "Import") { dept = "Foreign Purchase"; }
                else { dept = "Fabrication"; }
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                _dt = _objPo.GetPoData(25, xmlData, int.Parse(ddlUnit.SelectedValue), 0, DateTime.Now, Enroll);

                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = dept;
                string unitId = ddlUnit.SelectedValue.ToString();
                Session["unitId"] = unitId;

                _dt.Clear();
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(_stop, _location, "DefaltPageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(_stop, _location, "DefaltPageLoad", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetPoUserSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchPoUser(prefixText);
        }

        #endregion====================Close===============================

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, HttpContext.Current.Session["strType"].ToString(), HttpContext.Current.Session["unitId"].ToString());
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAllSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, HttpContext.Current.Session["strType"].ToString());
        }

        #endregion====================Close===============================

        protected void btnPoUserShow_Click(object sender, EventArgs e)
        {
            int enroll = 0;
            var fd = GetFlogDetail("starting SCM\\PoDocAttachment Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoDocAttachment Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                _arrayKey = txtPoUser.Text.Split(_delimiterChars);
                string item = ""; string itemid = "";
                if (_arrayKey.Length > 0)
                {
                    item = _arrayKey[0].ToString();
                    enroll = int.Parse(_arrayKey[1].ToString());
                }

                int unitId = int.Parse(ddlUnit.SelectedValue);
                string dept = ddlDept.SelectedItem.ToString();

                _arrayKey = txtSupplier.Text.Split(_delimiterChars);
                string strSupp = ""; int supplierid = 0;

                try
                {
                    if (_arrayKey.Length > 0)
                    {
                        item = _arrayKey[0].ToString(); supplierid = int.Parse(_arrayKey[1].ToString());
                    }
                    strSupp = supplierid.ToString();
                }
                catch { }

                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text);

                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + " strSupp=" + '"' + strSupp + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                _dt = _objPo.GetPoData(34, xmlData, unitId, 0, dteFrom, enroll);
                dgvPO.DataSource = _dt;
                dgvPO.DataBind();

                lblAddress.Text = @"Akij House, 198 Bir Uttam Mir Shawkat Sarak, Tejgaon, Dhaka-1208";
                lblDate.Text = @"For The Month of " + txtdteFrom.Text + @" To " + txtdteTo.Text;
                lblunit.Text = "";
                DataTable dts = new DataTable();
                dts = _obj.GetUnitAddress(unitId);
                if (dts.Rows.Count > 0)
                {
                    if (FindControl("lblunit") is Label lbluni) lbluni.Text = dts.Rows[0]["strDescription"].ToString();
                }
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(_stop, _location, "btnPoUserShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(_stop, _location, "btnPoUserShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnPoSuppShow_Click(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(_start, _location, "btnPoSuppShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(_perform + " " + "btnPoSuppShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string strSupp = ""; int supplierid = 0;
                int unitId = int.Parse(ddlUnit.SelectedValue);
                if(unitId==0)
                {
                    _arrayKey = txtAllSupplier.Text.Split(_delimiterChars);
                    if (_arrayKey.Length > 0)
                    {
                        strSupp = _arrayKey[0].ToString(); supplierid = int.Parse(_arrayKey[1].ToString());
                    }
                    strSupp = supplierid.ToString();
                }
                else
                {
                    _arrayKey = txtSupplier.Text.Split(_delimiterChars);
                    if (_arrayKey.Length > 0)
                    {
                        strSupp = _arrayKey[0].ToString(); supplierid = int.Parse(_arrayKey[1].ToString());
                    }
                    strSupp = supplierid.ToString();
                }
                string dept = ddlDept.SelectedItem.ToString();

               

                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text);

                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + " strSupp=" + '"' + strSupp + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                _dt = _objPo.GetPoData(26, xmlData, unitId, 0, dteFrom, supplierid);
                if(_dt.Rows.Count>0)
                {
                    dgvPO.DataSource = _dt;
                    dgvPO.DataBind();

                    lblAddress.Text = "Akij House, 198 Bir Uttam Mir Shawkat Sarak, Tejgaon, Dhaka-1208";
                    lblDate.Text = "For The Month of " + txtdteFrom.Text + " To " + txtdteTo.Text;
                    lblunit.Text = "";
                    DataTable dts = new DataTable();
                    dts = _obj.GetUnitAddress(unitId);
                    if (dts.Rows.Count > 0)
                    {
                        Label lbluni = FindControl("lblunit") as Label;
                        lbluni.Text = dts.Rows[0]["strDescription"].ToString();
                    }
                }
                else
                {
                    Toaster("There is no data to show", "Bill By Supplier", Common.TosterType.Warning);
                }
                
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(_stop, _location, "btnPoSuppShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(_stop, _location, "btnPoSuppShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(_start, _location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(_perform + " " + "ddlUnit_SelectedIndexChanged", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string dept = ddlDept.SelectedItem.ToString();
                if (dept == "Local") { dept = "Local Purchase"; }
                else if (dept == "Import") { dept = "Foreign Purchase"; }
                else { dept = "Fabrication"; }
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                _dt = _objPo.GetPoData(25, xmlData, int.Parse(ddlUnit.SelectedValue), 0, DateTime.Now, Enroll);

                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = dept;
                string unitId = ddlUnit.SelectedValue.ToString();
                Session["unitId"] = unitId;
                _dt.Clear();
                if (ddlUnit.SelectedValue == "0")
                {
                    txtAllSupplier.Enabled = true;
                    txtSupplier.Enabled = false;
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
                    txtAllSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
                else
                {
                    txtAllSupplier.Enabled = false;
                    txtSupplier.Enabled = true;
                    txtAllSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(_stop, _location, "ddlUnit_SelectedIndexChanged", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(_stop, _location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDept = ddlDept.SelectedItem.ToString();
            Session["strType"] = GetDept(strDept);
            string unitId = ddlUnit.SelectedValue.ToString();
            Session["unitId"] = unitId;
        }

        private string GetDept(string strDept)
        {
            try
            {
                if (strDept == "Local") { _strType = "Local Purchase"; }
                else if (strDept == "Fabrication") { _strType = "Local Fabrication"; }
                else if (strDept == "Import") { _strType = "Foreign Purchase"; }
                return _strType;
            }
            catch { return _strType; }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(_start, _location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(_perform + " " + "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string unit = ddlUnit.SelectedItem.ToString();
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblPoId = row.FindControl("lblPoId") as Label;
                Label lblmonBillAmount = row.FindControl("lblmonBillAmount") as Label;
                Label lblBillId = row.FindControl("lblBillId") as Label;
                Label lblBillCode = row.FindControl("lblBillCode") as Label;

                string poId = lblPoId.Text.ToString();
                string billAmount = lblmonBillAmount.Text.ToString();
                string billId = lblBillId.Text.ToString();
                string billCode = lblBillCode.Text.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + unit + "','" + poId.ToString() + "','" + billAmount + "','" + billId + "','" + billCode + "');", true);
            }
            catch { }
        }

        private FlogDetail GetFlogDetail(string message, Exception ex)
        {
            return new FlogDetail
            {
                Product = "ERP",
                Location = "SCM",
                Layer = "PoDocAttachment\\Show",
                UserName = Environment.UserName,
                Hostname = Environment.MachineName,
                Message = message,
                Exception = ex
            };
        }
    }
}
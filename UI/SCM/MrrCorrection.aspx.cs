using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class MrrCorrection : BasePage
    {
        MrrCorrectionBll obj = new MrrCorrectionBll();
        DataTable dt;
        int intMRRID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowInfo();
            LoadItemInfo();
        }

        protected void btnDeleteMRR_Click(object sender, EventArgs e)
        {

            if (txtStatus.Text == "Voucher Complete")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Voucher completed. MRR cannot be Deleted.');", true); return;
            }
            else if (txtVoucherNo.Text != "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Delete JV Voucher.');", true); return;
            }
            else
            {
                try
                {
                    intMRRID = int.Parse(txtMrrNo.Text);
                    dt = new DataTable();
                    dt = obj.CorrectionMrr(1, intMRRID);
                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["msg"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }
                }
                catch { }
            }

        }
        protected void btnFreeMRR_Click(object sender, EventArgs e)
        {

            try
            {
                intMRRID = int.Parse(txtMrrNo.Text);
                dt = new DataTable();
                dt = obj.CorrectionMrr(5, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["msg"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                ShowInfo();
            }
            catch { }

        }
        protected void btnDeleteJV_Click(object sender, EventArgs e)
        {

            try
            {
                intMRRID = int.Parse(txtMrrNo.Text);
                dt = new DataTable();
                dt = obj.CorrectionMrr(4, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["msg"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                ShowInfo();
            }
            catch { }

        }
        private void ShowInfo()
        {
            try
            {
                ClearControls();
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out intMRRID, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "this.form.reset();", true);
                    return;
                }
                dt = new DataTable();
                dt = obj.CorrectionMrr(2, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    txtMrrDate.Text = dt.Rows[0]["dteTransactionDate"].ToString();
                    txtVoucherNo.Text = dt.Rows[0]["strVoucherCode"].ToString();
                    txtPo.Text = dt.Rows[0]["intPOID"].ToString();
                    txtWhName.Text = dt.Rows[0]["strWareHoseName"].ToString();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
                    return;
                }
                dt = new DataTable();
                dt = obj.CorrectionMrr(3, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    txtStatus.Text = dt.Rows[0]["strStatus"].ToString();
                }
                dt = new DataTable();
                dt = obj.CorrectionMrr(6, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
                }
                else
                {
                    txtSupplierName.Text = "";
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        private void LoadItemInfo()
        {
            try
            {
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out intMRRID, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                dt = new DataTable();
                dt = obj.CorrectionMrr(7, intMRRID);
                if (dt.Rows.Count>0)
                {
                    dgvItem.DataSource = dt;
                    dgvItem.DataBind();
                    SetVisibility("itemPanel", true);
                }
                else
                {
                    SetVisibility("itemPanel", false);
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        public void ClearControls()
        {
            //txtWhName.Text = string.Empty;
            //txtVoucherNo.Text = string.Empty;
            //txtSupplierName.Text = string.Empty;
            //txtStatus.Text = string.Empty;
            //txtPo.Text = string.Empty;
            //txtMrrDate.Text = string.Empty;

            List<Control> exceptControls = new List<Control>();
            exceptControls.Add(txtMrrNo);
            Common.Clear(UpdatePanel0.Controls, exceptControls);
        }
    }
}
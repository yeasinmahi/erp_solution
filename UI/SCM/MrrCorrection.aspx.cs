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
            if (hdnconfirm.Value == "1")
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
                            hdnconfirm.Value = "0";
                        }
                    }
                    catch { }
                }
            }
        }
        protected void btnFreeMRR_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
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
                        hdnconfirm.Value = "0";
                    }
                    ShowInfo();
                }
                catch { }
            }
        }
        protected void btnDeleteJV_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
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
                        hdnconfirm.Value = "0";
                    }
                    ShowInfo();
                }
                catch { }
            }
        }
        private void ShowInfo()
        {
            try
            {
                intMRRID = int.Parse(txtMrrNo.Text);
                dt = new DataTable();
                dt = obj.CorrectionMrr(2, intMRRID);
                if (dt.Rows.Count > 0)
                {
                    txtMrrDate.Text = dt.Rows[0]["dteTransactionDate"].ToString();
                    txtVoucherNo.Text = dt.Rows[0]["strVoucherCode"].ToString();
                    txtPo.Text = dt.Rows[0]["intPOID"].ToString();
                    hdnMrrUnitID.Value = dt.Rows[0]["intUnitID"].ToString();
                    txtWhName.Text = dt.Rows[0]["strWareHoseName"].ToString();
                    hdnWHID.Value = dt.Rows[0]["intWHID"].ToString();
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
            catch { }
        }
        private void LoadItemInfo()
        {
            try
            {
                intMRRID = int.Parse(txtMrrNo.Text);
                dt = new DataTable();
                dt = obj.CorrectionMrr(7, intMRRID);
                dgvItem.DataSource = dt; dgvItem.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                //SetVisibility("itemPanel", true);
            }
            catch { }
        }
    }
}
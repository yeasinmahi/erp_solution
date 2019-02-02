using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class MrrCorrection : BasePage
    {
        private readonly MrrCorrectionBll _obj = new MrrCorrectionBll();
        private DataTable _dt;
        private int _intMrrid;

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

            if (txtStatus.Text == @"Voucher Complete")
            {
                Toaster("Voucher completed. MRR cannot be Deleted.", Common.TosterType.Warning);
            }
            else if (!string.IsNullOrWhiteSpace(txtVoucherNo.Text))
            {
                Toaster("Please Delete JV Voucher.", Common.TosterType.Warning);
            }
            else
            {
                try
                {
                    _intMrrid = int.Parse(txtMrrNo.Text);
                    
                    _dt = _obj.CorrectionMrr(1, _intMrrid,Enroll, out string message);
                    if (_dt.Rows.Count > 0)
                    {
                        Toaster(message, message.ToLower().Contains("success")? Common.TosterType.Success:Common.TosterType.Error);
                    }
                }
                catch(Exception ex) {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }

        }
        protected void btnFreeMRR_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _dt = _obj.CorrectionMrr(5, _intMrrid,Enroll, out  message);
                if (_dt.Rows.Count > 0)
                {
                    Toaster(message, message.ToLower().Contains("success") ? Common.TosterType.Success : Common.TosterType.Error);
                }
                ShowInfo();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }

        }
        protected void btnDeleteJV_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _dt = _obj.CorrectionMrr(4, _intMrrid,Enroll,out message);
                if (_dt.Rows.Count > 0)
                {
                    Toaster(message, message.ToLower().Contains("success") ? Common.TosterType.Success : Common.TosterType.Error);
                }
                ShowInfo();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }

        }
        private void ShowInfo()
        {
            try
            {
                ClearControls();
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "this.form.reset();", true);
                    return;
                }
                _dt = new DataTable();
                _dt = _obj.CorrectionMrr(2, _intMrrid,Enroll,out message);
                if (_dt.Rows.Count > 0)
                {
                    txtMrrDate.Text = _dt.Rows[0]["dteTransactionDate"].ToString();
                    txtVoucherNo.Text = _dt.Rows[0]["strVoucherCode"].ToString();
                    txtPo.Text = _dt.Rows[0]["intPOID"].ToString();
                    txtWhName.Text = _dt.Rows[0]["strWareHoseName"].ToString();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
                    return;
                }
                _dt = new DataTable();
                _dt = _obj.CorrectionMrr(3, _intMrrid,Enroll,out message);
                if (_dt.Rows.Count > 0)
                {
                    txtStatus.Text = _dt.Rows[0]["strStatus"].ToString();
                }
                _dt = new DataTable();
                _dt = _obj.CorrectionMrr(6, _intMrrid,Enroll,out message);
                txtSupplierName.Text = _dt.Rows.Count > 0 ? _dt.Rows[0]["strSupplierName"].ToString() : "";
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
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _dt = _obj.CorrectionMrr(7, _intMrrid,Enroll,out message);
                if (_dt.Rows.Count>0)
                {
                    dgvItem.DataSource = _dt;
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
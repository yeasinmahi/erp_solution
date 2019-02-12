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
            if (!CheckUnitPermission())
            {
                VisiblePanel();
                return;
            }
            if (txtStatus.Text.ToLower().Equals("complete"))
            {
                Toaster("Voucher completed. MRR cannot be Deleted.", Common.TosterType.Warning);
                VisiblePanel();
            }
            else if (!string.IsNullOrWhiteSpace(txtVoucherNo.Text))
            {
                Toaster("Please Delete JV Voucher.", Common.TosterType.Warning);
                VisiblePanel();
            }
            else
            {
                try
                {
                    _intMrrid = int.Parse(txtMrrNo.Text);
                    
                    _obj.CorrectionMrr(1, _intMrrid,Enroll, out string message);
                    if (message.ToLower().Contains("success"))
                    {
                        Toaster(message, Common.TosterType.Success);
                    }
                    else
                    {
                        Toaster(message, Common.TosterType.Error);
                        VisiblePanel();
                    }
                }
                catch(Exception ex) {
                    Toaster(ex.Message, Common.TosterType.Error);
                    VisiblePanel();
                }
            }

        }
        protected void btnFreeMRR_Click(object sender, EventArgs e)
        {
            if (!CheckUnitPermission())
            {
                VisiblePanel();
                return;
            }
            try
            {
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _obj.CorrectionMrr(5, _intMrrid,Enroll, out  message);
                if (message.ToLower().Contains("success"))
                {
                    Toaster(message, Common.TosterType.Success);
                    ShowInfo();
                    LoadItemInfo();
                }
                else
                {
                    Toaster(message, Common.TosterType.Error);
                    VisiblePanel();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
                VisiblePanel();
            }

        }
        protected void btnDeleteJV_Click(object sender, EventArgs e)
        {
            if (!CheckUnitPermission())
            {
                VisiblePanel();
                return;
            }
            try
            {
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtVoucherNo.Text))
                {
                    Toaster("No JV Found on this MRR",Common.TosterType.Warning);
                    VisiblePanel();
                    return;
                }
                _obj.CorrectionMrr(4, _intMrrid,Enroll,out message);
                if (message.ToLower().Contains("success"))
                {
                    Toaster(message, Common.TosterType.Success);
                    ShowInfo();
                    LoadItemInfo();
                }
                else
                {
                    Toaster(message, Common.TosterType.Error);
                    VisiblePanel();
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
                VisiblePanel();
            }

        }

        public void VisiblePanel()
        {
            SetVisibility("itemPanel", true);
            SetVisibility("controlPanel", true);
        }
        private void ShowInfo()
        {
            try
            {
                ClearControls();
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _dt = new DataTable();
                _dt = _obj.GetMrrInfo(_intMrrid);
                if (_dt.Rows.Count > 0)
                {
                    DateTime.TryParse(_dt.Rows[0]["dteTransactionDate"].ToString(), out DateTime mrrDate);
                    txtMrrDate.Text = mrrDate.ToShortDateString();
                    txtVoucherNo.Text = _dt.Rows[0]["strVoucherCode"].ToString();
                    txtPo.Text = _dt.Rows[0]["intPOID"].ToString();
                    txtWhName.Text = _dt.Rows[0]["strWareHoseName"].ToString();
                    txtSupplierName.Text = _dt.Rows[0]["strSupplierName"].ToString();
                    txtChanllanNo.Text = _dt.Rows[0]["strExtnlReff"].ToString();
                    txtStatus.Text = _dt.Rows[0]["status"].ToString();

                    string chanllanDateText = _dt.Rows[0]["dteChallanDate"].ToString();
                    if (!string.IsNullOrWhiteSpace(chanllanDateText))
                    {
                        DateTime.TryParse(chanllanDateText, out DateTime challanDate);
                        txtChallanDate.Text = challanDate.ToShortDateString();
                    }
                    SetVisibility("controlPanel",true);
                    
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
                    return;
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
                if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                _dt = _obj.GetMrrItemInfo(_intMrrid);
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

        public bool CheckUnitPermission()
        {
            if (!Validation.CheckTextBox(txtMrrNo, "MRR No ", out _intMrrid, out string message))
            {
                Toaster(message, Common.TosterType.Warning);
                return false;
            }
            _dt =_obj.CorrectionMrr(8, _intMrrid, Enroll, out message);
            if (_dt.Rows.Count > 0)
            {
                _dt = _obj.CorrectionMrr(9, _intMrrid, Enroll, out message);
                if (_dt.Rows.Count > 0)
                {
                    bool.TryParse(_dt.Rows[0]["ysnPay"].ToString(), out bool isPermitted);
                    return isPermitted;
                }
                else
                {
                    Toaster("You have not permission to delete MRR.", Common.TosterType.Warning);
                    return false;
                }
            }
            else
            {
                Toaster("You have not unit permission of this MRR ", Common.TosterType.Warning);
                return false;
            }
            
        }
    }
}
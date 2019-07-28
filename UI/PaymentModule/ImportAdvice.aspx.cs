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

namespace UI.PaymentModule
{
    public partial class ImportAdvice : BasePage
    {
        private DataTable _dt;
        private ImportAdviceBll _bll = new ImportAdviceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime today = DateTime.Now;
                txtDate.Text = new DateTime(today.Year, today.Month, 1).ToString("yyyy/MM/dd");
                LoadUnit();
                LoadBank();
                LoadAdvice();
            }
        }

        public void LoadUnit()
        {
            _dt = _bll.GetUnit();
            ddlUnit.LoadWithSelect(_dt, "intUnitID", "strDescription");
        }
        public void LoadBank()
        {
            _dt = _bll.GetBank();
            ddlbank.LoadWithSelect(_dt, "intBankID", "strBankName");
        }
        public void LoadAdvice()
        {
            int unitId = ddlUnit.SelectedValue();
            int bankId = ddlbank.SelectedValue();
            string fromDate = txtDate.Text;
            string toDate = DateTime.Now.ToString("yyyy/MM/dd");
            _dt = _bll.GetAdvice(unitId, bankId, fromDate, toDate);
            ddlAdvice.LoadWithSelect(_dt, "strAdviceGroup", "strAdviceGroup");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            gridview.UnLoad();
            int unitId = ddlUnit.SelectedValue();
            int bankId = ddlbank.SelectedValue();

            _dt = _bll.GetBankInfoForImport(unitId, bankId);
            if (_dt.Rows.Count < 1)
            {
                Toaster("Bank account info for payment is not found.");
                return;
            }
            DateTime date = Convert.ToDateTime(txtDate.Text);
            string adviceGroupid = ddlAdvice.SelectedText();
            _dt = _bll.GetAdviceInformation(unitId, bankId, date, adviceGroupid);
            if (_dt.Rows.Count > 0)
            {
                gridview.Loads(_dt);
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString());
            }

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBank();
            LoadAdvice();
        }

        protected void ddlbank_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadAdvice();
        }

        protected void btnCreateVoucher_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count > 0)
            {
                string advice = ddlAdvice.SelectedText();
                string date = txtDate.Text;
                int unitId = ddlUnit.SelectedValue();
                int bankId = ddlbank.SelectedValue();
                if (advice != "DD/TT/PO")
                {
                    _dt = _bll.GetrateCount(date, date);
                    if (_dt.Rows.Count > 0)
                    {
                        int count = _dt.GetAutoId("intId");
                        if (count == 0)
                        {
                            Toaster("Actual Exchage Rate for all transaction is not set yet. Please set it and try again.");
                            return;
                        }
                    }
                    else
                    {
                        Toaster("Getting Rate Count Problem");
                    }
                }

                foreach (GridViewRow row in gridview.Rows)
                {
                    int reqId = int.Parse(((Label)row.FindControl("lblRequestId")).Text);
                    int payFor = int.Parse(((Label)row.FindControl("lblPayFor")).Text);
                    string voucher = ((Label)row.FindControl("lblVoucher")).Text;
                    if ((payFor == 4 || payFor == 6 || payFor == 6) && voucher == "")
                    {
                        _dt = _bll.CreateVoucherBenificiarry(reqId, payFor, Enroll);
                    }
                    else if ((payFor == 1 || payFor == 3 || payFor == 5 || payFor == 8 || payFor == 9 || payFor == 10 || payFor == 11) && voucher == "")
                    {
                        _dt = _bll.CreateVoucherRequsition(reqId, payFor, Enroll);
                    }
                    else if (!string.IsNullOrWhiteSpace(voucher))
                    {
                        //Toaster("Voucher already created.");
                        continue;
                    }
                    if (_dt.Rows.Count > 0)
                    {
                        string newVoucher = _dt.GetValue<string>("strVoucherNo");
                        if (!string.IsNullOrWhiteSpace(newVoucher))
                        {
                            _dt = _bll.UpdateVoucher(newVoucher, reqId);
                            if (_dt.Rows.Count == 0)
                            {
                                Toaster("Update Voucher Failed");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Toaster("Can not craete Voucher");
                        return;
                    }

                }
                Toaster("Successfully Voucher Created",Common.TosterType.Success);
                LoadGrid();

            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString());
            }
        }
    }
}
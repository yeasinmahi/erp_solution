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

                string mesage = string.Empty;
                Status status = Status.NoDataFound;
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
                        status = Status.AlreadyCreate;
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
                                status = Status.UpdateFailed;
                            }
                            status = Status.Success;
                        }
                    }
                    else
                    {
                        status = Status.CanNotCreate;
                    }

                }
                switch (status)
                {
                    case Status.Success:
                        Toaster("Successfully Voucher Created", Common.TosterType.Success);
                        LoadGrid();
                        break;
                    case Status.AlreadyCreate:
                        Toaster("Voucher Already Created");
                        break;
                    case Status.NoDataFound:
                        Toaster("Voucher Data Not Found", Common.TosterType.Error);
                        break;
                    case Status.CanNotCreate:
                        Toaster("Voucher Can Not Create", Common.TosterType.Error);
                        break;
                    case Status.UpdateFailed:
                        Toaster("Voucher Create Failed",Common.TosterType.Error);
                        break;
                    default:
                        Toaster("Unknown Error", Common.TosterType.Error);
                        break;

                }
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString());
            }
            
        }
        enum Status
        {
            NoDataFound,
            Success,
            AlreadyCreate,
            CanNotCreate,
            UpdateFailed
        }
    }
}
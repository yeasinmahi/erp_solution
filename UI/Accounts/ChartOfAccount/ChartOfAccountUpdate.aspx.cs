using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using BLL.Accounts.ChartOfAccount;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.Accounts.ChartOfAccount
{
    public partial class ChartOfAccountUpdate : BasePage
    {
        private readonly Payment_All_Voucher_BLL _objVoucher = new Payment_All_Voucher_BLL();
        private readonly Billing_BLL _objBillReg = new Billing_BLL();
        private DataTable _dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    dgvItemList.UnLoad();

                    LoadUnit();
                    LoadGrid();
                    LoadLedgerGrid();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        public void LoadUnit()
        {
            _dt = _objBillReg.GetUnitListByUserID(Enroll);
            ddlUnit.LoadWithSelect(_dt, "intUnitID", "strUnit");
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                _dt = _objVoucher.GetChartOfAccount(ddlUnit.SelectedValue());
                dgvItemList.Loads(_dt);
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        #region Web Method
        [WebMethod]
        [ScriptMethod]
        public static string[] GetLedgerName(string prefixText)
        {
            return ChartOfAccStaticDataProvider.GetLedgerName(prefixText).ToArray();
        }

        #endregion Web Method

        protected void ddlUnit_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LoadGrid();
        }

        //protected void dgvItemList_DataBound(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gvRow in dgvItemList.Rows)
        //    {
        //        DropDownList ddlAccountName = gvRow.FindControl("ddlAccountName") as DropDownList;
        //        HiddenField hdnCOAID = gvRow.FindControl("hdnCOAID") as HiddenField;

        //        if (ddlAccountName != null && hdnCOAID != null)
        //        {
        //            ddlAccountName.SelectedValue = hdnCOAID.Value;
        //        }
        //    }
        //}


        //protected void btnUpdateBridge_Click(object sender, EventArgs e)
        //{
        //    if (dgvItemList.Rows.Count > 0)
        //    {
        //        for (int index = 0; index < dgvItemList.Rows.Count; index++)
        //        {
        //            if (((CheckBox)dgvItemList.Rows[index].FindControl("chkRow")).Checked)
        //            {
        //                itemid = ((Label)dgvItemList.Rows[index].FindControl("lblItemID")).Text;
        //                //coaid = ((DropDownList)dgvItemList.Rows[index].FindControl("ddlAccountName")).SelectedValue.ToString();

        //                string coa = ((TextBox)dgvItemList.Rows[index].FindControl("txtCOA")).Text;
        //                _arrayKey = coa.Split(_delimiterChars);
        //                int coaid = int.Parse(_arrayKey[3]);

        //                if (coaid > 0)
        //                {
        //                    //CreateVoucherXml(itemid, coaid.ToString());
        //                }
        //            }
        //        }
        //    }

        //    if (dgvItemList.Rows.Count > 0)
        //    {

        //    }

        //    string message = _objVoucher.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, Enroll, intCOAID);
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

        //}

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            List<object> objects = new List<object>();
            foreach (GridViewRow row in dgvItemList.Rows)
            {
                string subLedger = ((TextBox)row.FindControl("txtSubLedger")).Text;
                string accountId = ((Label)row.FindControl("lblAccountId")).Text;
                if (string.IsNullOrWhiteSpace(subLedger))
                {
                    continue;
                }
                string[] array = subLedger.Split(Variables.GetInstance().DelimiterChars);
                string globalCoaId = array[1];
                dynamic obj = new
                {
                    globalCoaId,
                    accountId
                };
                objects.Add(obj);
            }
            if (objects.Count > 0)
            {
                string xml = XmlParser.GetXml("COA", "Item", objects, out _);
                string message = _objVoucher.UpdateChartOfAccount(xml, Enroll);
                if (message.ToLower().Contains("success"))
                {
                    Toaster(message, Common.TosterType.Success);
                    LoadGrid();
                }
                else
                {
                    Toaster(message, Common.TosterType.Error);
                }
            }
            else
            {
                Toaster("You have to input at least 1 sub-leager name value properly ", Common.TosterType.Warning);
            }

        }

        protected void btnView_OnClick(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            hdnGridRowIndex.Value = rowIndex.ToString();
            SetVisibilityModal(true);
        }

        public void LoadLedgerGrid()
        {
            DataTable dt = _objVoucher.GetLedgerInfo();
            gridViewLedger.Loads(dt);
        }

        protected void gridViewLedger_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSelect_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
            string globalCoaId = ((Label)row.FindControl("lblGlobalCoaId")).Text;
            if (!string.IsNullOrWhiteSpace(globalCoaId))
            {
                List<string> ledgers = ChartOfAccStaticDataProvider.GetLedgerName(globalCoaId);
                if (ledgers.Count > 0)
                {
                    string s = ledgers[0];

                    ((TextBox)dgvItemList.Rows[Convert.ToInt32(hdnGridRowIndex.Value)].FindControl("txtSubLedger"))
                        .Text = s;
                }

            }
            else
            {
                Toaster("Problem Occured While Getting Global COA Id.", Common.TosterType.Error);
            }
        }
    }
}
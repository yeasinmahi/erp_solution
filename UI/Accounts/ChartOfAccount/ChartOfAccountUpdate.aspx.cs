using System;
using System.Data;
using System.Web;
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
            ddlUnit.Loads(_dt, "intUnitID", "strUnit");
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



        protected void dgvItemList_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvItemList.Rows)
            {
                DropDownList ddlAccountName = gvRow.FindControl("ddlAccountName") as DropDownList;
                HiddenField hdnCOAID = gvRow.FindControl("hdnCOAID") as HiddenField;

                if (ddlAccountName != null && hdnCOAID != null)
                {
                    ddlAccountName.SelectedValue = hdnCOAID.Value;
                }
            }
        }


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

    }
}
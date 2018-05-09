using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;


namespace UI.PaymentModule
{
    public partial class SupplierCOA : BasePage
    {
        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL(); Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        int intPart, intSupplierID, intUnitID, intUser, intCOAID;
        string strSupplier;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();

                if (!IsPostBack)
                {                    
                    dt = new DataTable();
                    dt = objBillReg.GetUnitListByUserID(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }
                }
            }
            catch { }
        }       

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = new DataTable();
                dt = objVoucher.GetSupplierListForAddToChartOfAcount(intUnitID);
                dgvSupplierList.DataSource = dt;
                dgvSupplierList.DataBind();
            }
            catch { }
        }
        protected void dgvSupplierList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvSupplierList.Rows[rowIndex];

            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            intSupplierID = int.Parse((row.FindControl("lblSupplierID") as Label).Text);

            if (hdnconfirm.Value == "1")
            {
                if (e.CommandName == "Update")
                {
                    intPart = 1;
                    strSupplier = (row.FindControl("lblSupplierName") as Label).Text;
                    intCOAID = 0;

                    string message = objVoucher.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, int.Parse(hdnEnroll.Value), intCOAID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                else if (e.CommandName == "Add")
                {
                    intPart = 2;
                    intCOAID = int.Parse((row.FindControl("ddlAccountName") as DropDownList).SelectedValue);

                    string message = objVoucher.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, int.Parse(hdnEnroll.Value), intCOAID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                LoadGrid();
            }
        }
        protected void dgvSupplierList_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvSupplierList.Rows)
            {
                DropDownList ddlAccountName = gvRow.FindControl("ddlAccountName") as DropDownList;
                HiddenField hdnCOAID = gvRow.FindControl("hdnCOAID") as HiddenField;

                if (ddlAccountName != null && hdnCOAID != null)
                {
                    ddlAccountName.SelectedValue = hdnCOAID.Value;
                }
            }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSupplierList.DataSource = "";
            dgvSupplierList.DataBind();
        }



















    }
}
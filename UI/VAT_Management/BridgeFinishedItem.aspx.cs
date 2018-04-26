using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using UI.ClassFiles;
using SAD_BLL.Vat;

namespace UI.VAT_Management
{
    public partial class BridgeFinishedItem : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intFGID, intVatItemID, intPart;
        string xml;

        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();
                    
                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();

                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    dt = new DataTable();
                    dt = objvat.GetVATItemList(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value));
                    ddlVATProduct.DataTextField = "strVatProductName";
                    ddlVATProduct.DataValueField = "intID";
                    ddlVATProduct.DataSource = dt;
                    ddlVATProduct.DataBind();

                    if(hdnUnit.Value == "3")
                    {
                        dt = new DataTable();
                        dt = objvat.GetFGItemListForATMLALL();
                    }
                    else
                    {
                        dt = new DataTable();
                        dt = objvat.GetFGItemList(int.Parse(hdnUnit.Value));
                    }
                    ddlFGItem.DataTextField = "strProductName";
                    ddlFGItem.DataValueField = "intID";
                    ddlFGItem.DataSource = dt;
                    ddlFGItem.DataBind();
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
            try
            {
                dt = new DataTable();
                dt = objvat.GetVATItemList(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value));
                ddlVATProduct.DataTextField = "strVatProductName";
                ddlVATProduct.DataValueField = "intID";
                ddlVATProduct.DataSource = dt;
                ddlVATProduct.DataBind();
            }
            catch { }
        }

        protected void btnUpdateBridge_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 1;
                    intFGID = int.Parse(ddlFGItem.SelectedValue.ToString());
                    intVatItemID = int.Parse(ddlVATProduct.SelectedValue.ToString());
                    xml = "";

                    string message = objvat.InsertVATItemAndMaterialBridge(intPart, intFGID, intVatItemID, int.Parse(hdnVatAccID.Value), int.Parse(hdnEnroll.Value), xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
            }
            catch { }
        }














    }
}
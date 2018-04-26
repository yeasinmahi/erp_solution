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
using System.IO;
using System.Xml;

namespace UI.VAT_Management
{
    public partial class ProductionEntry : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intVatItemID, intBandrollCount = 0, intMushakID, intType, intBandroll;
        decimal numQty, numBRWastage, numBandWastageLimit, numUsePerUnit;
        DateTime dteDate;
        string strMessage;

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

                    lblBandroll.Enabled = false;
                    ddlBandroll.Enabled = false;
                    lblWastage.Enabled = false;
                    txtWastage.Enabled = false;

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();
                    
                    hdnysnFactory.Value = "0";
                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }
                    if (hdnysnFactory.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not permited.');", true);
                        return;
                    }

                    dt = new DataTable();
                    dt = objvat.GetVATItemForProductionEntry(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value));
                    ddlVATProduct.DataTextField = "strVatProductName";
                    ddlVATProduct.DataValueField = "intID";
                    ddlVATProduct.DataSource = dt;
                    ddlVATProduct.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetTypeForProductionEntry();
                    ddlMIssueBy.DataTextField = "strName";
                    ddlMIssueBy.DataValueField = "intMusokTypeID";
                    ddlMIssueBy.DataSource = dt;
                    ddlMIssueBy.DataBind();                    
                }
            }
            catch { }
           
        }

        protected void btnSaveProduction_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intVatItemID = int.Parse(ddlVATProduct.SelectedValue.ToString());
                    numQty = decimal.Parse(txtQuantity.Text);
                    if (numQty == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid or zero quantity selected.');", true);
                        return;
                    }

                    dteDate = DateTime.Parse(txtDate.Text) + TimeSpan.Parse(tpkProductionTime.Hour.ToString() + ":" + tpkProductionTime.Minute.ToString() + ":" + tpkProductionTime.Second.ToString());
                    intType = int.Parse(ddlMIssueBy.SelectedValue.ToString());
                    try { intBandroll = int.Parse(ddlBandroll.SelectedValue.ToString()); }
                    catch { intBandroll = 0; }
                    try { numBRWastage = decimal.Parse(txtWastage.Text); }
                    catch { numBRWastage = 0; }
                    strMessage = "";

                    dt = new DataTable();
                    dt = objvat.GetBandrollCountCheck(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), intVatItemID);
                    if (dt.Rows.Count > 0)
                    {
                        intBandrollCount = int.Parse(dt.Rows[0]["intBandrollCount"].ToString());
                        numUsePerUnit = decimal.Parse(dt.Rows[0]["numUsePerUnitQty"].ToString());
                    }

                    intMushakID = int.Parse(ddlMIssueBy.SelectedValue.ToString());
                    if (intBandrollCount == 0 && intMushakID != 4)
                    {
                        try { numBRWastage = decimal.Parse(txtWastage.Text); }
                        catch { numBRWastage = 0; }
                        decimal dec = Decimal.Parse("0.01");
                        numBandWastageLimit = (numQty * (numUsePerUnit * dec));

                        if (int.Parse(hdnVatAccID.Value) != 2 && numBRWastage >= numBandWastageLimit)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Maximum Limit of Bandroll Wastage for Production of " + numQty + " unit is: Below " + numBandWastageLimit + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        intBandroll = 0;
                        numBRWastage = 0;
                    }

                    string message = objvat.InsertProductionEntry(intVatItemID, numQty, dteDate, int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), int.Parse(hdnEnroll.Value), intType, strMessage, intBandroll, numBRWastage);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtDate.Text = "";
                    txtQuantity.Text = "";
                    txtWastage.Text = "";
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();            
        }

        protected void ddlMIssueBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblBandroll.Enabled = false;
                ddlBandroll.Enabled = false;
                lblWastage.Enabled = false;
                txtWastage.Enabled = false;

                intMushakID = int.Parse(ddlMIssueBy.SelectedValue.ToString());
                intVatItemID = int.Parse(ddlVATProduct.SelectedValue.ToString());
                dt = new DataTable();
                dt = objvat.GetBandrollCountCheck(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), intVatItemID);
                if (dt.Rows.Count > 0)
                {
                    intBandrollCount = int.Parse(dt.Rows[0]["intBandrollCount"].ToString());
                }

                if (intBandrollCount > 0 && intMushakID != 4)
                {
                    lblBandroll.Enabled = true;
                    ddlBandroll.Enabled = true;
                    lblWastage.Enabled = true;
                    txtWastage.Enabled = true;
                    txtWastage.Text = "";

                    intVatItemID = int.Parse(ddlVATProduct.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = objvat.GetBrandRollList(intVatItemID);
                    ddlBandroll.DataTextField = "strBandrollName";
                    ddlBandroll.DataValueField = "intBandrollID";
                    ddlBandroll.DataSource = dt;
                    ddlBandroll.DataBind();
                }
            }
            catch { }
        }






















    }
}
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
    public partial class OtherAdjustments : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL(); DataTable dt;

        DateTime dteDate; string strRemark, strType;
        int intUnitID, intUserID, intVATAccountID, intTransactionTypeID, intType;
        decimal monSD, monVAT, monSurCharge, monAmount;
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
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }

        protected void btnSaveAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    strRemark = txtRemarks.Text;
                    try { intType = int.Parse(ddlType.SelectedValue.ToString()); }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select an adjustment type.');", true);
                        return;
                    }

                    strType = ddlCate.SelectedItem.ToString();
                    if (strType == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a Category.');", true);
                        return;
                    }

                    try { monAmount = decimal.Parse(txtAmount.Text); }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please give an amount.');", true);
                        return;
                    }
                    if (monAmount == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please give an amount.');", true);
                        return;
                    }
                    if (intType == 1)
                    {
                        monAmount = monAmount * -1;
                    }

                    try { dteDate = DateTime.Parse(txtDate.Text); }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please give a valid date.');", true);
                        return;
                    }

                    if (strType == "SD") { monSD = monAmount; monVAT = 0; monSurCharge = 0; }
                    else if (strType == "VAT") { monSD = 0; monVAT = monAmount; monSurCharge = 0; }
                    else if (strType == "Surcharge") { monSD = 0; monVAT = 0; monSurCharge = monAmount; }

                    if (intType == 1 || intType == 2) { intTransactionTypeID = 12; }
                    else if (intType == 3) { }
                }

                string message = objvat.InsertOtherAdjustment(dteDate, strRemark, intUnitID, intUserID, monSD, monVAT, monSurCharge, intVATAccountID, intTransactionTypeID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                txtAmount.Text = "";
                txtRemarks.Text = "";
                txtDate.Text = "";
            }
            catch { }
        }























    }
}
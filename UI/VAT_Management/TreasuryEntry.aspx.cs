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
    public partial class TreasuryEntry : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intDepositType;
        DateTime dteTrChallan, dteInstrument, dteTransactionDate;
        decimal monAmount;
        string strTrChallanNo, strInstrumentNo;
        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();

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

                    if(hdnysnFactory.Value == "0")
                    {
                        return;
                    }

                    dt = new DataTable();
                    dt = objvat.GetTreasuryDepositType();
                    ddlDepositFor.DataTextField = "strTreasuryDepositDescription";
                    ddlDepositFor.DataValueField = "intTreasuryDepositID";
                    ddlDepositFor.DataSource = dt;
                    ddlDepositFor.DataBind();
                }
            }
            catch { }
        }
        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }
        protected void btnSaveTreasury_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    try { intDepositType = int.Parse(ddlDepositFor.SelectedValue.ToString());}
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Treasury code selected.');", true);
                        return;
                    }

                    if(intDepositType == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Treasury code selected.');", true);
                        return;
                    }

                    try { monAmount = decimal.Parse(txtAmount.Text); }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Amount cannot be zero.');", true);
                        return;
                    }
                    if(monAmount == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Amount cannot be zero.');", true);
                        return;
                    }
                    if(txtChallanNo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Challan cannot be blank.');", true);
                        return;
                    }
                    if(txtInstrumentNo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Instrument No cannot be blank.');", true);
                        return;
                    }
                    strTrChallanNo = txtChallanNo.Text;
                    strInstrumentNo = txtInstrumentNo.Text;

                    try
                    {
                        dteTrChallan = DateTime.Parse(txtChallanDate.Text);
                        dteInstrument = DateTime.Parse(txtInstrumentDate.Text);
                        dteTransactionDate = DateTime.Parse(txtDepositDate.Text);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please give a valid.');", true);
                        return;
                    }

                    string message = objvat.InsertTreasuryDeposit(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), intDepositType, monAmount, int.Parse(hdnEnroll.Value), strTrChallanNo, dteTrChallan, strInstrumentNo, dteInstrument, dteTransactionDate);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                    txtAmount.Text = "";
                    txtChallanDate.Text = "";
                    txtChallanNo.Text = "";
                    txtDepositDate.Text = "";
                    txtInstrumentDate.Text = "";
                    txtInstrumentNo.Text = "";
                }
            }
            catch { }
        }































    }
}
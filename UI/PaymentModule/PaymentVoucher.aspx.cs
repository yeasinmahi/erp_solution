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
    public partial class PaymentVoucher : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        int intDept, intType;
        string unitid, billid, entrycode, party, bank, bankacc, instrument, billtypeid;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                
                if (!IsPostBack)
                {
                    #region ===== Permission Check ===========================================================
                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetCheckUserRoleForVoucher(hdnEmail.Value);
                        if (dt.Rows.Count > 0)
                        {
                            if (int.Parse(dt.Rows[0]["intCount"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                                return;
                            }
                        }
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }

                    hdnysnPay.Value = "0";
                    hdnysnDutyVoucher.Value = "0";
                    dt = new DataTable();
                    dt = objBillReg.GetUserInfoForPaymentModule(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ysnPay"].ToString()) == true)
                        {
                            hdnysnPay.Value = "1";                            
                        }
                        if (bool.Parse(dt.Rows[0]["ysnDutyVoucher"].ToString()) == true)
                        {
                            hdnysnDutyVoucher.Value = "1";
                        }                        
                    }
                    if(hdnysnPay.Value == "1")
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetPayTypeForPay1();
                        ddlType.DataTextField = "strPayType";
                        ddlType.DataValueField = "intPayType";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();
                    }
                    else if (hdnysnDutyVoucher.Value == "1")
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetPayTypeDutyVoucher1();
                        ddlType.DataTextField = "strPayType";
                        ddlType.DataValueField = "intPayType";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();
                    }

                    #endregion ====================================================================================
                    
                    dt = new DataTable();
                    dt = objBillReg.GetUnitListByUserID(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }
                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetBankInfoByUnitID(int.Parse(ddlUnit.SelectedValue.ToString()));
                        ddlBank.DataTextField = "strBankName";
                        ddlBank.DataValueField = "intBankID";
                        ddlBank.DataSource = dt;
                        ddlBank.DataBind();
                    }
                    catch { }

                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetAccountByBankID(int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlBank.SelectedValue.ToString()));
                        ddlACNumber.DataTextField = "strBankAccount";
                        ddlACNumber.DataValueField = "intAccountID";
                        ddlACNumber.DataSource = dt;
                        ddlACNumber.DataBind();
                    }
                    catch { }
                }
            }
            catch { }
        }

        protected void dgvReportForPaymentV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvReportForPaymentV.Rows[rowIndex];
            
            if (e.CommandName == "PV")
            {
                unitid = ddlUnit.SelectedValue.ToString();
                billid = (row.FindControl("lblID") as Label).Text;
                entrycode = (row.FindControl("lblRegNo") as Label).Text;
                party = (row.FindControl("lblPartyName") as Label).Text;
                bank = ddlBank.SelectedValue.ToString();
                bankacc = ddlACNumber.SelectedValue.ToString();
                instrument = ddlInstrument.SelectedValue.ToString();
                billtypeid = ddlType.SelectedValue.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPrepareVoucher('" + unitid + "','" + billid + "','" + entrycode + "','" + party + "','" + bank + "','" + bankacc + "','" + instrument + "', '" + billtypeid + "');", true);
            }
            else if (e.CommandName == "SD")
            {
                //int.Parse((row.FindControl("lblID") as Label).Text);
            }

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = objBillReg.GetBankInfoByUnitID(int.Parse(ddlUnit.SelectedValue.ToString()));
                ddlBank.DataTextField = "strBankName";
                ddlBank.DataValueField = "intBankID";
                ddlBank.DataSource = dt;
                ddlBank.DataBind();
            }
            catch { }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = objBillReg.GetAccountByBankID(int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlBank.SelectedValue.ToString()));
                ddlACNumber.DataTextField = "strBankAccount";
                ddlACNumber.DataValueField = "intAccountID";
                ddlACNumber.DataSource = dt;
                ddlACNumber.DataBind();
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
                intType = int.Parse(ddlType.SelectedValue.ToString());
                if (intType == 1) { intDept = 0; }
                else if (intType == 2) { intDept = 1; }
                else if (intType == 3) { intDept = 3; }
                else if (intType == 4) { intDept = 4; }
                

                if(hdnysnPay.Value == "1")
                {
                    intType = intType;
                }
                else if (hdnysnDutyVoucher.Value == "1" && intType == 2)
                {
                    intType = 4;
                }

                dt = new DataTable();
                dt = objBillReg.GetUnpaidBillList(int.Parse(ddlUnit.SelectedValue.ToString()), intDept);
                dgvReportForPaymentV.DataSource = dt;
                dgvReportForPaymentV.DataBind();
            }
            catch { }
        }
























    }
}
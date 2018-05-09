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
    public partial class ApproveSingle : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt;
        
        string strPOID, strRemarks; 
        int intUser, intBill, intLevel, intAction, intBillID;
        decimal monApproveAmount = 0, monBillAmount = 0, monPreAdv = 0, monNewAmount = 0;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnLevel.Value = "0";
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            dt = new DataTable();
            dt = objBillApp.GetUserInfoForAudit(int.Parse(hdnEnroll.Value));   
            if(bool.Parse(dt.Rows[0]["ysnAudit2"].ToString()) == true)
            {
                hdnLevel.Value = "2";
            }
            else if(bool.Parse(dt.Rows[0]["ysnAudit1"].ToString()) == true)
            {
                hdnLevel.Value = "1";
            }
           
            if (!IsPostBack)
            {
                if (hdnLevel.Value == "1")
                {
                    dt = objBillApp.GetApproveTypeL1();
                    ddlCurrentAction.DataTextField = "strApproveType";
                    ddlCurrentAction.DataValueField = "intID";
                    ddlCurrentAction.DataSource = dt;
                    ddlCurrentAction.DataBind();
                }
                else if(hdnLevel.Value == "2")
                {
                    dt = objBillApp.GetApproveTypeL2();
                    ddlCurrentAction.DataTextField = "strApproveType";
                    ddlCurrentAction.DataValueField = "intID";
                    ddlCurrentAction.DataSource = dt;
                    ddlCurrentAction.DataBind();
                }

                try
                {                    
                    lblParty.Text = Session["party"].ToString();
                    lblBillAmount.Text = Math.Round(decimal.Parse(Session["billamount"].ToString())).ToString();
                    monBillAmount = Math.Round(decimal.Parse(Session["billamount"].ToString()));
                    intBillID = int.Parse(Request.QueryString["Id"]);
                    hdnBillID.Value = intBillID.ToString();
                    Session["billid"] = intBillID.ToString();
                }
                catch
                {
                    intBillID = int.Parse(Session["billid"].ToString());
                    hdnBillID.Value = intBillID.ToString();
                }

                dt = new DataTable();
                dt = objBillApp.GetBillInfoForApprove(intBillID);
                if (dt.Rows.Count > 0)
                {
                    lblEntryCode.Text = dt.Rows[0]["strBillRegCode"].ToString();
                    lblNetPay.Text =  Math.Round(decimal.Parse(dt.Rows[0]["monNetPay"].ToString())).ToString();
                }

                dt = new DataTable();
                dt = objBillApp.GetAdvanceInfoForApprove(intBillID);
                if (dt.Rows.Count > 0)
                {
                    strPOID = dt.Rows[0]["strReffNo"].ToString();
                }
                dt = new DataTable();
                dt = objBillApp.GetAdvance(strPOID);
                if (dt.Rows.Count > 0)
                {
                    lblPreviousAdvance.Text = Math.Round(decimal.Parse(dt.Rows[0]["monAdvPaid"].ToString())).ToString();
                    monPreAdv = Math.Round(decimal.Parse(dt.Rows[0]["monAdvPaid"].ToString()));
                }

                dt = new DataTable();
                dt = objBillApp.GetPreviousAuditAction(intBillID);
                if (dt.Rows.Count > 0)
                {
                    dgvPreviousStatus.DataSource = dt;
                    dgvPreviousStatus.DataBind();
                }

                dt = new DataTable();
                dt = objBillApp.GetLevel1Amount(intBillID);
                if (dt.Rows.Count > 0)
                {
                    monApproveAmount = Math.Round(decimal.Parse(dt.Rows[0]["monApproveAmount"].ToString()));
                }
                
                if(hdnLevel.Value == "1")
                {
                    if(lblNetPay.Text == "0")
                    {
                        decimal Amount = (monBillAmount - monPreAdv);
                        txtAmount.Text = Amount.ToString();
                    }                   
                    else { txtAmount.Text = lblNetPay.Text;}
                }
                else if (hdnLevel.Value == "2")
                {
                    if(monApproveAmount == 0)
                    {
                        if (lblNetPay.Text == "0")
                        {
                            decimal Amount = (monBillAmount - monPreAdv);
                            txtAmount.Text = Amount.ToString();
                        }
                        else { txtAmount.Text = lblNetPay.Text; }
                    }
                    else
                    {
                        txtAmount.Text = monApproveAmount.ToString();
                    }
                }
                lblArrovedLevel.Text = monApproveAmount.ToString();                
            }                
        }

        protected void btnSaveAction_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intUser = int.Parse(hdnEnroll.Value);
                    intLevel = int.Parse(hdnLevel.Value);
                    intAction = int.Parse(ddlCurrentAction.SelectedValue.ToString());
                    strRemarks = txtRemarks.Text;
                    monNewAmount = decimal.Parse(txtAmount.Text);

                    dt = new DataTable();
                    dt = objBillApp.InsertSingleApproveAudit(intUser, int.Parse(hdnBillID.Value), intLevel, intAction, strRemarks, monNewAmount);
                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["strMessage"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }

                    dt = new DataTable();
                    dt = objBillApp.GetPreviousAuditAction(int.Parse(hdnBillID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        dgvPreviousStatus.DataSource = dt;
                        dgvPreviousStatus.DataBind();
                    }
                }
                catch { }
            }
        }























    }
}
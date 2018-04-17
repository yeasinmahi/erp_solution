using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using System.Data;
using UI.ClassFiles;

namespace UI.HR.Benifit
{
    public partial class PF_Recieve : BasePage
    {
        PF_Recieve_BLL objPfBankRecieveBll = new PF_Recieve_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnLoginUserId.Value = "1397";//Session[SessionParams.USER_ID.ToString()].ToString();//"1397";
                ddlUnit.DataBind();
                ddlAccountNo.DataBind();
                ddlVoucharNo.DataBind();
                dgvPF_BankRecieve.DataBind();
                ddlUnit_SelectedIndexChanged(sender, e);
                // btnRecieve.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnRecieve));
            }
        }
        protected void btnRecieve_Click(object sender, EventArgs e)
        {
            try
            {
                objPfBankRecieveBll = new PF_Recieve_BLL();
                string strInsertStatus = "";
                strInsertStatus = objPfBankRecieveBll.ReceiveUnitwiseSelectedProvidentFund(int.Parse(ddlUnit.SelectedValue), ddlVoucharNo.SelectedValue,
                                                      txtChequeNo.Text, decimal.Parse(txtAmount.Text),
                                                      int.Parse(ddlAccountNo.SelectedValue), txtParticulars.Text, int.Parse(hdnLoginUserId.Value));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strInsertStatus + "');", true);
                dgvPF_BankRecieve.DataBind();
                RefreshPage();

            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + exception.Message + "');", true);
            }
        }

        private void RefreshPage()
        {
            try
            {
                if (ddlUnit.Items.Count > 0) ddlUnit.SelectedIndex = 0;
                //if (ddlAccountNo.Items.Count > 0) ddlAccountNo.SelectedIndex = 0;
                ddlVoucharNo.DataBind();
                //dgvPF_BankRecieve.DataBind();
                txtAmount.Text = "";
                txtChequeNo.Text = "";
                txtParticulars.Text = "";
                //hdnBankRecieveID.Value = "";
            }
            catch
            {
            }
        }

        protected void dgvPF_BankRecieve_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / August-09-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    //  e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPF_BankRecieve, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAccountNo.DataBind();
                ddlVoucharNo.DataBind();
                ddlVoucharNo_SelectedIndexChanged(sender, e);
            }
            catch
            {
            }
        }
        protected void ddlVoucharNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PF_Transfer_BLL objPF_Transfer_BLL = new PF_Transfer_BLL();
                DataTable oDataTable = new DataTable();
                oDataTable = objPF_Transfer_BLL.GetTransferAmountByVoucharCode(ddlVoucharNo.SelectedValue);
                if (oDataTable.Rows.Count > 0)
                {
                    txtAmount.Text = Decimal.Parse(oDataTable.Rows[0]["totalTransferedAmount"].ToString()).ToString("#.##");
                }
                else
                {
                    txtAmount.Text = "";
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
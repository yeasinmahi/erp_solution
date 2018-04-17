using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;

namespace UI.HR.Benifit
{
    public partial class PF_Investment : Page
    {
        static double intTotalSelectedAmount = 0;
        static string strListOfMonthAndYear = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                hdnSoftwareLoginUserId.Value = "1397";//Session[SessionParams.USER_ID.ToString()].ToString();
                hdnIntPfUnitId.Value = "23";//Session[SessionParams.UNIT_ID.ToString()].ToString();
                txtEffectedDate.Text = DateTime.Now.ToShortDateString();
                dgvPF_Investment.DataBind();
                CheckBox1_CheckedChanged(sender, e);

                //btnInvest.Attributes.Add("OnClientClick", "ShowInvestmentDetailsArea();");
                lblTotalSelectedAmount.Text = "Total selected amount :" + intTotalSelectedAmount.ToString();
                lblTotalSelectedAmount.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dgvPF_Investment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / July-21-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPF_Investment, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }
        protected void btnInvest_Click(object sender, EventArgs e)
        {
            try
            {

                if (Decimal.Parse(txtInvestmentAmount.Text == "" ? "0" : txtInvestmentAmount.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Focus", "ShowInvestmentDetailsArea();",
                                                        true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript",
                                                        "alert('Sorry! 0 Capital can not be invest..');", true);
                    return;
                }
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "Focus", "ShowInvestmentDetailsArea();", true);
                txtInvestmentAmount.Text = intTotalSelectedAmount.ToString();
                txtEffectedDate.Text = DateTime.Now.ToShortDateString();
                PF_Investment_BLL objPFInvestment = new PF_Investment_BLL();

                string strInvestmentStatus = objPFInvestment.InvestUnitwisePF(int.Parse(hdnIntPfUnitId.Value),
                                                                              int.Parse(ddlPfInvestmentAccount.SelectedValue),
                                                                              int.Parse(ddlPfBankAccount.SelectedValue),
                                                                              Decimal.Parse(txtInvestmentAmount.Text),
                                                                              Decimal.Parse(txtDuration.Text),
                                                                              Decimal.Parse(txtInterestRate.Text),
                                                                              DateTime.Parse(txtEffectedDate.Text),
                                                                              int.Parse(ddlInvestmentType.SelectedValue),
                                                                              strListOfMonthAndYear,
                                                                              "#",
                                                                              int.Parse(hdnSoftwareLoginUserId.Value));

                dgvPF_Investment.DataBind(); //Refresh Data Grid
                lblTotalSelectedAmount.Text = "";
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "Focus", "HideInvestmentDetailsArea();", true);//Hide details area
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript",
                                                    "alert('" + strInvestmentStatus + "');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                intTotalSelectedAmount = 0;
                strListOfMonthAndYear = "";
                for (int index = 0; index < dgvPF_Investment.Rows.Count; index++)
                {
                    CheckBox objCheckBox = (CheckBox)dgvPF_Investment.Rows[index].Cells[1].FindControl("CheckBox1");
                    if (objCheckBox.Checked)
                    {
                        intTotalSelectedAmount += Double.Parse((dgvPF_Investment.Rows[index].Cells[2].Text == "" ? "0" : dgvPF_Investment.Rows[index].Cells[2].Text));

                        strListOfMonthAndYear = strListOfMonthAndYear.ToString() + (strListOfMonthAndYear != "" ? "#" : "");
                        strListOfMonthAndYear += ((HiddenField)dgvPF_Investment.Rows[index].Cells[3].FindControl("hdnMonthID")).Value + "-01-" + dgvPF_Investment.Rows[index].Cells[4].Text;
                    }
                }
                lblTotalSelectedAmount.Text = "Total selected amount :" + intTotalSelectedAmount.ToString();
                lblTotalSelectedAmount.ForeColor = System.Drawing.Color.Red;
                // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + intTotalSelectedAmount.ToString() + "'');", true);
                txtInvestmentAmount.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + ex.Message + "');", true);
            }

        }
        protected void btnInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPF_Investment.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Focus", "ShowInvestmentDetailsArea();", true);
                    txtInvestmentAmount.Text = intTotalSelectedAmount.ToString();

                    txtEffectedDate.Text = DateTime.Now.ToShortDateString();
                    txtInterestRate.Text = "";
                    txtDuration.Text = "";
                    ddlPfBankAccount.DataBind();
                    ddlPfInvestmentAccount.DataBind();
                    ddlInvestmentType.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript",
                                                            "alert('Sorry! there is no data..');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + ex.Message + "');", true);
            }
        }

    }
}
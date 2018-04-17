using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using UI.ClassFiles;

namespace UI.HR.Benifit
{
    public partial class PF_Transfer : BasePage
    {
        static double intTotalSelectedAmount = 0;
        static string strListOfMonthAndYear = "";
        static string strListOfMonthAndYearShouldBeUnchecked = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnSoftwareLoginUserId.Value = "1395";//Session[SessionParams.USER_ID.ToString()].ToString();
                lblTotalSelectedAmount.Text = "Total selected amount :" + intTotalSelectedAmount.ToString();
                lblTotalSelectedAmount.ForeColor = System.Drawing.Color.Red;
                dgvPfTransfer.DataBind();
                CheckBox1_CheckedChanged(sender, e);
            }
        }
        protected void dgvPfTransfer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / July-21-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPfTransfer, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to calculate total selected amount and seleced month&Year
            //Created    :   Md. Yeasir Arafat / August-13-2012
            //Modified   :   
            //Parameters :   


            try
            {
                intTotalSelectedAmount = 0;
                strListOfMonthAndYear = "";
                strListOfMonthAndYearShouldBeUnchecked = "";
                for (int index = 0; index < dgvPfTransfer.Rows.Count; index++)
                {
                    CheckBox objCheckBox = (CheckBox)dgvPfTransfer.Rows[index].Cells[1].FindControl("CheckBox1");
                    if (objCheckBox.Checked)
                    {
                        intTotalSelectedAmount += Double.Parse((dgvPfTransfer.Rows[index].Cells[4].Text == "" ? "0" : dgvPfTransfer.Rows[index].Cells[4].Text));

                        strListOfMonthAndYear = strListOfMonthAndYear + (strListOfMonthAndYear != "" ? "#" : "");
                        strListOfMonthAndYear += ((HiddenField)dgvPfTransfer.Rows[index].Cells[5].FindControl("hdnMonthID")).Value + "-01-" + dgvPfTransfer.Rows[index].Cells[6].Text;
                    }
                    else
                    {
                        strListOfMonthAndYearShouldBeUnchecked = strListOfMonthAndYearShouldBeUnchecked + (strListOfMonthAndYearShouldBeUnchecked != "" ? "#" : "");
                        strListOfMonthAndYearShouldBeUnchecked += ((HiddenField)dgvPfTransfer.Rows[index].Cells[5].FindControl("hdnMonthID")).Value + "-01-" + dgvPfTransfer.Rows[index].Cells[6].Text;
                    }
                }
                lblTotalSelectedAmount.Text = "Total selected amount :" + intTotalSelectedAmount.ToString();
                lblTotalSelectedAmount.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + ex.Message + "');", true);
            }

        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to transfer selected pf amount to accounts
            //Created    :   Md. Yeasir Arafat / August-13-2012
            //Modified   :   
            //Parameters :   passing parameter intUnitId,listOfSeleted Month year,seperator # 

            try
            {
                PF_Transfer_BLL objPFTransferBll = new PF_Transfer_BLL();
                int? intUnitId = 16;//int.Parse(Session[SessionParams.UNIT_ID].ToString());
                string strTransferStatus = objPFTransferBll.TransferUnitwiseSelectedProvidentFund(intUnitId, strListOfMonthAndYear, strListOfMonthAndYearShouldBeUnchecked, "#");
                dgvPfTransfer.DataBind();
                intTotalSelectedAmount = 0;
                lblTotalSelectedAmount.Text = "Total selected amount :" + intTotalSelectedAmount.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + strTransferStatus + "');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + exception.Message + "');", true);
            }
        }
    }
}
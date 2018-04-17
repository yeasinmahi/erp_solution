using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Closing;
using UI.ClassFiles;

namespace UI.HR.Closing
{
    public partial class HR_Closing : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ddlUnit.DataBind();
                dgvHRClosing.DataBind();
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to close erp period (like calculate prevelige leave,move last year leave application into tblLeaveHistory)
            //Created    :   Md. Yeasir Arafat / May-29-2012
            //Modified   :   
            //Parameters :   

            HR_BLL.Closing.HR_Closing objHR_Closing = new HR_BLL.Closing.HR_Closing();
            string strClosingStatus = objHR_Closing.ClosingPeriodByUnitID(int.Parse(((HiddenField)dgvHRClosing.SelectedRow.Cells[0].FindControl("hdnUnitID")).Value.ToString()), DateTime.Parse(dgvHRClosing.SelectedRow.Cells[0].Text), DateTime.Parse(dgvHRClosing.SelectedRow.Cells[1].Text));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + strClosingStatus + "');", true);
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to load hr starting date and ending date by unit id
            //Created    :   Md. Yeasir Arafat / May-29-2012
            //Modified   :   
            //Parameters : 

            dgvHRClosing.DataBind();
        }
        protected void dgvPayslip_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / May-29-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='default';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPayslip, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }
    }
}
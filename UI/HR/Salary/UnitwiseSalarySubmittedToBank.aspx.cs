using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GLOBAL_BLL;
using UI.ClassFiles;


namespace UI.HR.Salary
{
    public partial class UnitwiseSalarySubmittedToBank : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnLoginUserId.Value = Session[SessionParams.USER_ID].ToString();
            }
        }
        protected void dgvUnitwiseSalarySubmittedToBank_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / Mar-18-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='default';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvAttendanceUnProcesses, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }

        protected void btnSubmittedToBank_OnCommand(object sender, CommandEventArgs e)
        {
            //Summary    :   This Event will be fired when Submitted To Bank button click 
            //Created    :   Md. Yeasir Arafat / Mar-18-2012
            //Modified   :   
            //Parameters :

            if (e.CommandName.Equals("SubmittedToBank"))
            {
                //int value = Convert.ToInt32(e.CommandArgument);
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "Focus", "window.open('EmployeeIDCard.aspx?empID=" + value + "',null,'height=900, width=750,status= no, resizable= no, scrollbars=no, toolbar=no,location=no,menubar=no ');", true);
            }
        }

        public string GetStr(object intUnitID)
        {
            return "ShowSalaryAdviceToBank('" + intUnitID.ToString() + "')";
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;


namespace UI.HR.PaySlip
{
    public partial class PayslipGenerator : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtDate.Text = DateTime.Now.ToShortDateString();
            }
        }
        protected void btnPrintAll_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Call ALLPaySlipByUnitAndJobSation.aspx
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Focus", "window.open('ALLPaySlipByUnitAndJobSation.aspx?intEmployeeID=" + null + "&intUnitID=" + ddlUnit.SelectedValue.ToString() + "&intEmployeeJobStationId=" + ddljobstation.SelectedValue.ToString() + "&dtePayrollGenerationDate=" + txtDate.Text + "',null,'height=600, width=575,status= no, resizable= yes, scrollbars=yes, toolbar=no,location=no,menubar=no ');", true);
        }
        public string GetStr(object intEmployeeID, object intUnitID, object intEmployeeJobStationId, object dtePayrollGenerationDate)
        {
            //Summary    :   This function will use to Call java script GeneratePayslipByEmployeeID due to grid button click
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :

            return "GeneratePayslipByEmployeeID(" + intEmployeeID.ToString() + ",'" + intUnitID.ToString() + "','" + intEmployeeJobStationId.ToString() + "','" + dtePayrollGenerationDate + "')";
        }
        protected void dgvPayslip_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
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
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to load grid
            //Created    :   Md. Yeasir Arafat / Mar-20-2012
            //Modified   :   
            //Parameters :

            dgvPayslip.DataBind();
        }
    }
}
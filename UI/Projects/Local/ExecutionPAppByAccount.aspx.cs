using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL.Transport;
using Projects_BLL;

namespace UI.Projects.Local
{
    public partial class ExecutionPAppByAccount : BasePage
    {
        Project_Class rptproject = new Project_Class(); DataTable dt;

        string  xml, strLocation;
        int intPart, intUnitid, intDept;
        int intDeptid, intEventid, intTypeid, intLocationid, intBrandid, intActionBy;
        DateTime dtePlan, dtePlanF, dtePlanT;
        decimal numAdvAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            }
            else { if (hdnconfirm.Value == "3") { dgvExecutionP.Visible = true; }}
        }

        protected void btnShow_Click(object sender, EventArgs e) { LoadGrid(); }
        private void LoadGrid()
        {
            try
            {
                intPart = 2;
                intUnitid = int.Parse(ddlUnit.SelectedValue.ToString());
                intDept = int.Parse(ddlDept.SelectedValue.ToString());

                dt = new DataTable();
                dt = rptproject.GetReportForApprove(intPart, intUnitid, intDept);
                dgvExecutionP.DataSource = dt;
                dgvExecutionP.DataBind();
            }
            catch { }
        }
        private void GridviewBlank() { dgvExecutionP.DataSource = ""; dgvExecutionP.DataBind(); }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e) { GridviewBlank(); }
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e) { GridviewBlank(); }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            hdnProjectID.Value = senderdata;

            try
            {
                intPart = 4;
                intUnitid = int.Parse(senderdata.ToString());
                intDept = 0;

                dt = new DataTable();
                dt = rptproject.GetReportForApprove(intPart, intUnitid, intDept);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);
                    dgvExecutionEdit.DataSource = dt;
                    dgvExecutionEdit.DataBind();

                    dt = new DataTable();
                    dt = rptproject.GetAdvAmount(int.Parse(hdnProjectID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtAdvance.Text = dt.Rows[0]["numAppAdvAmount"].ToString();                                               
                    }
                    dgvExecutionP.Visible = false;
                }
            }
            catch { }
        }
        protected decimal totalamo = 0;
        protected void dgvExecutionEdit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamo += decimal.Parse(((Label)e.Row.Cells[1].FindControl("lblRAmount")).Text);
                }
            }
            catch { }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {                
                intPart = 4;
                intUnitid = int.Parse(hdnProjectID.Value);
                intDeptid = 1; // int.Parse(ddlCostCenter.SelectedValue.ToString());
                intEventid = 2; // int.Parse(ddlCOA.SelectedValue.ToString());
                intTypeid = 0; 
                intLocationid = 0;
                strLocation = "";
                intBrandid = 0;
                string dteDate = DateTime.Now.ToString("yyyy-MM-dd");
                dtePlan = DateTime.Parse(dteDate.ToString());
                intActionBy = int.Parse(hdnEnroll.Value);
                dtePlanF = DateTime.Parse(dteDate.ToString());
                dtePlanT = DateTime.Parse(dteDate.ToString());
                numAdvAmount = decimal.Parse(txtAdvance.Text);
                xml = "";
                
                string message = rptproject.InsertEntry(intPart, intUnitid, intDeptid, intEventid, intTypeid, intLocationid, strLocation, intBrandid, dtePlan, intActionBy, xml, dtePlanF, dtePlanT, numAdvAmount);
                LoadGrid();                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('" + 0 + "');", true);
            }
            dgvExecutionP.Visible = true;
        }
        














    }
}
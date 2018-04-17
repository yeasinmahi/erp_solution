using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;

namespace UI.Transport
{
    public partial class Utility_PaymentReport : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL(); Utility_BLL objut = new Utility_BLL();
        DataTable dt;

        int intWork; int intUnitID; DateTime dteFromDate; DateTime dteToDate; int intUtilityID;
        string strServiceName; int intReg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    dt = objut.GetServiceList();
                    ddlServiceList.DataTextField = "strServiceName";
                    //ddlServiceList.DataValueField = "intID";
                    ddlServiceList.DataSource = dt;
                    ddlServiceList.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                }
                catch
                { }
            }            
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                strServiceName = ddlServiceList.SelectedItem.ToString();
                if (rdoRenewal.Checked == true) { intReg = 1; } else { intReg = 0; }                 
                intUtilityID = 0;

                intWork = 4;
                dt = new DataTable();
                dt = objut.GetUtilityProfile(intWork, intUnitID, dteFromDate, dteToDate, intUtilityID, strServiceName, intReg);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch
            { }
        }

        protected decimal totalgovfee = 0;
        protected decimal totalincidentalcost = 0;
        protected decimal totalcost = 0;
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalgovfee += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblGovFee")).Text);
                    totalincidentalcost += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblIncidentalCost")).Text);
                    totalcost += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblTotalCost")).Text);
                }

            }
            catch { }
        }
        protected void btnDocVew_Click(object sender, EventArgs e)
        {            
            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocListView('" + senderdata + "');", true);
           
        }

        protected void rdoRenewal_CheckedChanged(object sender, EventArgs e) 
        {
            if (rdoRenewal.Checked == true) { rdoRegistration.Checked = false;} else { rdoRenewal.Checked = true; }            
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void rdoRegistration_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRegistration.Checked == true) { rdoRenewal.Checked = false; } else { rdoRegistration.Checked = true; }
            dgvReport.DataSource = "";
            dgvReport.DataBind();

        }

        protected void ddlServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }












    }
}
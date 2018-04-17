using Dairy_BLL;
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
namespace UI.Dairy
{
    public partial class Milk_MR_Report_Supplier_Wise : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID; DateTime dteFrom; DateTime dteTo; int intWork; int intSuppID; int intMRNo; int intPart;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetChillingCenterList(intUnitID);
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();
                }
                catch
                { }
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = obj.GetChillingCenterList(intUnitID);
                ddlChillingCenter.DataTextField = "strChillingCenterName";
                ddlChillingCenter.DataValueField = "intChillingCenterID";
                ddlChillingCenter.DataSource = dt;
                ddlChillingCenter.DataBind();

                lblUnitName.Visible = false;
                lblCCName.Visible = false;
                lblFromToDate.Visible = false;

            }
            catch { }

            dgvMRReport.DataSource = "";
            dgvMRReport.DataBind();
        }

        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMRReport.DataSource = "";
            dgvMRReport.DataBind();

            lblUnitName.Visible = false;
            lblCCName.Visible = false;
            lblFromToDate.Visible = false;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = ddlUnit.SelectedItem.ToString();
                lblCCName.Text = ddlChillingCenter.SelectedItem.ToString();
                lblFromToDate.Text = "As On " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                intWork = 4;
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

                dteFrom = DateTime.Parse(txtFromDate.Text);
                dteTo = DateTime.Parse(txtToDate.Text);

                intSuppID = 0;
                intMRNo = 0;
                intPart = 0;

                dt = new DataTable();
                dt = obj.GetMilkMRReport(intWork, dteFrom, dteTo, intCCID, intSuppID, intMRNo, intPart);
                dgvMRReport.DataSource = dt;
                dgvMRReport.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblCCName.Visible = true;
                    lblFromToDate.Visible = true;
                }
                else
                {
                    lblUnitName.Visible = false;
                    lblCCName.Visible = false;
                    lblFromToDate.Visible = false;
                }
            }
            catch { }
        }

        protected decimal tmrqty = 0;
        protected decimal tdeducqtyamo = 0;
        protected decimal tdecucfatamo = 0;
        protected decimal tmramo = 0;
        protected decimal tchalanqty = 0;
        protected decimal tchalanamo = 0;

        protected void dgvMRReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    tmrqty += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblMRQty")).Text);
                    tdeducqtyamo += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblDeductAmou")).Text);
                    tdecucfatamo += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblDeductFatPAmou")).Text);
                    tmramo += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblMRAmount")).Text);
                    tchalanqty += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblChallanQty")).Text);
                    tchalanamo += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblChallanAmount")).Text);
                }
            }
            catch { }
        }
















    }
}
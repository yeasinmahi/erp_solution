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
    public partial class Milk_Inventory : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID; DateTime dteFrom; DateTime dteTo;
        
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
                lblFromToDate.Text = "Inventory Report As On " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFromDate.Text);
                dteTo = DateTime.Parse(txtToDate.Text);

                dt = new DataTable();
                dt = obj.GetInventoryReport(intCCID, dteFrom, dteTo);
                dgvInventory.DataSource = dt;
                dgvInventory.DataBind();

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

        
        protected decimal trqty = 0;
        protected decimal trval = 0;       
        protected decimal tissqty = 0;
        protected decimal tissval = 0;
     
        protected void dgvInventory_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    trqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblRQty")).Text);
                    trval += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblRVal")).Text);
                    tissqty += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblIssQty")).Text);
                    tissval += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblIssVal")).Text);                                   
                }
            }
            catch { }
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

            dgvInventory.DataSource = "";
            dgvInventory.DataBind();
        }
        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvInventory.DataSource = "";
            dgvInventory.DataBind();

            lblUnitName.Visible = false;
            lblCCName.Visible = false;
            lblFromToDate.Visible = false;
        }

        






















    }
}
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
    public partial class Milk_Supplier_Profile : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID;

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
                lblFromToDate.Text = "SUPPLIER PROFILE";

                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
               
                dt = new DataTable();
                dt = obj.GetSupplierProfile(intCCID);
                dgvSupplierProfile.DataSource = dt;
                dgvSupplierProfile.DataBind();

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
            }
            catch { }

            lblUnitName.Visible = false;
            lblCCName.Visible = false;
            lblFromToDate.Visible = false;

            dgvSupplierProfile.DataSource = "";
            dgvSupplierProfile.DataBind();
        }

        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnitName.Visible = false;
            lblCCName.Visible = false;
            lblFromToDate.Visible = false;

            dgvSupplierProfile.DataSource = "";
            dgvSupplierProfile.DataBind();
        }












    }
}
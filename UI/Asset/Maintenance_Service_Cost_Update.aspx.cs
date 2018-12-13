using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class Maintenance_Service_Cost_Update : BasePage
    {
        AssetMaintenance objasset = new AssetMaintenance();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

                try
                {
                    dt = objasset.JobStation();
                    ddlJobStation.DataSource = dt;
                    ddlJobStation.DataTextField = "strJobStationName";
                    ddlJobStation.DataValueField = "intEmployeeJobStationId";
                    ddlJobStation.DataBind();
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dt = objasset.UnitName();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
            }
            catch { }
            int jobcard = Convert.ToInt32(txtJobCard.Text);
            dt = new DataTable();
            dt = objasset.GetServiceData(jobcard);
            if (dt.Rows.Count > 0)
            {
                gvServiceCostUpdate.DataSource = dt;
                gvServiceCostUpdate.DataBind();
            }
            else
            {
                gvServiceCostUpdate.DataSource = null;
                gvServiceCostUpdate.DataBind();
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);

        }
       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Button)sender).NamingContainer);
            int Index = gvr.RowIndex;
            GridViewRow row = gvServiceCostUpdate.Rows[Index];
            int intID = int.Parse((row.FindControl("lblID") as Label).Text);
            decimal amount = Convert.ToDecimal((row.FindControl("txtAmount") as TextBox).Text);
            string msg=  objasset.UpdateMoney(amount,intID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);

        }

        protected void btnUnitUpdate_Click(object sender, EventArgs e)
        {
            int unit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            int jobCard = Convert.ToInt32(txtJobCard.Text);
            objasset.UpdateFixedAssetRegisterUnit(unit, jobCard);
            string msg = objasset.UpdateAssetMaintenanceUnitByJobCard(unit, jobCard);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
        }
    }
}
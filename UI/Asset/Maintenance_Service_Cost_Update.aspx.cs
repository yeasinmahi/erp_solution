﻿using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class Maintenance_Service_Cost_Update : BasePage
    {
        AssetMaintenance objasset = new AssetMaintenance();
        DataTable dt = new DataTable();
        string[] arrayKey ;
        char[] deli = { '[', ']' };

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
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelJoB();", true);
            try
            {
                //dt = objasset.UnitName();
                //ddlUnit.DataSource = dt;
                //ddlUnit.DataTextField = "Name";
                //ddlUnit.DataValueField = "ID";
                //ddlUnit.DataBind();
            }
            catch { }
            bindGrid();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);

        }
        private void bindGrid()
        {
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
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelJoB();", true);
            GridViewRow gvr = (GridViewRow)(((Button)sender).NamingContainer);
            int Index = gvr.RowIndex;
            GridViewRow row = gvServiceCostUpdate.Rows[Index];
            int intID = int.Parse((row.FindControl("lblID") as Label).Text);
            decimal amount = Convert.ToDecimal((row.FindControl("txtAmount") as TextBox).Text);
            string msg=  objasset.UpdateMoney(amount,intID);
            bindGrid();           
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true); 

        }

        protected void btnUnitUpdate_Click(object sender, EventArgs e)
        {
            int jobStation = 0, unit= 0; string msg = "",AssetCode = "";
            //int unit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            
            string type = ddlType.SelectedItem.Text;
            arrayKey = txtJobSearch.Text.Split(deli);
            if (arrayKey.Length > 0)
            {
                unit = Convert.ToInt32(arrayKey[3]);
                jobStation = Convert.ToInt32(arrayKey[5]);
            }
            
            if (type == "Job")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelJoB();", true);
                int jobCard = Convert.ToInt32(txtJobCard.Text);
                //msg = objasset.UpdateAssetMaintenanceUnitByJobCard(unit, jobStation, jobCard);
            }
            else if(type =="Bill")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelAsset();", true);
                arrayKey = txtAssetSearch.Text.Split(deli);
                if (arrayKey.Length > 0)
                {
                    AssetCode = Convert.ToString(arrayKey[3].ToString());
                }
                //msg = objasset.UpdateFixedAssetRegisterUnit(unit, AssetCode);
            }
            
            
           
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchAssetVehicle(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 type = Int32.Parse(8.ToString());
            return objAutoSearch_BLL.GetAssetVehicle(type, prefixText);

        }

        
        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchJobStation(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetAllJobstationList(Active, prefixText);

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = ddlType.SelectedItem.Text;
            if (type == "Job")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelJoB();", true);

            }
            else if (type == "Bill")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanelAsset();", true);

            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

using System.Xml;
using System.IO;
using System.Drawing;

namespace UI.Asset
{
    public partial class Depreciation_UI : BasePage
    {
        AssetMaintenance objdep = new AssetMaintenance();
        DataTable dt = new DataTable();
        int intType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();

                dt = objdep.UnitName();
                ddlunit.DataSource = dt;
                ddlunit.DataTextField = "Name";
                ddlunit.DataValueField = "ID";
                ddlunit.DataBind();
                DateTime dtefrom = DateTime.Parse("1990-01-01".ToString());
                DateTime dteenddate = DateTime.Parse("1990-01-01".ToString());
            }
        }

        #region===============AutoSearch==============================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetTransaction(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetAssetItem(Active, prefixText);

        }

        #endregion===============Close================================
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            dgvGridView.DataSource = ""; dgvGridView.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string assetcode, xmlString;
                string strSearchKey = txtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                try { assetcode = searchKey[1]; } catch { assetcode = "0".ToString(); }
                xmlString = "<voucher><voucherentry AssetCOA=" + '"' + assetcode + '"' + "/></voucher>".ToString();
                if (int.Parse(ddltype.SelectedValue) == 1)
                {
                    dt = objdep.DepreciationView(6, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), 0, 0); 
                }
                else
                { 
                    dt = objdep.DepreciationView(6, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), int.Parse(ddlunit.SelectedValue), 0);
                    //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true); 
                }
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
            catch { }
          


        }

        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgvGridView.DataSource = ""; dgvGridView.DataBind();
            
        }

        protected void btnDepSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string assetcode, xmlString;
                string strSearchKey = txtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                try { assetcode = searchKey[1]; } catch { assetcode = "0".ToString(); }
                xmlString = "<voucher><voucherentry AssetCOA=" + '"' + assetcode + '"' + "/></voucher>".ToString();
                if (int.Parse(ddltype.SelectedValue) == 1)
                {
                    dt = objdep.DepreciationView(1, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), 0, 0);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                }
                else
                {

                    dt = objdep.DepreciationView(1, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), int.Parse(ddlunit.SelectedValue), 0);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                }
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();

            }
            catch { }
           
        }
    }
}
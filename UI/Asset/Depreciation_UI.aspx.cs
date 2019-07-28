using System;
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
using UI.ClassFiles;
using System.Xml;
using System.IO;
using System.Drawing;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class Depreciation_UI : BasePage
    {
        AssetMaintenance objdep = new AssetMaintenance();
        AssetParking_BLL parking = new AssetParking_BLL();
        DataTable dt = new DataTable();
        int intType;
        SeriLog log = new SeriLog();
        string location = "Asset", xmlString;
        string start = "starting Asset\\Depreciation_UI";
        string stop = "stopping Asset\\Depreciation_UI";
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = parking.CwipAssetView(19, "", "", "", "", 0, intenroll);//Unit by User
                ddlunit.DataSource = dt;
                ddlunit.DataTextField = "strName";
                ddlunit.DataValueField = "Id";
                ddlunit.DataBind();

                dt = objdep.AssetType();
                ddlCat.DataSource = dt;
                ddlCat.DataTextField = "strAssetTypeName";
                ddlCat.DataValueField = "intAssetTypeID";
                ddlCat.DataBind();

                ddlunit.Items.Insert(0, new ListItem("Select", "0"));
                try
                {
                    Session["unit"] = ddlunit.SelectedValue.ToString();
                }
                catch { }

                DateTime dtefrom = DateTime.Parse("1900-01-01".ToString());
                DateTime dteenddate = DateTime.Parse("1900-01-01".ToString());
            }
        }

        #region===============AutoSearch==============================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetTransaction(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.GetAssetItemByUnit(HttpContext.Current.Session["unit"].ToString(), prefixText);

        }

        #endregion===============Close================================
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            dgvGridView.DataSource = ""; dgvGridView.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\Depreciation_UI Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
               // string assetcode;
                string strSearchKey = txtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                arrayKey = txtAssetID.Text.Split(delimiterChars); 
                string assetid = "0";
                string assetName = "";
                string assetType = "";
                int assetAutoId = 0;

                try
                {
                    if (arrayKey.Length >5)
                    {
                        // assetName = arrayKey[0].ToString();
                        //  assetAutoId = int.Parse(arrayKey[3].ToString());
                        // assetType = arrayKey[5].ToString(); 

                        assetid = arrayKey[1];
                        xmlString = "<voucher><voucherentry AssetId=" + '"' + assetid + '"' + "/></voucher>".ToString();
                    }
                    else
                    {
                        xmlString = "<voucher><voucherentry AssetId=" + '"' + 0 + '"' + "/></voucher>".ToString();
                    }
                }
                catch { } 
              
                if (int.Parse(ddltype.SelectedValue) == 1)
                {
                    dt = objdep.DepreciationView(6, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), 0, int.Parse(ddlCat.SelectedValue.ToString())); 
                }
                else
                { 
                    dt = objdep.DepreciationView(6, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), int.Parse(ddlunit.SelectedValue), int.Parse(ddlCat.SelectedValue.ToString()));
                    //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true); 
                }

                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["unit"] = ddlunit.SelectedValue.ToString();
            }
            catch { }

            dgvGridView.DataSource = ""; dgvGridView.DataBind();
            
        }

        protected void btnDepSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\Depreciation_UI btnDepSubmit_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string assetcode, xmlString;
                string strSearchKey = txtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                arrayKey = txtAssetID.Text.Split(delimiterChars);

                string assetid = "0"; string assetName = ""; string assetType = ""; int assetAutoId = 0;
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetid = arrayKey[1].ToString(); assetAutoId = int.Parse(arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }
                 
                xmlString = "<voucher><voucherentry AssetCOA=" + '"' + assetid + '"' + "/></voucher>".ToString(); 
                if (int.Parse(ddltype.SelectedValue) == 1)
                {
                    dt = objdep.DepreciationView(1, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), 0, int.Parse(Session[SessionParams.USER_ID].ToString()));

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                }
                else
                {
                    //Multipole Asset Depreciation Charge
                    dt = objdep.DepreciationView(1, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), int.Parse(ddlunit.SelectedValue), int.Parse(Session[SessionParams.USER_ID].ToString()));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                }
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void txtdteTo_TextChanged(object sender, EventArgs e)
        {
            DateTime fromdate = DateTime.Parse(txtDteFrom.Text.ToString());
            DateTime todate = DateTime.Parse(txtdteTo.Text.ToString());
            if (fromdate > todate)
            {
                txtdteTo.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check To Date');", true);

            }

        }

        protected void btnImpairment_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\Depreciation_UI Impairment btnDepSubmit_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string   xmlString;
                string strSearchKey = txtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                arrayKey = txtAssetID.Text.Split(delimiterChars);

                string assetid = "0"; string assetName = ""; string assetType = ""; int assetAutoId = 0;
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetid = arrayKey[1].ToString(); assetAutoId = int.Parse(arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }

                xmlString = "<voucher><voucherentry AssetCOA=" + '"' + assetid + '"' + "/></voucher>".ToString();
                if (int.Parse(ddltype.SelectedValue) == 1)
                {
                    dt = objdep.DepreciationView(2, xmlString, DateTime.Parse(txtDteFrom.Text), DateTime.Parse(txtdteTo.Text), 0, 0);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                }
                
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
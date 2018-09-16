using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Xml;
using System.IO;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SCM
{
    public partial class FinishedGoodsBridge : BasePage
    {
        string xmlpath;
        DataTable dt = new DataTable();
        InventoryTransfer_BLL objinventoryTransfer = new InventoryTransfer_BLL();

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\FinishedGoodsBridge";
        string stop = "stopping SCM\\FinishedGoodsBridge";
        string perform = "Performance on SCM\\FinishedGoodsBridge Show";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {                
                pnlUpperControl.DataBind();
                DefaultPageLoad();
                Panel1.Visible = false;
            }
        }
        private void DefaultPageLoad()
        {
            var fd = log.GetFlogDetail(start, location, "DefaultPageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try {
                dt = objinventoryTransfer.GetWearHouse();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strWareHoseName";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefauldtPageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int unitid = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                dt = objinventoryTransfer.GetFGList(unitid);
                ddlFG.DataSource = dt;
                ddlFG.DataTextField = "strProduct";
                ddlFG.DataValueField = "intID";
                ddlFG.DataBind();

                dt = objinventoryTransfer.GetSadUOMList(unitid);
                ddlSadUOM.DataSource = dt;
                ddlSadUOM.DataTextField = "strUOM";
                ddlSadUOM.DataValueField = "intID";
                ddlSadUOM.DataBind();

                dt = objinventoryTransfer.GetSadUOMList(unitid);
                ddlInvUOM.DataSource = dt;
                ddlInvUOM.DataTextField = "strUOM";
                ddlInvUOM.DataValueField = "intID";
                ddlInvUOM.DataBind();

                if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
                {
                    txtCount.Text = 1.ToString();
                }
                else
                {
                    txtCount.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "ddlUnit_SelectedIndexChanged", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
           

        }

        protected void btnAddFg_Click(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            string strName= ddlFG.SelectedItem.Text;
            string strDescription = "";
            string strPartNo = "";
            string strBrand="";
            int intClusterID = 2;
            int intComGroupID = 37;
            int intCategoryID = 45;
            DateTime dteLastActionTime = DateTime.Parse(DateTime.Now.ToString());
            string strUoM = ddlInvUOM.SelectedItem.Text;
            int intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intUnit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            int SADItemID = Convert.ToInt32(ddlFG.SelectedItem.Value);
            int numConversion = Convert.ToInt32(txtCount.Text);
            int intSadStandardUOM = Convert.ToInt32(ddlSadUOM.SelectedItem.Value);
            int intInvUoM = Convert.ToInt32(ddlInvUOM.SelectedItem.Value);
            objinventoryTransfer.InsertItemList(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, intEnroll, dteLastActionTime, strUoM);
            objinventoryTransfer.GetItemMasterList(strName,strDescription,strPartNo,strBrand,intClusterID,intComGroupID,intCategoryID,strUoM,intEnroll,intUnit,SADItemID,numConversion,intSadStandardUOM,intInvUoM);
            Panel1.Visible = false;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Updated.');", true);
        }

       
        protected void ddlFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "ddlFG_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                Panel1.Visible = true;
                Label lblBaseName = (Label)FindControl("lblitemBaseName");
                lblBaseName.Text = ddlFG.SelectedItem.Text;
                //Label lbldes = (Label)FindControl("lblitemDescription");
                //lbldes.Text = ddlInvUOM.SelectedItem.Text;
                Label lbluom = (Label)FindControl("lbluom");
                lbluom.Text = ddlInvUOM.SelectedItem.Text;
                Label lblcluster = (Label)FindControl("lblcluster");
                lblcluster.Text = "Material";
                Label lblcommodity = (Label)FindControl("lblcommodity");
                lblcommodity.Text = "Finished Goods";
                Label lblclus = (Label)FindControl("lblclus");
                lblclus.Text = 2.ToString();
                Label lblgroup = (Label)FindControl("lblgroup");
                lblgroup.Text = 37.ToString();
                Label lblcat = (Label)FindControl("lblcat");
                lblcat.Text = 45.ToString();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "ddlFG_SelectedIndexChanged", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "ddlFG_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlInvUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = 0.ToString();
            }
        }

        protected void ddlSadUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = 0.ToString();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            //Flogger.WriteDiagnostic(fd);
            //// starting performance tracker
            //var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
            //    fd.Product, fd.Layer);
            //try
            //{
            //    Panel1.Visible = true;
            //    Label lblBaseName = (Label)FindControl("lblitemBaseName");
            //    lblBaseName.Text = ddlFG.SelectedItem.Text;
            //    //Label lbldes = (Label)FindControl("lblitemDescription");
            //    //lbldes.Text = ddlInvUOM.SelectedItem.Text;
            //    Label lbluom = (Label)FindControl("lbluom");
            //    lbluom.Text = ddlInvUOM.SelectedItem.Text;
            //    Label lblcluster = (Label)FindControl("lblcluster");
            //    lblcluster.Text = "Material";
            //    Label lblcommodity = (Label)FindControl("lblcommodity");
            //    lblcommodity.Text = "Finished Goods";
            //    Label lblclus = (Label)FindControl("lblclus");
            //    lblclus.Text = 2.ToString();
            //    Label lblgroup = (Label)FindControl("lblgroup");
            //    lblgroup.Text = 37.ToString();
            //    Label lblcat = (Label)FindControl("lblcat");
            //    lblcat.Text = 45.ToString();
            //}
            //catch (Exception ex)
            //{
            //    var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
            //    Flogger.WriteError(efd);
            //}

            //fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            //Flogger.WriteDiagnostic(fd);
            //// ends
            //tracker.Stop();




        }
       
       










    }
}
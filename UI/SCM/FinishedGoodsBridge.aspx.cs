using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
namespace UI.SCM
{
    public partial class FinishedGoodsBridge : BasePage
    {
        DataTable dt = new DataTable();
        InventoryTransfer_BLL objinventoryTransfer = new InventoryTransfer_BLL();
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
            dt = objinventoryTransfer.GetWearHouse();
            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "strWareHoseName";
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataBind();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

            int unitid = Convert.ToInt32( ddlUnit.SelectedItem.Value) ;
            dt = objinventoryTransfer.GetFGList(unitid);
            ddlFG.DataSource = dt;
            ddlFG.DataTextField = "strProduct";
            ddlFG.DataValueField = "intID";
            ddlFG.DataBind();

            dt = objinventoryTransfer.GetSadUOMList(unitid);
            ddlSadUOM.DataSource=dt;
            ddlSadUOM.DataTextField = "strUOM";
            ddlSadUOM.DataValueField = "intID";
            ddlSadUOM.DataBind();

            dt = objinventoryTransfer.GetSadUOMList(unitid);
            ddlInvUOM.DataSource = dt;
            ddlInvUOM.DataTextField = "strUOM";
            ddlInvUOM.DataValueField = "intID";
            ddlInvUOM.DataBind();

        }

        protected void btnAddFg_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddMasterItem_Click(object sender, EventArgs e)
        {

        }

        protected void ddlFG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblitemBaseName.Text = ddlFG.SelectedItem.Text;
            //lblcluster.Text ="Material";
            //lblcommodity.Text ="Finished Goods";
            //lblclus.Text = 2.ToString();
            //lblgroup.Text = 37.ToString();
            //lblcat.Text = 45.ToString();
        }

        protected void ddlInvUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = "";
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
                txtCount.Text = "";
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            //lblitemBaseName.Text = ddlFG.SelectedItem.Text;
            //lbluom.Text = ddlInvUOM.SelectedItem.Text;
            //lblcluster.Text = "Material";
            //lblcommodity.Text = "Finished Goods";
            //lblclus.Text = 2.ToString();
            //lblgroup.Text = 37.ToString();
            //lblcat.Text = 45.ToString();

            //if(ddlSadUOM.SelectedItem.Text==ddlInvUOM.SelectedItem.Text)
            //{
            //    txtCount.Text = 1.ToString();
            //}
        }
    }
}
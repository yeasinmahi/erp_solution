using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.IHB;
using UI.ClassFiles;

namespace UI.SAD.Consumer
{
    public partial class TsoEmailAndJsoEnroll : System.Web.UI.Page
    {
        private readonly DistributorWithIhbBll _bll = new DistributorWithIhbBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadRegion();
            }
        }

        protected void show_OnClick(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void update_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            int intID = Convert.ToInt32(((HiddenField)gvr.FindControl("intID")).Value);
            string email = ((TextBox)gvr.FindControl("strEmailAddressNew")).Text;
            int enroll = Convert.ToInt32(((TextBox)gvr.FindControl("intJSOidNew")).Text);
            try
            {
                _bll.UpdateEmailAndEnroll(enroll, email, intID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Updated');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Failed');", true);
            }
            LoadGridView();
        }
        
        protected void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int regionId = Convert.ToInt32(ddlRegion.SelectedItem.Value);
            LoadArea(regionId);
        }

        protected void ddlArea_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int areaId = Convert.ToInt32(ddlArea.SelectedItem.Value);
            LoadTerritory(areaId);
        }

        protected void ddlTerritory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridView();
        }

        public void LoadGridView()
        {
            int territoryId = Convert.ToInt32(ddlTerritory.SelectedItem.Value);
            grdvCustomerWithIhb.DataSource = _bll.GetEmailAndEnroll(territoryId);
            grdvCustomerWithIhb.DataBind();
        }

        public void LoadRegion()
        {
            ddlRegion.DataSource = _bll.GetRegion();
            ddlRegion.DataValueField = "intID";
            ddlRegion.DataTextField = "strText";
            ddlRegion.DataBind();
        }
        public void LoadArea(int regionId)
        {
            ddlArea.DataSource = _bll.GetArea(regionId);
            ddlArea.DataValueField = "intID";
            ddlArea.DataTextField = "strText";
            ddlArea.DataBind();
        }

        public void LoadTerritory(int areaId)
        {
            ddlTerritory.DataSource = _bll.GetTerritory(areaId);
            ddlTerritory.DataValueField = "intID";
            ddlTerritory.DataTextField = "strText";
            ddlTerritory.DataBind();
        }
    }
}
using SAD_BLL.IHB;
using System;

namespace UI.SAD.IHB
{
    
    public partial class DistributorWithIHB : System.Web.UI.Page
    {
        private DistributorWithIhbBll _bll = new DistributorWithIhbBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRegion();
            }
            
        }

        protected void add_OnClick(object sender, EventArgs e)
        {
            
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
            int territoryId = Convert.ToInt32(ddlTerritory.SelectedItem.Value);
            LoadDistributor(territoryId);
            LoadAcrd(territoryId);
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
        public void LoadDistributor(int territoryId)
        {
            ddlDistributor.DataSource = _bll.GetDistributor(territoryId);
            ddlDistributor.DataValueField = "intCusID";
            ddlDistributor.DataTextField = "strName";
            ddlDistributor.DataBind();
        }
        public void LoadAcrd(int territoryId)
        {
            ddlIhb.DataSource = _bll.GetAcrd(territoryId);
            ddlIhb.DataValueField = "intCusID";
            ddlIhb.DataTextField = "strName";
            ddlIhb.DataBind();
        }

    }
}
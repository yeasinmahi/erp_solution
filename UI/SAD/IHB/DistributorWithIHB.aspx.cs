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

        public void LoadRegion()
        {
            ddlRegion.DataSource = _bll.GetRegion();
            ddlRegion.DataValueField = "intID";
            ddlRegion.DataTextField = "strText";
            ddlRegion.DataBind();
        }

        protected void ddlArea_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
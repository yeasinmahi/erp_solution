using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.IHB;

namespace UI.SAD.IHB
{
    public partial class DistributorWithIhbReport : System.Web.UI.Page
    {
        private DistributorWithIhbBll _bll = new DistributorWithIhbBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            LoadGreadView();
        }

        private void LoadGreadView()
        {
            grdvDistributorWithIhb.DataSource = _bll.GetDistributorWithIhbReport();
            grdvDistributorWithIhb.DataBind();
        }
    }
}
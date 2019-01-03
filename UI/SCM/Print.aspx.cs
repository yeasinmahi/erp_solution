using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class Print : BasePage
    {
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable(); private int check;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            dt = objOperation.WhDataView(8, "", 7, 22623, 2);
            dgvWHLocation.DataSource = dt;
            dgvWHLocation.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "gridviewScroll()", true);
        }
    }
}
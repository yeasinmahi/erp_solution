using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class Print : System.Web.UI.Page
    {
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable(); int check;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
                

        }

        protected void Show_Click(object sender, EventArgs e)
        {
            dt = objOperation.WhDataView(8, "", 7, 22623, 2);
            dgvWHLocation.DataSource = dt;
            dgvWHLocation.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "gridviewScroll()", true);
        }
    }
}
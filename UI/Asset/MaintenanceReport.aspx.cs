using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Purchase_BLL.Asset;
using System.Web.UI.WebControls;

namespace UI.Asset
{
    public partial class MaintenanceReport : System.Web.UI.Page
    {
        AssetMaintenance objReport= new AssetMaintenance();
        DataTable report = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
            DateTime todate = DateTime.Parse(TxtdteTo.Text);
            report = objReport.ReportAsset( fromdate, todate);

            GridView1.DataSource = report;
            GridView1.DataBind();
        }
    }
}
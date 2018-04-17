using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAD_BLL.TFSBLL;


namespace UI.TFS
{
    public partial class TestNew : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        test testReport = new test();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtReport = testReport.getReportproduct();
                GridView1.DataSource = dtReport;
                GridView1.DataBind();
            }
        }
    }
}
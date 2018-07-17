using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class UDTCLSalesViewReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GvSalesReport.Visible = false;
        }

       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GvSalesReport.Visible = true;
        }









    }
}
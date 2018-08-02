using SAD_BLL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales.Report
{
    public partial class UDTCLSalesInventory : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        UDTCLSalesBLL obj = new UDTCLSalesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //dt=obj.SalesInvtoryReport(2,)
            }
            catch { }
        }
    }
}
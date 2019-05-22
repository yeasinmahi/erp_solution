using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Delivery
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string test = Request.QueryString["intid"].ToString();

            int intID = int.Parse(Request.QueryString["intid"].ToString());
            int intCustomerId = int.Parse(Request.QueryString["intCusID"].ToString());
            string strReportType = Request.QueryString["strReportType"].ToString();
            int intShipPointID = int.Parse(Request.QueryString["ShipPointID"].ToString());

            //intCustomerId + "' + '" + intid + "'  + '" + strReportType

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using SAD_BLL.Corporate_sales;


namespace UI.SAD.Corporate_sales
{
    public partial class AFBLCorporateProduct : System.Web.UI.Page
    {
        Bridge obj = new Bridge();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dt = obj.productlists();
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
    }
}
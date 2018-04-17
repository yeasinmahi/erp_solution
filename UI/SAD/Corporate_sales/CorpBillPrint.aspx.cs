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
using SAD_BLL.Corporate_Sales;

namespace UI.SAD.Corporate_sales
{
    public partial class CorpBillPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerName(string prefixText, int count)
        {
            // Int32 unit = Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString())
            Int32 unit = Convert.ToInt32("2".ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetCustname(unit.ToString(), prefixText);

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
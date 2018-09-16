using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.Banking;
using GLOBAL_BLL;
using UI.ClassFiles;


namespace UI.Accounts.Banking
{
    public partial class BankForceReconcilePop : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\BankForceReconcilePop";
        string stop = "stopping Accounts\\Banking\\BankForceReconcilePop";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["alt"] == "true")
                {
                    GridView1.DataSourceID = "ObjectDataSource2";
                }
                else
                {
                    GridView1.DataSourceID = "ObjectDataSource1";
                }

                GridView1.DataBind();
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            Reconcile rc = new Reconcile();

            string type = Request.QueryString["type"];

            if (Request.QueryString["alt"] == "true")
            {
                GridView1.Caption = rc.GetReconcileType(rc.GetReconcileTypeAlternateValue(type));
            }
            else
            {
                GridView1.Caption = rc.GetReconcileType(type);
            }
        }
    }
}

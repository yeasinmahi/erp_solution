using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class UnderMaintanance : System.Web.UI.Page
    {
        public string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["err"] == "-1")
            {
                str = "System will be activated at: " + String.Format("{0:d/M/yyyy HH:mm tt}", (object)ConfigurationManager.AppSettings["UM_Ret"]);
            }
            else if (Request.QueryString["err"] == "-2")
            {
                str = "Could not connect with database. Please infom at Dept. Of Software.";
            }

            Panel1.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}

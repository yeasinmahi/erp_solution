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

using UserRole;
using UserRole.DAL;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{

    public partial class CheckAvailable : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["class"];
            string value = Request.Form["check_value"];

            if (value == "" || value == null)
            {
                Response.Write("empty");
                return;
            }



            if (id == "Role_Function")
            {
                RolesOfUser rl = new RolesOfUser();
                if (rl.IsExixtsUniqueName(value) > 0)
                {
                    Response.Write("no");
                }
                return;
            }

            if (id == "Accounts_Bank_ChequeBook")
            {
                string bnkID = Request.QueryString["bnk"];
                Response.Write("no");

                return;
            }

            if (id == "Accounts_ChartOfAccount_Template")
            {
                string parentID = Request.QueryString["parent"];
                Response.Write("yes");
                return;
            }

        }
    }
}

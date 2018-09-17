using GLOBAL_BLL;
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
using UI.ClassFiles;

namespace UI.Accounts.Bank
{
    //public partial class Accounts_Bank_BankInfoEdit : System.Web.UI.Page
    public partial class BankInfoEdit : BasePage
    {
        public string userID;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Bank\\BankInfoEdit";
        string stop = "stopping Accounts\\Bank\\BankInfoEdit";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            userID = "" + Session[SessionParams.USER_ID];

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

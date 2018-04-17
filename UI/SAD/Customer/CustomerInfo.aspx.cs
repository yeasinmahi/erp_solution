using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using SAD_DAL.Customer;
using SAD_BLL.Customer;
using BLL.Accounts.ChartOfAccount;
using GLOBAL_BLL;
using UI.ClassFiles;

namespace UI.SAD.Customer
{
    public partial class CustomerInfo : BasePage
    {
        //private string nextParentID = "";    
        CheckDigit cg = new CheckDigit();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //BuildTree();
            }
            else
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            ddlCusType.DataBind();
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected string GetEncodedDigit(object val)
        {
            return cg.Encode(val.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }

}
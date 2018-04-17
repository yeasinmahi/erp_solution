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
using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using UI.ClassFiles;

namespace UI.Accounts.ChartOfAccount
{
    public partial class Accounts_ChartOfAccount_GetInfo : BasePage
    //public partial class Accounts_ChartOfAccount_GetInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string k = "";

            string page = Request.QueryString["page"];
            if (page == "coaTemplete")
            {
                string parentID = Request.QueryString["parentID"];
                BLL.Accounts.ChartOfAccount.Template tmp = new BLL.Accounts.ChartOfAccount.Template();
                TemplateTDS.TblAccountsChartOfAccTemplateDataTable tbl = tmp.GetCOATempleteByAccount(int.Parse(parentID));
                k = k + "<script type=\"text/javascript\">";
                k = k + "parent.GetEditInfo(";
                k = k + "'" + tbl[0].strAccName + "',";
                k = k + "'" + (tbl[0].IsintModulesAutoIDNull() ? 0 : 1) + "',";
                k = k + "'" + (tbl[0].IsintModulesAutoIDNull() ? -1 : tbl[0].intModulesAutoID) + "',";
                k = k + "'" + tbl[0].intChildCodeLength + "',";
                k = k + "'" + (tbl[0].ysnSubLedger ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnLedger ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnTrBalance ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnIncomeSt ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnBalanceSh ? 1 : 0) + "'";
                k = k + ")";
                k = k + "</script>";
            }
            else if (page == "coaByUnit")
            {
                string parentID = Request.QueryString["parentID"];
                ChartOfAcc coa = new ChartOfAcc();
                ChartOfAccTDS.TblAccountsChartOfAccDataTable tbl = coa.GetDataByAccountIDForEdit(int.Parse(parentID));

                k = k + "<script type=\"text/javascript\">";
                k = k + "parent.GetEditInfo(";
                k = k + "'" + tbl[0].strAccName + "',";
                k = k + "'" + (tbl[0].IsintModulesAutoIDNull() ? 0 : 1) + "',";
                k = k + "'" + (tbl[0].IsintModulesAutoIDNull() ? "-1" : tbl[0].intModulesAutoID) + "',";
                k = k + "'" + tbl[0].intChildCodeLength + "',";
                k = k + "'" + (tbl[0].ysnSubLedger ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnLedger ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnTrBalance ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnIncomeSt ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].ysnBalanceSh ? 1 : 0) + "',";
                k = k + "'" + (tbl[0].IsmonCurrentBalanceNull() ? 0 : tbl[0].monCurrentBalance) + "'";
                k = k + ")";
                k = k + "</script>";
            }
            Response.Write(k);
        }
    }
}

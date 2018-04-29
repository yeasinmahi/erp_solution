using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class OverTimeIndivisualReprts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFullName.Attributes.Add("onkeyUp", "SearchText();");
            hdnAction.Value = "0";
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

        }

        protected void grdvOverTimeReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOverTimeReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gdvJstopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

    }
}
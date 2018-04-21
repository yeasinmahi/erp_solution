using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class PreviousPrice : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt;

        int intItemID;
        string strSPName, strPath;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = "";
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnBillID.Value = Session["billid"].ToString();
                
                intItemID = int.Parse(Request.QueryString["Id"]);
                hdnItemID.Value = intItemID.ToString();
                //Session["mrrid"] = intBillID.ToString();

                dt = new DataTable();
                dt = objBillApp.GetPriceListByItemID(intItemID);
                if (dt.Rows.Count > 0)
                {
                    dgvPriceList.DataSource = dt;
                    dgvPriceList.DataBind();
                }

                dt = new DataTable();
                dt = objBillApp.GetChartOfPrice(int.Parse(hdnItemID.Value));
                Chart1.DataSource = dt;
                Chart1.DataBind();
                
            }
        }

        public void btnBack_Click()
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + hdnBillID.Value + "');", true);
        }

        






















    }
}
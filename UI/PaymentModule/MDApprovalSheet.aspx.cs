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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class MDApprovalSheet : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/MDApprovalSheet.aspx";
        string stop = "stopping PaymentModule/MDApprovalSheet.aspx";

        Billing_BLL objBillReg = new Billing_BLL();
        Payment_All_Voucher_BLL obj = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intUnitID, intType;
        DateTime dteFDate, dteTDate;
        #endregion ====================================================================================      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Common_Reports/Payment/MdApprovalSheet?rs:Embed=true');", true);

        }
















    }
}
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
    public partial class AllApprovedBillReport : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration ====================================================
        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                if (!IsPostBack)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetUnitList(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }
                }
            }
            catch { }
        }








































            }
}
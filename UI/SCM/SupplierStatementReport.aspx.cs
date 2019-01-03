using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class SupplierStatementReport : System.Web.UI.Page
    {
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private int enroll, intWh; private string strType;
        private DataTable dt = new DataTable(); private string[] arrayKey; private char[] delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objPo.GetUnit();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strName";
                ddlUnit.DataValueField = "Id";
                ddlUnit.DataBind();
                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = getDept(strDept);
                string unit = ddlUnit.SelectedValue.ToString();
                Session["strUnt"] = unit;
            }
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, HttpContext.Current.Session["strType"].ToString(), HttpContext.Current.Session["strUnt"].ToString());
        }

        #endregion====================Close===============================

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string unit = ddlUnit.SelectedValue.ToString();
                Session["strUnt"] = unit;
                dgvBill.DataSource = "";
                dgvBill.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string item = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                string dept = ddlDept.SelectedItem.ToString();
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();

                int intunit = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = objPo.GetPoData(42, xmlData, intunit, supplierid, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                    dgvBill.DataSource = dt;
                    dgvBill.DataBind();
                }
            }
            catch { }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvBill.DataSource = dt;
                dgvBill.DataBind();
            }
            catch { }
        }

        private string getDept(string strDept)
        {
            try
            {
                if (strDept == "Local") { strType = "Local Purchase"; }
                else if (strDept == "Fabrication") { strType = "Local Fabrication"; }
                else if (strDept == "Import") { strType = "Foreign Purchase"; }
                return strType;
            }
            catch { return strType; }
        }
    }
}
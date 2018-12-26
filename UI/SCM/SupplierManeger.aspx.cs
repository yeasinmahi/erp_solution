using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class SupplierManeger : BasePage
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
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataBind();
                // dgvStatement.DataBind();
                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = GetDept(strDept);
            }
            else { }
        }

        private string GetDept(string strDept)
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

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDept = ddlDept.SelectedItem.ToString();
            Session["strType"] = GetDept(strDept);
        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string item = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
                dt = objPo.GetPoData(38, "", intWh, supplierid, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSupplierName.Text = dt.Rows[0]["strSuppMasterName"].ToString();
                    lblPostralAdd.Text = dt.Rows[0]["strOrgAddress"].ToString();
                    lblPhoneNo.Text = dt.Rows[0]["strOrgContactNo"].ToString();
                    lblFaxNo.Text = dt.Rows[0]["strOrgFAXNo"].ToString();
                    lblEmail.Text = dt.Rows[0]["strOrgMail"].ToString();
                    lblContactPerson.Text = dt.Rows[0]["strReprName"].ToString();
                    lblContactNo.Text = dt.Rows[0]["strReprContactNo"].ToString();
                    lblPayTo.Text = dt.Rows[0]["strPayToName"].ToString();
                    lblStatus.Text = dt.Rows[0]["ysnActive"].ToString();
                }
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int unit = int.Parse(ddlUnit.SelectedValue);
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string item = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string strDept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry strType=" + '"' + GetDept(strDept).ToString() + '"' + "/></voucher>".ToString();
                string msg = objPo.PoApprove(39, xmlData, unit, supplierid, DateTime.Now, enroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            catch { }
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchMasterSupplier(prefixText, HttpContext.Current.Session["strType"].ToString());
        }

        #endregion====================Close===============================
    }
}
using Flogging.Core;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoDocAttachment : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL(); Payment_All_Voucher_BLL obj = new Payment_All_Voucher_BLL();
        int enroll, intWh; string[] arrayKey;string strType; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                DefaltPageLoad(); Page.Header.DataBind();
            }
            else { }
          
        }
        private void DefaltPageLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                 
                dt = objPo.GetUnit();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitId";
                ddlUnit.DataBind();
                dt.Clear();
                dt = objPo.GetPoData(21, "", 0, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
                dt.Clear();
                //dt = objPo.GetPoData(14, "", 0, 0, DateTime.Now, enroll);
                //ddlPoUser.DataSource = dt;
                //ddlPoUser.DataTextField = "strName";
                //ddlPoUser.DataValueField = "Id";
                //ddlPoUser.DataBind();
                string dept = ddlDept.SelectedItem.ToString();
                if (dept == "Local") { dept = "Local Purchase"; }
                else if (dept == "Import") { dept = "Foreign Purchase"; }
                else { dept = "Fabrication"; }
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"'  + "/></voucher>".ToString();
                dt = objPo.GetPoData(25, xmlData, int.Parse(ddlUnit.SelectedValue), 0, DateTime.Now, enroll);
                //ddlSupplier.DataSource = dt;
                //ddlSupplier.DataTextField = "strName";
                //ddlSupplier.DataValueField = "Id";
                //ddlSupplier.DataBind();

                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = dept;
                string unitId = ddlUnit.SelectedValue.ToString();
                Session["unitId"] = unitId;

                dt.Clear();
            }
            catch { }

        }

        #region=======================Auto Search========================= 
        [WebMethod]
        [ScriptMethod]
        public static string[] GetPoUserSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchPoUser(prefixText);
        }
        #endregion====================Close===============================

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, HttpContext.Current.Session["strType"].ToString(),HttpContext.Current.Session["unitId"].ToString());
        }


        #endregion====================Close===============================

        protected void btnPoUserShow_Click(object sender, EventArgs e)
        {
			var fd = GetFlogDetail("starting SCM\\PoDocAttachment Show", null);

			Flogger.WriteDiagnostic(fd);

			// starting performance tracker
			var tracker = new PerfTracker("Performance on SCM\\PoDocAttachment Show", "", fd.UserName, fd.Location,
				fd.Product, fd.Layer);

			try {
                
                arrayKey = txtPoUser.Text.Split(delimiterChars);
                string item = ""; string itemid = "";
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); enroll = int.Parse(arrayKey[1].ToString()); }

                int unitID = int.Parse(ddlUnit.SelectedValue);
                string dept = ddlDept.SelectedItem.ToString();
              
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string strSupp = ""; int supplierid = 0;

                try
                {
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
                    strSupp = supplierid.ToString();
                }
                catch { }


                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text);

                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + " strSupp=" + '"' + strSupp + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(34, xmlData, unitID, 0, dteFrom, enroll);
                dgvPO.DataSource = dt;
                dgvPO.DataBind();

                
                lblAddress.Text = "Akij House, 198 Bir Uttam Mir Shawkat Sarak, Tejgaon, Dhaka-1208";
                lblDate.Text = "For The Month of " + txtdteFrom.Text + " To " + txtdteTo.Text;
                lblunit.Text = "";
                DataTable dts = new DataTable();
                dts = obj.GetUnitAddress(unitID);
                if (dts.Rows.Count > 0)
                {
                    Label lbluni = FindControl("lblunit") as Label;
                    lbluni.Text= dts.Rows[0]["strDescription"].ToString();
                    
                }

            }
            catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}

			fd = GetFlogDetail("stopping SCM\\PoDocAttachment Show", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();

			int a = 30;


		}

        protected void btnPoSuppShow_Click(object sender, EventArgs e)
        {
            try
            {
                int unitID = int.Parse(ddlUnit.SelectedValue);
                string dept = ddlDept.SelectedItem.ToString();

                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string strSupp = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { strSupp = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }
                strSupp = supplierid.ToString();
                enroll = supplierid;
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text);

                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + " strSupp=" + '"' + strSupp + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(26, xmlData, unitID, 0, dteFrom, enroll);
                dgvPO.DataSource = dt;
                dgvPO.DataBind();
               
            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string dept = ddlDept.SelectedItem.ToString();
                if (dept == "Local") { dept = "Local Purchase"; }
                else if (dept == "Import") { dept = "Foreign Purchase"; }
                else { dept = "Fabrication"; }
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(25, xmlData, int.Parse(ddlUnit.SelectedValue), 0, DateTime.Now, enroll);
                //ddlSupplier.DataSource = dt;
                //ddlSupplier.DataTextField = "strName";
                //ddlSupplier.DataValueField = "Id";
                //ddlSupplier.DataBind();

                string strDept = ddlDept.SelectedItem.ToString();
                Session["strType"] = dept;
                string unitId = ddlUnit.SelectedValue.ToString();
                Session["unitId"] = unitId;
                dt.Clear();
            }
            catch { }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDept = ddlDept.SelectedItem.ToString();
            Session["strType"] = getDept(strDept);
            string unitId = ddlUnit.SelectedValue.ToString();
            Session["unitId"] = unitId;
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

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                string unit = ddlUnit.SelectedItem.ToString();
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblPoId = row.FindControl("lblPoId") as Label;
                Label lblmonBillAmount = row.FindControl("lblmonBillAmount") as Label;
                Label lblBillId = row.FindControl("lblBillId") as Label;
                Label lblBillCode = row.FindControl("lblBillCode") as Label;

                string PoId = lblPoId.Text.ToString();
                string BillAmount = lblmonBillAmount.Text.ToString();
                string BillId = lblBillId.Text.ToString();
                string BillCode = lblBillCode.Text.ToString();
                

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + unit + "','" + PoId.ToString() + "','" + BillAmount + "','" + BillId + "','" + BillCode + "');", true);
            }
            catch { }

        }

		private FlogDetail GetFlogDetail(string message, Exception ex)
		{
			return new FlogDetail
			{
				Product = "ERP",
				Location = "SCM",
				Layer = "BillForwardToBillingReport\\Show",
				UserName = Environment.UserName,
				Hostname = Environment.MachineName,
				Message = message,
				Exception = ex
			};
		}
	}
}
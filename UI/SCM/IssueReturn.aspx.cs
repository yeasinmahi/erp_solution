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
using Purchase_BLL.Asset;
namespace UI.SCM
{
    public partial class IssueReturn : System.Web.UI.Page
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataValueField = "Id";
                ddlWH.DataTextField = "strName";
                ddlWH.DataBind();

                Session["WareID"] = ddlWH.SelectedValue.ToString();
            }
            else
            { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                getIssueItem();

            }
            catch { }
        }

        private void getIssueItem()
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            intwh = int.Parse(ddlWH.SelectedValue);
            DateTime dteFrom = DateTime.Parse(txtdteFrom.Text.ToString());
            DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
            string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
            dt = objIssue.GetViewData(6, xmlData, intwh, 0, DateTime.Now, enroll);
            dgvPoApp.DataSource = dt;
            dgvPoApp.DataBind();
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSearch(string prefixText, int count)
        {
            return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }


        #endregion====================Close===============================
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                Session["WareID"] = ddlWH.SelectedValue.ToString();
            }
            catch { }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value == "1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = "";
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                    TextBox txtRemarks = row.FindControl("txtRemarks") as TextBox;
                    Label lblIssueId = row.FindControl("lblIssueId") as Label;
                     
                    string IssueID = lblIssueId.Text.ToString();

                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    double returnQty = double.Parse(txtReturnQty.Text.ToString());
                    string remarks = txtRemarks.Text.ToString();
                    string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty.ToString() + '"' + " remarks=" + '"' + remarks + '"' + " IssueID=" + '"' + IssueID + '"' + "/></voucher>".ToString();
                    if (returnQty>0)
                    {
                        string msg = objIssue.StoreIssue(7, xmlData, intwh,int.Parse(itemid), DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        getIssueItem();
                    } 
                }

            }
            catch { }
        }
    }
}
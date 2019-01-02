using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SCM
{
    public partial class IssueReturn : System.Web.UI.Page
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intwh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IssueReturn";
        private string stop = "stopping SCM\\IssueReturn";
        private string perform = "Performance on SCM\\IssueReturn";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            arrayKey = txtItem.Text.Split(delimiterChars);
            string item = ""; string itemid = "";
            if (arrayKey.Length > 0)
            { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            intwh = int.Parse(ddlWH.SelectedValue);
            DateTime dteFrom = DateTime.Parse(txtdteFrom.Text.ToString());
            DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
            string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
            dt = objIssue.GetViewData(6, xmlData, intwh, int.Parse(itemid), DateTime.Now, enroll);
            dgvPoApp.DataSource = dt;
            dgvPoApp.DataBind();
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSearch(string prefixText, int count)
        {
            AutoSearch_BLL ast = new AutoSearch_BLL();
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
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
            var fd = log.GetFlogDetail(start, location, "btnReturn_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnReturn_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
                    if (returnQty > 0)
                    {
                        string msg = objIssue.StoreIssue(7, xmlData, intwh, int.Parse(itemid), DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        getIssueItem();
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnReturn_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnReturn_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }
    }
}
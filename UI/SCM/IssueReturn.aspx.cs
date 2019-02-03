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
using Utility;

namespace UI.SCM
{
    public partial class IssueReturn : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private DataTable dt = new DataTable();
        private int intwh;
        private string[] arrayKey; private char[] delimiterChars = { '[', ']' };

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IssueReturn";
        private string stop = "stopping SCM\\IssueReturn";
        private string perform = "Performance on SCM\\IssueReturn";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ast = new AutoSearch_BLL();
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, Enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataValueField = "Id";
                ddlWH.DataTextField = "strName";
                ddlWH.DataBind();

                Session["WareID"] = Common.GetDdlSelectedValue(ddlWH);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetIssueItem();
        }

        private void GetIssueItem()
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                int itemid = 0;
                if (arrayKey.Length > 0)
                {
                    int.TryParse(arrayKey[1], out itemid);
                }
                if (itemid <= 0)
                {
                    Alert("Item Id "+Message.ParsingProblem.ToFriendlyString());
                    return;
                }
                intwh = Common.GetDdlSelectedValue(ddlWH);
                DateTime dteFrom = new DateTime();
                DateTime dteTo = new DateTime();
                try
                {
                    dteFrom = DateTime.Parse(txtdteFrom.Text);
                }
                catch (Exception e)
                {
                    Alert("From " + Message.DateFormatError.ToFriendlyString());
                }
                try
                {
                    dteTo = DateTime.Parse(txtdteTo.Text);
                }
                catch (Exception e)
                {
                    Alert("To "+Message.DateFormatError.ToFriendlyString());
                }
                dt = objIssue.GetIssueItem(itemid,intwh,dteFrom,dteTo);

                if (dt.Rows.Count > 0)
                {
                    dgvPoApp.DataSource = dt;
                    dgvPoApp.DataBind();
                }
                else
                {
                    Alert(Message.NoFound.ToFriendlyString());
                }
            }
            catch (Exception e)
            {
                Alert(e.Message);
            }
        }

        #region=======================Auto Search=========================
        static AutoSearch_BLL ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSearch(string prefixText, int count)
        {
            
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion====================Close===============================

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = Common.GetDdlSelectedValue(ddlWH);
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
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
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = "";
                if (arrayKey.Length > 0)
                { item = arrayKey[0]; itemid = arrayKey[1]; }

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                TextBox txtRemarks = row.FindControl("txtRemarks") as TextBox;
                Label lblIssueId = row.FindControl("lblIssueId") as Label;

                string IssueID = lblIssueId.Text;

                double returnQty = double.Parse(txtReturnQty.Text);
                string remarks = txtRemarks.Text;
                string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty + '"' + " remarks=" + '"' + remarks + '"' + " IssueID=" + '"' + IssueID + '"' + "/></voucher>";
                if (returnQty > 0)
                {
                    string msg = objIssue.StoreIssue(7, xmlData, intwh, int.Parse(itemid), DateTime.Now, Enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    GetIssueItem();
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
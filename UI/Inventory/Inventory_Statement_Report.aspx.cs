using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class Inventory_Statement_Report : BasePage
    {
        private DataTable dt = new DataTable();
        private InventoryTransfer_BLL objbll = new InventoryTransfer_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    int enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
                    dt = new MrrReceive_BLL().DataView(19, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                catch { }
            }
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId;
            int Type = Convert.ToInt32(ddlSearchBy.SelectedItem.Value);
            int WH = Convert.ToInt32(ddlWH.SelectedItem.Value);
            try { itemId = Convert.ToInt32(txtItemID.Text); }
            catch { itemId = 0; }

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);

            dt = objbll.InventorySearch(Type, WH, itemId);
            ddlSubCategory.DataSource = dt;
            ddlSubCategory.DataTextField = "strSearch";
            ddlSubCategory.DataValueField = "intId";
            ddlSubCategory.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string id = "";
            int WH = Convert.ToInt32(ddlWH.SelectedItem.Value);
            int ddlsearch = Convert.ToInt32(ddlSearchBy.SelectedItem.Value);
            if (ddlsearch == 4)
            {
                id = txtItemName.Text;
                txtItemID.Text = "";
                try
                {
                    if (!string.IsNullOrEmpty(ddlSubCategory.SelectedItem.Text))
                    {
                        ddlSubCategory.DataSource = null;
                        ddlSubCategory.DataBind();
                    }
                }
                catch
                {
                    ddlSubCategory.DataSource = null;
                    ddlSubCategory.DataBind();
                }
            }
            else if (ddlsearch == 3)
            {
                id = txtItemID.Text;
            }
            else if (ddlsearch == 11)
            {
                id = "";
                ddlsearch = 4;
            }
            else if (ddlsearch == 2)
            {
                id = ddlSubCategory.SelectedItem.Text;
            }
            else
            {
                id = ddlSubCategory.SelectedItem.Value;
            }
            string fromTime = txtFormTime.Text;
            string toTime = txtToTime.Text;

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            string url;
            if (string.IsNullOrWhiteSpace(fromTime) || string.IsNullOrWhiteSpace(toTime))
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Open_Reports/Inventory_Report_New" + "&wh=" + ddlWH.SelectedItem.Value + "&SearchBy=" + ddlsearch + "&FromDate=" + txtFromDate.Text + "&ToDate=" + txtToDate.Text + "&strID=" + id + "&rc:LinkTarget=_self";
            }
            else
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Open_Reports/Inventory_Report_New" + "&wh=" + ddlWH.SelectedItem.Value + "&SearchBy=" + ddlsearch + "&FromDate=" + txtFromDate.Text + " " + fromTime + "&ToDate=" + txtToDate.Text + " " + toTime + "&strID=" + id + "&rc:LinkTarget=_self";
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSearchBy.SelectedIndex = ddlSearchBy.Items.IndexOf(ddlSearchBy.Items.FindByValue("11"));
        }
    }
}
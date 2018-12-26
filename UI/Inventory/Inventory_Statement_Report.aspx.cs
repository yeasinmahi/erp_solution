using Purchase_BLL.Asset;
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

namespace UI.Inventory
{
    public partial class Inventory_Statement_Report : BasePage
    {
        DataTable dt = new DataTable();
        InventoryTransfer_BLL objbll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    int enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
                    dt = objbll.GetWH(enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataBind();
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
            catch {  itemId = 0; }

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
         

            dt = objbll.InventorySearch(Type, WH, itemId);
            ddlSubCategory.DataSource = dt;
            ddlSubCategory.DataTextField = "strSearch";
            ddlSubCategory.DataValueField = "intId";
            ddlSubCategory.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            string id="";
            int WH = Convert.ToInt32(ddlWH.SelectedItem.Value);
            int ddlsearch = Convert.ToInt32(ddlSearchBy.SelectedItem.Value);
            if(ddlsearch==4)
            {
                id = txtItemName.Text;
                txtItemID.Text = "";
                try
                {
                    if(!string.IsNullOrEmpty(ddlSubCategory.SelectedItem.Text))
                    {
                        ddlSubCategory.DataSource=null;
                        ddlSubCategory.DataBind();
                    }
                }
                catch
                {
                    ddlSubCategory.DataSource = null;
                    ddlSubCategory.DataBind();
                }
            }
            else if(ddlsearch==3)
            {
                id = txtItemID.Text;
            }
            else if (ddlsearch == 11)
            {
                id = "";
                ddlsearch = 4;
            }
            else
            {
                id = ddlSubCategory.SelectedItem.Value;
            }

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Open_Reports/Inventory_Report_New" + "&wh=" + ddlWH.SelectedItem.Value + "&SearchBy=" + ddlsearch + "&FromDate=" + txtFromDate.Text + "&ToDate=" + txtToDate.Text + "&strID=" + id + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {          
            ddlSearchBy.SelectedIndex = ddlSearchBy.Items.IndexOf(ddlSearchBy.Items.FindByValue("11"));
        }
    }
}
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/Reports/report/Corporate/Inventory_Report_New?rs:Embed=true');", true);
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

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId;
            int Type = Convert.ToInt32(ddlSearchBy.SelectedItem.Value);
            int WH = Convert.ToInt32(ddlWH.SelectedItem.Value);
            try { itemId = Convert.ToInt32(txtItemID.Text); }
            catch {  itemId = 0; }


            dt = objbll.InventorySearch(Type, WH, itemId);
            ddlSubCategory.DataSource = dt;
            ddlSubCategory.DataTextField = "strSearch";
            ddlSubCategory.DataValueField = "intId";
            ddlSubCategory.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int id=0,searchBy=0;
            int WH = Convert.ToInt32(ddlWH.SelectedItem.Value);
            try
            {
                if (!String.IsNullOrEmpty(ddlSubCategory.SelectedItem.Value))
                {
                    id = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
                    //txtItemID.Text = "";
                    searchBy = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
                }
            }
            catch {  }
           
            try
            {
                if (!String.IsNullOrEmpty(txtItemID.Text))
                {
                    id = Convert.ToInt32(txtItemID.Text);
                    
                    searchBy = Convert.ToInt32(ddlSearchBy.SelectedItem.Value);
                    if (!String.IsNullOrEmpty(ddlSubCategory.SelectedItem.Value))
                    {
                        ddlSubCategory.SelectedItem.Text = "";
                    }
                    }
            }
            catch { id = 0; }

            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Corporate/Inventory_Report_New" + "&wh=" + ddlWH.SelectedItem.Value + "&SearchBy=" + searchBy + "&FromDate=" + txtFromDate.Text + "&ToDate=" + txtToDate.Text + "&strID=" + id + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }
    }
}
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ItemCategoryUpdate : BasePage
    {

        private MrrReceive_BLL obj = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intWh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = obj.DataView(1, "", intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

            }
            else { }
        }


        protected void btnShowItem_Click(object sender, EventArgs e)
        {
            intWh = ddlWH.SelectedValue();
            dt = new DataTable();
            dt = obj.GetItemList(intWh);
            dgvItem.DataSource = dt;
            dgvItem.DataBind();
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            //enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            //GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

            //Label lblMrrId = row.FindControl("lblMrrId") as Label;

            //string MrrId = lblMrrId.Text;

            //Session["MrrID"] = lblMrrId;
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + MrrId + "');", true);
        }


      
    }
}
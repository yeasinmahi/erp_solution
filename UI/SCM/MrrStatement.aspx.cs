using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class MrrStatement : System.Web.UI.Page
    {
        MrrReceive_BLL obj = new MrrReceive_BLL();
        DataTable dt = new DataTable();
        int enroll, intWh, Mrrid;
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

                dt = obj.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
            }
            else { }

        }

        protected void btnAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer; 
                Label lblMrrId = row.FindControl("lblMrrId") as Label;

                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewdetails('" + MrrId + "');", true); 

            }
            catch { }

        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWH.SelectedValue);
                    DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                    DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                    string dept = ddlDept.SelectedItem.ToString();
                    
                    string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                    try { Mrrid = int.Parse(txtMrrNo.Text); } catch { Mrrid = 0; }
                    dt = obj.DataView(12, xmlData, intWh, Mrrid, dteFrom, enroll);
                    dgvIndent.DataSource = dt;
                    dgvIndent.DataBind();
                }
                catch { }
            }
            catch { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {

            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                 
               
                Label lblMrrId = row.FindControl("lblMrrId") as Label;
                
                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + MrrId + "');", true);


            }
            catch { }

        }

        
    }
}
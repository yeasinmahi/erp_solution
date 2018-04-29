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
    public partial class IndentStatus :BasePage
    {
        Indents_BLL objIndent = new Indents_BLL();
        DataTable dt = new DataTable();
        int enroll,intwh, indentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIndent.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                dt = objIndent.DataView(11, "", 0, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
            }
            else { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.Visible = true;
                dgvStatement.Visible = false;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                string dept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                try { indentId = int.Parse(txtIndentNo.Text); } catch { indentId = 0; }
                dt = objIndent.DataView(12, xmlData, intwh, indentId, dteFrom, enroll);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
            }
            catch { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
         
                Label lblDueDate = row.FindControl("lblDueDate") as Label;
                Label lblIndentDate = row.FindControl("lblIndentDate") as Label;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                string dteIndent = lblIndentDate.Text;
                string dteDue = lblDueDate.Text;
                string indentID = lblIndent.Text;
                string dept = ddlDept.SelectedItem.ToString();
                string whname = ddlWH.SelectedItem.ToString();
                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + dteIndent + "','" + dteDue.ToString() + "','" + indentID + "','" + dept + "','" + whname + "');", true);
                 
            }
            catch { }
        }

        protected void btnStementDetalis_Click(object sender, EventArgs e)
        {
             
                try
                { 
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                    Label lblDueDate = row.FindControl("lblDueDate") as Label;
                    Label lblIndentDate = row.FindControl("lblIndentDate") as Label;
                    Label lblIndent = row.FindControl("lblIndent") as Label;
                    string dteIndent = lblIndentDate.Text;
                    string dteDue = lblDueDate.Text;
                    string indentID = lblIndent.Text;
                    string dept = ddlDept.SelectedItem.ToString();
                    string whname = ddlWH.SelectedItem.ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + dteIndent + "','" + dteDue.ToString() + "','" + indentID + "','" + dept + "','" + whname + "');", true);


                }
                catch { }
            
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.Visible = false;
                dgvStatement.Visible = true;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                string dept = ddlDept.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                try { indentId = int.Parse(txtIndentNo.Text); } catch { indentId = 0; }
                dt = objIndent.DataView(13, xmlData, intwh, indentId, dteFrom, enroll);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
            }
            catch { }
           
        }
    }
}
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
    public partial class ConsumpReport : BasePage
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh;

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataValueField = "Id";
                ddlWh.DataTextField = "strName";
                ddlWh.DataBind();

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(9, "", 0, 0, DateTime.Now, enroll);
                ddlFilter.DataSource = dt;
                ddlFilter.DataValueField = "Id";
                ddlFilter.DataTextField = "strName";
                ddlFilter.DataBind();
                ddlFilter.Items.Insert(0, new ListItem("Add New", ""));

                dt = objIssue.GetViewData(10, "", 0, 0, DateTime.Now, enroll);
                ddlSection.DataSource = dt;
                ddlSection.DataValueField = "Id";
                ddlSection.DataTextField = "strName";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("Add New", ""));
            }
            else
            {

            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string dept = ddlFilter.SelectedItem.ToString();
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString(); 
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptId =int.Parse(ddlFilter.SelectedItem.ToString());
                dt = objIssue.GetViewData(12, "", intwh, deptId, DateTime.Now, enroll);
                dgvConsump.DataSource = dt;
                dgvConsump.DataBind();
            }
            catch { }
        }

        protected void btnFilterDept_Click(object sender, EventArgs e)
        {
            try
            {
                string dept = ddlSection.SelectedItem.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(11, "", intwh, 0, DateTime.Now, enroll);
                dgvConsump.DataSource = dt;
                dgvConsump.DataBind();
            }
            catch { }
        }
    }
}
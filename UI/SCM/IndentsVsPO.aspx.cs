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
    public partial class IndentsVsPO : System.Web.UI.Page
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();

        DataTable dt = new DataTable();
        int enroll, intwh;
        
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

            }
            else { }
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                int sortBy = int.Parse(ddlSortBy.SelectedValue);
                string dept = ddlType.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + " sortBy=" + '"' + sortBy + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(15, xmlData, intwh, 0, DateTime.Now, enroll);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();

            }
            catch { }
        }
    }
}
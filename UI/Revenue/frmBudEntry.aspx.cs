using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.RevenueBLL;
using SCM_BLL;
using UI.ClassFiles;

namespace UI.Revenue
{
    public partial class frmBudEntry : System.Web.UI.Page
    {
        RevenueClsBLL objrev = new RevenueClsBLL();
        DataTable dt;
        InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        string xmlString; int Id;
        int enroll, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblCompany.Text = "Akij Food & Beverage Ltd.";
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id";
                ddlWh.DataBind();
            }

        }



        protected void btnShow_Click(object sender, EventArgs e)
        {
            //dt = objrev.getRevenue(int.Parse(ddlWh.SelectedValue), DateTime.Parse(txtFrom.Text), DateTime.Parse(txtTo.Text),int.Parse("5"),ddlRptType.SelectedValue.ToString());

            dt = objrev.getInventoryMRRReport(int.Parse(ddlWh.SelectedValue.ToString()), int.Parse(ddlRptType.SelectedValue.ToString()),DateTime.Parse(txtFrom.Text),DateTime.Parse(txtTo.Text));
            dgvRpt.DataSource = dt;
            dgvRpt.DataBind();

        }

        protected void ddlSubList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
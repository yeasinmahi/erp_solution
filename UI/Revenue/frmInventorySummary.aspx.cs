using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.RevenueBLL;
using UI.ClassFiles;

namespace UI.Revenue
{
    public partial class frmInventorySummary : BasePage
    {
        RevenueClsBLL objrev = new RevenueClsBLL();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                ProductShow();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("Akij Food & Beverage Ltd.");
            lblHeading.Text = "Ok";
        }
        private void ProductShow()
        {
            dt = objrev.getMainHead();
            ddlMainHead.DataTextField = "strCCName";
            ddlMainHead.DataValueField = "intCostCenterID";
            ddlMainHead.DataSource = dt;
            ddlMainHead.DataBind();
        }

        protected void ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMainSub();
        }

        private void getMainSub()
        {
            dt = objrev.getCCSub(int.Parse(ddlMainHead.SelectedValue));
        }

        protected void ddlSubList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
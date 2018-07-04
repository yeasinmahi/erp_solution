using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;
using SAD_BLL.RevenueBLL;

namespace UI.Revenue
{
    public partial class frmBudgetVSRevenue : BasePage
    {
        string headname;
        int intheadid, intEnroll,intUnitid;
        RevenueClsBLL objrev = new RevenueClsBLL();     
        DataTable dt;
        char[] delimiterChars = { '[', ']' };

        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                lblVatAccount.Text = "Akij Food & Beverage Ltd.";
                getRevinuelist(0);
                getyearlist();
            }
        }

        private void getyearlist()
        {
            dt = objrev.getyearlist();
            ddlyear.DataTextField = "intYear";
            ddlyear.DataValueField = "intYear";
            ddlyear.DataSource = dt;
            ddlyear.DataBind();

        }

        protected void ddl2ndHead_SelectedIndexChanged(object sender, EventArgs e)
        {

            getlinebind();
        }

        private void getlinebind()
        {
            dt = objrev.getRevinuewList(int.Parse(ddl2ndHead.SelectedValue.ToString()));

            ddlregion.DataTextField = "strRCName";
            ddlregion.DataValueField = "intRCid";
            ddlregion.DataSource = dt;
            ddlregion.DataBind();
            if (dt.Rows.Count > 0)
            {

                dt = objrev.getRevinuewList(int.Parse(ddlregion.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    ddlArea.DataTextField = "strRCName";
                    ddlArea.DataValueField = "intRCid";
                    ddlArea.DataSource = dt;
                    ddlArea.DataBind();
                }
                else
                {
                    ddlArea.DataTextField = "strRCName";
                    ddlArea.DataValueField = "intRCid";
                    ddlArea.DataSource = dt;
                    ddlArea.DataBind();
                }
            }
            else
            {
                ddlArea.DataTextField = "strRCName";
                ddlArea.DataValueField = "intRCid";
                ddlArea.DataSource = dt;
                ddlArea.DataBind();
            }


        }

        protected void ddlregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRegion();
        }

        private void getRegion()
        {
            dt = objrev.getRevinuewList(int.Parse(ddlregion.SelectedValue.ToString()));

            ddlArea.DataTextField = "strRCName";
            ddlArea.DataValueField = "intRCid";
            ddlArea.DataSource = dt;
            ddlArea.DataBind();
        }

        private void getRevinuelist(int parentid)
        {
            dt = objrev.getRevinuewList(parentid);

            ddlMainHead.DataTextField = "strRCName";
            ddlMainHead.DataValueField = "intRCid";
            ddlMainHead.DataSource = dt;
            ddlMainHead.DataBind();
            dt = objrev.getRevinuewList(int.Parse(ddlMainHead.SelectedValue));

            ddl2ndHead.DataTextField = "strRCName";
            ddl2ndHead.DataValueField = "intRCid";
            ddl2ndHead.DataSource = dt;
            ddl2ndHead.DataBind();

            dt = objrev.getRevinuewList(int.Parse(ddl2ndHead.SelectedValue));
            ddlregion.DataTextField = "strRCName";
            ddlregion.DataValueField = "intRCid";
            ddlregion.DataSource = dt;
            ddlregion.DataBind();
            if (ddlregion.SelectedItem.Value != "")
            {
                dt = objrev.getRevinuewList(int.Parse(ddlregion.SelectedValue));
                ddlArea.DataTextField = "strRCName";
                ddlArea.DataValueField = "intRCid";
                ddlArea.DataSource = dt;
                ddlArea.DataBind();
            }

        }

        protected void ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRevinuelist(int.Parse(ddlMainHead.SelectedValue.ToString()));
        }
        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            dt = objrev.getRpt(DateTime.Now,int.Parse(ddlyear.SelectedItem.ToString()));
            dgvRpt.DataSource = dt;
            dgvRpt.DataBind();

        }



    }
}
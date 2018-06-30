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
    public partial class frmRevenueBudgetEntry : BasePage
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
                //  ProductShow();
                getline();
                getRegionG();
                getAreaG();
              
            }
        }

        private void getAreaG()
        {

            dt = objrev.GetAreaG(int.Parse(ddlregionG.SelectedValue));
            ddlAreaG.DataTextField = "strArea";
            ddlAreaG.DataValueField = "intAreaId";
            ddlAreaG.DataSource = dt;
            ddlAreaG.DataBind();
        }

        private void getRegionG()
        {
            dt = objrev.getRegionG(int.Parse(ddlLineG.SelectedValue));
            ddlregionG.DataTextField = "strRegion";
            ddlregionG.DataValueField = "intRegionId";
            ddlregionG.DataSource = dt;
            ddlregionG.DataBind();
        }

        private void getline()
        {
            dt = objrev.getLineG();
            ddlLineG.DataTextField = "strFGGroupName";
            ddlLineG.DataValueField = "intFGGroupID";
            ddlLineG.DataSource = dt;
            ddlLineG.DataBind();
        }

        protected void ddl2ndHead_SelectedIndexChanged(object sender, EventArgs e)
        {

            getlinebind();
           // ProductShow();

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

            dt = objrev.getRevinuewList(int.Parse(ddlregion.SelectedValue));
            ddlArea.DataTextField = "strRCName";
            ddlArea.DataValueField = "intRCid";
            ddlArea.DataSource = dt;
            ddlArea.DataBind();

        }

        protected void ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRevinuelist(int.Parse(ddlMainHead.SelectedValue.ToString()));
        }
       
     
        protected void txtLine_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string names = "A";

            objrev.getUpdateLine(int.Parse(ddlLineG.SelectedValue),int.Parse(ddl2ndHead.SelectedValue));


            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLineG_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            getRegionG();
            getAreaG();
        }

        protected void ddlregionG_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            getAreaG();
        }

        protected void btnRegionUpdate_Click(object sender, EventArgs e)
        {
            objrev.getUpdateLine(int.Parse(ddlregionG.SelectedValue), int.Parse(ddlregion.SelectedValue));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
        }

        protected void btnareaG_Click(object sender, EventArgs e)
        {
            objrev.getUpdateLine(int.Parse(ddlAreaG.SelectedValue), int.Parse(ddlArea.SelectedValue));

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
        }

        private void get2nd()
        {
            dt = objrev.getRevinuewList(int.Parse(ddlMainHead.SelectedValue));
            ddl2ndHead.DataTextField = "strRCName";
            ddl2ndHead.DataValueField = "intRCid";
            ddl2ndHead.DataSource = dt;
            ddl2ndHead.DataBind();

            ddlregion.DataTextField = "strRCName";
            ddlregion.DataValueField = "intRCid";
            ddlregion.DataSource = dt;
            ddlregion.DataBind();


            dt = objrev.getRevinuewList(int.Parse(ddlregion.SelectedValue));
            ddlArea.DataTextField = "strRCName";
            ddlArea.DataValueField = "intRCid";
            ddlArea.DataSource = dt;
            ddlArea.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }
       

    }
}
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ItemManager : System.Web.UI.Page
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        DataTable dt = new DataTable();
        int enroll,wh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt= objIssue.GetViewData(1, "", wh, 0, DateTime.Now, enroll);
               // dt = objIssue.GetWH();
                ddlWh.DataSource = dt;
                ddlWh.DataValueField = "Id";
                ddlWh.DataTextField = "strName";
                ddlWh.DataBind();
                wh = int.Parse(ddlWh.SelectedValue);
                dt = objIssue.GetWhByLocation(wh);
                ddlLocation.DataSource = dt;
                ddlLocation.DataValueField = "Id";
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataBind();
                 
            }
            else { }

        }

         

        protected void ListDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch { }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                wh = int.Parse(ddlWh.SelectedValue);
                dt = objIssue.GetWhByLocation(wh);
                ddlLocation.DataSource = dt;
                ddlLocation.DataValueField = "Id";
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataBind();
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string masteritem = ListDatas.SelectedValue.ToString();
                wh = int.Parse(ddlWh.SelectedValue);           
                string xmlData = "<voucher><voucherentry masteritem=" + '"' + masteritem + '"' +   "/></voucher>".ToString();
                int location = int.Parse(ddlLocation.SelectedValue);
                if (location > 0)
                {
                    string msg = objIssue.StoreIssue(13, xmlData, wh, location, DateTime.Now, enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Sselect your location');", true); }
               
            }

            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string strSearchKey = txtItem.Text.ToString();
                dt = objIssue.GetMasterItem(  strSearchKey);
                ListDatas.DataSource = dt;
                ListDatas.DataValueField = "intItemMasterID";
                ListDatas.DataTextField = "strItemMasterName";
                ListDatas.DataBind();
                
            }
            catch { }
        }
    }
}
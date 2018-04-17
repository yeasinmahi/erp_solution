using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UI.ClassFiles;
using HR_BLL.KPI;

namespace UI.HR.KPI
{
    public partial class WorkPlanReport_UI : BasePage
    {
        WorkPlan_BLL objPlan = new WorkPlan_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objPlan.UnitnameGet();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
                int unit = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
                dt = objPlan.FineancialYear();
                ddlFinanencialYear.DataSource = dt;
                ddlFinanencialYear.DataTextField = "Name";

                ddlFinanencialYear.DataBind();
                pnlUpperControl.DataBind();
             

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int unit = int.Parse(ddlUnit.SelectedValue.ToString());
            string fyear = ddlFinanencialYear.SelectedItem.ToString();
            dt = new DataTable();
            dt = objPlan.workplanViewReport(unit, fyear);
            if (dt.Rows.Count>0)
            {
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
            }
           
        }

       

       

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intAutoID"] = ordernumber1;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ReportDetalisWorkplan_UI.aspx');", true);

            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unit = int.Parse(ddlUnit.SelectedValue.ToString());

        }

        
    }
}
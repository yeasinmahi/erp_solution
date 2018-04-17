
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;

namespace UI.SAD.Corporate_sales
{
    public partial class Approved : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        OrderInput_BLL ReportOrder = new OrderInput_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["order"] = ordernumber1;
             int ids=int.Parse(hdnapp.Value);
             if (ids ==int.Parse("1"))
             {

                 ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('ApprovedDetails.aspx');", true);
             }
             else
             {
                 ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('ApprovedDetailsFinal.aspx');", true);
      
             }
            }
            catch { }
        }

        protected void rdbutton_CheckedChanged(object sender, EventArgs e)
        {
            dtReport = ReportOrder.getordderReport();
            dgvlist.DataSource = dtReport;
            dgvlist.DataBind();
            hdnapp.Value = "1";
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dtReport = ReportOrder.getordderReportapp();
            dgvlist.DataSource = dtReport;
            dgvlist.DataBind();
            hdnapp.Value = "2";

        }
    }
}
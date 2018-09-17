
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
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Corporate_sales
{
    public partial class Approved : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        OrderInput_BLL ReportOrder = new OrderInput_BLL();
        DataTable dt = new DataTable();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Corporate_sales\\Approved";
        string stop = "stopping SAD\\Corporate_sales\\Approved";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Corporate_sales\\Approved Approved ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
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
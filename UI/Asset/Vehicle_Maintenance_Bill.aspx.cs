using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.IO;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class Vehicle_Maintenance_Bill : BasePage
    {

        AssetMaintenance objBill = new AssetMaintenance();
        DataTable dt = new DataTable();
        int intItem;
        SeriLog log = new SeriLog();
        string location = "ASSET";
        string start = "starting ASSET\\Vehicle_Maintenance_Bill";
        string stop = "stopping ASSET\\Vehicle_Maintenance_Bill";
        string perform = "Performance on ASSET\\Vehicle_Maintenance_Bill";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!IsPostBack)
                {
                    int Mnumber = 0;
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    intItem = 60;
                    dt = objBill.ReportDetalisParts(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgview.DataSource = dt;
                    dgview.DataBind();

                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }
            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void BtnMDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnMDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "BtnMDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                
                Session["intMaintenanceNo"] = ordernumber1;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ReportDetalis('Vehicle_Bill_Detalis_PopUp.aspx');", true);

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "BtnMDetalis_Click", ex);
                Flogger.WriteError(efd);
            }
            fd = log.GetFlogDetail(stop, location, "BtnMDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }
    }
}
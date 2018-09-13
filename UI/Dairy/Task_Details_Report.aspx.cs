using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Dairy
{
    public partial class Task_Details_Report : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Task_Details_Report.aspx";
        string stop = "stopping Dairy/Task_Details_Report.aspx";

        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intWork; int intEnroll; string Unitid; int intSearchEnroll; string strReportType;
        int intID; int intCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Task_Details_Report.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();
                    
                    dt = new DataTable();
                    dt = objtask.GetCountDetailsByTask(intID);
                    if (dt.Rows.Count > 0)
                    { intCount = int.Parse(dt.Rows[0]["intCountDetails"].ToString()); }   
                    if(intCount == 0)
                    {
                        UpdateReportDiv.Visible = false;
                    }
                    else { UpdateReportDiv.Visible = true; }

                    LoadGrid();

                }
                catch { }
            }
            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Task_Details_Report.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                dt = new DataTable();
                dt = objtask.GetDetailsReport(intID);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();

                try
                {
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                    dt = new DataTable();
                    dt = objtask.GetWorkPlanReport(intID);
                    dgvWorkPlan.DataSource = dt;
                    dgvWorkPlan.DataBind();
                }
                catch { }
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

    
        protected void btnDocVew_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Task_Details_Report.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            string senderdata = ((Button)sender).CommandArgument.ToString();

            intID = int.Parse(senderdata.ToString());
            intCount = 0;

            dt = new DataTable();
            dt = objtask.GetDocCountByReffID(intID);
            if (dt.Rows.Count > 0)
            {
                intCount = int.Parse(dt.Rows[0]["intDocCount"].ToString());               
            }

            if (intCount > 0)
            {   
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocListView('" + senderdata + "');", true);
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There are no document attach in this task.');", true); return; }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvReport.Rows.Count; index++)
                    {
                        intID = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblDetailsID")).Text.ToString());

                        dt = new DataTable();
                        dt = objtask.GetDocCountByDetailsID(intID);

                        if (dt.Rows.Count > 0)
                        {
                            int intCount = int.Parse(dt.Rows[0]["DocCountByDetailsID"].ToString());

                            if (intCount == 0)
                            {
                                ((Button)dgvReport.Rows[index].FindControl("btnDocVew")).Visible = false;
                            }
                            else { ((Button)dgvReport.Rows[index].FindControl("btnDocVew")).Visible = true; }
                        }

                    }
                }
            }
            catch { }
        }

        //GetDocCountByDetailsID












    }
}
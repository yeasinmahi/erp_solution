using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ItemManager : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private DataTable dt = new DataTable();
        private int wh;
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IndentStatus";
        private string stop = "stopping SCM\\IndentStatus";
        private string perform = "Performance on SCM\\IndentStatus";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objIssue.GetViewData(1, "", wh, 0, DateTime.Now, Enroll);
                // dt = objIssue.GetWH();
                ddlWh.DataSource = dt;
                ddlWh.DataValueField = "Id";
                ddlWh.DataTextField = "strName";
                ddlWh.DataBind();
                wh = ddlWh.SelectedValue();
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
            var fd = log.GetFlogDetail(start, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnAdd_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string masteritem = ListDatas.SelectedValue.ToString();
                wh = int.Parse(ddlWh.SelectedValue);
                string xmlData = "<voucher><voucherentry masteritem=" + '"' + masteritem + '"' + "/></voucher>".ToString();
                int location = int.Parse(ddlLocation.SelectedValue);
                if (location > 0)
                {
                    string msg = objIssue.StoreIssue(13, xmlData, wh, location, DateTime.Now, Enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Sselect your location');", true); }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnAdd_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string strSearchKey = txtItem.Text.ToString();
                dt = objIssue.GetMasterItem(strSearchKey);
                ListDatas.DataSource = dt;
                ListDatas.DataValueField = "intItemMasterID";
                ListDatas.DataTextField = "strItemMasterName";
                ListDatas.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class CommonRepaisListPopUp :BasePage
    {
        AssetMaintenance objCommonRepairs = new AssetMaintenance();
        DataTable dt = new DataTable();
        DataTable asset = new DataTable();
        DataTable commonrep = new DataTable();
        int intItem;
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\CommonRepaisListPopUp";
        string stop = "stopping Asset\\CommonRepaisListPopUp";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
              
              
            }
        }

        private void LoadViewData()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CommonRepaisListPopUp Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int Mnumber = int.Parse("0".ToString());

                intItem = 11;

                commonrep = objCommonRepairs.RepairsCommonList(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvcommonrepairs.DataSource = commonrep;
                dgvcommonrepairs.DataBind();
                DdlServiceName.DataSource = commonrep;
                DdlServiceName.DataTextField = "strRepairs";
                DdlServiceName.DataValueField = "intID";
                DdlServiceName.DataBind();

                int repairsID = Int32.Parse(DdlServiceName.SelectedValue.ToString());
                dt = new DataTable();
                dt = objCommonRepairs.commonrepairsView(repairsID);
                if (dt.Rows.Count > 0)
                {
                    TxtCommonRepname.Text = dt.Rows[0]["strRepairs"].ToString();
                    TxtCommonReCharge.Text = dt.Rows[0]["monServiceCharge"].ToString();
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

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
            LoadViewData();
        }
        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            MainView.ActiveViewIndex = 1;
            LoadViewData();
        }

        protected void BtnIssue_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CommonRepaisListPopUp BtnIssue_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intdept= int.Parse(Session[SessionParams.DEPT_ID].ToString());
            string repairs = TxtRepairs.Text.ToString();
            decimal repairscost = decimal.Parse(TxtCommonRepSCost.Text.ToString());
            objCommonRepairs.CommonRepairsItemInsertGet(repairs,repairscost, intenroll, intjobid, intunitid, intdept);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Insert');", true);
          
            intItem = 11;


           int Mnumber = int.Parse("0".ToString());
           commonrep = objCommonRepairs.RepairsCommonList(intItem, Mnumber, intenroll, intjobid, intdept);
           dgvcommonrepairs.DataSource = commonrep;
           dgvcommonrepairs.DataBind();

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

        protected void DdlServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CommonRepaisListPopUp DdlServiceName_SelectedIndexChanged", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int repairsID = Int32.Parse(DdlServiceName.SelectedValue.ToString());
                dt = new DataTable();
                dt = objCommonRepairs.commonrepairsView(repairsID);
                if (dt.Rows.Count > 0)
                {
                    TxtCommonRepname.Text = dt.Rows[0]["strRepairs"].ToString();
                    TxtCommonReCharge.Text = dt.Rows[0]["monServiceCharge"].ToString();
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CommonRepaisListPopUp BtnUpdate_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int repairsID = Int32.Parse(DdlServiceName.SelectedValue.ToString());
                string repairsName = TxtCommonRepname.Text.ToString();
                decimal repairsCost = decimal.Parse(TxtCommonReCharge.Text.ToString());

                objCommonRepairs.UpdateCommonRepairsItem(repairsName, repairsCost, repairsID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);
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
    }
}
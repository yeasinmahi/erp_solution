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
    public partial class AssetCheckReceive : BasePage
    {
        AssetInOut objCheck = new AssetInOut();
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType, intActionBy; string assetCode, strNaration, stringXml;
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\AssetCheckReceive";
        string stop = "stopping Asset\\AssetCheckReceive";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept   = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid  = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                LoadData();
                
                pnlUpperControl.DataBind();
            }
        }

        private void LoadData()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckReceive Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intResEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                
                dt = objCheck.AssetCheckInOutDataTable(4, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                dgvGetpassRecieve.DataSource = dt;//receive View
                dgvGetpassRecieve.DataBind();

                dt = objCheck.AssetCheckInOutDataTable(5, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                dgvStatus.DataSource = dt;//asset Summery
                dgvStatus.DataBind();
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



        protected void Button1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckReceive Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int receiveID = int.Parse(searchKey[0].ToString());
                intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                string messages = objCheck.AssetCheckInOutAction(6, stringXml, receiveID, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messages + "');", true);
                LoadData();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
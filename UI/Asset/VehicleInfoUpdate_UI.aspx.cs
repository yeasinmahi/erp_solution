using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Data;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class VehicleInfoUpdate_UI :BasePage
    {
        Assetregister_BLL objregisterUpdate = new Assetregister_BLL();
        DataTable dt = new DataTable();
        int intItem ;


        SeriLog log = new SeriLog();
        string location = "ASSET";
        string start = "starting ASSET\\VehicleInfoUpdate_UI";
        string stop = "stopping ASSET\\VehicleInfoUpdate_UI";
        string perform = "Performance on ASSET\\VehicleInfoUpdate_UI";
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
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                    string assetcode = "0".ToString();
                    int Mnumber = int.Parse("1".ToString()); 
                    dt = new DataTable();

                    dt = objregisterUpdate.VehicleBillingUnitName();
                    DdlBillUnit.DataSource = dt;
                    DdlBillUnit.DataTextField = "strUnit";
                    DdlBillUnit.DataValueField = "intUnitID";
                    DdlBillUnit.DataBind();
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    int unitid = int.Parse(DdlBillUnit.SelectedValue.ToString());
                    dt = objregisterUpdate.VehicleBillingJobstation(unitid);
                    DdlJobstation.DataSource = dt;
                    DdlJobstation.DataTextField = "strJobStationName";
                    DdlJobstation.DataValueField = "intEmployeeJobStationId";
                    DdlJobstation.DataBind();

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

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 type = Int32.Parse(8.ToString());
            return objAutoSearch_BLL.GetAssetVehicle(type, prefixText);

        }

        protected void TxtAssetID_TextChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "TxtAssetID_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "TxtAssetID_TextChanged", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!String.IsNullOrEmpty(TxtAssetID.Text))
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = TxtAssetID.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    int intAssetId = int.Parse(temp1[2].ToString());

                    string strSearchKey = TxtAssetID.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    hdfEmpCode.Value = searchKey[1];

                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString()); 

                    int Mnumber = int.Parse("1".ToString());
                    string assetcode = hdfEmpCode.Value.ToString();

                    intItem = 7;
                    dt = objregisterUpdate.AssetVehicleView(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
                    if (dt.Rows.Count > 0)
                    {
                        TxtxtName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                        TxtxtDriverMobaile.Text = dt.Rows[0]["strVDriverMobaile"].ToString();
                        TxtDriverName.Text = dt.Rows[0]["strVDriverName"].ToString();
                        TxtUserName.Text = dt.Rows[0]["strVUserName"].ToString();
                        TxtEnroll.Text = dt.Rows[0]["IntVUserEnroll"].ToString();
                        TxtLocation.Text = dt.Rows[0]["strInstallationLocation"].ToString();
                        try { DdlBillUnit.SelectedItem.Text = dt.Rows[0]["unitname"].ToString(); }
                        catch { };

                        try { DdlBillUnit.SelectedValue = dt.Rows[0]["unitid"].ToString(); }
                        catch { };
                        try { DdlJobstation.SelectedItem.Text = dt.Rows[0]["strJobStationName"].ToString(); }
                        catch { };

                        try { DdlJobstation.SelectedValue = dt.Rows[0]["intEmployeeJobStationId"].ToString(); }
                        catch { };
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "TxtAssetID_TextChanged", ex);
                Flogger.WriteError(efd);
            }
            fd = log.GetFlogDetail(stop, location, "TxtAssetID_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnUpdate_Click", null);
                Flogger.WriteDiagnostic(fd);
                // starting performance tracker
                var tracker = new PerfTracker(perform + " " + "BtnUpdate_Click", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
            try
            {
                int userenroll;
                if (!String.IsNullOrEmpty(TxtAssetID.Text))
                {
                    string strSearchKey = TxtAssetID.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    hdfEmpCode.Value = searchKey[1];
                    string asetcode = hdfEmpCode.Value.ToString();
                    int billjobnid = int.Parse(DdlJobstation.SelectedValue.ToString());

                    int unitid = int.Parse(DdlBillUnit.SelectedValue.ToString());
                    string driverName = TxtDriverName.Text.ToString();
                    string driverMobaile = TxtxtDriverMobaile.Text.ToString();
                    string locations = TxtLocation.Text.ToString();
                    string username = TxtUserName.Text.ToString();
                    try { userenroll = int.Parse(TxtEnroll.Text.ToString()); }
                    catch { userenroll = int.Parse(TxtEnroll.Text.ToString()); }
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                    objregisterUpdate.VehicleRegisInformationUpdate(unitid, billjobnid, driverName, driverMobaile, locations, username, userenroll, intenroll, asetcode);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('SucessFully Update');", true);
                    TxtxtName.Text = "";
                    TxtxtDriverMobaile.Text = "";
                    TxtDriverName.Text = "";
                    TxtUserName.Text = "";
                    TxtEnroll.Text = "";
                    TxtLocation.Text = ""; TxtAssetID.Text = "";
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "BtnUpdate_Click", ex);
                Flogger.WriteError(efd);
            }
            fd = log.GetFlogDetail(stop, location, "BtnUpdate_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "DdlBillUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "DdlBillUnit_SelectedIndexChanged", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dt = new DataTable();
                int unitid = int.Parse(DdlBillUnit.SelectedValue.ToString());
                dt = objregisterUpdate.VehicleBillingJobstation(unitid);
                DdlJobstation.DataSource = dt;
                DdlJobstation.DataTextField = "strJobStationName";
                DdlJobstation.DataValueField = "intEmployeeJobStationId";
                DdlJobstation.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DdlBillUnit_SelectedIndexChanged", ex);
                Flogger.WriteError(efd);
            }
            fd = log.GetFlogDetail(stop, location, "DdlBillUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }
    }
}
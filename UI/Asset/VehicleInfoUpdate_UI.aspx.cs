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


namespace UI.Asset
{
    public partial class VehicleInfoUpdate_UI :BasePage
    {
        Assetregister_BLL objregisterUpdate = new Assetregister_BLL();
        DataTable dt = new DataTable();
        int intItem ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("1".ToString());

               
                dt = new DataTable();
               
                dt = objregisterUpdate.VehicleBillingUnitName();
                DdlBillUnit.DataSource = dt;
                DdlBillUnit.DataTextField = "strUnit";
                DdlBillUnit.DataValueField = "intUnitID";
                DdlBillUnit.DataBind();
                pnlUpperControl.DataBind();

                dt = new DataTable();
                Int32 unitid = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
                dt = objregisterUpdate.VehicleBillingJobstation(unitid);
                DdlJobstation.DataSource = dt;
                DdlJobstation.DataTextField = "strJobStationName";
                DdlJobstation.DataValueField = "intEmployeeJobStationId";
                DdlJobstation.DataBind();

            }
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
            if (!String.IsNullOrEmpty(TxtAssetID.Text))
            {
                string strSearchKey = TxtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];

                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
               


                Int32 Mnumber = Int32.Parse("1".ToString());
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Int32 userenroll;
             if (!String.IsNullOrEmpty(TxtAssetID.Text))
            {
                string strSearchKey = TxtAssetID.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];
                 string asetcode=hdfEmpCode.Value.ToString();
                 Int32 billjobnid = Int32.Parse(DdlJobstation.SelectedValue.ToString());

            Int32 unitid = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
            string driverName = TxtDriverName.Text.ToString();
            string driverMobaile = TxtxtDriverMobaile.Text.ToString();
            string locations = TxtLocation.Text.ToString();
            string username = TxtUserName.Text.ToString();
            try { userenroll = Int32.Parse(TxtEnroll.Text.ToString()); }
            catch {  userenroll = Int32.Parse(TxtEnroll.Text.ToString()); }
             Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

             objregisterUpdate.VehicleRegisInformationUpdate(unitid,billjobnid, driverName, driverMobaile, locations, username, userenroll, intenroll, asetcode);
             ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('SucessFully Update');", true);
             TxtxtName.Text = "";
             TxtxtDriverMobaile.Text = "";
             TxtDriverName.Text = "";
             TxtUserName.Text = "";
             TxtEnroll.Text = "";
             TxtLocation.Text = ""; TxtAssetID.Text = "";


           }
        }

        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 unitid = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
            dt = objregisterUpdate.VehicleBillingJobstation(unitid);
            DdlJobstation.DataSource = dt;
            DdlJobstation.DataTextField = "strJobStationName";
            DdlJobstation.DataValueField = "intEmployeeJobStationId";
            DdlJobstation.DataBind();
        }
    }
}
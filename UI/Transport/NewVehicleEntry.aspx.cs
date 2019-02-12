using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using SAD_BLL.Global;
using UI.ClassFiles;
using SAD_BLL.Transport;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;

namespace UI.Transport
{
    public partial class NewVehicleEntry : BasePage
    {
        HR_BLL.Global.Unit objunit = new HR_BLL.Global.Unit();
        SetupBLL objsetup = new SetupBLL();
        DataTable dt; int id; 
        string Vno,DriverName,DriverNid,DriverContact,HelperName, LisenceNo, msg;
        int Unitid,enroll,Vid,helperenroll, UOMid, Locationid, Typeid,intCOAID,driverenroll;
        int? intCOAIDs;
        decimal DriverDA,diselperkm, HelperDA, DownTripAllowance, DownTripDA, MillageAllowance100KM, MillageAllowance100KMAbove, MillageLocal,
        MillageOutstation, CNGAllowance, DiselPerKmOutstation, DiselPerKMLocal, DiselPerKMLitter, DownTripDiselPerKM, CNGPerKM,
        LoadingCapacity, CNGPerKMOutstation;
        NewVehicleBLL objVehicle = new NewVehicleBLL();
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objunit.GetUnits("1355");
                ddlunit.DataTextField = "strunit";
                ddlunit.DataValueField = "intUnitID";
                ddlunit.DataSource = dt;
                ddlunit.DataBind();
                txtVehicleNo.Text = "0";
                txtDriverName.Text = "0";
                txtDriverContact.Text = "0";
                txtDriverNId.Text = "0";
                txthelperName.Text = "0";
                txtLisence.Text = "0";
                txtDriverDA.Text = "0";
                txtHelperdA.Text = "0";
                txtDowntripAllowance.Text = "0";
                txtDownTripDA.Text = "0";
                MA100KM.Text = "0";
                txtMillageAllowance100KMAbove.Text = "0";
                txtMillageLocal.Text = "0";
                txtOutstation.Text = "0";
                txtCNGAllowance.Text = "0";
                txtDieselPerKMOutsation.Text = "0";
                txtDiselPerKMLocal.Text = "0";
                txtDiselPerKMLitter.Text = "0";
                txtDownTripDiselPerKM.Text = "0";
                txtCNGPerKM.Text = "0";
                txtLoadingcapacity.Text = "0";
                txtCNGPerKMOustStation.Text = "0";
                txtDiselPerKM.Text = "0";

                GetVehcileType();
                GetLocation();
                
            }
        }
        private void GetLocation()
        {
            
            try
            {
                dt = objVehicle.getLocation(ddlunit.SelectedValue.ToString());
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataValueField = "intid";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();

            }
            catch { }
        }
        private void GetVehcileType()
        {
            try
            {
                dt = objVehicle.getVehicletype(ddlunit.SelectedValue.ToString());
                ddlType.DataTextField = "strType";
                ddlType.DataValueField = "intTypeId";
                ddlType.DataSource = dt;
                ddlType.DataBind();

            }
            catch { }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
        private void GetBind(bool active, string type)
        {
            if(active==true)
            {
              //  objVehicle.getVehicle(txtVehicleNo.Text);
               

            }
            else if ((active == false)&&(type=="R"))
            {

               


            }
            else if ((active == false) && (type == "A"))
            {
              
            }
        }
    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                Unitid = int.Parse(ddlunit.SelectedValue.ToString());
                UOMid= int.Parse(ddlUOM.SelectedValue.ToString());
                Locationid = int.Parse(ddlLocation.SelectedValue.ToString());
                Vno = txtVehicleNo.Text;
                char[] delimiterCharss = { '[', ']' };
                if (txtDriverName.Text == "0")
                {
                    driverenroll = 0;
                    DriverName = "";
                }
                else
                {
                    arrayKeyItem = txtDriverName.Text.Split(delimiterCharss);
                    driverenroll = int.Parse((arrayKeyItem[1].ToString()));
                    DriverName = (arrayKeyItem[0].ToString());
                }
                DriverContact = txtDriverContact.Text;
                DriverNid = txtDriverNId.Text;
                if(txthelperName.Text=="0")
                {
                    helperenroll = 0;
                    HelperName = "";
                }
                else
                {
                    try
                    {
                        arrayKeyItem = txthelperName.Text.Split(delimiterCharss);
                        helperenroll = int.Parse((arrayKeyItem[1].ToString()));
                        HelperName = (arrayKeyItem[0].ToString());
                    }
                    catch { }
                } 
                
                LisenceNo = txtLisence.Text;
                DriverDA =decimal.Parse(txtDriverDA.Text);
                HelperDA = decimal.Parse(txtHelperdA.Text);
                DownTripAllowance = decimal.Parse(txtDowntripAllowance.Text);
                DownTripDA = decimal.Parse(txtDownTripDA.Text);
                MillageAllowance100KM = decimal.Parse(MA100KM.Text);
                MillageAllowance100KMAbove = decimal.Parse(txtMillageAllowance100KMAbove.Text);
                MillageLocal = decimal.Parse(txtMillageLocal.Text);
                MillageOutstation = decimal.Parse(txtOutstation.Text);
                CNGAllowance = decimal.Parse(txtCNGAllowance.Text);
                DiselPerKmOutstation = decimal.Parse(txtDieselPerKMOutsation.Text);
                DiselPerKMLocal = decimal.Parse(txtDiselPerKMLocal.Text);
                UOMid =int.Parse(ddlUOM.SelectedValue.ToString()); 
                DiselPerKMLitter = int.Parse(txtDiselPerKMLitter.Text);
                DownTripDiselPerKM = int.Parse(txtDownTripDiselPerKM.Text); 
                CNGPerKM = int.Parse(txtCNGPerKM.Text); 
                LoadingCapacity = int.Parse(txtLoadingcapacity.Text);
                CNGPerKMOutstation = int.Parse(txtCNGPerKMOustStation.Text);
                intCOAID = 0;
                diselperkm = decimal.Parse(txtDiselPerKM.Text);
                objVehicle.getVehcilEntry(Vno,Unitid,Typeid,intCOAID,Locationid,DriverName,DriverContact,DriverNid,HelperName,LoadingCapacity,UOMid,LisenceNo, driverenroll,DriverDA, helperenroll, HelperDA, diselperkm,DiselPerKMLitter,DownTripDiselPerKM,CNGPerKM,DownTripDA,CNGAllowance,MillageAllowance100KM,MillageAllowance100KMAbove,MillageLocal,MillageOutstation,DiselPerKmOutstation,CNGPerKMOutstation);

                if (Unitid == 4)
                {
                    dt = objVehicle.getAutoid();
                    Vid = int.Parse(dt.Rows[0]["intid"].ToString());
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    objVehicle.getVehcilCOA(Vno, 33881, true, false, false, false, false, enroll, 0, Vid, Unitid, 0, Vid, null, 0, ref intCOAIDs);
                    intCOAID = int.Parse(intCOAIDs.ToString());
                    objVehicle.getupdate(intCOAID, Vid);
                }


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save !');", true);
                txtDriverName.Text = "";
                txtVehicleNo.Text = "";
                txtDriverContact.Text="";
                txtDriverNId.Text = "";
                txthelperName.Text = "";
                txtLisence.Text = "";
                txtDriverDA.Text = "";
                txtHelperdA.Text = "";
                txtDowntripAllowance.Text = "";
                txtDownTripDA.Text = "";
                MA100KM.Text = "";
                txtMillageAllowance100KMAbove.Text = "";
                txtMillageLocal.Text = "";
                txtOutstation.Text = "";
                txtCNGAllowance.Text = "";
                txtDieselPerKMOutsation.Text = "";
                txtDiselPerKMLocal.Text = "";
                txtDiselPerKMLitter.Text = "";
                txtDownTripDiselPerKM.Text = "";
                txtCNGPerKM.Text = "";
                txtLoadingcapacity.Text = "";
                txtCNGPerKMOustStation.Text = "";
                txtDiselPerKM.Text = "";
            }
        }
    }
}
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

namespace UI.Asset
{
    public partial class AssertReport : BasePage
    {
        AssetMaintenance objPMConfigure = new AssetMaintenance();
        DataTable dt = new DataTable(); 
        int intItem;
        int Mnumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                Mnumber = 0;               
            
                dt = objPMConfigure.JobstationDropdoownlist(40, Mnumber, intenroll, intjobid, intdept);
                DdlJostation.DataSource = dt;
                DdlJostation.DataTextField = "strJobStationName";
                DdlJostation.DataValueField = "intEmployeeJobStationId";
                DdlJostation.DataBind();
               
                dt = objPMConfigure.JobstationDepartment(41, Mnumber, intenroll, intjobid, intdept);
                DdlDept.DataSource = dt;
                DdlDept.DataTextField = "strDepatrment";
                DdlDept.DataValueField = "intDepartmentID";
                DdlDept.DataBind();
               
          
                dt = objPMConfigure.ReportpageAssetTypeName(56, Mnumber, intenroll, intjobid, intdept);
                DdlAssetClas.DataSource = dt;
                DdlAssetClas.DataTextField = "strAssetTypeName";
                DdlAssetClas.DataValueField = "intAssetTypeID";
                DdlAssetClas.DataBind();

                DdlAssetClas.Items.Insert(0, new ListItem("All", "0"));
                pnlUpperControl.DataBind();
            }
           
        }


        

        
        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            dt = new DataTable();
            string number = TxtAsset.Text.ToString();
            dt = objPMConfigure.showassetData(number);
            if (dt.Rows.Count > 0)
            {
                TxtName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                
            }
             
        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
           
        }

        

        protected void DdlJostation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intjobid = int.Parse(DdlJostation.SelectedValue.ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());  
              
                dt = objPMConfigure.JobstationDepartment(41, Mnumber, intenroll, intjobid, intdept);
                DdlDept.DataSource = dt;
                DdlDept.DataTextField = "strDepatrment";
                DdlDept.DataValueField = "intDepartmentID";
                DdlDept.DataBind();
            }
            catch { }
           
        }

        protected void BtnMDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                //Int32 items = Int32.Parse(DdlSchedule.SelectedValue.ToString());

                // Response.Write(ordernumber); 
                //Session["intMaintenanceNo"] = ordernumber1;
                Session["intMaintenanceNo"] = ordernumber1;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ReportDetalis('AssetReportDetalis_UI.aspx');", true);

            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dtefrom, dteto;
               
                int intjobid = int.Parse(DdlJostation.SelectedValue.ToString()); 
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                try
                {
                    dteto = DateTime.Parse(TxtdteTo.Text.ToString());
                    dtefrom = DateTime.Parse(TxtdteFrom.Text.ToString());
                }
                catch { dteto = DateTime.Parse("2016 - 01 - 01".ToString()); dtefrom = DateTime.Parse("2016 - 01 - 01".ToString()); }

                int intdept = int.Parse(DdlDept.SelectedValue.ToString());

                try
                {
                    Mnumber = Int32.Parse(TxtAsset.Text.ToString());
                }
                catch { Mnumber = 0; }


                if (TxtAsset.Text == "")
                {
                    if (DdlType.Text == "Maintenance")
                    {
                        dgvCorrectiveService.Visible = false;
                        dgvPMService.Visible = false;
                        dgvUserRequest.Visible = false;
                        dgview.Visible = true;
                        dgvAssetregister.Visible = false;
                        dgvVehicleRegister.Visible = false;
                        dgvJobcard.Visible = false;
                        DgvlandDevlopment.Visible = false;

                        dt = objPMConfigure.DatewaiseReport(dtefrom, dteto, intjobid);
                        dgview.DataSource = dt;
                        dgview.DataBind();
                    }
                }

                else
                {
                    if (DdlType.Text == "Maintenance")
                    {
                        string number = TxtAsset.Text.ToString();

                        dt = new DataTable();
                        dt = objPMConfigure.ReportData(number);
                        dgview.DataSource = dt;
                        dgview.DataBind();
                    }
                }
                if (DdlType.Text == "PM Service")
                {


                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = true;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    dt = new DataTable();
                    dt = objPMConfigure.PmDateReportShow(intjobid, intdept, dtefrom, dteto);
                    dgvPMService.DataSource = dt;
                    dgvPMService.DataBind();
                }
                if (DdlType.Text == "Corrective Service")
                {

                    dgvCorrectiveService.Visible = true;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    intItem = 22;
                    dt = new DataTable();
                    dt = objPMConfigure.RepairservicerequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvCorrectiveService.DataSource = dt;
                    dgvCorrectiveService.DataBind();
                }

                if (DdlType.Text == "User Request Service")
                {
                    dt = new DataTable();
                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = true;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    intItem = 37;
                    dt = objPMConfigure.UserRequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvUserRequest.DataSource = dt;
                    dgvUserRequest.DataBind();
                }
                if (DdlType.Text == "Asset Register")
                {
                    try
                    {
                        Mnumber = Int32.Parse(DdlAssetClas.SelectedValue.ToString());
                    }
                    catch { Mnumber = 0; }

                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = true;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    intItem = 42;
                    dt = new DataTable();
                    dt = objPMConfigure.Assetregistervreport(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvAssetregister.DataSource = dt;
                    dgvAssetregister.DataBind();
                    if (DdlAssetClas.SelectedItem.Text == "All")
                    {
                        intItem = 57;
                        dt = new DataTable();
                        dt = objPMConfigure.AssetregisterAllReportt(intItem, Mnumber, intenroll, intjobid, intdept);
                        dgvAssetregister.DataSource = dt;
                        dgvAssetregister.DataBind();
                    }
                }
                if (DdlType.Text == "Workorder")
                {
                    dt = new DataTable();
                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = true;
                    DgvlandDevlopment.Visible = false;
                    intItem = 43;
                    dt = objPMConfigure.JobcardInformation(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvJobcard.DataSource = dt;
                    dgvJobcard.DataBind();

                }
                if (DdlType.Text == "User Request Service")
                {

                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = true;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    intItem = 37;
                    dt = objPMConfigure.UserRequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvUserRequest.DataSource = dt;
                    dgvUserRequest.DataBind();
                }
                if (DdlType.Text == "Vehicle Register")
                {

                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = true;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = false;
                    intItem = 44;
                    dt = objPMConfigure.VehicleTegistrationView(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvVehicleRegister.DataSource = dt;
                    dgvVehicleRegister.DataBind();

                }
                if (DdlType.Text == "Land")
                {
                    dt = new DataTable();
                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    dgvLand.Visible = true;
                    DgvlandDevlopment.Visible = false;


                    intItem = 45;
                    dt = objPMConfigure.LandRegisterReport(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvLand.DataSource = dt;
                    dgvLand.DataBind();
                }
                if (DdlType.Text == "Land Devlopment")
                {
                    dgvCorrectiveService.Visible = false;
                    dgvPMService.Visible = false;
                    dgvUserRequest.Visible = false;
                    dgview.Visible = false;
                    dgvAssetregister.Visible = false;
                    dgvVehicleRegister.Visible = false;
                    dgvJobcard.Visible = false;
                    DgvlandDevlopment.Visible = true;
                    dgvLand.Visible = false;

                   
                    intItem = 46;
                    dt = objPMConfigure.landDevlopmentReport(intItem, Mnumber, intenroll, intjobid, intdept);
                    DgvlandDevlopment.DataSource = dt;
                    DgvlandDevlopment.DataBind();
                }
            }
            catch { }
        }
    }
}
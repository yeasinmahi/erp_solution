using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Purchase_BLL.Asset;
using UI.ClassFiles;
namespace UI.Asset
{
    public partial class AssetRegisterUpdate : BasePage
    {
        Assetregister_BLL objregisterUpdate = new Assetregister_BLL();
      
        DataTable dt = new DataTable();
        DataTable et = new DataTable();

        int intItem; int intpart;
        //DateTime dtelc, dtepo, WarrintyPreoid, dteacusition, DteTaxToken, dtefitness, dteInsurance, RootPermit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Button3.Visible = false;
                Button2.Visible = false; 
               
                pnlUpperControl.DataBind();
                
            }

               
          

           
        }

        private void loadTab3LandReg()
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("1".ToString());
            dt = new DataTable();
            dt = objregisterUpdate.LandType();

            DdlAssetLand.DataSource = dt;
            DdlAssetLand.DataTextField = "strAssetTypeName";
            DdlAssetLand.DataValueField = "intAssetTypeID";
            DdlAssetLand.DataBind();
            dt = new DataTable();

            dt = objregisterUpdate.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlUnitLand.DataSource = dt;
            DdlUnitLand.DataTextField = "strUnit";
            DdlUnitLand.DataValueField = "intUnitID";
            DdlUnitLand.DataBind();

            Int32 unitid = Int32.Parse(DdlUnitLand.SelectedValue.ToString());
            dt = new DataTable();

            dt = objregisterUpdate.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlJobland.DataSource = dt;
            DdlJobland.DataTextField = "strJobStationName";
            DdlJobland.DataValueField = "intEmployeeJobStationId";
            DdlJobland.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.Districviewdropdown();
            Ddldistrict.DataSource = dt;
            Ddldistrict.DataTextField = "strDistrictBanglaName";
            Ddldistrict.DataValueField = "intDistrictIDs";
            Ddldistrict.DataBind();
            dt = new DataTable();
            Int32 districtss = Int32.Parse(Ddldistrict.SelectedValue.ToString());
            dt = objregisterUpdate.Thanadrodownview(districtss);
            DDlThana.DataSource = dt;
            DDlThana.DataTextField = "strDistrictBanglaName";
            DDlThana.DataValueField = "intDistrictIDs";
            DDlThana.DataBind();

        }

        private void loadTab4BuildingReg()
        {
            dt = new DataTable();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("1".ToString());

            dt = objregisterUpdate.BuildingType();
            DdlBuildAssetType.DataSource = dt;
            DdlBuildAssetType.DataTextField = "strAssetTypeName";
            DdlBuildAssetType.DataValueField = "intAssetTypeID";
            DdlBuildAssetType.DataBind();
            dt = new DataTable();

            dt = objregisterUpdate.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlBuildUnit.DataSource = dt;
            DdlBuildUnit.DataTextField = "strUnit";
            DdlBuildUnit.DataValueField = "intUnitID";
            DdlBuildUnit.DataBind();

            dt = new DataTable();
            Int32 unitid = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());

            dt = objregisterUpdate.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlbuildJobstation.DataSource = dt;
            DdlbuildJobstation.DataTextField = "strJobStationName";
            DdlbuildJobstation.DataValueField = "intEmployeeJobStationId";
            DdlbuildJobstation.DataBind();

            dt = new DataTable();
            //**Building--- Category Fixed make id 999999 ****//
            Int32 buildcategorys = Int32.Parse("999999".ToString());
            dt = objregisterUpdate.BuildingCataegoryList(buildcategorys);
            DdlBAssetCategory.DataSource = dt;
            DdlBAssetCategory.DataTextField = "strCategoryName";
            DdlBAssetCategory.DataValueField = "intCategoryID";
            DdlBAssetCategory.DataBind();


        }

        private void loadTab2VehicleReg()
        {
            dt = new DataTable();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = int.Parse("1".ToString());

            dt = objregisterUpdate.MotorVehicleTypes();
            DdlAsetTypes.DataSource = dt;
            DdlAsetTypes.DataTextField = "strAssetTypeName";
            DdlAsetTypes.DataValueField = "intAssetTypeID";
            DdlAsetTypes.DataBind();
           
            dt = new DataTable();
            dt = objregisterUpdate.VehicleBrand();
            DdlBrand.DataSource = dt;
            DdlBrand.DataTextField = "name";
            DdlBrand.DataValueField = "id";
            DdlBrand.DataBind();

            int VehicleCat = int.Parse(999998.ToString());
            dt = objregisterUpdate.DropdownCategoryView(VehicleCat);
            DdlAssetCate.DataSource = dt;
            DdlAssetCate.DataTextField = "strCategoryName";
            DdlAssetCate.DataValueField = "intCategoryID";
            DdlAssetCate.DataBind();

            dt = new DataTable();
            dt = objregisterUpdate.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode); ;
            ddlUnits.DataSource = dt;
            ddlUnits.DataTextField = "strUnit";
            ddlUnits.DataValueField = "intUnitID";
            ddlUnits.DataBind();

            dt = new DataTable();
            Mnumber = int.Parse(ddlUnits.SelectedValue.ToString());

            dt = objregisterUpdate.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            Ddljob.DataSource = dt;
            Ddljob.DataTextField = "strJobStationName";
            Ddljob.DataValueField = "intEmployeeJobStationId";
            Ddljob.DataBind();
          
           

           
        }

        private void loadTab1FactoryReg()
        {
            dt = new DataTable();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("1".ToString());
            dt = objregisterUpdate.AssetTypeName();
            DdlAssetType.DataSource = dt;
            DdlAssetType.DataTextField = "strAssetTypeName";
            DdlAssetType.DataValueField = "intAssetTypeID";
            DdlAssetType.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode); ;
            DdlUnit.DataSource = dt;
            DdlUnit.DataTextField = "strUnit";
            DdlUnit.DataValueField = "intUnitID";
            DdlUnit.DataBind();
            Int32 intUnitID = Int32.Parse(DdlUnit.SelectedValue.ToString());
            //dt = objregisterUpdate.RegCostCenter(intUnitID);
            //DdlCostCenterF.DataSource = dt;
            //DdlCostCenterF.DataTextField = "Name";
            //DdlCostCenterF.DataValueField = "Id";
            //DdlCostCenterF.DataBind();

            dt = new DataTable();
            Mnumber = Int32.Parse(DdlUnit.SelectedValue.ToString());

            dt = objregisterUpdate.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DlJobStation.DataSource = dt;
            DlJobStation.DataTextField = "strJobStationName";
            DlJobStation.DataValueField = "intEmployeeJobStationId";
            DlJobStation.DataBind();
           
            int jobstation = int.Parse(DlJobStation.SelectedValue.ToString());
            //dt = objregisterUpdate.DropdownCategoryView(jobstation);
            //DdlCategory.DataSource = dt;
            //DdlCategory.DataTextField = "strCategoryName";
            //DdlCategory.DataValueField = "intCategoryID";
            //DdlCategory.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();

            //DdlMainType.Items.Insert(0, new ListItem("Administrative", "0"));
            //DdlMainType.Items.Insert(1, new ListItem("Manufacturing", "1"));
            //dt = new DataTable();
            //dt = objregisterUpdate.PlantName(intUnitID);
            //DdlPlantF.DataSource = dt;
            //DdlPlantF.DataTextField = "Name";
            //DdlPlantF.DataValueField = "Id";
            //DdlPlantF.DataBind();



        }

        protected void Tab1_Click(object sender, EventArgs e)
        {

            dt = new DataTable();
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("1".ToString());
            intItem = 47;
            dt = objregisterUpdate.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {
               
                    
                    Tab1.CssClass = "Clicked";
                    Tab2.CssClass = "Initial";
                    Tab3.CssClass = "Initial";
                    Tab4.CssClass = "Initial";
                    MainView.ActiveViewIndex = 0;

                loadTab1FactoryReg();



            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }

        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("2".ToString());
            intItem = 47;
            dt = objregisterUpdate.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {

                
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 1;
                TxtVehicleCode.Text = "";
                loadTab2VehicleReg();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }



        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("3".ToString());
            intItem = 47;
            dt = new DataTable();
            dt = objregisterUpdate.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {
               
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 2;
                loadTab3LandReg();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }

        }
        protected void Tab4_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse("4".ToString());
            intItem = 47;
            dt = objregisterUpdate.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {
              
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Clicked";
                MainView.ActiveViewIndex = 3;
                loadTab4BuildingReg();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            


        }

        protected void TxtAssetCode_TextChanged(object sender, EventArgs e)
        {
            int intjobid;
             intjobid = int.Parse(DlJobStation.SelectedValue.ToString());
            //Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            //Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
       
            int Mnumber = int.Parse("1".ToString());
            string assetcode = TxtAssetCode.Text.ToString();
            
            dt = objregisterUpdate.assetDataView(assetcode,intjobid);
            

            if (dt.Rows.Count > 0)
            {

                try { DdlUnit.SelectedItem.Text = dt.Rows[0]["strUnit"].ToString(); }
                catch { };
                try { DdlUnit.SelectedValue = dt.Rows[0]["intUnitID"].ToString(); }
                catch { }
                try { DlJobStation.SelectedItem.Text = dt.Rows[0]["strJobStationName"].ToString(); }
                catch { };
                try { DlJobStation.SelectedValue = dt.Rows[0]["intEmployeeJobStationId"].ToString(); }
                catch { };
               
                try
                {
                    DataTable ct = new DataTable();
                    int intUnitID = int.Parse(DdlUnit.SelectedValue.ToString());
                    ct = objregisterUpdate.RegCostCenter(intUnitID);
                    DdlCostCenterF.DataSource = ct;
                    DdlCostCenterF.DataTextField = "Name";
                    DdlCostCenterF.DataValueField = "Id";
                    DdlCostCenterF.DataBind();
                   
                    et = new DataTable();
                    et = objregisterUpdate.PlantName(intUnitID);
                    DdlPlantF.DataSource = et;
                    DdlPlantF.DataTextField = "Name";
                    DdlPlantF.DataValueField = "Id";
                    DdlPlantF.DataBind();
                    DdlPlantF.Items.Insert(0, new ListItem("None", "0"));
                    et = new DataTable();
                    int jobstation = int.Parse(DlJobStation.SelectedValue.ToString());
                    et = objregisterUpdate.DropdownCategoryView(jobstation);
                    DdlCategory.DataSource = et;
                    DdlCategory.DataTextField = "strCategoryName";
                    DdlCategory.DataValueField = "intCategoryID";
                    DdlCategory.DataBind();
                    DataTable  dpt = new DataTable();
                    dpt = objregisterUpdate.DepertmentName(int.Parse(DlJobStation.SelectedValue));
                    DdlDept.DataSource = dt;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();
                    dpt.Clear();


                }
                catch { };


            try { TxtAssetName.Text = dt.Rows[0]["strNameOfAsset"].ToString(); }
            catch { };

            try { DdlAssetType.SelectedItem.Text = dt.Rows[0]["strAssetTypeName"].ToString(); }
            catch { };
            try { DdlDept.SelectedItem.Text = dt.Rows[0]["strDepatrment"].ToString(); DdlDept.SelectedValue = dt.Rows[0]["intDepartmentID"].ToString(); } catch { }
                

            try { DdlAssetType.SelectedValue = dt.Rows[0]["intAssetTypeID"].ToString(); }
            catch { };


                
            try { TxtHSCode.Text = dt.Rows[0]["strHSCode"].ToString(); } catch { }
            try { TxtManufacturer.Text = dt.Rows[0]["strNameManufacturer"].ToString(); } catch { }
            try { TxtAssetDescription.Text = dt.Rows[0]["strDescriptionAsset"].ToString(); } catch { }
            //TxtManufacturer.Text=dt.Rows[0]["strNameOfAsset"].ToString();
            try { TxtContryOrigin.Text = dt.Rows[0]["strCountryOrigin"].ToString(); } catch { }
            try { TxtCountryManufacture.Text = dt.Rows[0]["strCountryManufacturing"].ToString(); } catch { }
            try { TxtSuppName.Text = dt.Rows[0]["strSupplierName"].ToString(); } catch { }
                
            try { DdlCategory.SelectedItem.Text = dt.Rows[0]["strCategoryName"].ToString(); } catch { }
               
            try { DdlCategory.SelectedValue = dt.Rows[0]["intCategoryID"].ToString(); }  catch { } 
              
               
            try { TxtLCNo.Text = dt.Rows[0]["strLCNo"].ToString(); } catch { }
            try { TxtDteLC.Text = dt.Rows[0]["dteLCDate"].ToString(); } catch { }
            try { TxtPONo.Text = dt.Rows[0]["strPoNo"].ToString(); } catch { }
            try { TxtDtePo.Text = dt.Rows[0]["dtePoNo"].ToString(); } catch { }
            try { TxtDteWarranty.Text = dt.Rows[0]["dteWarranteePeriod"].ToString(); } catch { }
            try{TxtInvoice.Text = dt.Rows[0]["monInvoiceValue"].ToString(); } catch { }
            try { DdlInCoterms.Text = dt.Rows[0]["strIncoterms"].ToString(); } catch { }
            try{ TxtInsLocation.Text = dt.Rows[0]["strInstallationLocation"].ToString(); } catch { }
            try{TxtManuProvideSl.Text = dt.Rows[0]["strManufacProvideSL"].ToString(); } catch { }
            try { TxtFunction.Text = dt.Rows[0]["strFunctionoftheAsset"].ToString(); } catch { }
            try { TxtCapacity.Text = dt.Rows[0]["strCapacityoftheAsset"].ToString(); } catch { }
            try { TxtDteInstalation.Text = dt.Rows[0]["dteInstallation"].ToString(); } catch { }
            try { TxtErectionCost.Text = dt.Rows[0]["monErectionInstallCost"].ToString(); } catch { }

            try{ TxtDteAcusition.Text = dt.Rows[0]["dtrAcusition"].ToString(); } catch { }
            try{  TxtRecomandLife.Text = dt.Rows[0]["strRecommanLife"].ToString(); } catch { }
            try { TxtEstSalvageValue.Text = dt.Rows[0]["monEstSolvageValue"].ToString(); } catch { }
            try { TxtLandedCost.Text = dt.Rows[0]["monLandedCost"].ToString(); } catch { }
            try { TxtTAccumulatedCost.Text = dt.Rows[0]["monTAccumulatedCost"].ToString(); } catch { }
            try{ TxtRateDepeciation.Text = dt.Rows[0]["monRateOfDepeciation"].ToString();} catch { }
            try{  TxtAccumulatedDepreciation.Text = dt.Rows[0]["monAccumulatedDepeciation"].ToString();} catch { }
            try { TxtMethodDepreciation.Text = dt.Rows[0]["strMethodDepeciation"].ToString(); } catch { }
            try { TxtValueDepreciation.Text = dt.Rows[0]["monValueAfterDepeciation"].ToString(); } catch { }
            try { TxtWrittenDownValue.Text = dt.Rows[0]["monWritDownValue"].ToString(); } catch { }
            try{ TxtRemarks.Text = dt.Rows[0]["strRemarks"].ToString();} catch { }
            try { DdlCurrency.Text = dt.Rows[0]["strCurrency"].ToString(); }catch { }
            try { DdlDesiable.SelectedItem.Text = dt.Rows[0]["activestatus"].ToString(); } catch { } 
            try { DdlCostCenterF.SelectedValue = dt.Rows[0]["intCostCenterID"].ToString(); }catch   {  }
            try { DdlPlantF.SelectedValue = dt.Rows[0]["PlantID"].ToString(); } catch { }; 
                
            try { DdlCostCenterF.SelectedItem.Text = dt.Rows[0]["strCCName"].ToString(); } catch{ }
            try { DdlPlantF.SelectedItem.Text = dt.Rows[0]["strPlantName"].ToString(); } catch { } 
            try { DdlMainType.SelectedItem.Text = dt.Rows[0]["strAssetMainType"].ToString(); }  catch{} 
                
            try { TxtFModel.Text = dt.Rows[0]["strVModel"].ToString(); }  catch { }


                dt.Clear();et.Clear();

            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found ');", true);

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            DateTime dtelc; DateTime dtepo; DateTime dteacusition;
            DateTime WarrintyPreoid;
            int Costcenterid; int Plantname; int category;

            string assetcode = TxtAssetCode.Text.ToString();
            Int32 intenrollid = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            //Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intdept = Int32.Parse(Session[SessionParams.DEPT_ID].ToString());

            Int32 unit = Int32.Parse(DdlUnit.SelectedValue.ToString());
            Int32 intjobid = Int32.Parse(DlJobStation.SelectedValue.ToString());

            Int32 assettype = Int32.Parse(DdlAssetType.Text.ToString());
            String assetname = TxtAssetName.Text.ToString(); 
            string assetid = (DdlDept.Text.ToString());
            string hscode = (TxtHSCode.Text.ToString());
            String description = TxtAssetDescription.Text.ToString();
            String manufacture = TxtManufacturer.Text.ToString();
            String countryorigin = TxtContryOrigin.Text.ToString();
            string countrymanufacture = TxtCountryManufacture.Text.ToString();
            String supplier = TxtSuppName.Text.ToString();
            try {  category = Int32.Parse(DdlCategory.SelectedValue.ToString()); }
            catch {  category = Int32.Parse(0.ToString()); }

            String lcno = TxtLCNo.Text.ToString();
            try { dtelc = DateTime.Parse(TxtDteLC.Text); }
            catch { dtelc=DateTime.Parse("1990-01-01".ToString());}
            String pono = TxtPONo.Text.ToString();
            try { dtepo = DateTime.Parse(TxtDtePo.Text); }
            catch { dtepo = DateTime.Parse("1990-01-01".ToString()); }

            try { WarrintyPreoid = DateTime.Parse(TxtDteWarranty.Text); }
            catch { WarrintyPreoid = DateTime.Parse("1990-01-01".ToString());}

            Decimal invoicevalue = Decimal.Parse(TxtInvoice.Text.ToString());
            string incortms = DdlInCoterms.SelectedItem.ToString();
            String location = TxtInsLocation.Text.ToString();
            String ManuProSL = TxtManuProvideSl.Text.ToString();
            String function = TxtFunction.Text.ToString();
            string capacity = TxtCapacity.Text.ToString();
            DateTime dteinstalation = DateTime.Parse(TxtDteInstalation.Text);
            Decimal erectioncost = Decimal.Parse(TxtErectionCost.Text.ToString());
            int department = int.Parse(DdlDept.SelectedValue.ToString());

            try { dteacusition = DateTime.Parse(TxtDteAcusition.Text); }
            catch { dteacusition = DateTime.Parse("1990-01-01".ToString()); }

            String life = TxtRecomandLife.Text.ToString();

            Decimal salvage = Decimal.Parse(TxtEstSalvageValue.Text.ToString());
            Decimal landedC = Decimal.Parse(TxtLandedCost.Text.ToString());
            Decimal TAccumulatedC = Decimal.Parse(TxtTAccumulatedCost.Text.ToString());
            Decimal RateDepriciation = Decimal.Parse(TxtRateDepeciation.Text.ToString());
            Decimal AccumulatedDepriciation = decimal.Parse(TxtAccumulatedDepreciation.Text.ToString());
            String MethodDep = TxtMethodDepreciation.Text.ToString();
            Decimal ValueAfterDep = Decimal.Parse(TxtValueDepreciation.Text.ToString());
            Decimal writedownv = Decimal.Parse(TxtWrittenDownValue.Text.ToString());
            string remarks = TxtRemarks.Text.ToString();
            string currency = DdlCurrency.SelectedItem.ToString();


            Decimal accudepreciation = Decimal.Parse(TxtAccumulatedDepreciation.Text.ToString());
            String methoddepreciation = TxtMethodDepreciation.Text.ToString();
            Decimal wdownvalue = Decimal.Parse(TxtWrittenDownValue.Text.ToString());
            Int32 Active = Int32.Parse(DdlDesiable.SelectedValue.ToString());

            try { Costcenterid = Int32.Parse(DdlCostCenterF.SelectedValue.ToString()); }
            catch { Costcenterid = Int32.Parse(0.ToString()); }
            try { Plantname = Int32.Parse(DdlPlantF.SelectedValue.ToString()); }
            catch { Plantname = Int32.Parse(0.ToString()); }
            string maintType = DdlMainType.SelectedItem.ToString();
            string fmodel = TxtFModel.Text.ToString();
                objregisterUpdate.UpdateAssetRegistration(Active, assetname, assettype, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, invoicevalue, incortms, location, ManuProSL, function, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, WarrintyPreoid, Costcenterid, Plantname, maintType,fmodel,intenrollid, intjobid, assetcode);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully  Update ');", true);
                TxtAssetName.Text = ""; TxtHSCode.Text = ""; TxtAssetDescription.Text = ""; TxtManufacturer.Text = "";
                TxtContryOrigin.Text = ""; TxtCountryManufacture.Text = ""; TxtSuppName.Text = ""; TxtLCNo.Text = "";
                TxtDteLC.Text = ""; TxtAssetCode.Text = "";
            
            
            
        }

        protected void BtnBuilding_Click(object sender, EventArgs e)
        {
            decimal totalAccumulatedCost;
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 unit = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());
            Int32 jobstation = Int32.Parse(DdlbuildJobstation.SelectedValue.ToString());
            Int32 assettype = Int32.Parse(DdlBuildAssetType.SelectedValue.ToString());
            String assetname = TxtNameStructer.Text.ToString(); ;
            string BDescription = TxtBDescription.Text.ToString();
            string Requestby = TxtRequestBy.Text.ToString();
            string RequestApproved = TxtBapproveBy.Text.ToString();
            string Blocation = TxtLocation.Text.ToString();
           
            DateTime PoDate = DateTime.Parse(TxtDteBPodate.Text);
            DateTime porjectstardtDate = DateTime.Parse(TxtdteProjectStart.Text);
            DateTime deliverydate = DateTime.Parse(TxtdteBDeliveryDate.Text);
            string Length = TxtLength.Text.ToString();
            string Breadth = TxtBreadth.Text.ToString();
            string height = TxtHeight.Text.ToString();
            string totalarea = TxtBTotalArea.Text.ToString();
            decimal estimaticost = decimal.Parse(TxtBEstimatedCost.Text.ToString());
            decimal estmateconstriuction = decimal.Parse(TxtBEstimatedConstruction.Text.ToString());
            decimal actualconstruction = decimal.Parse(TxtActualConstruction.Text.ToString());
            string Estimatedlife = TxtEstimatedLife.Text.ToString();
            string year = TxtYearConstruction.Text.ToString();
            string Dept = TxtServciceDept.Text.ToString();
            string funndingsouece = TxtBprojectFundingSource.Text.ToString();
            string supplyby = TxtMaterailsSupplyby.Text.ToString();
            string consultant = TxtConsultantName.Text.ToString();
            string contractorname = TxtContractorName.Text.ToString();
            string renovationwork = TxtRenovationWork.Text.ToString();
            string approximiatly = TxtdteApproximatly.Text.ToString();
            string renomateralis = TxtRenovationMaterilas.Text.ToString();
            string projectnumber = TxtProkjectNumber.Text.ToString();
            string Bremarks = TxtBRemarks.Text.ToString();
            Int32 category = Int32.Parse(DdlBAssetCategory.Text.ToString());
            string BPoNO = TxtALandBuildCode.Text.ToString();
            try { totalAccumulatedCost = decimal.Parse(TxtTotalAccumulatedCost.Text.ToString()); }
            catch { totalAccumulatedCost = decimal.Parse(0.ToString()); }
            intpart = 6;
            objregisterUpdate.BuildingUpdate(intpart, unit, jobstation, assettype, assetname, BDescription, supplyby, category, BPoNO, PoDate, Blocation, Estimatedlife, Bremarks, Requestby, RequestApproved, porjectstardtDate, deliverydate, Length, Breadth, height, totalarea, estimaticost, estmateconstriuction, actualconstruction, year, Dept, funndingsouece, consultant, contractorname, renovationwork, approximiatly, renomateralis, intenroll, intjobid, projectnumber, totalAccumulatedCost);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully ');", true);
            TxtALandBuildCode.Text = "";
        
        }

        protected void BtnLand_Click(object sender, EventArgs e)
        {
            Int32 intenrollid = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


            Int32 UnitLand = Int32.Parse(DdlUnitLand.SelectedValue.ToString());
            Int32 Jobland = Int32.Parse(DdlJobland.SelectedValue.ToString());

            Int32 AssetTypeLand = Int32.Parse(DdlAssetLand.Text.ToString());

            String AssetLand = TxtAssetLand.Text.ToString();
            //Int32 category = Int32.Parse(DdlAssetCate.SelectedValue.ToString());
            string descriptionL = TxtDescriptionLand.Text.ToString();
            //string landpo = LandPo.Text.ToString();
            string landbayername = TxtBuyer.Text.ToString();
            string nameseller = TxtNameofSeller.Text.ToString();
            string landclass = DdlClass.SelectedItem.ToString();
            Int32 district = Int32.Parse(Ddldistrict.SelectedValue.ToString());
            Int32 Thana = Int32.Parse(DDlThana.SelectedValue.ToString());
            string mouja = TxtMouza.Text.ToString();
            string CSKatian = TxtCSKatian.Text.ToString();

            string SaKatian = TxtSaKatian.Text.ToString();
            string RSKathin = TxtRSKathin.Text.ToString();
            string DSKathian = TxtDSKathian.Text.ToString();
            string DpKatian = TxtDpKatian.Text.ToString();
            string CSDagNo = TxtCSDagNo.Text.ToString();
            string SADagNo = TxtSADagNo.Text.ToString();

            string RSDagNo = TxtRSDagNo.Text.ToString();
            string DSDagNo = TxtDSDagNo.Text.ToString();
            string DPDagNo = TxtDPDagNo.Text.ToString();
            string DeedReceoiptNo = TxtDeedReceoiptNo.Text.ToString();
            string DeedNo = TxtDeedNo.Text.ToString();
            DateTime DeedDate = DateTime.Parse(DteDeedDate.Text);
            DateTime DeedCertifyreceivedate = DateTime.Parse(dteDeedCertifyreceivedate.Text);
            DateTime OrginalDeedReceiveDate = DateTime.Parse(TxtOrginalDeedReceiveDate.Text);
            Decimal TotalArea = Decimal.Parse(TxtTotalArea.Text.ToString());
            Decimal TotalArealandinDecimal = Decimal.Parse(TxtTotalArealandinDecimal.Text.ToString());
            Decimal PricePerKatha = Decimal.Parse(TxtPricePerKatha.Text.ToString());
            Decimal PriceperDecimal = Decimal.Parse(TxtPriceperDecimal.Text.ToString());
            Decimal TotalValuelandTk = Decimal.Parse(TxtTotalValuelandTk.Text.ToString());
            Decimal RegistryBainaAmount = Decimal.Parse(TxtRegistryBainaAmount.Text.ToString());
            Decimal BalancelandValue = Decimal.Parse(TxtBalancelandValue.Text.ToString());
            Decimal RegistrationExpance = Decimal.Parse(TxtRegistrationExpance.Text.ToString());
            Decimal DeedValueLand = Decimal.Parse(TxtDeedValueLand.Text.ToString());
            Decimal LandofficevolumeCheckingexp = Decimal.Parse(TxtLandofficevolumeCheckingexp.Text.ToString());
            Decimal Nfees = Decimal.Parse(TxtNfees.Text.ToString());
            Decimal LocalgovtTax = decimal.Parse(TxtLocalgovtTax.Text.ToString());
            decimal Stamp = Decimal.Parse(TxtStamp.Text.ToString());
            decimal IncomeTax = Decimal.Parse(TxtIncomeTax.Text.ToString());
            Decimal GainTax = Decimal.Parse(TxtGainTax.Text.ToString());
            Decimal PayOrderExpense = Decimal.Parse(TxtPayOrderExpense.Text.ToString());
            Decimal SubRegisterCommission = Decimal.Parse(TxtSubRegisterCommission.Text.ToString());
            decimal DeedCertifiescopyExpance = Decimal.Parse(TxtDeedCertifiescopyExpance.Text.ToString());
            Decimal MutionExpanse = Decimal.Parse(TxtMutionExpanse.Text.ToString());
            Decimal OtherExpanse = Decimal.Parse(TxtOtherExpanse.Text.ToString());
            Decimal TotalArealandMuted = Decimal.Parse(TxtTotalArealandMuted.Text.ToString());
            string Jlno = Txtjlno.Text.ToString();
            String HoldingNoJotNo = TxtHoldingNoJotNo.Text.ToString();
            Decimal LandDevlopmentTaxExpance = Decimal.Parse(TxtLandDevlopmentTaxExpance.Text.ToString());
            Decimal BrokrCommission = Decimal.Parse(TxtBrokrCommission.Text.ToString());
            Decimal TotalLandAccusitionCost = Decimal.Parse(TxtTotalLandAccusitionCost.Text.ToString());


            string landpo = TxtALandCode.Text.ToString();
            //SpAssetRegister use for Update //
            intpart = 4;
            objregisterUpdate.AssetLandUpdate(intpart, UnitLand, Jobland, AssetTypeLand, AssetLand, descriptionL, landpo, landbayername, nameseller, landclass, district, Thana, mouja, CSKatian, SaKatian, RSKathin, DSKathian, DpKatian, CSDagNo, SADagNo, RSDagNo, DSDagNo, DPDagNo, DeedReceoiptNo, DeedNo, DeedDate, DeedCertifyreceivedate, OrginalDeedReceiveDate, TotalArea, TotalArealandinDecimal, PricePerKatha, PriceperDecimal, TotalValuelandTk, RegistryBainaAmount, BalancelandValue, RegistrationExpance, DeedValueLand, LandofficevolumeCheckingexp, Nfees, LocalgovtTax, Stamp, IncomeTax, GainTax, PayOrderExpense, SubRegisterCommission, DeedCertifiescopyExpance, MutionExpanse, OtherExpanse, TotalArealandMuted, Jlno, HoldingNoJotNo, LandDevlopmentTaxExpance, BrokrCommission, TotalLandAccusitionCost, intenrollid, intunitid, intjobid);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully ');", true);
            TxtALandCode.Text = "";


        }

        protected void BtnVechileSave_Click(object sender, EventArgs e)
        {
            DateTime dtelc; DateTime dtepo; DateTime dteacusition; DateTime DteTaxToken;
            DateTime dtefitness; DateTime dteInsurance; DateTime WarrintyPreoid;
            DateTime RootPermit;

            int intenrollid = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            try
            {

                int unit = int.Parse(ddlUnits.SelectedValue);
                int jobstation = int.Parse(Ddljob.SelectedValue);
                int assettype = int.Parse(DdlAsetTypes.SelectedValue);
                string assetname = TxtVechilReg.Text.ToString();
                int category = int.Parse(DdlAssetCate.SelectedValue);
                //string assetid = (DdlDept.Text.ToString());
                string hscode = (TxtHSCodes.Text.ToString());
                string description = TxtDscVechile.Text.ToString();
                string manufacture = TxtManuFactrurer.Text.ToString();
                string countryorigin = TxtOrigin.Text.ToString();
                string countrymanufacture = TxtCountryManu.Text.ToString();
                string supplier = TxtSupplier.Text.ToString();

                string lcno = TxtLcNumbers.Text.ToString();

                string pono = TxtPonumber.Text.ToString();

                decimal invoicevalue = Decimal.Parse(TxtInvoices.Text.ToString());
                string currency = DdlCurrency.SelectedItem.ToString();
                string incortms = DdlIncotermsd.SelectedItem.ToString();

                string servicetype = DdlServiceType.SelectedItem.ToString();
                string brand = DdlBrand.SelectedItem.ToString();
                string model = TxtModel.Text.ToString();
                string cc = TxtCC.Text.ToString();
                string color = DDlColor.SelectedItem.ToString();
                string Engine = TxtEngine.Text.ToString();
                string chasis = TxtCassis.Text.ToString();
                string inetialMilege = TxtInitialM.Text.ToString();
                string fuelstats = DdlFuelStatus.SelectedItem.ToString();
                DateTime DteRegistration = DateTime.Parse(TxtDteReg.Text);


                string insuranceName = DdlInsurance.SelectedItem.Text.ToString();
                // string rootname = TxtRoot.Text.ToString();
                try { RootPermit = DateTime.Parse(TxtDteRoot.Text); }
                catch { RootPermit = DateTime.Parse("1900-01-01"); }

                string location = TxtInsLocation.Text.ToString();


                int department = 0;



                string life = TxtRecommand.Text.ToString();

                decimal salvage = decimal.Parse(TxtEstSalvase.Text.ToString());
                decimal landedC = decimal.Parse(TxtLandedCosts.Text.ToString());
                decimal TAccumulatedC = decimal.Parse(Txttotalcost.Text.ToString());
                decimal RateDepriciation = decimal.Parse(TxtRateDepriciation.Text.ToString());
                decimal AccumulatedDepriciation = decimal.Parse(TxtTotalAccumatleted.Text.ToString());

                decimal ValueAfterDep = decimal.Parse(TxtValueAfterDep.Text.ToString());
                decimal writedownv = decimal.Parse(TxtWritenDownValue.Text.ToString());


                string remarks = TxtRemarksd.Text.ToString();
                string MethodDep = TxtMethode.Text.ToString();

                //String ManuProSL = TxtVechilReg.Text.ToString();


                string capacity = TxtModelYear.Text.ToString();
                DateTime dteinstalation = DateTime.Parse("2016-10-10".ToString());
                decimal erectioncost = decimal.Parse("0".ToString());


                int exixtingV = int.Parse(0.ToString());


                int txtUsername = int.Parse(txtUser.Text.ToString());

                try { dtepo = DateTime.Parse(TxtVPoDate.Text); }
                catch { dtepo = DateTime.Parse("1900-01-01"); }

                try { dtelc = DateTime.Parse(TxtDteVLcDate.Text); }
                catch { dtelc = DateTime.Parse("1900-01-01"); }

                try { WarrintyPreoid = DateTime.Parse(TxtDteVWarranty.Text); }
                catch { WarrintyPreoid = DateTime.Parse("1900-01-01"); }

                try { dteacusition = DateTime.Parse(TxtDteAccusition.Text); }
                catch { dteacusition = DateTime.Parse("1900-01-01"); }



                try { DteTaxToken = DateTime.Parse(TxtDteToken.Text); }
                catch { DteTaxToken = DateTime.Parse("1900-01-01"); }

                try { dtefitness = DateTime.Parse(TxtDteFitness.Text); }
                catch { dtefitness = DateTime.Parse("1900-01-01"); }
                try { dteInsurance = DateTime.Parse(TxtDteInsurance.Text); }
                catch { dteInsurance = DateTime.Parse("1900-01-01"); }

                string city = "0".ToString();
                string indenty = "0".ToString();
                string beginno = "0".ToString();
                string policyT = DdlpolicyType.SelectedItem.ToString();
                string poliNmae = Txtpolicy.Text.ToString();
                string unloadin = TxtUnladanW.Text.ToString();
                string loaden = TxtladenW.Text.ToString();

                string ManuProSL = TxtVehicleCode.Text.ToString();



                intpart = 3;

                objregisterUpdate.VehicleUpdate(intpart, unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, WarrintyPreoid, invoicevalue, incortms, location, ManuProSL, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, servicetype, brand, model, cc, color, Engine, chasis, inetialMilege, fuelstats, txtUsername, policyT, DteRegistration, DteTaxToken, dtefitness, dteInsurance, insuranceName, poliNmae, RootPermit, exixtingV, city, indenty, beginno, unloadin, loaden);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully ');", true);

                TxtVehicleCode.Text = "";
                loadTab2VehicleReg();
            }
            catch { }
        }

        protected void DlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(DlJobStation.SelectedValue.ToString());
            dt= objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
             dt = new DataTable();

            dt= objregisterUpdate.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();

            //dt = new DataTable();
            //dt= objregisterUpdate.DepertmentName(jobstation);
            //DdlDept.DataSource = dt;
            //DdlDept.DataTextField = "strDepatrment";
            //DdlDept.DataValueField = "intDepartmentID";
            //DdlDept.DataBind();
            
        }

        protected void DdlUnitLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 Unitland = Int32.Parse(DdlUnitLand.SelectedValue.ToString());
            dt = objregisterUpdate.Ljobstation(Unitland);
            DdlJobland.DataSource = dt;
            DdlJobland.DataTextField = "strJobStationName";
            DdlJobland.DataValueField = "intEmployeeJobStationID";
            DdlJobland.DataBind();
        }

        protected void Ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 districtss = Int32.Parse(Ddldistrict.SelectedValue.ToString());
            dt = objregisterUpdate.Thanadrodownview(districtss);
            DDlThana.DataSource = dt;
            DDlThana.DataTextField = "strDistrictBanglaName";
            DDlThana.DataValueField = "intDistrictIDs";
            DDlThana.DataBind();

        }


        protected void TxtVehicleCode_TextChanged(object sender, EventArgs e)
        {

            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());


            int Mnumber = int.Parse("1".ToString());
            string assetcode = TxtVehicleCode.Text.ToString();
            dt = new DataTable();
            intItem = 2;
            dt = objregisterUpdate.AssetVehicleView(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
           
            if (dt.Rows.Count > 0)
            {

                //try { ddlUnits.SelectedItem.Text = dt.Rows[0]["strUnit"].ToString(); }
               // catch { };
                try { ddlUnits.SelectedValue = dt.Rows[0]["intUnitID"].ToString(); }
                catch { };
                ddlUnits.DataBind();

                //try { Ddljob.SelectedItem.Text = dt.Rows[0]["strJobStationName"].ToString(); }
               // catch { }
                try { Ddljob.SelectedValue = dt.Rows[0]["intEmployeeJobStationId"].ToString(); }
                catch { };
                Ddljob.DataBind();
                try { DdlAsetTypes.SelectedItem.Text = dt.Rows[0]["strAssetTypeName"].ToString(); }
                catch { };
                try { DdlAssetCate.SelectedValue = dt.Rows[0]["intCategory"].ToString(); }
                catch { };
                DdlAssetCate.DataBind();

                TxtVechilReg.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                TxtHSCodes.Text = dt.Rows[0]["strHSCode"].ToString();
                TxtManuFactrurer.Text = dt.Rows[0]["strNameManufacturer"].ToString();
                TxtDscVechile.Text = dt.Rows[0]["strDescriptionAsset"].ToString();
                
                TxtOrigin.Text = dt.Rows[0]["strCountryOrigin"].ToString();
                TxtCountryManu.Text = dt.Rows[0]["strCountryManufacturing"].ToString();

                TxtSupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                //try { DdlAssetCate.SelectedItem.Text = dt.Rows[0]["strCategoryName"].ToString(); }
               // catch { };

               

                TxtLcNumbers.Text = dt.Rows[0]["strLCNo"].ToString();
                TxtDteVLcDate.Text = dt.Rows[0]["dteLCDate"].ToString();
                TxtPonumber.Text = dt.Rows[0]["strPoNo"].ToString();
                TxtVPoDate.Text = dt.Rows[0]["dtePoNo"].ToString();
                TxtDteVWarranty.Text = dt.Rows[0]["dteWarranteePeriod"].ToString();
                TxtInvoices.Text = dt.Rows[0]["monInvoiceValue"].ToString();
                 DdlCurrencys.Text = dt.Rows[0]["strCurrency"].ToString();
                 try { DdlIncotermsd.Text = dt.Rows[0]["strIncoterms"].ToString(); }
                 catch { };

                TxtDteAccusition.Text = dt.Rows[0]["dtrAcusition"].ToString();
                try { DdlServiceType.Text = dt.Rows[0]["strVServiceType"].ToString(); }
                catch { };
                try { DdlBrand.SelectedItem.Text = dt.Rows[0]["strVBrand"].ToString(); }
                catch { };
                TxtModel.Text = dt.Rows[0]["strVModel"].ToString();
                TxtCC.Text = dt.Rows[0]["strVCC"].ToString();
                try { DDlColor.Text = dt.Rows[0]["strVColor"].ToString(); }
                catch { };
                TxtEngine.Text = dt.Rows[0]["strVEngineNo"].ToString();
                TxtCassis.Text = dt.Rows[0]["strVChasisNo"].ToString();
                TxtInitialM.Text = dt.Rows[0]["strVInetialMilege"].ToString();
                try { DdlFuelStatus.SelectedItem.Text = dt.Rows[0]["strVFuelstatus"].ToString(); }
                catch{};
              
                txtUser.Text = dt.Rows[0]["IntVUserEnroll"].ToString();
              
                TxtDteReg.Text = dt.Rows[0]["DteVRegistrationDate"].ToString();
                TxtDteToken.Text = dt.Rows[0]["DteVTaxToken"].ToString();
                TxtDteFitness.Text = dt.Rows[0]["DteVFitnessDate"].ToString();
                DdlInsurance.SelectedItem.Text = dt.Rows[0]["strVInsuranceName"].ToString();

                TxtDteInsurance.Text = dt.Rows[0]["DteVInsuranceDate"].ToString();
               // TxtRoot.Text = dt.Rows[0]["strVRootName"].ToString();
                TxtDteRoot.Text = dt.Rows[0]["dteVRootPermitValidity"].ToString();
                //DdlDepartments.SelectedItem.Text = dt.Rows[0]["strDepatrment"].ToString();
                TxtRecommand.Text = dt.Rows[0]["strRecommanLife"].ToString();
                TxtEstSalvase.Text = dt.Rows[0]["monEstSolvageValue"].ToString();
                TxtLandedCosts.Text = dt.Rows[0]["monLandedCost"].ToString();
                Txttotalcost.Text = dt.Rows[0]["monTAccumulatedCost"].ToString();
                TxtRateDepriciation.Text = dt.Rows[0]["monRateOfDepeciation"].ToString();
                TxtTotalAccumatleted.Text = dt.Rows[0]["monAccumulatedDepeciation"].ToString();
                TxtMethode.Text = dt.Rows[0]["strMethodDepeciation"].ToString();
                 TxtValueAfterDep.Text = dt.Rows[0]["monValueAfterDepeciation"].ToString();
                TxtWritenDownValue.Text = dt.Rows[0]["monWritDownValue"].ToString();
                TxtRemarksd.Text = dt.Rows[0]["strRemarks"].ToString();
                TxtUnladanW.Text = dt.Rows[0]["strVehicleUnLodan"].ToString();
                TxtladenW.Text = dt.Rows[0]["strVehicleLodan"].ToString();
                Txtpolicy.Text = dt.Rows[0]["strVehiclePolicyNo"].ToString();
                DdlpolicyType.Text = dt.Rows[0]["strVehiclePolicyType"].ToString();
                TxtModelYear.Text = dt.Rows[0]["strVehicleModelofYear"].ToString();

            }
            MainView.ActiveViewIndex = 1;
        }

        protected void TxtALandCode_TextChanged(object sender, EventArgs e)
        {

          
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());


            Int32 Mnumber = Int32.Parse("1".ToString());
            string assetcode = TxtALandCode.Text.ToString();
            DataTable LandView = new DataTable();
            intItem = 3;
            LandView = objregisterUpdate.AssetLandView(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (LandView.Rows.Count > 0)
            {
                DdlUnitLand.SelectedItem.Text = LandView.Rows[0]["strUnit"].ToString();
                DdlJobland.SelectedItem.Text = LandView.Rows[0]["strJobStationName"].ToString();
                DdlAssetLand.SelectedItem.Text = LandView.Rows[0]["strAssetTypeName"].ToString();


                TxtAssetLand.Text = LandView.Rows[0]["strNameOfAsset"].ToString();
                LandPo.Text = LandView.Rows[0]["strPoNo"].ToString();
                TxtDescriptionLand.Text = LandView.Rows[0]["strDescriptionAsset"].ToString();
                TxtBuyer.Text = LandView.Rows[0]["strBuyerName"].ToString();
                TxtNameofSeller.Text = LandView.Rows[0]["strNameofSeller"].ToString();
                DdlClass.Text = LandView.Rows[0]["strClassofLand"].ToString();

                Ddldistrict.SelectedItem.Text = LandView.Rows[0]["strDistrict"].ToString();
                DDlThana.SelectedItem.Text = LandView.Rows[0]["Thana"].ToString();

                TxtMouza.Text = LandView.Rows[0]["strMouza"].ToString();
                TxtCSKatian.Text = LandView.Rows[0]["strCSkhatianNo"].ToString();
                TxtSaKatian.Text = LandView.Rows[0]["strSAkhatianNo"].ToString();
                TxtRSKathin.Text = LandView.Rows[0]["strRSkhatianNo"].ToString();
                TxtDSKathian.Text = LandView.Rows[0]["strDSkhatianNo"].ToString();
                TxtDpKatian.Text = LandView.Rows[0]["strDPkhatianNo"].ToString();
                TxtCSDagNo.Text = LandView.Rows[0]["strCSdagNo"].ToString();
                TxtSADagNo.Text = LandView.Rows[0]["strSAdagNo"].ToString();
                TxtRSDagNo.Text = LandView.Rows[0]["strRSdagNo"].ToString();
                TxtDSDagNo.Text = LandView.Rows[0]["strDSdagNo"].ToString();

                TxtDPDagNo.Text = LandView.Rows[0]["strDPdagNo"].ToString();
                TxtDeedReceoiptNo.Text = LandView.Rows[0]["strDeedReceiptNo"].ToString();
                TxtDeedNo.Text = LandView.Rows[0]["strDeedNo"].ToString();
                DteDeedDate.Text = LandView.Rows[0]["dteDeedDate"].ToString();
                dteDeedCertifyreceivedate.Text = LandView.Rows[0]["dteDeedCertifiedCopyReceivedDate"].ToString();
                TxtOrginalDeedReceiveDate.Text = LandView.Rows[0]["dteOriginalCopyReceivedDate"].ToString();
                TxtTotalArea.Text = LandView.Rows[0]["numAreaofLnadinKhata"].ToString();
                TxtTotalArealandinDecimal.Text = LandView.Rows[0]["numAreaofLnadindecimal"].ToString();
                TxtPricePerKatha.Text = LandView.Rows[0]["monPriceperKhata"].ToString();
                TxtPriceperDecimal.Text = LandView.Rows[0]["monPriceperDecimal"].ToString();
                TxtTotalValuelandTk.Text = LandView.Rows[0]["monTotalValueofLand"].ToString();
                TxtRegistryBainaAmount.Text = LandView.Rows[0]["monRegistryBinaAmount"].ToString();
                TxtBalancelandValue.Text = LandView.Rows[0]["monBalanceofLandValue"].ToString();
                TxtLocalgovtTax.Text = LandView.Rows[0]["monLocalGovtTax"].ToString();
                TxtStamp.Text = LandView.Rows[0]["monStampCharge"].ToString();
                TxtIncomeTax.Text = LandView.Rows[0]["monIncomeTax"].ToString();
                TxtGainTax.Text = LandView.Rows[0]["monGainTax"].ToString();

                TxtNfees.Text = LandView.Rows[0]["monNFees"].ToString();
                TxtPayOrderExpense.Text = LandView.Rows[0]["monPayorderExp"].ToString();
                TxtSubRegisterCommission.Text = LandView.Rows[0]["monSubRegisterCom"].ToString();
                TxtLandofficevolumeCheckingexp.Text = LandView.Rows[0]["monOfficeVolumeCheckingExp"].ToString();
                TxtDeedCertifiescopyExpance.Text = LandView.Rows[0]["monDeedCertifiedCopyExp"].ToString();
                TxtMutionExpanse.Text = LandView.Rows[0]["monMutationExp"].ToString();
                TxtOtherExpanse.Text = LandView.Rows[0]["monOtherExpenses"].ToString();
                TxtTotalArealandMuted.Text = LandView.Rows[0]["numTotalAreaofLandmuted"].ToString();
                Txtjlno.Text = LandView.Rows[0]["strJLNo"].ToString();
                TxtHoldingNoJotNo.Text = LandView.Rows[0]["strHoldingNo"].ToString();
                TxtLandDevlopmentTaxExpance.Text = LandView.Rows[0]["monLanddevelopmentTaxExp"].ToString();
                TxtBrokrCommission.Text = LandView.Rows[0]["monBrokerCom"].ToString();
                TxtTotalLandAccusitionCost.Text = LandView.Rows[0]["monTotalLandAccusitionCost"].ToString();
                TxtRegistrationExpance.Text = LandView.Rows[0]["monRegistrationExp"].ToString();

                TxtDeedValueLand.Text = LandView.Rows[0]["monDeedValueofLand"].ToString();

            }
            MainView.ActiveViewIndex = 2;
        }

        protected void TxtALandBuildCode_TextChanged(object sender, EventArgs e)
        {
            DataTable devlopmentV = new DataTable();
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());


            Int32 Mnumber = Int32.Parse("1".ToString());
            string assetcode = TxtALandBuildCode.Text.ToString();
           
            intItem = 4;
            devlopmentV = objregisterUpdate.AssetDevlopment(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (devlopmentV.Rows.Count > 0)
            {
                DdlBuildUnit.SelectedItem.Text = devlopmentV.Rows[0]["strUnit"].ToString();
                DdlbuildJobstation.SelectedItem.Text = devlopmentV.Rows[0]["strJobStationName"].ToString();
                DdlBuildAssetType.SelectedItem.Text = devlopmentV.Rows[0]["strAssetTypeName"].ToString();


                TxtNameStructer.Text = devlopmentV.Rows[0]["strNameOfAsset"].ToString();
                LandPo.Text = devlopmentV.Rows[0]["strPoNo"].ToString();
                TxtBDescription.Text = devlopmentV.Rows[0]["strDescriptionAsset"].ToString();
                TxtRequestBy.Text = devlopmentV.Rows[0]["strRequestby"].ToString();
                TxtBapproveBy.Text = devlopmentV.Rows[0]["strRequestApproved"].ToString();
                TxtLocation.Text = devlopmentV.Rows[0]["strInstallationLocation"].ToString();

                TxtBPoNo.Text = devlopmentV.Rows[0]["strPoNo"].ToString();
                TxtDteBPodate.Text = devlopmentV.Rows[0]["dtePoNo"].ToString();
                TxtdteProjectStart.Text = devlopmentV.Rows[0]["DtePorjectstardtDate"].ToString();
                TxtdteBDeliveryDate.Text = devlopmentV.Rows[0]["DteDeliverydate"].ToString();
                TxtLength.Text = devlopmentV.Rows[0]["strLength"].ToString();
                TxtBreadth.Text = devlopmentV.Rows[0]["strBreadth"].ToString();
                TxtHeight.Text = devlopmentV.Rows[0]["strHeight"].ToString();
                TxtBTotalArea.Text = devlopmentV.Rows[0]["strTotalArea"].ToString();
                TxtBEstimatedCost.Text = devlopmentV.Rows[0]["monEstimatiCost"].ToString();
                TxtBEstimatedConstruction.Text = devlopmentV.Rows[0]["monEstmateConstriuction"].ToString();
                TxtActualConstruction.Text = devlopmentV.Rows[0]["monActualConstruction"].ToString();
                TxtEstimatedLife.Text = devlopmentV.Rows[0]["strRecommanLife"].ToString();
                TxtYearConstruction.Text = devlopmentV.Rows[0]["strConstructorYear"].ToString();
                TxtServciceDept.Text = devlopmentV.Rows[0]["ServiceDept"].ToString();

                TxtBprojectFundingSource.Text = devlopmentV.Rows[0]["strFunndingSource"].ToString();
                TxtMaterailsSupplyby.Text = devlopmentV.Rows[0]["strSupplierName"].ToString();
                TxtConsultantName.Text = devlopmentV.Rows[0]["strConsultant"].ToString();
                TxtContractorName.Text = devlopmentV.Rows[0]["strContractorName"].ToString();
                TxtRenovationWork.Text = devlopmentV.Rows[0]["strEovationWork"].ToString();
                TxtdteApproximatly.Text = devlopmentV.Rows[0]["strApproximiatly"].ToString();
                TxtRenovationMaterilas.Text = devlopmentV.Rows[0]["strRenovationmateralis"].ToString();
                TxtProkjectNumber.Text = devlopmentV.Rows[0]["strProjectNumber"].ToString();
                TxtBRemarks.Text = devlopmentV.Rows[0]["strRemarks"].ToString();
                DdlBAssetCategory.SelectedItem.Text = devlopmentV.Rows[0]["strCategoryName"].ToString();
                try { TxtTotalAccumulatedCost.Text = devlopmentV.Rows[0]["monTAccumulatedCost"].ToString(); }
                catch { TxtTotalAccumulatedCost.Text = "0".ToString(); }



            }
            MainView.ActiveViewIndex = 3;
        }

       

        protected void DdlBuildUnit_SelectedIndexChanged1(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 Bnitland = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());
            dt= objregisterUpdate.Ljobstation(Bnitland);
            DdlbuildJobstation.DataSource = dt;
            DdlbuildJobstation.DataTextField = "strJobStationName";
            DdlbuildJobstation.DataValueField = "intEmployeeJobStationID";
            DdlbuildJobstation.DataBind();
        }

        
        protected void Ddljob_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(Ddljob.SelectedValue.ToString());
            dt = objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
            dt = new DataTable();

            dt = objregisterUpdate.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
        }

       

        protected void DdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 pJob = Int32.Parse(DdlUnit.SelectedValue.ToString());
            dt = objregisterUpdate.Ljobstation(pJob);
            DlJobStation.DataSource = dt;
            DlJobStation.DataTextField = "strJobStationName";
            DlJobStation.DataValueField = "intEmployeeJobStationID";
            DlJobStation.DataBind();
            dt = new DataTable();

            Int32 jobstation = Int32.Parse(DlJobStation.SelectedValue.ToString());
            dt = objregisterUpdate.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
            
            Int32 intUnitID = Int32.Parse(DdlUnit.SelectedValue.ToString());
            dt = objregisterUpdate.RegCostCenter(intUnitID);
            DdlCostCenterF.DataSource = dt;
            DdlCostCenterF.DataTextField = "Name";
            DdlCostCenterF.DataValueField = "Id";
            DdlCostCenterF.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.PlantName(intUnitID);
            DdlPlantF.DataSource = dt;
            DdlPlantF.DataTextField = "Name";
            DdlPlantF.DataValueField = "Id";
            DdlPlantF.DataBind();
        }

        protected void DlJobStation_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
            Int32 jobstation = int.Parse(DlJobStation.SelectedValue.ToString());
           

            dt = new DataTable();
            
            dt = objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
            dt = new DataTable();
            dt = objregisterUpdate.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
        }

        protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 unitid = Int32.Parse(ddlUnits.SelectedValue.ToString());
            dt = objregisterUpdate.Ljobstation(unitid);
            Ddljob.DataSource = dt;
            Ddljob.DataTextField = "strJobStationName";
            Ddljob.DataValueField = "intEmployeeJobStationId";
            Ddljob.DataBind();
        }

        
   

       
    }
}
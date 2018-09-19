
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using System.Xml;
 
using Purchase_BLL.VehicleRegRenewal_BLL;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.Asset
{
    public partial class FormAssetRegisterUI : BasePage
    {
        Assetregister_BLL objregister = new Assetregister_BLL();
       
        DataTable dt = new DataTable();
        string data; Int32 exixtingV;

        int intpart; int intItem; int Mnumber;

        string xmlString = ""; 

        string filePathForXMLDocUpload;

        // TourPlanning bll = new TourPlanning(); 
        DataTable dtinfo = new DataTable();
        RegistrationRenewals_BLL bllaset = new RegistrationRenewals_BLL();
        string filePathForXML; string serial;

        decimal accudepreciation, wdownvalue, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, ValueAfterDep, writedownv, invoicevalue, erectioncost; int department;
        DateTime dtelc, dtepo, dteacusition, dteinstalation, WarrintyPreoid;

        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\FormAssetRegisterUI";
        string stop = "stopping Asset\\FormAssetRegisterUI";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Asset/Data/Assetinformation_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
           
            filePathForXMLDocUpload = Server.MapPath("~/Asset/Data/DocUpload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {

                Button3.Visible = false;
                Button2.Visible = false;
              
                TxtValueAfterDep.Text = "0"; TxtWritenDownValue.Text = "0"; TxtTotalAccumatleted.Text = "0"; TxtRateDepriciation.Text = "0";
                Txttotalcost.Text = "0"; TxtLandedCosts.Text = "0"; TxtEstSalvase.Text = "0";
                
                TxtInvoices.Text = "0"; txtUser.Text = "0";
                TxtEstSalvageValue.Text = "0"; TxtLandedCost.Text = "0"; TxtTAccumulatedCost.Text = "0";
                TxtMethodDepreciation.Text = ""; TxtValueDepreciation.Text = "0"; TxtWrittenDownValue.Text = "0";
                TxtRemarks.Text = "0"; TxtInvoice.Text = "0";
                TxtErectionCost.Text = "0"; TxtAccumulatedDepreciation.Text = "0"; TxtRateDepeciation.Text = "0";
             
                pnlUpperControl.DataBind();
                
                try { File.Delete(filePathForXML); }
                catch { }
                

            }
            else
            {
                 
            }
        }

        

        private void CreateVoucherXmlBuildDocUpload(string strFileName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeBuildDocUpload(doc, strFileName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeBuildDocUpload(doc, strFileName);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);

        }

        private XmlNode CreateItemNodeBuildDocUpload(XmlDocument doc, string strFileName)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;

            node.Attributes.Append(StrFileName);

            return node;
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
            dt = objregister.LandType();

            DdlAssetLand.DataSource = dt;
            DdlAssetLand.DataTextField = "strAssetTypeName";
            DdlAssetLand.DataValueField = "intAssetTypeID";
            DdlAssetLand.DataBind();
            dt = new DataTable();

            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlUnitLand.DataSource = dt;
            DdlUnitLand.DataTextField = "strUnit";
            DdlUnitLand.DataValueField = "intUnitID";
            DdlUnitLand.DataBind();

            Int32 unitid = Int32.Parse(DdlUnitLand.SelectedValue.ToString());
            dt = new DataTable();

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlJobland.DataSource = dt;
            DdlJobland.DataTextField = "strJobStationName";
            DdlJobland.DataValueField = "intEmployeeJobStationId";
            DdlJobland.DataBind();
            dt = new DataTable();
            dt = objregister.Districviewdropdown();
            Ddldistrict.DataSource = dt;
            Ddldistrict.DataTextField = "strDistrictBanglaName";
            Ddldistrict.DataValueField = "intDistrictIDs";
            Ddldistrict.DataBind();
            dt = new DataTable();
            Int32 districtss = Int32.Parse(Ddldistrict.SelectedValue.ToString());
            dt = objregister.Thanadrodownview(districtss);
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

            dt = objregister.BuildingType();
            DdlBuildAssetType.DataSource = dt;
            DdlBuildAssetType.DataTextField = "strAssetTypeName";
            DdlBuildAssetType.DataValueField = "intAssetTypeID";
            DdlBuildAssetType.DataBind();
            dt = new DataTable();

            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlBuildUnit.DataSource = dt;
            DdlBuildUnit.DataTextField = "strUnit";
            DdlBuildUnit.DataValueField = "intUnitID";
            DdlBuildUnit.DataBind();

            dt = new DataTable();
            Int32 unitid = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DdlbuildJobstation.DataSource = dt;
            DdlbuildJobstation.DataTextField = "strJobStationName";
            DdlbuildJobstation.DataValueField = "intEmployeeJobStationId";
            DdlbuildJobstation.DataBind();

            dt = new DataTable();
            //**Building--- Category Fixed make id 999999 ****//
            Int32 buildcategorys = Int32.Parse("999999".ToString());
            dt = objregister.BuildingCataegoryList(buildcategorys);
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
            Int32 Mnumber = Int32.Parse("1".ToString());
            dt = objregister.VehicleRegisterArea();
            DvehicleArea.DataSource = dt;
            DvehicleArea.DataTextField = "name";
            DvehicleArea.DataValueField = "id";
            DvehicleArea.DataBind();
            
            dt = new DataTable();
            dt = objregister.VehicleBrand();
            DdlBrand.DataSource = dt;
            DdlBrand.DataTextField = "name";
            DdlBrand.DataValueField = "id";
            DdlBrand.DataBind();
            
            dt = new DataTable();
            dt = objregister.MotorVehicleTypes();
            DdlAsetTypes.DataSource = dt;
            DdlAsetTypes.DataTextField = "strAssetTypeName";
            DdlAsetTypes.DataValueField = "intAssetTypeID";
            DdlAsetTypes.DataBind();

            dt = new DataTable();
            dt = objregister.IndendityfiactionNumber();
            Ddlindentity.DataSource = dt;
            Ddlindentity.DataTextField = "name";
            Ddlindentity.DataValueField = "id";
            Ddlindentity.DataBind();

            dt = new DataTable();
            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlUnits.DataSource = dt;
            ddlUnits.DataTextField = "strUnit";
            ddlUnits.DataValueField = "intUnitID";
            ddlUnits.DataBind();

             Mnumber = Int32.Parse(ddlUnits.SelectedValue.ToString());

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            Ddljob.DataSource = dt;
            Ddljob.DataTextField = "strJobStationName";
            Ddljob.DataValueField = "intEmployeeJobStationId";
            Ddljob.DataBind();
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(Ddljob.SelectedValue.ToString());
            Int32 VehicleCat = Int32.Parse(999998.ToString());
            dt = objregister.DropdownCategoryView(VehicleCat);
            DdlAssetCate.DataSource = dt;
            DdlAssetCate.DataTextField = "strCategoryName";
            DdlAssetCate.DataValueField = "intCategoryID";
            DdlAssetCate.DataBind();
            dt = new DataTable();
            Int32 Unitid = Int32.Parse(ddlUnits.SelectedValue.ToString());

            dt = objregister.ExistingVehicleshow(Unitid);
            DdlExixtingVehicle.DataSource = dt;
            DdlExixtingVehicle.DataTextField = "strRegNo";
            DdlExixtingVehicle.DataValueField = "intID";
            DdlExixtingVehicle.DataBind();

            dt = new DataTable();
            dt = objregister.DepertmentName(jobstation);
            DdlDepartments.DataSource = dt;
            DdlDepartments.DataTextField = "strDepatrment";
            DdlDepartments.DataValueField = "intDepartmentID";
            DdlDepartments.DataBind();
        }

        private void loadTab1FactoryReg()
        {
            
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = 1;
            dt = objregister.AssetTypeName();
            DdlAssetType.DataSource = dt;
            DdlAssetType.DataTextField = "strAssetTypeName";
            DdlAssetType.DataValueField = "intAssetTypeID";
            DdlAssetType.DataBind();
            
            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);;
            DdlUnit.DataSource = dt;
            DdlUnit.DataTextField = "strUnit";
            DdlUnit.DataValueField = "intUnitID";
            DdlUnit.DataBind();
            
            int intUnitID = int.Parse(DdlUnit.SelectedValue.ToString());
            dt = objregister.RegCostCenter(intUnitID);
            DdlCostCenterF.DataSource = dt;
            DdlCostCenterF.DataTextField = "Name";
            DdlCostCenterF.DataValueField = "Id";
            DdlCostCenterF.DataBind();

           
            Mnumber = int.Parse(DdlUnit.SelectedValue.ToString());
        
            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            DlJobStation.DataSource = dt;
            DlJobStation.DataTextField = "strJobStationName";
            DlJobStation.DataValueField = "intEmployeeJobStationId";
            DlJobStation.DataBind();
            
            int jobstation = int.Parse(DlJobStation.SelectedValue.ToString());
            dt = objregister.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
           
            dt = objregister.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();

           
            dt = objregister.PlantName(intUnitID);
            DdlPlantF.DataSource = dt;
            DdlPlantF.DataTextField = "Name";
            DdlPlantF.DataValueField = "Id";
            DdlPlantF.DataBind();

            DdlPlantF.Items.Insert(0, new ListItem("None", "0"));
            dt.Clear();
        }



        protected void Tab1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\fromassetRegisterUi Tab1_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = 1;
            intItem = 47;
            dt = objregister.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {

                loadTab1FactoryReg();

                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 0;

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

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

        protected void Tab2_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = 2;
            intItem = 47;
            dt = objregister.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {

                loadTab2VehicleReg();
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 1;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }



        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = 3;
            intItem = 47;
            dt = new DataTable();
            dt = objregister.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {
                loadTab3LandReg();
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 2;

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

            }

        }
        protected void Tab4_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\FormAssetRegisterUI Tab4_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                dt = new DataTable();
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = 4;
            intItem = 47;
            dt = objregister.TabPermission(intItem, Mnumber, intenroll, intjobid, intdept, assetcode);
            if (dt.Rows.Count > 0)
            {

                loadTab4BuildingReg();
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Clicked";
                MainView.ActiveViewIndex = 3;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no Permission');", true);

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
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string barCode = TxtAssetDescription.Text;

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();

            using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
            {

                using (Graphics graphics = Graphics.FromImage(bitMap))
                {

                    Font oFont = new Font("IDAutomationHC39M", 16);

                    PointF point = new PointF(2f, 2f);

                    SolidBrush blackBrush = new SolidBrush(Color.Black);

                    SolidBrush whiteBrush = new SolidBrush(Color.White);

                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);

                }

                using (MemoryStream ms = new MemoryStream())
                {

                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] byteImage = ms.ToArray();



                    Convert.ToBase64String(byteImage);

                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                }

                plBarCode.Controls.Add(imgBarCode);
            }
        }

        public System.Drawing.Image bitMap { get; set; }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
             int Costcenterid; int Plantname; int category; int assettype; 
             
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            int intenrollid = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


            int unit = int.Parse(DdlUnit.SelectedValue.ToString());
            int jobstation = int.Parse(DlJobStation.SelectedValue.ToString());
            try { assettype = int.Parse(DdlAssetType.Text.ToString()); }
            catch { assettype = int.Parse(0.ToString()); }
            string assetname = TxtAssetName.Text.ToString(); ;
            string assetid = (DdlDept.Text.ToString());
            string hscode = (TxtHSCode.Text.ToString());
            string description = TxtAssetDescription.Text.ToString();
            string manufacture = TxtManufacturer.Text.ToString();
            string countryorigin = TxtContryOrigin.Text.ToString();
            string countrymanufacture = TxtCountryManufacture.Text.ToString();
            string supplier = TxtSuppName.Text.ToString();
            try {  category = int.Parse(DdlCategory.SelectedValue.ToString()); }
            catch { category = int.Parse(0.ToString()); }
            string lcno = TxtLCNo.Text.ToString();

            //DateTime dtelc = DateTime.Parse(TxtDteLC.Text);
            try { dtelc = DateTime.Parse(TxtDteLC.Text.ToString()); }
            catch {}

            string pono = TxtPONo.Text.ToString();
            //DateTime dtepo = DateTime.Parse(TxtDtePo.Text);
            try { dtepo = DateTime.Parse(TxtDtePo.Text.ToString()); }
            catch {   }

            //DateTime WarrintyPreoid = DateTime.Parse(TxtDteWarranty.Text);
            try { WarrintyPreoid = DateTime.Parse(TxtDteWarranty.Text.ToString()); }
             catch {   }

            try { invoicevalue = Decimal.Parse(TxtInvoice.Text.ToString()); } catch { }
            string incortms = DdlInCoterms.SelectedItem.ToString();
            string location = TxtInsLocation.Text.ToString();
            string ManuProSL = TxtManuProvideSl.Text.ToString();
            string function = TxtFunction.Text.ToString();
            string capacity = TxtCapacity.Text.ToString();
            try { dteinstalation = DateTime.Parse(TxtDteInstalation.Text); } catch { }
            try { erectioncost = Decimal.Parse(TxtErectionCost.Text.ToString()); } catch { }
            try { department = int.Parse(DdlDept.SelectedValue.ToString()); } catch { }

            //DateTime dteacusition = DateTime.Parse(TxtDteAcusition.Text);
            try { dteacusition = DateTime.Parse(TxtDteAcusition.Text.ToString()); }
            catch { dteacusition = DateTime.Parse("1900-01-01"); }
           
             try { Costcenterid = int.Parse(DdlCostCenterF.SelectedValue.ToString()); }
            catch { Costcenterid = int.Parse(0.ToString()); }
             try { Plantname = int.Parse(DdlPlantF.SelectedValue.ToString()); }
             catch { Plantname = int.Parse(0.ToString()); }
             string maintType=DdlMainType.SelectedItem.ToString();


            string life = TxtRecomandLife.Text.ToString();

            try { salvage = Decimal.Parse(TxtEstSalvageValue.Text.ToString()); } catch { }
            try { landedC = Decimal.Parse(TxtLandedCost.Text.ToString()); } catch { }
            try { TAccumulatedC = Decimal.Parse(TxtTAccumulatedCost.Text.ToString()); } catch { }
            try { RateDepriciation = Decimal.Parse(TxtRateDepeciation.Text.ToString()); } catch { }
            try {   AccumulatedDepriciation = decimal.Parse(TxtAccumulatedDepreciation.Text.ToString()); } catch { }
            string MethodDep = TxtMethodDepreciation.Text.ToString();
            try { ValueAfterDep = Decimal.Parse(TxtValueDepreciation.Text.ToString()); } catch { }
            try { writedownv = Decimal.Parse(TxtWrittenDownValue.Text.ToString()); } catch { }
            string remarks = TxtRemarks.Text.ToString();
            string currency = DdlCurrency.SelectedItem.ToString();


            try { accudepreciation = Decimal.Parse(TxtAccumulatedDepreciation.Text.ToString()); } catch { }
            string methoddepreciation = TxtMethodDepreciation.Text.ToString();
            try { wdownvalue = Decimal.Parse(TxtWrittenDownValue.Text.ToString()); } catch { }
            string fmodel = TxtFModel.Text.ToString();

            dt = objregister.ChecklSerialNumber(jobstation, ManuProSL);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('All ready Inserted Manufacturer Provided SL No ');", true);

            }
           
            else
            {
                dt.Clear();
                dt = objregister.RegistrationDataInsert(unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, WarrintyPreoid, invoicevalue, incortms, location, ManuProSL, function, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, maintType, Plantname, Costcenterid, fmodel);

                if (dt.Rows.Count > 0)
                {

                    data = dt.Rows[0]["AutoNumber"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('AutoGenerated '+'ID Numeber   '+''+'" + data + "');", true);
                }



             

                string barCode = data;

                using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
                {

                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {

                        Font oFont = new Font("IDAutomationHC39M", 16);

                        PointF point = new PointF(2f, 2f);

                        SolidBrush blackBrush = new SolidBrush(Color.Black);

                        SolidBrush whiteBrush = new SolidBrush(Color.White);

                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);

                    }

                    using (MemoryStream ms = new MemoryStream())
                    {

                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        byte[] byteImage = ms.ToArray();



                        Convert.ToBase64String(byteImage);

                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                    }

                    plBarCode.Controls.Add(imgBarCode);
                }
            }
            TxtDteInstalation.Text = "";
            TxtAssetName.Text = "";
            //TxtHSCode.Text = "";
            //TxtAssetDescription.Text = "";
            //TxtManufacturer.Text = "";
            //TxtSuppName.Text = "";
            //TxtLCNo.Text = "";
            //TxtPONo.Text = "";

            //TxtInsLocation.Text = "";
            TxtManuProvideSl.Text = "";
            //TxtFunction.Text = "";
            //TxtCapacity.Text = "";
            //TxtErectionCost.Text = "";
            //TxtRecomandLife.Text = "";
            TxtEstSalvageValue.Text = "0";
            TxtLandedCost.Text = "0";
            TxtTAccumulatedCost.Text = "0";
            TxtMethodDepreciation.Text = "";
            TxtValueDepreciation.Text = "0";
            TxtWrittenDownValue.Text = "0";
            TxtRemarks.Text = "0";
            TxtErectionCost.Text = "0";


        }

        protected void DdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse(DdlUnit.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode); 
           Int32 unitid = Int32.Parse(DdlUnit.SelectedValue.ToString());
           // dt = objregister.Ljobstation(unitid);
            DlJobStation.DataSource = dt;
            DlJobStation.DataTextField = "strJobStationName";
            DlJobStation.DataValueField = "intEmployeeJobStationId";
            DlJobStation.DataBind();
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(DlJobStation.SelectedValue.ToString());
            dt = objregister.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
          
            dt = new DataTable();
            Int32 intUnitID = Int32.Parse(DdlUnit.SelectedValue.ToString());
            dt = objregister.RegCostCenter(intUnitID);
            DdlCostCenterF.DataSource = dt;
            DdlCostCenterF.DataTextField = "Name";
            DdlCostCenterF.DataValueField = "Id";
            DdlCostCenterF.DataBind();

            dt = new DataTable();
           
            dt = objregister.PlantName(intUnitID);
            DdlPlantF.DataSource = dt;
            DdlPlantF.DataTextField = "Name";
            DdlPlantF.DataValueField = "Id";
            DdlPlantF.DataBind();
            DdlPlantF.Items.Insert(0, new ListItem("None", "0"));


            
         


           
        }

        protected void DdlUnitLand_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            Int32 Unitland = Int32.Parse(DdlUnitLand.SelectedValue.ToString());
            dt = new DataTable();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse(DdlUnitLand.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode); 

            // dt = objregister.Ljobstation(Unitland);
            DdlJobland.DataSource = dt;
            DdlJobland.DataTextField = "strJobStationName";
            DdlJobland.DataValueField = "intEmployeeJobStationID";
            DdlJobland.DataBind();

        }

    


        protected void Ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 districtss = Int32.Parse(Ddldistrict.SelectedValue.ToString());
            dt = objregister.Thanadrodownview(districtss);
            DDlThana.DataSource = dt;
            DDlThana.DataTextField = "strDistrictBanglaName";
            DDlThana.DataValueField = "intDistrictIDs";
            DDlThana.DataBind();

        }
        protected void DlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(DlJobStation.SelectedValue.ToString());
            dt = objregister.DepertmentName(jobstation);
            DdlDept.DataSource = dt;
            DdlDept.DataTextField = "strDepatrment";
            DdlDept.DataValueField = "intDepartmentID";
            DdlDept.DataBind();
            dt = new DataTable();
            dt = objregister.DropdownCategoryView(jobstation);
            DdlCategory.DataSource = dt;
            DdlCategory.DataTextField = "strCategoryName";
            DdlCategory.DataValueField = "intCategoryID";
            DdlCategory.DataBind();
            
            //dt = new DataTable();
            //Int32 intjobid = Int32.Parse(DlJobStation.SelectedValue.ToString());
            //dt = objregister.PlantName(intjobid);
            //DdlPlantF.DataSource = dt;
            //DdlPlantF.DataTextField = "Name";
            //DdlPlantF.DataValueField = "Id";
            //DdlPlantF.DataBind();

        }

        

        protected void BtnVechileSave_Click(object sender, EventArgs e)
        {

            
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            DateTime dtelc; DateTime dtepo; DateTime dteacusition; DateTime DteTaxToken;
            DateTime dtefitness; DateTime dteInsurance; DateTime WarrintyPreoid;
            DateTime RootPermit;

            Int32 intenrollid = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


            Int32 unit = Int32.Parse(ddlUnits.SelectedValue.ToString());
            Int32 jobstation = Int32.Parse(Ddljob.SelectedValue.ToString());
            Int32 assettype = Int32.Parse(DdlAsetTypes.Text.ToString());
            String assetname = TxtVechilReg.Text.ToString();
            Int32 category = Int32.Parse(DdlAssetCate.SelectedValue.ToString());
            //string assetid = (DdlDept.Text.ToString());
            string hscode = (TxtHSCodes.Text.ToString());
            String description = TxtDscVechile.Text.ToString();
            String manufacture = TxtManuFactrurer.Text.ToString();
            String countryorigin = TxtOrigin.Text.ToString();
            string countrymanufacture = TxtCountryManu.Text.ToString();
            String supplier = TxtSupplier.Text.ToString();

            String lcno = TxtLcNumbers.Text.ToString();

            String pono = TxtPonumber.Text.ToString();

            Decimal invoicevalue = Decimal.Parse(TxtInvoices.Text.ToString());
            string currency = DdlCurrency.SelectedItem.ToString();
            string incortms = DdlIncotermsd.SelectedItem.ToString();

            String servicetype = DdlServiceType.SelectedItem.ToString();
            string brand = DdlBrand.SelectedItem.ToString();
            String model = TxtModel.Text.ToString();
            string cc = TxtCC.Text.ToString();
            string color = DDlColor.SelectedItem.ToString();
            string Engine = TxtEngine.Text.ToString();
            string chasis = TxtCassis.Text.ToString();
            string inetialMilege = TxtInitialM.Text.ToString();
            string fuelstats = DdlFuelStatus.SelectedItem.ToString();



            string insuranceName = DdlInsurance.SelectedItem.Text.ToString();
           // string rootname = TxtRoot.Text.ToString();
            try { RootPermit = DateTime.Parse(TxtDteRoot.Text); }
            catch { RootPermit = DateTime.Parse("1900-01-01"); }
            String location = TxtInsLocation.Text.ToString();


            Int32 department = Int32.Parse(DdlDepartments.SelectedValue.ToString());



            String life = TxtRecommand.Text.ToString();

            Decimal salvage = Decimal.Parse(TxtEstSalvase.Text.ToString());
            Decimal landedC = Decimal.Parse(TxtLandedCosts.Text.ToString());
            Decimal TAccumulatedC = Decimal.Parse(Txttotalcost.Text.ToString());
            Decimal RateDepriciation = Decimal.Parse(TxtRateDepriciation.Text.ToString());
            Decimal AccumulatedDepriciation = decimal.Parse(TxtTotalAccumatleted.Text.ToString());

            Decimal ValueAfterDep = Decimal.Parse(TxtValueAfterDep.Text.ToString());
            Decimal writedownv = Decimal.Parse(TxtWritenDownValue.Text.ToString());


            string remarks = TxtRemarksd.Text.ToString();
            String MethodDep = TxtMethode.Text.ToString();
            String ManuProSL = TxtVechilReg.Text.ToString();


            string capacity = TxtModelYear.Text.ToString();
            DateTime dteinstalation = DateTime.Parse("2016-10-10".ToString());
            Decimal erectioncost = Decimal.Parse("0".ToString());


            try { Int32 exixtingV = Int32.Parse(DdlExixtingVehicle.SelectedValue.ToString()); }
            catch {  exixtingV = 0; }

            Int32 txtUsername = Int32.Parse(txtUser.Text.ToString());

            try { dtepo = DateTime.Parse(TxtVPoDate.Text); }
            catch {dtepo = DateTime.Parse("1900-01-01");}

            try {dtelc = DateTime.Parse(TxtDteVLcDate.Text);}
            catch {dtelc = DateTime.Parse("1900-01-01");}

            try { WarrintyPreoid = DateTime.Parse(TxtDteVWarranty.Text); }
            catch { WarrintyPreoid = DateTime.Parse("1900-01-01"); }

            try {  dteacusition = DateTime.Parse(TxtDteAccusition.Text); }
            catch { dteacusition = DateTime.Parse("1900-01-01"); }


            string alertdate=TxtDteReg.Text.ToString();
            try {  DteTaxToken = DateTime.Parse(TxtDteToken.Text); }
            catch { DteTaxToken = DateTime.Parse("1900-01-01"); }

            try {  dtefitness = DateTime.Parse(TxtDteFitness.Text); }
            catch { dtefitness = DateTime.Parse("1900-01-01"); }
            try {  dteInsurance = DateTime.Parse(TxtDteInsurance.Text); }
            catch { dteInsurance = DateTime.Parse("1900-01-01"); }

            string city = DvehicleArea.SelectedItem.ToString();
            string indenty = Ddlindentity.SelectedItem.ToString();
            string beginno = ddlBeginNo.SelectedItem.ToString();
            string policyT = DdlpolicyType.SelectedItem.ToString();
            string poliNmae = Txtpolicy.Text.ToString();
            string unloadin = TxtUnladanW.Text.ToString();
            string loaden = TxtladenW.Text.ToString();
            string check = (city + ' ' + indenty + '-' + beginno + '-' + assetname).ToString();
            if (assetname != "" && assetname.Length >= 4 && alertdate!="")
            {
                DateTime DteRegistration = DateTime.Parse(TxtDteReg.Text);

                dt = new DataTable();

                dt = objregister.ChecklVechicleSerialNumber(check);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('All ready Inserted Vehicle Reg No ');", true);

                }

                else
                {
                    dt = new DataTable();
                    intpart = 2;
                    dt = objregister.VehicleRegistrationDataInsert(intpart, unit, jobstation, assettype, assetname, hscode, description, manufacture, countryorigin, countrymanufacture, supplier, category, lcno, dtelc, pono, dtepo, WarrintyPreoid, invoicevalue, incortms, location, ManuProSL, capacity, dteinstalation, erectioncost, department, dteacusition, life, salvage, landedC, TAccumulatedC, RateDepriciation, AccumulatedDepriciation, MethodDep, ValueAfterDep, writedownv, remarks, intjobid, intenrollid, intunitid, currency, servicetype, brand, model, cc, color, Engine, chasis, inetialMilege, fuelstats, txtUsername, policyT, DteRegistration, DteTaxToken, dtefitness, dteInsurance, insuranceName, poliNmae, RootPermit, exixtingV, city, indenty, beginno, unloadin, loaden);

                    if (dt.Rows.Count > 0)
                    {


                        data = dt.Rows[0]["AutoNumber"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('AutoGenerated '+'Asset ID Numeber   '+''+'" + data + "'+' Vehicle Number '+'" + check + "');", true);

                    }
                    dt = new DataTable();
                    //Reload existing vehicle//
                    Int32 Unitid = Int32.Parse(ddlUnits.SelectedValue.ToString());

                    dt = objregister.ExistingVehicleshow(Unitid);
                    DdlExixtingVehicle.DataSource = dt;
                    DdlExixtingVehicle.DataTextField = "strRegNo";
                    DdlExixtingVehicle.DataValueField = "intID";
                    DdlExixtingVehicle.DataBind();
                    TxtVechilReg.Text = "";
                    TxtValueAfterDep.Text = "0"; TxtWritenDownValue.Text = "0"; TxtTotalAccumatleted.Text = "0"; TxtRateDepriciation.Text = "0";
                    Txttotalcost.Text = "0"; TxtLandedCosts.Text = "0"; TxtEstSalvase.Text = "0";
                    //TxtVPoDate.Text = "1990-01-01"; TxtDteVWarranty.Text = "1990-01-01"; TxtDteAccusition.Text = "1990-01-01"; TxtDteToken.Text = "1990-01-01";
                    //TxtDteFitness.Text = "1990-01-01"; TxtDteInsurance.Text = "1990-01-01"; TxtDteVLcDate.Text = "1990-01-01";TxtDteRoot.Text = "1990-01-01";
                    TxtInvoices.Text = "0"; 
                    txtUser.Text = "0"; 
                    TxtDteReg.BorderColor = System.Drawing.Color.Gray;
                    TxtVechilReg.BorderColor = System.Drawing.Color.Gray;
                    string barCode = data;

                    using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
                    {

                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {

                            Font oFont = new Font("IDAutomationHC39M", 16);

                            PointF point = new PointF(2f, 2f);

                            SolidBrush blackBrush = new SolidBrush(Color.Black);

                            SolidBrush whiteBrush = new SolidBrush(Color.White);

                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                            graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);

                        }

                        using (MemoryStream ms = new MemoryStream())
                        {

                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                            byte[] byteImage = ms.ToArray();



                            Convert.ToBase64String(byteImage);

                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                        }

                        PlaceHolder2.Controls.Add(imgBarCode);
                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill up End Number & Minimum Length 4 ');", true);
               
                TxtDteReg.BorderColor = System.Drawing.Color.Gray;
                TxtVechilReg.BorderColor = System.Drawing.Color.Gray;
                if (assetname== "" || assetname.Length <4)
                { TxtVechilReg.BorderColor = System.Drawing.Color.Red; }
                
                if (alertdate == "")
                {
                    TxtDteReg.BorderColor = System.Drawing.Color.Red;
                   
                }
            }
        }

        protected void BtnLand_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            if (hdnconfirm.Value == "1")
            {
                if (grdvassetinfo.Rows.Count > 0)
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
                    string landpo = LandPo.Text.ToString();
                    string landbayername = TxtBuyer.Text.ToString();
                    string nameseller = TxtNameofSeller.Text.ToString();
                    string landclass = DdlClass.SelectedItem.ToString();
                    Int32 district = Int32.Parse(Ddldistrict.SelectedValue.ToString());
                    Int32 Thana = Int32.Parse(DDlThana.SelectedValue.ToString());
                    string mouja = TxtMouza.Text.ToString();
                    string CSKatian = "0";

                    string SaKatian = "0";
                    string RSKathin = "0";
                    string DSKathian = "0";
                    string DpKatian = "0";
                    string CSDagNo = "0";
                    string SADagNo = "0";

                    string RSDagNo = "0";
                    string DSDagNo = "0";
                    string DPDagNo = "0";
                    string DeedReceoiptNo = TxtDeedReceoiptNo.Text.ToString();
                    string DeedNo = TxtDeedNo.Text.ToString();
                    //TotalArea,TotalArealandinDecimal,PricePerKatha,PriceperDecimal,

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
                    intpart = 3;
                    dt = new DataTable();
                    dt = objregister.LandRegistration(intpart, UnitLand, Jobland, AssetTypeLand, AssetLand, descriptionL, landpo, landbayername, nameseller, landclass, district, Thana, mouja, CSKatian, SaKatian, RSKathin, DSKathian, DpKatian, CSDagNo, SADagNo, RSDagNo, DSDagNo, DPDagNo, DeedReceoiptNo, DeedNo, DeedDate, DeedCertifyreceivedate, OrginalDeedReceiveDate, TotalArea, TotalArealandinDecimal, PricePerKatha, PriceperDecimal, TotalValuelandTk, RegistryBainaAmount, BalancelandValue, RegistrationExpance, DeedValueLand, LandofficevolumeCheckingexp, Nfees, LocalgovtTax, Stamp, IncomeTax, GainTax, PayOrderExpense, SubRegisterCommission, DeedCertifiescopyExpance, MutionExpanse, OtherExpanse, TotalArealandMuted, Jlno, HoldingNoJotNo, LandDevlopmentTaxExpance, BrokrCommission, TotalLandAccusitionCost, intenrollid, intunitid, intjobid);
                    if (dt.Rows.Count > 0)
                    {

                        data = dt.Rows[0]["AutoNumber"].ToString();
                        //Session["data"] = data;

                        if (grdvassetinfo.Rows.Count > 0)
                        {
                            #region ------------ Insert into dataBase -----------


                            hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                            Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);

                            HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                            int unit = Convert.ToInt32(HiddenUnit.Value);
                            hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                            int jobstation = Convert.ToInt32(hdnstation.Value);
                            string assetid = data;
                            XmlDocument doc = new XmlDocument();
                            try
                            {
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("AssetInformation");
                                string xmlString = dSftTm.InnerXml;
                                xmlString = "<AssetInformation>" + xmlString + "</AssetInformation>";
                                string message = bllaset.FixedDataLandInfoinsert(xmlString, enroll, unit, jobstation, assetid);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            }

                            catch
                            {

                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                            }
                            #endregion ------------ Insertion End ----------------


                        }


                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('AutoGenerated '+'ID Numeber   '+''+'" + data + "');", true);


                    }
                    grdvassetinfo.DataBind();
                    File.Delete(filePathForXML);
                    grdvassetinfo.DataSource = "";
                    grdvassetinfo.DataBind();

                    DteDeedDate.Text = "";
                    dteDeedCertifyreceivedate.Text = "";
                    TxtAssetLand.Text = "";
                    string barCode = data;


                    using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
                    {

                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {

                            Font oFont = new Font("IDAutomationHC39M", 16);

                            PointF point = new PointF(2f, 2f);

                            SolidBrush blackBrush = new SolidBrush(Color.Black);

                            SolidBrush whiteBrush = new SolidBrush(Color.White);

                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                            graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);

                        }

                        using (MemoryStream ms = new MemoryStream())
                        {

                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                            byte[] byteImage = ms.ToArray();



                            Convert.ToBase64String(byteImage);

                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                        }

                        PlaceHolder3.Controls.Add(imgBarCode);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You must click add button');", true);

                }


            }




        }

        protected void BtnBuilding_Click(object sender, EventArgs e)
        { var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CommonRepaisListPopUp BtnBuilding_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            DateTime PoDate, porjectstardtDate, deliverydate; decimal estimaticost, estmateconstriuction, actualconstruction, totalAccumulatedCost;
           
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 unit = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());
            Int32 jobstation = Int32.Parse(DdlbuildJobstation.SelectedValue.ToString());
            Int32 assettype = Int32.Parse(DdlBuildAssetType.SelectedValue.ToString());
            String assetname = TxtNameStructer.Text.ToString(); 
            string BDescription = TxtBDescription.Text.ToString();
            string Requestby = TxtRequestBy.Text.ToString();
            string RequestApproved = TxtBapproveBy.Text.ToString();
            string Blocation = TxtLocation.Text.ToString();
            string BPoNO = TxtBPoNo.Text.ToString();

            try { PoDate = DateTime.Parse(TxtDteBPodate.Text); }
            catch { PoDate = DateTime.Parse("1990-01-01".ToString()); }
            try
            {
                porjectstardtDate = DateTime.Parse(TxtdteProjectStart.Text);
            }
            catch { porjectstardtDate = DateTime.Parse("1990-01-01".ToString()); }
             
            deliverydate = DateTime.Parse(TxtdteBDeliveryDate.Text); 
            
            
            string Length = TxtLength.Text.ToString();
            string Breadth = TxtBreadth.Text.ToString();
            string height = TxtHeight.Text.ToString();
            string totalarea = TxtBTotalArea.Text.ToString();
            try { estimaticost = decimal.Parse(TxtBEstimatedCost.Text.ToString()); }
            catch { estimaticost = decimal.Parse(0.ToString()); }
            try { estmateconstriuction = decimal.Parse(TxtBEstimatedConstruction.Text.ToString()); }
            catch { estmateconstriuction = decimal.Parse(0.ToString()); }
            try { actualconstruction = decimal.Parse(TxtActualConstruction.Text.ToString()); }
            catch { actualconstruction = decimal.Parse(0.ToString()); }
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

            try {totalAccumulatedCost = decimal.Parse(TxtTotalAccumulatedCost.Text.ToString()); }
            catch { totalAccumulatedCost = decimal.Parse(0.ToString()); }

            Int32 category = Int32.Parse(DdlBAssetCategory.Text.ToString());
            if (TxtNameStructer.Text == "")
            {
                TxtNameStructer.BorderColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Structure Name');", true);
            }
            else
            {
                intpart = 5;
                dt = new DataTable();
                dt = objregister.BuildingRegistration(intpart, unit, jobstation, assettype, assetname, BDescription, supplyby, category, BPoNO, PoDate, Blocation, Estimatedlife, Bremarks, Requestby, RequestApproved, porjectstardtDate, deliverydate, Length, Breadth, height, totalarea, estimaticost, estmateconstriuction, actualconstruction, year, Dept, funndingsouece, consultant, contractorname, renovationwork, approximiatly, renomateralis, intenroll, intjobid, projectnumber, totalAccumulatedCost);
                if (dt.Rows.Count > 0)
                {

                    data = dt.Rows[0]["AutoNumber"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('AutoGenerated '+'ID Numeber   '+''+'" + data + "');", true);

                }
            }
            TxtNameStructer.Text = "";
            string barCode = data;

            using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
            {

                using (Graphics graphics = Graphics.FromImage(bitMap))
                {

                    Font oFont = new Font("IDAutomationHC39M", 16);

                    PointF point = new PointF(2f, 2f);

                    SolidBrush blackBrush = new SolidBrush(Color.Black);

                    SolidBrush whiteBrush = new SolidBrush(Color.White);

                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);

                }

                using (MemoryStream ms = new MemoryStream())
                {

                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] byteImage = ms.ToArray();



                    Convert.ToBase64String(byteImage);

                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                }

                PlaceHolder4.Controls.Add(imgBarCode);
            }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void DdlBuildUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();

            Int32 Bnitland = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());

            
           
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse(DdlBuildUnit.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode);

            //dt = objregister.Ljobstation(Bnitland);
            DdlbuildJobstation.DataSource = dt;
            DdlbuildJobstation.DataTextField = "strJobStationName";
            DdlbuildJobstation.DataValueField = "intEmployeeJobStationID";
            DdlbuildJobstation.DataBind();

        }

        protected void Ddljob_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 jobstation = Int32.Parse(Ddljob.SelectedValue.ToString());
            dt = objregister.DepertmentName(jobstation);
            DdlDepartments.DataSource = dt;
            DdlDepartments.DataTextField = "strDepatrment";
            DdlDepartments.DataValueField = "intDepartmentID";
            DdlDepartments.DataBind();
        }

        protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 Unitland = Int32.Parse(ddlUnits.SelectedValue.ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            Int32 Mnumber = Int32.Parse(ddlUnits.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode); ;
            // dt = objregister.Ljobstation(Unitland);
            Ddljob.DataSource = dt;
            Ddljob.DataTextField = "strJobStationName";
            Ddljob.DataValueField = "intEmployeeJobStationID";
            Ddljob.DataBind();

            Int32 Unitid = Int32.Parse(ddlUnits.SelectedValue.ToString());
            dt = new DataTable();
            dt = objregister.ExistingVehicleshow(Unitid);
            DdlExixtingVehicle.DataSource = dt;
            DdlExixtingVehicle.DataTextField = "strRegNo";
            DdlExixtingVehicle.DataValueField = "intID";
            DdlExixtingVehicle.DataBind();
         
        }
        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("AssetInformation");
                xmlString = dSftTm.InnerXml;
                xmlString = "<AssetInformation>" + xmlString + "</AssetInformation>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvassetinfo.DataSource = ds; }
                else { grdvassetinfo.DataSource = ""; }

                grdvassetinfo.DataBind();

            }
            catch { }
        }
        private void CreateVoucherXml(string dagcs, string dagsa, string dagrs, string dagbrs, string khatiancs, string khatiansa, string khatianrs, string khatianbrs)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("AssetInformation");
                XmlNode addItem = CreateItemNode(doc, dagcs, dagsa, dagrs, dagbrs, khatiancs, khatiansa, khatianrs, khatianbrs);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("AssetInformation");
                XmlNode addItem = CreateItemNode(doc, dagcs, dagsa, dagrs, dagbrs, khatiancs, khatiansa, khatianrs, khatianbrs);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string dagcs, string dagsa, string dagrs, string dagbrs, string khatiancs, string khatiansa, string khatianrs, string khatianbrs)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Dagcs = doc.CreateAttribute("dagcs");
            Dagcs.Value = dagcs;
            XmlAttribute Dagsa = doc.CreateAttribute("dagsa");
            Dagsa.Value = dagsa;
            XmlAttribute Dagrs = doc.CreateAttribute("dagrs");
            Dagrs.Value = dagrs;
            XmlAttribute Dagbrs = doc.CreateAttribute("dagbrs");
            Dagbrs.Value = dagbrs;

            XmlAttribute Khatiancs = doc.CreateAttribute("khatiancs");
            Khatiancs.Value = khatiancs;
            XmlAttribute Khatiansa = doc.CreateAttribute("khatiansa");
            Khatiansa.Value = khatiansa;
            XmlAttribute Khatianrs = doc.CreateAttribute("khatianrs");
            Khatianrs.Value = khatianrs;
            XmlAttribute Khatianbrs = doc.CreateAttribute("khatianbrs");
            Khatianbrs.Value = khatianbrs;

            node.Attributes.Append(Dagcs);
            node.Attributes.Append(Dagsa);
            node.Attributes.Append(Dagrs);
            node.Attributes.Append(Dagbrs);
            node.Attributes.Append(Khatiancs);
            node.Attributes.Append(Khatiansa);
            node.Attributes.Append(Khatianrs);
            node.Attributes.Append(Khatianbrs);
            return node;
        }
        private void Clear()
        {

            //txtdagcs.Text = "";
            txtdagsa.Text = ""; txtdagrs.Text = ""; txtdagbrs.Text = "";
            txtkhatiancs.Text = ""; txtkhatiansa.Text = ""; txtkhatianrs.Text = ""; txtkhatianbrs.Text = "";

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            //if (hdnconfirm.Value == "1")
            //{

                string strdagcs = txtdagcs.Text;
                string strdagsa = txtdagsa.Text;
                string strdagrs = txtdagrs.Text;
                string strdagbrs = txtdagbrs.Text;
                string strkhatiancs = txtkhatiancs.Text;
                string strkhatiansa = txtkhatiansa.Text;
                string strkhatianrs = txtkhatianrs.Text;
                string strkhatianbrs = txtkhatianbrs.Text;
                if (strdagcs.Length <= 0) { strdagcs = "0"; }
                if (strdagsa.Length <= 0) { strdagsa = "0"; }
                if (strdagrs.Length <= 0) { strdagrs = "0"; }
                if (strdagbrs.Length <= 0) { strdagbrs = "0"; }
                if (strkhatiancs.Length <= 0) { strkhatiancs = "0"; }
                if (strkhatiansa.Length <= 0) { strkhatiansa = "0"; }
                if (strkhatianrs.Length <= 0) { strkhatianrs = "0"; }
                if (strkhatianbrs.Length <= 0) { strkhatianbrs = "0"; }
                CreateVoucherXml(strdagcs, strdagsa, strdagrs, strdagbrs, strkhatiancs, strkhatiansa, strkhatianrs, strkhatianbrs);
            //}


        }

        protected void grdvassetinfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvassetinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvassetinfo.DataSource;
                dsGrid.Tables[0].Rows[grdvassetinfo.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvassetinfo.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvassetinfo.DataSource = ""; grdvassetinfo.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void TxtTotalArealandinDecimal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdagsa_TextChanged(object sender, EventArgs e)
        {
            //string strdagsa = txtdagcs.Text;
            //int dagsa = int.Parse(txtdagcs.Text);
            //dtinfo = bllaset.dagvslandstatus(dagsa);
            //lblTotalLanddata.Text = dtinfo.Rows[0][1].ToString().ToUpper();
            //lblpurchaseddata.Text = dtinfo.Rows[0][2].ToString();

            int dag;
            int dagtype = int.Parse(drdlDagforland.SelectedValue.ToString());
            if (dagtype == 1)
            {
                string strdagcs = txtdagcs.Text;
                if (strdagcs==""|| strdagcs.Length<0) { strdagcs = "0"; }
                dag = int.Parse(strdagcs);
                dtinfo = bllaset.dagvslandstatus(dag);
                if (dtinfo.Rows.Count > 0)
                {
                    TxtTotalArea.Text = dtinfo.Rows[0][2].ToString();
                    TxtTotalArealandinDecimal.Text = dtinfo.Rows[0][1].ToString();

                }
            }
            //else if (dagtype == 2)
            //{
            //    string strdagsa = txtdagsa.Text;
            //    if (strdagsa.Length < 0) { strdagsa = "0"; }
            //    dag = int.Parse(strdagsa);
            //}
            //else if (dagtype == 3)
            //{
            //    string strdagrs = txtdagcs.Text;
            //    if (strdagrs.Length < 0) { strdagrs = "0"; }
            //    dag = int.Parse(strdagrs);
            //}
            //else
            //{
            //    string strdagbrs = txtdagcs.Text;
            //    if (strdagbrs.Length < 0) { strdagbrs = "0"; }
            //    dag = int.Parse(strdagbrs);
            //}
         
            


        }

        protected void drdlDagforland_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dag;

            int dagtype = int.Parse(drdlDagforland.SelectedValue.ToString());
            if (dagtype == 1)
            {
                string strdagcs = txtdagcs.Text;
                if (strdagcs == "" || strdagcs.Length < 0) { strdagcs = "0"; }
                dag = int.Parse(strdagcs);
            }
            else if (dagtype == 2)
            {
                string strdagsa = txtdagsa.Text;
                if (strdagsa == "" || strdagsa.Length < 0) { strdagsa = "0"; }
                dag = int.Parse(strdagsa);
            }
            else if (dagtype == 3)
            {
                string strdagrs = txtdagcs.Text;
                if (strdagrs == "" || strdagrs.Length < 0) { strdagrs = "0"; }
                dag = int.Parse(strdagrs);
            }
            else
            {
                string strdagbrs = txtdagcs.Text;
                if (strdagbrs == "" || strdagbrs.Length < 0) { strdagbrs = "0"; }
                dag = int.Parse(strdagbrs);
            }

            dtinfo = bllaset.dagvslandstatus(dag);
            if (dtinfo.Rows.Count > 0)
            {
                TxtTotalArea.Text = dtinfo.Rows[0][2].ToString();
                TxtTotalArealandinDecimal.Text = dtinfo.Rows[0][1].ToString();

            }



        }

        protected void txtdagrs_TextChanged(object sender, EventArgs e)
        {
            int dag;
            int dagtype = int.Parse(drdlDagforland.SelectedValue.ToString());
            if (dagtype == 2)
            {
                string strdagsa = txtdagsa.Text;
                if (strdagsa.Length < 0) { strdagsa = "0"; }
                dag = int.Parse(strdagsa);
                dtinfo = bllaset.dagvslandstatus(dag);
                if (dtinfo.Rows.Count > 0)
                {
                    TxtTotalArea.Text = dtinfo.Rows[0][2].ToString();
                    TxtTotalArealandinDecimal.Text = dtinfo.Rows[0][1].ToString();

                }
            }
        }

        protected void txtdagbrs_TextChanged(object sender, EventArgs e)
        {
            int dag;
            int dagtype = int.Parse(drdlDagforland.SelectedValue.ToString());
            if (dagtype == 3)
            {
                string strdagrs = txtdagsa.Text;
                if (strdagrs.Length < 0) { strdagrs = "0"; }
                dag = int.Parse(strdagrs);
                dtinfo = bllaset.dagvslandstatus(dag);
                if (dtinfo.Rows.Count > 0)
                {
                    TxtTotalArea.Text = dtinfo.Rows[0][2].ToString();
                    TxtTotalArealandinDecimal.Text = dtinfo.Rows[0][1].ToString();

                }
            }
        }

        protected void txtkhatiancs_TextChanged(object sender, EventArgs e)
        {
        //    int dag;
        //    int dagtype = int.Parse(drdlDagforland.SelectedValue.ToString());
        //    if (dagtype == 4)
        //    {
        //        string strdagbrs = txtdagsa.Text;
        //        if (strdagbrs.Length < 0) { strdagbrs = "0"; }
        //        dag = int.Parse(strdagbrs);
        //        dtinfo = bllaset.dagvslandstatus(dag);
        //        if (dtinfo.Rows.Count > 0)
        //        {
        //            TxtTotalArea.Text = dtinfo.Rows[0][2].ToString();
        //            TxtTotalArealandinDecimal.Text = dtinfo.Rows[0][1].ToString();

        //        }
           //}
        }
    }
}
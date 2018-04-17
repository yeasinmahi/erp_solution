using Purchase_BLL.Asset;
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

namespace UI.Asset
{
    public partial class CwipAssetParking : System.Web.UI.Page
    {
        string filePathForXMlAssetParking, filePathXMlCwipLand;
        string XMLVehicle, XMLBuilding, XMLLand; int enroll; decimal recieveqty;
        string xmlStringG = ""; string xmlStringDag = "";
        AssetParking_BLL parking = new AssetParking_BLL();
        Assetregister_BLL objregister = new Assetregister_BLL();
        DataTable dt = new DataTable();

        int unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, ponumber, userenroll, depMethode;
        decimal invoicevalue, landedcost, otherCost, accusitioncost, depRate, recommandlife;

        decimal csdagno, tCsDag, sadDagNo, tSaDag, rsDagNo, tRsDag, brsDagno, tBrsDag, dpDagno, tDpDagno;


        DateTime dtePo, dteWarranty, detInstalation, issudate, grnDate, servicedate, dteDepRunDate;
        string suppliers, lcoation, remarks, assetname, description, hscodecountryorigin, manufacturer, provideSlnumber, modelono, lcnumber, others, capacity;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMlAssetParking = Server.MapPath("~/Asset/Data/cw_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathXMlCwipLand = Server.MapPath("~/Asset/Data/cwl_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            // try { File.Delete(filePathForXMlAssetParking); }
            // catch { }

            if (!IsPostBack)
            {




                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                dt = parking.CwipAssetView(2, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intuntid);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();



            }
            else
            {
                
            }
        }



        #region ==============================Vehicle Asset==========================
        private void VehicleAssetInfoLoad()
        {
            dt = new DataTable();
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = Int32.Parse("1".ToString());
            dt = objregister.VehicleRegisterArea();
            ddlCity.DataSource = dt;
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();

            dt = new DataTable();
            dt = objregister.VehicleBrand();
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "name";
            ddlBrand.DataValueField = "id";
            ddlBrand.DataBind();

            dt = new DataTable();
            dt = objregister.MotorVehicleTypes();
            ddlMajorCatV.DataSource = dt;
            ddlMajorCatV.DataTextField = "strAssetTypeName";
            ddlMajorCatV.DataValueField = "intAssetTypeID";
            ddlMajorCatV.DataBind();

            dt = new DataTable();
            dt = objregister.IndendityfiactionNumber();
            ddlIdentifire.DataSource = dt;
            ddlIdentifire.DataTextField = "name";
            ddlIdentifire.DataValueField = "id";
            ddlIdentifire.DataBind();

            dt = new DataTable();
            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlUnitV.DataSource = dt;
            ddlUnitV.DataTextField = "strUnit";
            ddlUnitV.DataValueField = "intUnitID";
            ddlUnitV.DataBind();

            Mnumber = int.Parse(ddlUnitV.SelectedValue.ToString());

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlJobstationV.DataSource = dt;
            ddlJobstationV.DataTextField = "strJobStationName";
            ddlJobstationV.DataValueField = "intEmployeeJobStationId";
            ddlJobstationV.DataBind();
            dt = new DataTable();
            int jobstation = int.Parse(ddlJobstationV.SelectedValue.ToString());
            int VehicleCat = int.Parse(8.ToString());
            // dt = objregister.DropdownCategoryView(VehicleCat);
            dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(ddlMajorCatV.SelectedValue), jobstation);//Parking List
            ddlMinorCate1V.DataSource = dt;
            ddlMinorCate1V.DataTextField = "strCategoryName";
            ddlMinorCate1V.DataValueField = "intCategoryID";
            ddlMinorCate1V.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlMinorCate2V.DataSource = dt;
            ddlMinorCate2V.DataTextField = "Name";
            ddlMinorCate2V.DataValueField = "ID";
            ddlMinorCate2V.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlUnitV.SelectedValue));
            ddlCostCenterV.DataSource = dt;
            ddlCostCenterV.DataTextField = "Name";
            ddlCostCenterV.DataValueField = "Id";
            ddlCostCenterV.DataBind();

            try
            {



                int intAutoID = int.Parse(hdnReceive.Value);
                DataTable pk = new DataTable();
                pk = parking.CwipAssetView(3, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intAutoID);
                if (pk.Rows.Count > 0)
                {


                    try { ddlUnitV.SelectedValue = pk.Rows[0]["intUnit"].ToString(); }
                    catch { }
                    try
                    {
                        dt = objregister.JobstationName(8, int.Parse(ddlUnitV.SelectedValue), intenroll, intjobid, intdept, "0");
                        ddlJobstationV.DataSource = dt;
                        ddlJobstationV.DataTextField = "strJobStationName";
                        ddlJobstationV.DataValueField = "intEmployeeJobStationId";
                        ddlJobstationV.DataBind();
                    }
                    catch { }
                    try { ddlJobstationV.SelectedValue = pk.Rows[0]["intjobstationid"].ToString(); } catch { }
                    try { ddlAssetType.SelectedValue = pk.Rows[0]["intMaintype"].ToString(); } catch { }
                    try { ddlMajorCat.SelectedValue = pk.Rows[0]["intAssetType"].ToString(); } catch { }

                    dt = objregister.DropdownCategoryView(int.Parse(ddlJobstationV.SelectedValue));
                    dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(pk.Rows[0]["intAssetType"].ToString()), int.Parse(ddlJobstationV.SelectedValue));//Parking List

                    ddlMinorCate1V.DataSource = dt;
                    ddlMinorCate1V.DataTextField = "strCategoryName";
                    ddlMinorCate1V.DataValueField = "intCategoryID";
                    ddlMinorCate1V.DataBind();





                    try { ddlMinorCate1V.SelectedValue = pk.Rows[0]["intMinorCatagory1"].ToString(); } catch { }

                    try { ddlMinorCate2V.SelectedValue = pk.Rows[0]["intMinorCatagory2"].ToString(); } catch { }





                    dt = objregister.RegCostCenter(int.Parse(ddlUnitV.SelectedValue));
                    ddlCostCenterV.DataSource = dt;
                    ddlCostCenterV.DataTextField = "Name";
                    ddlCostCenterV.DataValueField = "Id";
                    ddlCostCenterV.DataBind();

                    try
                    {
                        ddlCostCenterV.SelectedValue = pk.Rows[0]["intCostCenter"].ToString();
                    }
                    catch { }
                    txtAssetnameV.Text = pk.Rows[0]["strNameOfAsset"].ToString();

                    txtSuppliersV.Text = pk.Rows[0]["suppliers"].ToString();
                    txtPonumbersV.Text = pk.Rows[0]["intPoNumber"].ToString();
                    dtePoDateV.Text = pk.Rows[0]["dtePo"].ToString();
                    dteWarintyExpireV.Text = pk.Rows[0]["dteWarranty"].ToString();
                    txtDateInstalationV.Text = pk.Rows[0]["detInstalation"].ToString();
                    txtAssetLocationV.Text = pk.Rows[0]["strlcoation"].ToString();
                    txtEnrolmentV.Text = pk.Rows[0]["intUserEnroll"].ToString();
                    txtInvoiceValueV.Text = pk.Rows[0]["monInvoicevalue"].ToString();
                    txtLandedCostV.Text = pk.Rows[0]["monLandedcost"].ToString();
                    txtErectionOtherCostV.Text = pk.Rows[0]["monOtherCost"].ToString();
                    txtAcisitionCostV.Text = pk.Rows[0]["monAccusitioncost"].ToString();
                    txtRemarksV.Text = pk.Rows[0]["strRemarks"].ToString();


                    txtAssetname.Text = pk.Rows[0]["strNameOfAsset"].ToString();
                    txtDescriptionV.Text = pk.Rows[0]["strDescription"].ToString();
                    txtHsCodeV.Text = pk.Rows[0]["strHScode"].ToString();
                    txtIssueDateV.Text = pk.Rows[0]["dteIssudate"].ToString();
                    txtGrndDateV.Text = pk.Rows[0]["dteGRN"].ToString();
                    txtServiceDateV.Text = pk.Rows[0]["dteServicedate"].ToString();

                    txtCountryOriginV.Text = pk.Rows[0]["strCountryorigin"].ToString();
                    txtManufacturerV.Text = pk.Rows[0]["strManufacturer"].ToString();
                    txtManuProviceSlNoV.Text = pk.Rows[0]["strProvideSlnumber"].ToString();
                    txtModelNoV.Text = pk.Rows[0]["strModelono"].ToString();

                    txtLCnumberV.Text = pk.Rows[0]["strLcnumber"].ToString();
                    txtOthersV.Text = pk.Rows[0]["strOthers"].ToString();
                    txtCapacityV.Text = pk.Rows[0]["strCapacity"].ToString();
                    txtRecommandLifeV.Text = pk.Rows[0]["monRecommandlife"].ToString();
                    ddlMethodOfDepV.SelectedValue = pk.Rows[0]["intDepMethode"].ToString();
                    txtRateDepV.Text = pk.Rows[0]["monDepRate"].ToString();

                    txtDteDepRunV.Text = pk.Rows[0]["dteDepRun"].ToString();

                    try
                    {
                        txtProjectIDV.Text = pk.Rows[0]["projectid"].ToString();
                        txtProjectNameV.Text = pk.Rows[0]["projectName"].ToString();
                        txtAssetLocationV.Text = pk.Rows[0]["location"].ToString();
                    }
                    catch { }

                    try { invoicevalue = decimal.Parse(txtInvoiceValueV.Text); } catch { invoicevalue = 0; }
                    try { landedcost = decimal.Parse(txtLandedCostV.Text); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtErectionOtherCostV.Text); } catch { otherCost = 0; }
                    txtAcisitionCostV.Text = (landedcost + otherCost).ToString();
                    txtAcisitionCostV.ReadOnly = true;

                }

            }
            catch { };
        }

        protected void ddlUnitV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = int.Parse("1".ToString());
            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlJobstationV.DataSource = dt;
            ddlJobstationV.DataTextField = "strJobStationName";
            ddlJobstationV.DataValueField = "intEmployeeJobStationId";
            ddlJobstationV.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlUnitV.SelectedValue));
            ddlCostCenterV.DataSource = dt;
            ddlCostCenterV.DataTextField = "Name";
            ddlCostCenterV.DataValueField = "Id";
            ddlCostCenterV.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDivVehicle();", true);
        }

        private void VehicleAssetRegistration()
        {
            try
            {
                string unitV = ddlUnitV.SelectedValue.ToString();
                string assetNameV = txtAssetnameV.Text.ToString();
                string jobstationV = ddlJobstationV.SelectedValue.ToString();
                string descriptionV = txtDescriptionV.Text.ToString();
                string assetTypeV = ddlAssetTypeV.SelectedValue.ToString();
                string hsCodeV = txtHsCodeV.Text.ToString();
                string majorCategory = ddlMajorCatV.SelectedValue.ToString();
                string issuedatV = txtIssueDateV.Text.ToString();
                string minorCategoryV = ddlMinorCate1V.SelectedValue.ToString();
                string dteGRnDateV = txtGrndDateV.Text.ToString();
                string minorCategory2V = ddlMinorCate2V.SelectedValue.ToString();
                string dteServiceDateV = txtServiceDateV.Text.ToString();
                string costCenterV = ddlCostCenterV.SelectedValue.ToString();

                string projectid = txtProjectIDV.Text.ToString();
                string projectname = txtProjectNameV.Text.ToString();

               

                string cityV = ddlCity.SelectedItem.ToString();
                string identifireV = ddlIdentifire.SelectedItem.ToString();
                string serialV = ddlSerialNo.SelectedItem.ToString();
                string endnumber = txtEndNumber.Text.ToString();
                string brandNameV = ddlBrand.SelectedItem.ToString();
                string modelV = txtModelName.Text.ToString();
                string yearModelV = txtYearOfModel.Text.ToString();
                string ccV = txtCC.Text.ToString();
                string colorV = ddlColor.SelectedItem.ToString();
                string engineNo = txtEngineNo.Text.ToString();

                string chasisnoV = txtChassisNo.Text.ToString();
                string initialMileV = txtInitialMile.Text.ToString();
                string fuelstatusV = ddlFuelStatus.SelectedItem.ToString();
                string ulodaenWeight = txtUnladanWeight.Text.ToString();
                string ladenWeight = txtLadenWeight.Text.ToString();
                string supplierV = txtSuppliersV.Text.ToString();
                string countryOriginV = txtCountryOriginV.Text.ToString();
                string ponumberV = txtPonumbersV.Text.ToString();
                string mnanufactureV = txtManufacturerV.Text.ToString();
                string dtePodateV = dtePoDateV.Text.ToString();
                string provideSlNoV = txtManuProviceSlNoV.Text.ToString();
                string expirDateV = dteWarintyExpireV.Text.ToString();
                string modelNoV = txtModelNoV.Text.ToString();
                try { detInstalation = DateTime.Parse(txtDateInstalationV.Text); } catch { detInstalation = DateTime.Parse("1990-01-01".ToString()); }

                // string dteInstlationV = txtDateInstalationV.Text.ToString();
                string lcNumberV = txtLCnumberV.Text.ToString();
                string locationV = txtAssetLocationV.Text.ToString();
                string othersV = txtOthersV.Text.ToString();
               // string enrollV = txtEnrolmentV.Text.ToString();
                string capacityV = txtCapacityV.Text.ToString();

              //  string invoiceV = txtInvoiceValueV.Text.ToString();
               // string recommandV = txtRecommandLifeV.Text.ToString();
               // string landedCostV = txtLandedCostV.Text.ToString();
             //   string methodDepV = ddlMethodOfDepV.SelectedValue.ToString();
               // string erectionCostV = txtErectionOtherCostV.Text.ToString();
                //string rateofDepV = txtRateDepV.Text.ToString();
                //string acisitionCostV = txtAcisitionCostV.Text.ToString();
                string remarksV = txtRemarksV.Text.ToString();

              //  enrollV,invoiceV,landedCostV,erectionCostV,acisitionCostV
                try { userenroll = int.Parse(txtEnrolmentV.Text); } catch { userenroll = 0; }
                try { invoicevalue = decimal.Parse(txtInvoiceValueV.Text); } catch { invoicevalue = 0; }
                try { landedcost = decimal.Parse(txtLandedCostV.Text); } catch { landedcost = 0; }
                try { otherCost = decimal.Parse(txtErectionOtherCostV.Text); } catch { otherCost = 0; }
                try { accusitioncost = decimal.Parse(txtAcisitionCostV.Text); } catch { accusitioncost = 0; }

                try { recommandlife = decimal.Parse(txtRecommandLifeV.Text); } catch { recommandlife = 0; }
                try { depMethode = int.Parse(ddlMethodOfDepV.SelectedValue); } catch { depMethode = 0; }
                try { depRate = decimal.Parse(txtRateDepV.Text); } catch { depRate = 0; }
                try { dteDepRunDate = DateTime.Parse(txtDteDepRunV.Text); } catch { dteDepRunDate = DateTime.Parse("1990-01-01".ToString()); }
                string reffid = hdnReceive.Value;






                CreateXmlV(reffid,unitV, assetNameV, jobstationV, descriptionV, assetTypeV, hsCodeV, majorCategory, issuedatV, minorCategoryV, dteGRnDateV, minorCategory2V, dteServiceDateV, costCenterV,
                          cityV, identifireV, serialV, endnumber, brandNameV, modelV, yearModelV, ccV, colorV, engineNo, chasisnoV, initialMileV, fuelstatusV, ulodaenWeight, ladenWeight, supplierV,
                          countryOriginV, ponumberV, mnanufactureV, dtePodateV, provideSlNoV, expirDateV, modelNoV, detInstalation.ToString(), lcNumberV, locationV, othersV, userenroll.ToString(), capacityV, invoicevalue.ToString(),
                          recommandlife.ToString(), landedcost.ToString(), depMethode.ToString(), otherCost.ToString(), depRate.ToString(), accusitioncost.ToString(), remarksV, dteDepRunDate.ToString(), projectid, projectname);

            }
            catch { }
        }

        private void CreateXmlV(string reffid,string unitV, string assetNameV, string jobstationV, string descriptionV, string assetTypeV, string hsCodeV, string majorCategory, string issuedatV, string minorCategoryV, string dteGRnDateV, string minorCategory2V, string dteServiceDateV, string costCenterV, string cityV, string identifireV, string serialV, string endnumber, string brandNameV, string modelV, string yearModelV, string ccV, string colorV, string engineNo, string chasisnoV, string initialMileV, string fuelstatusV, string ulodaenWeight, string ladenWeight, string supplierV, string countryOriginV, string ponumberV, string mnanufactureV, string dtePodateV, string provideSlNoV, string expirDateV, string modelNoV, string dteInstlationV, string lcNumberV, string locationV, string othersV, string enrollV, string capacityV, string invoiceV, string recommandV, string landedCostV, string methodDepV, string erectionCostV, string rateofDepV, string acisitionCostV, string remarksV,string dteDepRunDate, string projectid,string projectname)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeV(doc, reffid, unitV, assetNameV, jobstationV, descriptionV, assetTypeV, hsCodeV, majorCategory, issuedatV, minorCategoryV, dteGRnDateV, minorCategory2V, dteServiceDateV, costCenterV,
                       cityV, identifireV, serialV, endnumber, brandNameV, modelV, yearModelV, ccV, colorV, engineNo, chasisnoV, initialMileV, fuelstatusV, ulodaenWeight, ladenWeight, supplierV,
                       countryOriginV, ponumberV, mnanufactureV, dtePodateV, provideSlNoV, expirDateV, modelNoV, dteInstlationV, lcNumberV, locationV, othersV, enrollV, capacityV, invoiceV,
                       recommandV, landedCostV, methodDepV, erectionCostV, rateofDepV, acisitionCostV, remarksV, dteDepRunDate, projectid, projectname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeV(doc, reffid, unitV, assetNameV, jobstationV, descriptionV, assetTypeV, hsCodeV, majorCategory, issuedatV, minorCategoryV, dteGRnDateV, minorCategory2V, dteServiceDateV, costCenterV,
                       cityV, identifireV, serialV, endnumber, brandNameV, modelV, yearModelV, ccV, colorV, engineNo, chasisnoV, initialMileV, fuelstatusV, ulodaenWeight, ladenWeight, supplierV,
                       countryOriginV, ponumberV, mnanufactureV, dtePodateV, provideSlNoV, expirDateV, modelNoV, dteInstlationV, lcNumberV, locationV, othersV, enrollV, capacityV, invoiceV,
                       recommandV, landedCostV, methodDepV, erectionCostV, rateofDepV, acisitionCostV, remarksV, dteDepRunDate, projectid, projectname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);

        }

        private XmlNode CreateItemNodeV(XmlDocument doc,string reffid, string unitV, string assetNameV, string jobstationV, string descriptionV, string assetTypeV, string hsCodeV, string majorCategory,
        string issuedatV, string minorCategoryV, string dteGRnDateV, string minorCategory2V, string dteServiceDateV, string costCenterV, string cityV, string identifireV, string serialV,
        string endnumber, string brandNameV, string modelV, string yearModelV, string ccV, string colorV, string engineNo, string chasisnoV, string initialMileV, string fuelstatusV,
        string ulodaenWeight, string ladenWeight, string supplierV, string countryOriginV, string ponumberV, string mnanufactureV, string dtePodateV, string provideSlNoV,
        string expirDateV, string modelNoV, string dteInstlationV, string lcNumberV, string locationV, string othersV, string enrollV, string capacityV, string invoiceV,
        string recommandV, string landedCostV, string methodDepV, string erectionCostV, string rateofDepV, string acisitionCostV, string remarksV,string dteDepRunDate, string projectid,string projectname)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            
            XmlAttribute Reffid = doc.CreateAttribute("reffid");
            Reffid.Value = reffid;

            XmlAttribute UnitV = doc.CreateAttribute("unitV");
            UnitV.Value = unitV;

            XmlAttribute AssetNameV = doc.CreateAttribute("assetNameV");
            AssetNameV.Value = assetNameV;

            XmlAttribute JobstationV = doc.CreateAttribute("jobstationV");
            JobstationV.Value = jobstationV;

            XmlAttribute DescriptionV = doc.CreateAttribute("descriptionV");
            DescriptionV.Value = descriptionV;

            XmlAttribute AssetTypeV = doc.CreateAttribute("assetTypeV");
            AssetTypeV.Value = assetTypeV;
            XmlAttribute HsCodeV = doc.CreateAttribute("hsCodeV");
            HsCodeV.Value = hsCodeV;

            XmlAttribute MajorCategory = doc.CreateAttribute("majorCategory");
            MajorCategory.Value = majorCategory;


            XmlAttribute IssuedatV = doc.CreateAttribute("issuedatV");
            IssuedatV.Value = issuedatV;
            XmlAttribute MinorCategoryV = doc.CreateAttribute("minorCategoryV");
            MinorCategoryV.Value = minorCategoryV;

            XmlAttribute DteGRnDateV = doc.CreateAttribute("dteGRnDateV");
            DteGRnDateV.Value = dteGRnDateV;
            XmlAttribute MinorCategory2V = doc.CreateAttribute("minorCategory2V");
            MinorCategory2V.Value = minorCategory2V;
            XmlAttribute DteServiceDateV = doc.CreateAttribute("dteServiceDateV");
            DteServiceDateV.Value = dteServiceDateV;

            XmlAttribute CostCenterV = doc.CreateAttribute("costCenterV");
            CostCenterV.Value = costCenterV;




            XmlAttribute CityV = doc.CreateAttribute("cityV");
            CityV.Value = cityV;
            XmlAttribute IdentifireV = doc.CreateAttribute("identifireV");
            IdentifireV.Value = identifireV;

            XmlAttribute SerialV = doc.CreateAttribute("serialV");
            SerialV.Value = serialV;
            XmlAttribute Endnumber = doc.CreateAttribute("endnumber");
            Endnumber.Value = endnumber;
            XmlAttribute BrandNameV = doc.CreateAttribute("brandNameV");
            BrandNameV.Value = brandNameV;

            XmlAttribute ModelV = doc.CreateAttribute("modelV");
            ModelV.Value = modelV;

            XmlAttribute YearModelV = doc.CreateAttribute("yearModelV");
            YearModelV.Value = yearModelV;

            XmlAttribute CcV = doc.CreateAttribute("ccV");
            CcV.Value = ccV;
            XmlAttribute ColorV = doc.CreateAttribute("colorV");
            ColorV.Value = colorV;

            XmlAttribute EngineNo = doc.CreateAttribute("engineNo");
            EngineNo.Value = engineNo;

            XmlAttribute ChasisnoV = doc.CreateAttribute("chasisnoV");
            ChasisnoV.Value = chasisnoV;


            XmlAttribute InitialMileV = doc.CreateAttribute("initialMileV");
            InitialMileV.Value = initialMileV;

            XmlAttribute FuelstatusV = doc.CreateAttribute("fuelstatusV");
            FuelstatusV.Value = fuelstatusV;
            XmlAttribute UlodaenWeight = doc.CreateAttribute("ulodaenWeight");
            UlodaenWeight.Value = ulodaenWeight;
            XmlAttribute LadenWeight = doc.CreateAttribute("ladenWeight");
            LadenWeight.Value = ladenWeight;

            XmlAttribute SupplierV = doc.CreateAttribute("supplierV");
            SupplierV.Value = supplierV;
            XmlAttribute CountryOriginV = doc.CreateAttribute("countryOriginV");
            CountryOriginV.Value = countryOriginV;
            XmlAttribute PonumberV = doc.CreateAttribute("ponumberV");
            PonumberV.Value = ponumberV;
            XmlAttribute MnanufactureV = doc.CreateAttribute("mnanufactureV");
            MnanufactureV.Value = mnanufactureV;

            XmlAttribute DtePodateV = doc.CreateAttribute("dtePodateV");
            DtePodateV.Value = dtePodateV;

            XmlAttribute ProvideSlNoV = doc.CreateAttribute("provideSlNoV");
            ProvideSlNoV.Value = provideSlNoV;
            XmlAttribute ExpirDateV = doc.CreateAttribute("expirDateV");
            ExpirDateV.Value = expirDateV;
            XmlAttribute ModelNoV = doc.CreateAttribute("modelNoV");
            ModelNoV.Value = modelNoV;

            XmlAttribute DteInstlationV = doc.CreateAttribute("dteInstlationV");
            DteInstlationV.Value = dteInstlationV;
            XmlAttribute LcNumberV = doc.CreateAttribute("lcNumberV");
            LcNumberV.Value = lcNumberV;

            XmlAttribute LocationV = doc.CreateAttribute("locationV");
            LocationV.Value = locationV;

            XmlAttribute OthersV = doc.CreateAttribute("othersV");
            OthersV.Value = othersV;
            XmlAttribute EnrollV = doc.CreateAttribute("enrollV");
            EnrollV.Value = enrollV;
            XmlAttribute CapacityV = doc.CreateAttribute("capacityV");
            CapacityV.Value = capacityV;

            XmlAttribute InvoiceV = doc.CreateAttribute("invoiceV");
            InvoiceV.Value = invoiceV;
            XmlAttribute RecommandV = doc.CreateAttribute("recommandV");
            RecommandV.Value = recommandV;

            XmlAttribute LandedCostV = doc.CreateAttribute("landedCostV");
            LandedCostV.Value = landedCostV;

            XmlAttribute MethodDepV = doc.CreateAttribute("methodDepV");
            MethodDepV.Value = methodDepV;
            XmlAttribute ErectionCostV = doc.CreateAttribute("erectionCostV");
            ErectionCostV.Value = erectionCostV;
            XmlAttribute RateofDepV = doc.CreateAttribute("rateofDepV");
            RateofDepV.Value = rateofDepV;

            XmlAttribute AcisitionCostV = doc.CreateAttribute("acisitionCostV");
            AcisitionCostV.Value = acisitionCostV;
            XmlAttribute RemarksV = doc.CreateAttribute("remarksV");
            RemarksV.Value = remarksV;
            XmlAttribute DteDepRunDate = doc.CreateAttribute("dteDepRunDate");
            DteDepRunDate.Value = dteDepRunDate;

            XmlAttribute Projectid = doc.CreateAttribute("projectid");
            Projectid.Value = projectid;
            XmlAttribute Projectname = doc.CreateAttribute("projectname");
            Projectname.Value = projectname;

           

            node.Attributes.Append(Reffid);
            node.Attributes.Append(UnitV);
            node.Attributes.Append(AssetNameV);
            node.Attributes.Append(JobstationV);


            node.Attributes.Append(DescriptionV);
            node.Attributes.Append(AssetTypeV);
            node.Attributes.Append(HsCodeV);
            node.Attributes.Append(MajorCategory);
            node.Attributes.Append(IssuedatV);
            node.Attributes.Append(MinorCategoryV);
            node.Attributes.Append(DteGRnDateV);
            node.Attributes.Append(MinorCategory2V);
            node.Attributes.Append(DteServiceDateV);
            node.Attributes.Append(CostCenterV);
            node.Attributes.Append(CityV);
            node.Attributes.Append(IdentifireV);
            node.Attributes.Append(SerialV);
            node.Attributes.Append(Endnumber);
            node.Attributes.Append(BrandNameV);
            node.Attributes.Append(ModelV);
            node.Attributes.Append(YearModelV);
            node.Attributes.Append(CcV);
            node.Attributes.Append(ColorV);
            node.Attributes.Append(EngineNo);
            node.Attributes.Append(ChasisnoV);
            node.Attributes.Append(InitialMileV);
            node.Attributes.Append(FuelstatusV);
            node.Attributes.Append(UlodaenWeight);
            node.Attributes.Append(LadenWeight);
            node.Attributes.Append(SupplierV);
            node.Attributes.Append(CountryOriginV);

            node.Attributes.Append(PonumberV);
            node.Attributes.Append(MnanufactureV);
            node.Attributes.Append(DtePodateV);
            node.Attributes.Append(ProvideSlNoV);
            node.Attributes.Append(ExpirDateV);

            node.Attributes.Append(ModelNoV);
            node.Attributes.Append(DteInstlationV);
            node.Attributes.Append(LcNumberV);
            node.Attributes.Append(LocationV);
            node.Attributes.Append(OthersV);
            node.Attributes.Append(EnrollV);

            node.Attributes.Append(CapacityV);
            node.Attributes.Append(InvoiceV);
            node.Attributes.Append(RecommandV);
            node.Attributes.Append(LandedCostV);
            node.Attributes.Append(MethodDepV);
            node.Attributes.Append(ErectionCostV);

            node.Attributes.Append(RateofDepV);
            node.Attributes.Append(AcisitionCostV);
            node.Attributes.Append(RemarksV);
            node.Attributes.Append(DteDepRunDate);
            node.Attributes.Append(Projectid);
            node.Attributes.Append(Projectname);
            return node;
        }

        protected void btnSaveVehicle_Click(object sender, EventArgs e)
        {
             VehicleAssetRegistration();
            try
            {
                //int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMlAssetParking);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                string message = parking.InsertParkingData(8, xmlString, XMLVehicle, XMLBuilding, XMLLand, 0, intenroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                divClose();
            }
            catch { }
        }
        #endregion ===========================Close===================================


        #region ==============================Land Asset============================
        private void LandAssetInfoLoad()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = Int32.Parse("1".ToString());
            dt = new DataTable();
            dt = objregister.LandType();

            ddlMajorCategoryL.DataSource = dt;
            ddlMajorCategoryL.DataTextField = "strAssetTypeName";
            ddlMajorCategoryL.DataValueField = "intAssetTypeID";
            ddlMajorCategoryL.DataBind();
            dt = new DataTable();

            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlUnitLand.DataSource = dt;
            ddlUnitLand.DataTextField = "strUnit";
            ddlUnitLand.DataValueField = "intUnitID";
            ddlUnitLand.DataBind();

            Int32 unitid = Int32.Parse(ddlUnitLand.SelectedValue.ToString());
            dt = new DataTable();

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlJobstationL.DataSource = dt;
            ddlJobstationL.DataTextField = "strJobStationName";
            ddlJobstationL.DataValueField = "intEmployeeJobStationId";
            ddlJobstationL.DataBind();
            dt = new DataTable();
            dt = objregister.Districviewdropdown();
            ddlDistrictL.DataSource = dt;
            ddlDistrictL.DataTextField = "strDistrictBanglaName";
            ddlDistrictL.DataValueField = "intDistrictIDs";
            ddlDistrictL.DataBind();
            dt = new DataTable();
            int districtss = int.Parse(ddlDistrictL.SelectedValue.ToString());
            dt = objregister.Thanadrodownview(districtss);
            ddlThanaL.DataSource = dt;
            ddlThanaL.DataTextField = "strDistrictBanglaName";
            ddlThanaL.DataValueField = "intDistrictIDs";
            ddlThanaL.DataBind();



            int VehicleCat = int.Parse(999998.ToString());
            dt = objregister.DropdownCategoryView(VehicleCat);
            ddlMinorCategory1L.DataSource = dt;
            ddlMinorCategory1L.DataTextField = "strCategoryName";
            ddlMinorCategory1L.DataValueField = "intCategoryID";
            ddlMinorCategory1L.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlMinorCategory2L.DataSource = dt;
            ddlMinorCategory2L.DataTextField = "Name";
            ddlMinorCategory2L.DataValueField = "ID";
            ddlMinorCategory2L.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlUnitLand.SelectedValue));
            ddlCostCenterL.DataSource = dt;
            ddlCostCenterL.DataTextField = "Name";
            ddlCostCenterL.DataValueField = "Id";
            ddlCostCenterL.DataBind();


            try
            {



                int intAutoID = int.Parse(hdnReceive.Value);
                DataTable pk = new DataTable();
                pk = parking.CwipAssetView(3, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intAutoID);
                if (pk.Rows.Count > 0)
                {


                    try { ddlUnitLand.SelectedValue = pk.Rows[0]["intUnit"].ToString(); }
                    catch { }
                    try
                    {
                        dt = objregister.JobstationName(8, int.Parse(ddlUnitLand.SelectedValue), intenroll, intjobid, intdept, "0");
                        ddlJobstationL.DataSource = dt;
                        ddlJobstationL.DataTextField = "strJobStationName";
                        ddlJobstationL.DataValueField = "intEmployeeJobStationId";
                        ddlJobstationL.DataBind();
                    }
                    catch { }
                    try { ddlJobstationL.SelectedValue = pk.Rows[0]["intjobstationid"].ToString(); } catch { }
                    try { ddlAssetTypeL.SelectedValue = pk.Rows[0]["intMaintype"].ToString(); } catch { }
                    try { ddlMajorCategoryL.SelectedValue = pk.Rows[0]["intAssetType"].ToString(); } catch { }

                    //  dt = objregister.DropdownCategoryView(int.Parse(ddlJobstationV.SelectedValue));
                    dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(pk.Rows[0]["intAssetType"].ToString()), int.Parse(ddlJobstationL.SelectedValue));//Parking List

                    ddlMinorCategory1L.DataSource = dt;
                    ddlMinorCategory1L.DataTextField = "strCategoryName";
                    ddlMinorCategory1L.DataValueField = "intCategoryID";
                    ddlMinorCategory1L.DataBind();





                    try { ddlMinorCategory1L.SelectedValue = pk.Rows[0]["intMinorCatagory1"].ToString(); } catch { }

                    try { ddlMinorCategory2L.SelectedValue = pk.Rows[0]["intMinorCatagory2"].ToString(); } catch { }





                    dt = objregister.RegCostCenter(int.Parse(ddlUnitLand.SelectedValue));
                    ddlCostCenterL.DataSource = dt;
                    ddlCostCenterL.DataTextField = "Name";
                    ddlCostCenterL.DataValueField = "Id";
                    ddlCostCenterL.DataBind();

                    try
                    {
                        ddlCostCenterL.SelectedValue = pk.Rows[0]["intCostCenter"].ToString();
                    }
                    catch { }
                    txtAssetnameV.Text = pk.Rows[0]["strNameOfAsset"].ToString();

                    txtSupplierL.Text = pk.Rows[0]["suppliers"].ToString();
                    txtPoNumberL.Text = pk.Rows[0]["intPoNumber"].ToString();
                    txtPoDateL.Text = pk.Rows[0]["dtePo"].ToString();
                    // dteWarintyExpireV.Text = pk.Rows[0]["dteWarranty"].ToString();
                    // txtDateInstalationV.Text = pk.Rows[0]["detInstalation"].ToString();
                    txtMouzaL.Text = pk.Rows[0]["strlcoation"].ToString();
                    txtEnrollmentL.Text = pk.Rows[0]["intUserEnroll"].ToString();
                    //txtInvoiceValueL.Text = pk.Rows[0]["monInvoicevalue"].ToString();
                    // txtLandedCostL.Text = pk.Rows[0]["monLandedcost"].ToString();
                  
                    txtRemarksL.Text = pk.Rows[0]["strRemarks"].ToString();


                    txtAssetNameL.Text = pk.Rows[0]["strNameOfAsset"].ToString();
                    txtDescriptionL.Text = pk.Rows[0]["strDescription"].ToString();
                    txtHScodeL.Text = pk.Rows[0]["strHScode"].ToString();
                    txtIssueDateL.Text = pk.Rows[0]["dteIssudate"].ToString();
                    txtGRNDateL.Text = pk.Rows[0]["dteGRN"].ToString();
                    txtServiceDateL.Text = pk.Rows[0]["dteServicedate"].ToString();

                    try
                    {
                        txtProjectIDL.Text = pk.Rows[0]["projectid"].ToString();
                        txtProjectNameL.Text = pk.Rows[0]["projectName"].ToString();
                        txtMouzaL.Text = pk.Rows[0]["location"].ToString();
                    }
                    catch { }

                    // txtCountryOriginV.Text = pk.Rows[0]["strCountryorigin"].ToString();
                    //  txtManufacturerV.Text = pk.Rows[0]["strManufacturer"].ToString();
                    //  txtManuProviceSlNoV.Text = pk.Rows[0]["strProvideSlnumber"].ToString();
                    // txtModelNoV.Text = pk.Rows[0]["strModelono"].ToString();

                    //txtLCnumberV.Text = pk.Rows[0]["strLcnumber"].ToString();
                    //txtOthersV.Text = pk.Rows[0]["strOthers"].ToString();
                    //txtCapacityV.Text = pk.Rows[0]["strCapacity"].ToString();
                    //txtRecommandLifeV.Text = pk.Rows[0]["monRecommandlife"].ToString();
                    //ddlMethodOfDepV.SelectedValue = pk.Rows[0]["intDepMethode"].ToString();
                    //txtRateDepV.Text = pk.Rows[0]["monDepRate"].ToString();

                    //txtDteDepRunV.Text = pk.Rows[0]["dteDepRun"].ToString(); txtInvoiceValueV.Text = pk.Rows[0]["monInvoicevalue"].ToString();

                    txtLandedCostL.Text= pk.Rows[0]["monInvoicevalue"].ToString();
                    txtOtherCostL.Text= pk.Rows[0]["monOtherCost"].ToString();
                    txtAcqusitionCostL.Text= pk.Rows[0]["monAccusitioncost"].ToString();

                    // try { invoicevalue = decimal.Parse(0 } catch { invoicevalue = 0; }
                    // try { landedcost = decimal.Parse(txtLandedCostV.Text); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtErectionOtherCostV.Text); } catch { otherCost = 0; }
                    txtAcqusitionCostL.Text = (invoicevalue + otherCost).ToString();
                    txtAcqusitionCostL.ReadOnly = true;

                }

            }
            catch { };
        }

        protected void ddlUnitLand_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt = new DataTable();
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = Int32.Parse(ddlUnitLand.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode);
            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlUnitLand.DataSource = dt;
            ddlUnitLand.DataTextField = "strUnit";
            ddlUnitLand.DataValueField = "intUnitID";
            ddlUnitLand.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlUnitLand.SelectedValue));
            ddlCostCenterL.DataSource = dt;
            ddlCostCenterL.DataTextField = "Name";
            ddlCostCenterL.DataValueField = "Id";
            ddlCostCenterL.DataBind();
        }
        protected void ddlDistrictL_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            int districtss = int.Parse(ddlDistrictL.SelectedValue.ToString());
            dt = objregister.Thanadrodownview(districtss);
            ddlThanaL.DataSource = dt;
            ddlThanaL.DataTextField = "strDistrictBanglaName";
            ddlThanaL.DataValueField = "intDistrictIDs";
            ddlThanaL.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnLandDiv();", true);

        }
        protected void dgvLand_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvLand.DataSource;
                dsGrid.Tables[0].Rows[dgvLand.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathXMlCwipLand);
                DataSet dsGridAfterDelete = (DataSet)dgvLand.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathXMlCwipLand); dgvLand.DataSource = ""; dgvLand.DataBind(); }
                else { LoadGridwithXml(); }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnLandDiv();", true);


            }

            catch { }
        }
        protected void btnAddL_Click(object sender, EventArgs e)
        {
            try { csdagno = decimal.Parse(txtDagCs.Text.ToString()); } catch { csdagno = 0; }
            try { tCsDag = decimal.Parse(txtDagCsTotal.Text.ToString()); } catch { tCsDag = 0; }
            try { sadDagNo = decimal.Parse(txtDagSa.Text.ToString()); } catch { sadDagNo = 0; }
            try { tSaDag = decimal.Parse(txtDagSaTotal.Text.ToString()); } catch { tSaDag = 0; }
            try{ rsDagNo = decimal.Parse(txtDagRs.Text.ToString());} catch{ rsDagNo = 0; }
            try {  tRsDag = decimal.Parse(txtDagRsTotal.Text.ToString()); } catch { tRsDag = 0; }
            try { brsDagno = decimal.Parse(txtDagBrs.Text.ToString()); } catch { brsDagno = 0; }
            try { tBrsDag = decimal.Parse(txtDagBrsTotal.Text.ToString()); } catch { tBrsDag = 0; }
            try {  dpDagno = decimal.Parse(txtDpDagNo.Text.ToString()); } catch { dpDagno = 0; }
            try { tDpDagno = decimal.Parse(txtDpDagTotal.Text.ToString()); } catch { tDpDagno = 0; }

            CreateXmlLandDag(csdagno.ToString(), tCsDag.ToString(), sadDagNo.ToString(), tSaDag.ToString(), rsDagNo.ToString(), tRsDag.ToString(), brsDagno.ToString(), tBrsDag.ToString(), dpDagno.ToString(), tDpDagno.ToString());

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnLandDiv();", true);
        }

        private void CreateXmlLandDag(string csdagno, string tCsDag, string sadDagNo, string tSaDag, string rsDagNo, string tRsDag, string brsDagno, string tBrsDag, string dpDagno, string tDpDagno)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathXMlCwipLand))
            {
                doc.Load(filePathXMlCwipLand);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeDag(doc, csdagno, tCsDag, sadDagNo, tSaDag, rsDagNo, tRsDag, brsDagno, tBrsDag, dpDagno, tDpDagno);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeDag(doc, csdagno, tCsDag, sadDagNo, tSaDag, rsDagNo, tRsDag, brsDagno, tBrsDag, dpDagno, tDpDagno);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathXMlCwipLand);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNodeDag(XmlDocument doc, string csdagno, string tCsDag, string sadDagNo, string tSaDag, string rsDagNo, string tRsDag, string brsDagno, string tBrsDag, string dpDagno, string tDpDagno)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Csdagno = doc.CreateAttribute("csdagno");
            Csdagno.Value = csdagno;

            XmlAttribute TCsDag = doc.CreateAttribute("tCsDag");
            TCsDag.Value = tCsDag;

            XmlAttribute SadDagNo = doc.CreateAttribute("sadDagNo");
            SadDagNo.Value = sadDagNo;

            XmlAttribute TSaDag = doc.CreateAttribute("tSaDag");
            TSaDag.Value = tSaDag;

            XmlAttribute RsDagNo = doc.CreateAttribute("rsDagNo");
            RsDagNo.Value = rsDagNo;
            XmlAttribute TRsDag = doc.CreateAttribute("tRsDag");
            TRsDag.Value = tRsDag;

            XmlAttribute BrsDagno = doc.CreateAttribute("brsDagno");
            BrsDagno.Value = brsDagno;
            XmlAttribute TBrsDag = doc.CreateAttribute("tBrsDag");
            TBrsDag.Value = tBrsDag;

            XmlAttribute DpDagno = doc.CreateAttribute("dpDagno");
            DpDagno.Value = dpDagno;
            XmlAttribute TDpDagno = doc.CreateAttribute("tDpDagno");
            TDpDagno.Value = tDpDagno;


            node.Attributes.Append(Csdagno);
            node.Attributes.Append(TCsDag);
            node.Attributes.Append(SadDagNo);


            node.Attributes.Append(TSaDag);
            node.Attributes.Append(RsDagNo);
            node.Attributes.Append(TRsDag);
            node.Attributes.Append(BrsDagno);
            node.Attributes.Append(TBrsDag);
            node.Attributes.Append(DpDagno);
            node.Attributes.Append(TDpDagno);
            return node;

        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathXMlCwipLand);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlStringDag = dSftTm.InnerXml;
                xmlStringDag = "<voucher>" + xmlStringDag + "</voucher>";
                StringReader sr = new StringReader(xmlStringDag);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvLand.DataSource = ds; }

                else { dgvLand.DataSource = ""; }
                dgvLand.DataBind();
            }
            catch { }

        }
        private void LandAssetRegistration()
        {
            DateTime dteDedCertigyRec, dteDeedL, dedRecDateL;
            try { dteDedCertigyRec = DateTime.Parse(txtDeedCertifyRecDate.Text); } catch { dteDedCertigyRec = DateTime.Parse("1990-01-01".ToString()); }
                     
           
            string unitland = ddlUnitLand.SelectedValue.ToString();
            string assetland = txtAssetNameL.Text.ToString();
            string jobland = ddlJobstationL.SelectedValue.ToString();
            string descriptionLand = txtDescriptionL.Text.ToString();
            string assetTypeLand = ddlAssetTypeL.SelectedValue.ToString();
            string hscodeLand = txtHScodeL.Text.ToString();
            string mezorcatL = ddlMajorCategoryL.SelectedValue.ToString();
            string detIsueL = txtIssueDateL.Text.ToString();
            string mezorCat1L = ddlMinorCategory1L.SelectedValue.ToString();
            string dtegrnL = txtGRNDateL.Text.ToString();
            string mezorcat2L = ddlMinorCategory2L.SelectedValue.ToString();
            string dteServiceL = txtServiceDateL.Text.ToString();
            string coscenterL = ddlCostCenterL.SelectedValue.ToString();
            string districL = ddlDistrictL.SelectedValue.ToString();
            string thanaL = ddlThanaL.SelectedValue.ToString();
            string mouzaL = txtMouzaL.Text.ToString();
            string supplierL = txtSupplierL.Text.ToString();
            string buyerL = txtBuyerName.Text.ToString();
            string ponumberL = txtPoNumberL.Text.ToString();
            string dedReceptNoL = txtDeedReceiptNo.Text.ToString();
            string dtePoL = txtPoDateL.Text.ToString();
            string dedNoL = txtDeedNo.Text.ToString();
            try { dteDeedL = DateTime.Parse(txtDeedDate.Text); } catch { dteDeedL = DateTime.Parse("1990-01-01".ToString()); }
           
            string totalLandDecL = txtTotalLandinDecimal.Text.ToString();
            try { dteDedCertigyRec = DateTime.Parse(txtDeedCertifyRecDate.Text); } catch { dteDedCertigyRec = DateTime.Parse("1990-01-01".ToString()); }

            //string dteDedCertigyRec = txtDeedCertifyRecDate.Text.ToString();
            string ratePerDecL = txtRatePerDecimal.Text.ToString();
            
            try { dedRecDateL = DateTime.Parse(txtDeedReceiveDate.Text); } catch { dedRecDateL = DateTime.Parse("1990-01-01".ToString()); }
            string registrationCostL = txtRegistrationCost.Text.ToString();
            string enrollmentL = txtEnrollmentL.Text.ToString();
            string totalLandValue = txtTotalLandValue.Text.ToString();
            string dagCsL = txtDagCs.Text.ToString();
            string dagSaL = txtDagSa.Text.ToString();
            string dagRsL = txtDagRs.Text.ToString();

            string dagBrsl = txtDagBrs.Text.ToString();
            string katianCsL = txtKhatianCs.Text.ToString();
            string katianSaL = txtKhatian.Text.ToString();
            string katianRsL = txtKhatianRs.Text.ToString();
            string katianBrsL = txtKathinBrs.Text.ToString();
            string lengthFeetL = txtLengthFeetL.Text.ToString();
            string breadthFetL = txtBreadthFeetL.Text.ToString();
            string heightFetL = txtHeightFeetL.Text.ToString();
            string totalAreasftL = txtTotalAreaSftL.Text.ToString();
            string rateSftL = txtRateSftL.Text.ToString();
            string invoiceValueL = "0".ToString();
          //  string lanedcostL = txtLandedCostL.Text.ToString();
           // string acqusitionCostL = txtAcqusitionCostL.Text.ToString();

            string remarksL = txtRemarksL.Text.ToString();

            try { landedcost = decimal.Parse(txtLandedCostL.Text); } catch { landedcost = 0; }
            try { otherCost = decimal.Parse(txtOtherCostL.Text); } catch { otherCost = 0; }
            try { accusitioncost = decimal.Parse(txtAcqusitionCostL.Text); } catch { accusitioncost = 0; }
            string reffid = hdnReceive.Value;
            string projectid = txtProjectIDL.Text.ToString();
            string projectname = txtProjectNameL.Text.ToString();
          

            CreateXmlLand(reffid,unitland, assetland, jobland, descriptionLand, assetTypeLand, hscodeLand, mezorcatL, detIsueL, mezorCat1L, dtegrnL, mezorcat2L, dteServiceL, coscenterL, districL, thanaL, mouzaL,
            supplierL, buyerL, ponumberL, dedReceptNoL, dtePoL, dedNoL, dteDeedL.ToString(), totalLandDecL, dteDedCertigyRec.ToString(), ratePerDecL, dedRecDateL.ToString(), registrationCostL, enrollmentL,
            totalLandValue, katianCsL, katianSaL, katianRsL, katianBrsL, lengthFeetL, breadthFetL, heightFetL, totalAreasftL, rateSftL, invoiceValueL, landedcost.ToString(), otherCost.ToString(),accusitioncost.ToString(), remarksL, projectid, projectname);

        }


        private void CreateXmlLand(string reffid,string unitland, string assetland, string jobland, string descriptionLand, string assetTypeLand, string hscodeLand, string mezorcatL, string detIsueL, string mezorCat1L, string dtegrnL, string mezorcat2L, string dteServiceL, string coscenterL, string districL, string thanaL, string mouzaL, string supplierL, string buyerL, string ponumberL, string dedReceptNoL, string dtePoL, string dedNoL, string dteDeedL, string totalLandDecL, string dteDedCertigyRec, string ratePerDecL, string dedRecDateL, string registrationCostL, string enrollmentL, string totalLandValue, string katianCsL, string katianSaL, string katianRsL, string katianBrsL, string lengthFeetL, string breadthFetL, string heightFetL, string totalAreasftL, string rateSftL, string invoiceValueL, string lanedcostL,string otherCostL, string acqusitionCostL, string remarksL, string projectid,string projectname)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeL(doc, reffid,unitland, assetland, jobland, descriptionLand, assetTypeLand, hscodeLand, mezorcatL, detIsueL, mezorCat1L, dtegrnL, mezorcat2L, dteServiceL, coscenterL, districL, thanaL, mouzaL,
            supplierL, buyerL, ponumberL, dedReceptNoL, dtePoL, dedNoL, dteDeedL, totalLandDecL, dteDedCertigyRec, ratePerDecL, dedRecDateL, registrationCostL, enrollmentL,
            totalLandValue, katianCsL, katianSaL, katianRsL, katianBrsL, lengthFeetL, breadthFetL, heightFetL, totalAreasftL, rateSftL, invoiceValueL, lanedcostL, otherCostL, acqusitionCostL, remarksL, projectid, projectname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeL(doc, reffid, unitland, assetland, jobland, descriptionLand, assetTypeLand, hscodeLand, mezorcatL, detIsueL, mezorCat1L, dtegrnL, mezorcat2L, dteServiceL, coscenterL, districL, thanaL, mouzaL,
            supplierL, buyerL, ponumberL, dedReceptNoL, dtePoL, dedNoL, dteDeedL, totalLandDecL, dteDedCertigyRec, ratePerDecL, dedRecDateL, registrationCostL, enrollmentL,
            totalLandValue, katianCsL, katianSaL, katianRsL, katianBrsL, lengthFeetL, breadthFetL, heightFetL, totalAreasftL, rateSftL, invoiceValueL, lanedcostL, otherCostL, acqusitionCostL, remarksL, projectid, projectname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeL(XmlDocument doc,string reffid, string unitland, string assetland, string jobland, string descriptionLand, string assetTypeLand, string hscodeLand, string mezorcatL, string detIsueL, string mezorCat1L, string dtegrnL, string mezorcat2L, string dteServiceL, string coscenterL, string districL, string thanaL, string mouzaL, string supplierL, string buyerL, string ponumberL, string dedReceptNoL, string dtePoL, string dedNoL, string dteDeedL, string totalLandDecL, string dteDedCertigyRec, string ratePerDecL, string dedRecDateL, string registrationCostL, string enrollmentL, string totalLandValue, string katianCsL, string katianSaL, string katianRsL, string katianBrsL, string lengthFeetL, string breadthFetL, string heightFetL, string totalAreasftL, string rateSftL, string invoiceValueL, string lanedcostL, string otherCostL,string acqusitionCostL, string remarksL, string projectid,string projectname)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            
            XmlAttribute Reffid = doc.CreateAttribute("reffid");
            Reffid.Value = reffid;

            XmlAttribute Unitland = doc.CreateAttribute("unitland");
            Unitland.Value = unitland;

            XmlAttribute Assetland = doc.CreateAttribute("assetland");
            Assetland.Value = assetland;

            XmlAttribute Jobland = doc.CreateAttribute("jobland");
            Jobland.Value = jobland;

            XmlAttribute DescriptionLand = doc.CreateAttribute("descriptionLand");
            DescriptionLand.Value = descriptionLand;

            XmlAttribute AssetTypeLand = doc.CreateAttribute("assetTypeLand");
            AssetTypeLand.Value = assetTypeLand;
            XmlAttribute HscodeLand = doc.CreateAttribute("hscodeLand");
            HscodeLand.Value = hscodeLand;

            XmlAttribute MezorcatL = doc.CreateAttribute("mezorcatL");
            MezorcatL.Value = mezorcatL;
            XmlAttribute DetIsueL = doc.CreateAttribute("detIsueL");
            DetIsueL.Value = detIsueL;

            XmlAttribute MezorCat1L = doc.CreateAttribute("mezorCat1L");
            MezorCat1L.Value = mezorCat1L;


            XmlAttribute DtegrnL = doc.CreateAttribute("dtegrnL");
            DtegrnL.Value = dtegrnL;
            XmlAttribute Mezorcat2L = doc.CreateAttribute("mezorcat2L");
            Mezorcat2L.Value = mezorcat2L;
            XmlAttribute DteServiceL = doc.CreateAttribute("dteServiceL");
            DteServiceL.Value = dteServiceL;

            XmlAttribute CoscenterL = doc.CreateAttribute("coscenterL");
            CoscenterL.Value = coscenterL;
            XmlAttribute DistricL = doc.CreateAttribute("districL");
            DistricL.Value = districL;
            XmlAttribute ThanaL = doc.CreateAttribute("thanaL");
            ThanaL.Value = thanaL;

            XmlAttribute MouzaL = doc.CreateAttribute("mouzaL");
            MouzaL.Value = mouzaL;



            XmlAttribute SupplierL = doc.CreateAttribute("supplierL");
            SupplierL.Value = supplierL;
            XmlAttribute BuyerL = doc.CreateAttribute("buyerL");
            BuyerL.Value = buyerL;

            XmlAttribute PonumberL = doc.CreateAttribute("ponumberL");
            PonumberL.Value = ponumberL;
            XmlAttribute DedReceptNoL = doc.CreateAttribute("dedReceptNoL");
            DedReceptNoL.Value = dedReceptNoL;
            XmlAttribute DtePoL = doc.CreateAttribute("dtePoL");
            DtePoL.Value = dtePoL;

            XmlAttribute DedNoL = doc.CreateAttribute("dedNoL");
            DedNoL.Value = dedNoL;

            XmlAttribute DteDeedL = doc.CreateAttribute("dteDeedL");
            DteDeedL.Value = dteDeedL;

            XmlAttribute TotalLandDecL = doc.CreateAttribute("totalLandDecL");
            TotalLandDecL.Value = totalLandDecL;
            XmlAttribute DteDedCertigyRec = doc.CreateAttribute("dteDedCertigyRec");
            DteDedCertigyRec.Value = dteDedCertigyRec;



            XmlAttribute RatePerDecL = doc.CreateAttribute("ratePerDecL");
            RatePerDecL.Value = ratePerDecL;


            XmlAttribute DedRecDateL = doc.CreateAttribute("dedRecDateL");
            DedRecDateL.Value = dedRecDateL;

            XmlAttribute RegistrationCostL = doc.CreateAttribute("registrationCostL");
            RegistrationCostL.Value = registrationCostL;
            XmlAttribute EnrollmentL = doc.CreateAttribute("enrollmentL");
            EnrollmentL.Value = enrollmentL;

            XmlAttribute TotalLandValue = doc.CreateAttribute("totalLandValue");
            TotalLandValue.Value = totalLandValue;

            XmlAttribute KatianCsL = doc.CreateAttribute("katianCsL");
            KatianCsL.Value = katianCsL;
            XmlAttribute KatianSaL = doc.CreateAttribute("katianSaL");
            KatianSaL.Value = katianSaL;
            XmlAttribute KatianRsL = doc.CreateAttribute("katianRsL");
            KatianRsL.Value = katianRsL;
            XmlAttribute KatianBrsL = doc.CreateAttribute("katianBrsL");
            KatianBrsL.Value = katianBrsL;

            XmlAttribute LengthFeetL = doc.CreateAttribute("lengthFeetL");
            LengthFeetL.Value = lengthFeetL;

            XmlAttribute BreadthFetL = doc.CreateAttribute("breadthFetL");
            BreadthFetL.Value = breadthFetL;
            XmlAttribute HeightFetL = doc.CreateAttribute("heightFetL");
            HeightFetL.Value = heightFetL;
            XmlAttribute TotalAreasftL = doc.CreateAttribute("totalAreasftL");
            TotalAreasftL.Value = totalAreasftL;

            XmlAttribute RateSftL = doc.CreateAttribute("rateSftL");
            RateSftL.Value = rateSftL;
            XmlAttribute InvoiceValueL = doc.CreateAttribute("invoiceValueL");
            InvoiceValueL.Value = invoiceValueL;


            XmlAttribute AcqusitionCostL = doc.CreateAttribute("acqusitionCostL");
            AcqusitionCostL.Value = acqusitionCostL;
            XmlAttribute OtherCostL = doc.CreateAttribute("otherCostL");
            OtherCostL.Value = otherCostL;
            
            XmlAttribute LanedcostL = doc.CreateAttribute("lanedcostL");
            LanedcostL.Value = lanedcostL;

            XmlAttribute RemarksL = doc.CreateAttribute("remarksL");
            RemarksL.Value = remarksL;

            XmlAttribute Projectid = doc.CreateAttribute("projectid");
            Projectid.Value = projectid;

            XmlAttribute Projectname = doc.CreateAttribute("projectname");
            Projectname.Value = projectname;

          



            node.Attributes.Append(Reffid);
            node.Attributes.Append(Unitland);
            node.Attributes.Append(Assetland);
            node.Attributes.Append(Jobland);


            node.Attributes.Append(DescriptionLand);
            node.Attributes.Append(AssetTypeLand);
            node.Attributes.Append(HscodeLand);
            node.Attributes.Append(MezorcatL);
            node.Attributes.Append(DetIsueL);
            node.Attributes.Append(MezorCat1L);
            node.Attributes.Append(DtegrnL);
            node.Attributes.Append(Mezorcat2L);
            node.Attributes.Append(DteServiceL);
            node.Attributes.Append(CoscenterL);
            node.Attributes.Append(DistricL);
            node.Attributes.Append(ThanaL);
            node.Attributes.Append(MouzaL);
            node.Attributes.Append(SupplierL);
            node.Attributes.Append(BuyerL);
            node.Attributes.Append(PonumberL);
            node.Attributes.Append(DedReceptNoL);
            node.Attributes.Append(DtePoL);
            node.Attributes.Append(DedNoL);
            node.Attributes.Append(DteDeedL);
            node.Attributes.Append(TotalLandDecL);
            node.Attributes.Append(DteDedCertigyRec);
            node.Attributes.Append(RatePerDecL);
            node.Attributes.Append(DedRecDateL);
            node.Attributes.Append(RegistrationCostL);

            node.Attributes.Append(EnrollmentL);

            node.Attributes.Append(TotalLandValue);
            node.Attributes.Append(KatianCsL);
            node.Attributes.Append(KatianSaL);
            node.Attributes.Append(KatianRsL);
            node.Attributes.Append(KatianBrsL);

            node.Attributes.Append(LengthFeetL);
            node.Attributes.Append(BreadthFetL);
            node.Attributes.Append(HeightFetL);
            node.Attributes.Append(TotalAreasftL);
            node.Attributes.Append(RateSftL);
            node.Attributes.Append(InvoiceValueL);
            node.Attributes.Append(OtherCostL);
            
            node.Attributes.Append(LanedcostL);
            node.Attributes.Append(AcqusitionCostL);
            node.Attributes.Append(RemarksL);
            node.Attributes.Append(Projectid);
            node.Attributes.Append(Projectname);
            return node;
        }

        protected void btnSaveLand_Click(object sender, EventArgs e)
        {
            LandAssetRegistration();
            try
            {
                //int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMlAssetParking);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXMlAssetParking); } catch { }

                XmlDocument doc2 = new XmlDocument();
                doc.Load(filePathXMlCwipLand);
                XmlNode dSftTm2 = doc.SelectSingleNode("voucher");
                string xmlStringDag = dSftTm.InnerXml;
                xmlStringDag = "<voucher>" + xmlStringDag + "</voucher>";
                try { File.Delete(filePathXMlCwipLand); } catch { }


                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                string message = parking.InsertParkingData(9, xmlString, xmlStringDag, XMLBuilding, XMLLand, 0, intenroll);
                dgvLand.DataSource = "";dgvLand.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                divClose();
            }
            catch { }
        }

        #endregion ==============================Close================================


        #region ==============================Building Asset==========================
        private void BuildingAssetInfoLoad()
        {
            dt = new DataTable();
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = Int32.Parse("1".ToString());

            dt = objregister.BuildingType();
            ddlBuildMajorCategory.DataSource = dt;
            ddlBuildMajorCategory.DataTextField = "strAssetTypeName";
            ddlBuildMajorCategory.DataValueField = "intAssetTypeID";
            ddlBuildMajorCategory.DataBind();
            dt = new DataTable();

            dt = objregister.Unitname(5, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlBuildUnit.DataSource = dt;
            ddlBuildUnit.DataTextField = "strUnit";
            ddlBuildUnit.DataValueField = "intUnitID";
            ddlBuildUnit.DataBind();

            dt = new DataTable();
            int unitid = int.Parse(ddlBuildUnit.SelectedValue.ToString());

            dt = objregister.JobstationName(6, Mnumber, intenroll, intjobid, intdept, assetcode);
            ddlBuildJobstation.DataSource = dt;
            ddlBuildJobstation.DataTextField = "strJobStationName";
            ddlBuildJobstation.DataValueField = "intEmployeeJobStationId";
            ddlBuildJobstation.DataBind();

            dt = new DataTable();
            //**Building--- Category Fixed make id 999999 ****//
            //int buildcategorys = int.Parse("999999".ToString());
            int buildcategorys = int.Parse(ddlBuildMajorCategory.SelectedValue.ToString());
            // dt = objregister.BuildingCataegoryList(buildcategorys);
            dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, buildcategorys, intenroll);//Parking List
            ddlBMinorCategory1.DataSource = dt;
            ddlBMinorCategory1.DataTextField = "strCategoryName";
            ddlBMinorCategory1.DataValueField = "intCategoryID";
            ddlBMinorCategory1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlBMinorCategory2.DataSource = dt;
            ddlBMinorCategory2.DataTextField = "Name";
            ddlBMinorCategory2.DataValueField = "ID";
            ddlBMinorCategory2.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlBuildUnit.SelectedValue));
            ddlBCostCenter.DataSource = dt;
            ddlBCostCenter.DataTextField = "Name";
            ddlBCostCenter.DataValueField = "Id";
            ddlBCostCenter.DataBind();



            try
            {



                int intAutoID = int.Parse(hdnReceive.Value);
                DataTable pk = new DataTable();
                pk = parking.CwipAssetView(3, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intAutoID);
                if (pk.Rows.Count > 0)
                {


                    try { ddlBuildUnit.SelectedValue = pk.Rows[0]["intUnit"].ToString(); }
                    catch { }
                    try
                    {
                        dt = objregister.JobstationName(8, int.Parse(ddlBuildUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                        ddlBuildJobstation.DataSource = dt;
                        ddlBuildJobstation.DataTextField = "strJobStationName";
                        ddlBuildJobstation.DataValueField = "intEmployeeJobStationId";
                        ddlBuildJobstation.DataBind();
                    }
                    catch { }
                    try { ddlBuildJobstation.SelectedValue = pk.Rows[0]["intjobstationid"].ToString(); } catch { }
                    try { ddlBuildAssetType.SelectedValue = pk.Rows[0]["intMaintype"].ToString(); } catch { }
                    try { ddlBuildMajorCategory.SelectedValue = pk.Rows[0]["intAssetType"].ToString(); } catch { }

                    try
                    {
                        dt = objregister.DropdownCategoryView(int.Parse(ddlJobstationV.SelectedValue));
                        dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(pk.Rows[0]["intAssetType"].ToString()), int.Parse(ddlJobstationV.SelectedValue));//Parking List

                        ddlBMinorCategory1.DataSource = dt;
                        ddlBMinorCategory1.DataTextField = "strCategoryName";
                        ddlBMinorCategory1.DataValueField = "intCategoryID";
                        ddlBMinorCategory1.DataBind();
                    }
                    catch { }





                    try { ddlBMinorCategory1.SelectedValue = pk.Rows[0]["intMinorCatagory1"].ToString(); } catch { }

                    try { ddlBMinorCategory2.SelectedValue = pk.Rows[0]["intMinorCatagory2"].ToString(); } catch { }





                    dt = objregister.RegCostCenter(int.Parse(ddlBuildUnit.SelectedValue));
                    ddlBCostCenter.DataSource = dt;
                    ddlBCostCenter.DataTextField = "Name";
                    ddlBCostCenter.DataValueField = "Id";
                    ddlBCostCenter.DataBind();

                    try
                    {
                        ddlBCostCenter.SelectedValue = pk.Rows[0]["intCostCenter"].ToString();
                    }
                    catch { }
                    txtBuildAssetName.Text = pk.Rows[0]["strNameOfAsset"].ToString();

                    txtBSupplier.Text = pk.Rows[0]["suppliers"].ToString();
                    txtBPoNumber.Text = pk.Rows[0]["intPoNumber"].ToString();
                    txtBPoDate.Text = pk.Rows[0]["dtePo"].ToString();
                    txtBWarantyExDate.Text = pk.Rows[0]["dteWarranty"].ToString();
                    txtBDateInstalation.Text = pk.Rows[0]["detInstalation"].ToString();
                    txtBAssetLocation.Text = pk.Rows[0]["strlcoation"].ToString();
                    txtBUserEnroll.Text = pk.Rows[0]["intUserEnroll"].ToString();
                    txtBInvoiceValueBdt.Text = pk.Rows[0]["monInvoicevalue"].ToString();
                    txtBLandCost.Text = pk.Rows[0]["monLandedcost"].ToString();
                    txtBOtherCost.Text = pk.Rows[0]["monOtherCost"].ToString();
                    txtBAcquisitionCost.Text = pk.Rows[0]["monAccusitioncost"].ToString();
                    txtBRemarks.Text = pk.Rows[0]["strRemarks"].ToString();


                    //txtAssetname.Text = pk.Rows[0]["strNameOfAsset"].ToString();
                    txtBuildDescription.Text = pk.Rows[0]["strDescription"].ToString();
                    txtBHsCode.Text = pk.Rows[0]["strHScode"].ToString();
                    txtBuildStoreIssueDate.Text = pk.Rows[0]["dteIssudate"].ToString();
                    txtBGRNDate.Text = pk.Rows[0]["dteGRN"].ToString();
                    txtBServiceDate.Text = pk.Rows[0]["dteServicedate"].ToString();

                    txtBCountryOrigin.Text = pk.Rows[0]["strCountryorigin"].ToString();
                    txtBNameManufacturer.Text = pk.Rows[0]["strManufacturer"].ToString();
                    txtBProvideSl.Text = pk.Rows[0]["strProvideSlnumber"].ToString();
                    txtBModelNo.Text = pk.Rows[0]["strModelono"].ToString();

                    txtBLcNumber.Text = pk.Rows[0]["strLcnumber"].ToString();
                    txtBOthers.Text = pk.Rows[0]["strOthers"].ToString();
                    txtBRatedCapacity.Text = pk.Rows[0]["strCapacity"].ToString();
                    txtBRecommandLife.Text = pk.Rows[0]["monRecommandlife"].ToString();
                    ddlBDepMethod.SelectedValue = pk.Rows[0]["intDepMethode"].ToString();
                    txtDepRateB.Text = pk.Rows[0]["monDepRate"].ToString();

                    txtBDepRunDate.Text = pk.Rows[0]["dteDepRun"].ToString();
                    try
                    {
                        txtProjectIDB.Text = pk.Rows[0]["projectid"].ToString();
                        txtProjectNameB.Text = pk.Rows[0]["projectName"].ToString();
                        txtBAssetLocation.Text = pk.Rows[0]["location"].ToString();
                    }
                    catch { }

                    try { invoicevalue = decimal.Parse(txtBInvoiceValueBdt.Text); } catch { invoicevalue = 0; }
                    try { landedcost = decimal.Parse(txtBLandCost.Text); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtBOtherCost.Text); } catch { otherCost = 0; }
                    txtBAcquisitionCost.Text = (landedcost + otherCost).ToString();
                    txtBAcquisitionCost.ReadOnly = true;

                }

            }
            catch { };
        }

        protected void ddlBuildUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();           
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string assetcode = "0".ToString();
            int Mnumber = Int32.Parse(ddlBuildUnit.SelectedValue.ToString());

            dt = objregister.Unitname(8, Mnumber, intenroll, intjobid, intdept, assetcode);

            //dt = objregister.Ljobstation(Bnitland);
            ddlBuildJobstation.DataSource = dt;
            ddlBuildJobstation.DataTextField = "strJobStationName";
            ddlBuildJobstation.DataValueField = "intEmployeeJobStationID";
            ddlBuildJobstation.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlBuildUnit.SelectedValue));
            ddlBCostCenter.DataSource = dt;
            ddlBCostCenter.DataTextField = "Name";
            ddlBCostCenter.DataValueField = "Id";
            ddlBCostCenter.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnBuildingDiv();", true);
        }

        
        private void BuildingAssetTegistration()
        {
            try
            {
                string unitBuild = ddlBuildUnit.SelectedValue.ToString();
                string asetNameBuild = txtBuildAssetName.Text.ToString();
                string jonbB = ddlBuildJobstation.SelectedValue.ToString();
                string descriptionB = txtBuildDescription.Text.ToString();
                string assetTypeB = ddlBuildAssetType.SelectedValue.ToString();
                string hscodeB = txtBHsCode.Text.ToString();
                string majorcatB = ddlBuildMajorCategory.SelectedValue.ToString();
                string issudateB = txtBuildStoreIssueDate.Text.ToString();
                string majorcat1B = ddlBMinorCategory1.SelectedValue.ToString();
                string dteGrnB = txtBGRNDate.Text.ToString();
                string minorcate2B = ddlBMinorCategory2.SelectedValue.ToString();
                string dteserviceB = txtBServiceDate.Text.ToString();
                string costcenterB = ddlBCostCenter.SelectedValue.ToString();
                string distictB = "0".ToString();//ddlBDistict.SelectedValue
                string thanaB = "0".ToString();//ddlBThana.SelectedValue
                string mouzaB = "0".ToString(); //ddlBThana.SelectedValue
                string supplierB = txtBSupplier.Text.ToString();
                string countryOriginB = txtBCountryOrigin.Text.ToString();
                string ponumberB = txtBPoNumber.Text.ToString();
                string manufacturerB = txtBNameManufacturer.Text.ToString();
                string dtePoB = txtBPoDate.Text.ToString();
                string provideSlB = txtBProvideSl.Text.ToString();
                string warntyExpB = txtBWarantyExDate.Text.ToString();
                string modelNoB = txtBModelNo.Text.ToString();
                string dteInstalationB = txtBDateInstalation.Text.ToString();
                string lcnumberB = txtBLcNumber.Text.ToString();
                string locationB = txtBAssetLocation.Text.ToString();
                string othersB = txtBOthers.Text.ToString();
                //string enrollB = txtBUserEnroll.Text.ToString();
                string capacityB = txtBRatedCapacity.Text.ToString();
                string lengthB = txtBLengthFeet.Text.ToString();
                string breathFeetB = txtBBreadthFeet.Text.ToString();
                string heightFeetB = txtBHeightfeet.Text.ToString();
                string totalsftB = txtBTotalSft.Text.ToString();
                string ratesftB = txtBRateSft.Text.ToString();
                string invoiceValueB = txtBInvoiceValueBdt.Text.ToString();
                string recommandLifeB = txtBRecommandLife.Text.ToString();
                string landedCostB = txtBLandCost.Text.ToString();
                string depMethodB = ddlBDepMethod.SelectedValue.ToString();
                string otherCostB = txtBOtherCost.Text.ToString();
                string acquisitionCostB = txtBAcquisitionCost.Text.ToString();
                string deprundateB = txtBDepRunDate.Text.ToString();
                string remarksB = txtBRemarks.Text.ToString();

                try { userenroll = int.Parse(txtBUserEnroll.Text); } catch { userenroll = 0; }
                try { invoicevalue = decimal.Parse(txtBInvoiceValueBdt.Text); } catch { invoicevalue = 0; }
                try { landedcost = decimal.Parse(txtBLandCost.Text); } catch { landedcost = 0; }
                try { otherCost = decimal.Parse(txtBOtherCost.Text); } catch { otherCost = 0; }
                try { accusitioncost = decimal.Parse(txtBAcquisitionCost.Text); } catch { accusitioncost = 0; }

                try { recommandlife = decimal.Parse(txtBRecommandLife.Text); } catch { recommandlife = 0; }
                try { depMethode = int.Parse(ddlBDepMethod.SelectedValue); } catch { depMethode = 0; }
                try { depRate = decimal.Parse(txtDepRateB.Text); } catch { depRate = 0; }
                try { dteDepRunDate = DateTime.Parse(txtBDepRunDate.Text); } catch { dteDepRunDate = DateTime.Parse("1990-01-01".ToString()); }
                string reffid = hdnReceive.Value;
                string projectid = txtProjectIDB.Text.ToString();
                string projectname = txtProjectNameB.Text.ToString();

                CreateXmlBuilding(reffid, unitBuild, asetNameBuild, jonbB, descriptionB, assetTypeB, hscodeB, majorcatB, issudateB, majorcat1B, dteGrnB, minorcate2B, dteserviceB, costcenterB, distictB, thanaB,
                mouzaB, supplierB, countryOriginB, ponumberB, manufacturerB, dtePoB, provideSlB, warntyExpB, modelNoB, dteInstalationB, lcnumberB, locationB, othersB, userenroll.ToString(), capacityB,
                lengthB, breathFeetB, heightFeetB, totalsftB, ratesftB, invoiceValueB, recommandLifeB, landedCostB, depMethodB, otherCostB, acquisitionCostB, deprundateB, remarksB, projectid, projectname);
            }
            catch { }

            }

        private void CreateXmlBuilding(string reffid,string unitBuild, string asetNameBuild, string jonbB, string descriptionB, string assetTypeB, string hscodeB, string majorcatB, string issudateB, string majorcat1B, string dteGrnB, string minorcate2B, string dteserviceB, string costcenterB, string distictB, string thanaB, string mouzaB, string supplierB, string countryOriginB, string ponumberB, string manufacturerB, string dtePoB, string provideSlB, string warntyExpB, string modelNoB, string dteInstalationB, string lcnumberB, string locationB, string othersB, string enrollB, string capacityB, string lengthB, string breathFeetB, string heightFeetB, string totalsftB, string ratesftB, string invoiceValueB, string recommandLifeB, string landedCostB, string depMethodB, string otherCostB, string acquisitionCostB, string deprundateB, string remarksB, string projectid, string projectname)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeBuild(doc,reffid, unitBuild, asetNameBuild, jonbB, descriptionB, assetTypeB, hscodeB, majorcatB, issudateB, majorcat1B, dteGrnB, minorcate2B, dteserviceB, costcenterB, distictB, thanaB,
            mouzaB, supplierB, countryOriginB, ponumberB, manufacturerB, dtePoB, provideSlB, warntyExpB, modelNoB, dteInstalationB, lcnumberB, locationB, othersB, enrollB, capacityB,
            lengthB, breathFeetB, heightFeetB, totalsftB, ratesftB, invoiceValueB, recommandLifeB, landedCostB, depMethodB, otherCostB, acquisitionCostB, deprundateB, remarksB, projectid, projectname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeBuild(doc,reffid, unitBuild, asetNameBuild, jonbB, descriptionB, assetTypeB, hscodeB, majorcatB, issudateB, majorcat1B, dteGrnB, minorcate2B, dteserviceB, costcenterB, distictB, thanaB,
            mouzaB, supplierB, countryOriginB, ponumberB, manufacturerB, dtePoB, provideSlB, warntyExpB, modelNoB, dteInstalationB, lcnumberB, locationB, othersB, enrollB, capacityB,
            lengthB, breathFeetB, heightFeetB, totalsftB, ratesftB, invoiceValueB, recommandLifeB, landedCostB, depMethodB, otherCostB, acquisitionCostB, deprundateB, remarksB, projectid, projectname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeBuild(XmlDocument doc,string reffid, string unitBuild, string asetNameBuild, string jonbB, string descriptionB, string assetTypeB, string hscodeB, string majorcatB, string issudateB, string majorcat1B, string dteGrnB, string minorcate2B, string dteserviceB, string costcenterB, string distictB, string thanaB, string mouzaB, string supplierB, string countryOriginB, string ponumberB, string manufacturerB, string dtePoB, string provideSlB, string warntyExpB, string modelNoB, string dteInstalationB, string lcnumberB, string locationB, string othersB, string enrollB, string capacityB, string lengthB, string breathFeetB, string heightFeetB, string totalsftB, string ratesftB, string invoiceValueB, string recommandLifeB, string landedCostB, string depMethodB, string otherCostB, string acquisitionCostB, string deprundateB, string remarksB, string projectid,string projectname)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Reffid = doc.CreateAttribute("reffid");
            Reffid.Value = reffid;

            XmlAttribute UnitBuild = doc.CreateAttribute("unitBuild");
            UnitBuild.Value = unitBuild;

            XmlAttribute AsetNameBuild = doc.CreateAttribute("asetNameBuild");
            AsetNameBuild.Value = asetNameBuild;

            XmlAttribute JonbB = doc.CreateAttribute("jonbB");
            JonbB.Value = jonbB;

            XmlAttribute DescriptionB = doc.CreateAttribute("descriptionB");
            DescriptionB.Value = descriptionB;

            XmlAttribute AssetTypeB = doc.CreateAttribute("assetTypeB");
            AssetTypeB.Value = assetTypeB;
            XmlAttribute HscodeB = doc.CreateAttribute("hscodeB");
            HscodeB.Value = hscodeB;

            XmlAttribute MajorcatB = doc.CreateAttribute("majorcatB");
            MajorcatB.Value = majorcatB;

            XmlAttribute IssudateB = doc.CreateAttribute("issudateB");
            IssudateB.Value = issudateB;

            XmlAttribute Majorcat1B = doc.CreateAttribute("majorcat1B");
            Majorcat1B.Value = majorcat1B;



            XmlAttribute DteGrnB = doc.CreateAttribute("dteGrnB");
            DteGrnB.Value = dteGrnB;
            XmlAttribute Minorcate2B = doc.CreateAttribute("minorcate2B");
            Minorcate2B.Value = minorcate2B;
            XmlAttribute DteserviceB = doc.CreateAttribute("dteserviceB");
            DteserviceB.Value = dteserviceB;

            XmlAttribute CostcenterB = doc.CreateAttribute("costcenterB");
            CostcenterB.Value = costcenterB;
            XmlAttribute DistictB = doc.CreateAttribute("distictB");
            DistictB.Value = distictB;
            XmlAttribute ThanaB = doc.CreateAttribute("thanaB");
            ThanaB.Value = thanaB;

            XmlAttribute MouzaB = doc.CreateAttribute("mouzaB");
            MouzaB.Value = mouzaB;

            XmlAttribute SupplierB = doc.CreateAttribute("supplierB");
            SupplierB.Value = supplierB;
            XmlAttribute CountryOriginB = doc.CreateAttribute("countryOriginB");
            CountryOriginB.Value = countryOriginB;

            XmlAttribute PonumberB = doc.CreateAttribute("ponumberB");
            PonumberB.Value = ponumberB;
            XmlAttribute ManufacturerB = doc.CreateAttribute("manufacturerB");
            ManufacturerB.Value = manufacturerB;
            XmlAttribute DtePoB = doc.CreateAttribute("dtePoB");
            DtePoB.Value = dtePoB;

            XmlAttribute ProvideSlB = doc.CreateAttribute("provideSlB");
            ProvideSlB.Value = provideSlB;

            XmlAttribute WarntyExpB = doc.CreateAttribute("warntyExpB");
            WarntyExpB.Value = warntyExpB;

            XmlAttribute ModelNoB = doc.CreateAttribute("modelNoB");
            ModelNoB.Value = modelNoB;
            XmlAttribute DteInstalationB = doc.CreateAttribute("dteInstalationB");
            DteInstalationB.Value = dteInstalationB;



            XmlAttribute LcnumberB = doc.CreateAttribute("lcnumberB");
            LcnumberB.Value = lcnumberB;


            XmlAttribute LocationB = doc.CreateAttribute("locationB");
            LocationB.Value = locationB;

            XmlAttribute OthersB = doc.CreateAttribute("othersB");
            OthersB.Value = othersB;
            XmlAttribute EnrollB = doc.CreateAttribute("enrollB");
            EnrollB.Value = enrollB;

            XmlAttribute CapacityB = doc.CreateAttribute("capacityB");
            CapacityB.Value = capacityB;

            XmlAttribute LengthB = doc.CreateAttribute("lengthB");
            LengthB.Value = lengthB;
            XmlAttribute BreathFeetB = doc.CreateAttribute("breathFeetB");
            BreathFeetB.Value = breathFeetB;
            XmlAttribute HeightFeetB = doc.CreateAttribute("heightFeetB");
            HeightFeetB.Value = heightFeetB;
            XmlAttribute TotalsftB = doc.CreateAttribute("totalsftB");
            TotalsftB.Value = totalsftB;

            XmlAttribute RatesftB = doc.CreateAttribute("ratesftB");
            RatesftB.Value = ratesftB;

            XmlAttribute InvoiceValueB = doc.CreateAttribute("invoiceValueB");
            InvoiceValueB.Value = invoiceValueB;
            XmlAttribute RecommandLifeB = doc.CreateAttribute("recommandLifeB");
            RecommandLifeB.Value = recommandLifeB;
            XmlAttribute LandedCostB = doc.CreateAttribute("landedCostB");
            LandedCostB.Value = landedCostB;

            XmlAttribute DepMethodB = doc.CreateAttribute("depMethodB");
            DepMethodB.Value = depMethodB;
            XmlAttribute OtherCostB = doc.CreateAttribute("otherCostB");
            OtherCostB.Value = otherCostB;


            XmlAttribute AcquisitionCostB = doc.CreateAttribute("acquisitionCostB");
            AcquisitionCostB.Value = acquisitionCostB;
            XmlAttribute DeprundateB = doc.CreateAttribute("deprundateB");
            DeprundateB.Value = deprundateB;

            XmlAttribute RemarksB = doc.CreateAttribute("remarksB");
            RemarksB.Value = remarksB;


            XmlAttribute Projectid = doc.CreateAttribute("projectid");
            Projectid.Value = projectid;

            XmlAttribute Projectname = doc.CreateAttribute("projectname");
            Projectname.Value = projectname;


            node.Attributes.Append(Reffid);
            node.Attributes.Append(UnitBuild);
            node.Attributes.Append(AsetNameBuild);
            node.Attributes.Append(JonbB);


            node.Attributes.Append(DescriptionB);
            node.Attributes.Append(AssetTypeB);
            node.Attributes.Append(HscodeB);
            node.Attributes.Append(MajorcatB);
            node.Attributes.Append(IssudateB);
            node.Attributes.Append(Majorcat1B);
            node.Attributes.Append(DteGrnB);
            node.Attributes.Append(Minorcate2B);
            node.Attributes.Append(DteserviceB);
            node.Attributes.Append(CostcenterB);
            node.Attributes.Append(DistictB);
            node.Attributes.Append(ThanaB);
            node.Attributes.Append(MouzaB);
            node.Attributes.Append(SupplierB);
            node.Attributes.Append(CountryOriginB);
            node.Attributes.Append(PonumberB);
            node.Attributes.Append(ManufacturerB);
            node.Attributes.Append(DtePoB);
            node.Attributes.Append(ProvideSlB);
            node.Attributes.Append(WarntyExpB);
            node.Attributes.Append(ModelNoB);
            node.Attributes.Append(DteInstalationB);
            node.Attributes.Append(LcnumberB);
            node.Attributes.Append(LocationB);
            node.Attributes.Append(OthersB);

            node.Attributes.Append(EnrollB);

            node.Attributes.Append(CapacityB);
            node.Attributes.Append(LengthB);
            node.Attributes.Append(BreathFeetB);
            node.Attributes.Append(HeightFeetB);
            node.Attributes.Append(TotalsftB);

            node.Attributes.Append(RatesftB);
            node.Attributes.Append(InvoiceValueB);

            node.Attributes.Append(RecommandLifeB);
            node.Attributes.Append(LandedCostB);
            node.Attributes.Append(DepMethodB);
            node.Attributes.Append(OtherCostB);

            node.Attributes.Append(AcquisitionCostB);
            node.Attributes.Append(DeprundateB);
            node.Attributes.Append(RemarksB);

            node.Attributes.Append(Projectid);
            node.Attributes.Append(Projectname);

            

            return node;
        }


        protected void btnSaveBuild_Click(object sender, EventArgs e)
        {
           
            try
            {
                BuildingAssetTegistration();
                //int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMlAssetParking);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                string message = parking.InsertParkingData(10, xmlString, XMLVehicle, XMLBuilding, XMLLand, 0, intenroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                divClose();

            }
            catch { }

        }
        #endregion ===========================Building Asset==========================


        protected void txtErectionOtherCost_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
            try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
            try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
            txtAcisitionCost.Text = ( landedcost + otherCost).ToString();
            txtAcisitionCost.ReadOnly = true;
        }

        protected void txtLandedCost_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
            try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
            try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
            txtAcisitionCost.Text = ( landedcost + otherCost).ToString();
            txtAcisitionCost.ReadOnly = true;
        }

        protected void txtInvoiceValue_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
            try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
            try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
            txtAcisitionCost.Text = ( landedcost + otherCost).ToString();
            txtAcisitionCost.ReadOnly = true;
        }
        private void LoadView()
        {
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());


                dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataBind();

                dt = objregister.JobstationName(8, int.Parse(ddlUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                dlJobstation.DataSource = dt;
                dlJobstation.DataTextField = "strJobStationName";
                dlJobstation.DataValueField = "intEmployeeJobStationId";
                dlJobstation.DataBind();

                dt = objregister.AssetTypeName();
                ddlMajorCat.DataSource = dt;
                ddlMajorCat.DataTextField = "strAssetTypeName";
                ddlMajorCat.DataValueField = "intAssetTypeID";
                ddlMajorCat.DataBind();

                //dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));              
               
                dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(ddlMajorCat.SelectedValue), int.Parse(dlJobstation.SelectedValue));//Parking List

                ddlMinorCate1.DataSource = dt;
                ddlMinorCate1.DataTextField = "strCategoryName";
                ddlMinorCate1.DataValueField = "intCategoryID";
                ddlMinorCate1.DataBind();

                dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
                ddlMinorCate2.DataSource = dt;
                ddlMinorCate2.DataTextField = "Name";
                ddlMinorCate2.DataValueField = "ID";
                ddlMinorCate2.DataBind();

                dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                ddlCostCenter.DataSource = dt;
                ddlCostCenter.DataTextField = "Name";
                ddlCostCenter.DataValueField = "Id";
                ddlCostCenter.DataBind();
            }
            catch { }
            

           

          

            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
            try
            {
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                txtAcisitionCost.ReadOnly = false;
                try { unit = int.Parse(ddlUnit.SelectedValue); } catch { unit = 1; }
                try { jobstation = int.Parse(dlJobstation.SelectedValue); } catch { jobstation = 1; }
                try { asettype = int.Parse(ddlAssetType.SelectedValue); } catch { asettype = 1; }
                try { mazorcategory = int.Parse(ddlMajorCat.SelectedValue); } catch { mazorcategory = 1; }
                try { minorcatagory1 = int.Parse(ddlMinorCate1.SelectedValue); } catch { minorcatagory1 = 1; }
                try { minorcatagory2 = int.Parse(ddlMinorCate2.SelectedValue); } catch { minorcatagory2 = 1; }
                try { coscenter = int.Parse(ddlCostCenter.SelectedValue); } catch { coscenter = 1; }             


                 suppliers = txtSuppliers.Text.ToString();
                try { ponumber = int.Parse(txtPonumbers.Text.ToString()); } catch { ponumber = 0; }
                try {  dtePo = DateTime.Parse(dtePoDate.Text); } catch { dtePo = DateTime.Parse("1990-01-01".ToString()); }
                try { dteWarranty = DateTime.Parse(dteWarintyExpire.Text); } catch { dteWarranty = DateTime.Parse("1990-01-01".ToString()); }
                try { detInstalation = DateTime.Parse(txtDateInstalation.Text); } catch { detInstalation = DateTime.Parse("1990-01-01".ToString()); }
               
                string lcoation = txtAssetLocation.Text.ToString();
                try { userenroll = int.Parse(txtEnrolment.Text); } catch { userenroll = 0; }
                try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
                try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
                try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
                try { accusitioncost = decimal.Parse(txtAcisitionCost.Text); } catch { accusitioncost = 0; }
                string remarks = txtRemarks.Text.ToString();


                string assetname = txtAssetname.Text.ToString();
                string description = txtDescription.Text.ToString();
                string hscode = txtHsCode.Text;
                try { issudate = DateTime.Parse(txtIssueDate.Text); } catch { issudate = DateTime.Parse("1990-01-01".ToString()); }
                try { grnDate = DateTime.Parse(txtGrndDate.Text); } catch { grnDate = DateTime.Parse("1990-01-01".ToString()); }
                try { servicedate = DateTime.Parse(txtServiceDate.Text); } catch { servicedate = DateTime.Parse("1990-01-01".ToString()); }
               
                string countryorigin = txtCountryOrigin.Text.ToString();
                string manufacturer = txtManufacturer.Text.ToString();
                string provideSlnumber = txtManuProviceSlNo.Text.ToString();
                string modelono = txtModelNo.Text.ToString();
                string lcnumber = txtLCnumber.Text.ToString();
                string others = txtOthers.Text.ToString();
                string capacity = txtCapacity.Text.ToString();
                try { recommandlife = decimal.Parse(txtRecommandLife.Text); } catch { recommandlife = 0; }
                try { depMethode = int.Parse(ddlMethodOfDep.SelectedValue); } catch { depMethode = 0; }
                try { depRate = decimal.Parse(txtRateDep.Text); } catch { depRate =0; }
                try { dteDepRunDate = DateTime.Parse(txtDepRunDate.Text); } catch { dteDepRunDate = DateTime.Parse("1990-01-01".ToString()); }

                string reffid= hdnReceive.Value;





                CreateParkingXML(reffid,unit.ToString(), jobstation.ToString(), asettype.ToString(), mazorcategory.ToString(), minorcatagory1.ToString(), minorcatagory2.ToString(), coscenter.ToString(), suppliers, ponumber.ToString(), dtePo.ToString(), dteWarranty.ToString(), detInstalation.ToString(), lcoation
                , userenroll.ToString(), invoicevalue.ToString(), landedcost.ToString(), otherCost.ToString(), accusitioncost.ToString(), remarks, assetname, description, hscode, issudate.ToString(), grnDate.ToString(), servicedate.ToString(), countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife.ToString(), depMethode.ToString(), depRate.ToString(), dteDepRunDate.ToString());


                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMlAssetParking);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlStringG = dSftTm.InnerXml;
                xmlStringG = "<voucher>" + xmlStringG + "</voucher>";
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //string= int.Parse(hdnReceive.Value);
                try { File.Delete(filePathForXMlAssetParking); }
                catch { }
                dt = parking.CwipAssetView(2, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intuntid);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();

                string message = parking.InsertParkingData(4, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intenroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

              
              

                
            }
            catch { }

        }

        private void CreateParkingXML(string reffid,string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1, string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation, string lcoation, string userenroll, string invoicevalue, string landedcost, string otherCost, string accusitioncost, string remarks, string assetname, string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer, string provideSlnumber, string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode, string depRate, string dteDepRunDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, reffid,unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost, accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, reffid, unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost, accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNode(XmlDocument doc,string reffid, string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1,
            string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation,
            string lcoation, string userenroll, string invoicevalue, string landedcost, string otherCost, string accusitioncost, string remarks, string assetname,
            string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer,
            string provideSlnumber, string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode,
            string depRate, string dteDepRunDate)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Reffid = doc.CreateAttribute("reffid");
            Reffid.Value = reffid;
            XmlAttribute Unit = doc.CreateAttribute("unit");
            Unit.Value = unit;
            XmlAttribute Jobstation = doc.CreateAttribute("jobstation");
            Jobstation.Value = jobstation;

            XmlAttribute Asettype = doc.CreateAttribute("asettype");
            Asettype.Value = asettype;
            XmlAttribute Mazorcategory = doc.CreateAttribute("mazorcategory");
            Mazorcategory.Value = mazorcategory;

            XmlAttribute Minorcatagory1 = doc.CreateAttribute("minorcatagory1");
            Minorcatagory1.Value = minorcatagory1;


            XmlAttribute Minorcatagory2 = doc.CreateAttribute("minorcatagory2");
            Minorcatagory2.Value = minorcatagory2;
            XmlAttribute Coscenter = doc.CreateAttribute("coscenter");
            Coscenter.Value = coscenter;

            XmlAttribute Suppliers = doc.CreateAttribute("suppliers");
            Suppliers.Value = suppliers;
            XmlAttribute Ponumber = doc.CreateAttribute("ponumber");
            Ponumber.Value = ponumber;
            XmlAttribute DtePo = doc.CreateAttribute("dtePo");
            DtePo.Value = dtePo;

            XmlAttribute DteWarranty = doc.CreateAttribute("dteWarranty");
            DteWarranty.Value = dteWarranty;




            XmlAttribute DetInstalation = doc.CreateAttribute("detInstalation");
            DetInstalation.Value = detInstalation;
            XmlAttribute Lcoation = doc.CreateAttribute("lcoation");
            Lcoation.Value = lcoation;

            XmlAttribute Userenroll = doc.CreateAttribute("userenroll");
            Userenroll.Value = userenroll;
            XmlAttribute Invoicevalue = doc.CreateAttribute("invoicevalue");
            Invoicevalue.Value = invoicevalue;
            XmlAttribute Landedcost = doc.CreateAttribute("landedcost");
            Landedcost.Value = landedcost;

            XmlAttribute OtherCost = doc.CreateAttribute("otherCost");
            OtherCost.Value = otherCost;

            XmlAttribute Accusitioncost = doc.CreateAttribute("accusitioncost");
            Accusitioncost.Value = accusitioncost;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Assetname = doc.CreateAttribute("assetname");
            Assetname.Value = assetname;

            XmlAttribute Description = doc.CreateAttribute("description");
            Description.Value = description;
            XmlAttribute Hscode = doc.CreateAttribute("hscode");
            Hscode.Value = hscode;


            XmlAttribute Issudate = doc.CreateAttribute("issudate");
            Issudate.Value = issudate;

            XmlAttribute GrnDate = doc.CreateAttribute("grnDate");
            GrnDate.Value = grnDate;
            XmlAttribute Servicedate = doc.CreateAttribute("servicedate");
            Servicedate.Value = servicedate;
            XmlAttribute Countryorigin = doc.CreateAttribute("countryorigin");
            Countryorigin.Value = countryorigin;

            XmlAttribute Manufacturer = doc.CreateAttribute("manufacturer");
            Manufacturer.Value = manufacturer;
            XmlAttribute ProvideSlnumber = doc.CreateAttribute("provideSlnumber");
            ProvideSlnumber.Value = provideSlnumber;
            XmlAttribute Modelono = doc.CreateAttribute("modelono");
            Modelono.Value = modelono;
            XmlAttribute Lcnumber = doc.CreateAttribute("lcnumber");
            Lcnumber.Value = lcnumber;

            XmlAttribute Others = doc.CreateAttribute("others");
            Others.Value = others;

            XmlAttribute Capacity = doc.CreateAttribute("capacity");
            Capacity.Value = capacity;
            XmlAttribute Recommandlife = doc.CreateAttribute("recommandlife");
            Recommandlife.Value = recommandlife;
            XmlAttribute DepMethode = doc.CreateAttribute("depMethode");
            DepMethode.Value = depMethode;

            XmlAttribute DepRate = doc.CreateAttribute("depRate");
            DepRate.Value = depRate;
            XmlAttribute DteDepRunDate = doc.CreateAttribute("dteDepRunDate");
            DteDepRunDate.Value = dteDepRunDate;




            
            node.Attributes.Append(Reffid);
            node.Attributes.Append(Unit);
            node.Attributes.Append(Jobstation);
            node.Attributes.Append(Asettype);
            node.Attributes.Append(Mazorcategory);
            node.Attributes.Append(Minorcatagory1);
            node.Attributes.Append(Minorcatagory2);
            node.Attributes.Append(Coscenter);
            node.Attributes.Append(Suppliers);
            node.Attributes.Append(Ponumber);
            node.Attributes.Append(DtePo);
            node.Attributes.Append(DteWarranty);
            node.Attributes.Append(DetInstalation);
            node.Attributes.Append(Lcoation);
            node.Attributes.Append(Userenroll);
            node.Attributes.Append(Invoicevalue);

            node.Attributes.Append(Landedcost);
            node.Attributes.Append(OtherCost);
            node.Attributes.Append(Accusitioncost);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(Assetname);
            node.Attributes.Append(Description);
            node.Attributes.Append(Hscode);

            node.Attributes.Append(Issudate);
            node.Attributes.Append(GrnDate);
            node.Attributes.Append(DepRate);
            node.Attributes.Append(Issudate);
            node.Attributes.Append(Servicedate);

            node.Attributes.Append(Countryorigin);
            node.Attributes.Append(Manufacturer);
            node.Attributes.Append(ProvideSlnumber);
            node.Attributes.Append(Modelono);
            node.Attributes.Append(Lcnumber);

            node.Attributes.Append(Others);
            node.Attributes.Append(Capacity);
            node.Attributes.Append(Recommandlife);
            node.Attributes.Append(DepMethode);
            node.Attributes.Append(DepRate);
            node.Attributes.Append(DteDepRunDate);
            return node;


        }


      
      
        public string GetJSFunctionString(object intAutoid,object majorType)
        {
            string str = "";
            str = intAutoid.ToString() + ',' + majorType.ToString();
            return str;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                LoadView();
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                int intAutoID = int.Parse(datas[0].ToString());
                int majorType= int.Parse(datas[1].ToString());
                hdnReceive.Value = intAutoID.ToString();
                if (majorType == 8)
                {
                   
                    try { File.Delete(filePathXMlCwipLand); } catch { }




                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDivVehicle();", true);
                   VehicleAssetInfoLoad();
                }
                else if (majorType == 5)                
                {
                    try { File.Delete(filePathXMlCwipLand); } catch { }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnLandDiv();", true);

                    LandAssetInfoLoad();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                }
                else if (majorType == 6)
                {
                    try { File.Delete(filePathXMlCwipLand); } catch { }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnBuildingDiv();", true);
                      BuildingAssetInfoLoad();
                   
                }
                else
                {
                    try { File.Delete(filePathXMlCwipLand); } catch { }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);

                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    DataTable pk = new DataTable();
                    pk = parking.CwipAssetView(3, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, intAutoID);
                    if (pk.Rows.Count > 0)
                    {


                        try { ddlUnit.SelectedValue = pk.Rows[0]["intUnit"].ToString(); }
                        catch { }
                        try
                        {
                            dt = objregister.JobstationName(8, int.Parse(ddlUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                            dlJobstation.DataSource = dt;
                            dlJobstation.DataTextField = "strJobStationName";
                            dlJobstation.DataValueField = "intEmployeeJobStationId";
                            dlJobstation.DataBind();
                        }
                        catch { }
                        try { dlJobstation.SelectedValue = pk.Rows[0]["intjobstationid"].ToString(); } catch { }

                        dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
                        ddlMinorCate1.DataSource = dt;
                        ddlMinorCate1.DataTextField = "strCategoryName";
                        ddlMinorCate1.DataValueField = "intCategoryID";
                        ddlMinorCate1.DataBind();




                        ddlAssetType.SelectedValue = pk.Rows[0]["intMaintype"].ToString();
                        ddlMajorCat.SelectedValue = pk.Rows[0]["intAssetType"].ToString();
                        try { ddlMinorCate1.SelectedValue = pk.Rows[0]["intMinorCatagory1"].ToString(); } catch { }

                        try { ddlMinorCate2.SelectedValue = pk.Rows[0]["intMinorCatagory2"].ToString(); } catch { }

                        

                        dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                        ddlCostCenter.DataSource = dt;
                        ddlCostCenter.DataTextField = "Name";
                        ddlCostCenter.DataValueField = "Id";
                        ddlCostCenter.DataBind();

                        try
                        {
                            ddlCostCenter.SelectedValue = pk.Rows[0]["intCostCenter"].ToString();
                        }
                        catch { }

                        txtSuppliers.Text = pk.Rows[0]["suppliers"].ToString();
                        txtPonumbers.Text = pk.Rows[0]["intPoNumber"].ToString();
                        dtePoDate.Text = pk.Rows[0]["dtePo"].ToString();
                        dteWarintyExpire.Text = pk.Rows[0]["dteWarranty"].ToString();
                        txtDateInstalation.Text = pk.Rows[0]["detInstalation"].ToString();
                        txtAssetLocation.Text = pk.Rows[0]["strlcoation"].ToString();
                        txtEnrolment.Text = pk.Rows[0]["intUserEnroll"].ToString();
                        txtInvoiceValue.Text = pk.Rows[0]["monInvoicevalue"].ToString();
                        txtLandedCost.Text = pk.Rows[0]["monLandedcost"].ToString();
                        txtErectionOtherCost.Text = pk.Rows[0]["monOtherCost"].ToString();
                        txtAcisitionCost.Text = pk.Rows[0]["monAccusitioncost"].ToString();
                        txtRemarks.Text = pk.Rows[0]["strRemarks"].ToString();


                        txtAssetname.Text = pk.Rows[0]["strNameOfAsset"].ToString();
                        txtDescription.Text = pk.Rows[0]["strDescription"].ToString();
                        txtHsCode.Text = pk.Rows[0]["strHScode"].ToString();
                        txtIssueDate.Text = pk.Rows[0]["dteIssudate"].ToString();
                        txtGrndDate.Text = pk.Rows[0]["dteGRN"].ToString();
                        txtServiceDate.Text = pk.Rows[0]["dteServicedate"].ToString();
                        txtCountryOrigin.Text = pk.Rows[0]["strCountryorigin"].ToString();
                        txtManufacturer.Text = pk.Rows[0]["strManufacturer"].ToString();
                        txtManuProviceSlNo.Text = pk.Rows[0]["strProvideSlnumber"].ToString();
                        txtModelNo.Text = pk.Rows[0]["strModelono"].ToString();

                        txtLCnumber.Text = pk.Rows[0]["strLcnumber"].ToString();
                        txtOthers.Text = pk.Rows[0]["strOthers"].ToString();
                        txtCapacity.Text = pk.Rows[0]["strCapacity"].ToString();
                        txtRecommandLife.Text = pk.Rows[0]["monRecommandlife"].ToString();
                        ddlMethodOfDep.SelectedValue = pk.Rows[0]["intDepMethode"].ToString();
                        txtRateDep.Text = pk.Rows[0]["monDepRate"].ToString();
                        txtDepRunDate.Text = pk.Rows[0]["dteDepRun"].ToString();
                        try
                        {
                            txtProjectID.Text = pk.Rows[0]["projectid"].ToString();
                            txtProjectName.Text = pk.Rows[0]["projectName"].ToString();
                            txtAssetLocation.Text = pk.Rows[0]["location"].ToString();
                        }
                        catch { }

                        try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
                        try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
                        try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
                        txtAcisitionCost.Text = (landedcost + otherCost).ToString();
                        txtAcisitionCost.ReadOnly = true;
                    }




              


                }
            }
            catch { }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
           
            divClose();
        }

        private void divClose()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                dt = objregister.JobstationName(8, int.Parse(ddlUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                dlJobstation.DataSource = dt;
                dlJobstation.DataTextField = "strJobStationName";
                dlJobstation.DataValueField = "intEmployeeJobStationId";
                dlJobstation.DataBind();

                dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                ddlCostCenter.DataSource = dt;
                ddlCostCenter.DataTextField = "Name";
                ddlCostCenter.DataValueField = "Id";
                ddlCostCenter.DataBind();
            }
            catch { }
       
        }

        protected void ddlJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
            ddlMinorCate1.DataSource = dt;
            ddlMinorCate1.DataTextField = "strCategoryName";
            ddlMinorCate1.DataValueField = "intCategoryID";
            ddlMinorCate1.DataBind();
        }

        protected void ddlMajorCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }

        protected void ddlMinorCate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }
    }
}
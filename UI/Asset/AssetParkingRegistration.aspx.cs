using Flogging.Core;
using GLOBAL_BLL;
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
    public partial class AssetParkingRegistration : System.Web.UI.Page
    {
        string filePathForXMlAssetParking;
        string XMLVehicle, XMLBuilding, XMLLand;   
        string xmlStringG = "";
        AssetParking_BLL parking = new AssetParking_BLL();
        Assetregister_BLL objregister = new Assetregister_BLL();
        DataTable dt = new DataTable(); 
        int? unit=null, jobstation=null, asettype=null, mazorcategory=null, minorcatagory1=null, minorcatagory2=null, coscenter=null, ponumber=null, userenroll=null, depMethode=null, intItemid=null, intMrrId=null, intPoID=null, enroll=null;
        decimal invoicevalue, landedcost, otherCost, accusitioncost, depRate, recommandlife, totalaccdep, recieveqty; 
        DateTime? dtePo=null, dteWarranty=null , detInstalation=null, issudate=null, grnDate=null, servicedate=null, dteDepRunDate=null;

       

        string suppliers, lcoation, remarks, assetname, description, hscodecountryorigin, manufacturer, provideSlnumber, modelono, lcnumber, others, capacity;
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\AssetManualRegistration";
        string stop = "stopping Asset\\AssetManualRegistration";

        protected void Page_Load(object sender, EventArgs e)
        {
           filePathForXMlAssetParking = Server.MapPath("~/Asset/Data/p_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            try { File.Delete(filePathForXMlAssetParking); }
            catch { }
            if (!IsPostBack)
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                dt = parking.CwipAssetView(19, "", "", "", "", 0, intenroll);//Parking List
                ddlUnitby.DataSource = dt;
                ddlUnitby.DataTextField = "strName";
                ddlUnitby.DataValueField = "Id";
                ddlUnitby.DataBind();
                ddlUnitby.Items.Insert(0, new ListItem("Select", "0"));

            }
            else
            {

            }
        }
        protected void ddlUnitby_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            dt = parking.CwipAssetView(20, "", "", "", "", 0, int.Parse(ddlUnitby.SelectedValue));//Parking List
            ddlWh.DataSource = dt;
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
            ddlWh.Items.Insert(0, new ListItem("Select", "0"));
            dgvGridView.DataSource = "";
            dgvGridView.DataBind();
        }
        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGridView.DataSource = "";
            dgvGridView.DataBind();
        }
        protected void btnMrrView_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetManualRegistration btnMrrView_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                if(txtMrrId.Text.Length>3)
                {
                    dt = parking.CwipAssetView(12, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, decimal.Parse(txtMrrId.Text.ToString()), intenroll);//Parking List

                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                    dt.Clear();
                }
                else if (int.Parse(ddlWh.SelectedValue)>0)
                {
                    dt = parking.CwipAssetView(21, xmlStringG, XMLVehicle, XMLBuilding, XMLLand,0, int.Parse(ddlWh.SelectedValue));//Parking List

                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                    dt.Clear();

                }
                else
                {
                    dt = parking.CwipAssetView(5, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List 
                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                    dt.Clear();
                }

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

        private void LoadView()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd); 

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetManualRegistration LoadView", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
            ddlUnit.Items.Insert(0, new ListItem("Select", "0"));

            dt = objregister.JobstationName(8, int.Parse(ddlUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            dlJobstation.DataSource = dt;
            dlJobstation.DataTextField = "strJobStationName";
            dlJobstation.DataValueField = "intEmployeeJobStationId";
            dlJobstation.DataBind(); 
            dlJobstation.Items.Insert(0, new ListItem("Select", "0"));

            dt = objregister.AssetTypeName();
            ddlMajorCat.DataSource = dt;
            ddlMajorCat.DataTextField = "strAssetTypeName";
            ddlMajorCat.DataValueField = "intAssetTypeID";
            ddlMajorCat.DataBind();
            ddlMajorCat.Items.Insert(0, new ListItem("Select", "0"));

            dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
            ddlCostCenter.DataSource = dt;
            ddlCostCenter.DataTextField = "Name";
            ddlCostCenter.DataValueField = "Id";
            ddlCostCenter.DataBind();           
            ddlCostCenter.Items.Insert(0, new ListItem("Select", "0"));



            dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
            ddlMinorCate1.DataSource = dt;
            ddlMinorCate1.DataTextField = "strCategoryName";
            ddlMinorCate1.DataValueField = "intCategoryID";
            ddlMinorCate1.DataBind();
            ddlMinorCate1.Items.Insert(0, new ListItem("Select", "0"));

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlMinorCate2.DataSource = dt;
            ddlMinorCate2.DataTextField = "Name";
            ddlMinorCate2.DataValueField = "ID";
            ddlMinorCate2.DataBind();
            ddlMinorCate2.Items.Insert(0, new ListItem("Select", "0"));



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


        

        protected void btnSave_Click(object sender, EventArgs e)
        { 

            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetManualRegistration btnSave_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
           
            if (hdnPreConfirm.Value == "1")
            {
                try { File.Delete(filePathForXMlAssetParking); }
                catch { }
                try
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
                    int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    txtAcisitionCost.ReadOnly = false;

                    try { unit = int.Parse(ddlUnit.SelectedValue); } catch { unit = 1; }
                    try { jobstation = int.Parse(dlJobstation.SelectedValue); } catch { jobstation = 0; }
                    try { asettype = int.Parse(ddlAssetType.SelectedValue); } catch { asettype = 0; }
                    try { mazorcategory = int.Parse(ddlMajorCat.SelectedValue); } catch { mazorcategory = 0; }
                    try { minorcatagory1 = int.Parse(ddlMinorCate1.SelectedValue); } catch { minorcatagory1 = 0; }
                    try { minorcatagory2 = int.Parse(ddlMinorCate2.SelectedValue); } catch { minorcatagory2 = null; }
                    try { coscenter = int.Parse(ddlCostCenter.SelectedValue); } catch { coscenter = null; }


                    suppliers = txtSuppliers.Text.ToString();
                    try { ponumber = int.Parse(txtPonumbers.Text.ToString()); } catch { ponumber = 0; }
                    try { dtePo = DateTime.Parse(dtePoDate.Text); } catch { dtePo = DateTime.Parse("1990-01-01".ToString()); }
                    try { dteWarranty = DateTime.Parse(dteWarintyExpire.Text); } catch { dteWarranty = DateTime.Parse("1990-01-01".ToString()); }
                    try { detInstalation = DateTime.Parse(txtDateInstalation.Text); } catch { detInstalation = DateTime.Parse("1990-01-01".ToString()); }

                    string lcoation = txtAssetLocation.Text.ToString();
                    try { userenroll = int.Parse(txtEnrolment.Text); } catch { userenroll = 0; }
                    try { invoicevalue = decimal.Parse(txtInvoiceValue.Text.ToString()); } catch { invoicevalue = 0; }
                    try { landedcost = decimal.Parse(txtLandedCost.Text.ToString()); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtErectionOtherCost.Text.ToString()); } catch { otherCost = 0; }
                    try { accusitioncost = decimal.Parse(txtAcisitionCost.Text.ToString()); } catch { accusitioncost = 0; }
                    string remarks = txtRemarks.Text.ToString();
                    string group = txtGroupName.Text.ToString();
                    string projectName = txtProjectName.Text.ToString();


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
                    try { recommandlife = decimal.Parse(txtRecommandLife.Text.ToString()); } catch { recommandlife = 0; }
                    try { depMethode = int.Parse(ddlMethodOfDep.SelectedValue); } catch { depMethode = 0; }
                    try { depRate = decimal.Parse(txtRateDep.Text.ToString()); } catch { depRate = 0; }
                    try { dteDepRunDate = DateTime.Parse(txtDepRunDate.Text.ToString()); } catch { dteDepRunDate = DateTime.Parse("1990-01-01".ToString()); ; }
                    try { totalaccdep = decimal.Parse(txtAccDep.Text.ToString()); } catch { totalaccdep = 0; }
                    
                    try { intItemid = int.Parse(hdnItemID.Value.ToString()); } catch { intItemid = 0; }
                    try { intMrrId = int.Parse(hdnMrrID.Value.ToString()); } catch { intMrrId = 0; }
                    try { intPoID = int.Parse(hdnPoID.Value.ToString()); } catch { intPoID = 0; }
                    try { recieveqty = decimal.Parse(txtAssetQty.Text.ToString()); } catch { recieveqty = 0; }

                    

                    if (ddlUnit.Enabled && recieveqty > 0)
                    { 
                        CreateParkingXML(intItemid.ToString(), intMrrId.ToString(), intPoID.ToString(), unit.ToString(), jobstation.ToString(), asettype.ToString(), mazorcategory.ToString(), minorcatagory1.ToString(), minorcatagory2.ToString(), coscenter.ToString(), suppliers, ponumber.ToString(), dtePo.ToString(), dteWarranty.ToString(), detInstalation.ToString(), lcoation
                       , userenroll.ToString(), invoicevalue.ToString(), landedcost.ToString(), otherCost.ToString(), accusitioncost.ToString(), remarks, assetname, description, hscode, issudate.ToString(), grnDate.ToString(), servicedate.ToString(), countryorigin,
                       manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife.ToString(), depMethode.ToString(), depRate.ToString(), dteDepRunDate.ToString(), totalaccdep.ToString(),group, projectName);

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMlAssetParking);
                        XmlNode dSftTm = doc.SelectSingleNode("voucher");
                        string xmlStringG = dSftTm.InnerXml;
                        xmlStringG = "<voucher>" + xmlStringG + "</voucher>";
                        int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                        try { File.Delete(filePathForXMlAssetParking); }
                        catch { }
                        string message = parking.InsertParkingData(1, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);
                        lblMessage.Text =" " +message.ToString();
                        dt = parking.CwipAssetView(5, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
                        dgvGridView.DataSource = dt;
                        dgvGridView.DataBind();
                        DataClear();

                       
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                    }
                    else
                    {
                        if (intItemid > 0 && intMrrId > 0 && invoicevalue > 0 && recieveqty > 0)
                        {
                           
                           // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup();", true);
                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#MyPopup').modal('hide')", true);

                            CreateParkingXML(intItemid.ToString(), intMrrId.ToString(), intPoID.ToString(), unit.ToString(), jobstation.ToString(), asettype.ToString(), mazorcategory.ToString(), minorcatagory1.ToString(), minorcatagory2.ToString(), coscenter.ToString(), suppliers, ponumber.ToString(), dtePo.ToString(), dteWarranty.ToString(), detInstalation.ToString(), lcoation
                            , userenroll.ToString(), invoicevalue.ToString(), landedcost.ToString(), otherCost.ToString(), accusitioncost.ToString(), remarks, assetname, description, hscode, issudate.ToString(), grnDate.ToString(), servicedate.ToString(), countryorigin,
                            manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife.ToString(), depMethode.ToString(), depRate.ToString(), dteDepRunDate.ToString(), totalaccdep.ToString(), group, projectName);

                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMlAssetParking);
                            XmlNode dSftTm = doc.SelectSingleNode("voucher");
                            string xmlStringG = dSftTm.InnerXml;
                            xmlStringG = "<voucher>" + xmlStringG + "</voucher>";
                            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                            try { File.Delete(filePathForXMlAssetParking); }
                            catch { }
                            string message = parking.InsertParkingData(1, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);
                            dt = parking.CwipAssetView(5, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
                            dgvGridView.DataSource = dt;
                            dgvGridView.DataBind();
                            DataClear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                          

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-Up Invoice Value or Asset Qty');", true);
                            try { File.Delete(filePathForXMlAssetParking); }
                            catch { }
                        }
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
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            }
           

            }

        private void DataClear()
        {
            txtPonumbers.Text = "0".ToString();
            txtSuppliers.Text = "0".ToString();
            dtePoDate.Text = "0".ToString();
            txtInvoiceValue.Text = "0".ToString();
            txtLandedCost.Text = "0".ToString();
            txtAssetname.Text = "0".ToString();
            txtDescription.Text = "0".ToString();
            txtHsCode.Text = "0".ToString();
            txtIssueDate.Text = "0".ToString();
            txtAssetQty.Text = "0".ToString();
            txtAcisitionCost.Text = "0".ToString();

            txtGroupName.Text = "0".ToString();
            txtProjectName.Text = "0".ToString();
            txtAssetLocation.Text = "0".ToString();
            txtCountryOrigin.Text = "0".ToString(); ;
            txtManufacturer.Text = "0".ToString();
            txtModelNo.Text = "0".ToString();
        }

        private void CreateParkingXML(string intItemid, string intMrrId,string intPoID, string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1, string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation, string lcoation, string userenroll, string invoicevalue, string landedcost, string otherCost,string accusitioncost, string remarks, string assetname, string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer, string provideSlnumber, 
            string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode, string depRate, string dteDepRunDate,string totalaccdep,string group,string projectName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemid, intMrrId, intPoID,unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost, accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate, totalaccdep, group, projectName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemid, intMrrId, intPoID, unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost,accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate, totalaccdep, group, projectName);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string intItemid, string intMrrId, string intPoID, string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1,
        string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation,
        string lcoation, string userenroll, string invoicevalue, string landedcost, string otherCost, string accusitioncost, string remarks, string assetname,
        string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer,
        string provideSlnumber, string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode,
        string depRate, string dteDepRunDate, string totalaccdep, string group, string projectName)

        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute IntItemid = doc.CreateAttribute("intItemid");
            IntItemid.Value = intItemid;

            XmlAttribute IntMrrId = doc.CreateAttribute("intMrrId");
            IntMrrId.Value = intMrrId;

            XmlAttribute IntPoID = doc.CreateAttribute("intPoID");
            IntPoID.Value = intPoID;

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
            XmlAttribute Totalaccdep = doc.CreateAttribute("totalaccdep");
            Totalaccdep.Value = totalaccdep; 
            XmlAttribute Group = doc.CreateAttribute("group");
            Group.Value = group;
            XmlAttribute ProjectName = doc.CreateAttribute("projectName");
            ProjectName.Value = projectName;


             
            node.Attributes.Append(IntItemid);
            node.Attributes.Append(IntMrrId);
            node.Attributes.Append(IntPoID);


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
            node.Attributes.Append(Totalaccdep);

            return node;


        }

        public string GetJSFunctionString(object intItem, object intPO, object intMrrID,object numReceiveQty)
        {
            string str = "";
            str = intItem.ToString() + ',' + intPO.ToString() + ',' + intMrrID.ToString()+ ',' + numReceiveQty.ToString();
            return str;
        }
        
        protected void btnManuals_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true); 
             
           
            ddlUnit.Enabled = true;
            dlJobstation.Enabled = true;
            txtPonumbers.Enabled = true;
            txtAcisitionCost.Enabled = true;

            hdnItemID.Value = "0".ToString();
            hdnMrrID.Value = "0".ToString();
            hdnPoID.Value = "0".ToString();

            LoadView();
            txtPonumbers.Text = "0".ToString();
            txtSuppliers.Text = "0".ToString();
            dtePoDate.Text = "0".ToString();
            txtInvoiceValue.Text = "0".ToString();
            txtLandedCost.Text = "0".ToString();
            txtAssetname.Text = "0".ToString();
            txtDescription.Text = "0".ToString();
            txtHsCode.Text = "0".ToString();
            txtIssueDate.Text = "0".ToString();
            txtAssetQty.Text = "0".ToString();
            txtAcisitionCost.Text = "0".ToString();

            txtGroupName.Text = "0".ToString();
            txtProjectName.Text = "0".ToString();
            txtAssetLocation.Text = "0".ToString();
            txtCountryOrigin.Text = "0".ToString(); ;
            txtManufacturer.Text = "0".ToString();
            txtModelNo.Text = "0".ToString(); 
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true); 

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd); 
            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetManualRegistration btnSubmit_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                ddlUnit.Enabled = false;
                dlJobstation.Enabled = false;
                txtPonumbers.Enabled = false; 

                LoadView();
                hdnItemID.Value ="0".ToString();
                hdnMrrID.Value ="0".ToString();
                hdnPoID.Value ="0".ToString();

                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string intItem =datas[0].ToString();
                string intPO = datas[1].ToString();
                string intMrrID =datas[2].ToString();

                hdnReceive.Value = datas[3].ToString();
                hdnItemID.Value = intItem.ToString();
                hdnMrrID.Value = intMrrID.ToString();
                hdnPoID.Value = intPO.ToString();

                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                DataTable pk = new DataTable();
                xmlStringG = "<voucher><voucherentry intItem=" + '"' + intItem + '"' + "/></voucher>".ToString();
                XMLVehicle = "<voucher><voucherentry intPO=" + '"' + intPO + '"' + "/></voucher>".ToString();
                XMLBuilding = "<voucher><voucherentry intMrrID=" + '"' + intMrrID + '"' + "/></voucher>".ToString();
                pk = parking.CwipAssetView(11, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, 0, 0);
                //pk = parking.ParkingDetalis(intItem, intPO, intMrrID);
                if (pk.Rows.Count > 0)
                {
                    try { ddlUnit.SelectedValue = pk.Rows[0]["intunitid"].ToString(); }
                    catch { }
                    try
                    {
                        dt = objregister.JobstationName(8, int.Parse(ddlUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                        dlJobstation.DataSource = dt;
                        dlJobstation.DataTextField = "strJobStationName";
                        dlJobstation.DataValueField = "intEmployeeJobStationId";
                        dlJobstation.DataBind();
                        dlJobstation.Items.Insert(0, new ListItem("Select", "0"));

                        dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                        ddlCostCenter.DataSource = dt;
                        ddlCostCenter.DataTextField = "Name";
                        ddlCostCenter.DataValueField = "Id";
                        ddlCostCenter.DataBind();
                        ddlCostCenter.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    catch { }
                    try { dlJobstation.SelectedValue = pk.Rows[0]["intJobStationId"].ToString(); } catch { }

                    txtPonumbers.Text = pk.Rows[0]["intPOID"].ToString();
                    txtSuppliers.Text = pk.Rows[0]["strSupplierName"].ToString();
                    try { dtePoDate.Text = pk.Rows[0]["dtePODate"].ToString(); } catch { }
                    try { txtInvoiceValue.Text = pk.Rows[0]["monAmount"].ToString(); } catch { }
                    try { txtLandedCost.Text = pk.Rows[0]["monBDTTotal"].ToString(); } catch { }
                    try { txtAssetname.Text = pk.Rows[0]["strItem"].ToString(); } catch { }
                    try { txtDescription.Text = pk.Rows[0]["strItem"].ToString(); } catch { }
                    try { txtHsCode.Text = pk.Rows[0]["strHSCode"].ToString(); } catch { }
                    try { txtIssueDate.Text = pk.Rows[0]["dteChallanDate"].ToString(); } catch { }
                    try { txtAssetQty.Text = hdnReceive.Value; } catch { }
                    try { txtGrndDate.Text = pk.Rows[0]["MrrDate"].ToString(); } catch { } 


                    try { txtProjectName.Text = pk.Rows[0]["projectName"].ToString(); } catch { }
                    try { txtAssetLocation.Text = pk.Rows[0]["locations"].ToString(); } catch { }
                    try { txtCountryOrigin.Text = pk.Rows[0]["countryorigin"].ToString(); } catch { }
                    try { txtManufacturer.Text = pk.Rows[0]["manufacturer"].ToString(); } catch { }
                    try { txtModelNo.Text = pk.Rows[0]["modelno"].ToString(); } catch { } 

                    try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
                    try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
                    txtAcisitionCost.Text = (landedcost + otherCost).ToString();
                    txtAcisitionCost.ReadOnly = true;
                    
                }
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
             //ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", " ClosePopup();", true);
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
                dlJobstation.Items.Insert(0, new ListItem("Select", "0"));

                dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                ddlCostCenter.DataSource = dt;
                ddlCostCenter.DataTextField = "Name";
                ddlCostCenter.DataValueField = "Id";
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem("Select", "0"));
               // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup();", true);

            }
            catch { }
           
        }

        protected void ddlMajorCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup();", true);
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }

        protected void ddlMinorCate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup();", true);
            // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + "title" + "', '" + "body" + "');", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }
        protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + "title" + "', '" + "body" + "');", true);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup();", true);
            dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
            ddlMinorCate1.DataSource = dt;
            ddlMinorCate1.DataTextField = "strCategoryName";
            ddlMinorCate1.DataValueField = "intCategoryID";
            ddlMinorCate1.DataBind();
            ddlMinorCate1.Items.Insert(0, new ListItem("Select", "0"));

        }
        
    }
}
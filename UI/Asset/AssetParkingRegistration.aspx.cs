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
        string XMLVehicle, XMLBuilding, XMLLand; int enroll;decimal recieveqty;
        string xmlStringG = "";
        AssetParking_BLL parking = new AssetParking_BLL();
        Assetregister_BLL objregister = new Assetregister_BLL();
        DataTable dt = new DataTable(); 
        int unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, ponumber, userenroll, depMethode;
        decimal invoicevalue, landedcost, otherCost, accusitioncost, depRate, recommandlife, totalaccdep; 
        DateTime dtePo, dteWarranty, detInstalation, issudate, grnDate, servicedate, dteDepRunDate; 
        string suppliers, lcoation, remarks, assetname, description, hscodecountryorigin, manufacturer, provideSlnumber, modelono, lcnumber, others, capacity;


        protected void Page_Load(object sender, EventArgs e)
        {
           filePathForXMlAssetParking = Server.MapPath("~/Asset/Data/p_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            try { File.Delete(filePathForXMlAssetParking); }
            catch { }
            if (!IsPostBack)
            {
               

               
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                dt = parking.CwipAssetView(5, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List

                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();



            }
            else
            {

            }
        }

        private void LoadView()
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

            dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
            ddlCostCenter.DataSource = dt;
            ddlCostCenter.DataTextField = "Name";
            ddlCostCenter.DataValueField = "Id";
            ddlCostCenter.DataBind();

          

            dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
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
            txtAcisitionCost.Text = (landedcost + otherCost).ToString();
            txtAcisitionCost.ReadOnly = true;
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
                try { dtePo = DateTime.Parse(dtePoDate.Text); } catch { dtePo = DateTime.Parse("1990-01-01".ToString()); }
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
                try { depRate = decimal.Parse(txtRateDep.Text); } catch { depRate = 0; }
                try { dteDepRunDate = DateTime.Parse(txtDepRunDate.Text); } catch { dteDepRunDate = DateTime.Parse("1990-01-01".ToString()); }
                try { totalaccdep = decimal.Parse(txtAccDep.Text.ToString()); } catch { totalaccdep = 0; }

                string intItemid =hdnItemID.Value; string intMrrId=hdnMrrID.Value;string intPoID = hdnPoID.Value;

                CreateParkingXML(intItemid, intMrrId, intPoID, unit.ToString(), jobstation.ToString(), asettype.ToString(), mazorcategory.ToString(), minorcatagory1.ToString(), minorcatagory2.ToString(), coscenter.ToString(), suppliers, ponumber.ToString(), dtePo.ToString(), dteWarranty.ToString(), detInstalation.ToString(), lcoation
                , userenroll.ToString(), invoicevalue.ToString(), landedcost.ToString(), otherCost.ToString(), accusitioncost.ToString(), remarks, assetname, description, hscode, issudate.ToString(), grnDate.ToString(), servicedate.ToString(), countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife.ToString(), depMethode.ToString(), depRate.ToString(), dteDepRunDate.ToString(), totalaccdep.ToString());


                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMlAssetParking);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlStringG = dSftTm.InnerXml;
                xmlStringG = "<voucher>" + xmlStringG + "</voucher>";
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                recieveqty = decimal.Parse(txtAssetQty.Text);
                try { File.Delete(filePathForXMlAssetParking);  }
                catch { }
                string message = parking.InsertParkingData(1, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty,intenroll);              
              

                dt = parking.CwipAssetView(5, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
            catch { }

        } 
        private void CreateParkingXML(string intItemid, string intMrrId,string intPoID, string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1, string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation, string lcoation, string userenroll, string invoicevalue, string landedcost, string otherCost,string accusitioncost, string remarks, string assetname, string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer, string provideSlnumber, string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode, string depRate, string dteDepRunDate,string totalaccdep)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemid, intMrrId, intPoID,unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost, accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate, totalaccdep);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemid, intMrrId, intPoID, unit, jobstation, asettype, mazorcategory, minorcatagory1, minorcatagory2, coscenter, suppliers, ponumber, dtePo, dteWarranty, detInstalation, lcoation
                , userenroll, invoicevalue, landedcost, otherCost,accusitioncost, remarks, assetname, description, hscode, issudate, grnDate, servicedate, countryorigin,
                manufacturer, provideSlnumber, modelono, lcnumber, others, capacity, recommandlife, depMethode, depRate, dteDepRunDate, totalaccdep);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNode(XmlDocument doc,string intItemid, string intMrrId,string intPoID, string unit, string jobstation, string asettype, string mazorcategory, string minorcatagory1, 
        string minorcatagory2, string coscenter, string suppliers, string ponumber, string dtePo, string dteWarranty, string detInstalation, 
        string lcoation, string userenroll, string invoicevalue, string landedcost,string otherCost, string accusitioncost, string remarks, string assetname,
        string description, string hscode, string issudate, string grnDate, string servicedate, string countryorigin, string manufacturer, 
        string provideSlnumber, string modelono, string lcnumber, string others, string capacity, string recommandlife, string depMethode,
        string depRate, string dteDepRunDate,string totalaccdep)

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
        protected void btnManual_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            txtAccDep.Visible = true;
            lblAccdep.Visible = true;
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
            try
            {
                txtProjectID.Text = "0".ToString();
                txtProjectName.Text = "0".ToString();
                txtAssetLocation.Text = "0".ToString();
                txtCountryOrigin.Text = "0".ToString(); ;
                txtManufacturer.Text = "0".ToString();
                txtModelNo.Text = "0".ToString();
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            try
            {
                LoadView();

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

                        dt = objregister.RegCostCenter(int.Parse(ddlUnit.SelectedValue));
                        ddlCostCenter.DataSource = dt;
                        ddlCostCenter.DataTextField = "Name";
                        ddlCostCenter.DataValueField = "Id";
                        ddlCostCenter.DataBind();
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
                    try
                    {
                        txtProjectID.Text = pk.Rows[0]["projectid"].ToString();
                    }
                    catch { }
                    }
                  
                    try { txtProjectName.Text = pk.Rows[0]["projectName"].ToString(); } catch { }
                    try { txtAssetLocation.Text = pk.Rows[0]["locations"].ToString(); } catch { }
                    try { txtCountryOrigin.Text = pk.Rows[0]["countryorigin"].ToString(); } catch { }
                    try { txtManufacturer.Text = pk.Rows[0]["manufacturer"].ToString(); } catch { }
                    try { txtModelNo.Text = pk.Rows[0]["modelno"].ToString(); } catch { }
                    
                  



                    try { invoicevalue = decimal.Parse(txtInvoiceValue.Text); } catch { invoicevalue = 0; }
                    try { landedcost = decimal.Parse(txtLandedCost.Text); } catch { landedcost = 0; }
                    try { otherCost = decimal.Parse(txtErectionOtherCost.Text); } catch { otherCost = 0; }
                    txtAcisitionCost.Text = ( landedcost + otherCost).ToString();
                    txtAcisitionCost.ReadOnly = true;
                    lblAccdep.Visible = false;
                    txtAccDep.Visible = false;
                
            }
            catch { }

        }

        protected void btnClose_Click(object sender, EventArgs e)
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

        protected void ddlMajorCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }

        protected void ddlMinorCate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }
        protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            dt = objregister.DropdownCategoryView(int.Parse(dlJobstation.SelectedValue));
            ddlMinorCate1.DataSource = dt;
            ddlMinorCate1.DataTextField = "strCategoryName";
            ddlMinorCate1.DataValueField = "intCategoryID";
            ddlMinorCate1.DataBind();
        }
        
    }
}
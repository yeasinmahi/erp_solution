using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Transport
{
    public partial class InternalTransportRouteExpInEntry : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLDTFare; string xmlStringDTFare = ""; string xmlDtFare;
        string filePathForXMLDTFareCash; string xmlStringDTFareCash = ""; string xmlDtFareCash;
        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload; 
        string intPartyID; string fuelstation; string dieselcredit; string cngcredit; string totalcredit;
        string unitid; string shippointid; string unitname; string shippointname; string dtfarecredit;
        string strEnroll; int intUnitID; string inttype; int intID; int intWork;

        DateTime dteInDate; int intAdditionalMillage; decimal monLabourEXP; decimal monPoliceEXP;
        string strMaintenanceDesc; decimal monMaintenanceTK; string strOhtersDetail; decimal monOthersTK;
        decimal intNoOfDA; decimal monTripBonus; decimal monTimeAllow; decimal monTotalDTripFareCash;
        decimal monAdditionalFare; int intInInsertBy; string strAgentName; decimal monBridgeToll;
        decimal monFerryEXP; decimal monFuelCash; string agenttnam; string dtfarecash;

        string strCauseOfAdditionalMillage; string strCauseOfAdditionalFare;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strFuelPurchaseDate;
             
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            filePathForXML = Server.MapPath("~/Transport/Data/InFuelStation_" + hdnEnroll.Value + ".xml");
            filePathForXMLDTFare = Server.MapPath("~/Transport/Data/InDTFare_" + hdnEnroll.Value + ".xml");
            filePathForXMLDTFareCash = Server.MapPath("~/Transport/Data/InDTFareCash_" + hdnEnroll.Value + ".xml");
            filePathForXMLDocUpload = Server.MapPath("~/Transport/Data/DocUpload_" + hdnEnroll.Value + ".xml");
                       
            if (!IsPostBack)
            {
                try
                {   
                    File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    File.Delete(filePathForXMLDTFare); dgvDTFare.DataSource = ""; dgvDTFare.DataBind();
                    File.Delete(filePathForXMLDTFareCash); dgvDTFareCash.DataSource = ""; dgvDTFareCash.DataBind();
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    dt = new DataTable();
                    dt = obj.GetUnitList();
                    ddlUnitNameDTF.DataTextField = "strUnit";
                    ddlUnitNameDTF.DataValueField = "intUnitID";
                    ddlUnitNameDTF.DataSource = dt;
                    ddlUnitNameDTF.DataBind();
                    
                    dt = new DataTable();
                    intUnitID = int.Parse(ddlUnitNameDTF.SelectedValue.ToString());
                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPointDTF.DataTextField = "strName";
                    ddlShipPointDTF.DataValueField = "intId";
                    ddlShipPointDTF.DataSource = dt;
                    ddlShipPointDTF.DataBind();     

                    dt = new DataTable();
                    dt = obj.GetFuelStationList();
                    ddlFuelStation.DataTextField = "strPartyName";
                    ddlFuelStation.DataValueField = "intPartyID";
                    ddlFuelStation.DataSource = dt;
                    ddlFuelStation.DataBind();
                    ddlFuelStation.Items.Insert(0, new ListItem("", ""));


                    dt = new DataTable();
                    dt = obj.GetDocTypeList();
                    ddlDocType.DataTextField = "strDocType";
                    ddlDocType.DataValueField = "intDocType";
                    ddlDocType.DataSource = dt;
                    ddlDocType.DataBind();

                    lblQty.Visible = false;
                    txtQty.Visible = false;

                    if (hdnUnit.Value == "4")
                    {
                        lblQty.Visible = true;
                        txtQty.Visible = true;
                    }
                                                            
                    GetTripFareAndToll();
                    FuelCostLoadByTrip();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    
                }
                catch
                {}
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
            //else
            //{
            //    if (hdnField.Value != "0")
            //    {
            //        FTPUp();
            //        //lbldoc.Text = message;
            //    }
            //}
        }
        private void GetTripFareAndToll()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            dt = new DataTable();
            dt = obj.GetTripFareAndToll(intID);
            if (dt.Rows.Count > 0)
            {
                txtBridgeToll.Text = dt.Rows[0]["BnRToll"].ToString();
                txtFerryToll.Text = dt.Rows[0]["Ferrytoll"].ToString();                             
                txtTotalMillage.Text = dt.Rows[0]["Millage"].ToString();                
                txtLabourExp.Text = dt.Rows[0]["LabourEXP"].ToString();
                txtPolice.Text = dt.Rows[0]["PoliceEXP"].ToString();
                decimal trotecost = decimal.Parse(dt.Rows[0]["BnRToll"].ToString()) + decimal.Parse(dt.Rows[0]["Ferrytoll"].ToString()) + decimal.Parse(dt.Rows[0]["LabourEXP"].ToString()) + decimal.Parse(dt.Rows[0]["PoliceEXP"].ToString());
                txtTotalRouteExp.Text = trotecost.ToString();
                lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();
                lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();
                //txtFuelCash.Text = dt.Rows[0]["FuelCash"].ToString();
                hdnMillage.Value = dt.Rows[0]["Millage"].ToString();                
                hdnQty.Value = dt.Rows[0]["Quantity"].ToString();
                txtQty.Text = dt.Rows[0]["Quantity"].ToString();

                if (hdnUnit.Value == "94")
                {
                    hdnTFare.Value = dt.Rows[0]["TripFare"].ToString();
                    txtTotalTripFare.Text = dt.Rows[0]["TripFare"].ToString();
                }

                //lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();                
                //lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                //lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                //lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();
            }

            if (hdnUnit.Value != "94")
            {
                dt = new DataTable();
                dt = obj.GetTripFareForInEntry(intID);
                if (dt.Rows.Count > 0)
                {
                    hdnTFare.Value = dt.Rows[0]["monTripFare"].ToString();
                    txtTotalTripFare.Text = dt.Rows[0]["monTripFare"].ToString();
                }
            }

        }

        //** Gridview Fuel Station Add Start ******************************************************
        private void FuelCostLoadByTrip()
        {             
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            intWork = 4;
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            if (dt.Rows.Count > 0)
            {
                hdnDA.Value = dt.Rows[0]["DAllow"].ToString();
                hdnDTFare.Value = dt.Rows[0]["DownTripDAllow"].ToString();
                //txtDtripAllowance.Text = dt.Rows[0]["DownTripDAllow"].ToString();

                txtTripBonus.Text = dt.Rows[0]["monTripBonus"].ToString();

                hdnSingleMillage100KM.Value = dt.Rows[0]["MillageAllowSingle100KM"].ToString();
                hdnSingleMillage100AboveKM.Value = dt.Rows[0]["MillageAllowSingle100AboveKM"].ToString();
                                
                txtMillageAllowance.Text = dt.Rows[0]["MillageAllow"].ToString();
                hdnDieselTotalTk.Value = dt.Rows[0]["DieselPerKM"].ToString();
                hdnCNGTotalTk.Value = dt.Rows[0]["CNGPerKM"].ToString();

                hdnDieselPerKMOutStation.Value = dt.Rows[0]["DieselPerKMOutStation"].ToString();
                hdnCNGPerKMOutStation.Value = dt.Rows[0]["CNGPerKMOutStation"].ToString();
            }
            //Fuelcost();

            intWork = 3;
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            
            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    intPartyID = dt.Rows[index]["intPartyID"].ToString();
                    fuelstation = dt.Rows[index]["fuelstation"].ToString();
                    dieselcredit = dt.Rows[index]["dieselcredit"].ToString();
                    cngcredit = dt.Rows[index]["cngcredit"].ToString();
                    totalcredit = dt.Rows[index]["totalcredit"].ToString();
                    inttype = dt.Rows[index]["inttype"].ToString();
                    strFuelPurchaseDate = dt.Rows[index]["dteActualFuelDate"].ToString();
                    
                    grandtotal = 0;
                    grandtotaldtfare = 0;
                    totaldieselcredit = 0;
                    totalcngcredit = 0;

                    CreateVoucherXml(intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, inttype, strFuelPurchaseDate);
                    txtDieselCredit.Text = "";
                    txtCNGCredit.Text = "";
                }
            }

        }        
        protected void btnFuelCostAdd_Click(object sender, EventArgs e)
        {
            intPartyID = ddlFuelStation.SelectedValue.ToString();
            fuelstation = ddlFuelStation.SelectedItem.ToString();
            if (txtDieselCredit.Text == "") { dieselcredit = "0"; } else { dieselcredit = txtDieselCredit.Text; }
            if (txtCNGCredit.Text == "") { cngcredit = "0"; } else { cngcredit = txtCNGCredit.Text; }
            decimal dieselcrtk = decimal.Parse(dieselcredit.ToString());
            decimal cngcrtk = decimal.Parse(cngcredit.ToString());
            decimal ttk = dieselcrtk + cngcrtk;
            totalcredit = ttk.ToString();
            inttype = "0";

            try
            {
                if (txtFuelPurchaeDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return;
                }
                else { strFuelPurchaseDate = txtFuelPurchaeDate.Text; }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            try
            {
                strFuelPurchaseDate = txtFuelPurchaeDate.Text;
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            if (intPartyID != "" && fuelstation != "" && ttk != 0)
            {
                CreateVoucherXml(intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, inttype, strFuelPurchaseDate);
                txtDieselCredit.Text = "";
                txtCNGCredit.Text = "";
                ddlFuelStation.Text = "";
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Fuel Station.');", true); return; }

        }
        private void CreateVoucherXml(string intPartyID, string fuelstation, string dieselcredit, string cngcredit, string totalcredit, string inttype, string strFuelPurchaseDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("FDetails");
                XmlNode addItem = CreateItemNode(doc, intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, inttype, strFuelPurchaseDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FDetails");
                XmlNode addItem = CreateItemNode(doc, intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, inttype, strFuelPurchaseDate); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            //Clear();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("FDetails");
            xmlString = dSftTm.InnerXml;
            xmlString = "<FDetails>" + xmlString + "</FDetails>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvFuelCost.DataSource = ds; }
            else { dgvFuelCost.DataSource = ""; } dgvFuelCost.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intPartyID, string fuelstation, string dieselcredit, string cngcredit, string totalcredit, string inttype, string strFuelPurchaseDate)
        {
            XmlNode node = doc.CreateElement("FDetails");

            XmlAttribute IntPartyID = doc.CreateAttribute("intPartyID");
            IntPartyID.Value = intPartyID;
            XmlAttribute Fuelstation = doc.CreateAttribute("fuelstation");
            Fuelstation.Value = fuelstation;
            XmlAttribute Dieselcredit = doc.CreateAttribute("dieselcredit");
            Dieselcredit.Value = dieselcredit;
            XmlAttribute Cngcredit = doc.CreateAttribute("cngcredit");
            Cngcredit.Value = cngcredit;
            XmlAttribute Totalcredit = doc.CreateAttribute("totalcredit");
            Totalcredit.Value = totalcredit;
            XmlAttribute Inttype = doc.CreateAttribute("inttype");
            Inttype.Value = inttype;
            XmlAttribute StrFuelPurchaseDate = doc.CreateAttribute("strFuelPurchaseDate");
            StrFuelPurchaseDate.Value = strFuelPurchaseDate;

            node.Attributes.Append(IntPartyID);
            node.Attributes.Append(Fuelstation);
            node.Attributes.Append(Dieselcredit);
            node.Attributes.Append(Cngcredit);
            node.Attributes.Append(Totalcredit);
            node.Attributes.Append(Inttype);
            node.Attributes.Append(StrFuelPurchaseDate);
            return node;
        }
        protected void dgvFuelCost_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("FDetails");
                xmlString = dSftTm.InnerXml;
                xmlString = "<FDetails>" + xmlString + "</FDetails>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvFuelCost.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvFuelCost.DataSource;
                string chek = dsGrid.Tables[0].Rows[e.RowIndex][5].ToString();

                if (chek == "0")
                {
                    decimal fc;
                    hdndgvFTTotal.Value = grandtotal.ToString();
                    try { fc = decimal.Parse(txtFuelCash.Text); }
                    catch { fc = 0; }
                    decimal tfc = fc + grandtotal;
                    txtTFCost.Text = tfc.ToString();

                    decimal bridge; decimal freey; decimal lbexp; decimal pexp; decimal mtk; decimal othertk;
                    if (txtBridgeToll.Text == "") { bridge = 0; }
                    else { bridge = decimal.Parse(txtBridgeToll.Text); }

                    if (txtFerryToll.Text == "") { freey = 0; }
                    else { freey = decimal.Parse(txtFerryToll.Text); }

                    if (txtLabourExp.Text == "") { lbexp = 0; }
                    else { lbexp = decimal.Parse(txtLabourExp.Text); }

                    if (txtPolice.Text == "") { pexp = 0; }
                    else { pexp = decimal.Parse(txtPolice.Text); }

                    if (txtMaintananceTK.Text == "") { mtk = 0; }
                    else { mtk = decimal.Parse(txtMaintananceTK.Text); }

                    if (txtOthersTK.Text == "") { othertk = 0; }
                    else { othertk = decimal.Parse(txtOthersTK.Text); }

                    decimal ta = bridge + freey + lbexp + pexp + tfc + mtk + othertk;
                    txtTotalRouteExp.Text = ta.ToString();

                    dsGrid.Tables[0].Rows[dgvFuelCost.Rows[e.RowIndex].DataItemIndex].Delete();
                    dsGrid.WriteXml(filePathForXML);
                    DataSet dsGridAfterDelete = (DataSet)dgvFuelCost.DataSource;
                    if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                    { File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    }
                    else { LoadGridwithXml(); }
                }
            }
            catch { }

        }
        //** Gridview Add And Delete Row End 

        //** Gridview Down Trip Fare Cash Add Start ******************************************************
        protected void btnDTFareCashAdd_Click(object sender, EventArgs e)
        {
            agenttnam = txtAgentName.Text;
            dtfarecash = txtDTFCash.Text;

            if (agenttnam != "" && dtfarecash != "" && dtfarecash != "")
            {
                //if (dgvDTFare.Rows.Count > 0)
                //{
                //    for (int index = 0; index < dgvDTFare.Rows.Count; index++)
                //    {
                //        string strCheckItemid = ((Label)dgvDTFare.Rows[index].FindControl("lblshippointid")).Text.ToString();
                //        if (shippointid == strCheckItemid)
                //        {
                //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Ship Point is already Added.');", true); return;
                //        }
                //    }
                //}

                CreateVoucherXmlDTFareCash(agenttnam, dtfarecash);
                txtAgentName.Text = "";
                txtDTFCash.Text = "";
            }
            else
            { }

        }
        private void CreateVoucherXmlDTFareCash(string agenttnam, string dtfarecash)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDTFareCash))
            {
                doc.Load(filePathForXMLDTFareCash);
                XmlNode rootNode = doc.SelectSingleNode("DTFareCash");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, agenttnam, dtfarecash);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DTFareCash");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, agenttnam, dtfarecash);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDTFareCash);
            LoadGridwithXmlDTFareCash();
            //Clear();
        }
        private void LoadGridwithXmlDTFareCash()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDTFareCash);
            XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
            xmlStringDTFareCash = dSftTm.InnerXml;
            xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
            StringReader sr = new StringReader(xmlStringDTFareCash);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDTFareCash.DataSource = ds; }
            else { dgvDTFareCash.DataSource = ""; } dgvDTFareCash.DataBind();
            hdnDTFCountCash.Value = dgvDTFareCash.Rows.Count.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);

        }
        private XmlNode CreateItemNodeDTFareCash(XmlDocument doc, string agenttnam, string dtfarecash)
        {
            XmlNode node = doc.CreateElement("DTFareCash");

            XmlAttribute Agenttnam = doc.CreateAttribute("agenttnam");
            Agenttnam.Value = agenttnam;
            XmlAttribute Dtfarecash = doc.CreateAttribute("dtfarecash");
            Dtfarecash.Value = dtfarecash;

            node.Attributes.Append(Agenttnam);
            node.Attributes.Append(Dtfarecash);            
            return node;
        }
        protected void dgvDTFareCash_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDTFareCash);
                XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
                xmlStringDTFareCash = dSftTm.InnerXml;
                xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
                StringReader sr = new StringReader(xmlStringDTFareCash);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDTFareCash.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDTFareCash.DataSource;
                hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                dsGrid.Tables[0].Rows[dgvDTFareCash.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDTFareCash);
                DataSet dsGridAfterDelete = (DataSet)dgvDTFareCash.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDTFareCash); dgvDTFareCash.DataSource = ""; dgvDTFareCash.DataBind();
                    hdnDTFCountCash.Value = dgvDTFareCash.Rows.Count.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXmlDTFareCash(); }
            }
            catch { }

        }
        //** Gridview Down Trip Fare Cash Add End 
                
        //** Gridview DT Fare Add Start ******************************************************
        protected void btnDTFareAdd_Click1(object sender, EventArgs e)
        {
            //intDownTripCount = 0;

            unitid = ddlUnitNameDTF.SelectedValue.ToString();
            shippointid = ddlShipPointDTF.SelectedValue.ToString();
            unitname = ddlUnitNameDTF.SelectedItem.ToString();
            shippointname = ddlShipPointDTF.SelectedItem.ToString();
            dtfarecredit = txtDTFareCredit.Text;

            if (unitid != "" && shippointid != "" && unitname != "" && shippointname != "" && dtfarecredit != "")
            {
                if (dgvDTFare.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvDTFare.Rows.Count; index++)
                    {
                        string strCheckItemid = ((Label)dgvDTFare.Rows[index].FindControl("lblshippointid")).Text.ToString();
                        if (shippointid == strCheckItemid)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Ship Point is already Added.');", true); return;
                        }
                    }
                }

                CreateVoucherXmlDTFare(unitid, shippointid, unitname, shippointname, dtfarecredit);
                txtDTFareCredit.Text = "";
                
            }
            else
            { }
            
        } 
        private void CreateVoucherXmlDTFare(string unitid, string shippointid, string unitname, string shippointname, string dtfarecredit)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDTFare))
            {
                doc.Load(filePathForXMLDTFare);
                XmlNode rootNode = doc.SelectSingleNode("DTFare");
                XmlNode addItem = CreateItemNodeDTFare(doc, unitid, shippointid, unitname, shippointname, dtfarecredit);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DTFare");
                XmlNode addItem = CreateItemNodeDTFare(doc, unitid, shippointid, unitname, shippointname, dtfarecredit); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDTFare);
            LoadGridwithXmlDTFare();
            //Clear();
        }
        private void LoadGridwithXmlDTFare() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDTFare);
            XmlNode dSftTm = doc.SelectSingleNode("DTFare");
            xmlStringDTFare = dSftTm.InnerXml;
            xmlStringDTFare = "<DTFare>" + xmlStringDTFare + "</DTFare>";
            StringReader sr = new StringReader(xmlStringDTFare);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDTFare.DataSource = ds; }
            else { dgvDTFare.DataSource = ""; } dgvDTFare.DataBind();
            hdnDTFCount.Value = dgvDTFare.Rows.Count.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }
        private XmlNode CreateItemNodeDTFare(XmlDocument doc, string unitid, string shippointid, string unitname, string shippointname, string dtfarecredit)
        {
            XmlNode node = doc.CreateElement("DTFare");

            XmlAttribute Unitid = doc.CreateAttribute("unitid");
            Unitid.Value = unitid;
            XmlAttribute Shippointid = doc.CreateAttribute("shippointid");
            Shippointid.Value = shippointid;
            XmlAttribute Unitname = doc.CreateAttribute("unitname");
            Unitname.Value = unitname;
            XmlAttribute Shippointname = doc.CreateAttribute("shippointname");
            Shippointname.Value = shippointname;
            XmlAttribute Dtfarecredit = doc.CreateAttribute("dtfarecredit");
            Dtfarecredit.Value = dtfarecredit;

            node.Attributes.Append(Unitid);
            node.Attributes.Append(Shippointid);
            node.Attributes.Append(Unitname);
            node.Attributes.Append(Shippointname);
            node.Attributes.Append(Dtfarecredit);
            return node;
        }
        protected void dgvDTFare_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDTFare);
                XmlNode dSftTm = doc.SelectSingleNode("DTFare");
                xmlStringDTFare = dSftTm.InnerXml;
                xmlStringDTFare = "<DTFare>" + xmlStringDTFare + "</DTFare>";
                StringReader sr = new StringReader(xmlStringDTFare);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDTFare.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDTFare.DataSource;
                dsGrid.Tables[0].Rows[dgvDTFare.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDTFare);
                DataSet dsGridAfterDelete = (DataSet)dgvDTFare.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLDTFare); dgvDTFare.DataSource = ""; dgvDTFare.DataBind();
                hdnDTFCount.Value = dgvDTFare.Rows.Count.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXmlDTFare(); }
            }
            catch { }

        }
        //** Gridview Add And Delete Row End 

        protected decimal grandtotal = 0;
        protected decimal grandtotaldtfare = 0;
        
        protected decimal totaldieselcredit = 0;
        protected decimal totalcngcredit = 0;
        protected decimal grandtotaldtfarecash = 0;  
        protected void dgvFuelCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //grandtotal = 0;
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {                    
                    grandtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblGrandTotal")).Text);
                    totaldieselcredit += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lbldieselcredit")).Text);
                    totalcngcredit += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblcngcredit")).Text);
                    
                    decimal fc;
                    hdndgvFTTotal.Value = grandtotal.ToString();
                    try { fc = decimal.Parse(txtFuelCash.Text); }
                    catch { fc = 0; }
                    decimal tfc = fc + grandtotal;
                    txtTFCost.Text = tfc.ToString();

                    decimal bridge; decimal freey; decimal lbexp; decimal pexp; decimal mtk; decimal othertk;
                    if (txtBridgeToll.Text == "") { bridge = 0; }
                    else { bridge = decimal.Parse(txtBridgeToll.Text); }

                    if (txtFerryToll.Text == "") { freey = 0; }
                    else { freey = decimal.Parse(txtFerryToll.Text); }

                    if (txtLabourExp.Text == "") { lbexp = 0; }
                    else { lbexp = decimal.Parse(txtLabourExp.Text); }

                    if (txtPolice.Text == "") { pexp = 0; }
                    else { pexp = decimal.Parse(txtPolice.Text); }

                    if (txtMaintananceTK.Text == "") { mtk = 0; }
                    else { mtk = decimal.Parse(txtMaintananceTK.Text); }

                    if (txtOthersTK.Text == "") { othertk = 0; }
                    else { othertk = decimal.Parse(txtOthersTK.Text); }

                    decimal ta = bridge + freey + lbexp + pexp + tfc + mtk + othertk;
                    txtTotalRouteExp.Text = ta.ToString();
                }
            }
            catch { }
        }
        protected void dgvDTFare_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grandtotaldtfare += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblGrandTotaldtfare")).Text);

                    //DownTripCount = DownTripCount + 1;
                    //int monDTFar = int.Parse(hdnDTFare.Value);
                    //txtDtripAllowance.Text = (int.Parse(DownTripCount.ToString()) * monDTFar).ToString();
                }
            } 
            catch { }
        }
        protected void dgvDTFareCash_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grandtotaldtfarecash += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblGrandTotaldtfareCash")).Text);
                    hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                }
            }
            catch { }
        }
        protected void ddlUnitNameDTF_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            intUnitID = int.Parse(ddlUnitNameDTF.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPointDTF.DataTextField = "strName";
            ddlShipPointDTF.DataValueField = "intId";
            ddlShipPointDTF.DataSource = dt;
            ddlShipPointDTF.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }
        protected void txtNoOfDA_TextChanged(object sender, EventArgs e)
        {
            decimal noda = decimal.Parse(txtNoOfDA.Text);
            decimal da = decimal.Parse(HttpContext.Current.Session["DAllow"].ToString());
            decimal tda = noda * da;
            txtDailyAlllownacetk.Text = tda.ToString();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {                    
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    try { dteInDate = DateTime.Parse(txtInDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please In Date Properly Input.');", true); return; }

                    try { intAdditionalMillage = int.Parse(txtAdditionalMillage.Text); }
                    catch { intAdditionalMillage = 0; }
                    if (intAdditionalMillage != 0 && txtCauseOfAdditionalM.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Additional Millage Input.');", true); return; }
                    strCauseOfAdditionalMillage = txtCauseOfAdditionalM.Text;

                    try { monAdditionalFare = decimal.Parse(txtAdditionalFare.Text); }
                    catch { monAdditionalFare = 0; }
                    if (monAdditionalFare != 0 && txtCauseOfAdditionalF.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Additional Fare Input.');", true); return; }
                    strCauseOfAdditionalFare = txtCauseOfAdditionalF.Text;
                    
                    try { monLabourEXP = decimal.Parse(txtLabourExp.Text); }
                    catch { monLabourEXP = 0; }
                    try { monPoliceEXP = decimal.Parse(txtPolice.Text); }
                    catch { monPoliceEXP = 0; }
                    
                    try { monMaintenanceTK = decimal.Parse(txtMaintananceTK.Text); }
                    catch { monMaintenanceTK = 0; }
                    if (monMaintenanceTK != 0 && txtCauseOfMaintenance.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Maintenance Input.');", true); return; }
                    strMaintenanceDesc = txtCauseOfMaintenance.Text;
                                        
                    try { monOthersTK = decimal.Parse(txtOthersTK.Text); }
                    catch { monOthersTK = 0; }
                    if (monOthersTK != 0 && txtCauseOfOthers.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Others Input.');", true); return; }
                    strOhtersDetail = txtCauseOfOthers.Text;
                                        
                    try { intNoOfDA = decimal.Parse(txtNoOfDA.Text); }
                    catch { intNoOfDA = 0; }
                    try { monTripBonus = decimal.Parse(txtTripBonus.Text); }
                    catch { monTripBonus = 0; }
                    try { monTimeAllow = decimal.Parse(txtTimeAllowance.Text); }
                    catch { monTimeAllow = 0; }
                    try { monTotalDTripFareCash = decimal.Parse(hdndgvDTFCash.Value); }
                    catch { monTotalDTripFareCash = 0; }                    
                    
                    intInInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    strAgentName = txtAgentName.Text;
                    try { monBridgeToll = decimal.Parse(txtBridgeToll.Text); }
                    catch { monBridgeToll = 0; }
                    try { monFerryEXP = decimal.Parse(txtFerryToll.Text); }
                    catch { monFerryEXP = 0; }
                    try { monFuelCash = decimal.Parse(txtFuelCash.Text); }
                    catch { monFuelCash = 0; }
                    
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("FDetails");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<FDetails>" + xmlString + "</FDetails>";
                        xml = xmlString;

                    }
                    catch { }
                       
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDTFare);
                        XmlNode dSftTm = doc.SelectSingleNode("DTFare");
                        xmlStringDTFare = dSftTm.InnerXml;
                        xmlStringDTFare = "<DTFare>" + xmlStringDTFare + "</DTFare>";
                        xmlDtFare = xmlStringDTFare;
                    }
                    catch { }
                          
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDTFareCash);
                        XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
                        xmlStringDTFareCash = dSftTm.InnerXml;
                        xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
                        xmlDtFareCash = xmlStringDTFareCash;
                    }
                    catch { }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDocUpload);
                        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                        xmlStringDocUpload = dSftTm.InnerXml;
                        xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                        xmlDocUpload = xmlStringDocUpload;
                    }
                    catch { }
                                        
                    //Final In Insert
                    //string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow);
                    string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare, xmlDocUpload);
                    //string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare);

                    //****Document Upload Start

                    //if (hdnconfirm.Value == "3")
                    //{
                        if (dgvDocUp.Rows.Count > 0)
                        {
                            for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                            {
                                fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                                FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");

                                //CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

                            }
                        }

                        dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    //}

                    hdnconfirm.Value = "0";

                    //****Document Upload End

                    txtFuelCash.Text = "";
                    txtCauseOfAdditionalM.Text = "";
                    txtCauseOfAdditionalF.Text = "";
                    if (filePathForXML != null)
                    { File.Delete(filePathForXML); } dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    if (filePathForXMLDTFare != null)
                    { File.Delete(filePathForXMLDTFare); } dgvDTFare.DataSource = ""; dgvDTFare.DataBind();
                    if (filePathForXMLDTFareCash != null)
                    { File.Delete(filePathForXMLDTFareCash); } dgvDTFareCash.DataSource = ""; dgvDTFareCash.DataBind();                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);                   
                }
                catch { }
            }

        }
        
        //** Gridview Document Upload Start ******************************************************
        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = int.Parse(ddlDocType.SelectedValue.ToString());
                    strDocName = ddlDocType.SelectedItem.ToString();
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    /////strDocUploadPath = txtDocUpload.FileName.ToString();

                    //string files1 = System.IO.Path.GetFullPath(txtDocUpload.PostedFile.FileName);
                    //string files2 = Path.GetFileName(txtDocUpload.PostedFile.FileName);
                    //string files3 = System.IO.Path.GetDirectoryName(txtDocUpload.PostedFile.FileName).ToString();
                    //string files4 = Convert.ToString(System.IO.Directory.GetParent(txtDocUpload.PostedFile.FileName));
                    //string files5 = Server.MapPath(txtDocUpload.FileName); 
                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            ////strDocUploadPath = Path.GetFileName(txtDocUpload.PostedFile.FileName);
                            strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strDocUploadPath;
                            doctypeid = ddlDocType.SelectedValue.ToString();
                                      
                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            //string fileName = hdnID.Value + "_" + Path.GetFileName(txtDocUpload.PostedFile.FileName);
                            fileName = strDocUploadPath.Replace(" ", "");

                            //fileName = "* A Short String. *";
                            //Console.WriteLine(fileName);
                            //Console.WriteLine(fileName.Trim(new Char[] { ' ', '_', '*', '.' }));

                            //string txt = "                   i am a string                                    ";
                            //char[] charsToTrim = { ' ' };
                            //txt = txt.Trim(charsToTrim); // txt = "i am a string"

                            //var myString = "    this    is my String ";
                            //var newstring = myString.Trim(); // results in "this is my String"
                            //var noSpaceString = myString.Replace(" ", ""); // results in "thisismyString";
                    
                            //////////////////////////txtDocUpload.PostedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                            //////FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
                            ////File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
                            //lblMessage.Text += fileName + " Uploaded.<br />";
                            strFileName = fileName.Trim();
                            //////strFilePath = fileName;\
                                                       
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                    
                            //string fileName = FileUpload1.FileName;
                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            {
                                //FileUpload1.SaveAs(Server.MapPath(fileName));
                                ///txtDocUpload.PostedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                                uploadedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                                /////uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"),uploadedFile.FileName));
                            }
                            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(strFileName, doctypeid);
                            ////obj.InsertDocPath(intEnroll, strFilePath, intSeparationID);
                            //txtAgentName.Text = "";
                            //txtDTFCash.Text = "";
                        }
                       
                            ////uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Transport/Uploads/"), uploadedFile.FileName.ToString()));
                            //listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                            //strDocUploadPath = txtDocUpload.FileName.ToString();
                            //string checkf = String.Format("{0}", uploadedFile.FileName.ToString());
                            //string checkf1 = uploadedFile.FileName.ToString();
                            //listofuploadedfiles.Text += String.Format("{0}", uploadedFile.FileName.ToString());
                            //string check2 = listofuploadedfiles.Text.ToString();
                            
                            
                        }
                    }
                                    
                hdnconfirm.Value = "0";

                ///obj.InsertDocPath(intEnroll, strFilePath, intSeparationID);
                ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Document Upload Successfully.');", true);

                ///Response.Redirect(Request.Url.AbsoluteUri);
                #endregion                
            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName, string doctypeid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);
            LoadGridwithXmlDocUpload();
            //Clear(); 
        }
        private void LoadGridwithXmlDocUpload()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDocUpload);
            XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
            xmlStringDocUpload = dSftTm.InnerXml;
            xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
            StringReader sr = new StringReader(xmlStringDocUpload);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDocUp.DataSource = ds; }
            else { dgvDocUp.DataSource = ""; } dgvDocUp.DataBind();
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName, string doctypeid)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Doctypeid);     
            return node;
        }
        protected void dgvDocUp_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            { 
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                StringReader sr = new StringReader(xmlStringDocUpload);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDocUp.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDocUp.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();
                File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
                
                //hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                dsGrid.Tables[0].Rows[dgvDocUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    //hdnDTFCountCash.Value = dgvDTFareCash.Rows.Count.ToString();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch { }

        }
        //** Gridview Document Upload End   
      
        protected void DynamicUpload()
        {
            FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            //******************************************************************
            try
            {
                FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
                requestFTPUploader.Credentials = new NetworkCredential(user, pass);
                requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(localPath + fileName);
                FileStream fileStream = fileInfo.OpenRead();

                int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];

                Stream uploadStream = requestFTPUploader.GetRequestStream();
                int contentLength = fileStream.Read(buffer, 0, bufferLength);

                while (contentLength != 0)
                {
                    uploadStream.Write(buffer, 0, contentLength);
                    contentLength = fileStream.Read(buffer, 0, bufferLength);
                }

                uploadStream.Close();
                fileStream.Close();

                requestFTPUploader = null;
                File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }

        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    try { dteInDate = DateTime.Parse(txtInDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please In Date Properly Input.');", true); return; }

                    try { intAdditionalMillage = int.Parse(txtAdditionalMillage.Text); }
                    catch { intAdditionalMillage = 0; }
                    if (intAdditionalMillage != 0 && txtCauseOfAdditionalM.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Additional Millage Input.');", true); return; }
                    strCauseOfAdditionalMillage = txtCauseOfAdditionalM.Text;

                    try { monAdditionalFare = decimal.Parse(txtAdditionalFare.Text); }
                    catch { monAdditionalFare = 0; }
                    if (monAdditionalFare != 0 && txtCauseOfAdditionalF.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Additional Fare Input.');", true); return; }
                    strCauseOfAdditionalFare = txtCauseOfAdditionalF.Text;

                    try { monLabourEXP = decimal.Parse(txtLabourExp.Text); }
                    catch { monLabourEXP = 0; }
                    try { monPoliceEXP = decimal.Parse(txtPolice.Text); }
                    catch { monPoliceEXP = 0; }

                    try { monMaintenanceTK = decimal.Parse(txtMaintananceTK.Text); }
                    catch { monMaintenanceTK = 0; }
                    if (monMaintenanceTK != 0 && txtCauseOfMaintenance.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Maintenance Input.');", true); return; }
                    strMaintenanceDesc = txtCauseOfMaintenance.Text;

                    try { monOthersTK = decimal.Parse(txtOthersTK.Text); }
                    catch { monOthersTK = 0; }
                    if (monOthersTK != 0 && txtCauseOfOthers.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Cause Of Others Input.');", true); return; }
                    strOhtersDetail = txtCauseOfOthers.Text;

                    try { intNoOfDA = decimal.Parse(txtNoOfDA.Text); }
                    catch { intNoOfDA = 0; }
                    try { monTripBonus = decimal.Parse(txtTripBonus.Text); }
                    catch { monTripBonus = 0; }
                    try { monTimeAllow = decimal.Parse(txtTimeAllowance.Text); }
                    catch { monTimeAllow = 0; }
                    try { monTotalDTripFareCash = decimal.Parse(hdndgvDTFCash.Value); }
                    catch { monTotalDTripFareCash = 0; }

                    intInInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    strAgentName = txtAgentName.Text;
                    try { monBridgeToll = decimal.Parse(txtBridgeToll.Text); }
                    catch { monBridgeToll = 0; }
                    try { monFerryEXP = decimal.Parse(txtFerryToll.Text); }
                    catch { monFerryEXP = 0; }
                    try { monFuelCash = decimal.Parse(txtFuelCash.Text); }
                    catch { monFuelCash = 0; }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("FDetails");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<FDetails>" + xmlString + "</FDetails>";
                        xml = xmlString;

                    }
                    catch { }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDTFare);
                        XmlNode dSftTm = doc.SelectSingleNode("DTFare");
                        xmlStringDTFare = dSftTm.InnerXml;
                        xmlStringDTFare = "<DTFare>" + xmlStringDTFare + "</DTFare>";
                        xmlDtFare = xmlStringDTFare;
                    }
                    catch { }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDTFareCash);
                        XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
                        xmlStringDTFareCash = dSftTm.InnerXml;
                        xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
                        xmlDtFareCash = xmlStringDTFareCash;
                    }
                    catch { }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDocUpload);
                        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                        xmlStringDocUpload = dSftTm.InnerXml;
                        xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                        xmlDocUpload = xmlStringDocUpload;
                    }
                    catch { }
                    
                    //****Document Upload Start

                    //if (hdnconfirm.Value == "3")
                    //{
                    if (dgvDocUp.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                        {
                            fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                            FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
                            //CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);
                       }
                    }

                    //Final In Insert
                    //string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow);
                    string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare, xmlDocUpload);
                    //string message = obj.InsertInEntry(intID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare);

                    //}

                    hdnconfirm.Value = "0";

                    //****Document Upload End

                    txtFuelCash.Text = "";
                    txtCauseOfAdditionalM.Text = "";
                    txtCauseOfAdditionalF.Text = "";
                    if (filePathForXML != null)
                    { File.Delete(filePathForXML); } dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    if (filePathForXMLDTFare != null)
                    { File.Delete(filePathForXMLDTFare); } dgvDTFare.DataSource = ""; dgvDTFare.DataBind();
                    if (filePathForXMLDTFareCash != null)
                    { File.Delete(filePathForXMLDTFareCash); } dgvDTFareCash.DataSource = ""; dgvDTFareCash.DataBind();
                    if (filePathForXMLDocUpload != null)
                    { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

                }
                catch (Exception ex) { throw ex; }
            }
        }

     

     
        //protected void FinalUpload()
        //{
        //    if (hdnconfirm.Value == "3")
        //    {
        //        if (dgvDocUp.Rows.Count > 0)
        //        {
        //            for (int index = 0; index < dgvDocUp.Rows.Count; index++)
        //            {
        //                fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
        //                FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");

        //                //CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

        //            }
        //        }

        //        dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
        //    }

        //    hdnconfirm.Value = "0";
        //}

        
        
       



    }
}
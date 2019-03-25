using SAD_BLL.Transport;
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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Transport
{
    public partial class InternalTransportExtimatedExp : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Transport";
        string start = "starting Transport/InternalTransportExtimatedExp.aspx";
        string stop = "stopping Transport/InternalTransportExtimatedExp.aspx";

        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt; DataTable dtn; 

        int intID; int intWork;
        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLCustWiseCost; string xmlStringCustWiseCost = ""; string xmlCustWiseCost; 
        string intPartyID; string fuelstation; string dieselcredit; string cngcredit; string totalcredit;
        string unitid; string shippointid; string unitname; string shippointname; string dtfarecredit;
        string strEnroll; int intUnitID;

        string reffid; string custid; string custname; string millage; string tripfare; string tfopentruck; 
        string tfcoveredvan; string tfpickup; string tf7ton; string tf5ton; string tf3ton; string tf1andhalfton; 
        string bridgetoll; string bnrtoll20ton; string bnrtoll10ton; string bnrtoll7ton; string bnrtoll5ton; 
        string bnrtoll3ton; string bnrtoll2ton; string bnrtoll1andhalfton; string ferrytoll; string ft20ton;
        string ft7ton; string ft5ton; string ft3ton; string ft1andhalfton; string tf10ton;

        int intReffID; decimal monBridgeToll; decimal monFerryEXP; decimal monLabourEXP; 
        decimal monPoliceEXP; int intDriverEnroll; decimal monFuelCash; decimal monAdvance;
        int intInsertBy; int intTripCount; decimal TotalRouteExp; string strFuelPurchaseDate;
           
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            //hdnUnit.Value = "4";

            filePathForXML = Server.MapPath("~/Transport/Data/ExpFuelStation_" + hdnEnroll.Value + ".xml");
            filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");
            
            if (!IsPostBack)
            {
                //=== As per Transport Department =============================================
                btnUpdate.Visible = false;
                               
                try
                {
                    File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    File.Delete(filePathForXMLCustWiseCost); dgvTripWiseCustomer.DataSource = ""; dgvTripWiseCustomer.DataBind();
                    
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    dtn = new DataTable();
                    dtn = obj.GetDriverEnrollAndUnitidByTrip(intID);

                    intUnitID = int.Parse(dtn.Rows[0]["intUnitID"].ToString());
                    HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
                    dt = new DataTable();
                    dt = obj.GetFuelStationList();
                    ddlFuelStation.DataTextField = "strPartyName";
                    ddlFuelStation.DataValueField = "intPartyID";
                    ddlFuelStation.DataSource = dt;
                    ddlFuelStation.DataBind();

                    dt = new DataTable();
                    dt = obj.GetDriverList(intUnitID);
                    ddlDriverName.DataTextField = "strEmployeeName";
                    ddlDriverName.DataValueField = "intEmployeeID";
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataBind();

                    ddlDriverName.SelectedValue = dtn.Rows[0]["intEmployeeID"].ToString();

                    lblQty.Visible = false;
                    txtQty.Visible = false;

                    if (hdnUnit.Value == "4")
                    {
                        lblQty.Visible = true;
                        txtQty.Visible = true;
                    }

                    GetTripFareAndToll();
                    CustomerWiseRouteCost();
                    LadgerBalance();
                    FuelCostLoadByTrip();

                    //intPiID = int.Parse(strPI.ToString());
                    //HttpContext.Current.Session["intPiID"] = intPiID.ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void FuelCostLoadByTrip()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            intWork = 4;
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            if (dt.Rows.Count > 0)
            {
                hdnDieselTotalTk.Value = dt.Rows[0]["DieselPerKM"].ToString();
                hdnCNGTotalTk.Value = dt.Rows[0]["CNGPerKM"].ToString();

                hdnDieselPerKMOutStation.Value = dt.Rows[0]["DieselPerKMOutStation"].ToString();
                hdnCNGPerKMOutStation.Value = dt.Rows[0]["CNGPerKMOutStation"].ToString();                                
            }
        }

        //** Gridview Fuel Station Add Start ******************************************************        
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
            try
            {
                if (txtFuelPurchaeDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return;
                }
                else { strFuelPurchaseDate = txtFuelPurchaeDate.Text;}
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            //&& dieselcredit != "" && cngcredit != "" 
            if (intPartyID != "" && fuelstation != "" && ttk != 0)
            {
            //    if (dgvFuelCost.Rows.Count > 0)
            //    {
            //        for (int index = 0; index < dgvFuelCost.Rows.Count; index++)
            //        {
            //            string strCheckItemid = ((Label)dgvFuelCost.Rows[index].FindControl("lblPartyID")).Text.ToString();
            //            if (intPartyID == strCheckItemid)
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Fuel Station is already Added.');", true); return;
            //            }
            //        }
            //    }

                CreateVoucherXml(intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, strFuelPurchaseDate);
                txtDieselCredit.Text = "";
                txtCNGCredit.Text = "";
            }
            else
            { }

        }
        private void CreateVoucherXml(string intPartyID, string fuelstation, string dieselcredit, string cngcredit, string totalcredit, string strFuelPurchaseDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("FDetails");
                XmlNode addItem = CreateItemNode(doc, intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, strFuelPurchaseDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FDetails");
                XmlNode addItem = CreateItemNode(doc, intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, strFuelPurchaseDate); ;
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
        private XmlNode CreateItemNode(XmlDocument doc, string intPartyID, string fuelstation, string dieselcredit, string cngcredit, string totalcredit, string strFuelPurchaseDate)
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
            XmlAttribute StrFuelPurchaseDate = doc.CreateAttribute("strFuelPurchaseDate");
            StrFuelPurchaseDate.Value = strFuelPurchaseDate;
            
            node.Attributes.Append(IntPartyID);
            node.Attributes.Append(Fuelstation);
            node.Attributes.Append(Dieselcredit);
            node.Attributes.Append(Cngcredit);
            node.Attributes.Append(Totalcredit);
            node.Attributes.Append(StrFuelPurchaseDate);
            return node;
        }
        protected void dgvFuelCost_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                decimal fc;
                txtdgvFTTotal.Text = "0";
                try { fc = 0; /*decimal.Parse(txtFuelCash.Text);*/ }
                catch { fc = 0; }                
                //txtTFCost.Text = fc.ToString();

                txtTotalRouteExp.Text = "0";

                decimal bridge; decimal freey; decimal lbexp; decimal pexp;
                if (txtBridgeToll.Text == "") { bridge = 0; }
                else { bridge = decimal.Parse(txtBridgeToll.Text); }

                if (txtFerryToll.Text == "") { freey = 0; }
                else { freey = decimal.Parse(txtFerryToll.Text); }

                if (txtLabourExp.Text == "") { lbexp = 0; }
                else { lbexp = decimal.Parse(txtLabourExp.Text); }

                if (txtPolice.Text == "") { pexp = 0; }
                else { pexp = decimal.Parse(txtPolice.Text); }

                decimal ta = bridge + freey + lbexp + pexp + fc;
                txtTotalRouteExp.Text = ta.ToString();
                
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
                dsGrid.Tables[0].Rows[dgvFuelCost.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvFuelCost.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);}                
                else { LoadGridwithXml(); }
            }
            catch { }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }
        //** Gridview Add And Delete Row End 
        private void GetTripFareAndToll()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
            
            dt = new DataTable();
            dt = obj.GetTripFareAndToll(intID);
            if (dt.Rows.Count > 0)
            {
                txtBridgeToll.Text = dt.Rows[0]["BnRToll"].ToString();
                txtFerryToll.Text = dt.Rows[0]["Ferrytoll"].ToString();
                txtTotalRouteExp.Text = dt.Rows[0]["Total"].ToString();                
                txtMillage.Text = dt.Rows[0]["Millage"].ToString();
                lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();
                lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();               
                txtQty.Text = dt.Rows[0]["Quantity"].ToString();
            }

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }

        //** Gridview Customer Wise Route Cost Add Start ******************************************************
        private void CustomerWiseRouteCost()
        {
            intWork = 1;
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            dgvTripWiseCustomer.DataSource = dt;
            dgvTripWiseCustomer.DataBind();
            if (dt.Rows.Count > 0)
            {
                intUnitID = int.Parse(dt.Rows[0]["unitid"].ToString());
            }

            dgvTripWiseCustomer.Columns[5].Visible = false;
            dgvTripWiseCustomer.Columns[6].Visible = false;
            dgvTripWiseCustomer.Columns[7].Visible = false;
            dgvTripWiseCustomer.Columns[8].Visible = false;
            dgvTripWiseCustomer.Columns[9].Visible = false;
            dgvTripWiseCustomer.Columns[10].Visible = false;
            dgvTripWiseCustomer.Columns[11].Visible = false;
            dgvTripWiseCustomer.Columns[12].Visible = false;
            dgvTripWiseCustomer.Columns[13].Visible = false;
            dgvTripWiseCustomer.Columns[14].Visible = false;
            dgvTripWiseCustomer.Columns[15].Visible = false;
            dgvTripWiseCustomer.Columns[16].Visible = false;
            dgvTripWiseCustomer.Columns[17].Visible = false;
            dgvTripWiseCustomer.Columns[18].Visible = false;
            dgvTripWiseCustomer.Columns[19].Visible = false;
            dgvTripWiseCustomer.Columns[20].Visible = false;
            dgvTripWiseCustomer.Columns[21].Visible = false;
            dgvTripWiseCustomer.Columns[22].Visible = false;
            dgvTripWiseCustomer.Columns[23].Visible = false;
            dgvTripWiseCustomer.Columns[24].Visible = false;
            dgvTripWiseCustomer.Columns[25].Visible = false;
            dgvTripWiseCustomer.Columns[26].Visible = false;
            dgvTripWiseCustomer.Columns[27].Visible = false;

            //intUnitID = 16;

            if (intUnitID == 1)
            {
                dgvTripWiseCustomer.Columns[6].Visible = true;
                dgvTripWiseCustomer.Columns[7].Visible = true;
                dgvTripWiseCustomer.Columns[8].Visible = true;
                dgvTripWiseCustomer.Columns[14].Visible = true;
                dgvTripWiseCustomer.Columns[22].Visible = true;
            }
            else if (intUnitID == 2)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
                dgvTripWiseCustomer.Columns[26].Visible = true;
                dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 4 || intUnitID == 8)
            {
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[15].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[23].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;

            }
            else if (intUnitID == 16 || intUnitID == 105)
            {
                //dgvTripWiseCustomer.Columns[5].Visible = true;

                dgvTripWiseCustomer.Columns[9].Visible = true;
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;                
                dgvTripWiseCustomer.Columns[13].Visible = true;

                dgvTripWiseCustomer.Columns[16].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[20].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
                dgvTripWiseCustomer.Columns[26].Visible = true;
                dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 10)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
            }
            else if (intUnitID == 90)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;

                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
            }
            else
            {
                dgvTripWiseCustomer.Columns[5].Visible = true;
                dgvTripWiseCustomer.Columns[14].Visible = true;
                dgvTripWiseCustomer.Columns[22].Visible = true;
            }
                        
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {

                if (dgvTripWiseCustomer.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvTripWiseCustomer.Rows.Count; index++)
                    {
                        reffid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblReffIDG")).Text.ToString();
                        custid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustIDG")).Text.ToString();
                        custname = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustNameG")).Text.ToString();
                        millage = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageG")).Text.ToString();
                        tripfare = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTripFareG")).Text.ToString();
                        tfopentruck = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFOpentruckG")).Text.ToString();
                        tfcoveredvan = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFCoveredVanG")).Text.ToString();
                        tfpickup = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFPickupG")).Text.ToString();
                        tf10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF10TonG")).Text.ToString();
                        tf7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF7TonG")).Text.ToString();
                        tf5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF5TonG")).Text.ToString();
                        tf3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF3TonG")).Text.ToString();
                        tf1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF1AndHalfTonG")).Text.ToString();
                        bridgetoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBridgeTollG")).Text.ToString();
                        bnrtoll20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll20TonG")).Text.ToString();
                        bnrtoll10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll10TonG")).Text.ToString();
                        bnrtoll7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll7TonG")).Text.ToString();
                        bnrtoll5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll5TonG")).Text.ToString();
                        bnrtoll3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll3TonG")).Text.ToString();
                        bnrtoll2ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll2TonG")).Text.ToString();
                        bnrtoll1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll1AndHalfTonG")).Text.ToString();
                        ferrytoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFerryTollG")).Text.ToString();
                        ft20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT20TonG")).Text.ToString();
                        ft7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT7TonG")).Text.ToString();
                        ft5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT5TonG")).Text.ToString();
                        ft3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT3TonG")).Text.ToString();
                        ft1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT1AndHalfTonG")).Text.ToString();

                        CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

                    }

                    if (dgvTripWiseCustomer.Rows.Count > 0)
                    {
                        try
                        {
                            //filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLCustWiseCost);
                            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
                            string xmlStringCustWiseCost = dSftTm.InnerXml;
                            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
                            xml = xmlStringCustWiseCost;
                        }
                        catch { }
                        if (xml == "") { return; }
                    }

                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //Final Update
                    string message = obj.UpdateRouteCostByCustomer(intReffID, intInsertBy, xml);
                     
                    if (filePathForXMLCustWiseCost != null)
                    { File.Delete(filePathForXMLCustWiseCost); } dgvTripWiseCustomer.DataSource = ""; dgvTripWiseCustomer.DataBind();
                    
                    //Show Report By Trip Sl Start
                    GetTripFareAndToll();
                    CustomerWiseRouteCost();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //Show Report By Trip Sl End

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXmlCustWiseCost(string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLCustWiseCost))
            {
                doc.Load(filePathForXMLCustWiseCost);
                XmlNode rootNode = doc.SelectSingleNode("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLCustWiseCost);
            LoadGridwithXmlCustWiseCost();
            //Clear();
        }
        private void LoadGridwithXmlCustWiseCost() 
        { 
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLCustWiseCost);
            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
            xmlStringCustWiseCost = dSftTm.InnerXml;
            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
            StringReader sr = new StringReader(xmlStringCustWiseCost);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);            
            if (ds.Tables[0].Rows.Count > 0) { dgvTripWiseCustomer.DataSource = ds; }
            else { dgvTripWiseCustomer.DataSource = ""; } //dgvTripWiseCustomer.DataBind();
        }
        private XmlNode CreateItemNodeCustWiseCost(XmlDocument doc, string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {            
            XmlNode node = doc.CreateElement("CustWiseCost");

            XmlAttribute Reffid = doc.CreateAttribute("reffid"); Reffid.Value = reffid;
            XmlAttribute Custid = doc.CreateAttribute("custid"); Custid.Value = custid;
            XmlAttribute Custname = doc.CreateAttribute("custname"); Custname.Value = custname;
            XmlAttribute Millage = doc.CreateAttribute("millage"); Millage.Value = millage;
            XmlAttribute Tripfare = doc.CreateAttribute("tripfare"); Tripfare.Value = tripfare;
            XmlAttribute Tfopentruck = doc.CreateAttribute("tfopentruck"); Tfopentruck.Value = tfopentruck;
            XmlAttribute Tfcoveredvan = doc.CreateAttribute("tfcoveredvan"); Tfcoveredvan.Value = tfcoveredvan; 
            XmlAttribute Tfpickup = doc.CreateAttribute("tfpickup"); Tfpickup.Value = tfpickup;
            XmlAttribute Tf10ton = doc.CreateAttribute("tf10ton"); Tf10ton.Value = tf10ton;            
            XmlAttribute Tf7ton = doc.CreateAttribute("tf7ton"); Tf7ton.Value = tf7ton;
            XmlAttribute Tf5ton = doc.CreateAttribute("tf5ton"); Tf5ton.Value = tf5ton;
            XmlAttribute Tf3ton = doc.CreateAttribute("tf3ton"); Tf3ton.Value = tf3ton;
            XmlAttribute Tf1andhalfton = doc.CreateAttribute("tf1andhalfton"); Tf1andhalfton.Value = tf1andhalfton;
            XmlAttribute Bridgetoll = doc.CreateAttribute("bridgetoll"); Bridgetoll.Value = bridgetoll;
            XmlAttribute Bnrtoll20ton = doc.CreateAttribute("bnrtoll20ton"); Bnrtoll20ton.Value = bnrtoll20ton;
            XmlAttribute Bnrtoll10ton = doc.CreateAttribute("bnrtoll10ton"); Bnrtoll10ton.Value = bnrtoll10ton;
            XmlAttribute Bnrtoll7ton = doc.CreateAttribute("bnrtoll7ton"); Bnrtoll7ton.Value = bnrtoll7ton;
            XmlAttribute Bnrtoll5ton = doc.CreateAttribute("bnrtoll5ton"); Bnrtoll5ton.Value = bnrtoll5ton;
            XmlAttribute Bnrtoll3ton = doc.CreateAttribute("bnrtoll3ton"); Bnrtoll3ton.Value = bnrtoll3ton;
            XmlAttribute Bnrtoll2ton = doc.CreateAttribute("bnrtoll2ton"); Bnrtoll2ton.Value = bnrtoll2ton;
            XmlAttribute Bnrtoll1andhalfton = doc.CreateAttribute("bnrtoll1andhalfton"); Bnrtoll1andhalfton.Value = bnrtoll1andhalfton;
            XmlAttribute Ferrytoll = doc.CreateAttribute("ferrytoll"); Ferrytoll.Value = ferrytoll;
            XmlAttribute Ft20ton = doc.CreateAttribute("ft20ton"); Ft20ton.Value = ft20ton;            
            XmlAttribute Ft7ton = doc.CreateAttribute("ft7ton"); Ft7ton.Value = ft7ton;
            XmlAttribute Ft5ton = doc.CreateAttribute("ft5ton"); Ft5ton.Value = ft5ton;
            XmlAttribute Ft3ton = doc.CreateAttribute("ft3ton"); Ft3ton.Value = ft3ton;
            XmlAttribute Ft1andhalfton = doc.CreateAttribute("ft1andhalfton"); Ft1andhalfton.Value = ft1andhalfton;

            node.Attributes.Append(Reffid);
            node.Attributes.Append(Custid);
            node.Attributes.Append(Custname);
            node.Attributes.Append(Millage);
            node.Attributes.Append(Tripfare);
            node.Attributes.Append(Tfopentruck);
            node.Attributes.Append(Tfcoveredvan);
            node.Attributes.Append(Tfpickup);
            node.Attributes.Append(Tf10ton);            
            node.Attributes.Append(Tf7ton);
            node.Attributes.Append(Tf5ton);
            node.Attributes.Append(Tf3ton);
            node.Attributes.Append(Tf1andhalfton);
            node.Attributes.Append(Bridgetoll);
            node.Attributes.Append(Bnrtoll20ton);
            node.Attributes.Append(Bnrtoll10ton);
            node.Attributes.Append(Bnrtoll7ton);
            node.Attributes.Append(Bnrtoll5ton);
            node.Attributes.Append(Bnrtoll3ton);
            node.Attributes.Append(Bnrtoll2ton);
            node.Attributes.Append(Bnrtoll1andhalfton);
            node.Attributes.Append(Ferrytoll);
            node.Attributes.Append(Ft20ton);
            node.Attributes.Append(Ft7ton);
            node.Attributes.Append(Ft5ton);
            node.Attributes.Append(Ft3ton);
            node.Attributes.Append(Ft1andhalfton);           
            return node;
        }

        //** Gridview Customer Wise Route Cost End 
        protected decimal grandtotal = 0;
        protected decimal totaldieselcredit = 0;
        protected decimal totalcngcredit = 0;
        protected void dgvFuelCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grandtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblGrandTotal")).Text);
                    totaldieselcredit += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lbldieselcredit")).Text);
                    totalcngcredit += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblcngcredit")).Text);

                    decimal fc;
                    txtdgvFTTotal.Text = grandtotal.ToString();
                    try { fc = 0; /*decimal.Parse(txtFuelCash.Text);*/ }
                    catch { fc = 0; }
                    decimal tfc = fc + grandtotal;
                    //txtTFCost.Text = tfc.ToString();
                    
                    decimal bridge; decimal freey; decimal lbexp; decimal pexp;
                    if (txtBridgeToll.Text == "") { bridge = 0; }
                    else { bridge = decimal.Parse(txtBridgeToll.Text); }

                    if (txtFerryToll.Text == "") { freey = 0; }
                    else { freey = decimal.Parse(txtFerryToll.Text); }

                    if (txtLabourExp.Text == "") { lbexp = 0; }
                    else { lbexp = decimal.Parse(txtLabourExp.Text); }

                    if (txtPolice.Text == "") { pexp = 0; }
                    else { pexp = decimal.Parse(txtPolice.Text); }
                    
                    decimal ta = bridge + freey + lbexp + pexp + tfc;
                    txtTotalRouteExp.Text = ta.ToString();
                }
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());

                try
                {
                    dt = new DataTable();
                    dt = obj.GetConfirmTripEntry(intReffID);
                    string strTripCount = dt.Rows[0]["TripCount"].ToString();
                    intTripCount = int.Parse(dt.Rows[0]["TripCount"].ToString());

                }
                catch { intTripCount = 0; }

                //if (intTripCount != 0)
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Pending Previous In Entry In This Vehicle.');", true); return;
                //}
              
                if (dgvFuelCost.Rows.Count > 0)
                {
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
                    //if (xml == "") { return; }
                }

                if (txtBridgeToll.Text == "") { monBridgeToll = 0; } else { monBridgeToll = decimal.Parse(txtBridgeToll.Text); }
                if (txtFerryToll.Text == "") { monFerryEXP = 0; } else { monFerryEXP = decimal.Parse(txtFerryToll.Text); }
                if (txtLabourExp.Text == "") { monLabourEXP = 0; } else { monLabourEXP = decimal.Parse(txtLabourExp.Text); }
                if (txtPolice.Text == "") { monPoliceEXP = 0; } else { monPoliceEXP = decimal.Parse(txtPolice.Text); }
                if (int.Parse(ddlDriverName.SelectedValue.ToString()) == 0) { return; } else { intDriverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString()); }
                //if (txtFuelCash.Text == "") { monFuelCash = 0; } else { monFuelCash = decimal.Parse(txtFuelCash.Text); }
                monFuelCash = 0;
                if (txtAdvance.Text == "") { monAdvance = 0; } else { monAdvance = decimal.Parse(txtAdvance.Text); }
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                TotalRouteExp = decimal.Parse(txtTotalRouteExp.Text);
                
                ///////////////////////////////////////////////////////////////////////////////

                if (dgvTripWiseCustomer.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvTripWiseCustomer.Rows.Count; index++)
                    {
                        reffid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblReffIDG")).Text.ToString();
                        custid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustIDG")).Text.ToString();
                        custname = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustNameG")).Text.ToString();
                        millage = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageG")).Text.ToString();
                        tripfare = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTripFareG")).Text.ToString();
                        tfopentruck = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFOpentruckG")).Text.ToString();
                        tfcoveredvan = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFCoveredVanG")).Text.ToString();
                        tfpickup = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFPickupG")).Text.ToString();
                        tf10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF10TonG")).Text.ToString();
                        tf7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF7TonG")).Text.ToString();
                        tf5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF5TonG")).Text.ToString();
                        tf3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF3TonG")).Text.ToString();
                        tf1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF1AndHalfTonG")).Text.ToString();
                        bridgetoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBridgeTollG")).Text.ToString();
                        bnrtoll20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll20TonG")).Text.ToString();
                        bnrtoll10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll10TonG")).Text.ToString();
                        bnrtoll7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll7TonG")).Text.ToString();
                        bnrtoll5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll5TonG")).Text.ToString();
                        bnrtoll3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll3TonG")).Text.ToString();
                        bnrtoll2ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll2TonG")).Text.ToString();
                        bnrtoll1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll1AndHalfTonG")).Text.ToString();
                        ferrytoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFerryTollG")).Text.ToString();
                        ft20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT20TonG")).Text.ToString();
                        ft7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT7TonG")).Text.ToString();
                        ft5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT5TonG")).Text.ToString();
                        ft3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT3TonG")).Text.ToString();
                        ft1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT1AndHalfTonG")).Text.ToString();
                        
                        if (intUnitID == 1)
                        {
                            if (millage == "" || millage == "0" || tfopentruck == "" || tfopentruck == "0" || tfcoveredvan == "" || tfcoveredvan == "0" || tfpickup == "" || tfpickup == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Route Cost Update.');", true); return;
                            }
                        }
                        else if (intUnitID == 2 || intUnitID == 90)
                        {
                            //|| bnrtoll7ton == "" || bnrtoll7ton == "0" || bnrtoll5ton == "" || bnrtoll5ton == "0" || bnrtoll3ton == "" || bnrtoll3ton == "0" || bnrtoll1andhalfton == "" || bnrtoll1andhalfton == "0" || ft7ton == "" || ft7ton == "0" || ft5ton == "" || ft5ton == "0" || ft3ton == "" || ft3ton == "0" || ft1andhalfton == "" || ft1andhalfton == "0"
                            if (millage == "" || millage == "0" || tf7ton == "" || tf7ton == "0" || tf5ton == "" || tf5ton == "0" || tf3ton == "" || tf3ton == "0" || tf1andhalfton == "" || tf1andhalfton == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Route Cost Update.');", true); return;
                            }
                        }
                        else if (intUnitID == 4 || intUnitID == 8)
                        {
                            if (millage == "" || millage == "0" || tf5ton == "" || tf5ton == "0" || tf3ton == "" || tf3ton == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Route Cost Update.');", true); return;
                            }
                        }
                        else if (intUnitID == 16 || intUnitID == 105)
                        {
                            if (millage == "" || millage == "0" || tf10ton == "" || tf10ton == "0" || tf7ton == "" || tf7ton == "0" || tf5ton == "" || tf5ton == "0" || tf3ton == "" || tf3ton == "0" || tf1andhalfton == "" || tf1andhalfton == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Route Cost Update.');", true); return;
                            }
                        }
                        else if (intUnitID == 10)
                        {
                            
                        }  
                        else
                        {
                            if (millage == "" || millage == "0" || tripfare == "" || tripfare == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Route Cost Update.');", true); return;
                            }
                        }
                    }
                }

                ///////////////////////////////////////////////////////////////////////////////

                //Final Insert
                string message = obj.InsertOutEntry(intReffID, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, intDriverEnroll, monFuelCash, monAdvance, intInsertBy, xml, TotalRouteExp);
                
                if (filePathForXML != null)
                { File.Delete(filePathForXML); } dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LadgerBalance();
        }
        private void LadgerBalance()
        {
            try
            {
                intDriverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString());

                //dt = new DataTable();
                //dt = obj.GetLadgerBalanceOfDriver(intDriverEnroll);
                //if (dt.Rows.Count > 0)
                //{
                //    txtLedgerB.Text = dt.Rows[0]["TotalExp"].ToString();
                //}

                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
            }
            catch { }
        }

        protected void btnAddDriver_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intWork = 3;
                    intReffID = int.Parse(txtDriverEn.Text);
                    //intInsertBy = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
                    intInsertBy = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());

                    string message = obj.InsertAndUpdateCustInfoBridge(intWork, intReffID, intInsertBy, xml);
                    txtDriverEn.Text = "";

                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    dtn = new DataTable();
                    dtn = obj.GetDriverEnrollAndUnitidByTrip(intID);

                    intUnitID = int.Parse(dtn.Rows[0]["intUnitID"].ToString());
                                       
                    dt = new DataTable();
                    dt = obj.GetDriverList(intUnitID);
                    ddlDriverName.DataTextField = "strEmployeeName";
                    ddlDriverName.DataValueField = "intEmployeeID";
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataBind();

                    ddlDriverName.SelectedValue = dtn.Rows[0]["intEmployeeID"].ToString();
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

     

        //protected void dgvTripWiseCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    if (e.ColumnIndex == 3 && e.Value != null && e.Value.ToString() != "")
        //    {
        //        //fill the unbound textbox column (5) from raw value column (3)
        //        string newValue = TimeAttendanceHelper.FormatHourlyDuration(e.Value);
        //        gridview.Rows[e.RowIndex].Cells[5].Value = newValue;
        //    }

        //}


        //private void dgvTripWiseCustomer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) 
        //{
        //    if (e.ColumnIndex == yourEditColumn)
        //    {
        //        string yourValue = "12345";
        //        dataGridView1.Rows[e.RowIndex].Cells[yourEditColumn].Value = yourValue;
        //        if (editBox != null) editBox.Text = yourValue;
        //    }
        //}
             
        //private void dgvTripWiseCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    if (e.ColumnIndex == 3 && e.Value != null && e.Value.ToString() != "")
        //    {
        //        //fill the unbound textbox column (5) from raw value column (3)
        //        string newValue = TimeAttendanceHelper.FormatHourlyDuration(e.Value);
        //        gridview.Rows[e.RowIndex].Cells[5].Value = newValue;
        //    }
        //}



    }
}
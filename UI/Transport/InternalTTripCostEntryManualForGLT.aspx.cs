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
    public partial class InternalTTripCostEntryManualForGLT : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt; DataTable dtn;

        int intID; int intWork;
        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLCustInfo; string xmlStringCustInfo = ""; string xmlCustInfo;
        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName;

        int intUnitID; int intShipPointID; DateTime dteDate; string strFuelPurchaseDate;
        string intPartyID; string fuelstation; string dieselcredit; string cngcredit; string totalcredit;
        string unitid; string shippointid; string unitname; string shippointname; 
        string strEnroll; int intDriverEnroll; int intVehicleID;
        string fromcustid; string tocustid; string milage; string shippid; string getpassno;
        int intCustid; string fromcustname; string tocustname; string dtechallndate; string tfare;
        string causeofaddmillage; string addmillage; string causeofaddfare; string addfare; 

        decimal monBridgeToll; decimal monFerryEXP; decimal monLabourEXP;
        decimal monPoliceEXP; decimal monAdvance; int intInsertBy; string strVehicleNo; decimal TotalRouteExp;
        string dtfarecash; string dtfarecredit; string objFI; string sFileExt1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/Transport/Data/ExpFuelSWDC_" + hdnEnroll.Value + ".xml");
            filePathForXMLCustInfo = Server.MapPath("~/Transport/Data/CustInfoWDC_" + hdnEnroll.Value + ".xml");
            filePathForXMLDocUpload = Server.MapPath("~/Transport/Data/DocUpload_" + hdnEnroll.Value + ".xml");
            BindGrid();
            if (!IsPostBack)
            {
                BindGrid();

                try
                {
                    File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    File.Delete(filePathForXMLCustInfo); dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();
                    
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    //pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();

                    
                    //ddlShipPointForCustomer.DataTextField = "strName";
                    //ddlShipPointForCustomer.DataValueField = "intId";
                    //ddlShipPointForCustomer.DataSource = dt;
                    //ddlShipPointForCustomer.DataBind();

                    intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
                    dt = obj.GetCustomerList(intUnitID, intShipPointID);
                    ddlToAddress.DataTextField = "strName";
                    ddlToAddress.DataValueField = "intCusID";
                    ddlToAddress.DataSource = dt;
                    ddlToAddress.DataBind();

                    ddlFromAddress.DataTextField = "strName";
                    ddlFromAddress.DataValueField = "intCusID";
                    ddlFromAddress.DataSource = dt;
                    ddlFromAddress.DataBind();

                    //try
                    //{
                    //    intCustid = int.Parse(ddlCustomer.SelectedValue.ToString());
                    //    dt = new DataTable();
                    //    dt = obj.GetMillageCustWise(intCustid, intShipPointID);
                    //    txtMillage1.Text = dt.Rows[0]["intMillage"].ToString();
                    //}
                    //catch { }

                    dt = obj.GetVehicleList(intUnitID);
                    ddlVehicleNo.DataTextField = "strRegNo";
                    ddlVehicleNo.DataValueField = "intID";
                    ddlVehicleNo.DataSource = dt;
                    ddlVehicleNo.DataBind();

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

                    intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
                    try
                    {
                        dt = new DataTable();
                        dt = obj.GetDriverSelect(intVehicleID);
                        ddlDriverName.SelectedValue = dt.Rows[0]["intDriverEnroll"].ToString();
                        txtVehicleType.Text = dt.Rows[0]["strType"].ToString();
                    }
                    catch { ddlDriverName.DataBind(); }

                    LadgerBalance();
                    FuelCostLoadByTrip();
                    hdnHightMilage.Value = "0";

                    ////ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                catch
                { }
            }
            
       //if (fileUpload.HasFile)     // CHECK IF ANY FILE HAS BEEN SELECTED.
       // {
       //     int iUploadedCnt = 0;
       //     int iFailedCnt = 0;
       //     HttpFileCollection hfc = Request.Files;
       //     lblFileList.Text = "Select <b>" + hfc.Count + "</b> file(s)";

       //     if (hfc.Count <= 10)    // 10 FILES RESTRICTION.
       //     {
       //         for (int i = 0; i <= hfc.Count - 1; i++)
       //         {
       //             HttpPostedFile hpf = hfc[i];
       //             if (hpf.ContentLength > 0)
       //             {
       //                 if (!File.Exists(Server.MapPath("CopyFiles\\") + 
       //                     Path.GetFileName(hpf.FileName)))
       //                 {
       //                     DirectoryInfo objDir = 
       //                         new DirectoryInfo(Server.MapPath("CopyFiles\\"));

       //                     string sFileName = Path.GetFileName(hpf.FileName);
       //                     string sFileExt = Path.GetExtension(hpf.FileName);

       //                     // CHECK FOR DUPLICATE FILES.
       //                     FileInfo[] objFI = objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

       //                     if (objFI.Length > 0)
       //                     {
       //                         // CHECK IF FILE WITH THE SAME NAME EXISTS 
       //                             //(IGNORING THE EXTENTIONS).
       //                         foreach (FileInfo file in objFI)
       //                         {
       //                             string sFileName1 = objFI[0].Name;
       //                             //string sFileExt1 = Path.GetExtension<objFI[0].Name;
       //                             sFileExt1 = Path.GetExtension (objFI[0].Name);

       //                             if (sFileName1.Replace(sFileExt1, "") == sFileName.Replace(sFileExt, ""))
       //                             {
       //                                 iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
       //                                 break;
       //                             }
       //                         }
       //                     }
       //                     else
       //                     {
       //                         // SAVE THE FILE IN A FOLDER.
       //                         hpf.SaveAs(Server.MapPath("CopyFiles\\") + 
       //                             Path.GetFileName(hpf.FileName));
       //                         iUploadedCnt += 1;
       //                     }
       //                 }
       //             }
       //         }
       //         lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> file(s) Uploaded.";
       //         lblFailedStatus.Text = "<b>" + iFailedCnt + 
       //             "</b> duplicate file(s) could not be uploaded.";
       //     }
       //     else lblUploadStatus.Text = "Max. 10 files allowed.";
       // }
       // else lblUploadStatus.Text = "No files selected.";


        }
        private void FuelCostLoadByTrip()
        {
            try
            {
                intID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
                intWork = 5;
                dt = new DataTable();
                dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
                if (dt.Rows.Count > 0)
                {
                    hdnDieselTotalTk.Value = dt.Rows[0]["DieselPerKM"].ToString();
                    hdnCNGTotalTk.Value = dt.Rows[0]["CNGPerKM"].ToString();
                }
            }
            catch { }
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

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
            }
            catch { }
        }
        protected decimal grandtotal = 0;
        protected decimal totaldieselcredit = 0;
        protected decimal totalcngcredit = 0;

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
                strFuelPurchaseDate = txtFuelPurchaeDate.Text;
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            //&& dieselcredit != "" && cngcredit != "" 
            if (intPartyID != "" && fuelstation != "" && ttk != 0)
            {
                //if (dgvFuelCost.Rows.Count > 0)
                //{
                //    for (int index = 0; index < dgvFuelCost.Rows.Count; index++)
                //    {
                //        string strCheckItemid = ((Label)dgvFuelCost.Rows[index].FindControl("lblPartyID")).Text.ToString();
                //        if (intPartyID == strCheckItemid)
                //        {
                //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Fuel Station is already Added.');", true); return;
                //        }
                //    }
                //}

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
                ////////txtdgvFTTotal.Text = "0";
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
                {
                    File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXml(); }
            }
            catch { }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }
        //** Gridview Add And Delete Row End 

        //** Customer Gridview Fuel Station Add Start ******************************************************        
        protected void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            try { dteDate = DateTime.Parse(txtOutDate.Text); }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Challan/Get Pass Date Properly Input.');", true); return; }
            dtechallndate = DateTime.Parse(txtOutDate.Text).ToString("yyyy-MM-dd");
            tfare = txtTripFare.Text;
            fromcustid = ddlFromAddress.SelectedValue.ToString();
            tocustid = ddlToAddress.SelectedValue.ToString();
            fromcustname = ddlFromAddress.SelectedItem.ToString();
            tocustname = ddlToAddress.SelectedItem.ToString();
            getpassno = txtChallanNo.Text;
            //custname = ddlCustomer.SelectedItem.ToString();
            milage = txtMillage1.Text;
            unitid = ddlUnit.SelectedValue.ToString();
            shippid = ddlShipPoint.SelectedValue.ToString();
            causeofaddmillage = txtCauseOfAdditionalM.Text;
            if (txtAdditionalMillage.Text == "")
            { addmillage = "0"; }
            else { addmillage = txtAdditionalMillage.Text; }            
            causeofaddfare = txtCauseOfAdditionalF.Text;            
            if (txtAdditionalFare.Text == "")
            { addfare = "0"; }
            else { addfare = txtAdditionalFare.Text; }            
            if (txtDTfareCash.Text == "")
            { dtfarecash = "0";}
            else { dtfarecash = txtDTfareCash.Text; }
            if (txtDTfareCredit.Text == "")
            { dtfarecredit = "0"; }
            else { dtfarecredit = txtDTfareCredit.Text; }
            
            
            if (fromcustid != "0" && tocustid != "0" && shippid != "0" && getpassno != "" && milage != "" && milage != "0" && tfare != "" && tfare != "0")
            {
                //if (dgvCustomerAdd.Rows.Count > 0) 
                //{
                //    for (int index = 0; index < dgvCustomerAdd.Rows.Count; index++)
                //    {
                //        string strCheckcustid = ((Label)dgvCustomerAdd.Rows[index].FindControl("lblcustid")).Text.ToString();
                //        if (custid == strCheckcustid)
                //        {
                //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Destination is already Added.');", true); return;
                //        }
                //    }
                //}
                CreateVoucherXmlCustAdd(fromcustid, tocustid, getpassno, fromcustname, tocustname, milage, tfare, unitid, shippid, dtechallndate, causeofaddmillage, addmillage, causeofaddfare, addfare, dtfarecash, dtfarecredit);
                txtChallanNo.Text = "";
                txtTripFare.Text = "";
                txtOutDate.Text = "";
                txtCauseOfAdditionalM.Text = "";
                txtAdditionalMillage.Text = "";
                txtCauseOfAdditionalF.Text = "";
                txtAdditionalFare.Text = "";
                txtDTfareCash.Text = "";
                txtDTfareCredit.Text = "";
                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please properly fillup information.');", true); return; }
        }
        private void CreateVoucherXmlCustAdd(string fromcustid, string tocustid, string getpassno, string fromcustname, string tocustname, string milage, string tfare, string unitid, string shippid, string dtechallndate, string causeofaddmillage, string addmillage, string causeofaddfare, string addfare, string dtfarecash, string dtfarecredit)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLCustInfo))
            {
                doc.Load(filePathForXMLCustInfo);
                XmlNode rootNode = doc.SelectSingleNode("CustDetails");
                XmlNode addItem = CreateItemNodeCustAdd(doc, fromcustid, tocustid, getpassno, fromcustname, tocustname, milage, tfare, unitid, shippid, dtechallndate, causeofaddmillage, addmillage, causeofaddfare, addfare, dtfarecash, dtfarecredit);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CustDetails");
                XmlNode addItem = CreateItemNodeCustAdd(doc, fromcustid, tocustid, getpassno, fromcustname, tocustname, milage, tfare, unitid, shippid, dtechallndate, causeofaddmillage, addmillage, causeofaddfare, addfare, dtfarecash, dtfarecredit);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLCustInfo);
            LoadGridwithXmlCustAdd();
            //Clear();
        }
        private void LoadGridwithXmlCustAdd()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLCustInfo);
            XmlNode dSftTm = doc.SelectSingleNode("CustDetails");
            xmlStringCustInfo = dSftTm.InnerXml;
            xmlStringCustInfo = "<CustDetails>" + xmlStringCustInfo + "</CustDetails>";
            StringReader sr = new StringReader(xmlStringCustInfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvCustomerAdd.DataSource = ds; }
            else { dgvCustomerAdd.DataSource = ""; } dgvCustomerAdd.DataBind();
        }
        private XmlNode CreateItemNodeCustAdd(XmlDocument doc, string fromcustid, string tocustid, string getpassno, string fromcustname, string tocustname, string milage, string tfare, string unitid, string shippid, string dtechallndate, string causeofaddmillage, string addmillage, string causeofaddfare, string addfare, string dtfarecash, string dtfarecredit)
        {
            XmlNode node = doc.CreateElement("CustDetails");

            XmlAttribute Fromcustid = doc.CreateAttribute("fromcustid");
            Fromcustid.Value = fromcustid;
            XmlAttribute Tocustid = doc.CreateAttribute("tocustid");
            Tocustid.Value = tocustid;            
            XmlAttribute Getpassno = doc.CreateAttribute("getpassno");
            Getpassno.Value = getpassno;
            XmlAttribute Fromcustname = doc.CreateAttribute("fromcustname");
            Fromcustname.Value = fromcustname;
            XmlAttribute Tocustname = doc.CreateAttribute("tocustname");
            Tocustname.Value = tocustname;
            XmlAttribute Milage = doc.CreateAttribute("milage");
            Milage.Value = milage;
            XmlAttribute Tfare = doc.CreateAttribute("tfare");
            Tfare.Value = tfare;            
            XmlAttribute Unitid = doc.CreateAttribute("unitid");
            Unitid.Value = unitid;
            XmlAttribute Shippid = doc.CreateAttribute("shippid");
            Shippid.Value = shippid;
            XmlAttribute Dtechallndate = doc.CreateAttribute("dtechallndate");
            Dtechallndate.Value = dtechallndate;
            XmlAttribute Causeofaddmillage = doc.CreateAttribute("causeofaddmillage");
            Causeofaddmillage.Value = causeofaddmillage;
            XmlAttribute Addmillage = doc.CreateAttribute("addmillage");
            Addmillage.Value = addmillage;
            XmlAttribute Causeofaddfare = doc.CreateAttribute("causeofaddfare");
            Causeofaddfare.Value = causeofaddfare;
            XmlAttribute Addfare = doc.CreateAttribute("addfare");
            Addfare.Value = addfare; 
            XmlAttribute Dtfarecash = doc.CreateAttribute("dtfarecash");
            Dtfarecash.Value = dtfarecash;
            XmlAttribute Dtfarecredit = doc.CreateAttribute("dtfarecredit");
            Dtfarecredit.Value = dtfarecredit; 

            node.Attributes.Append(Fromcustid);
            node.Attributes.Append(Tocustid);
            node.Attributes.Append(Getpassno);
            node.Attributes.Append(Fromcustname);
            node.Attributes.Append(Tocustname);
            node.Attributes.Append(Milage);
            node.Attributes.Append(Tfare);            
            node.Attributes.Append(Unitid);
            node.Attributes.Append(Shippid);
            node.Attributes.Append(Dtechallndate);
            node.Attributes.Append(Causeofaddmillage);
            node.Attributes.Append(Addmillage);
            node.Attributes.Append(Causeofaddfare);
            node.Attributes.Append(Addfare);
            node.Attributes.Append(Dtfarecash);
            node.Attributes.Append(Dtfarecredit);
            return node;
        }
        protected void dgvCustomerAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLCustInfo);
                XmlNode dSftTm = doc.SelectSingleNode("CustDetails");
                xmlStringCustInfo = dSftTm.InnerXml;
                xmlStringCustInfo = "<CustDetails>" + xmlStringCustInfo + "</CustDetails>";
                StringReader sr = new StringReader(xmlStringCustInfo);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvCustomerAdd.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvCustomerAdd.DataSource;
                dsGrid.Tables[0].Rows[dgvCustomerAdd.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLCustInfo);
                DataSet dsGridAfterDelete = (DataSet)dgvCustomerAdd.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLCustInfo); dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();
                }
                else { LoadGridwithXmlCustAdd(); }
                hdnHightMilage.Value = HMillag.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
            }
            catch { }
        }
        //** Customer Gridview Add And Delete Row End 

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            //ddlShipPointForCustomer.DataTextField = "strName";
            //ddlShipPointForCustomer.DataValueField = "intId";
            //ddlShipPointForCustomer.DataSource = dt;
            //ddlShipPointForCustomer.DataBind();

            intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
            dt = obj.GetCustomerList(intUnitID, intShipPointID);
            ddlToAddress.DataTextField = "strName";
            ddlToAddress.DataValueField = "intCusID";
            ddlToAddress.DataSource = dt;
            ddlToAddress.DataBind();

            ddlFromAddress.DataTextField = "strName";
            ddlFromAddress.DataValueField = "intCusID";
            ddlFromAddress.DataSource = dt;
            ddlFromAddress.DataBind();

            //try
            //{
            //    intCustid = int.Parse(ddlCustomer.SelectedValue.ToString());
            //    dt = new DataTable();
            //    dt = obj.GetMillageCustWise(intCustid, intShipPointID);
            //    txtMillage1.Text = dt.Rows[0]["intMillage"].ToString();
            //}
            //catch { }

            dt = new DataTable();
            dt = obj.GetVehicleList(intUnitID);
            ddlVehicleNo.DataTextField = "strRegNo";
            ddlVehicleNo.DataValueField = "intID";
            ddlVehicleNo.DataSource = dt;
            ddlVehicleNo.DataBind();

            dt = new DataTable();
            dt = obj.GetDriverList(intUnitID);
            ddlDriverName.DataTextField = "strEmployeeName";
            ddlDriverName.DataValueField = "intEmployeeID";
            ddlDriverName.DataSource = dt;
            ddlDriverName.DataBind();
                        
            try
            {
                intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
                dt = new DataTable();
                dt = obj.GetDriverSelect(intVehicleID);
                ddlDriverName.SelectedValue = dt.Rows[0]["intDriverEnroll"].ToString();
                txtVehicleType.Text = dt.Rows[0]["strType"].ToString();
            }
            catch { ddlDriverName.DataBind(); }

            LadgerBalance();
            FuelCostLoadByTrip();

            File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
            File.Delete(filePathForXMLCustInfo); dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();

        }
        //protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //intShipPointID = int.Parse(ddlShipPointForCustomer.SelectedValue.ToString());
        //        //intCustid = int.Parse(ddlCustomer.SelectedValue.ToString());
        //        //dt = new DataTable();
        //        //dt = obj.GetMillageCustWise(intCustid, intShipPointID);
        //        //txtMillage1.Text = dt.Rows[0]["intMillage"].ToString();
        //    }
        //    catch { }
        //}
        protected void ddlDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LadgerBalance();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //dteDate, intUnitID, intShipPointId, intVehicleID, intDriverEnroll, monBridgeToll, monFerryEXP, 
            //monLabourEXP, monPoliceEXP, monAdvance, intInsertBy, xml, xmlCustInfo
            if (hdnconfirm.Value == "1")
            {

                //try { dteDate = DateTime.Parse(txtOutDate.Text); }
                //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Out Date Properly Input.');", true); return; }

                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                strVehicleNo = ddlVehicleNo.SelectedItem.ToString();
                if (int.Parse(ddlShipPoint.SelectedValue.ToString()) == 0) { return; } else { intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString()); }
                if (int.Parse(ddlVehicleNo.SelectedValue.ToString()) == 0) { return; } else { intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString()); }
                if (txtBridgeToll.Text == "") { monBridgeToll = 0; } else { monBridgeToll = decimal.Parse(txtBridgeToll.Text); }
                if (txtFerryToll.Text == "") { monFerryEXP = 0; } else { monFerryEXP = decimal.Parse(txtFerryToll.Text); }
                if (txtLabourExp.Text == "") { monLabourEXP = 0; } else { monLabourEXP = decimal.Parse(txtLabourExp.Text); }
                if (txtPolice.Text == "") { monPoliceEXP = 0; } else { monPoliceEXP = decimal.Parse(txtPolice.Text); }
                if (int.Parse(ddlDriverName.SelectedValue.ToString()) == 0) { return; } else { intDriverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString()); }
                if (txtAdvance.Text == "") { monAdvance = 0; } else { monAdvance = decimal.Parse(txtAdvance.Text); }
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                TotalRouteExp = decimal.Parse(txtTotalRouteExp.Text);


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
                    doc.Load(filePathForXMLCustInfo);
                    XmlNode dSftTm = doc.SelectSingleNode("CustDetails");
                    xmlStringCustInfo = dSftTm.InnerXml;
                    xmlStringCustInfo = "<CustDetails>" + xmlStringCustInfo + "</CustDetails>";
                    xmlCustInfo = xmlStringCustInfo;
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Customer Add.');", true); return; }
                if (filePathForXMLCustInfo == null) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Customer Add.');", true); return; }

                //Final In Insert
                string message = obj.InsertMEntryForGLT(intUnitID, intShipPointID, intVehicleID, strVehicleNo, intDriverEnroll, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, monAdvance, intInsertBy, xml, xmlCustInfo, TotalRouteExp);

                if (filePathForXML != null)
                { File.Delete(filePathForXML); } dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
                if (filePathForXMLCustInfo != null)
                { File.Delete(filePathForXMLCustInfo); } dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                txtAdvance.Text = "";
                txtLabourExp.Text = "";
                txtPolice.Text = "";

                ///Response.Redirect("~/Transport/InternalTTripCostEntryWithoutDChallan.aspx");
            }
        }
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
                    ////txtdgvFTTotal.Text = grandtotal.ToString();
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
        protected void ddlVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());

            try
            {
                dt = new DataTable();
                dt = obj.GetDriverSelect(intVehicleID);
                ddlDriverName.SelectedValue = dt.Rows[0]["intDriverEnroll"].ToString();
                txtVehicleType.Text = dt.Rows[0]["strType"].ToString();
            }
            catch { ddlDriverName.DataBind(); }

            LadgerBalance();
            FuelCostLoadByTrip();

            File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
            File.Delete(filePathForXMLCustInfo); dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);

        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = obj.GetShipPointList(intUnitID);
            /*ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();*/

            //ddlShipPointForCustomer.DataTextField = "strName";
            //ddlShipPointForCustomer.DataValueField = "intId";
            //ddlShipPointForCustomer.DataSource = dt;
            //ddlShipPointForCustomer.DataBind();

            intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
            dt = obj.GetCustomerList(intUnitID, intShipPointID);
            ddlToAddress.DataTextField = "strName";
            ddlToAddress.DataValueField = "intCusID";
            ddlToAddress.DataSource = dt;
            ddlToAddress.DataBind();

            ddlFromAddress.DataTextField = "strName";
            ddlFromAddress.DataValueField = "intCusID";
            ddlFromAddress.DataSource = dt;
            ddlFromAddress.DataBind();
            
            //try
            //{
            //    intCustid = int.Parse(ddlCustomer.SelectedValue.ToString());
            //    dt = new DataTable();
            //    dt = obj.GetMillageCustWise(intCustid, intShipPointID);
            //    txtMillage1.Text = dt.Rows[0]["intMillage"].ToString();
            //}
            //catch { }

            dt = new DataTable();
            dt = obj.GetVehicleList(intUnitID);
            ddlVehicleNo.DataTextField = "strRegNo";
            ddlVehicleNo.DataValueField = "intID";
            ddlVehicleNo.DataSource = dt;
            ddlVehicleNo.DataBind();

            dt = new DataTable();
            dt = obj.GetDriverList(intUnitID);
            ddlDriverName.DataTextField = "strEmployeeName";
            ddlDriverName.DataValueField = "intEmployeeID";
            ddlDriverName.DataSource = dt;
            ddlDriverName.DataBind();

            intVehicleID = int.Parse(ddlVehicleNo.SelectedValue.ToString());
            try
            {
                dt = new DataTable();
                dt = obj.GetDriverSelect(intVehicleID);
                ddlDriverName.SelectedValue = dt.Rows[0]["intDriverEnroll"].ToString();
                txtVehicleType.Text = dt.Rows[0]["strType"].ToString();
            }
            catch { ddlDriverName.DataBind(); }

            LadgerBalance();

            File.Delete(filePathForXML); dgvFuelCost.DataSource = ""; dgvFuelCost.DataBind();
            File.Delete(filePathForXMLCustInfo); dgvCustomerAdd.DataSource = ""; dgvCustomerAdd.DataBind();

        }
      
        protected decimal Millag = 0;
        protected decimal HMillag = 0;
        protected decimal totalmilage = 0;
        protected decimal totaltfare = 0;
        protected decimal totaladdmilage = 0;
        protected decimal totaladdfare = 0;
        protected decimal totaldtfcash = 0; 
        protected decimal totaldtfcredit = 0; 
        
        protected void dgvCustomerAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalmilage += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblmilag")).Text);                    
                    totaltfare += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lbltf")).Text);
                    totaladdmilage += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblAddmilag")).Text);
                    totaladdfare += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblAddFare")).Text);
                    totaldtfcash += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblDTFareCash")).Text);
                    totaldtfcredit += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblDTFareCredit")).Text);
                    HMillag = totalmilage;
                    hdnHightMilage.Value = HMillag.ToString();                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
            }
            catch { }
        }
        protected void ddlToAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlFromAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       //**************************************************************************************

   //protected void Upload_Files(object sender, EventArgs e)
   // {
   //     if (fileUpload.HasFile)     // CHECK IF ANY FILE HAS BEEN SELECTED.
   //     {
   //         int iUploadedCnt = 0;
   //         int iFailedCnt = 0;
   //         HttpFileCollection hfc = Request.Files;
   //         lblFileList.Text = "Select <b>" + hfc.Count + "</b> file(s)";

   //         if (hfc.Count <= 10)    // 10 FILES RESTRICTION.
   //         {
   //             for (int i = 0; i <= hfc.Count - 1; i++)
   //             {
   //                 HttpPostedFile hpf = hfc[i];
   //                 if (hpf.ContentLength > 0)
   //                 {
   //                     if (!File.Exists(Server.MapPath("CopyFiles\\") + 
   //                         Path.GetFileName(hpf.FileName)))
   //                     {
   //                         DirectoryInfo objDir = 
   //                             new DirectoryInfo(Server.MapPath("CopyFiles\\"));

   //                         string sFileName = Path.GetFileName(hpf.FileName);
   //                         string sFileExt = Path.GetExtension(hpf.FileName);

   //                         // CHECK FOR DUPLICATE FILES.
   //                         FileInfo[] objFI = 
   //                             objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

   //                         if (objFI.Length > 0)
   //                         {
   //                             // CHECK IF FILE WITH THE SAME NAME EXISTS 
   //                                 //(IGNORING THE EXTENTIONS).
   //                             foreach (FileInfo file in objFI)
   //                             {
   //                                 string sFileName1 = objFI[0].Name;
   //                                 string sFileExt1 = Path.GetExtension (objFI[0].Name);

   //                                 if (sFileName1.Replace(sFileExt1, "") == 
   //                                         sFileName.Replace(sFileExt, ""))
   //                                 {
   //                                     iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
   //                                     break;
   //                                 }
   //                             }
   //                         }
   //                         else
   //                         {
   //                             // SAVE THE FILE IN A FOLDER.
   //                             hpf.SaveAs(Server.MapPath("CopyFiles\\") + 
   //                                 Path.GetFileName(hpf.FileName));
   //                             iUploadedCnt += 1;
   //                         }
   //                     }
   //                 }
   //             }
   //             lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> file(s) Uploaded.";
   //             lblFailedStatus.Text = "<b>" + iFailedCnt + 
   //                 "</b> duplicate file(s) could not be uploaded.";
   //         }
   //         else lblUploadStatus.Text = "Max. 10 files allowed.";
   //     }
   //     else lblUploadStatus.Text = "No files selected.";
   // }

        protected void BindGrid()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Transport/Uploads/"));

            List<ListItem> files = new List<ListItem>();

            foreach (string filePath in filePaths)
            {

                files.Add(new ListItem(Path.GetFileName(filePath), filePath));

            }

            GridView1.DataSource = files;

            GridView1.DataBind();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs(Server.MapPath("~/Transport/Uploads/") + FileUpload1.FileName);

                BindGrid();

            }

            else
            {

                Response.Write("Please select file to upload");

            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {

            string filePath = (sender as LinkButton).CommandArgument;

            Response.ContentType = ContentType;

            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));

            Response.WriteFile(filePath);

            Response.End();

        }

        protected void DeleteFile(object sender, EventArgs e)
        {

            string filePath = (sender as LinkButton).CommandArgument;

            File.Delete(filePath);

            BindGrid();

        }






    }
}
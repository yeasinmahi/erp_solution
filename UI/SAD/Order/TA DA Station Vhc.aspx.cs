using HR_BLL.Employee;
using LOGIS_BLL.Supplier;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class TA_DA_Station_Vhc : System.Web.UI.Page
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        string filePathForXML;
        string xmlString = "";
        int intCOAid; int RowIndex;
        protected decimal grandtotal = 0; protected decimal Grndothercost = 0;
        protected decimal hotelfairTotal = 0; protected decimal otherpersondaTotal = 0; protected decimal owndaTotal = 0;
        protected decimal othervhfairTotal = 0; protected decimal boatfairTotal = 0;
        protected decimal trainfairTotal = 0;
        protected decimal cngfairTotal = 0; protected decimal RickfaiTotal = 0; protected decimal busfairTotal = 0;
        int enr;


        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaForStandbyVheicle.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
       
                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }

            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enr = int.Parse(code.ToString());
                    LoadFieldValue(enr);

                }
                else
                {
                    //ClearControls();
                }
            }





        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierList(string prefixText, int count)
        {
           
                

                return VehicleSupplierST.GetAllStandVheicleDataForAutoFillAll("4", prefixText);
          
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetStandVheicleDriverList(string prefixText, int count)
        {



            return VehicleSupplierST.GetAllStandVheicleDriverNameListDataForAutoFillAll("4", prefixText);

        }





        private void LoadFieldValue(int enrol)
        {
            try
            {

                EmployeeRegistration objenrol = new EmployeeRegistration();
                DataTable objDT = new DataTable();
                objDT = objenrol.GetEmployeeProfileByEnrol(enrol);
                if (objDT.Rows.Count >= 0)
                {
                 textEnrol.Text = objDT.Rows[0]["strEmployeeCode"].ToString();
                }

            }
            catch (Exception ex) { throw ex; }
        }

        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("RemotetadaForStandbyVheicle");
                xmlString = dSftTm.InnerXml;
                xmlString = "<RemotetadaForStandbyVheicle>" + xmlString + "</RemotetadaForStandbyVheicle>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvForStandByVehicle.DataSource = ds; }
                else { grdvForStandByVehicle.DataSource = ""; }
                grdvForStandByVehicle.DataBind();
            }
            catch { }
        }



        private void CreateVoucherXml(string BillDate, string enrol, string vhehiclename, string vhechleid, string fromAddress, string movementAddress, string toAddress,
            string remarks,string startmilage, string endmilage, string consumed , string totoilltr, string oilPaymentTypeid  , string oilSupplierID,
            string OilCashAmount, string OilcreditAmount, string cngPaymentTypeid, string CNGSupplierID, string CNGCashAmount, string CNGCreditAmount , string TotalGas,
            string mntCost,string ownda, string ownhotelfair, string personalusedMilageQnt, string personalusemilageTotcost , string OtherCost, string totalcost
           , string slNo
          
           )
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("RemotetadaForStandbyVheicle");
                XmlNode addItem = CreateItemNode(doc, BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
             remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
             OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
             mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, slNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaForStandbyVheicle");
                XmlNode addItem = CreateItemNode(doc, BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
             remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
             OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
             mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, slNo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }


        private void Clear()
        {
          
           txtFromAddr.Text = ""; txtMovementArea.Text = ""; txtToaddr.Text = ""; 
           txtOwnDA.Text = "";  txtOwnHotel.Text = ""; txtOtherCost.Text = ""; 
           txtStartMilage.Text = ""; txtEndMilage.Text = ""; txtConsumed.Text = "";
           txtMntVh.Text = ""; txtSupporting.Text = ""; txtOilLtr.Text = ""; txtoilcash.Text = "";
           txtOilCredit.Text = ""; txtCNGCash.Text = ""; txtCNGCredit.Text = ""; txtTotal.Text = "";
           txtMntVh.Text = ""; txtPersMilagekm.Text = ""; txtPmilagTotalCost.Text = "";

            
        }

        private XmlNode CreateItemNode(XmlDocument doc, string BillDate, string enrol, string vhehiclename, string vhechleid, string fromAddress, string movementAddress, string toAddress,
            string remarks, string startmilage, string endmilage, string consumed, string totoilltr, string oilPaymentTypeid, string oilSupplierID,
            string OilCashAmount, string OilcreditAmount, string cngPaymentTypeid, string CNGSupplierID, string CNGCashAmount, string CNGCreditAmount, string TotalGas,
            string mntCost, string ownda, string ownhotelfair, string personalusedMilageQnt, string personalusemilageTotcost, string OtherCost, string totalcost,string slNo
          )
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("BillDate");
            STRBILLDATE.Value = BillDate;

            XmlAttribute ENROL = doc.CreateAttribute("enrol");
            ENROL.Value = enrol;
            XmlAttribute VHCNAME = doc.CreateAttribute("vhehiclename");
            VHCNAME.Value = vhehiclename;
            XmlAttribute VHCID = doc.CreateAttribute("vhechleid");
            VHCID.Value = vhechleid;
            XmlAttribute FRMADDR = doc.CreateAttribute("fromAddress");
            FRMADDR.Value = fromAddress;
            XmlAttribute MOVADDR = doc.CreateAttribute("movementAddress");
            MOVADDR.Value = movementAddress;
            XmlAttribute TOADDR = doc.CreateAttribute("toAddress");
            TOADDR.Value = toAddress;

            XmlAttribute SUPPORTING = doc.CreateAttribute("remarks");
            SUPPORTING.Value = remarks;

            XmlAttribute STARTMILAGE = doc.CreateAttribute("startmilage");
            STARTMILAGE.Value = startmilage;

            XmlAttribute ENDMILAGE = doc.CreateAttribute("endmilage");
            ENDMILAGE.Value = endmilage;

            XmlAttribute CONSUMEDMILAGE = doc.CreateAttribute("consumed");
            CONSUMEDMILAGE.Value = consumed;


            XmlAttribute TOTALOILLTR = doc.CreateAttribute("totoilltr");
            TOTALOILLTR.Value = totoilltr;

            XmlAttribute OILPAYMENTTYPEID = doc.CreateAttribute("oilPaymentTypeid");
            OILPAYMENTTYPEID.Value = oilPaymentTypeid;
            XmlAttribute OILSUPPLIERID = doc.CreateAttribute("oilSupplierID");
            OILSUPPLIERID.Value = oilSupplierID;
            XmlAttribute OILCASHAMOUNT = doc.CreateAttribute("OilCashAmount");
            OILCASHAMOUNT.Value = OilCashAmount;


            XmlAttribute OILCREDITAMOUNT = doc.CreateAttribute("OilcreditAmount");
            OILCREDITAMOUNT.Value = OilcreditAmount;

            XmlAttribute CNGPAYMENTTYPEID = doc.CreateAttribute("cngPaymentTypeid");
            CNGPAYMENTTYPEID.Value = cngPaymentTypeid;
            XmlAttribute CNGSUPPLIERID = doc.CreateAttribute("CNGSupplierID");
            CNGSUPPLIERID.Value = CNGSupplierID;
            XmlAttribute CNGCASAMOUNT = doc.CreateAttribute("CNGCashAmount");
            CNGCASAMOUNT.Value = CNGCashAmount;

            XmlAttribute CNGCREDITAMOUNT = doc.CreateAttribute("CNGCreditAmount");
            CNGCREDITAMOUNT.Value = CNGCreditAmount;
            XmlAttribute TOTALGASLTR = doc.CreateAttribute("TotalGas");
            TOTALGASLTR.Value = TotalGas;
            XmlAttribute MNTCOST = doc.CreateAttribute("mntCost");
            MNTCOST.Value = mntCost;
            XmlAttribute OWNDA = doc.CreateAttribute("ownda");
            OWNDA.Value = ownda;
            XmlAttribute OWNHOTELF = doc.CreateAttribute("ownhotelfair");
            OWNHOTELF.Value = ownhotelfair;
            XmlAttribute PERSONALUSEMILAGEQNT = doc.CreateAttribute("personalusedMilageQnt");
            PERSONALUSEMILAGEQNT.Value = personalusedMilageQnt;
            XmlAttribute PERSONALUSEMILAGETOTALCOST = doc.CreateAttribute("personalusemilageTotcost");
            PERSONALUSEMILAGETOTALCOST.Value = personalusemilageTotcost;

            XmlAttribute OTHCOST = doc.CreateAttribute("OtherCost");
            OTHCOST.Value = OtherCost;

            XmlAttribute TOTALCOST = doc.CreateAttribute("totalcost");
            TOTALCOST.Value = totalcost;

            XmlAttribute SL = doc.CreateAttribute("slNo");
            SL.Value = slNo;
            

            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(ENROL);
            node.Attributes.Append(VHCNAME);
            node.Attributes.Append(VHCID);
            node.Attributes.Append(FRMADDR);
            node.Attributes.Append(MOVADDR);
            node.Attributes.Append(TOADDR);
            node.Attributes.Append(SUPPORTING);
            node.Attributes.Append(STARTMILAGE);
            node.Attributes.Append(ENDMILAGE);
            node.Attributes.Append(CONSUMEDMILAGE);
            node.Attributes.Append(TOTALOILLTR);
            node.Attributes.Append(OILPAYMENTTYPEID);
            node.Attributes.Append(OILSUPPLIERID);
            node.Attributes.Append(OILCASHAMOUNT);
            node.Attributes.Append(OILCREDITAMOUNT);
            node.Attributes.Append(CNGPAYMENTTYPEID);
            node.Attributes.Append(CNGSUPPLIERID);
            node.Attributes.Append(CNGCASAMOUNT);
            node.Attributes.Append(CNGCREDITAMOUNT);
            node.Attributes.Append(TOTALGASLTR);
            node.Attributes.Append(MNTCOST);
            node.Attributes.Append(OWNDA);
            node.Attributes.Append(OWNHOTELF);
            node.Attributes.Append(PERSONALUSEMILAGEQNT);
            node.Attributes.Append(PERSONALUSEMILAGETOTALCOST);
            node.Attributes.Append(OTHCOST);
            node.Attributes.Append(TOTALCOST);
            node.Attributes.Append(SL);
            return node;
        }



















        protected void GridviewForStationVheicle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridviewForStationVheicle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddBikeCarUser_Click(object sender, EventArgs e)
        {
            string tst = rdbOilstationpay.SelectedValue.ToString();
            string tstCNGGas = rdbCNGSupplierpay.SelectedValue.ToString();
            if (tst == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptMessages", "alert('Please select Oil station Payment Mode !')", true);
            }

            if (tstCNGGas == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptMessages", "alert('Please select CNG Gas station Payment Mode !')", true);
            }
           string oilltr = txtOilLtr.Text;

           if (oilltr == string.Empty || oilltr == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gas Qnt  can not blank !')", true);
            }


            else
            {
                tst = rdbOilstationpay.SelectedValue.ToString();
                tstCNGGas = rdbCNGSupplierpay.SelectedValue.ToString();

                string startmilage = "0", endmilage = "0", consumed = "0", totoilltr = "0",
             OilCashAmount = "0", OilcreditAmount = "0", CNGCashAmount = "0", CNGCreditAmount = "0", TotalGas = "0",
             mntCost = "0", ownda = "0", ownhotelfair = "0", personalusedMilageQnt = "0", personalusemilageTotcost = "0", OtherCost = "", totalcost = "0";
                string oilPaymentTypeid, oilSupplierID,
               cngPaymentTypeid, CNGSupplierID;

               
                string BillDate = txtFromDate.Text;

                string strSearchKey = txtFullName.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                string enrol = code;
               
                string vhehiclename = txtVheicleName.Text;
                arrayKey = vhehiclename.Split(delimiterChars);
                string drivercode = arrayKey[1].ToString();
                string vhechleid = drivercode;





                string fromAddress = txtFromAddr.Text;
                string movementAddress = txtMovementArea.Text;
                string toAddress = txtToaddr.Text;

                string remarks = txtSupporting.Text;
                if (remarks.Length <= 0) { remarks = "NA"; }
                startmilage = txtStartMilage.Text;
                if (startmilage.Length <= 0) { startmilage = "0"; }
                endmilage = txtEndMilage.Text;
                if (endmilage.Length <= 0) { endmilage = "0"; }
                consumed = txtConsumed.Text;
                if (consumed.Length <= 0) { consumed = "0"; }

                totoilltr = txtOilLtr.Text;
                if (totoilltr.Length <= 0) { totoilltr = "0"; }

                if (rdbOilstationpay.SelectedItem.Text == "Cash Oil") { oilPaymentTypeid = "0"; }
                else oilPaymentTypeid = "1";

                if (rdbOilstationpay.SelectedItem.Text == "Cash Oil") { oilSupplierID = "0"; }
                else oilSupplierID = (drdlSupplierName.SelectedValue.ToString());

                OilCashAmount = txtoilcash.Text;
                OilcreditAmount = txtOilCredit.Text;

                if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG") { cngPaymentTypeid = "0"; }
                else cngPaymentTypeid = "1";

                if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG") { CNGSupplierID = "0"; }
                else CNGSupplierID = (DropDownList1.SelectedValue.ToString());

                CNGCashAmount = txtCNGCash.Text;
                if (CNGCashAmount.Length <= 0) { CNGCashAmount = "0"; }
                CNGCreditAmount = txtCNGCredit.Text;
                if (CNGCreditAmount.Length <= 0) { CNGCreditAmount = "0"; }
                TotalGas = txtOilKm.Text;
                if (TotalGas.Length <= 0) { TotalGas = "0"; }
                mntCost = txtMntVh.Text;
                if (mntCost.Length <= 0) { mntCost = "0"; }
                ownda = txtOwnDA.Text;
                if (ownda.Length <= 0) { ownda = "0"; }
                ownhotelfair = txtOwnHotel.Text;
                if (ownhotelfair.Length <= 0) { ownhotelfair = "0"; }
                personalusemilageTotcost = txtPmilagTotalCost.Text;
                if (personalusemilageTotcost.Length <= 0) { personalusemilageTotcost = "0"; }

                personalusedMilageQnt = txtPersMilagekm.Text;
                if (personalusedMilageQnt.Length <= 0) { personalusedMilageQnt = "0"; }



                OtherCost = txtOtherCost.Text;
                if (OtherCost.Length <= 0) { OtherCost = "0"; }

                totalcost = txtTotal.Text;




                if (BillDate == string.Empty || BillDate == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                }

                else if (vhehiclename == string.Empty || vhehiclename == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle Name can not be blank !')", true);
                }

                else if (strSearchKey == string.Empty || strSearchKey == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Name  can not blank !')", true);
                }

                else if (totoilltr == string.Empty || totoilltr == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total Liter can not blank !')", true);
                }
                else if (startmilage == string.Empty || startmilage == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Start Milage  can not blank !')", true);
                }

                else if (endmilage == string.Empty || endmilage == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Start Milage  can not blank !')", true);
                }

                

                else
                {

                    BillDate = txtFromDate.Text;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = code;
                    vhehiclename = txtVheicleName.Text;
                    arrayKey = vhehiclename.Split(delimiterChars);
                     drivercode = arrayKey[1].ToString();
                     vhechleid = drivercode;



                    fromAddress = txtFromAddr.Text;
                    if (fromAddress.Length <= 0) { fromAddress="NA";}
                    movementAddress = txtMovementArea.Text;
                    if(movementAddress.Length<=0){movementAddress="NA";}
                    toAddress = txtToaddr.Text;
                    if (toAddress.Length <= 0) { toAddress = "NA"; }

                    remarks = txtSupporting.Text;
                    if (remarks.Length <= 0) { remarks = "NA"; }
                    startmilage = txtStartMilage.Text;
                    if (startmilage.Length <= 0) { startmilage = "0"; }
                    endmilage = txtEndMilage.Text;
                    if (endmilage.Length <= 0) { endmilage = "0"; }
                    consumed = txtConsumed.Text;
                    if (consumed.Length <= 0) { consumed = "0"; }

                    totoilltr = txtOilLtr.Text;
                    if (totoilltr.Length <= 0) { totoilltr = "0"; }

                    if (rdbOilstationpay.SelectedItem.Text == "Cash Oil") { oilPaymentTypeid = "0"; }
                    else oilPaymentTypeid = "1";

                    if (rdbOilstationpay.SelectedItem.Text == "Cash Oil") { oilSupplierID = "0"; }
                    else oilSupplierID = (drdlSupplierName.SelectedValue.ToString());

                    OilCashAmount = txtoilcash.Text;
                    if (OilCashAmount.Length <= 0) { OilCashAmount = "0"; }
                    OilcreditAmount = txtOilCredit.Text;
                    if (OilcreditAmount.Length <= 0) { OilcreditAmount = "0"; }

                    if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG") { cngPaymentTypeid = "0"; }
                    else cngPaymentTypeid = "1";

                    if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG") { CNGSupplierID = "0"; }
                    else CNGSupplierID = (DropDownList1.SelectedValue.ToString());

                    CNGCashAmount = txtCNGCash.Text;
                    if (CNGCashAmount.Length <= 0) { CNGCashAmount = "0"; }
                    CNGCreditAmount = txtCNGCredit.Text;
                    if (CNGCreditAmount.Length <= 0) { CNGCreditAmount = "0"; }
                    TotalGas = txtOilKm.Text;
                    if (TotalGas.Length <= 0) { TotalGas = "0"; }
                    mntCost = txtMntVh.Text;
                    if (mntCost.Length <= 0) { mntCost = "0"; }
                    ownda = txtOwnDA.Text;
                    if (ownda.Length <= 0) { ownda = "0"; }
                    ownhotelfair = txtOwnHotel.Text;
                    if (ownhotelfair.Length <= 0) { ownhotelfair = "0"; }
                    personalusemilageTotcost = txtPmilagTotalCost.Text;
                    if (personalusemilageTotcost.Length <= 0) { personalusemilageTotcost = "0"; }

                    personalusedMilageQnt = txtPersMilagekm.Text;
                    if (personalusedMilageQnt.Length <= 0) { personalusedMilageQnt = "0"; }



                    OtherCost = txtOtherCost.Text;
                    if (OtherCost.Length <= 0) { OtherCost = "0"; }

                    totalcost = txtTotal.Text;




                    if (grdvForStandByVehicle.Rows.Count <= 0)
                    {
                        serial = "1";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
                        remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
                        OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
                        mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
                        );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 1)
                    {
                        serial = "2";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
 remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
 OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
 mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
 );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 2)
                    {
                        serial = "3";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
   remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
   OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
   mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
   );
                    }
                    else if (grdvForStandByVehicle.Rows.Count == 3)
                    {
                        serial = "4";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
   remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
   OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
   mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
   );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 4)
                    {
                        serial = "5";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
     remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
     OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
     mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
     );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 5)
                    {
                        serial = "6";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
    remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
    OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
    mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
    );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 6)
                    {
                        serial = "7";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
   remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
   OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
   mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
   );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 7)
                    {
                        serial = "8";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
    remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
    OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
    mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
    );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 8)
                    {
                        serial = "9";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
 remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
 OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
 mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
 );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 9)
                    {
                        serial = "10";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
       remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
       OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
       mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
       );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 10)
                    {
                        serial = "11";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
                     remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
                     OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
                     mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
                     );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 11)
                    {
                        serial = "12";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
  remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
  OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
  mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
  );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 12)
                    {
                        serial = "13";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
  remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
  OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
  mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
  );
                    }
                    else if (grdvForStandByVehicle.Rows.Count == 13)
                    {
                        serial = "14";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
 remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
 OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
 mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
 );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 14)
                    {
                        serial = "15";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
   remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
   OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
   mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
   );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 15)
                    {
                        serial = "16";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
               remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
               OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
               mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
               );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 16)
                    {
                        serial = "17";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
          remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
          OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
          mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
          );

                    }

                    else if (grdvForStandByVehicle.Rows.Count == 17)
                    {
                        serial = "18";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
              remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
              OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
              mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
              );

                    }
                    else if (grdvForStandByVehicle.Rows.Count == 18)
                    {
                        serial = "19";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
          remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
          OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
          mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
          );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 19)
                    {
                        serial = "20";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
    remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
    OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
    mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
    );
                    }

                    else if (grdvForStandByVehicle.Rows.Count == 20)
                    {
                        serial = "21";
                        CreateVoucherXml(BillDate, enrol, vhehiclename, vhechleid, fromAddress, movementAddress, toAddress,
  remarks, startmilage, endmilage, consumed, totoilltr, oilPaymentTypeid, oilSupplierID,
  OilCashAmount, OilcreditAmount, cngPaymentTypeid, CNGSupplierID, CNGCashAmount, CNGCreditAmount, TotalGas,
  mntCost, ownda, ownhotelfair, personalusedMilageQnt, personalusemilageTotcost, OtherCost, totalcost, serial
  );

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not allow to add more than Twenty  rows !')", true);

                    }

                }



            }
           
        }




        



        protected void rdbOilstationpay_SelectedIndexChanged(object sender, EventArgs e)
        {

        

            if (rdbOilstationpay.SelectedItem.Text == "Credit Oil")
                drdlSupplierName.Enabled = true;

            else
                drdlSupplierName.Enabled = false;

            if (rdbOilstationpay.SelectedItem.Text == "Credit Oil")

                txtOilCredit.Enabled = true;
         
            else

                txtOilCredit.Enabled = false;

            if (rdbOilstationpay.SelectedItem.Text == "Credit Oil")

                txtoilcash.Enabled = false;

            else

                txtoilcash.Enabled = true;


            if (rdbOilstationpay.SelectedItem.Text == "Cash Oil")
                drdlSupplierName.Enabled = false;

            else
                drdlSupplierName.Enabled = true;

            if (rdbOilstationpay.SelectedItem.Text == "Cash Oil")

                txtoilcash.Enabled = true;

            else

                txtoilcash.Enabled = false;

            if (rdbOilstationpay.SelectedItem.Text == "Cash Oil")

                txtOilCredit.Enabled = false;

            else

                txtOilCredit.Enabled = true;



        }
    



        protected void rdbCNGSupplierpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG")
                DropDownList1.Enabled = false;
            else
                DropDownList1.Enabled = true;

            if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG")
                txtCNGCash.Enabled = true;
            else
                txtCNGCash.Enabled = false;


            if (rdbCNGSupplierpay.SelectedItem.Text == "Cash CNG")
                txtCNGCredit.Enabled = false;
            else
                txtCNGCredit.Enabled = true;




            if (rdbCNGSupplierpay.SelectedItem.Text == "Credit CNG")
                DropDownList1.Enabled = true;
            else
                DropDownList1.Enabled = false;

            if (rdbCNGSupplierpay.SelectedItem.Text == "Credit CNG")
                txtCNGCash.Enabled = false;
            else
                txtCNGCash.Enabled = true;


            if (rdbCNGSupplierpay.SelectedItem.Text == "Credit CNG")
                txtCNGCredit.Enabled = true;
            else
                txtCNGCredit.Enabled = false;





        }

        protected void grdvForStandByVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvForStandByVehicle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvForStandByVehicle.DataSource;
                dsGrid.Tables[0].Rows[grdvForStandByVehicle.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvForStandByVehicle.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvForStandByVehicle.DataSource = ""; grdvForStandByVehicle.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

      

        protected void btnSubmitBikeCar_Click(object sender, EventArgs e)
        {
  

            if (grdvForStandByVehicle.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------

                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                Int32 insertby = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                int BikeCarUserTypeid = 4;
                HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                int unit = Convert.ToInt32(HiddenUnit.Value);
                hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                int jobstation = Convert.ToInt32(hdnstation.Value);
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("RemotetadaForStandbyVheicle");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemotetadaForStandbyVheicle>" + xmlString + "</RemotetadaForStandbyVheicle>";
                    string message = bll.tadaInsertByStandByVheicle(xmlString, dteFromDate, insertby,unit, jobstation,BikeCarUserTypeid);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }
            grdvForStandByVehicle.DataBind();
            File.Delete(filePathForXML);
            grdvForStandByVehicle.DataSource = "";
            grdvForStandByVehicle.DataBind();


        }


        }

     
}
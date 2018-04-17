using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AutoChallan;
using System.Data;
using System.Xml;
using UI.ClassFiles;
using System.IO;
using SAD_BLL.AutoChallanBll;

namespace UI.SAD.ExcelChallan
{
    public partial class frmLoadingSlipChallan : BasePage
    {
        ExcelDataBLL objExcel = new ExcelDataBLL();
        DataTable dt; decimal balance, totalBalance, numLogisticCharge, monExtraAmount, numCharge, numIncentive, numConvRate;
        int Shipid, Custid, intunitid, part, Offid, enroll, intVehicleVarId, intVehicleId, counts = 0, intsalestypeid, intVehicleTypeId, intDisPointId,
        intCurrencyId, intPriceVarId, CustType, intIncentiveId;
        string slip, strCustnameName, strDrivername, strDriverContact,strCode= "", price, strExtraCause, narration = "", intentryid = "", strSupplier, strOther, strVehicleRegNo, strChallanNo, CustAddress, strSupplierCOACod, narratioin, filePathForXML, vno,vid,driverenroll, suppliercheck;
        challanandPending Report = new challanandPending();
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/ExcelChallan/Data/AutoChallanupload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {              
                try { File.Delete(filePathForXML); }catch { }
                part = 2;
                Shipid = int.Parse(Request.QueryString["Shipid"].ToString());
                Offid = int.Parse(Request.QueryString["offid"].ToString());
                Custid = int.Parse(Request.QueryString["Custid"].ToString());
                txtSlipno.Text= Request.QueryString["slipno"].ToString();
                dt = objExcel.getProductview(Custid, Shipid, part);
                dgvPending.DataSource = dt;
                dgvPending.DataBind();

                dt = objExcel.getVehicleAndDriverName(Custid);
                if (dt.Rows.Count > 0)
                {
                    txtDriverName.Text = dt.Rows[0]["stremployeename"].ToString();
                    txtVehicleno.Text = dt.Rows[0]["strVno"].ToString();
                    txtMobile.Text = dt.Rows[0]["strcontactno1"].ToString();
                    hdnVid.Value = dt.Rows[0]["intVid"].ToString();
                    hdnEnroll.Value = dt.Rows[0]["intEmployeeenroll"].ToString();
                    lblDist.Text= dt.Rows[0]["strname"].ToString(); 
                    hdnCustAddress.Value= dt.Rows[0]["straddress"].ToString();
                    hdnCustType.Value = dt.Rows[0]["intCusType"].ToString();
                    hdnSupplier.Value = dt.Rows[0]["strSupplierName"].ToString();
                    lblSupplierName.Text= dt.Rows[0]["strSupplierName"].ToString();
                }
                part = 3;
                dt = objExcel.getProductviewBalance(Custid, Shipid, part);
                hdnAmount.Value= dt.Rows[0]["TotalAmount"].ToString();
                hdnBalance.Value = dt.Rows[0]["AmountBalance"].ToString();
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {           
            Custid = int.Parse(Request.QueryString["Custid"].ToString());
            vid = hdnVid.Value;
            vno = txtVehicleno.Text;
            driverenroll = hdnEnroll.Value;
            intVehicleId = Convert.ToInt32(hdnVid.Value.ToString());
            strDriverContact = Convert.ToString(txtMobile.Text);
            Shipid = int.Parse(Request.QueryString["Shipid"].ToString());
            Offid = int.Parse(Request.QueryString["offid"].ToString());
            dt = Report.getChallanCountCheck(Shipid, Custid);
            if (int.Parse(dt.Rows[0]["ChallanCount"].ToString()) == 0)
              {                 
                slip = Request.QueryString["slipno"].ToString();
                strCustnameName = lblDist.Text;
                bool ysnLogisticByCompany; string numPromQnty;
                int intcheck = int.Parse(1.ToString());
                suppliercheck = hdnSupplier.Value.ToString();

                if (suppliercheck == "Company")
                { ysnLogisticByCompany = Convert.ToBoolean(true.ToString()); }
                else { ysnLogisticByCompany = Convert.ToBoolean(false.ToString()); }

                enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());             
                DateTime dtdate = DateTime.Now;
                narratioin = Convert.ToString("".ToString());
                balance = decimal.Parse(hdnBalance.Value);
                CustAddress = Convert.ToString(hdnCustAddress.Value.ToString());
                CustType = Convert.ToInt32(hdnCustType.Value.ToString());                 
                totalBalance = ((decimal.Parse(balance.ToString())));

                if (decimal.Parse(hdnAmount.Value) < totalBalance)
                  {
                    intDisPointId = int.Parse("0".ToString());
                    bool ysnDO2 = false;
                    bool ysnChallanCompleted = Convert.ToBoolean(false.ToString());
                    intPriceVarId = int.Parse("0".ToString());
                    if (intcheck == 1)
                      { intVehicleVarId = int.Parse("1".ToString()); }
                    else
                      { intVehicleVarId = int.Parse("0".ToString()); }

                    strVehicleRegNo = Convert.ToString(txtVehicleno.Text.ToString());
                    numLogisticCharge = Convert.ToDecimal("0".ToString());
                    bool ysnLogistic = Convert.ToBoolean(true.ToString());
                    intVehicleTypeId = int.Parse("1".ToString());
                    int intChargeId = int.Parse("2".ToString());
                    numCharge = Convert.ToDecimal("1".ToString());
                    intIncentiveId = int.Parse("2".ToString());
                    numIncentive = Convert.ToDecimal("0".ToString());
                    strSupplierCOACod = Convert.ToString("").ToString();
                    strSupplier = Convert.ToString(hdnSupplier.Value.ToString());
                    bool ysnChargeToSupplier = Convert.ToBoolean(true.ToString());
                    intCurrencyId = Convert.ToInt32("1".ToString());
                    numConvRate = Convert.ToDecimal("1".ToString());
                    challanandPending uom = new challanandPending();
                    intsalestypeid = int.Parse("8");
                    monExtraAmount = Convert.ToDecimal("0".ToString());
                    strExtraCause = Convert.ToString("Pcs");
                    strOther = Convert.ToString("".ToString());
                    strDrivername = Convert.ToString(txtDriverName.Text.ToString());               
                    strChallanNo = Convert.ToString("".ToString());
                    #region *************** Xml **************                                           
                    if (dgvPending.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvPending.Rows.Count; index++)
                        {
                            counts = counts + 1;
                            int totalcount = dgvPending.Rows.Count;                            
                            string pid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                            string paname = ((Label)dgvPending.Rows[index].FindControl("lblstrProductName")).Text.ToString();
                            string qty = ((TextBox)dgvPending.Rows[index].FindControl("lblQuantity")).Text.ToString();
                            string accid = ((HiddenField)dgvPending.Rows[index].FindControl("intCOAIDtxt")).Value.ToString();
                            string accName = ((HiddenField)dgvPending.Rows[index].FindControl("strAccNametxt")).Value.ToString();
                            string extid = ((HiddenField)dgvPending.Rows[index].FindControl("Extidtxt")).Value.ToString();
                            string extName = ((HiddenField)dgvPending.Rows[index].FindControl("ExtNametxt")).Value.ToString();
                            string extPr = ((HiddenField)dgvPending.Rows[index].FindControl("ExtPrtxt")).Value.ToString();
                            string itemUom = ((HiddenField)dgvPending.Rows[index].FindControl("ItemUom")).Value.ToString();
                            string cur = ((HiddenField)dgvPending.Rows[index].FindControl("Cur")).Value.ToString();
                            string narr = ((HiddenField)dgvPending.Rows[index].FindControl("Narr")).Value.ToString();
                            string stype = ((HiddenField)dgvPending.Rows[index].FindControl("Salestype")).Value.ToString();
                            string comm = ((HiddenField)dgvPending.Rows[index].FindControl("Comm")).Value.ToString();
                            string uomTxt = ((HiddenField)dgvPending.Rows[index].FindControl("UomTxt")).Value.ToString();
                            string promoItemid = ((HiddenField)dgvPending.Rows[index].FindControl("FreeProductid")).Value.ToString();
                            string promItem = ((HiddenField)dgvPending.Rows[index].FindControl("FreeproductName")).Value.ToString();
                            string promUom = ((HiddenField)dgvPending.Rows[index].FindControl("FreeItemUom")).Value.ToString();
                            string promUomtext = ((HiddenField)dgvPending.Rows[index].FindControl("FreeUomTxt")).Value.ToString();
                            string promitemCOA = ((HiddenField)dgvPending.Rows[index].FindControl("freeintCOAID")).Value.ToString();
                            string prompr = ((HiddenField)dgvPending.Rows[index].FindControl("rate")).Value.ToString();
                            numPromQnty = ((HiddenField)dgvPending.Rows[index].FindControl("numPromQnty")).Value.ToString();
                            string uomqty = ((HiddenField)dgvPending.Rows[index].FindControl("uomqty")).Value.ToString();
                            
                            string rate = ((HiddenField)dgvPending.Rows[index].FindControl("rate")).Value.ToString();
                            string pr = ((HiddenField)dgvPending.Rows[index].FindControl("rate")).Value.ToString();
                            Decimal Freeqty = (((Convert.ToDecimal(numPromQnty.ToString()) / decimal.Parse(uomqty.ToString())) * decimal.Parse(qty.ToString()) * decimal.Parse(uomqty.ToString()))) / decimal.Parse(uomqty.ToString());
                            string Prom = ((HiddenField)dgvPending.Rows[index].FindControl("numPromQnty")).Value.ToString();
                            Prom = Convert.ToString(Math.Round(Freeqty,2));
                            if (qty == "") { qty = "0"; }
                            decimal amount = Convert.ToDecimal(qty) * Convert.ToDecimal(rate);
                            decimal finalttoal = Convert.ToDecimal(qty) + Convert.ToDecimal(rate);
                            string amounts = Convert.ToString(amount);
                            string logisid = Convert.ToString(hdnVid.Value.ToString());
                            string logis = Convert.ToString("0".ToString());
                            string incPr = Convert.ToString("0".ToString());
                            string incId = Convert.ToString("2".ToString());
                            string supTax = Convert.ToString("0".ToString());
                            string vat = Convert.ToString("0".ToString());
                            string vatpr = Convert.ToString("0".ToString());
                            string logisGain = Convert.ToString("0".ToString());
                            string Extpr = Convert.ToString("0".ToString());
                            if (qty != "0")
                            {
                                narration = narration + " [" + qty + "] " + uomTxt + " " + paname;
                                narratioin = narration;
                                Session[narratioin] = narratioin;
                            }
                            intsalestypeid = Convert.ToInt32(stype);
                            if (qty != "0")
                            {
                                if (counts > 7)
                                {
                                    counts = 1;
                                 #region ------------ Insert into dataBase -----------                                                                            

                                    XmlDocument doc = new XmlDocument();
                                    doc.Load(filePathForXML);
                                    XmlNode dSftTm = doc.SelectSingleNode("node");
                                    string xmlString = dSftTm.InnerXml;
                                    xmlString = "<node>" + xmlString + "</node>";
                                    string message = Report.AutoChallaninsertform(xmlString, ref intentryid, enroll, intunitid, dtdate, strChallanNo, CustType, Custid, intDisPointId, narratioin, CustAddress, ysnDO2, ysnChallanCompleted, intPriceVarId, intVehicleVarId, numLogisticCharge, ysnLogistic, ysnLogisticByCompany, strVehicleRegNo, intVehicleId, intVehicleTypeId, intChargeId, numCharge, intIncentiveId, numIncentive, strSupplierCOACod, strSupplier, ysnChargeToSupplier, intCurrencyId, numConvRate, intsalestypeid, monExtraAmount, strExtraCause, strOther, strDrivername, strDriverContact, Offid, Shipid, ref strCode);
                                    File.Delete(filePathForXML);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                                  #endregion ------------ Insertion End ----------------
                                        
                                    qty = Convert.ToString(qty.ToString());
                                    CreateSalesXml(pid, paname, qty, pr, accid, accName, extid, extName, extPr, itemUom, cur, narr, stype, logisid, logis, Prom, comm, incId, incPr, supTax, vat, vatpr, uomTxt, promoItemid, promItem, promUom, promUomtext, logisGain, prompr, promitemCOA);
                                    narration = "";
                                    narration = narration + " [" + qty + "] " + uomTxt + " " + paname;
                                }
                                else
                                {
                                    qty = Convert.ToString(qty.ToString());
                                    CreateSalesXml(pid, paname, qty, pr, accid, accName, extid, extName, extPr, itemUom, cur, narr, stype, logisid, logis, Prom, comm, incId, incPr, supTax, vat, vatpr, uomTxt, promoItemid, promItem, promUom, promUomtext, logisGain, prompr, promitemCOA);
                                }
                            }
                        }
                        if (counts < 8)
                        {
                            #region ------------ Insert into dataBase -----------
                            narratioin = Convert.ToString(Session[narratioin]);
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("node");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<node>" + xmlString + "</node>";
                            string message = Report.AutoChallaninsertform(xmlString, ref intentryid, enroll, intunitid, dtdate, strChallanNo, CustType, Custid, intDisPointId, narratioin, CustAddress, ysnDO2, ysnChallanCompleted, intPriceVarId, intVehicleVarId, numLogisticCharge, ysnLogistic, ysnLogisticByCompany, strVehicleRegNo, intVehicleId, intVehicleTypeId, intChargeId, numCharge, intIncentiveId, numIncentive, strSupplierCOACod, strSupplier, ysnChargeToSupplier, intCurrencyId, numConvRate, intsalestypeid, monExtraAmount, strExtraCause, strOther, strDrivername, strDriverContact, Offid, Shipid, ref strCode);
                            File.Delete(filePathForXML);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                            #endregion ------------ Insertion End ----------------
                            dgvPending.DataBind();
                        }
                        objExcel.getUpdateSlipnobyCustomer(slip, Custid);
                        Report.getBalanceUpdate(Custid, Shipid);
                        objExcel.getOrderdelete(Custid, Shipid);
                    }
                    #endregion ******************** End XML ***********************************
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Your Balance !');", true);}
          }
         else{ ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your Existing Challan Vat Complete !');", true); }
        }
        private void CreateSalesXml(string Pid, string paname, string qty, string pr, string AccId, string AccName,
         string Extid, string ExtName, string Extpr, string itemUom, string Cur, string Narr, string stype, string logisid,
         string logis, string Prom, string Comm, string IncId, string IncPr, string SupTax, string Vat, string Vatpr,
         string UomTxt, string PromoItemid, string PromItem, string PromUom, string PromUomtext, string logisGain,
         string Prompr, string PromitemCOA)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("node");
                XmlNode addItem = CreateItemNode(doc, Pid, paname, qty, pr, AccId, AccName, Extid, ExtName, Extpr, itemUom, Cur, Narr, stype, logisid, logis, Prom, Comm, IncId, IncPr, SupTax, Vat, Vatpr, UomTxt, PromoItemid, PromItem, PromUom, PromUomtext, logisGain, Prompr, PromitemCOA);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("node");
                XmlNode addItem = CreateItemNode(doc, Pid, paname, qty, pr, AccId, AccName, Extid, ExtName, Extpr, itemUom, Cur, Narr, stype, logisid, logis, Prom, Comm, IncId, IncPr, SupTax, Vat, Vatpr, UomTxt, PromoItemid, PromItem, PromUom, PromUomtext, logisGain, Prompr, PromitemCOA);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string Pid, string Pname, string Qnt, string Pr, string AccId, string AccName,
            string ExtId, string ExtName, string ExtPr, string Uom, string Cur, string Narr, string SType, string LogisId,
            string Logis, string Prom, string Comm, string IncId, string IncPr, string SuppTax, string Vat, string VatPr,
            string UomTxt, string PromItemId, string PromItem, string PromUom, string PromUomtext, string LogisGain,
            string PromPr, string PromItemCOA)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute Prid = doc.CreateAttribute("Pid");
            Prid.Value = Pid;
            XmlAttribute Panamet = doc.CreateAttribute("Pname");
            Panamet.Value = Pname;
            XmlAttribute Qtyt = doc.CreateAttribute("Qnt");
            Qtyt.Value = Qnt;
            XmlAttribute Prt = doc.CreateAttribute("Pr");
            Prt.Value = Pr;
            XmlAttribute Accidt = doc.CreateAttribute("AccId");
            Accidt.Value = AccId;
            XmlAttribute AccNamet = doc.CreateAttribute("AccName");
            AccNamet.Value = AccName;
            XmlAttribute Extidt = doc.CreateAttribute("ExtId");
            Extidt.Value = ExtId;
            XmlAttribute ExtNamet = doc.CreateAttribute("ExtName");
            ExtNamet.Value = ExtName;
            XmlAttribute Extprt = doc.CreateAttribute("ExtPr");
            Extprt.Value = ExtPr;
            XmlAttribute ItemUomt = doc.CreateAttribute("Uom");
            ItemUomt.Value = Uom;
            XmlAttribute Curt = doc.CreateAttribute("Cur");
            Curt.Value = Cur;
            XmlAttribute Narrt = doc.CreateAttribute("Narr");
            Narrt.Value = Narr;
            XmlAttribute Stypet = doc.CreateAttribute("SType");
            Stypet.Value = SType;
            XmlAttribute Logisidt = doc.CreateAttribute("LogisId");
            Logisidt.Value = LogisId;
            XmlAttribute Logist = doc.CreateAttribute("Logis");
            Logist.Value = Logis;
            XmlAttribute Promt = doc.CreateAttribute("Prom");
            Promt.Value = Prom;
            XmlAttribute Commt = doc.CreateAttribute("Comm");
            Commt.Value = Comm;
            XmlAttribute IncIdt = doc.CreateAttribute("IncId");
            IncIdt.Value = IncId;
            XmlAttribute IncPrt = doc.CreateAttribute("IncPr");
            IncPrt.Value = IncPr;
            XmlAttribute SupTaxt = doc.CreateAttribute("SuppTax");
            SupTaxt.Value = SuppTax;
            XmlAttribute Vatt = doc.CreateAttribute("Vat");
            Vatt.Value = Vat;
            XmlAttribute Vatprt = doc.CreateAttribute("VatPr");
            Vatprt.Value = VatPr;
            XmlAttribute UomTxtt = doc.CreateAttribute("UomTxt");
            UomTxtt.Value = UomTxt;
            XmlAttribute PromoItemidt = doc.CreateAttribute("PromItemId");
            PromoItemidt.Value = PromItemId;
            XmlAttribute PromItemt = doc.CreateAttribute("PromItem");
            PromItemt.Value = PromItem;
            XmlAttribute PromUomt = doc.CreateAttribute("PromUom");
            PromUomt.Value = PromUom;
            XmlAttribute PromUomtextt = doc.CreateAttribute("PromUomtext");
            PromUomtextt.Value = PromUomtext;
            XmlAttribute LogisGaint = doc.CreateAttribute("LogisGain");
            LogisGaint.Value = LogisGain;
            XmlAttribute Promprt = doc.CreateAttribute("PromPr");
            Promprt.Value = PromPr;
            XmlAttribute PromitemCOAt = doc.CreateAttribute("PromItemCOA");
            PromitemCOAt.Value = PromItemCOA;


            node.Attributes.Append(Prid);
            node.Attributes.Append(Panamet);
            node.Attributes.Append(Qtyt);
            node.Attributes.Append(Prt);
            node.Attributes.Append(Accidt);
            node.Attributes.Append(AccNamet);
            node.Attributes.Append(Extidt);
            node.Attributes.Append(ExtNamet);
            node.Attributes.Append(Extprt);
            node.Attributes.Append(ItemUomt);
            node.Attributes.Append(Curt);
            node.Attributes.Append(Narrt);
            node.Attributes.Append(Stypet);
            node.Attributes.Append(Logisidt);
            node.Attributes.Append(Logist);
            node.Attributes.Append(Promt);
            node.Attributes.Append(Commt);
            node.Attributes.Append(IncIdt);
            node.Attributes.Append(IncPrt);
            node.Attributes.Append(SupTaxt);
            node.Attributes.Append(Vatt);
            node.Attributes.Append(Vatprt);
            node.Attributes.Append(UomTxtt);
            node.Attributes.Append(PromoItemidt);
            node.Attributes.Append(PromItemt);
            node.Attributes.Append(PromUomt);
            node.Attributes.Append(PromUomtextt);
            node.Attributes.Append(LogisGaint);
            node.Attributes.Append(Promprt);
            node.Attributes.Append(PromitemCOAt);
            return node;
        }
       
        protected double Pendingtotal = 0; protected double TotalQty = 0;
        protected void dgvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[5].FindControl("lblTotalqty")).Text == "")
                {
                    TotalQty += 0;
                }
                else
                {
                    TotalQty += double.Parse(((Label)e.Row.Cells[5].FindControl("lblTotalqty")).Text);
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using SAD_BLL.AutoChallanBll;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;


namespace UI.SAD.Corporate_sales
{
    public partial class CorpLoadingSlip : System.Web.UI.Page
    {
        DataTable dtSlipdetailsReport = new DataTable();
        DataTable dtSlipdetailsReportinfo = new DataTable();
        challanandPending Report = new challanandPending();
        string filePathForXML; int enroll; 


        protected void Page_Load(object sender, EventArgs e)
        {
            //enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            enroll = int.Parse("1355".ToString());
            
           // string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());
            string strEnroll = Convert.ToString("1355".ToString());
            filePathForXML = Server.MapPath("Autochallan" + strEnroll + ".xml");
          //  hdnstation.Value = Session[SessionParams.UnitID].ToString();
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                try { File.Delete(filePathForXML); }
                catch { }

                string Slipno = Convert.ToString(Session["slipno"]);

                dtSlipdetailsReportinfo = Report.getSlipDetailsReportfino(Slipno);

                int Vehilceid = int.Parse(dtSlipdetailsReportinfo.Rows[0]["VehicleId"].ToString());
                int Custid = int.Parse(dtSlipdetailsReportinfo.Rows[0]["Custid"].ToString());
                string Vehicleno = dtSlipdetailsReportinfo.Rows[0]["VehicleNo"].ToString();
                string Distributorname = dtSlipdetailsReportinfo.Rows[0]["strName"].ToString();
                string drivername = dtSlipdetailsReportinfo.Rows[0]["drivername"].ToString();
                string mobileno = dtSlipdetailsReportinfo.Rows[0]["strDriverMobileno"].ToString();
                string strSupplierName = dtSlipdetailsReportinfo.Rows[0]["strSupplierName"].ToString();
                Session["Custid"] = Custid;
                Session["Vehicleno"] = Vehicleno;

                Session["mobileno"] = mobileno;

                DataTable dtCustBalance = new DataTable();
                dtCustBalance = Report.getCustBalance(Custid);
                decimal MonBalance = decimal.Parse(dtCustBalance.Rows[0]["Balance"].ToString());
                decimal monCredite = decimal.Parse(dtCustBalance.Rows[0]["monCreditLimit"].ToString());
                string CustAddress = Convert.ToString(dtCustBalance.Rows[0]["strAddress"].ToString());
                int intSalesOffId = int.Parse(dtCustBalance.Rows[0]["intSalesOffId"].ToString());
                int CustType = int.Parse(dtCustBalance.Rows[0]["intCusType"].ToString());
                Session["MonBalance"] = MonBalance;
                Session["monCredite"] = monCredite;
                Session["CustAddress"] = CustAddress;
                Session["intSalesOffId"] = Session["officeid"];
                Session["CustType"] = CustType;



                decimal totalBalance = ((decimal.Parse(MonBalance.ToString()) * -1) + decimal.Parse(monCredite.ToString()));

                DataTable dtBalance = new DataTable();
              int custid = Convert.ToInt32(Session["custid"].ToString());
              string slip = Session["slipno"].ToString();
                dtBalance = Report.getBalanceCheck(slip, custid);

                decimal OrderAmount = decimal.Parse(dtBalance.Rows[0]["Amount"].ToString());

                if (OrderAmount < totalBalance)
                {
                    dtSlipdetailsReport = Report.getSlipDetailsReport(Slipno);
                    GridView1.DataSource = dtSlipdetailsReport;
                    GridView1.DataBind();


                    Label2.Text = Distributorname;
                    Label4.Text = Vehicleno;
                    Label7.Text = Slipno;
                    Label1.Text = drivername;
                    Label13.Text = mobileno;

                    Session["Vehilceid"] = Vehilceid;
                    Session["drivername"] = drivername;

                    Session["strSupplierName"] = strSupplierName;

                }
                else 
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Your Balance!');", true);
                }

               
               
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {

        }
        protected double numqtytotal = 0; protected double totalfreetotal = 0; protected double totalqtytotal = 0; 
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Mlqctotal += int.Parse(((Label)e.Row.Cells[1].FindControl("lblMlqc")).Text);

                if (((TextBox)e.Row.Cells[1].FindControl("lblnumqty")).Text == "")
                {
                    numqtytotal += 0;
                }
                else
                {
                    numqtytotal += double.Parse(((TextBox)e.Row.Cells[1].FindControl("lblnumqty")).Text);
                }
                if (((Label)e.Row.Cells[2].FindControl("lbltotalfree")).Text == "")
                {
                    totalfreetotal += 0;
                }
                else
                {
                    totalfreetotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lbltotalfree")).Text);
                }
                if (((Label)e.Row.Cells[3].FindControl("lbltotalqty")).Text == "")
                {
                    totalqtytotal += 0;
                }
                else
                {
                    totalqtytotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lbltotalqty")).Text);
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Int32 intVehicleId;
            Int32 custid; int ShipPointid;
            DataTable dtChallancount = new DataTable();
            intVehicleId = Convert.ToInt32(Session["Vehilceid"].ToString());
            string strDriverContact = Convert.ToString(Label13.Text);
            ShipPointid= Convert.ToInt32(Session["Shippointid"].ToString());

            custid = Convert.ToInt32(Session["custid"].ToString());
            dtChallancount = Report.getChallanCountCheck(ShipPointid, custid);
            int challacount = int.Parse(dtChallancount.Rows[0]["ChallanCount"].ToString());


            if (challacount == 0)
            {
                 DataTable dtBalance = new DataTable();
                 custid = Convert.ToInt32(Session["custid"].ToString());
                 string slip = Session["slipno"].ToString();
                 dtBalance = Report.getBalanceCheck(slip, custid);

                decimal OrderAmount = decimal.Parse(dtBalance.Rows[0]["Amount"].ToString());

                string strCustnameName = Label2.Text;
                bool ysnLogisticByCompany; string numPromQnty;
                Int32 intcheck = Convert.ToInt32(1.ToString());
                string suppliercheck = Session["strSupplierName"].ToString();
                if (suppliercheck == "Company")
                {
                    ysnLogisticByCompany = Convert.ToBoolean(true.ToString());
                  
                }
                else
                {
                    ysnLogisticByCompany = Convert.ToBoolean(false.ToString());
                   
                }

             
                Int32 insertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intunitid = int.Parse("2".ToString());
                Int32 unit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                DateTime dtdate = DateTime.Now;
                DataTable dtcustinfo = new DataTable();
                custid = Convert.ToInt32(Session["custid"].ToString());
                string narratioin = Convert.ToString("".ToString());


                decimal balance = decimal.Parse(Session["MonBalance"].ToString());
                decimal monCredite = decimal.Parse(Session["monCredite"].ToString());
                string CustAddress = Convert.ToString(Session["CustAddress"].ToString());
                Int32 CustType = Convert.ToInt32(Session["CustType"].ToString());
                Int32 intSalesOffId = Convert.ToInt32(Session["intSalesOffId"].ToString());

                decimal totalBalance = ((decimal.Parse(balance.ToString())*-1) + decimal.Parse(monCredite.ToString()));

                if (OrderAmount < totalBalance)
                {


                    Int32 intDisPointId = Convert.ToInt32("0".ToString());
                    bool ysnDO2 = false;
                    bool ysnChallanCompleted = Convert.ToBoolean(false.ToString());
                    Int32 intPriceVarId = Convert.ToInt32("0".ToString());
                    Int32 intVehicleVarId;
                   
                   
                    if (intcheck == 1)
                    {
                        intVehicleId = Convert.ToInt32(Session["Vehilceid"].ToString());

                        string strVehicleRegNo1 = Convert.ToString(Session["Vehicleno"].ToString());
                        Session["strVehicleRegNo1"] = strVehicleRegNo1;
                        intVehicleVarId = Convert.ToInt32("1".ToString());
                        Session["intVehicleId"] = intVehicleVarId;
                    }
                    else
                    {
                        string strVehicleRegNo1 = Convert.ToString(Session["Vehicleno"].ToString());
                        intVehicleVarId = Convert.ToInt32("0".ToString());
                        Session["strVehicleRegNo1"] = strVehicleRegNo1;
                        Session["intVehicleId"] = intVehicleVarId;
                    }

                    decimal numLogisticCharge = Convert.ToDecimal("0".ToString());
                    bool ysnLogistic = Convert.ToBoolean(true.ToString());
                    string strVehicleRegNo = Session["strVehicleRegNo1"].ToString();
                    intVehicleId = Convert.ToInt32(Session["Vehilceid"].ToString());
                    Int32 intVehicleTypeId = Convert.ToInt32("1".ToString());
                    Int32 intChargeId = Convert.ToInt32("2".ToString());
                    decimal numCharge = Convert.ToDecimal("1".ToString());
                    Int32 intIncentiveId = Convert.ToInt32("2".ToString());
                    decimal numIncentive = Convert.ToDecimal("0".ToString());
                    string strSupplierCOACod = Convert.ToString("").ToString();
                    string strSupplier = Convert.ToString(Session["strSupplierName"].ToString());
                    bool ysnChargeToSupplier = Convert.ToBoolean(true.ToString());
                    Int32 intCurrencyId = Convert.ToInt32("1".ToString());
                    decimal numConvRate = Convert.ToDecimal("1".ToString());

                    DataTable dtsalestype = new DataTable();
                    challanandPending uom = new challanandPending();
                    Int32 unitid = int.Parse("2".ToString());
                  
                    Int32 intsalestypeid = int.Parse("0"); //= Convert.ToInt32(dtsalestype.Rows[0]["intTypeID"].ToString());
                    decimal monExtraAmount = Convert.ToDecimal("0".ToString());
                    string strExtraCause = Convert.ToString("Pcs");
                    string strOther = Convert.ToString("".ToString());
                    string strDrivername = Convert.ToString(Session["drivername"].ToString());
                   
                    Int32 intshipingpointid = Convert.ToInt32(Session["Shippointid"].ToString());
                    string strCode = "";
                    string strChallanNo = Convert.ToString("".ToString());
                    int counts = 0;
                    string narration = "";
                            string intentryid = "";
                    if (GridView1.Rows.Count > 0)
                    {

                        for (int index = 0; index < GridView1.Rows.Count; index++)
                        {
                            counts = counts + 1;


                            Int32 totalcount = GridView1.Rows.Count;

                            string IntOrderNumber = "0";
                            Session["IntOrderNumber"] = IntOrderNumber;
                            string pid = ((Label)GridView1.Rows[index].FindControl("lblProductid")).Text.ToString();
                            string paname = ((Label)GridView1.Rows[index].FindControl("lblstrProductName")).Text.ToString();
                            string qty = ((TextBox)GridView1.Rows[index].FindControl("lblnumqty")).Text.ToString();
                            string accid = ((HiddenField)GridView1.Rows[index].FindControl("intCOAIDtxt")).Value.ToString();
                            string accName = ((HiddenField)GridView1.Rows[index].FindControl("strAccNametxt")).Value.ToString();
                            string extid = ((HiddenField)GridView1.Rows[index].FindControl("Extidtxt")).Value.ToString();
                            string extName = ((HiddenField)GridView1.Rows[index].FindControl("ExtNametxt")).Value.ToString();
                            string extPr = ((HiddenField)GridView1.Rows[index].FindControl("ExtPrtxt")).Value.ToString();
                            string itemUom = ((HiddenField)GridView1.Rows[index].FindControl("ItemUom")).Value.ToString();
                            string cur = ((HiddenField)GridView1.Rows[index].FindControl("Cur")).Value.ToString();
                            string narr = ((HiddenField)GridView1.Rows[index].FindControl("Narr")).Value.ToString();
                            string stype = ((HiddenField)GridView1.Rows[index].FindControl("Salestype")).Value.ToString();
                            string comm = ((HiddenField)GridView1.Rows[index].FindControl("Comm")).Value.ToString();
                            string uomTxt = ((HiddenField)GridView1.Rows[index].FindControl("UomTxt")).Value.ToString();
                            string promoItemid = ((HiddenField)GridView1.Rows[index].FindControl("FreeProductid")).Value.ToString();
                            string promItem = ((HiddenField)GridView1.Rows[index].FindControl("FreeproductName")).Value.ToString();
                            string promUom = ((HiddenField)GridView1.Rows[index].FindControl("FreeItemUom")).Value.ToString();
                            string promUomtext = ((HiddenField)GridView1.Rows[index].FindControl("FreeUomTxt")).Value.ToString();
                            string promitemCOA = ((HiddenField)GridView1.Rows[index].FindControl("freeintCOAID")).Value.ToString();
                            string prompr = ((HiddenField)GridView1.Rows[index].FindControl("rate")).Value.ToString();
                            numPromQnty = ((HiddenField)GridView1.Rows[index].FindControl("numPromQnty")).Value.ToString();
                            string uomqty = ((HiddenField)GridView1.Rows[index].FindControl("uomqty")).Value.ToString();
                            if (uomqty == "")
                            {
                                uomqty = "1";
                            }
                            if (numPromQnty == "")
                            {
                                numPromQnty = "0";
                            }

                            if (promoItemid == "")
                            {
                                promoItemid = "0";
                            }





                            string intCustid = Session["Custid"].ToString();
                            string rate = ((HiddenField)GridView1.Rows[index].FindControl("rate")).Value.ToString();
                            string pr = ((HiddenField)GridView1.Rows[index].FindControl("rate")).Value.ToString();
                            Decimal Freeqty = (((Convert.ToDecimal(numPromQnty.ToString()) / decimal.Parse(uomqty.ToString())) * decimal.Parse(qty.ToString()) * decimal.Parse(uomqty.ToString()))) / decimal.Parse(uomqty.ToString());
                            // Freeqty = Math.Round(Freeqty);

                            string Prom = ((HiddenField)GridView1.Rows[index].FindControl("numPromQnty")).Value.ToString();
                            Prom = Convert.ToString(Freeqty);
                            if (qty == "") { qty = "0"; }
                            decimal amount = Convert.ToDecimal(qty) * Convert.ToDecimal(rate);
                            decimal finalttoal = Convert.ToDecimal(qty) + Convert.ToDecimal(rate);
                            string amounts = Convert.ToString(amount);
                            string logisid = Convert.ToString(Session["intVehicleId"].ToString());
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

                            decimal price = Math.Round(Convert.ToDecimal(pr));
                            pr = Convert.ToString(price);
                            intsalestypeid = Convert.ToInt32(stype);
                            if (qty != "0")
                            {
                                if (counts > 7)
                                {
                                    counts = 1;

 
                                    #region ------------ Insert into dataBase -----------


                                    string txtDate = "2015-5-7";

                                    DateTime date = DateTime.Parse(txtDate);
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load(filePathForXML);
                                    XmlNode dSftTm = doc.SelectSingleNode("node");
                                    string xmlString = dSftTm.InnerXml;
                                    xmlString = "<node>" + xmlString + "</node>";
                                    //string message = rpt.AutoChallaninsertform(xmlString, ref intentryid, insertby, intunitid, dtdate, strChallanNo, CustType, custid, intDisPointId, narratioin, CustAddress, ysnDO2, ysnChallanCompleted, intPriceVarId, intVehicleVarId, numLogisticCharge, ysnLogistic, ysnLogisticByCompany, strVehicleRegNo, intVehicleId, intVehicleTypeId, intChargeId, numCharge, intIncentiveId, numIncentive, strSupplierCOACod, strSupplier, ysnChargeToSupplier, intCurrencyId, numConvRate, intsalestypeid, monExtraAmount, strExtraCause, strOther, strDrivername, strDriverContact, intSalesOffId, intshipingpointid, ref strCode);
                                    string message = Report.AutoChallaninsertform(xmlString, ref intentryid, insertby, intunitid, dtdate, strChallanNo, CustType, custid, intDisPointId, narratioin, CustAddress, ysnDO2, ysnChallanCompleted, intPriceVarId, intVehicleVarId, numLogisticCharge, ysnLogistic, ysnLogisticByCompany, strVehicleRegNo, intVehicleId, intVehicleTypeId, intChargeId, numCharge, intIncentiveId, numIncentive, strSupplierCOACod, strSupplier, ysnChargeToSupplier, intCurrencyId, numConvRate, intsalestypeid, monExtraAmount, strExtraCause, strOther, strDrivername, strDriverContact, intSalesOffId, intshipingpointid, ref strCode);
                                    File.Delete(filePathForXML);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                                    #endregion ------------ Insertion End ----------------
                                    //if (rate != "0.0000" || qty != "0.0000")
                                    // {
                                    qty = Convert.ToString(qty.ToString());


                                    CreateSalesXml(pid, paname, qty, pr, accid, accName, extid, extName, extPr, itemUom, cur, narr, stype, logisid, logis, Prom, comm, incId, incPr, supTax, vat, vatpr, uomTxt, promoItemid, promItem, promUom, promUomtext, logisGain, prompr, promitemCOA);
                                    //  }

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

                            string txtDate = "2015-5-7";

                            DateTime date = DateTime.Parse(txtDate);
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("node");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<node>" + xmlString + "</node>";
                            string message = Report.AutoChallaninsertform(xmlString, ref intentryid, insertby, intunitid, dtdate, strChallanNo, CustType, custid, intDisPointId, narratioin, CustAddress, ysnDO2, ysnChallanCompleted, intPriceVarId, intVehicleVarId, numLogisticCharge, ysnLogistic, ysnLogisticByCompany, strVehicleRegNo, intVehicleId, intVehicleTypeId, intChargeId, numCharge, intIncentiveId, numIncentive, strSupplierCOACod, strSupplier, ysnChargeToSupplier, intCurrencyId, numConvRate, intsalestypeid, monExtraAmount, strExtraCause, strOther, strDrivername, strDriverContact, intSalesOffId, intshipingpointid, ref strCode);
                            File.Delete(filePathForXML);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                            #endregion ------------ Insertion End ----------------
                            GridView1.DataBind();
                        }
                        Report.getUpdateSlipno(slip);
                        Report.getBalanceUpdate(custid,ShipPointid);

                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Your Balance !');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your Existing Challan Vat Complete !');", true);
            }



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
            // LoadGridwithXml();
            // Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string Pid, string Pname, string Qnt, string Pr, string AccId,
            string AccName,
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



       

       
    }
}
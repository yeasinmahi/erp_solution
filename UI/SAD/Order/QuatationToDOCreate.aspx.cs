using SAD_BLL.Sales;
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

namespace UI.SAD.Order
{
    public partial class QuatationToDOCreate : System.Web.UI.Page
    {
        #region Global variable
        string strcustid, strautoid;
        int intCustomerId, intid;
        SalesOrderView bll = new SalesOrderView();
        DataTable dt = new DataTable();
        DataTable dtpend = new DataTable();
        string code, narration, extCause, note, contatcAt = "NA", ContactPhone = "0", id = "";
        char[] delimiterChars = { '[', ']' };
        int Custid, islog, unitid, shopid, intSalesOffId, Depotid, incentiveId , currencyId = 1, custtype, Charge, Territoryid, intsalestype = 88;
        decimal Totalamount;


        bool ysnsdv, ysnDelivaryOrder, logis;
        decimal conversionRate = 1;
        string filePathForXML; string xmlString = ""; string filePathForXML1;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            string strEnroll = Convert.ToString(enroll.ToString());
            filePathForXML = Server.MapPath("ageditorder" + strEnroll + ".xml");
            filePathForXML1 = Server.MapPath("agsubmitorder" + strEnroll + ".xml");
            hdnstation.Value = (Session[SessionParams.UNIT_ID].ToString()); ;


            if (!IsPostBack)
            {

             
                try
                {

                    strcustid = Session["intCustomerId"].ToString();
                    strautoid = Session["intid"].ToString();
                    DateTime fromDate = DateTime.Now.Date;
                    DateTime toDate = DateTime.Now.Date;
                    intCustomerId = int.Parse(strcustid);
                    intid = int.Parse(strautoid);
                    dt = bll.getQuationDets(intid);
                    if (dt.Rows.Count > 0)
                    {
                        grdvQuationDetails.DataSource = dt; grdvQuationDetails.DataBind();
                        lblordernumberval.Text = dt.Rows[0]["strCode"].ToString();
                        lblcustval.Text = dt.Rows[0]["strName"].ToString();
                        lblqotdateval.Text= dt.Rows[0]["dteDate"].ToString();
                    }

                    dtpend = bll.getCustPending(intCustomerId);
                    if (dtpend.Rows.Count > 0)
                    {

                        lblcreditlmval.Text = dtpend.Rows[0]["monCreditLimit"].ToString();
                        lblPendingamount.Text = dtpend.Rows[0]["monPending"].ToString();
                        lbloutstandingval.Text = dtpend.Rows[0]["monOutstanding"].ToString();
                    }
                }
                catch (Exception ex)
                {
                   
                }

               
            }
        }
        protected decimal TotalQty = 0, TotalOrderAmounts = 0;

     

        protected void grdvQuationDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[5].FindControl("lblAmounts")).Text == "")
                {
                    TotalOrderAmounts += 0;
                }
                else
                {
                    TotalOrderAmounts += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblAmounts")).Text);
                }
                lbltotamounval.Text = Math.Round(TotalOrderAmounts).ToString();

                //    //if (((Label)e.Row.Cells[9].FindControl("lblDiscount")).Text == "")
                //    //{
                //    //    TotalQty += 0;
                //    //}
                //    //else
                //    //{
                //    //    TotalQty += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblDiscount")).Text);
                //    //}
                //    //lblTotalDiscount.Text = Math.Round(TotalQty).ToString();
                //    //lblFinalOrderamount.Text = Math.Round((TotalOrderAmounts - TotalQty), 0).ToString();
                //}
            }
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvQuationDetails.DataSource = ds; }

                else { grdvQuationDetails.DataSource = ""; }
                grdvQuationDetails.DataBind();
            }
            catch { }
        }
        private void CreateSalesXml(string Pid, string PName, string Qnt, string Pr,
            string AccId, string AccName, string ExtId, string ExtName, string ExtPr,
            string Uom, string Cur, string Narr
        , string SType, string LogisId, string Prom, string Comm, string IncId,
            string IncPr, string SuppTax, string Vat, string VatPr, string UomTxt
        , string PromItemId, string PromItem, string PromUom, string PromUomText,
            string PromPr, string PromItemCOA, string SoPkId, string ApprQnt)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML1))
            {
                doc.Load(filePathForXML1);
                XmlNode rootNode = doc.SelectSingleNode("node");
                XmlNode addItem = CreateItemNode(doc, Pid, PName, Qnt, Pr, AccId, AccName, ExtId, ExtName, ExtPr, Uom, Cur, Narr, SType, LogisId, Prom, Comm, IncId, IncPr, SuppTax, Vat, VatPr, UomTxt, PromItemId, PromItem, PromUom, PromUomText, PromPr, PromItemCOA, SoPkId, ApprQnt);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("node");
                XmlNode addItem = CreateItemNode(doc, Pid, PName, Qnt, Pr, AccId, AccName, ExtId, ExtName, ExtPr, Uom, Cur, Narr, SType, LogisId, Prom, Comm, IncId, IncPr, SuppTax, Vat, VatPr, UomTxt, PromItemId, PromItem, PromUom, PromUomText, PromPr, PromItemCOA, SoPkId, ApprQnt);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML1);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string Pid, string PName,
            string Qnt,
            string Pr, string AccId, string AccName, string ExtId, string ExtName, string
            ExtPr, string Uom, string Cur, string Narr, string SType, string LogisId,
            string Prom, string Comm,
            string IncId, string IncPr, string SuppTax, string Vat, string VatPr,
            string UomTxt, string PromItemId, string PromItem, string PromUom,
            string PromUomText, string PromPr, string PromItemCOA, string SoPkId,
            string ApprQnt)
        {
            XmlNode node = doc.CreateElement("item");
            XmlAttribute Pidt = doc.CreateAttribute("Pid");
            Pidt.Value = Pid;
            XmlAttribute PNamet = doc.CreateAttribute("PName");
            PNamet.Value = PName;
            XmlAttribute Qntt = doc.CreateAttribute("Qnt");
            Qntt.Value = Qnt;
            XmlAttribute pr = doc.CreateAttribute("Pr");
            pr.Value = Pr;
            XmlAttribute AccIdt = doc.CreateAttribute("AccId");
            AccIdt.Value = AccId;
            XmlAttribute AccNamet = doc.CreateAttribute("AccName");
            AccNamet.Value = AccName;
            XmlAttribute ExtIdt = doc.CreateAttribute("ExtId");
            ExtIdt.Value = ExtId;
            XmlAttribute ExtNamet = doc.CreateAttribute("ExtName");
            ExtNamet.Value = ExtName;
            XmlAttribute ExtPrt = doc.CreateAttribute("ExtPr");
            ExtPrt.Value = ExtPr;
            XmlAttribute Uomt = doc.CreateAttribute("Uom");
            Uomt.Value = Uom;
            XmlAttribute Curt = doc.CreateAttribute("Cur");
            Curt.Value = Cur;
            XmlAttribute Narrt = doc.CreateAttribute("Narr");
            Narrt.Value = Narr;
            XmlAttribute STypet = doc.CreateAttribute("SType");
            STypet.Value = SType;
            XmlAttribute LogisIdt = doc.CreateAttribute("LogisId");
            LogisIdt.Value = LogisId;
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
            XmlAttribute VatPrt = doc.CreateAttribute("VatPr");
            VatPrt.Value = VatPr;
            XmlAttribute UomTxtt = doc.CreateAttribute("UomTxt");
            UomTxtt.Value = UomTxt;
            XmlAttribute PromItemIdt = doc.CreateAttribute("PromItemId");
            PromItemIdt.Value = PromItemId;
            XmlAttribute PromItemt = doc.CreateAttribute("PromItem");
            PromItemt.Value = PromItem;
            XmlAttribute PromUomt = doc.CreateAttribute("PromUom");
            PromUomt.Value = PromUom;
            XmlAttribute PromUomTextt = doc.CreateAttribute("PromUomText");
            PromUomTextt.Value = PromUomText;
            XmlAttribute PromPrt = doc.CreateAttribute("PromPr");
            PromPrt.Value = PromPr;
            XmlAttribute PromItemCOAt = doc.CreateAttribute("PromItemCOA");
            PromItemCOAt.Value = PromItemCOA;
            XmlAttribute SoPkIdt = doc.CreateAttribute("SoPkId");
            SoPkIdt.Value = SoPkId;
            XmlAttribute ApprQntt = doc.CreateAttribute("ApprQnt");
            ApprQntt.Value = ApprQnt;


            node.Attributes.Append(Pidt);
            node.Attributes.Append(PNamet);
            node.Attributes.Append(Qntt);
            node.Attributes.Append(pr);
            node.Attributes.Append(AccIdt);
            node.Attributes.Append(AccNamet);
            node.Attributes.Append(ExtIdt);
            node.Attributes.Append(ExtNamet);
            node.Attributes.Append(ExtPrt);
            node.Attributes.Append(Uomt);
            node.Attributes.Append(Curt);
            node.Attributes.Append(Narrt);
            node.Attributes.Append(STypet);
            node.Attributes.Append(LogisIdt);
            node.Attributes.Append(Promt);
            node.Attributes.Append(Commt);
            node.Attributes.Append(IncIdt);
            node.Attributes.Append(IncPrt);
            node.Attributes.Append(SupTaxt);
            node.Attributes.Append(Vatt);
            node.Attributes.Append(VatPrt);
            node.Attributes.Append(UomTxtt);
            node.Attributes.Append(PromItemIdt);
            node.Attributes.Append(PromItemt);
            node.Attributes.Append(PromUomt);
            node.Attributes.Append(PromUomTextt);
            node.Attributes.Append(PromPrt);
            node.Attributes.Append(SoPkIdt);
            node.Attributes.Append(ApprQntt);

            return node;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //if (hdnconfirm.Value == "1")
            //{

            //if (decimal.Parse(lbloutstandingval.Text.ToString()) >= decimal.Parse(lbltotamounval.Text.ToString()))
            //{

                Int32 intOrdernum = Convert.ToInt32(Session["intid"].ToString().ToString());
                //orderdelete.orderdeletefinal(intOrdernum);

                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
               

                string intCustid;
            DataTable dtr = new DataTable();
            int count = grdvQuationDetails.Rows.Count;

                if (grdvQuationDetails.Rows.Count > 0)
                {

                    for (int index = 0; index < grdvQuationDetails.Rows.Count; index++)
                    {


                        string IntOrderNumber = ((Label)grdvQuationDetails.Rows[index].FindControl("IntOrderNumber")).Text.ToString();
                        Session["IntOrderNumber"] = IntOrderNumber;
                        intCustid = ((HiddenField)grdvQuationDetails.Rows[index].FindControl("hdncustid")).Value.ToString();
                        Session["intCustid"] = intCustid;


                        string depot = ((HiddenField)grdvQuationDetails.Rows[index].FindControl("hdnintShipPointId")).Value.ToString();
                        string itemid = ((HiddenField)grdvQuationDetails.Rows[index].FindControl("hdnitemid")).Value.ToString();
                        string strItemName = ((Label)grdvQuationDetails.Rows[index].FindControl("lblprdname")).Text.ToString();
                        string rate = ((HiddenField)grdvQuationDetails.Rows[index].FindControl("hdnnumprice")).Value.ToString();
                        string quantity = ((TextBox)grdvQuationDetails.Rows[index].FindControl("txtquantity")).Text.ToString();
                        string remarks = ((HiddenField)grdvQuationDetails.Rows[index].FindControl("hdnstrTermsNCondition")).Value.ToString();
                        string Appquantity = ((TextBox)grdvQuationDetails.Rows[index].FindControl("txtquantity")).Text.ToString();

                        if (quantity == "") { quantity = "0"; }
                        string Promotion = "0";

                        if (decimal.Parse(quantity) > 0)
                        {
                            decimal amount = Convert.ToDecimal(quantity) * Convert.ToDecimal(rate);

                            string amounts = Convert.ToString(amount);
                            Totalamount = decimal.Parse(Totalamount.ToString()) + amount;

                            unitid = int.Parse("91");
                            dt = bll.getCOAID(itemid, unitid, intsalestype);
                            int coaid = int.Parse(dt.Rows[0]["COAid"].ToString());
                            string coaName = (dt.Rows[0]["AccName"].ToString());

                            int extrap = 1;
                            string extname = "";
                            int incentive = 0;
                            int chrPr = 1;
                            decimal promotionqty = 0;
                            decimal comission = amount * decimal.Parse("0.0");
                            int intpro = 1;
                            int incPr = 1;
                            decimal vat = 0;
                            decimal vatp = 0;
                            string supptex = "0";
                            decimal supp = 0;
                            decimal propric = 0;
                            int intProItemid = 0;
                            string proItem = "";
                            string promItemUOM = "0";
                            string promUom = "";
                            string proUomName = "";
                            decimal promPrice = 0;
                            int promItemCOAId = coaid;
                            int curr = 1;
                            dt = bll.getCOAID(itemid, unitid, intsalestype);
                            int ExtId = 0;
                            int salestype = 90;
                            string ThanaRate = "0";
                            dt = bll.getUOM(int.Parse(Session["intCustid"].ToString()),int.Parse("0"), int.Parse("0"), int.Parse("90") , Convert.ToDateTime(DateTime.Now));
                            string uom = dt.Rows[0]["strUOM"].ToString();
                            string pUOm = "";
                            int proitemUOMID = int.Parse(dt.Rows[0]["intID"].ToString());
                            int uomid = int.Parse(dt.Rows[0]["intID"].ToString());
                            int incentiveId =  int.Parse(Session["IntOrderNumber"].ToString());
                        string code = "";
                            if (quantity != "0")
                            {
                                if (quantity != "0")
                                {
                                    narration = narration + " [" + quantity + "] " + uom + " " + strItemName;

                                }

                                if (rate != "0.0000" || quantity != "0.0000")
                                {


                                    CreateSalesXml(itemid, strItemName, quantity, rate, coaid.ToString(), coaName,
                                    ExtId.ToString(), extname, extrap.ToString(), uomid.ToString(), curr.ToString(),
                                    narration, salestype.ToString(), "0".ToString(), promotionqty.ToString(), comission.ToString(), incentiveId.ToString()
                                    , incPr.ToString(), supptex, vat.ToString(), vatp.ToString(),
                                    uom, intProItemid.ToString(), proItem, promItemUOM, pUOm
                                    , promPrice.ToString(), promItemCOAId.ToString(), ThanaRate, Appquantity);

                                }

                            }

                        }
                    }

                    if (hdnLog.Value == "1")
                    {
                        logis = true;
                    }
                    else { logis = false; }


                    Depotid = int.Parse("1150");

                    note = "";
                    #region ------------ Insert into dataBase -----------
                    Custid = int.Parse(Session["intCustid"].ToString());
                    dtpend = bll.getcustomerinformations(Custid);
                    string addresss = dtpend.Rows[0]["strAddress"].ToString();
                    intSalesOffId = int.Parse(dtpend.Rows[0]["intSalesOffId"].ToString());
                    ContactPhone = dtpend.Rows[0]["strContactNo"].ToString();
                    narration = dtpend.Rows[0]["strCusName"].ToString() + narration;
                Int32 unit = int.Parse(dtpend.Rows[0]["intunitid"].ToString());
                string monLim = "", monBalance = "";

                    decimal balance = decimal.Parse(dtpend.Rows[0]["monOutstanding"].ToString());
                    decimal Limit = decimal.Parse(dtpend.Rows[0]["monCreditLimit"].ToString());
                    decimal totalbalce = balance + Limit;

                    Territoryid = int.Parse(dtpend.Rows[0]["intPriceCatagory"].ToString());



                    custtype = int.Parse(dtpend.Rows[0]["intCusType"].ToString());
                    extCause = "Pcs";
                    Charge = 1;
                    ysnDelivaryOrder = true;
               

                    #endregion ------------ Insertion End ----------------
                DateTime date = DateTime.Parse(DateTime.Now.ToString());
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML1);
                    XmlNode dSftTm = doc.SelectSingleNode("node");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<node>" + xmlString + "</node>";
                    string message = bll.DoCreateFromQuotaion(xmlString, ref id, enroll, unit, date, date, custtype, Custid, shopid, narration, addresss, Territoryid, Charge, logis, Charge, Charge, incentiveId, incentiveId, currencyId, conversionRate, intsalestype, Totalamount, extCause, note
                    , contatcAt, ContactPhone, intSalesOffId, Depotid, ysnDelivaryOrder, ysnsdv, ref code);
                    File.Delete(filePathForXML1);
              
                //bll.getDoCompleteComplete(enroll, code, unit);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + "Your Do Number : " + code + "');", true);
                    lblDo.Text = "DO No: " + code.ToString();

                    grdvQuationDetails.DataBind();
                    //Int32 ONumber = Convert.ToInt32(Session["ordernumber1"].ToString());
                    //objDo.getorderInactive(ONumber);

                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Your Balance !');", true);
            }



        }
    }
}
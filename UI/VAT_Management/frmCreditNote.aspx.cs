using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;

namespace UI.VAT_Management
{
    public partial class frmCreditNote : BasePage
    {
        string filePathForXML,Pname, xmlString = "",strChallanNo, ItemName, strReason, strItem, strVehicleTypeNo, strCusName, strCusAddress, strCusVatReg, intVATTime;
        int intItem, intitemid, intYear, intM12No, intM11Challanno,intCustid,VatChallanNo, intid,intyear,intMonth, intSL;
        VAT_BLL objvat = new VAT_BLL();
        string[] arrayKeyItem;
        CreditNoteBLL objCreditBll = new CreditNoteBLL();
        DataTable dt;
        decimal numQty, monRtnAmountWithoutSDnVAT, monValue, monSD, monSurCharge, monVAT, monM11Other, monM11VAT, monNewSD, monNewVAT;


        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' };bool ysnFactory;
        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/VAT_Management/Data/CreditNote_" + Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                try { File.Delete(filePathForXML); }
                catch { }

                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }
                dt.Clear();
                dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                ddlVatAccount.DataTextField = "strVATAccountName";
                ddlVatAccount.DataValueField = "intVatPointID";
                ddlVatAccount.DataSource = dt;
                ddlVatAccount.DataBind();
                lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
               // hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();
                dt.Clear();
            }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (lblM11Vat.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select New Item');", true);
                }
                else
                {
                    intitemid = int.Parse(hdnitemid.Value.ToString());
                    strChallanNo = ddlChallanNo.SelectedValue.ToString();
                    Pname = txtVatItemList.Text.ToString();
                    dtedate = DateTime.Parse(lblChallanDate.Text);
                    string creditqty = txtCreditqty.Text;
                    string sdnew = txtSD.Text;
                    string othersdNew = txtWithoutSDVAT.Text;
                    string surnew = txtSurcharge.Text;
                    string vatnew = txtVAT.Text;
                    string m11vat = lblM11Vat.Text;
                    string others = lblM11OthersTax.Text;
                    decimal Decreasedothers = decimal.Parse(others) - decimal.Parse(surnew) - decimal.Parse(sdnew);
                    decimal DecreasedVat = decimal.Parse(m11vat) - decimal.Parse(vatnew);

                    CreateVoucherXml(intitemid.ToString(), strChallanNo, dtedate.ToString(), Pname, creditqty, othersdNew, sdnew, surnew, vatnew, m11vat, others, Decreasedothers.ToString(), DecreasedVat.ToString());

                    txtCreditqty.Text = "";
                    txtSD.Text = "";
                    txtWithoutSDVAT.Text = "";
                    txtSurcharge.Text = "";
                    txtVAT.Text = "";
                    lblM11Vat.Text = "";
                    lblM11OthersTax.Text = "";
                    lblProductQty.Text = "";
                    lblChallanDate.Text = "";
                }
            

            }
        }
        private void CreateVoucherXml(string intitemid, string strChallanNo, string dtedate, string Pname, string creditqty, string othersdNew, string sdnew, string surnew, string vatnew, string m11vat, string others, string Decreasedothers, string DecreasedVat)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, intitemid, strChallanNo, dtedate, Pname, creditqty, othersdNew, sdnew, surnew, vatnew, m11vat, others, Decreasedothers, DecreasedVat);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, intitemid, strChallanNo, dtedate, Pname, creditqty, othersdNew, sdnew, surnew, vatnew, m11vat, others, Decreasedothers, DecreasedVat);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
            xmlString = dSftTm.InnerXml;
            xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvVatProduct.DataSource = ds; }
            else { dgvVatProduct.DataSource = ""; }
            dgvVatProduct.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intitemid, string strChallanNo, 
            string dtedate, string Pname, string creditqty, string othersdNew, string sdnew, 
            string surnew, string vatnew, string m11vat, string others, string Decreasedothers, string DecreasedVat)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Intitemid = doc.CreateAttribute("intitemid"); Intitemid.Value = intitemid;
            XmlAttribute StrChallanNo = doc.CreateAttribute("strChallanNo"); StrChallanNo.Value = strChallanNo;
            XmlAttribute Dtedate = doc.CreateAttribute("dtedate"); Dtedate.Value = dtedate;
            XmlAttribute pname = doc.CreateAttribute("Pname"); pname.Value = Pname;
            XmlAttribute Creditqty = doc.CreateAttribute("creditqty"); Creditqty.Value = creditqty;
            XmlAttribute OthersdNew = doc.CreateAttribute("othersdNew"); OthersdNew.Value = othersdNew;
            XmlAttribute Sdnew = doc.CreateAttribute("sdnew"); Sdnew.Value = sdnew;
            XmlAttribute Surnew = doc.CreateAttribute("surnew"); Surnew.Value = surnew;
            XmlAttribute Vatnew = doc.CreateAttribute("vatnew"); Vatnew.Value = vatnew;
            XmlAttribute M11vat = doc.CreateAttribute("m11vat"); M11vat.Value = m11vat;
            XmlAttribute Others = doc.CreateAttribute("others"); Others.Value = others;
            XmlAttribute decreasedothers = doc.CreateAttribute("Decreasedothers"); decreasedothers.Value = Decreasedothers;
            XmlAttribute decreasedVat = doc.CreateAttribute("DecreasedVat"); decreasedVat.Value = DecreasedVat;


            node.Attributes.Append(Intitemid);
            node.Attributes.Append(StrChallanNo);
            node.Attributes.Append(Dtedate);
            node.Attributes.Append(pname);
            node.Attributes.Append(Creditqty);
            node.Attributes.Append(OthersdNew);
            node.Attributes.Append(Sdnew);
            node.Attributes.Append(Surnew);
            node.Attributes.Append(Vatnew);
            node.Attributes.Append(M11vat);
            node.Attributes.Append(Others);
            node.Attributes.Append(decreasedothers);
            node.Attributes.Append(decreasedVat);
            return node;
        }
        protected void dgvBandrollReceive_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                xmlString = dSftTm.InnerXml;
                xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                //dgvBandrollReceive.DataSource = ds;

                //DataSet dsGrid = (DataSet)dgvBandrollReceive.DataSource;
               // dsGrid.Tables[0].Rows[dgvBandrollReceive.Rows[e.RowIndex].DataItemIndex].Delete();
              //  dsGrid.WriteXml(filePathForXML);
              //  DataSet dsGridAfterDelete = (DataSet)dgvBandrollReceive.DataSource;
              //  if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
              //  {
              //      File.Delete(filePathForXML); dgvBandrollReceive.DataSource = ""; dgvBandrollReceive.DataBind();
              //  }
              //  else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected void ddlChallanNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItemList.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            ItemName = (arrayKeyItem[0].ToString());
            intitemid = Int32.Parse(arrayKeyItem[1].ToString());

            dt = objCreditBll.GETCreditlist(ddlChallanNo.SelectedValue.ToString(), int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value));
            
            lblCustVatRegno.Text = dt.Rows[0]["strCustVATRegNo"].ToString();
            lblChallanDate.Text = dt.Rows[0]["dteSellingDate"].ToString();

            dt = objCreditBll.getChallanInfo(ddlChallanNo.SelectedValue.ToString(), int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), intitemid);
            lblProductQty.Text = dt.Rows[0]["numQuantity"].ToString();
            lblM11OthersTax.Text = dt.Rows[0]["OthersSDVAT"].ToString();
            lblChallanDate.Text = dt.Rows[0]["dteSellingDate"].ToString();
            lblM11Vat.Text= dt.Rows[0]["monVAT"].ToString();
            hdnCustid.Value= dt.Rows[0]["intcusid"].ToString(); 
            hdnCustAddress.Value = dt.Rows[0]["strcustaddress"].ToString();

        }
        protected void txtVatItemList_TextChanged(object sender, EventArgs e)
        {
            getDropdownChallanList();

        }

        private void getDropdownChallanList()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItemList.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            ItemName = (arrayKeyItem[0].ToString());
            intitemid = Int32.Parse(arrayKeyItem[1].ToString());
            hdnitemid.Value = arrayKeyItem[1].ToString();
            dt = objCreditBll.getCreditchallan(int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value),intitemid);
            ddlChallanNo.DataTextField = "strVATChallanNowith";
            ddlChallanNo.DataValueField = "strVATChallanNo";
            ddlChallanNo.DataSource = dt;
            ddlChallanNo.DataBind();


        }

       

        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            intM11Challanno =int.Parse(ddlChallanNo.SelectedValue);
            intCustid = int.Parse(hdnCustid.Value);
            strCusName= "N/A";
            strCusAddress = hdnCustAddress.Value;
          // strVehicleTypeNo = txtVehicletypeno.Text;
            dtedate = DateTime.Now;
            if (dtedate.Month >= 7)
            {
                intYear = int.Parse((dtedate.Year) + "" + ((dtedate.Year) + 1).ToString());
            }
            else { intYear = int.Parse(((dtedate.Year) - 1).ToString() + "" + ((dtedate.Year) + 1).ToString()); }
            dt = objMush.getVatChallano(intYear, int.Parse(hdnAccno.Value), "M12");
            intM12No = int.Parse(dt.Rows[0]["intVatChallanNo"].ToString());

            intSL = 0;
            if (dgvVatProduct.Rows.Count > 0)
            {
                for (int index = 0; index < dgvVatProduct.Rows.Count; index++)
                {
                    intSL = intSL + 1;

                    intItem =int.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblvatItemid")).Text.ToString());
                    intM11Challanno =int.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblstrVATChallanNo")).Text.ToString());

                    strChallanNo = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVATChallanNo")).Text.ToString();
                    strM11DateChallan =DateTime.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lbldtedates")).Text.ToString());
                    strItem = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVatProductName")).Text.ToString();
                    numQty =decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblQuantity")).Text.ToString());
                    monValue = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsdvat")).Text.ToString());
                    monSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsd")).Text.ToString());
                    monSurCharge = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblSurCharge")).Text.ToString());
                    monVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblVAT")).Text.ToString());
                    monM11Other = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblM11txt")).Text.ToString());
                    monM11VAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblM11")).Text.ToString());
                    monNewSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecrateOthervat")).Text.ToString());
                    monNewVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblDecratevat")).Text.ToString());

                    string msg=objMush.getCreditnoteCreate(intM12No, intCustid,strCusName,strCusAddress,strCusVatReg,strVehicleTypeNo,intItem,intSL,intM11Challanno,strM11DateChallan,strItem,numQty,monValue,monSD,monVAT,monM11Other,monM11VAT,monNewSD,monNewVAT,strReason,int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.UNIT_ID].ToString()), intYear, monSurCharge);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                }
                dgvVatProduct.DataBind();
            }
        }
        
        protected double TotalValue = 0;
        protected void dgvTresuryRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
        protected void dgvPurchaseEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                xmlString = dSftTm.InnerXml;
                xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvVatProduct.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvVatProduct.DataSource;
                dsGrid.Tables[0].Rows[dgvVatProduct.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvVatProduct.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvVatProduct.DataSource = ""; dgvVatProduct.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getVatItemList(prefixText, accid);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchMatrial(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] SupplierSearch(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSupplierList(prefixText, unitid);
        }

        #endregion * ********** End search **********

    }
}
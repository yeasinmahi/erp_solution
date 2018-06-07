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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            intitemid =int.Parse(hdnitemid.Value.ToString());
            strChallanNo = ddlChallanNo.SelectedValue.ToString();
            Pname= ddlChallanNo.SelectedItem.ToString();
            dtedate = DateTime.Parse(lblChallanDate.Text);
            string creditqty = txtCreditqty.Text;
            string sdnew = txtSD.Text;
            string othersdNew = txtWithoutSDVAT.Text;
            string sur = txtSurcharge.Text;
            string vatnew = txtVAT.Text;
            string m11vat = lblM11Vat.Text;
            string others = lblM11OthersTax.Text;
           

           // CreateVoucherXml(intitemid, strChallanNo, dtedate, Pname, demdate, dono, dodate, recdate, recqty);

        }
        private void CreateVoucherXml(string brid, string brname, string demno, string demdate, string dono, string dodate, string recdate, string recqty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, brid, brname, demno, demdate, dono, dodate, recdate, recqty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, brid, brname, demno, demdate, dono, dodate, recdate, recqty);
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
        private XmlNode CreateItemNode(XmlDocument doc, string brid, string brname, string demno, string demdate, string dono, string dodate, string recdate, string recqty)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Brid = doc.CreateAttribute("brid"); Brid.Value = brid;
            XmlAttribute Brname = doc.CreateAttribute("brname"); Brname.Value = brname;
            XmlAttribute Demno = doc.CreateAttribute("demno"); Demno.Value = demno;
            XmlAttribute Demdate = doc.CreateAttribute("demdate"); Demdate.Value = demdate;
            XmlAttribute Dono = doc.CreateAttribute("dono"); Dono.Value = dono;
            XmlAttribute Dodate = doc.CreateAttribute("dodate"); Dodate.Value = dodate;
            XmlAttribute Recdate = doc.CreateAttribute("recdate"); Recdate.Value = recdate;
            XmlAttribute Recqty = doc.CreateAttribute("recqty"); Recqty.Value = recqty;

            node.Attributes.Append(Brid);
            node.Attributes.Append(Brname);
            node.Attributes.Append(Demno);
            node.Attributes.Append(Demdate);
            node.Attributes.Append(Dono);
            node.Attributes.Append(Dodate);
            node.Attributes.Append(Recdate);
            node.Attributes.Append(Recqty);
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

            dt = objCreditBll.GETCreditlist(ddlChallanNo.SelectedValue.ToString(), int.Parse(Session[SessionParams.USER_ID].ToString()),int.Parse(hdnAccno.Value));
            
            lblCustVatRegno.Text = dt.Rows[0]["strCustVATRegNo"].ToString();
            lblChallanDate.Text = dt.Rows[0]["ysnFactory"].ToString();

            dt = objCreditBll.getChallanInfo(ddlChallanNo.SelectedValue.ToString(), int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(hdnAccno.Value), intitemid);
            lblProductQty.Text = dt.Rows[0]["numQuantity"].ToString();
            lblM11OthersTax.Text = dt.Rows[0]["OthersSDVAT"].ToString();
            lblChallanDate.Text = dt.Rows[0]["dteSellingDate"].ToString();
            lblM11Vat.Text= dt.Rows[0]["monVAT"].ToString();

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
            dt = objCreditBll.getCreditchallan(int.Parse(Session[SessionParams.USER_ID].ToString()),int.Parse(hdnAccno.Value),intitemid);
            ddlChallanNo.DataTextField = "strVATChallanNo";
            ddlChallanNo.DataValueField = "strVATChallanNo";
            ddlChallanNo.DataSource = dt;
            ddlChallanNo.DataBind();


        }

        protected void btnShowREPORT_Click(object sender, EventArgs e)
        {
           // //strChallanNo = txtVatChallno.Text;
           //// intyear = int.Parse(txtYear.Text);

           // dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), 1);
           // hdnCustid.Value = dt.Rows[0]["intCusID"].ToString();
           // //hdnCustname.Value = dt.Rows[0]["strCustName"].ToString();
           //// hdnCustname.Value = dt.Rows[0]["strCustAddress"].ToString();
           // txtCustomerVatReg.Text = dt.Rows[0]["strCustVATRegNo"].ToString();
           // dt.Clear();
           // dt = objMush.getVatChallano(intyear, strChallanNo, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), 2);
           // dgvVatProduct.DataSource = dt;
           // dgvVatProduct.DataBind();

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           // intM11Challanno =int.Parse(txtVatChallno.Text);
            intCustid = int.Parse(hdnCustid.Value);
           // strCusName= hdnCustname.Value;
            strCusAddress = hdnCustAddress.Value;
          //  strVehicleTypeNo = txtVehicletypeno.Text;
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
                    strChallanNo = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVATChallanNo")).Text.ToString();
                    strM11DateChallan =DateTime.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lbldtedate")).Text.ToString());
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
            }
        }
        
        protected double TotalValue = 0;
        protected void dgvTresuryRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[6].FindControl("lblmonAmount")).Text == "")
                {
                    TotalValue += 0;
                }
                else
                {
                    TotalValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblmonAmount")).Text);
                }
               
            }

        }
        protected void btnDelete(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                intid = int.Parse(searchKey[0].ToString());
                dt = objMush.getTreasuryYear(intid);
                intyear = int.Parse(dt.Rows[0]["intYear"].ToString());
                intMonth = int.Parse(dt.Rows[0]["intMonth"].ToString());
                dt = objMush.getTreasuryCount(int.Parse(hdnAccno.Value),intyear,intMonth);
                if (int.Parse(dt.Rows[0]["intCount"].ToString()) == 0)
                {
                    objMush.gepPurchasedelete(int.Parse(hdnAccno.Value), intid, 3);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Mushak-19 for this purchase already created. Therefore, delete is not possible!');", true);
                }



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
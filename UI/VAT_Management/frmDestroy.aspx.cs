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
    public partial class frmDestroy : BasePage
    {
        string filePathForXML,MaterialName,Pname, xmlString = "",strChallanNo, ItemName, strReason, strItem, strVehicleTypeNo, strCusName, strCusAddress, strCusVatReg, intVATTime;
        int intItem, intitemid, intYear, intM12No,intCustid, intid,intyear,intMonth, intSL;
        VAT_BLL objvat = new VAT_BLL();
        string[] arrayKeyItem;
        CreditNoteBLL objCreditBll = new CreditNoteBLL();
        DataTable dt;
        decimal numQty, monValue, monSD, monVAT;

        DateTime dtedate;
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
        protected void ddlChallanNo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            getChallaninfo();
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

        protected void txtCreditqty_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(hdnperVat.Value) == 0)
            {
                txtVAT.Text = "0";
            }
            else 
                {
                    txtVAT.Text = (decimal.Parse(lblMaterialUserStandard.Text) * decimal.Parse(txtCreditqty.Text)).ToString();
                }
            
        }

        private void getChallaninfo()
        {
            dt = objCreditBll.getChallanProductqty(ddlChallanNo.SelectedItem.ToString(),int.Parse(ddlMaterialList.SelectedValue.ToString()));
            lblQty.Text= dt.Rows[0]["numQuantity"].ToString();
            lblVat.Text = dt.Rows[0]["monVAT"].ToString();
            lblSD.Text = dt.Rows[0]["monSD"].ToString();
            decimal vat = decimal.Parse(dt.Rows[0]["numQuantity"].ToString());
            if(vat>1)
            {
                vat = decimal.Parse(dt.Rows[0]["numQuantity"].ToString());
            }
            else
            {
                vat = 1;
            }
            decimal qty = decimal.Parse(dt.Rows[0]["numQuantity"].ToString());
            if (qty != 0)
            {
                qty = decimal.Parse(dt.Rows[0]["numQuantity"].ToString());
            }
            else
            {
                qty = 1;
            }

            hdnperVat.Value=(vat / qty).ToString();

        }

        protected void ddlMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMatrialUserStandar();
        }

        private void getMatrialUserStandar()
        {
            dt = objCreditBll.getuseStandard( int.Parse(ddlMaterialList.SelectedValue), int.Parse(hdnitemid.Value));
            lblMaterialUserStandard.Text = dt.Rows[0]["numQty"].ToString();
            dt = objCreditBll.getPurChallanList(int.Parse(ddlMaterialList.SelectedValue), int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session["VatAccid"].ToString()));

            ddlChallanNo.DataTextField = "strChallanNo";
            ddlChallanNo.DataValueField = "strChallanNo";
            ddlChallanNo.DataSource = dt;
            ddlChallanNo.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            intitemid =int.Parse(ddlMaterialList.SelectedValue.ToString());
            MaterialName = (ddlMaterialList.SelectedItem.ToString());
            strChallanNo = ddlChallanNo.SelectedValue.ToString();
            Pname= ddlChallanNo.SelectedItem.ToString();
            string values = "0";
            string qty = txtCreditqty.Text;
            string sdnew = "0";
            string vatnew =(decimal.Parse(txtCreditqty.Text)*decimal.Parse(hdnperVat.Value)).ToString();
            

            CreateVoucherXml(intitemid.ToString(), MaterialName,qty, values,sdnew,vatnew);
            txtCreditqty.Text = "";
            txtSD.Text = "";
            txtVAT.Text = "";
            txtSDCharableValue.Text = "";
        }
        private void CreateVoucherXml(string mid, string MaterialName, string qty, string values, string sdnew, string vatnew)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, MaterialName, qty, values, sdnew, vatnew);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, MaterialName, qty, values, sdnew, vatnew);
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
        private XmlNode CreateItemNode(XmlDocument doc, string mid, string MaterialName, string qty, string values, string sdnew, string vatnew)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Mid = doc.CreateAttribute("mid"); Mid.Value = mid;
            XmlAttribute materialName = doc.CreateAttribute("MaterialName"); materialName.Value = MaterialName;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Values = doc.CreateAttribute("values"); Values.Value = values;
            XmlAttribute Sdnew = doc.CreateAttribute("sdnew"); Sdnew.Value = sdnew;
            XmlAttribute Vatnew = doc.CreateAttribute("vatnew"); Vatnew.Value = vatnew;
     
            node.Attributes.Append(Mid);
            node.Attributes.Append(materialName);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Values);
            node.Attributes.Append(Sdnew);
            node.Attributes.Append(Vatnew);
          
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
               
            }
            catch { }
        }
        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
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
            dt = objCreditBll.getMatrialList(intitemid,1,DateTime.Now);
            ddlMaterialList.DataTextField = "strMaterialName";
            ddlMaterialList.DataValueField = "intvatMaterialID";
            ddlMaterialList.DataSource = dt;
            ddlMaterialList.DataBind();

            getMatrialUserStandar();
        }

       

        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
     
            intCustid = int.Parse(hdnAccno.Value);
            strCusAddress = hdnCustAddress.Value;
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

                    intItem =int.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblMatrialid")).Text.ToString());
                    strItem = ((Label)dgvVatProduct.Rows[index].FindControl("lblstrVatProductName")).Text.ToString();
                    numQty =decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblQuantity")).Text.ToString());
                    monValue = 0;
                    monSD = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblsd")).Text.ToString());
                    monVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblVAT")).Text.ToString());
                    string remarks;
                    if (txtRemarks.Text == "")
                    {
                        remarks = "";
                    }
                    else { remarks = txtRemarks.Text; }

                    string  msg = objMush.getDestroy(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), hdnysnFactory.Value, int.Parse(Session[SessionParams.USER_ID].ToString()), intItem, strItem, numQty, monValue, monSD, monVAT, remarks, 2);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    txtRemarks.Text = "";
                }
            }
            dgvVatProduct.DataBind();
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
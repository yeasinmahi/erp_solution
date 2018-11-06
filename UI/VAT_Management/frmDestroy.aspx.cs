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
        protected void dgvVatProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvVatProduct.DataSource;
                dsGrid.Tables[0].Rows[dgvVatProduct.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvVatProduct.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvVatProduct.DataSource = ""; dgvVatProduct.DataBind(); }
                else { LoadGridwithXml(); }
               
               
             
            }

            catch { }
        }

        protected void txtCreditqty_TextChanged(object sender, EventArgs e)
        {
            if ((hdnperVat.Value != ""))
            {
                if (decimal.Parse(hdnperVat.Value) == 0)
                {
                    txtNuse.Text = "0";
                }
                else
                {
                    txtNuse.Text = (decimal.Parse(lblMaterialUserStandard.Text) * decimal.Parse(txtCreditqty.Text)).ToString();
                }
                if (lblVat.Text.ToString() == "0")
                {

                }
                txtNuse.Text = (decimal.Parse(txtCreditqty.Text) * decimal.Parse(lblMaterialUserStandard.Text)).ToString();
            }
        }

        private void getChallaninfo()
        {
            dt = objCreditBll.getChallanProductqty(ddlChallanNo.SelectedItem.ToString(),int.Parse(ddlMaterialList.SelectedValue.ToString()));
            lblQty.Text= dt.Rows[0]["numQuantity"].ToString();
            lblVat.Text = dt.Rows[0]["monVAT"].ToString();
            lblSD.Text = dt.Rows[0]["monSD"].ToString();
            hdndtechallandate.Value= dt.Rows[0]["dteChallanDate"].ToString();
            DateTime dtedate= DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
            lblChallandate.Text = DateTime.Parse(dtedate.ToString("yyyy-MM-dd")).ToString();
            decimal vat = decimal.Parse(dt.Rows[0]["monVAT"].ToString());
            if(vat>1)
            {
                vat = decimal.Parse(dt.Rows[0]["monVAT"].ToString());
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
            if (vat == 0)
            {
                hdnperVat.Value = 0.ToString();
            }
            else
            {
                hdnperVat.Value = (vat / decimal.Parse(lblQty.Text)).ToString();
            }

        }
        protected decimal totalrbit = 0;
        protected decimal totalvalue = 0, totalvat = 0, totalsdv=0, totalIssuevalue = 0;
        protected void dgvSOItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalrbit += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblpervat")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                    totalIssuevalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("txtIssueValues")).Text);
                    totalvat += decimal.Parse(((Label)e.Row.Cells[6].FindControl("totalvat")).Text);
                    totalsdv += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblsdv")).Text);
                }
            }
            catch { }
        }

        protected void ddlMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMatrialUserStandar();
            getChallaninfo();
        }

        private void getMatrialUserStandar()
        {
            dt = objCreditBll.getuseStandard( int.Parse(ddlMaterialList.SelectedValue), int.Parse(hdnitemid.Value));
            lblMaterialUserStandard.Text = dt.Rows[0]["numQty"].ToString();
            hdnuom.Value = dt.Rows[0]["struom"].ToString();
            dt = objCreditBll.getPurChallanList(int.Parse(ddlMaterialList.SelectedValue), int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session["VatAccid"].ToString()));

            ddlChallanNo.DataTextField = "strChallanNo";
            ddlChallanNo.DataValueField = "strChallanNo";
            ddlChallanNo.DataSource = dt;
            ddlChallanNo.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value.ToString() != "0")
            {
                intitemid = int.Parse(ddlMaterialList.SelectedValue.ToString());
                MaterialName = (ddlMaterialList.SelectedItem.ToString());
                strChallanNo = ddlChallanNo.SelectedValue.ToString();
                Pname = ddlChallanNo.SelectedItem.ToString();
                txtNewVat.Text =Math.Round((decimal.Parse(txtCreditqty.Text) * decimal.Parse(hdnperVat.Value)),2).ToString();
                string values = "0";
                string qty = txtCreditqty.Text;
                string pervat;
                string sdnew = "0", sdv = "0";
                if (txtSD.Text != "") { sdnew = txtSDCharableValue.Text.ToString(); }
                if (txtSDCharableValue.Text != "") { sdv = txtSDCharableValue.Text.ToString(); }
                string vatnew = (decimal.Parse(txtCreditqty.Text) * decimal.Parse(hdnperVat.Value)).ToString();
                string rbit = (decimal.Parse(txtCreditqty.Text) * decimal.Parse(hdnperVat.Value.ToString())).ToString();
                decimal f = Math.Round(decimal.Parse(qty), 2);
                CreateVoucherXml(intitemid.ToString(), MaterialName, qty, values, sdnew, Math.Round(decimal.Parse(txtNuse.Text.ToString()), 2).ToString(), ddlChallanNo.SelectedItem.ToString(), lblChallandate.Text.ToString(), lblMaterialUserStandard.Text.ToString(), lblQty.Text.ToString(), sdv.ToString(), Math.Round(decimal.Parse(hdnperVat.Value.ToString()), 2).ToString(), Math.Round(decimal.Parse(rbit.ToString()), 2).ToString(), hdnuom.Value.ToString(), Math.Round(decimal.Parse(vatnew.ToString()), 2).ToString());
                txtCreditqty.Text = "";
                txtSD.Text = "";
                txtNuse.Text = "";
                txtSDCharableValue.Text = "";
                txtCreditqty.Text = "";
            }


        }
        private void CreateVoucherXml(string mid, string MaterialName, string qty, string values, string sdnew, string totaluse,string challanno,string dteCdate,string usepar,string pqty,string sdv, string pervat,string rbit,string uom,string totalvat)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, MaterialName, qty, values, sdnew, totaluse, challanno, dteCdate, usepar, pqty,sdv, pervat, rbit,uom, totalvat);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, MaterialName, qty, values, sdnew, totaluse, challanno, dteCdate, usepar, pqty,sdv, pervat, rbit,uom, totalvat);
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
        private XmlNode CreateItemNode(XmlDocument doc, string mid, string MaterialName, string qty, string values, string sdnew, string totaluse, string challanno,string dteCdate,string usepar, string pqty,string sdv, string pervat,string rbit,string uom,string totalvat)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Mid = doc.CreateAttribute("mid"); Mid.Value = mid;
            XmlAttribute materialName = doc.CreateAttribute("MaterialName"); materialName.Value = MaterialName;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Values = doc.CreateAttribute("values"); Values.Value = values;
            XmlAttribute Sdnew = doc.CreateAttribute("sdnew"); Sdnew.Value = sdnew;
            XmlAttribute Totaluse = doc.CreateAttribute("totaluse"); Totaluse.Value = totaluse;
            XmlAttribute Challanno = doc.CreateAttribute("challanno"); Challanno.Value = challanno;
            XmlAttribute DteCdate = doc.CreateAttribute("dteCdate"); DteCdate.Value = dteCdate;
            XmlAttribute Pervat = doc.CreateAttribute("pervat"); Pervat.Value = pervat;
            XmlAttribute Useper = doc.CreateAttribute("usepar"); Useper.Value = usepar;
            XmlAttribute Pqty = doc.CreateAttribute("pqty"); Pqty.Value = pqty;
            XmlAttribute Sdv = doc.CreateAttribute("sdv"); Sdv.Value = sdv;
            XmlAttribute Rbit = doc.CreateAttribute("rbit"); Rbit.Value = rbit;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom; 
            XmlAttribute Totalvat = doc.CreateAttribute("totalvat"); Totalvat.Value = totalvat; 
            node.Attributes.Append(Mid);
            node.Attributes.Append(materialName);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Values);
            node.Attributes.Append(Sdnew);
            node.Attributes.Append(Totaluse);
            node.Attributes.Append(Challanno);
            node.Attributes.Append(DteCdate);
            node.Attributes.Append(Useper);
            node.Attributes.Append(Pqty);
            node.Attributes.Append(Sdv);
            node.Attributes.Append(Pervat);
            node.Attributes.Append(Rbit);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Totalvat);
            return node;
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
                    monVAT = decimal.Parse(((Label)dgvVatProduct.Rows[index].FindControl("lblTvat")).Text.ToString());
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
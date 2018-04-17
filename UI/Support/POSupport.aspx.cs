using Support_BLL;
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
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
namespace UI.Support
{
    public partial class POSupport : BasePage
    {
        PO_Currection_BLL obj = new PO_Currection_BLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        int intUnitID;

        string intemid; string itemname; string specification; string uom; string qty; string rate; string vat;
        string ait; string total; string ysnExisting; string message,potype;

        int intPOID; int intSuppid; DateTime dtePODate; int intCurrencyID; int intMRRID; decimal monFreight; decimal monPacking;
        decimal monDiscount; int intShipment; string strDeliveryAddress; int ysnPartialShip; string strPayTerm; int intCreditDays; 
        int intInstallmentNo; int intInstallmentInterval; int intWarrantyMonth,updateby; string strOtherTerms; DateTime dteLastShipmentDate;

        decimal numPOQty; int intItemID; string strSpecification; decimal monRate; decimal monVAT; decimal monAmount;

        string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/Support/Data/ItemInfoByPO_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML); dgvItemInfoByPO.DataSource = ""; dgvItemInfoByPO.DataBind();

                    dt = obj.GetCurrency();
                    ddlCurrency.DataTextField = "strCurrencyName";
                    ddlCurrency.DataValueField = "intCurrencyID";
                    ddlCurrency.DataSource = dt;
                    ddlCurrency.DataBind();
                }
                catch { }
                divItemInfo.Visible = false;
                HttpContext.Current.Session["Unitid"] = "0";
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetItemInfoByPO();
        }
        private void GetItemInfoByPO()
        {
            try { intPOID = int.Parse(txtPONo.Text); }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Number');", true); return; }

            //*** Get MRR No 
            try
            {
                dt = new DataTable();
                dt = obj.GetMRRNoByPO(intPOID);
                if (dt.Rows.Count > 0) { lblMRRNo.Text = dt.Rows[0]["intMRRID"].ToString();
                   

                }
                else { lblMRRNo.Text = ""; }
            }
            catch { lblMRRNo.Text = ""; }
            //*******
            try
            {
                dt = new DataTable();
                dt = obj.GetProviderListByPO(intPOID);
                if (dt.Rows.Count > 0)
                {
                    //dt = new DataTable();
                    //dt = obj.GetProviderListByUnit(intUnitID);"intSupplierID "dt.Rows[0]["strSupplierName"].ToString();dt.Rows[0]["intSupplierID"].ToString();
                    drdlsupplierbaseonunit.DataSource = dt;
                    drdlsupplierbaseonunit.DataTextField = "strSupplierName";
                    drdlsupplierbaseonunit.DataValueField = "intSupplierID";
                    drdlsupplierbaseonunit.DataBind();


                }
                else {  }
            }
            catch {  }




            //*** Get Unit & Supplier Type
            try
            {


                dt = new DataTable();
                dt = obj.GetSupplierInfoByPO(intPOID);
                if (dt.Rows.Count > 0)
                {
                    ddlCurrency.SelectedValue = dt.Rows[0]["intCurrencyID"].ToString();
                    txtPODate.Text = dt.Rows[0]["dtePODate"].ToString();
                    hdnPOUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    HttpContext.Current.Session["Unitid"] = dt.Rows[0]["intUnitID"].ToString();
                    txtSupplierList.Text = dt.Rows[0]["strSupplierName"].ToString() + " [" + dt.Rows[0]["intSupplierID"].ToString() + "]";
                    lblPOTypevalue.Text = dt.Rows[0]["strPoFor"].ToString();
                    intUnitID = int.Parse(hdnPOUnit.Value.ToString());
                    
                    //btnIndentShow.Enabled = true;                    
                }
                

            }
            catch
            {
                txtPODate.Text = "";
                ddlCurrency.SelectedValue = "1";
                txtSupplierList.Text = "";
            }

            //*** Get Others Terms
            try
            {
                dt = new DataTable();
                dt = obj.GetShipmentAndOtherInfoByPO(intPOID);
                if (dt.Rows.Count > 0)
                {
                    divItemInfo.Visible = true;

                    ddlPartialShipment.SelectedValue = dt.Rows[0]["ysnPartialShip"].ToString();
                    txtNoofShipment.Text = dt.Rows[0]["intShipment"].ToString();
                    txtLastShipmentDate.Text = dt.Rows[0]["dteLastShipmentDate"].ToString();
                    ddlPaymentTerms.Text = dt.Rows[0]["strPayTerm"].ToString();
                    txtPaymentdaysAfterMRR.Text = dt.Rows[0]["intCreditDays"].ToString();
                    txtNoOfInstallment.Text = dt.Rows[0]["intInstallmentNo"].ToString();
                    txtInstallmentIntervalDays.Text = dt.Rows[0]["intInstallmentInterval"].ToString();
                    txtDestinationForDelivery.Text = dt.Rows[0]["strDeliveryAddress"].ToString();
                    txtWarrentyAfterDelivery.Text = dt.Rows[0]["intWarrantyMonth"].ToString();
                    txtOtherTerms.Text = dt.Rows[0]["strOtherTerms"].ToString();
                    txtTransport.Text = dt.Rows[0]["monFreight"].ToString();
                    txtGDiscount.Text = dt.Rows[0]["monDiscount"].ToString();
                    txtOthers.Text = dt.Rows[0]["monPacking"].ToString();
                }
            }
            catch
            {
                divItemInfo.Visible = false;
                ddlPartialShipment.SelectedValue = "";
                txtNoofShipment.Text = "";
                txtLastShipmentDate.Text = "";
                ddlPaymentTerms.Text = "";
                txtPaymentdaysAfterMRR.Text = "";
                txtNoOfInstallment.Text = "";
                txtInstallmentIntervalDays.Text = "";
                txtDestinationForDelivery.Text = "";
                txtWarrentyAfterDelivery.Text = "";
                txtOtherTerms.Text = "";
            }

            //*** Get Other Terms
            dt = new DataTable();
            dt = obj.GetItemInfoByPO(intPOID);
            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    intemid = dt.Rows[index]["intItemID"].ToString();
                    itemname = dt.Rows[index]["strITemName"].ToString();
                    specification = dt.Rows[index]["strSpecification"].ToString();
                    uom = dt.Rows[index]["strUoM"].ToString();
                    qty = dt.Rows[index]["numQty"].ToString();
                    rate = dt.Rows[index]["monRate"].ToString();
                    vat = dt.Rows[index]["monVAT"].ToString();
                    ait = dt.Rows[index]["monAIT"].ToString();
                    total = dt.Rows[index]["monTotal"].ToString();
                    ysnExisting = dt.Rows[index]["ysnExisting"].ToString();

                    //grandtotal = 0;
                    //grandtotaldtfare = 0;
                    //totaldieselcredit = 0;
                    //totalcngcredit = 0;
                    File.Delete(filePathForXML); dgvItemInfoByPO.DataSource = ""; dgvItemInfoByPO.DataBind();
                    CreateVoucherXml(intemid, itemname, specification, uom, qty, rate, vat, ait, total, ysnExisting);

                    //txtDieselCredit.Text = "";
                    //txtCNGCredit.Text = "";
                }
            }
        }
        private void CreateVoucherXml(string intemid, string itemname, string specification, string uom, string qty, string rate, string vat, string ait, string total, string ysnExisting)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("FDetails");
                XmlNode addItem = CreateItemNode(doc, intemid, itemname, specification, uom, qty, rate, vat, ait, total, ysnExisting);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FDetails");
                XmlNode addItem = CreateItemNode(doc, intemid, itemname, specification, uom, qty, rate, vat, ait, total, ysnExisting);
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
            if (ds.Tables[0].Rows.Count > 0) { dgvItemInfoByPO.DataSource = ds; }
            else { dgvItemInfoByPO.DataSource = ""; } dgvItemInfoByPO.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intemid, string itemname, string specification, string uom, string qty, string rate, string vat, string ait, string total, string ysnExisting)
        {
            XmlNode node = doc.CreateElement("FDetails");

            XmlAttribute Intemid = doc.CreateAttribute("intemid"); Intemid.Value = intemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Specification = doc.CreateAttribute("specification"); Specification.Value = specification;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Vat = doc.CreateAttribute("vat"); Vat.Value = vat;
            XmlAttribute Ait = doc.CreateAttribute("ait"); Ait.Value = ait;
            XmlAttribute Total = doc.CreateAttribute("total"); Total.Value = total;
            XmlAttribute YsnExisting = doc.CreateAttribute("ysnExisting"); YsnExisting.Value = ysnExisting;

            node.Attributes.Append(Intemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Specification);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Vat);
            node.Attributes.Append(Ait);
            node.Attributes.Append(Total);
            node.Attributes.Append(YsnExisting);
            return node;
        }
        protected decimal totalqty = 0;
        protected decimal totalval = 0;
        protected decimal totalait = 0;
        protected decimal totalvat = 0;
        protected void dgvItemInfoByPO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalqty += decimal.Parse(((TextBox)e.Row.Cells[6].FindControl("txtQty")).Text);
                totalvat += decimal.Parse(((TextBox)e.Row.Cells[8].FindControl("txtVAT")).Text);
                totalait += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblAIT")).Text);
                totalval += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblTotalVal")).Text);
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierList(string prefixText, int count)
        {
            string intUnit = HttpContext.Current.Session["Unitid"].ToString();
            PO_Currection_BLL objSerch = new PO_Currection_BLL();
            return objSerch.GetSuppList(intUnit, prefixText);            
        }
        protected void txtSupplierList_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSupplierList.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                //intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { }
        }

        protected void drdlsupplierbaseonunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSupplierList.Text = "";
            txtSupplierList.Text = drdlsupplierbaseonunit.SelectedItem.Text.ToString();
        }

        protected void dgvItemInfoByPO_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{
                try
                {
                updateby = int.Parse(Session[SessionParams.USER_ID].ToString());
                try { intPOID = int.Parse(txtPONo.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Number');", true); return; }

                    try { intMRRID = int.Parse(lblMRRNo.Text); }
                    catch { intMRRID = 0; }

                    if (intMRRID == 0)
                    {                        
                        intItemID = int.Parse(((Label)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("lblItemID")).Text.ToString());
                        strSpecification = ((TextBox)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("txtSpecification")).Text.ToString();

                        try { numPOQty = decimal.Parse(((TextBox)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("txtQty")).Text.ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Quantity.');", true); return; }

                        try { monRate = decimal.Parse(((TextBox)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("txtRate")).Text.ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Rate.');", true); return; }

                        try { monVAT = decimal.Parse(((TextBox)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("txtVAT")).Text.ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong VAT Amount.');", true); return; }

                        try { monAmount = decimal.Parse(((Label)dgvItemInfoByPO.Rows[e.RowIndex].FindControl("lblAIT")).Text.ToString()); }
                        catch { monAmount = 0; }

                        //Final Insert
                        string message = obj.UpdateItemInfoByPONew(intPOID, numPOQty, intItemID, strSpecification, monRate, monVAT, monAmount, updateby);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO correction is not possible after issuing MRR.');", true); }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    try { intPOID = int.Parse(txtPONo.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Number');", true); return; }
                    
                    try { intMRRID = int.Parse(lblMRRNo.Text); }
                    catch { intMRRID = 0; }

                    if (intMRRID == 0)
                    {
                        //'PO correction is not possible after issuing MRR' 
                                                
                        char[] ch1 = { '[', ']' };
                        string[] temp1 = txtSupplierList.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                        try { intSuppid = int.Parse(temp1[1].ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Supplier Name & ID');", true); return; }

                        try { dtePODate = DateTime.Parse(txtPODate.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Date Format.');", true); return; }

                        try { intCurrencyID = int.Parse(ddlCurrency.SelectedValue.ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Currency.');", true); return; }

                        try { monFreight = decimal.Parse(txtTransport.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Freight Amount.');", true); return; }

                        try { monPacking = decimal.Parse(txtOthers.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Packing Amount.');", true); return; }

                        try { monDiscount = decimal.Parse(txtGDiscount.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Discount Amount.');", true); return; }

                        try { intShipment = int.Parse(txtNoofShipment.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong No of Shipment.');", true); return; }

                        try { intCreditDays = int.Parse(txtPaymentdaysAfterMRR.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Payment days after MRR (days)');", true); return; }

                        strDeliveryAddress = txtDestinationForDelivery.Text;
                        ysnPartialShip = int.Parse(ddlPartialShipment.SelectedValue.ToString());
                        strPayTerm = ddlPaymentTerms.SelectedItem.ToString();

                        try { intInstallmentNo = int.Parse(txtNoOfInstallment.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong No of Installment (for installment Payment)');", true); return; }

                        try { intInstallmentInterval = int.Parse(txtInstallmentIntervalDays.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Installment Interval (Days, for installment)');", true); return; }

                        try { intWarrantyMonth = int.Parse(txtWarrentyAfterDelivery.Text); }
                        catch { intWarrantyMonth = 0; } //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Warrenty after delivery (in months)');", true); return; }

                        try { dteLastShipmentDate = DateTime.Parse(txtLastShipmentDate.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Last Shipment Date;", true); return; }

                        strOtherTerms = txtOtherTerms.Text;
                        strOtherTerms = "N/A";
                        potype = lblPOType.Text.ToString();
                        updateby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        //updateby = int.Parse("1274");
                        //Final Insert
                        message = obj.UpdatePO(intPOID, intSuppid, dtePODate, intCurrencyID, intMRRID, monFreight, monPacking, monDiscount, intShipment, strDeliveryAddress, ysnPartialShip, strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, dteLastShipmentDate, potype, updateby);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO correction is not possible after issuing MRR.');", true); }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true); }
            }

        }





















    }
}
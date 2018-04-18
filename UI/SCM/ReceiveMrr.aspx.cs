using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ReceiveMrr : System.Web.UI.Page
    {
        MrrReceive_BLL obj = new MrrReceive_BLL();
        DataTable dt = new DataTable();
        string xmlString = "",filePathForXML,strMssingCost, challanNo, strVatChallan,poIssueBy;
        int intWh, enroll, intPo, intShipment, intPOID, intSupplierID, intUnitID;
        decimal monConverRate, monVatAmount, monProductCost, monOther, monDiscount, monBDTConversion, monRate; 
        DateTime dteChallan; 
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Mr__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                ddlInvoice.Enabled = false;
                DefaltBind();
            }
            else
            {
            }
        }

        protected void ddlPoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string poType = ddlPoType.SelectedItem.ToString();
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>".ToString();
                dt = obj.DataView(3, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPo.DataSource = dt;
                ddlPo.DataTextField = "strName";
                ddlPo.DataValueField = "Id";
                ddlPo.DataBind();
                DataClear();



            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string poType = ddlPoType.SelectedItem.ToString();
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>".ToString();
                dt = obj.DataView(3, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPo.DataSource = dt;
                ddlPo.DataTextField = "strName";
                ddlPo.DataValueField = "Id";
                ddlPo.DataBind();
                DataClear();

            }
            catch { }
        }

        protected void btnSaveMrr_Click(object sender, EventArgs e)
        {
            try
            {  try { File.Delete(filePathForXML);  } catch { }
               
                if (dgvMrr.Rows.Count > 0 && hdnConfirm.Value.ToString()=="1")
                {
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    try { intPOID = int.Parse(ddlPo.SelectedValue); } catch { }
                    try { intSupplierID = int.Parse(lblSuppliuerID.Text); } catch { }
                    try { intShipment = int.Parse(hdnShipment.Value); } catch { }
                    try { dteChallan = DateTime.Parse(txtdteChallan.Text.ToString()); } catch { }
                    try { monVatAmount = decimal.Parse(txtVatAmount.Text); } catch { }
                    try { challanNo = txtChallan.Text.ToString(); } catch { }
                    try { strVatChallan = txtVatChallan.Text.ToString(); } catch { }
                    try { monProductCost = decimal.Parse(lblProductCost.Text.ToString()); } catch { }
                    try { monOther = decimal.Parse(lblOtherCost.Text.ToString()); } catch { }
                    try { monDiscount = decimal.Parse(lblDiscount.Text.ToString()); } catch { }
                    try { monBDTConversion = decimal.Parse(hdnConversion.Value); } catch { }
                    poIssueBy = lblPoIssueBy.Text.ToString();
                    
                    for (int index = 0; index < dgvMrr.Rows.Count; index++)
                    { 
                        string intItemID = ((Label)dgvMrr.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string numPOQty = ((Label)dgvMrr.Rows[index].FindControl("lblPoQty")).Text.ToString();
                        string numPreRcvQty = ((Label)dgvMrr.Rows[index].FindControl("lblPreviousReceive")).Text.ToString();
                        string numRcvQty = ((TextBox)dgvMrr.Rows[index].FindControl("txtReceiveQty")).Text.ToString();
                        try { monRate = decimal.Parse(((Label)dgvMrr.Rows[index].FindControl("lblRate")).Text.ToString()); } catch { monRate = 0; }
                        string numRcvValue = (decimal.Parse(numPOQty.ToString()) * monRate).ToString();//((Label)dgvMrr.Rows[index].FindControl("lblMrrValue")).Text.ToString();
                        string numRcvVatValue = ((Label)dgvMrr.Rows[index].FindControl("lblVat")).Text.ToString(); 
                        string location = ((DropDownList)dgvMrr.Rows[index].FindControl("ddlStoreLocation")).SelectedValue.ToString();
                        string remarks = ((TextBox)dgvMrr.Rows[index].FindControl("txtRemarks")).Text.ToString(); 
                        string ysnQc = ((Label)dgvMrr.Rows[index].FindControl("lblYsnQc")).Text.ToString();
                        string numQcQty=((Label)dgvMrr.Rows[index].FindControl("lblQcPassedQty")).Text.ToString();
                      

                        if (decimal.Parse(numRcvQty)>0 && int.Parse(location)>0 && monRate>0)
                        {
                            //if (ysnQc.ToString() == "0")
                            //{
                            //    if (Double.Parse(numPreRcvQty) + Double.Parse(numRcvQty) > (Double.Parse(numPOQty)) * 1.1)
                            //    {
                            //        try { File.Delete(filePathForXML); } catch { }
                            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Maximum receive quantity must be Less or equal than 10% more than PO quantity.');", true);
                            //        break;
                            //    }
                            //}
                            //else
                            //{
                            //    if (Double.Parse(numPreRcvQty) + Double.Parse(numRcvQty) > (Double.Parse(numQcQty)) * 1.1)
                            //    {
                            //        try { File.Delete(filePathForXML); } catch { }
                            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Maximum receive quantity must be Less or equal than QC Passed quantity.');", true);
                            //        break;
                            //    }
                            //}


                            CreateXml(intPOID.ToString(), intSupplierID.ToString(), intShipment.ToString(), dteChallan.ToString(), monVatAmount.ToString(), challanNo, strVatChallan, monProductCost.ToString(), monOther.ToString(), monDiscount.ToString(), monBDTConversion.ToString(), intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate.ToString(), poIssueBy);
                        }
                       
                    
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("mrr");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<mrr>" + xmlString + "</mrr>";
                    try { File.Delete(filePathForXML); } catch { }
                    string msg = obj.MrrReceive(11, xmlString, intWh, intPOID, DateTime.Now, enroll);
                    
                    string[] searchKey = Regex.Split(msg, ":");
                    lblMrrNo.Text = searchKey[1].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    PoView();
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
        }

        private void CreateXml(string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks,string monRate,string poIssueBy)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
           
        }

        private XmlNode CreateItemNode(XmlDocument doc, string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks,string monRate,string poIssueBy)
        {
            XmlNode node = doc.CreateElement("mrrEntry");

            XmlAttribute IntPOID = doc.CreateAttribute("intPOID");
            IntPOID.Value = intPOID;
            XmlAttribute IntSupplierID = doc.CreateAttribute("intSupplierID");
            IntSupplierID.Value = intSupplierID;
            XmlAttribute IntShipment = doc.CreateAttribute("intShipment");
            IntShipment.Value = intShipment;
            XmlAttribute DteChallan = doc.CreateAttribute("dteChallan");
            DteChallan.Value = dteChallan;
            XmlAttribute MonVatAmount = doc.CreateAttribute("monVatAmount");
            MonVatAmount.Value = monVatAmount;
             
            XmlAttribute ChallanNo = doc.CreateAttribute("challanNo");
            ChallanNo.Value = challanNo; 
            XmlAttribute StrVatChallan = doc.CreateAttribute("strVatChallan");
            StrVatChallan.Value = strVatChallan;
            XmlAttribute MonProductCost = doc.CreateAttribute("monProductCost");
            MonProductCost.Value = monProductCost;
            XmlAttribute MonOther = doc.CreateAttribute("monOther");
            MonOther.Value = monOther;

            XmlAttribute MonDiscount = doc.CreateAttribute("monDiscount");
            MonDiscount.Value = monDiscount;
            XmlAttribute MonBDTConversion = doc.CreateAttribute("monBDTConversion");
            MonBDTConversion.Value = monBDTConversion;
            XmlAttribute IntItemID = doc.CreateAttribute("intItemID");
            IntItemID.Value = intItemID; 
            XmlAttribute NumPOQty = doc.CreateAttribute("numPOQty");
            NumPOQty.Value = numPOQty;

            XmlAttribute NumPreRcvQty = doc.CreateAttribute("numPreRcvQty");
            NumPreRcvQty.Value = numPreRcvQty;
            XmlAttribute NumRcvQty = doc.CreateAttribute("numRcvQty");
            NumRcvQty.Value = numRcvQty;
            XmlAttribute NumRcvValue = doc.CreateAttribute("numRcvValue");
            NumRcvValue.Value = numRcvValue;
            XmlAttribute NumRcvVatValue = doc.CreateAttribute("numRcvVatValue");
            NumRcvVatValue.Value = numRcvVatValue; 
            XmlAttribute Location = doc.CreateAttribute("location");
            Location.Value = location;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            XmlAttribute MonRate = doc.CreateAttribute("monRate");
            MonRate.Value = monRate;
            XmlAttribute PoIssueBy = doc.CreateAttribute("poIssueBy");
            PoIssueBy.Value = poIssueBy;
             


            node.Attributes.Append(IntPOID);
            node.Attributes.Append(IntSupplierID);
            node.Attributes.Append(IntShipment);
            node.Attributes.Append(DteChallan);

            node.Attributes.Append(MonVatAmount);
            node.Attributes.Append(ChallanNo);
            node.Attributes.Append(StrVatChallan);
            node.Attributes.Append(MonProductCost);
            node.Attributes.Append(MonOther);
            node.Attributes.Append(MonDiscount);
            node.Attributes.Append(MonBDTConversion);
            
            node.Attributes.Append(IntItemID);
            node.Attributes.Append(NumPOQty);
            node.Attributes.Append(NumPreRcvQty);
            node.Attributes.Append(NumRcvQty);
            node.Attributes.Append(NumRcvValue);

            node.Attributes.Append(NumRcvVatValue);
            node.Attributes.Append(Location);
            node.Attributes.Append(Remarks);

            node.Attributes.Append(MonRate);
            node.Attributes.Append(PoIssueBy);

            return node;
        }

        protected void ddlPo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataClear();
                string poType = ddlPoType.SelectedItem.ToString();
                intPo = int.Parse(ddlPo.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            
                if (poType == "Local")
                {
                   
                    ddlInvoice.Enabled = false;
                    ddlInvoice.DataSource = "";
                    ddlInvoice.DataBind();
                }
                else if (poType == "Import")
                {
                    ddlInvoice.Enabled = true; 
                    dt = obj.DataView(5, xmlString, intWh, intPo, DateTime.Now, enroll);
                    ddlInvoice.DataSource = dt;
                    ddlInvoice.DataTextField = "strName";
                    ddlInvoice.DataValueField = "Id";
                    ddlInvoice.DataBind();
                }

                
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
          
            PoView();
        }

        private void PoView()
        {
            try
            {
                intWh = int.Parse(ddlWH.SelectedValue);
                intPo = int.Parse(ddlPo.SelectedValue);
                try { intShipment = int.Parse(ddlInvoice.SelectedValue); hdnShipment.Value = intShipment.ToString(); } catch { intShipment = 0; hdnShipment.Value = "0".ToString(); }
                xmlString = "<voucher><voucherentry intShipment=" + '"' + intShipment + '"' + "/></voucher>".ToString();
                if (ddlInvoice.Enabled == true)
                {
                    dt = obj.DataView(6, xmlString, intWh, intPo, DateTime.Now, enroll);
                    strMssingCost = dt.Rows[0]["strMissingCost"].ToString();

                    if (strMssingCost != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["strMissingCost"].ToString() + "');", true);
                    }
                    else
                    {
                        dt = obj.DataView(7, xmlString, intWh, intPo, DateTime.Now, enroll);
                        lblSuppliuerID.Text = dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + dt.Rows[0]["strSupplierName"].ToString();
                        lblCurrency.Text = " Currency: " + dt.Rows[0]["strCurrencyName"].ToString();
                        lblConversion.Text = " Conversion: " + dt.Rows[0]["monBDTConversion"].ToString();
                        monConverRate = decimal.Parse(dt.Rows[0]["monBDTConversion"].ToString());
                        lblPoIssueBy.Text = dt.Rows[0]["strEmployeeName"].ToString();

                        dt = obj.DataView(8, xmlString, intWh, intPo, DateTime.Now, enroll);
                        lblPoTotal.Text = "";
                        lblProductCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monTotal"].ToString()) * monConverRate);
                        lblTransportCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monFreight"].ToString()) * monConverRate);
                        lblOtherCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monPacking"].ToString()) * monConverRate);
                        lblDiscount.Text = "0";
                    }

                }
                else
                {
                    dt = obj.DataView(4, xmlString, intWh, intPo, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblSuppliuerID.Text = dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + dt.Rows[0]["strSupplierName"].ToString();
                        //lblMrrNo.Text = dt.Rows[0][""].ToString();
                        // lblMrrDate.Text= dt.Rows[0][""].ToString();
                        lblPoTotal.Text = dt.Rows[0]["monPOTotalVAT"].ToString();
                        lblProductCost.Text = dt.Rows[0]["monPOAmount"].ToString();
                        lblTransportCost.Text = dt.Rows[0]["monOther"].ToString();
                        lblOtherCost.Text = dt.Rows[0]["monOther"].ToString();
                        lblDiscount.Text = dt.Rows[0]["monDiscount"].ToString();
                        lblCurrency.Text = "Currency: " + dt.Rows[0]["strCurrencyName"].ToString();
                        lblConversion.Text = "Conversion: " + dt.Rows[0]["monBDTConversion"].ToString();
                        hdnConversion.Value = dt.Rows[0]["monBDTConversion"].ToString();
                        lblPoIssueBy.Text = dt.Rows[0]["strEmployeeName"].ToString();

                    }

                }
                dt = obj.DataView(9, xmlString, intWh, intPo, DateTime.Now, enroll);
                dgvMrr.DataSource = dt;
                dgvMrr.DataBind();


            }
            catch { }
        }

        private void DefaltBind()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
               
                dt = obj.DataView(1, xmlString, intWh,0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                intWh = int.Parse(ddlWH.SelectedValue);
                dt = obj.DataView(2, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPoType.DataSource = dt;
                ddlPoType.DataTextField = "strName";
                ddlPoType.DataValueField = "Id";
                ddlPoType.DataBind();
            }
            catch { }
        }
        private void DataClear()
        {
            try
            {

                dgvMrr.DataSource = "";
                dgvMrr.DataBind();
                lblSuppliuerID.Text = "";
                lblSuppliyer.Text = ""; 
                lblPoTotal.Text = "";
                lblProductCost.Text ="";
                lblTransportCost.Text = "";
                lblOtherCost.Text = "";
                lblDiscount.Text = "";
                lblCurrency.Text = "";
                lblConversion.Text = "";

            }
            catch { }
        }
    }
}
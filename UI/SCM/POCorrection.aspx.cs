using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class POCorrection : BasePage
    {
        private PoGenerate_BLL obj = new PoGenerate_BLL();
        private DataTable dt;
        private int intPart, intPOID, intUnitID, intCurrencyID, intShipment, ysnPartialShip, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, intEnroll, intMRRID, intSuppid;
        private DateTime dtePODate, dteLastShipmentDate;
        private decimal monFreight, monPacking, monDiscount, monRate, monVAT, monAmount, monAIT, numPOQty;

        private string filePathForXML, xmlString = "", xml, strPo, intemid, itemname, specification, uom, qty, rate, vat, ait, total, ysnExisting, message, potype, ysnApprove, intSingleApproveBy, strDeliveryAddress, strPayTerm, strOtherTerms;
        private int intItemID; private string strSpecification, PoType;

        protected void Page_Load(object sender, EventArgs e)
        {
            //hdnUnit.Value = Session[SessionParams.Unitid].ToString();
            filePathForXML = Server.MapPath("~/SCM/Data/ItemInfoByPO_" + Enroll + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXML);

                GridViewUtil.UnLoadGridView(dgvItemInfoByPO);
                //dgvItemInfoByPO.DataSource = "";
                //dgvItemInfoByPO.DataBind();

                dt = obj.GetCurrency();
                Common.LoadDropDown(ddlCurrency, dt, "intCurrencyID", "strCurrencyName");

                btnUpdatePO.Visible = false;
                btnDeletePO.Visible = false;
            }
        }

        private bool CheckTextBox(TextBox textBox, string type)
        {
            string s = textBox.Text;
            string contolText;
            if (type.Equals("PO"))
            {
                contolText = "PO Id ";
            }
            else
            {
                contolText = "MRR Id ";
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                Toaster(contolText + Message.NotBlank.ToFriendlyString(), Common.TosterType.Warning);
                return false;
            }
            if (!int.TryParse(s, out intPOID))
            {
                Toaster("Input "+ contolText + "prperly", Common.TosterType.Warning);
                return false;
            }
            return true;
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Common.Clear(Controls);
            Common.UnLoadDropDown(ddlSupplier);
            if (!CheckTextBox(txtPONo, "PO"))
            {
                return;
            }
            
            dt = new DataTable();
            dt = obj.GetMRRNoByPO(intPOID);

            if (dt.Rows.Count > 0)
            {
                txtMrrNo.Text = dt.Rows[0]["intMRRID"].ToString();
            }
            else
            {
                txtMrrNo.Text = "";
            }
            dt = obj.GetSuppliers(intPOID);
            Common.LoadDropDown(ddlSupplier, dt, "intSupplierID", "strSupplierName");

            dt = new DataTable();
            dt = obj.GetSupplierInfoByPO(intPOID);
            if (dt.Rows.Count > 0)
            {
                ddlCurrency.SelectedValue = dt.Rows[0]["intCurrencyID"].ToString();
                txtPODate.Text = dt.Rows[0]["dtePODate"].ToString();
                hdnPOUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                HttpContext.Current.Session["Unitid"] = dt.Rows[0]["intUnitID"].ToString();
                txtPOType.Text = dt.Rows[0]["strPoFor"].ToString();
                PoType = dt.Rows[0]["strPoFor"].ToString();
                intUnitID = int.Parse(hdnPOUnit.Value.ToString());
                ddlSupplier.SelectedValue = dt.Rows[0]["intSupplierID"].ToString();
                txtWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
            }
            else
            {
                txtPODate.Text = "";
                ddlCurrency.SelectedValue = "1";
                txtPOType.Text = "";
                hdnPOUnit.Value = "0";
                HttpContext.Current.Session["Unitid"] = hdnPOUnit.Value;
            }

            try
            {
                dt = obj.GetShipmentAndOtherInfoByPO(intPOID);
                if (dt.Rows.Count > 0)
                {
                    ddlPartialShipment.SelectedValue = dt.Rows[0]["ysnPartialShip"].ToString();
                    txtNoofShipment.Text = dt.Rows[0]["intShipment"].ToString();
                    txtLastShipmentDate.Text = dt.Rows[0]["dteLastShipmentDate"].ToString();
                    ddlPaymentTerms.SelectedItem.Text = dt.Rows[0]["strPayTerm"].ToString();
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
                else
                {
                    //txtNoofShipment.Text = string.Empty;
                    //txtLastShipmentDate.Text = string.Empty;
                    //txtPaymentdaysAfterMRR.Text = string.Empty;
                    //txtNoOfInstallment.Text = string.Empty;
                    //txtInstallmentIntervalDays.Text = string.Empty;
                    //txtDestinationForDelivery.Text = string.Empty;
                    //txtWarrentyAfterDelivery.Text = string.Empty;
                    //txtOtherTerms.Text = string.Empty;
                    //txtTransport.Text = string.Empty;
                    //txtGDiscount.Text = string.Empty;
                    //txtOthers.Text = string.Empty;
                    Common.Clear(Controls);
                }
            }
            catch
            {
                Common.Clear(Controls);
            }

            if (string.IsNullOrWhiteSpace(txtMrrNo.Text))
            {
                dt = obj.GetApprovalAuthorityList(Enroll, PoType);
                if (dt.Rows.Count > 0)
                {
                    //Authority
                    btnDeletePO.Visible = true;
                    btnUpdatePO.Visible = true;
                }
                else
                {
                    btnDeletePO.Visible = false;
                    btnUpdatePO.Visible = false;

                    dt = obj.GetApprovalInfo(intPOID);
                    if (dt.Rows.Count > 0)
                    {
                        int poActionBy = Convert.ToInt32(dt.Rows[0]["intLastActionBy"].ToString());
                        bool ysnApproved = Convert.ToBoolean(dt.Rows[0]["ysnApprove"].ToString());
                        if (poActionBy == Enroll)
                        {
                            if (ysnApproved)
                            {
                                Toaster("This PO have already been approved. Please contact with your suppervisor for correction.", Common.TosterType.Warning);
                                return;
                            }
                            else
                            {
                                btnDeletePO.Visible = true;
                                // show
                            }
                        }
                        else
                        {
                            Toaster("This is not your PO. You can not correction",Common.TosterType.Warning);
                            return;
                        }
                    }
                    else
                    {
                        Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                        return;
                    }

                    
                }

                
                dt = new DataTable();
                dt = obj.GetItemInfoByPO(intPOID);
                File.Delete(filePathForXML);
                dgvItemInfoByPO.DataSource = "";
                dgvItemInfoByPO.DataBind();
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

                        CreateVoucherXml(intemid, itemname, specification, uom, qty, rate, vat, ait, total, ysnExisting);
                    }
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                }
            }
            else
            {
                btnUpdatePO.Visible = false;
                btnDeletePO.Visible = false;
                Toaster("MRR has already been issued. Remove MRR first.",Common.TosterType.Warning);
            }
        }

        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intPOID = Convert.ToInt32(txtPONo.Text);
                    dt = obj.GetPoData(45, "", 0, intPOID, DateTime.Now, Enroll);
                    ysnApprove = dt.Rows[0]["ysnApprove"].ToString();
                    intSingleApproveBy = dt.Rows[0]["ysnApprove"].ToString();
                    strPo = dt.Rows[0]["strPoFor"].ToString();

                    //PO Correction cannot be possible after approve
                    if (string.IsNullOrEmpty(ysnApprove) || string.IsNullOrEmpty(intSingleApproveBy))
                    {
                        update();
                    }
                    else if (!string.IsNullOrEmpty(ysnApprove) || !string.IsNullOrEmpty(intSingleApproveBy))
                    {
                        // only this two Enroll can update PO even though PO already approved.
                        dt = obj.GetApprovalAuthorityList(Enroll, strPo);
                        if (dt.Rows.Count > 0)
                        {
                            string POType = dt.Rows[0]["strPOType"].ToString();
                            int ApprovedBy = Convert.ToInt32(dt.Rows[0]["intEnrollment"].ToString());
                            if (Enroll == ApprovedBy && strPo == POType)
                            {
                                update();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO cannot update.PO already approved');", true);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void update()
        {
            if (!CheckTextBox(txtPONo, "PO"))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtMrrNo.Text))
            {
                //'PO correction is not possible after issuing MRR'

                try
                {
                    dtePODate = DateTime.Parse(txtPODate.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Date Format.');", true); return;
                }

                try
                {
                    intCurrencyID = int.Parse(ddlCurrency.SelectedValue.ToString());
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Currency.');", true); return;
                }

                try
                {
                    monFreight = decimal.Parse(txtTransport.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Freight Amount.');", true); return;
                }

                try
                {
                    monPacking = decimal.Parse(txtOthers.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Packing Amount.');", true); return;
                }

                try
                {
                    monDiscount = decimal.Parse(txtGDiscount.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Discount Amount.');", true); return;
                }

                try
                {
                    intShipment = int.Parse(txtNoofShipment.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong No of Shipment.');", true); return;
                }

                try
                {
                    intCreditDays = int.Parse(txtPaymentdaysAfterMRR.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Payment days after MRR (days)');", true); return;
                }

                strDeliveryAddress = txtDestinationForDelivery.Text;
                ysnPartialShip = int.Parse(ddlPartialShipment.SelectedValue.ToString());
                strPayTerm = ddlPaymentTerms.SelectedItem.ToString();

                try
                {
                    intInstallmentNo = int.Parse(txtNoOfInstallment.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong No of Installment (for installment Payment)');", true); return;
                }

                try
                {
                    intInstallmentInterval = int.Parse(txtInstallmentIntervalDays.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Installment Interval (Days, for installment)');", true); return;
                }

                try
                {
                    intWarrantyMonth = int.Parse(txtWarrentyAfterDelivery.Text);
                }
                catch
                {
                    intWarrantyMonth = 0;
                } //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Warrenty after delivery (in months)');", true); return; }

                try
                {
                    dteLastShipmentDate = DateTime.Parse(txtLastShipmentDate.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Last Shipment Date;", true); return;
                }

                strOtherTerms = txtOtherTerms.Text;
                intPart = 1;
                dt = obj.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking, monDiscount, intShipment, strDeliveryAddress, ysnPartialShip,
                strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, dteLastShipmentDate, intEnroll);
                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["msg"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    hdnconfirm.Value = "0";
                }
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO correction is not possible after issuing MRR.');", true); }
        }

        protected void btnDeletePO_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intPart = 2;

                    dt = obj.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking, monDiscount, intShipment, strDeliveryAddress, ysnPartialShip,
                    strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, dteLastShipmentDate, intEnroll);
                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["msg"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        hdnconfirm.Value = "0";
                    }
                }
                catch { }
            }
        }

        #region ===== XML Start Code =======================================================

        private void CreateVoucherXml(string intemid, string itemname, string specification, string uom, string qty, string rate, string vat, string ait, string total, string ysnExisting)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
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
            else { dgvItemInfoByPO.DataSource = ""; }
            dgvItemInfoByPO.DataBind();
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
                totalait += decimal.Parse(((TextBox)e.Row.Cells[9].FindControl("txtAIT")).Text);
                totalval += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblTotalVal")).Text);
            }
        }

        #endregion ===== XML Start Code =======================================================

        protected void dgvItemInfoByPO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateItem")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvItemInfoByPO.Rows[rowIndex];
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        try { intPOID = int.Parse(txtPONo.Text); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Number');", true); return; }

                        try { intMRRID = int.Parse(txtMrrNo.Text); }
                        catch { intMRRID = 0; }

                        if (intMRRID == 0)
                        {
                            intItemID = int.Parse((row.FindControl("lblItemID") as Label).Text);
                            strSpecification = (row.FindControl("txtSpecification") as TextBox).Text;

                            try { numPOQty = decimal.Parse((row.FindControl("txtQty") as TextBox).Text); }
                            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Quantity.');", true); return; }

                            try { monRate = decimal.Parse((row.FindControl("txtRate") as TextBox).Text); }
                            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Rate.');", true); return; }

                            try { monVAT = decimal.Parse((row.FindControl("txtVAT") as TextBox).Text); }
                            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong VAT Amount.');", true); return; }

                            try { monAIT = decimal.Parse((row.FindControl("txtAIT") as TextBox).Text); }
                            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong AIT Amount.');", true); return; }

                            try { monAmount = decimal.Parse((row.FindControl("lblTotalVal") as Label).Text); }
                            catch { monAmount = 0; }

                            //Final Insert
                            string message = obj.UpdateItemInfoByPONew(intPOID, numPOQty, intItemID, strSpecification, monRate, monVAT, monAmount, Enroll, monAIT);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO correction is not possible after issuing MRR.');", true); }
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
                }
            }
            else if (e.CommandName == "DeleteItem")
            {
                if (hdnconfirm.Value == "1")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = dgvItemInfoByPO.Rows[rowIndex];
                    try
                    {
                        intMRRID = int.Parse(txtMrrNo.Text);
                    }
                    catch
                    {
                        intMRRID = 0;
                    }
                    try
                    {
                        intPOID = int.Parse(txtPONo.Text);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong PO Number');", true); return;
                    }
                    if (dgvItemInfoByPO.Rows.Count == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item delete not possible.');", true); return;
                    }
                    else
                    {
                        if (intMRRID == 0)
                        {
                            intItemID = int.Parse((row.FindControl("lblItemID") as Label).Text);
                            string msg = obj.Delete_PO_Data(intItemID, intPOID, Enroll);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item delete not possible after issuing MRR.');", true); return;
                        }
                    }
                }
            }
        }
    }
}
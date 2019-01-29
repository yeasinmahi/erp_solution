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
        private int intPart, intPOID, intCurrencyID, intShipment, ysnPartialShip, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, intMRRID, intSuppid;
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

        private bool CheckTextBox(TextBox textBox, string type, out int id)
        {
            string s = textBox.Text;
            string contolText;
            id = 0;
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
            if (!int.TryParse(s, out id))
            {
                Toaster("Input " + contolText + "prperly", Common.TosterType.Warning);
                return false;
            }

            return true;
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Common.Clear(UpdatePanel0.Controls);
            Common.UnLoadDropDown(ddlSupplier);
            if (!CheckTextBox(txtPONo, "PO", out intPOID))
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
                lblSupplierAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();
                //ddlSupplier.SelectedValue = dt.Rows[0]["intSupplierID"].ToString();
                Common.SetDdlSelectedValue(ddlSupplier, dt.Rows[0]["intSupplierID"].ToString());
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
                    Common.Clear(UpdatePanel0.Controls);
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
                            Toaster("This is not your PO. You can not correction", Common.TosterType.Warning);
                            return;
                        }
                    }
                    else
                    {
                        Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                        return;
                    }
                }
                LoadItemGridview();
            }
            else
            {
                btnUpdatePO.Visible = false;
                btnDeletePO.Visible = false;
                Toaster("MRR has already been issued. Remove MRR first.", Common.TosterType.Warning);
            }
        }

        public void LoadItemGridview()
        {
            dt = obj.GetItemInfoByPO(intPOID);
            FileHelper.DeleteFile(filePathForXML);
            GridViewUtil.UnLoadGridView(dgvItemInfoByPO);
            if (dt.Rows.Count > 0)
            {
                dgvItemInfoByPO.DataSource = dt;
                dgvItemInfoByPO.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }
        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (!CheckTextBox(txtPONo, "PO", out intPOID))
                    {
                        return;
                    }
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
            if (!CheckTextBox(txtPONo, "PO", out intPOID))
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
                    Toaster(Message.DateFormatError.ToFriendlyString(), Common.TosterType.Warning);
                    return;
                }

                intCurrencyID = Common.GetDdlSelectedValue(ddlCurrency);
                if (intCurrencyID == 0)
                {
                    Toaster("You should select currency", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    monFreight = decimal.Parse(txtTransport.Text);
                }
                catch
                {
                    Toaster("Wrong Freight Amount", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    monPacking = decimal.Parse(txtOthers.Text);
                }
                catch
                {
                    Toaster("Wrong Packing Amount", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    monDiscount = decimal.Parse(txtGDiscount.Text);
                }
                catch
                {
                    Toaster("Wrong Discount Amount", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    intShipment = int.Parse(txtNoofShipment.Text);
                }
                catch
                {
                    Toaster("Wrong No of Shipment", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    intCreditDays = int.Parse(txtPaymentdaysAfterMRR.Text);
                }
                catch
                {
                    Toaster("Wrong Payment days after MRR (days)", Common.TosterType.Warning);
                    return;
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
                    Toaster("Wrong No of Installment (for installment Payment)", Common.TosterType.Warning);
                    return;
                }

                try
                {
                    intInstallmentInterval = int.Parse(txtInstallmentIntervalDays.Text);
                }
                catch
                {
                    Toaster("Wrong Installment Interval (Days, for installment)", Common.TosterType.Warning);
                    return;
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
                    Toaster("Wrong Last Shipment Date", Common.TosterType.Warning);
                    return;
                }
                int supplierId = Common.GetDdlSelectedValue(ddlSupplier);

                strOtherTerms = txtOtherTerms.Text;
                intPart = 1;
                dt = obj.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking, monDiscount,
                    intShipment, strDeliveryAddress, ysnPartialShip,
                    strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth,
                    strOtherTerms, dteLastShipmentDate, Enroll, supplierId);
                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["msg"].ToString();
                    Toaster(msg,
                        msg.ToLower().Contains("success") ? Common.TosterType.Success : Common.TosterType.Error);
                    hdnconfirm.Value = "0";
                    LoadItemGridview();
                }
            }
            else
            {
                Toaster("PO correction is not possible after issuing MRR", Common.TosterType.Warning);
            }
        }

        protected void btnDeletePO_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (!CheckTextBox(txtPONo, "PO", out intPOID))
                    {
                        return;
                    }
                    intPart = 2;
                    dt = obj.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking,
                        monDiscount, intShipment, strDeliveryAddress, ysnPartialShip,
                        strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth,
                        strOtherTerms, dteLastShipmentDate, Enroll, 0);
                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["msg"].ToString();
                        Toaster(msg,
                            msg.ToLower().Contains("success") ? Common.TosterType.Success : Common.TosterType.Error);
                        hdnconfirm.Value = "0";
                        LoadItemGridview();
                    }
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }
        }

        
        protected decimal totalqty = 0;
        protected decimal totalval = 0;
        protected decimal totalait = 0;
        protected decimal totalvat = 0;

        protected void dgvItemInfoByPO_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalqty += decimal.Parse(((TextBox)e.Row.FindControl("txtQty")).Text);
                totalvat += decimal.Parse(((TextBox)e.Row.FindControl("txtVAT")).Text);
                totalait += decimal.Parse(((TextBox)e.Row.FindControl("txtAIT")).Text);
                totalval += decimal.Parse(((Label)e.Row.FindControl("lblTotalVal")).Text);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label)e.Row.FindControl("lblGrandTotalQty")).Text = totalqty.ToString();
                ((Label)e.Row.FindControl("lblGrandTotalVAT")).Text = totalvat.ToString();
                ((Label)e.Row.FindControl("lblGrandTotalAIT")).Text = totalait.ToString();
                ((Label)e.Row.FindControl("lblGrandTotal")).Text = totalval.ToString();
            }
        }
        protected void dgvItemInfoByPO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateItem")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvItemInfoByPO.Rows[rowIndex];
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        if (!CheckTextBox(txtPONo, "PO", out intPOID))
                        {
                            return;
                        }
                        try
                        {
                            intMRRID = int.Parse(txtMrrNo.Text);
                        }
                        catch
                        {
                            intMRRID = 0;
                        }

                        if (intMRRID == 0)
                        {
                            intItemID = int.Parse((row.FindControl("lblItemID") as Label).Text);
                            strSpecification = (row.FindControl("txtSpecification") as TextBox).Text;

                            try
                            {
                                numPOQty = decimal.Parse((row.FindControl("txtQty") as TextBox).Text);
                            }
                            catch
                            {
                                Toaster("Wrong PO Quantity", Common.TosterType.Warning);
                            }

                            try
                            {
                                monRate = decimal.Parse((row.FindControl("txtRate") as TextBox).Text);
                            }
                            catch
                            {
                                Toaster("Wrong Rate", Common.TosterType.Warning);
                            }

                            try
                            {
                                monVAT = decimal.Parse((row.FindControl("txtVAT") as TextBox).Text);
                            }
                            catch
                            {
                                Toaster("Wrong VAT Amount", Common.TosterType.Warning);
                            }

                            try
                            {
                                monAIT = decimal.Parse((row.FindControl("txtAIT") as TextBox).Text);
                            }
                            catch
                            {
                                Toaster("Wrong AIT Amount", Common.TosterType.Warning);
                            }

                            try
                            {
                                monAmount = decimal.Parse((row.FindControl("lblTotalVal") as Label).Text);
                            }
                            catch
                            {
                                monAmount = 0;
                            }

                            //Final Insert
                            string msg = obj.UpdateItemInfoByPONew(intPOID, numPOQty, intItemID, strSpecification,
                                monRate, monVAT, monAmount, Enroll, monAIT);
                            Toaster(msg,
                                msg.ToLower().Contains("success")
                                    ? Common.TosterType.Success
                                    : Common.TosterType.Error);
                            LoadItemGridview();
                        }
                        else
                        {
                            Toaster("PO correction is not possible after issuing MRR", Common.TosterType.Warning);
                        }
                    }
                    catch
                    {
                        Toaster("Please Try Again", Common.TosterType.Error);
                    }
                }
            }
            else if (e.CommandName == "DeleteItem")
            {
                if (hdnconfirm.Value == "1")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = dgvItemInfoByPO.Rows[rowIndex];
                    if (!CheckTextBox(txtPONo, "PO", out intPOID))
                    {
                        return;
                    }
                    try
                    {
                        intMRRID = int.Parse(txtMrrNo.Text);
                    }
                    catch
                    {
                        intMRRID = 0;
                    }

                    if (dgvItemInfoByPO.Rows.Count <= 1)
                    {
                        Toaster("Item delete not possible", Common.TosterType.Warning);
                        return;
                    }
                    if (intMRRID == 0)
                    {
                        intItemID = int.Parse((row.FindControl("lblItemID") as Label).Text);
                        string msg = obj.Delete_PO_Data(intItemID, intPOID, Enroll);
                        Toaster(msg,
                            msg.ToLower().Contains("success")
                                ? Common.TosterType.Success
                                : Common.TosterType.Error);
                        LoadItemGridview();
                    }
                    else
                    {
                        Toaster("Item delete not possible after issuing MRR", Common.TosterType.Warning);
                    }
                }
            }
        }
    }
}
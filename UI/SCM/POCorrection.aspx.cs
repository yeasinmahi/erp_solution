using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class POCorrection : BasePage
    {
        private readonly PoGenerate_BLL _bll = new PoGenerate_BLL();
        private DataTable _dt;
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

                _dt = _bll.GetCurrency();
                Common.LoadDropDown(ddlCurrency, _dt, "intCurrencyID", "strCurrencyName");

                btnUpdatePO.Visible = false;
                btnDeletePO.Visible = false;
            }
        }

        private bool CheckTextBox(TextBox textBox, string type, out int id)
        {
            string s = textBox.Text;
            id = 0;
            string contolText = type.Equals("PO") ? "PO Id " : "MRR Id ";

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

            _dt = new DataTable();
            _dt = _bll.GetMRRNoByPO(intPOID);

            if (_dt.Rows.Count > 0)
            {
                txtMrrNo.Text = _dt.Rows[0]["intMRRID"].ToString();
            }
            else
            {
                txtMrrNo.Text = "";
            }
            _dt = _bll.GetSuppliers(intPOID);
            Common.LoadDropDown(ddlSupplier, _dt, "intSupplierID", "strSupplierName");

            _dt = new DataTable();
            _dt = _bll.GetSupplierInfoByPO(intPOID);
            if (_dt.Rows.Count > 0)
            {
                ddlCurrency.SelectedValue = _dt.Rows[0]["intCurrencyID"].ToString();
                txtPODate.Text = _dt.Rows[0]["dtePODate"].ToString();
                hdnPOUnit.Value = _dt.Rows[0]["intUnitID"].ToString();
                HttpContext.Current.Session["Unitid"] = _dt.Rows[0]["intUnitID"].ToString();
                txtPOType.Text = _dt.Rows[0]["strPoFor"].ToString();
                PoType = _dt.Rows[0]["strPoFor"].ToString();
                lblSupplierAddress.Text = _dt.Rows[0]["strOrgAddress"].ToString();
                //ddlSupplier.SelectedValue = dt.Rows[0]["intSupplierID"].ToString();
                Common.SetDdlSelectedValue(ddlSupplier, _dt.Rows[0]["intSupplierID"].ToString());
                txtWH.Text = _dt.Rows[0]["strWareHoseName"].ToString();
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
                _dt = _bll.GetShipmentAndOtherInfoByPO(intPOID);
                if (_dt.Rows.Count > 0)
                {
                    ddlPartialShipment.SelectedValue = _dt.Rows[0]["ysnPartialShip"].ToString();
                    txtNoofShipment.Text = _dt.Rows[0]["intShipment"].ToString();
                    txtLastShipmentDate.Text = _dt.Rows[0]["dteLastShipmentDate"].ToString();
                    ddlPaymentTerms.SelectedItem.Text = _dt.Rows[0]["strPayTerm"].ToString();
                    txtPaymentdaysAfterMRR.Text = _dt.Rows[0]["intCreditDays"].ToString();
                    txtNoOfInstallment.Text = _dt.Rows[0]["intInstallmentNo"].ToString();
                    txtInstallmentIntervalDays.Text = _dt.Rows[0]["intInstallmentInterval"].ToString();
                    txtDestinationForDelivery.Text = _dt.Rows[0]["strDeliveryAddress"].ToString();
                    txtWarrentyAfterDelivery.Text = _dt.Rows[0]["intWarrantyMonth"].ToString();
                    txtOtherTerms.Text = _dt.Rows[0]["strOtherTerms"].ToString();
                    txtTransport.Text = _dt.Rows[0]["monFreight"].ToString();
                    txtGDiscount.Text = _dt.Rows[0]["monDiscount"].ToString();
                    txtOthers.Text = _dt.Rows[0]["monPacking"].ToString();
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
                _dt = _bll.GetApprovalAuthorityList(Enroll, PoType);
                if (_dt.Rows.Count > 0)
                {
                    //Authority
                    btnDeletePO.Visible = true;
                    btnUpdatePO.Visible = true;
                }
                else
                {
                    btnDeletePO.Visible = false;
                    btnUpdatePO.Visible = false;

                    _dt = _bll.GetApprovalInfo(intPOID);
                    if (_dt.Rows.Count > 0)
                    {
                        int poActionBy = Convert.ToInt32(_dt.Rows[0]["intLastActionBy"].ToString());
                        bool ysnApproved = Convert.ToBoolean(_dt.Rows[0]["ysnApprove"].ToString());
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
            if (!CheckTextBox(txtPONo, "PO", out intPOID))
            {
                return;
            }
            _dt = _bll.GetItemInfoByPO(intPOID);
            FileHelper.DeleteFile(filePathForXML);
            GridViewUtil.UnLoadGridView(dgvItemInfoByPO);
            if (_dt.Rows.Count > 0)
            {
                dgvItemInfoByPO.DataSource = _dt;
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
                    _dt = _bll.GetPoData(45, "", 0, intPOID, DateTime.Now, Enroll);

                    ysnApprove = _dt.Rows[0]["ysnApprove"].ToString();
                    intSingleApproveBy = _dt.Rows[0]["ysnApprove"].ToString();
                    strPo = _dt.Rows[0]["strPoFor"].ToString();

                    //PO Correction cannot be possible after approve
                    if (string.IsNullOrEmpty(ysnApprove) || string.IsNullOrEmpty(intSingleApproveBy))
                    {
                        update();
                    }
                    else if (!string.IsNullOrEmpty(ysnApprove) || !string.IsNullOrEmpty(intSingleApproveBy))
                    {
                        // only this two Enroll can update PO even though PO already approved.
                        _dt = _bll.GetApprovalAuthorityList(Enroll, strPo);
                        if (_dt.Rows.Count > 0)
                        {
                            string POType = _dt.Rows[0]["strPOType"].ToString();
                            int ApprovedBy = Convert.ToInt32(_dt.Rows[0]["intEnrollment"].ToString());
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
                _dt = _bll.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking, monDiscount,
                    intShipment, strDeliveryAddress, ysnPartialShip,
                    strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth,
                    strOtherTerms, dteLastShipmentDate, Enroll, supplierId);
                if (_dt.Rows.Count > 0)
                {
                    string msg = _dt.Rows[0]["msg"].ToString();
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
                    _dt = _bll.POCurrection(intPart, intPOID, dtePODate, intCurrencyID, monFreight, monPacking,
                        monDiscount, intShipment, strDeliveryAddress, ysnPartialShip,
                        strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth,
                        strOtherTerms, dteLastShipmentDate, Enroll, 0);
                    if (_dt.Rows.Count > 0)
                    {
                        string msg = _dt.Rows[0]["msg"].ToString();
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
                            string msg = _bll.UpdateItemInfoByPONew(intPOID, numPOQty, intItemID, strSpecification,
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
                        string msg = _bll.Delete_PO_Data(intItemID, intPOID, Enroll);
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

        protected void ddlSupplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _dt = _bll.GetSupplierAddress(Common.GetDdlSelectedValue(ddlSupplier));
            lblSupplierAddress.Text = _dt.Rows[0]["strOrgAddress"].ToString();
            //LoadItemGridview(); it can not 
        }
    }
}
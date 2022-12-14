using SCM_BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoGenerateNew : BasePage
    {
        private DataTable dt = new DataTable();
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private string filePathForXML, filePathForXMLPrepare, filePathForXMLPo, othersTrems, warrentyperiod, xmlString = "", strType, msg, supplierName;
        private int enroll, intWh, indentNo, whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem;
        private string ysnApprove, intSingleApproveBy;

        private decimal totalqnty = 0, totalValue = 0, totalAit = 0, totalVat = 0;
        private char[] delimeters = { '[', ']' };
        private string[] arraykey;

        private string payDate, paymentTrems, destDelivery, paymentSchedule;
        private DateTime dtePo, dtelastShipment;
        private decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        #region=========== gridview bind==============

        protected void dgvIndentPrepare_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void dgvIndentPrepare_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void dgvIndentPrepare_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;

                GridViewRow selectedRow = dgvIndentPrepare.Rows[RowIndex];
                Label lblitemid = selectedRow.FindControl("lblItemId") as Label;
                TextBox txtquantity = selectedRow.FindControl("txtQty") as TextBox;
                TextBox txtrate = selectedRow.FindControl("txtRate") as TextBox;
                TextBox txtvat = selectedRow.FindControl("txtVAT") as TextBox;
                TextBox txtait = selectedRow.FindControl("txtAIT") as TextBox;
                decimal quantity = Convert.ToDecimal(txtquantity.Text);
                decimal rate = Convert.ToDecimal(txtrate.Text);
                decimal vat = Convert.ToDecimal(txtvat.Text);
                decimal ait = Convert.ToDecimal(txtait.Text);
                int itemid = Convert.ToInt32(lblitemid.Text);
                int pono = Convert.ToInt32(txtpoid.Text);
                msg = objPo.UpdatePO(quantity, rate, vat, ait, itemid, pono);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            else if (e.CommandName == "delete")
            {
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;

                GridViewRow selectedRow = dgvIndentPrepare.Rows[RowIndex];
                Label lblitemid = selectedRow.FindControl("lblItemId") as Label;
                int itemid = Convert.ToInt32(lblitemid.Text);
                int pono = Convert.ToInt32(txtpoid.Text);
                int count = dgvIndentPrepare.Rows.Count;
                if (dgvIndentPrepare.Rows.Count > 1)
                {
                    msg = objPo.DeletePo(itemid, pono);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                else if (dgvIndentPrepare.Rows.Count == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Cannot Delete the PO');", true);
                }
            }
        }

        protected void dgvIndentPrepare_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalqnty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "numQty"));
                totalValue += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monAmount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblGrandTotalQty");
                Label lblTotalvalue = (Label)e.Row.FindControl("lblGrandTotal");
                if (lblTotal != null)
                {
                    lblTotal.Text = totalqnty.ToString();
                }
                if (lblTotalvalue != null)
                {
                    lblTotalvalue.Text = totalValue.ToString();
                }
            }
        }

        #endregion============end gridview bind=======================

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arraykey = txtSupplier.Text.Split(delimeters);
                string strSupp = "";
                int supplierid = 0;
                if (arraykey.Length > 0)
                {
                    strSupp = arraykey[0].ToString();
                    supplierid = int.Parse(arraykey[1].ToString());
                }

                dt = objPo.GetPoData(22, "", 0, supplierid, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSuppAddress.Text = dt.Rows[0]["strName"].ToString();
                }
            }
            catch { }
        }

        #region==========button event===========

        protected void btnShow_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int pono = Convert.ToInt32(txtpoid.Text);
            //DateTime dte = DateTime.Now;
            dt = new DataTable();
            dt = objPo.GetPoData(45, "", 0, pono, DateTime.Now, enroll);

            if (dt.Rows.Count > 0)
            {
                string strType = dt.Rows[0]["strPoFor"].ToString();
                if (strType == "Import")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Insert the PO NO not in Import');", true);
                    txtpoid.Text = "";
                    txtdtePo.Text = "";
                    txtdtePo.BackColor = Color.White;
                    txtCommosion.Text = "";
                    txtWH.Text = "";
                    txtWH.BackColor = Color.White;
                    txtAit.Text = "";
                    txtAit.BackColor = Color.White;
                    txtSupplier.Text = "";
                    lblSuppAddress.Text = "";
                    txtGrossDiscount.Text = "";
                    ddlCurrency.DataSource = "";
                    ddlCurrency.DataBind();
                    ddlDtePay.DataSource = "";
                    ddlDtePay.DataBind();
                    ddlCostCenter.DataSource = "";
                    ddlCostCenter.DataBind();
                    dgvIndentPrepare.DataSource = "";
                    dgvIndentPrepare.DataBind();
                }
                else
                {
                    intWh = Convert.ToInt32(dt.Rows[0]["intWHID"].ToString());
                    txtCommosion.Text = dt.Rows[0]["monCommission"].ToString();

                    DateTime date = Convert.ToDateTime(dt.Rows[0]["dtePODate"].ToString());
                    txtdtePo.Text = date.ToShortDateString();
                    txtdtePo.BackColor = Color.LightGray;
                    txtAit.Text = dt.Rows[0]["monAIT"].ToString();
                    txtAit.BackColor = Color.LightGray;
                    txtGrossDiscount.Text = dt.Rows[0]["monDiscount"].ToString();

                    DateTime shipdate = Convert.ToDateTime(dt.Rows[0]["dteLastShipmentDate"].ToString());
                    txtLastShipmentDate.Text = shipdate.ToString("yyyy-MM-dd");
                    ddlPaymentTrams.Text = dt.Rows[0]["strPayTerm"].ToString();
                    txtDestinationDelivery.Text = dt.Rows[0]["strDeliveryAddress"].ToString();
                    txtWarrenty.Text = dt.Rows[0]["intWarrantyMonth"].ToString();
                    txtOthersTerms.Text = dt.Rows[0]["strOtherTerms"].ToString();

                    txtIntervel.Text = dt.Rows[0]["intInstallmentInterval"].ToString();
                    txtNoOfInstall.Text = dt.Rows[0]["intInstallmentNo"].ToString();
                    txtAfterMrrDay.Text = dt.Rows[0]["intCreditDays"].ToString();
                    txtNoOfShipment.Text = dt.Rows[0]["intShipment"].ToString();

                    string ysnps = dt.Rows[0]["strDeliveryAddress"].ToString();
                    if (ysnps == "True")
                    {
                        ddlPartialShip.Text = "Yes";
                    }
                    else if (ysnps == "False")
                    {
                        ddlPartialShip.Text = "No";
                    }

                    dt = new DataTable();
                    dt = objPo.GetWHName(intWh);
                    txtWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
                    txtWH.BackColor = Color.LightGray;

                    dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, enroll);//get Currency Name

                    ddlCurrency.DataSource = dt;
                    ddlCurrency.DataTextField = "strName";
                    ddlCurrency.DataValueField = "Id";
                    ddlCurrency.DataBind();
                    dt.Clear();

                    dt = objPo.GetPoData(45, "", 0, pono, DateTime.Now, enroll);
                    int unit = Convert.ToInt32(dt.Rows[0]["intUnitID"].ToString());
                    Session["unitId"] = unit.ToString();
                    dt = objPo.GetPoData(7, "", intWh, unit, DateTime.Now, enroll);// Pay Date
                    ddlDtePay.DataSource = dt;
                    ddlDtePay.DataTextField = "strName";
                    ddlDtePay.DataValueField = "dteDate";
                    ddlDtePay.DataBind();
                    ddlDtePay.BackColor = Color.LightGray;

                    dt = objPo.GetPoData(8, "", intWh, unit, DateTime.Now, enroll);// Get Costcenter
                    ddlCostCenter.DataSource = dt;
                    ddlCostCenter.DataTextField = "strName";
                    ddlCostCenter.DataValueField = "Id";
                    ddlCostCenter.DataBind();

                    dt = objPo.GetPoData(44, "", 0, pono, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        dgvIndentPrepare.DataSource = dt;
                        dgvIndentPrepare.DataBind();
                    }
                    else
                    {
                        dgvIndentPrepare.DataSource = "";
                        dgvIndentPrepare.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not found');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not found');", true);
            }
        }

        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intPOID = Convert.ToInt32(txtpoid.Text);
            dt = objPo.GetPoData(45, "", 0, intPOID, DateTime.Now, enroll);
            ysnApprove = dt.Rows[0]["ysnApprove"].ToString();
            intSingleApproveBy = dt.Rows[0]["ysnApprove"].ToString();
            if (ysnApprove == "" || intSingleApproveBy == "")
            {
                decimal monFreight = Convert.ToDecimal(txtTransport.Text);
                decimal monPacking = Convert.ToDecimal(txtOthers.Text);
                decimal monDiscount = Convert.ToDecimal(txtGrossDiscount.Text);
                arraykey = txtSupplier.Text.Split(delimeters);
                if (arraykey.Length > 0)
                {
                    supplierName = arraykey[0].ToString();
                    supplierId = Convert.ToInt32(arraykey[1].ToString());
                }

                DateTime PODate = DateTime.Parse(txtdtePo.Text, CultureInfo.InvariantCulture);
                string date = PODate.ToString("yyyy-MM-dd");
                DateTime dtePODate = DateTime.Parse(date);
                int intCurrencyID = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                msg = objPo.UpdatePOMain(0, "", true, "", 0, 0, 0, 0, "", DateTime.Now, intPOID, 2, monFreight, monPacking, monDiscount, supplierId, dtePODate, intCurrencyID, enroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            else if (ysnApprove != "" || intSingleApproveBy != "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already Approved');", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intPOID = Convert.ToInt32(txtpoid.Text);
            dt = objPo.GetPoData(45, "", 0, intPOID, DateTime.Now, enroll);
            ysnApprove = dt.Rows[0]["ysnApprove"].ToString();
            intSingleApproveBy = dt.Rows[0]["ysnApprove"].ToString();
            if (ysnApprove == "" || intSingleApproveBy == "")
            {
                int intShipment = Convert.ToInt32(txtNoOfShipment.Text);
                string strDeliveryAddress = txtDestinationDelivery.Text;
                string PartialShip = ddlPartialShip.SelectedItem.Text;
                bool ysnPartialShip = false;
                if (PartialShip == "Yes")
                {
                    ysnPartialShip = true;
                }
                else if (PartialShip == "No")
                {
                    ysnPartialShip = false;
                }
                string strPayTerm = ddlPaymentTrams.SelectedItem.Text;
                int intCreditDays = Convert.ToInt32(txtAfterMrrDay.Text);
                int intInstallmentNo = Convert.ToInt32(txtNoOfInstall.Text);
                int intInstallmentInterval = Convert.ToInt32(txtIntervel.Text);
                int intWarrantyMonth = Convert.ToInt32(txtWarrenty.Text);
                string strOtherTerms = txtOthers.Text;
                DateTime ShipmentDate = DateTime.ParseExact(txtLastShipmentDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                msg = objPo.UpdatePOMain(intShipment, strDeliveryAddress, ysnPartialShip, strPayTerm, intCreditDays, intInstallmentNo, intInstallmentInterval, intWarrantyMonth, strOtherTerms, ShipmentDate, intPOID, 1, 0, 0, 0, 0, DateTime.Now, 0, enroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            else if (ysnApprove != "" || intSingleApproveBy != "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already Approved');", true);
            }
        }

        #endregion==============end button event======================

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, "", HttpContext.Current.Session["unitId"].ToString());
        }

        #endregion====================Close===============================
    }
}
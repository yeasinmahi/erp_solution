using BLL.Accounts.Bank;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class AccountsViewCashCredit : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill(); protected double grdTotal = 0;
        bool isCheque; string chequeno; bool isAdvice; bool isOnline; string statusmsg = ""; string[] vouchercode;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\PartyPayment\\AccountsViewCashCredit";
        string stop = "stopping Accounts\\PartyPayment\\AccountsViewCashCredit";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { pnlUpperControl.DataBind(); hdnuserid.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString(); btnSelectAll.Text = "SelectAll"; }
        }

        #region---------- Change & Databound Event Handaler ------------
        public string GetJSShowBillVATPOMRR(object intBillID, object intPOID, object intShipmentID, object viewtype)
        { return "ShowBillVatPOMRR('" + intBillID.ToString() + "','" + intPOID.ToString() + "','" + intShipmentID.ToString() + "','" + viewtype.ToString() + "')"; }
        protected void ddlBank_DataBound(object sender, EventArgs e)
        {
            SetChequeNumber();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetChequeNumber();
        }
        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetChequeNumber();
        }

        protected void dgvViewBill_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                grdTotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lblAmount")).Text);
            }
        }
        protected void ddlAccount_DataBound(object sender, EventArgs e)
        {
            SetChequeNumber();
        }
        protected void ddlPaytype_DataBound(object sender, EventArgs e)
        {
            if (ddlPaytype.SelectedValue.ToString() == "2") { txtChkNo.Text = "Advice"; isAdvice = true; }
            else if (ddlPaytype.SelectedValue.ToString() == "3") { txtChkNo.Text = "Online"; isOnline = true; }
            else { txtChkNo.Text = hdnchequeno.Value; isCheque = true; }
        }
        protected void ddlPaytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaytype.SelectedValue.ToString() == "2") { txtChkNo.Text = "Advice"; isAdvice = true; }
            else if (ddlPaytype.SelectedValue.ToString() == "3") { txtChkNo.Text = "Online"; isOnline = true; }
            else { txtChkNo.Text = hdnchequeno.Value; isCheque = true; }
        }
        private void SetChequeNumber()
        {
            BankCheck bc = new BankCheck();
            txtChkNo.Text = bc.GetCheckNo(ddlAccount.SelectedValue);
            if (txtChkNo.Text != "")
            {
                isCheque = true; hdnchequeno.Value = txtChkNo.Text; chequeno = hdnchequeno.Value;
            }
            else { isAdvice = false; isCheque = false; isCheque = false; }
        }
        private decimal GetSubstringValue(string gvnstring)
        {
            if (String.IsNullOrEmpty(gvnstring))
            {
                return decimal.Parse(gvnstring);
            }
            else
            {
                decimal number;
                Decimal.TryParse(gvnstring, out number);
                decimal returnDEC = Decimal.Round(number, 2);
                return returnDEC;
            }
        }
        #endregion

        #region---------- Click Event Handaler ------------
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "SelectAll")
            {
                btnSelectAll.Text = "UnSelectAll";
                int rowCount = dgvViewBill.Rows.Count;
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvViewBill.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true); }
            }

            else
            {
                btnSelectAll.Text = "SelectAll";
                int rowCount = dgvViewBill.Rows.Count;
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvViewBill.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AccountsViewCashCredit   Submit ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int rowCount = dgvViewBill.Rows.Count; bool ysnChecked;
                    for (int i = 0; i < rowCount; i++)
                    {
                        ysnChecked = ((CheckBox)dgvViewBill.Rows[i].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            #region------------- Bank Information --------------
                            int bnkid = int.Parse(ddlBank.SelectedValue.ToString());
                            int bnkaccid = int.Parse(ddlAccount.SelectedValue.ToString());
                            int type = int.Parse(ddlPaytype.SelectedValue.ToString());
                            chequeno = txtChkNo.Text;
                            DateTime chequedte = DateTime.Parse(dteCheque.Text);
                            decimal amountcr = GetSubstringValue(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnamount")).Value.ToString());
                            string bnknarration = ddlPaytype.SelectedItem.ToString();
                            string remarks = ddlPaytype.SelectedItem.ToString() + " " + ((HiddenField)dgvViewBill.Rows[i].FindControl("hdnsupname")).Value;
                            DateTime actualpaydte = DateTime.Parse(dteActualPay.Text);
                            #endregion

                            #region------------- Suplier Information --------------
                            string coacode = ((TextBox)dgvViewBill.Rows[i].Cells[1].Controls[0]).Text;//"16898";
                            string[] supcoaid = Regex.Split(coacode, ",");
                            decimal amountdr = GetSubstringValue(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnamount")).Value.ToString());
                            string supnarration = "Being the amount paid to " + ((HiddenField)dgvViewBill.Rows[i].FindControl("hdnsupname")).Value.ToString() + " For purchase of against PO No. " +
                            ((HiddenField)dgvViewBill.Rows[i].FindControl("hdnpoid")).Value.ToString() + " and Bill no. " + 
                            ((HiddenField)dgvViewBill.Rows[i].FindControl("hdnreff")).Value.ToString() +"";
                            #endregion

                            #region------------- Others Information --------------
                            string supname = ((HiddenField)dgvViewBill.Rows[i].FindControl("hdnsupname")).Value.ToString();
                            int unitid = int.Parse(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnunit")).Value.ToString());
                            int billid = int.Parse(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnbillno")).Value.ToString());
                            string billtype = "Cash/Credit";
                            int poid = int.Parse(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnpoid")).Value);
                            int shipmentid = int.Parse(((HiddenField)dgvViewBill.Rows[i].FindControl("hdnshipmentid")).Value);
                            #endregion

                            #region ------- Insert into Database -------------

                            if (txtChkNo.Text == "Advice") { isAdvice = true; }
                            else if (txtChkNo.Text == "Online") { isOnline = true; }
                            else { isCheque = true; }
                            statusmsg = objPartyBill.PartybillActionByAccounts(billtype, billid, unitid, poid, shipmentid, bnkid, bnkaccid, chequeno,
                            chequedte, amountcr, bnknarration, remarks, actualpaydte, supcoaid[supcoaid.Length - 1], amountdr, supname, supnarration,
                            isCheque, isAdvice, isOnline, supname, int.Parse(Session[SessionParams.USER_ID].ToString()));

                            if (statusmsg == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit this bill. !!!');", true);
                            }
                            else
                            {
                                vouchercode = Regex.Split(statusmsg, ",");
                                if (isCheque)
                                {
                                    objPartyBill.Updateusedchequeafteraccountsaction(int.Parse(vouchercode[1]), objPartyBill.GetLastChequeNo(bnkaccid, ""));
                                }
                            }
                            #endregion
                        }
                    }
                    dgvViewBill.DataBind();
                    SetChequeNumber(); dteCheque.Text = ""; dteActualPay.Text = "";
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            } 

        }
        

        #endregion

        


    }
}
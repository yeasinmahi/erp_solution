using BLL.Accounts.Voucher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Accounts.Voucher
{
    public partial class SubAccountVoucherEntry : System.Web.UI.Page
    {
        #region INIT
        private readonly AccountsNsubAccountsBLL acsacbll = new AccountsNsubAccountsBLL();
        int UnitId, Enroll, ysnCheque, ysnDemandDraft, ysnPayOrder, ysnDepositSlip, ysnAdvance, ysnAdjustment, ysnOnline;
        private string xmlString, filePathForXML, narration;
        private int CheckItem = 1;
        private decimal totalDebitAmount, totalCreditAmount;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Accounts/Voucher/Data/SubAcc__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
                tabBankReceive.CssClass = "Clicked";
                tabBankPayment.CssClass = "Initial";
                tabJournalVoucher.CssClass = "Initial";
                tabContra.CssClass = "Initial";

                mainView.ActiveViewIndex = 0;

                FillDropDown();
            }
        }
        
        #endregion

        #region Event

        #region Tab Event
        protected void tabBankReceive_Click(object sender, EventArgs e)
        {
            try
            {
                tabBankReceive.CssClass = "Clicked";
                tabBankPayment.CssClass = "Initial";
                tabJournalVoucher.CssClass = "Initial";
                tabContra.CssClass = "Initial";

                mainView.ActiveViewIndex = 0;

                TabClear(1);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabBankPayment_Click(object sender, EventArgs e)
        {
            try
            {
                tabBankReceive.CssClass = "Initial";
                tabBankPayment.CssClass = "Clicked";
                tabJournalVoucher.CssClass = "Initial";
                tabContra.CssClass = "Initial";

                mainView.ActiveViewIndex = 1;

                TabClear(2);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabJournalVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                tabBankReceive.CssClass = "Initial";
                tabBankPayment.CssClass = "Initial";
                tabJournalVoucher.CssClass = "Clicked";
                tabContra.CssClass = "Initial";
                rbJVDebit.Checked = true;
                mainView.ActiveViewIndex = 2;

                TabClear(3);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void tabContra_Click(object sender, EventArgs e)
        {
            try
            {
                tabBankReceive.CssClass = "Initial";
                tabBankPayment.CssClass = "Initial";
                tabJournalVoucher.CssClass = "Initial";
                tabContra.CssClass = "Clicked";
                rbContraBanktoCash.Checked = true;
                mainView.ActiveViewIndex = 3;

                TabClear(4);
            }
            catch (Exception ex)
            {
                //Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        #endregion

        #region Bank Receive
        protected void ddlBRInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlBRInstrument.SelectedValue == "Advice" || ddlBRInstrument.SelectedValue == "Adjustment")
                {
                    txtBRNo.Text = ddlBRInstrument.SelectedValue;
                }
                else
                {
                    txtBRNo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void btnBankReceiveAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (BRValidation() == true)
                {
                    string creditAccountNo = ddlBRCreditAccount.SelectedItem.ToString();
                    int creditAccountId = int.Parse(ddlBRCreditAccount.SelectedValue);
                    string debitAccountNo = string.Empty;
                    int debitAccountId = 0;
                    
                    decimal DebitAmount = 0;
                    hfTotalBRDebitAmount.Value = "0";
                    decimal CreditAmount = decimal.Parse(txtBankReceiveAmount.Text.Trim());
                    hfTotalBRCreditAmount.Value = !string.IsNullOrEmpty(hfTotalBRCreditAmount.Value) ?
                        (decimal.Parse(hfTotalBRCreditAmount.Value) + CreditAmount).ToString() : CreditAmount.ToString();


                    string Narration = txtBankReceiveNarration.Text;
                    hfBRNarration.Value = !string.IsNullOrEmpty(hfBRNarration.Value) ? (hfBRNarration.Value +", "+ Narration) : Narration;
                    
                    checkXmlItemData(creditAccountId.ToString());
                    if (CheckItem == 1)
                    {
                        CreateXml(creditAccountId.ToString(), creditAccountNo, debitAccountId.ToString(), debitAccountNo, DebitAmount.ToString(), 
                            CreditAmount.ToString(), Narration);
                        LoadBRGridwithXml();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Accounts already added.');", true);
                    }

                    BRClear();
                }


            }
            catch (Exception ex)
            {
                string sms = "Bank Receive Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnBankReceiveDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnBankReceiveSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (BRMasterValidation() == true)
                {
                    XmlDocument doc = new XmlDocument();
                    int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string accountNo = ddlBRAccountNo.SelectedItem.ToString();
                    int accountId = int.Parse(ddlBRAccountNo.SelectedValue);
                    string BRNumber = txtBRNo.Text.Trim();
                    DateTime Date = DateTime.ParseExact(txtBankReceiveDate.Text,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                    string Instrument = ddlBRInstrument.SelectedItem.ToString();
                    if (Instrument.Equals("Cheque"))
                        ysnCheque = 1;
                    else if (Instrument.Equals("DD"))
                        ysnDemandDraft = 1;
                    else if (Instrument.Equals("PO"))
                        ysnPayOrder = 1;
                    else if (Instrument.Equals("CDS"))
                        ysnDepositSlip = 1;
                    else if (Instrument.Equals("Advice"))
                        ysnAdvance = 1;
                    else if (Instrument.Equals("Adjustment"))
                        ysnAdjustment = 1;
                    else if (Instrument.Equals("Online"))
                        ysnOnline = 1;

                    decimal TotalBRDebitAmount = decimal.Parse(hfTotalBRDebitAmount.Value);
                    decimal TotalBRCreditAmount = decimal.Parse(hfTotalBRCreditAmount.Value);
                    string BRNarration = hfBRNarration.Value;
                    string ReceiveFrom = txtBankReceiveFrom.Text;

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }

                   string voucherno = acsacbll.InsertBankReceiveVoucher(1, UnitID, xmlString, accountId, accountNo, BRNumber, Date, ysnCheque, ysnDemandDraft,
                        ysnPayOrder, ysnDepositSlip, ysnAdvance, ysnAdjustment, ysnOnline, BRNarration, TotalBRDebitAmount,
                        TotalBRCreditAmount, ReceiveFrom, Enroll);
                    if (!string.IsNullOrEmpty(voucherno))
                    {
                        BRMasterClear();
                        gvBankReceive.DataSource = null;
                        gvBankReceive.DataBind();
                        string MsgBox = "Bank Receive Voucher Inserted Successfully. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ MsgBox + "');", true);
                    }
                    else
                    {
                        string MsgBox = "Bank Receive Voucher Insert Failed. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Receive From');", true);
                    //ddlBankReceiveFrom.Focus();
                    //return;
                }
            }
            catch (Exception ex)
            {
                string sms = "Bank Receive Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Bank Payment
        protected void ddlBankPaymentInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBankPaymentInstrument.SelectedValue == "Advice" || ddlBankPaymentInstrument.SelectedValue == "Adjustment")
                {
                    txtBankPaymentNo.Text = ddlBankPaymentInstrument.SelectedValue;
                }
                else
                {
                    txtBankPaymentNo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnBankPaymentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(BPValidation() == true)
                {
                    string creditAccountNo = string.Empty;
                    int creditAccountId = 0;
                    string debitAccountNo = ddlBankPaymentDebitAC.SelectedItem.ToString();
                    int debitAccountId = int.Parse(ddlBankPaymentDebitAC.SelectedValue);
                    decimal DebitAmount = decimal.Parse(txtBankPaymentAmount.Text.Trim());
                    hfBPDebitAmount.Value = !string.IsNullOrEmpty(hfBPDebitAmount.Value) ?
                            (decimal.Parse(hfBPDebitAmount.Value) + DebitAmount).ToString() : DebitAmount.ToString();
                    decimal CreditAmount = 0;
                    hfBPCreditAmount.Value = "0";
                    string Narration = txtBankPaymentNarration.Text;
                    hfBPNarration.Value = !string.IsNullOrEmpty(hfBPNarration.Value) ? (hfBPNarration.Value + ", " + Narration) : Narration;
                    string Instrument = ddlBankPaymentInstrument.SelectedItem.ToString();

                    checkXmlItemData(debitAccountId.ToString());
                    if (CheckItem == 1)
                    {
                        CreateXml(creditAccountId.ToString(), creditAccountNo, debitAccountId.ToString(), debitAccountNo, DebitAmount.ToString(), CreditAmount.ToString(), Narration);
                        LoadBPGridwithXml();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Accounts already added.');", true);
                    }

                    BPClear();
                }
                
            }
            catch (Exception ex)
            {
                string sms = "Bank Payment Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnBankPaymentDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnBankPaymentSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (BPMasterValidation() == true)
                {
                    XmlDocument doc = new XmlDocument();
                    int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string accountNo = ddlBankPaymentACNo.SelectedItem.ToString();
                    int accountId = int.Parse(ddlBankPaymentACNo.SelectedValue);
                    string BRNumber = txtBankPaymentNo.Text.Trim();
                    DateTime Date = DateTime.ParseExact(txtBankPaymentDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string Instrument = ddlBankPaymentInstrument.SelectedItem.ToString();
                    if (Instrument.Equals("Cheque"))
                        ysnCheque = 1;
                    else if (Instrument.Equals("Advice"))
                        ysnAdvance = 1;
                    else if (Instrument.Equals("Adjustment"))
                        ysnAdjustment = 1;

                    decimal TotalBPDebitAmount = decimal.Parse(hfBPDebitAmount.Value);
                    decimal TotalBPCreditAmount = decimal.Parse(hfBPCreditAmount.Value);
                    string BPNarration = hfBPNarration.Value;
                    string PaymentTo = txtBankPaymentPayTo.Text;

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }

                    string voucherno = acsacbll.InsertBankReceiveVoucher(2, UnitID, xmlString, accountId, accountNo, BRNumber, Date, ysnCheque, ysnDemandDraft,
                         ysnPayOrder, ysnDepositSlip, ysnAdvance, ysnAdjustment, ysnOnline, BPNarration, TotalBPDebitAmount,
                         TotalBPCreditAmount, PaymentTo, Enroll);
                    if (!string.IsNullOrEmpty(voucherno))
                    {
                        BPMasterClear();
                        gvBankPayment.DataSource = null;
                        gvBankPayment.DataBind();
                        string MsgBox = "Bank Payment Voucher Inserted Successfully. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                    }
                    else
                    {
                        string MsgBox = "Bank Payment Voucher Insert Failed. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Receive From');", true);
                    //ddlBankReceiveFrom.Focus();
                    //return;
                }
            }
            catch (Exception ex)
            {
                string sms = "Bank Payment Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Journal Voucher
        protected void rbJVDebit_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbJVCredit_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnJVAdd_Click(object sender, EventArgs e)
        {
            decimal DebitAmount = 0;
            decimal CreditAmount = 0;
            try
            {
                if(JVValidation() == true)
                {
                    string creditAccountNo = ddlJVAccountHead.SelectedItem.ToString();
                    int creditAccountId = int.Parse(ddlJVAccountHead.SelectedValue);
                    string debitAccountNo = string.Empty;
                    int debitAccountId = 0;

                    if (rbJVCredit.Checked == true)
                    {
                        DebitAmount = 0;
                        hfJVDebitAmount.Value = !string.IsNullOrEmpty(hfJVDebitAmount.Value) ?
                            (decimal.Parse(hfJVDebitAmount.Value) + DebitAmount).ToString() : DebitAmount.ToString();
                        CreditAmount = decimal.Parse(txtJVAmount.Text.Trim());
                        hfJVCreditAmount.Value = !string.IsNullOrEmpty(hfJVCreditAmount.Value) ?
                            (decimal.Parse(hfJVCreditAmount.Value) + CreditAmount).ToString() : CreditAmount.ToString();
                    }
                    else if (rbJVDebit.Checked == true)
                    {
                        DebitAmount = decimal.Parse(txtJVAmount.Text.Trim());
                        hfJVDebitAmount.Value = !string.IsNullOrEmpty(hfJVDebitAmount.Value) ?
                            (decimal.Parse(hfJVDebitAmount.Value) + DebitAmount).ToString() : DebitAmount.ToString();
                        CreditAmount = 0;
                        hfJVCreditAmount.Value = !string.IsNullOrEmpty(hfJVCreditAmount.Value) ?
                            (decimal.Parse(hfJVCreditAmount.Value) + CreditAmount).ToString() : CreditAmount.ToString();
                    }
                    string Narration = txtJVNarration.Text;
                    hfJVNarration.Value = !string.IsNullOrEmpty(hfJVNarration.Value) ? (hfJVNarration.Value + ", " + Narration) : Narration;

                    checkXmlItemData(debitAccountId.ToString());
                    if (CheckItem == 1)
                    {
                        CreateXml(creditAccountId.ToString(), creditAccountNo, debitAccountId.ToString(), debitAccountNo, DebitAmount.ToString(), CreditAmount.ToString(), Narration);
                        LoadJVGridwithXml();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Account Head already added.');", true);
                    }

                    JVClear();
                }
                

            }
            catch (Exception ex)
            {
                string sms = "Jurnal Voucher Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnJVDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnJVSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtJVDate.Text))
                {
                    XmlDocument doc = new XmlDocument();
                    int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string accountNo = "0";
                    int accountId = 0;
                    string BRNumber = "0";
                    DateTime Date = DateTime.ParseExact(txtJVDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    decimal TotalJVDebitAmount = decimal.Parse(hfJVDebitAmount.Value);
                    decimal TotalJVCreditAmount = decimal.Parse(hfJVCreditAmount.Value);
                    string JVNarration = hfJVNarration.Value;
                    string ReceiveFrom = string.Empty;

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }

                    string voucherno = acsacbll.InsertBankReceiveVoucher(3, UnitID, xmlString, accountId, accountNo, BRNumber, Date, ysnCheque, ysnDemandDraft,
                         ysnPayOrder, ysnDepositSlip, ysnAdvance, ysnAdjustment, ysnOnline, JVNarration, TotalJVDebitAmount,
                         TotalJVCreditAmount, ReceiveFrom, Enroll);
                    if (!string.IsNullOrEmpty(voucherno))
                    {
                        txtJVDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        ddlJVAccountHead.SelectedValue = "-1";
                        gvJurnalVoucher.DataSource = null;
                        gvJurnalVoucher.DataBind();
                        string MsgBox = "Journal Voucher Inserted Successfully. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                    }
                    else
                    {
                        string MsgBox = "Journal Voucher Insert Failed. Voucher Number: " + voucherno;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Journal Date');", true);
                    txtJVDate.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string sms = "Journal Voucher Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }

        #endregion

        #region Contra
        protected void ddlContraInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlContraInstrument.SelectedValue == "Advice" || ddlContraInstrument.SelectedValue == "Adjustment")
                {
                    txtContraNo.Text = ddlContraInstrument.SelectedValue;
                }
                else
                {
                    txtContraNo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void rbContraBanktoCash_CheckedChanged(object sender, EventArgs e)
        {
            lblContraInstrument.Visible = true;
            ddlContraInstrument.Visible = true;
            lblContraNo.Visible = true;
            txtContraNo.Visible = true;
            lblContraDate.Visible = true;
            txtContraDate.Visible = true;
            ContraClear();
            gvContra.DataSource = null;
            gvContra.DataBind();
            File.Delete(filePathForXML);
        }
        protected void rbContraCashtpoBank_CheckedChanged(object sender, EventArgs e)
        {
            lblContraInstrument.Visible = false;
            ddlContraInstrument.Visible = false;
            ddlContraInstrument.SelectedValue = "-1";
            lblContraNo.Visible = false;
            txtContraNo.Visible = false;
            lblContraDate.Visible = false;
            txtContraDate.Visible = false;
            ContraClear();
            gvContra.DataSource = null;
            gvContra.DataBind();
            File.Delete(filePathForXML);
        }
        protected void btnContraAdd_Click(object sender, EventArgs e)
        {
            decimal DebitAmount = 0;
            decimal CreditAmount = 0;
            string Instrument = string.Empty;
            string BRNumber = string.Empty;
            string Date = string.Empty;
            try
            {
                string accountNo = ddlContraACNo.SelectedItem.ToString();
                int accountId = int.Parse(ddlContraACNo.SelectedValue);
                string debitAccountNo = string.Empty;
                int debitAccountId = 0;
                if (rbContraBanktoCash.Checked == true)
                {
                    DebitAmount = decimal.Parse(txtContraAmount.Text.Trim());
                    hfContraDebitAmount.Value = !string.IsNullOrEmpty(hfContraDebitAmount.Value) ?
                            (decimal.Parse(hfContraDebitAmount.Value) + DebitAmount).ToString() : DebitAmount.ToString();
                    CreditAmount = 0;
                    hfContraCreditAmount.Value = CreditAmount.ToString();
                }
                else if (rbContraCashtpoBank.Checked == true)
                {
                    DebitAmount = 0;
                    hfContraDebitAmount.Value = DebitAmount.ToString();
                    CreditAmount = decimal.Parse(txtContraAmount.Text.Trim());
                    hfContraCreditAmount.Value = !string.IsNullOrEmpty(hfContraCreditAmount.Value) ?
                            (decimal.Parse(hfContraCreditAmount.Value) + CreditAmount).ToString() : CreditAmount.ToString();
                }

                string Narration = txtContraNarration.Text;
                hfContraNarration.Value = !string.IsNullOrEmpty(hfContraNarration.Value) ? (hfContraNarration.Value + ", " + Narration) : Narration;

                // checkXmlItemData(debitAccountId.ToString());
                if (CheckItem == 1)
                {
                    CreateXml(accountId.ToString(), accountNo, debitAccountId.ToString(), debitAccountNo, DebitAmount.ToString(), CreditAmount.ToString(), Narration);
                    LoadContraGridwithXml();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Accounts already added.');", true);
                }

                ContraClear();

            }
            catch (Exception ex)
            {
                string sms = "Contra Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnContraDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnContraSubmit_Click(object sender, EventArgs e)
        {
            string Instrument = string.Empty;
            string BRNumber = string.Empty;
            DateTime Date = DateTime.MinValue;
            try
            {
                XmlDocument doc = new XmlDocument();
                int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string accountNo = ddlContraACNo.SelectedItem.ToString();
                int accountId = int.Parse(ddlContraACNo.SelectedValue);

                if (rbContraBanktoCash.Checked == true)
                {
                    Instrument = ddlContraInstrument.SelectedItem.ToString();
                    if (Instrument.Equals("Cheque"))
                        ysnCheque = 1;
                    else if (Instrument.Equals("Advice"))
                        ysnAdvance = 1;
                    else if (Instrument.Equals("Adjustment"))
                        ysnAdjustment = 1;

                    BRNumber = txtContraNo.Text;
                    Date = DateTime.ParseExact(txtContraDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else if (rbContraCashtpoBank.Checked == true)
                {
                    BRNumber = "N/A";
                }

                decimal TotalContraDebitAmount = !string.IsNullOrEmpty(hfContraDebitAmount.Value) ? decimal.Parse(hfContraDebitAmount.Value) : 0;
                decimal TotalContraCreditAmount = !string.IsNullOrEmpty(hfContraCreditAmount.Value) ? decimal.Parse(hfContraCreditAmount.Value) : 0;
                string ContraNarration = hfBPNarration.Value;
                string ChecqBarier = string.Empty;

                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }

                string voucherno = acsacbll.InsertBankReceiveVoucher(4, UnitID, xmlString, accountId, accountNo, BRNumber, Date, ysnCheque, ysnDemandDraft,
                     ysnPayOrder, ysnDepositSlip, ysnAdvance, ysnAdjustment, ysnOnline, ContraNarration, TotalContraDebitAmount,
                     TotalContraCreditAmount, ChecqBarier, Enroll);
                if (!string.IsNullOrEmpty(voucherno))
                {
                    ContraMasterClear();
                    gvContra.DataSource = null;
                    gvContra.DataBind();
                    string MsgBox = "Contra Voucher Inserted Successfully. Voucher Number: " + voucherno;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                }
                else
                {
                    string MsgBox = "Contra Voucher Insert Failed. Voucher Number: " + voucherno;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + MsgBox + "');", true);
                }


            }
            catch (Exception ex)
            {
                string sms = "Contra Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #endregion

        #region Method
        private void FillDropDown()
        {
            DataTable dtBRAC = new DataTable();
            DataTable dtBPAC = new DataTable();
            DataTable dtContraAC = new DataTable();
            DataTable dtBRCA = new DataTable();
            DataTable dtBPDA = new DataTable();
            DataTable dtJVAH = new DataTable();
            ArrayList allInstrumentList = new ArrayList();
            ArrayList someInstrumentList = new ArrayList();
            try
            {
                UnitId = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                #region List
                allInstrumentList.Add("Cheque");
                allInstrumentList.Add("Advice");
                allInstrumentList.Add("Adjustment");
                allInstrumentList.Add("DD");
                allInstrumentList.Add("PO");
                allInstrumentList.Add("CDS");
                allInstrumentList.Add("Online");
                someInstrumentList.Add("Cheque");
                someInstrumentList.Add("Advice");
                someInstrumentList.Add("Adjustment");
                #endregion

                dtBRAC = acsacbll.GetBRAccountsNumber(UnitId, Enroll);
                if (dtBRAC != null && dtBRAC.Rows.Count > 0)
                {
                    ddlBRAccountNo.DataSource = dtBRAC;
                    ddlBRAccountNo.DataTextField = "strAccName";
                    ddlBRAccountNo.DataValueField = "intBankAccID";
                    ddlBRAccountNo.DataBind();
                }
                dtBPAC = acsacbll.GetBPAccountsNumber(UnitId, Enroll);
                if (dtBPAC != null && dtBPAC.Rows.Count > 0)
                {
                    ddlBankPaymentACNo.DataSource = dtBPAC;
                    ddlBankPaymentACNo.DataTextField = "strAccName";
                    ddlBankPaymentACNo.DataValueField = "intBankAccID";
                    ddlBankPaymentACNo.DataBind();
                }

                dtContraAC = acsacbll.GetContraAccountsNumber(UnitId, Enroll);
                if (dtContraAC != null && dtContraAC.Rows.Count > 0)
                {
                    ddlContraACNo.DataSource = dtContraAC;
                    ddlContraACNo.DataTextField = "strAccName";
                    ddlContraACNo.DataValueField = "intBankAccID";
                    ddlContraACNo.DataBind();
                }

                dtBRCA = acsacbll.GetBRCreditAccountsNo(UnitId, Enroll);
                if (dtBRCA != null && dtBRCA.Rows.Count > 0)
                {
                    ddlBRCreditAccount.DataSource = dtBRCA;
                    ddlBRCreditAccount.DataTextField = "strAccName";
                    ddlBRCreditAccount.DataValueField = "intAccID";
                    ddlBRCreditAccount.DataBind();
                }

                dtBPDA = acsacbll.GetBPDebitAccountsNo(UnitId, Enroll);
                if (dtBPDA != null && dtBPDA.Rows.Count > 0)
                {
                    ddlBankPaymentDebitAC.DataSource = dtBPDA;
                    ddlBankPaymentDebitAC.DataTextField = "strAccName";
                    ddlBankPaymentDebitAC.DataValueField = "intAccID";
                    ddlBankPaymentDebitAC.DataBind();
                }

                dtJVAH = acsacbll.GetJVAccountsHead(UnitId, Enroll);
                if (dtJVAH != null && dtJVAH.Rows.Count > 0)
                {
                    ddlJVAccountHead.DataSource = dtBPDA;
                    ddlJVAccountHead.DataTextField = "strAccName";
                    ddlJVAccountHead.DataValueField = "intAccID";
                    ddlJVAccountHead.DataBind();
                }

                ddlBRInstrument.DataSource = allInstrumentList;
                ddlBRInstrument.DataBind();
                ddlBRInstrument.Items.Insert(0, new ListItem("--- Select Instrument---", "-1"));
                ddlBankPaymentInstrument.DataSource = someInstrumentList;
                ddlBankPaymentInstrument.DataBind();
                ddlBankPaymentInstrument.Items.Insert(0, new ListItem("--- Select Instrument---", "-1"));
                ddlContraInstrument.DataSource = someInstrumentList;
                ddlContraInstrument.DataBind();
                ddlContraInstrument.Items.Insert(0, new ListItem("--- Select Instrument---", "-1"));

                ddlBRAccountNo.Items.Insert(0, new ListItem("--- Select A/C No---", "-1"));
                ddlBankPaymentACNo.Items.Insert(0, new ListItem("--- Select A/C No---", "-1"));
                ddlContraACNo.Items.Insert(0, new ListItem("--- Select A/C No---", "-1"));
                ddlBRCreditAccount.Items.Insert(0, new ListItem("--- Select Credit A/C No---", "-1"));
                ddlBankPaymentDebitAC.Items.Insert(0, new ListItem("--- Select Debit A/C No---", "-1"));
                ddlJVAccountHead.Items.Insert(0, new ListItem("--- Select A/C Head---", "-1"));

                //ddlBankReceiveFrom.Items.Insert(0, new ListItem("--- Select Receive From ---", "-1"));
                //ddlBankPaymentPayTo.Items.Insert(0, new ListItem("--- Select Pay To ---", "-1"));

            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void CreateXml(string creditaccountid, string creditaccountname, string debitaccountid,
            string debitaccountname, string debitamount, string creditamount, string narration)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SubAcc");
                XmlNode addItem = CreateItemNode(doc, creditaccountid, creditaccountname, debitaccountid, debitaccountname,
                    debitamount, creditamount, narration);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SubAcc");
                XmlNode addItem = CreateItemNode(doc, creditaccountid, creditaccountname, debitaccountid, debitaccountname,
                    debitamount, creditamount, narration);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

        }

        private XmlNode CreateItemNode(XmlDocument doc, string creditaccountid, string creditaccountname,
            string debitaccountid, string debitaccountname, string debitamount, string creditamount,string narration)
        {
            XmlNode node = doc.CreateElement("subAccount");

            XmlAttribute CreditAccountId = doc.CreateAttribute("creditaccountid");
            CreditAccountId.Value = creditaccountid;
            XmlAttribute CreditAccountName = doc.CreateAttribute("creditaccountname");
            CreditAccountName.Value = creditaccountname;
            XmlAttribute DebitAccountId = doc.CreateAttribute("debitaccountid");
            DebitAccountId.Value = debitaccountid;
            XmlAttribute DebitAccountName = doc.CreateAttribute("debitaccountname");
            DebitAccountName.Value = debitaccountname;
            XmlAttribute DebitAmount = doc.CreateAttribute("debitamount");
            DebitAmount.Value = debitamount;
            XmlAttribute CreditAmount = doc.CreateAttribute("creditamount");
            CreditAmount.Value = creditamount;
            XmlAttribute Narration = doc.CreateAttribute("narration");
            Narration.Value = narration;

            node.Attributes.Append(CreditAccountId);
            node.Attributes.Append(CreditAccountName);
            node.Attributes.Append(DebitAccountId);
            node.Attributes.Append(DebitAccountName);
            node.Attributes.Append(DebitAmount);
            node.Attributes.Append(CreditAmount);
            node.Attributes.Append(Narration);
           
            return node;
        }
        private void checkXmlItemData(string accountID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (accountID == (ds.Tables[0].Rows[i].ItemArray[2].ToString()))
                    {
                        CheckItem = 0;
                        break;
                    }
                    else
                    {
                        CheckItem = 1;
                    }
                }
            }
            catch { }
        }

        
        private void LoadBRGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvBankReceive.DataSource = ds;
                }
                else
                {
                    gvBankReceive.DataSource = "";
                }
                gvBankReceive.DataBind();
            }
            catch { }
        }
        private void LoadBPGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvBankPayment.DataSource = ds;
                }
                else
                {
                    gvBankPayment.DataSource = "";
                }
                gvBankPayment.DataBind();
            }
            catch { }
        }
       
        private void LoadJVGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvJurnalVoucher.DataSource = ds;
                }
                else
                {
                    gvJurnalVoucher.DataSource = "";
                }
                gvJurnalVoucher.DataBind();
            }
            catch { }
        }
        private void LoadContraGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SubAcc");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SubAcc>" + xmlString + "</SubAcc>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvContra.DataSource = ds;
                }
                else
                {
                    gvContra.DataSource = "";
                }
                gvContra.DataBind();
            }
            catch { }
        }

        private void BRClear()
        {
            ddlBRCreditAccount.SelectedValue = "-1";
            txtBankReceiveAmount.Text = string.Empty;
            txtBankReceiveNarration.Text = string.Empty;
        }

        

        private void BRMasterClear()
        {
            ddlBRAccountNo.SelectedValue = "-1";
            ddlBRInstrument.SelectedValue = "-1";
            txtBRNo.Text = string.Empty;
            txtBankReceiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtBankReceiveFrom.Text = string.Empty;
            hfTotalBRCreditAmount.Value = string.Empty;
            hfTotalBRDebitAmount.Value = string.Empty;
            hfBRNarration.Value = string.Empty;
        }

        private void BPClear()
        {
            
            ddlBankPaymentDebitAC.SelectedValue = "-1";
            txtBankPaymentAmount.Text = string.Empty;
            txtBankPaymentNarration.Text = string.Empty;
        }
        private void BPMasterClear()
        {
            ddlBankPaymentACNo.SelectedValue = "-1";
            ddlBankPaymentInstrument.SelectedValue = "-1";
            txtBankPaymentNo.Text = string.Empty;
            txtBankPaymentDate.Text = string.Empty;
            txtBankPaymentPayTo.Text = string.Empty;
            txtBankPaymentAmount.Text = string.Empty;
            hfBPDebitAmount.Value = string.Empty;
            hfBPCreditAmount.Value = string.Empty;
            hfBPNarration.Value = string.Empty;
        }

        private void JVClear()
        {
            //ddlJVAccountHead.SelectedValue = "-1";
            txtJVAmount.Text = string.Empty;
            txtJVNarration.Text = string.Empty;
        }


        private void ContraClear()
        {
           // ddlContraACNo.SelectedValue = "-1";
            //ddlContraInstrument.SelectedValue = "-1";
           // txtContraNo.Text = string.Empty;
            //txtContraDate.Text = string.Empty;
            txtContraAmount.Text = string.Empty;
            txtContraNarration.Text = string.Empty;
        }
        private void ContraMasterClear()
        {
            ddlContraACNo.SelectedValue = "-1";
            ddlContraInstrument.SelectedValue = "-1";
            txtContraNo.Text = string.Empty;
            txtContraDate.Text = string.Empty;

            gvContra.DataSource = null;
            gvContra.DataBind();
        }

        private bool BRMasterValidation()
        {
            if (ddlBRAccountNo.SelectedValue == "-1")
            {
                ddlBRAccountNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Bank Account Number');", true);
                return false;
            }
            if (ddlBRInstrument.SelectedValue == "-1")
            {
                ddlBRInstrument.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select an Instrument');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBRNo.Text) && txtBRNo.Text.Length > 0)
            {
                txtBRNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Bank Receive No.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankReceiveDate.Text) && txtBankReceiveDate.Text.Length > 0)
            {
                txtBankReceiveDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Receive Date.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankReceiveFrom.Text) && txtBankReceiveFrom.Text.Length > 0)
            {
                txtBankReceiveFrom.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Receive From.');", true);
                return false;
            }
            return true;
        }
        private bool BRValidation()
        {
            if (ddlBRCreditAccount.SelectedValue == "-1")
            {
                ddlBRCreditAccount.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Credit A/C. ');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankReceiveAmount.Text) && txtBankReceiveAmount.Text.Length > 0)
            {
                txtBankReceiveAmount.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Credit Amount');", true);
                return false;
            }
            
            return true;
        }

        private bool BPMasterValidation()
        {
            if (ddlBankPaymentACNo.SelectedValue == "-1")
            {
                ddlBankPaymentACNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Bank Account Number');", true);
                return false;
            }
            if (ddlBankPaymentInstrument.SelectedValue == "-1")
            {
                ddlBankPaymentInstrument.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select an Instrument');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankPaymentNo.Text) && txtBankPaymentNo.Text.Length > 0)
            {
                txtBankPaymentNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Bank Payment No.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankPaymentDate.Text) && txtBankPaymentDate.Text.Length > 0)
            {
                txtBankPaymentDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Payment Date.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankPaymentPayTo.Text) && txtBankPaymentPayTo.Text.Length > 0)
            {
                txtBankPaymentPayTo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Payment To.');", true);
                return false;
            }
            return true;
        }
        private bool BPValidation()
        {
            if (ddlBankPaymentDebitAC.SelectedValue == "-1")
            {
                ddlBankPaymentDebitAC.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Debit A/C. ');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBankPaymentAmount.Text) && txtBankPaymentAmount.Text.Length > 0)
            {
                txtBankPaymentAmount.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Debit Amount');", true);
                return false;
            }

            return true;
        }
        private bool JVValidation()
        {
            if (ddlJVAccountHead.SelectedValue == "-1")
            {
                ddlJVAccountHead.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select A/C Head. ');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtJVAmount.Text) && txtJVAmount.Text.Length > 0)
            {
                txtJVAmount.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Debit/Credit Amount');", true);
                return false;
            }

            return true;
        }

        private void TabClear(int tab)
        {
            if (tab == 1)
            {
                BPClear();
                BPMasterClear();
                gvBankPayment.DataSource = null;
                gvBankPayment.DataBind();
                JVClear();
                gvJurnalVoucher.DataSource = null;
                gvJurnalVoucher.DataBind();
                ContraClear();
                gvContra.DataSource = null;
                gvContra.DataBind();
            }
            else if (tab == 2)
            {
                BRClear();
                BRMasterClear();
                gvBankReceive.DataSource = null;
                gvBankReceive.DataBind();
                JVClear();
                gvJurnalVoucher.DataSource = null;
                gvJurnalVoucher.DataBind();
                ContraClear();
                gvContra.DataSource = null;
                gvContra.DataBind();
            }
            else if (tab == 3)
            {
                BRClear();
                BRMasterClear();
                gvBankReceive.DataSource = null;
                gvBankReceive.DataBind();
                BPClear();
                BPMasterClear();
                gvBankPayment.DataSource = null;
                gvBankPayment.DataBind();
                ContraClear();
                gvContra.DataSource = null;
                gvContra.DataBind();
            }
            else if (tab == 4)
            {
                BRClear();
                BRMasterClear();
                gvBankReceive.DataSource = null;
                gvBankReceive.DataBind();
                BPClear();
                BPMasterClear();
                gvBankPayment.DataSource = null;
                gvBankPayment.DataBind();
                JVClear();
                gvJurnalVoucher.DataSource = null;
                gvJurnalVoucher.DataBind();
            }
            File.Delete(filePathForXML);
        }
        #endregion


    }
}
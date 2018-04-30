using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class BankPay : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillApp = new Billing_BLL(); Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intDept, intType, intPartyType, intAccID, intCountPVoucher, intPOID, intBankID;
        string unitid, billid, entrycode, party, bank, bankacc, instrument;
        string accid, accname, narration, debit, credit, strAccName, strNarrationBank, strNarrationJournal;
        string filePathForXML; string xmlString = ""; string xml;
        decimal monApproveAmount, monTotalAdvance, monLedgerBalance, monNetPay, monVoucherTotal;
        bool ysnAdvance, ysnPurchase, ysnCreditor, ysnAll, ysnBillReg;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/PaymentModule/Data/BPVoucher_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {                
                File.Delete(filePathForXML); dgvReportForPaymentV.DataSource = ""; dgvReportForPaymentV.DataBind();
                hdnBillUnitID.Value = Request.QueryString["unitid"];
                hdnBillID.Value = Request.QueryString["billid"];
                entrycode = Request.QueryString["entrycode"];
                party = Request.QueryString["party"];
                hdnBillType.Value = Request.QueryString["billtypeid"];
                txtEntryCode.Text = entrycode;
                txtParty.Text = party;
                hdnBank.Value = Request.QueryString["bank"]; 
                hdnBankAcc.Value = Request.QueryString["bankacc"]; 
                hdnInstrument.Value = Request.QueryString["instrument"]; 
                
                dt = new DataTable();
                dt = objBillApp.GetBillInfoForBPVoucher(int.Parse(hdnBillID.Value));
                if (dt.Rows.Count > 0)
                {
                    intPartyType = int.Parse(dt.Rows[0]["intPartyType"].ToString());
                    try { intPOID = int.Parse(dt.Rows[0]["strReff_PO"].ToString()); }
                    catch { intPOID = 0; }
                    monApproveAmount = decimal.Parse(dt.Rows[0]["monApprove"].ToString());
                    monVoucherTotal = decimal.Parse(dt.Rows[0]["monVoucherTotal"].ToString());
                    monTotalAdvance = decimal.Parse(dt.Rows[0]["monAdvanceTotal"].ToString());
                    intAccID = int.Parse(dt.Rows[0]["intPartyCOA"].ToString());
                    strAccName = dt.Rows[0]["strPartyCOA"].ToString();
                    intCountPVoucher = int.Parse(dt.Rows[0]["intCountPVoucher"].ToString());
                    monLedgerBalance = decimal.Parse(dt.Rows[0]["monLedgerBalance"].ToString());
                    monNetPay = decimal.Parse(dt.Rows[0]["monNetPay"].ToString());
                }

                txtApproveAmount.Text = monApproveAmount.ToString();
                txtPreAdvance.Text = monTotalAdvance.ToString();
                txtVoucherIssued.Text = monVoucherTotal.ToString();
                
                try
                {
                    dt = new DataTable();
                    dt = objBillApp.GetBankInfoByUnitID(int.Parse(hdnBillUnitID.Value));
                    ddlBank.DataTextField = "strBankName";
                    ddlBank.DataValueField = "intBankID";
                    ddlBank.DataSource = dt;
                    ddlBank.DataBind();
                }
                catch { }

                try
                {
                    intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = objVoucher.GetAccountList(int.Parse(hdnBillUnitID.Value), intBankID);
                    if (dt.Rows.Count > 0)
                    {
                        ddlACNumber.DataTextField = "strBankAccount";
                        ddlACNumber.DataValueField = "intAccountID";
                        ddlACNumber.DataSource = dt;
                        ddlACNumber.DataBind();
                    }
                }
                catch { }

                try
                {
                    dt = new DataTable();
                    dt = objBillApp.GetCostCenter(int.Parse(hdnBillUnitID.Value));
                    ddlCostCenter.DataTextField = "strCCName";
                    ddlCostCenter.DataValueField = "intCostCenterID";
                    ddlCostCenter.DataSource = dt;
                    ddlCostCenter.DataBind();
                }
                catch { }

                try
                {
                    dt = new DataTable();
                    dt = objBillApp.GetPayToList(int.Parse(hdnBillID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlPayTo.DataTextField = "strMasterAccName";
                        ddlPayTo.DataValueField = "intMasterAccID";
                        ddlPayTo.DataSource = dt;
                        ddlPayTo.DataBind();
                    }
                    else
                    {
                        ddlPayTo.SelectedValue = txtParty.Text;
                    }
                }
                catch { }

                try
                {
                    if(hdnBillType.Value == "1") // 'FOR ADVANCE PAYMENT
                    {
                        if(intPartyType == 1)
                        {
                            ysnCreditor = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlDebitAc.DataTextField = "strAccName";
                            ddlDebitAc.DataValueField = "intAccID";
                            ddlDebitAc.DataSource = dt;
                            ddlDebitAc.DataBind();
                        }
                        else
                        {
                            ysnPurchase = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlDebitAc.DataTextField = "strAccName";
                            ddlDebitAc.DataValueField = "intAccID";
                            ddlDebitAc.DataSource = dt;
                            ddlDebitAc.DataBind();
                        }
                        
                        if(intPOID == 0)
                        {
                            txtNarration.Text = "Being the amount paid to " + party + " in advance against Code: " + entrycode;
                        }
                        else
                        {
                            txtNarration.Text = "Being the amount paid to " + party + " in advance against Code: " + entrycode + ", PO NO: " + intPOID.ToString();
                        }
                        txtAmount.Text = monApproveAmount.ToString();
                        ddlBank.SelectedValue = hdnBank.Value;
                        ddlACNumber.SelectedValue = hdnBankAcc.Value;
                        ddlInstrument.SelectedValue = hdnInstrument.Value;
                        ddlDebitAc.SelectedItem.Text = strAccName;                        
                    }
                    else if (hdnBillType.Value == "2") // 'FOR PAYMENT AGAINST CREDIT PURCHASE BILL
                    {
                        if (intPartyType == 1)
                        {
                            if(intCountPVoucher == 0)
                            {
                                ysnPurchase = true;
                                dt = new DataTable();
                                dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                                ddlDebitAc.DataTextField = "strAccName";
                                ddlDebitAc.DataValueField = "intAccID";
                                ddlDebitAc.DataSource = dt;
                                ddlDebitAc.DataBind();
                            }
                            else if(intCountPVoucher > 0)
                            {
                                ysnCreditor = true;
                                dt = new DataTable();
                                dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                                ddlDebitAc.DataTextField = "strAccName";
                                ddlDebitAc.DataValueField = "intAccID";
                                ddlDebitAc.DataSource = dt;
                                ddlDebitAc.DataBind();
                            }
                        }
                        else
                        {
                            ysnPurchase = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlDebitAc.DataTextField = "strAccName";
                            ddlDebitAc.DataValueField = "intAccID";
                            ddlDebitAc.DataSource = dt;
                            ddlDebitAc.DataBind();
                        }
                        
                        if(intPOID == 0)
                        {
                            strNarrationBank = "Being the amount paid to " + party + " against Code: " + entrycode;
                            strNarrationJournal = "Being the amount Adjusted to " + party + " against Code: " + entrycode;
                        }
                        else
                        {
                            strNarrationBank = "Being the amount paid to " + party + " against Code: " + entrycode + ", PO NO: " + intPOID.ToString();
                            strNarrationJournal = "Being the amount Adjusted to " + party + " against Code: " + entrycode + ", PO NO: " + intPOID.ToString();
                        }

                        txtAmount.Text = monApproveAmount.ToString();
                        ddlBank.SelectedValue = hdnBank.Value;
                        ddlACNumber.SelectedValue = hdnBankAcc.Value;
                        ddlInstrument.SelectedValue = hdnInstrument.Value;
                        ddlDebitAc.SelectedItem.Text = strAccName;
                    }
                    else if (hdnBillType.Value == "3") // 'FOR PAYMENT AGAINST CASH PURCHASE BILL
                    {
                        if (intPartyType == 1)
                        {
                            ysnCreditor = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlDebitAc.DataTextField = "strAccName";
                            ddlDebitAc.DataValueField = "intAccID";
                            ddlDebitAc.DataSource = dt;
                            ddlDebitAc.DataBind();
                        }
                        else
                        {
                            ysnPurchase = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlDebitAc.DataTextField = "strAccName";
                            ddlDebitAc.DataValueField = "intAccID";
                            ddlDebitAc.DataSource = dt;
                            ddlDebitAc.DataBind();
                        }
                    }
                }
                catch { }                
            }
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                dt = new DataTable();
                dt = objVoucher.GetAccountList(int.Parse(hdnBillUnitID.Value), intBankID);
                if (dt.Rows.Count > 0)
                {
                    ddlACNumber.DataTextField = "strBankAccount";
                    ddlACNumber.DataValueField = "intAccountID";
                    ddlACNumber.DataSource = dt;
                    ddlACNumber.DataBind();
                }
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                accid = ddlDebitAc.SelectedValue.ToString();
                accname = ddlDebitAc.SelectedItem.ToString();
                narration = txtNarration.Text;
                debit = txtAmount.Text;
                credit = "0";

                if (accname == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Account Head Selected.');", true); return;
                }
                try
                {
                    if (int.Parse(txtAmount.Text) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Amount cannot be blank.');", true); return;
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Amount cannot be blank.');", true); return; }

                CreateVoucherXml(accid, accname, narration, debit, credit);
            }
            catch { }
        }

        private void CreateVoucherXml(string accid, string accname, string narration, string debit, string credit)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("BPVoucher");
                XmlNode addItem = CreateItemNode(doc, accid, accname, narration, debit, credit);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BPVoucher");
                XmlNode addItem = CreateItemNode(doc, accid, accname, narration, debit, credit); ;
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
            XmlNode dSftTm = doc.SelectSingleNode("BPVoucher");
            xmlString = dSftTm.InnerXml;
            xmlString = "<BPVoucher>" + xmlString + "</BPVoucher>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvReportForPaymentV.DataSource = ds; }
            else { dgvReportForPaymentV.DataSource = ""; }
            dgvReportForPaymentV.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string accid, string accname, string narration, string debit, string credit)
        {
            XmlNode node = doc.CreateElement("BPVoucher");

            XmlAttribute Accid = doc.CreateAttribute("accid");
            Accid.Value = accid;
            XmlAttribute Accname = doc.CreateAttribute("accname");
            Accname.Value = accname;
            XmlAttribute Narration = doc.CreateAttribute("narration");
            Narration.Value = narration;
            XmlAttribute Debit = doc.CreateAttribute("debit");
            Debit.Value = debit;
            XmlAttribute Credit = doc.CreateAttribute("credit");
            Credit.Value = credit;

            node.Attributes.Append(Accid);
            node.Attributes.Append(Accname);
            node.Attributes.Append(Narration);
            node.Attributes.Append(Debit);
            node.Attributes.Append(Credit);
            return node;
        }
        protected void dgvReportForPaymentV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("BPVoucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<BPVoucher>" + xmlString + "</BPVoucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvReportForPaymentV.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvReportForPaymentV.DataSource;
                dsGrid.Tables[0].Rows[dgvReportForPaymentV.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvReportForPaymentV.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvReportForPaymentV.DataSource = ""; dgvReportForPaymentV.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }























    }
}
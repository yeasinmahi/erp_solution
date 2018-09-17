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
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.PaymentModule
{
    public partial class BankPay : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/BankPay.aspx";
        string stop = "stopping PaymentModule/BankPay.aspx";

        Billing_BLL objBillApp = new Billing_BLL(); Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intDept, intType, intPartyType, intAccID, intCountPVoucher, intPOID, intBankID;
        string unitid, billid, entrycode, party, bank, bankacc, instrument;
        string accid, accname, narration, debit, credit, strAccName, strNarrationBank, strNarrationJournal;
        string filePathForXML; string xmlString = ""; string xml;
        decimal monApproveAmount, monTotalAdvance, monLedgerBalance, monNetPay, monVoucherTotal;
        bool ysnAdvance, ysnPurchase, ysnCreditor, ysnAll, ysnBillReg;

        int intUnitID, intCCID, intBank, intBankAcc, intUserID, intBillID;
        string strCCName, strInstrument, strPayTo, strBillCode, strNarration, strInstrumentNo;
        DateTime dteInstrumentDate, dteVoucherDate;

        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BankPay.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/PaymentModule/Data/BPVoucher_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
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
                    txtDate.Text = DateTime.Parse(Request.QueryString["vdate"]).ToString("yyyy-MM-dd");

                    dt = new DataTable();
                    dt = objBillApp.GetBillInfoForBPVoucher(int.Parse(hdnBillID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        intPartyType = int.Parse(dt.Rows[0]["intPartyType"].ToString());
                        try { intPOID = int.Parse(dt.Rows[0]["strReff_PO"].ToString()); }
                        catch { intPOID = 0; }
                        monApproveAmount = Math.Round(decimal.Parse(dt.Rows[0]["monApprove"].ToString()), 2);
                        monVoucherTotal = Math.Round(decimal.Parse(dt.Rows[0]["monVoucherTotal"].ToString()), 2);
                        monTotalAdvance = Math.Round(decimal.Parse(dt.Rows[0]["monAdvanceTotal"].ToString()), 2);
                        intAccID = int.Parse(dt.Rows[0]["intPartyCOA"].ToString());
                        strAccName = dt.Rows[0]["strPartyCOA"].ToString();
                        intCountPVoucher = int.Parse(dt.Rows[0]["intCountPVoucher"].ToString());
                        monLedgerBalance = Math.Round(decimal.Parse(dt.Rows[0]["monLedgerBalance"].ToString()), 2);
                        monNetPay = Math.Round(decimal.Parse(dt.Rows[0]["monNetPay"].ToString()), 2);
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

                    intBankAcc = int.Parse(ddlACNumber.SelectedValue.ToString());
                    strInstrument = ddlInstrument.SelectedItem.ToString();

                    dt = new DataTable();
                    dt = objVoucher.GetChequeOrAdvice(intBankAcc, int.Parse(hdnUnit.Value), strInstrument);
                    if (dt.Rows.Count > 0)
                    {
                        txtNo.Text = dt.Rows[0]["strCode"].ToString();
                    }
                    else
                    {
                        txtNo.Text = "";
                    }

                    try
                    {
                        if (hdnBillType.Value == "1") // 'FOR ADVANCE PAYMENT
                        {
                            if (intAccID == 0)
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
                                    dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                                    ddlDebitAc.DataTextField = "strAccName";
                                    ddlDebitAc.DataValueField = "intAccID";
                                    ddlDebitAc.DataSource = dt;
                                    ddlDebitAc.DataBind();
                                }
                            }
                            else
                            {
                                ListItem item1 = new ListItem(strAccName, intAccID.ToString());
                                ddlDebitAc.Items.Add(item1);
                            }

                            if (intPOID == 0)
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
                            if (intAccID == 0)
                            {
                                if (intPartyType == 1)
                                {
                                    if (intCountPVoucher == 0)
                                    {
                                        ysnPurchase = true;
                                        dt = new DataTable();
                                        dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                                        ddlDebitAc.DataTextField = "strAccName";
                                        ddlDebitAc.DataValueField = "intAccID";
                                        ddlDebitAc.DataSource = dt;
                                        ddlDebitAc.DataBind();
                                    }
                                    else if (intCountPVoucher > 0)
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
                                    dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                                    ddlDebitAc.DataTextField = "strAccName";
                                    ddlDebitAc.DataValueField = "intAccID";
                                    ddlDebitAc.DataSource = dt;
                                    ddlDebitAc.DataBind();
                                }
                            }
                            else
                            {
                                ListItem item1 = new ListItem(strAccName, intAccID.ToString());
                                ddlDebitAc.Items.Add(item1);
                            }

                            if (intPOID == 0)
                            {
                                strNarrationBank = "Being the amount paid to " + party + " against Code: " + entrycode;
                                txtNarration.Text = strNarrationBank;
                                strNarrationJournal = "Being the amount Adjusted to " + party + " against Code: " + entrycode;
                            }
                            else
                            {
                                strNarrationBank = "Being the amount paid to " + party + " against Code: " + entrycode + ", PO NO: " + intPOID.ToString();
                                txtNarration.Text = strNarrationBank;
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
                            if (intAccID == 0)
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
                            else
                            {
                                ListItem item1 = new ListItem(strAccName, intAccID.ToString());
                                ddlDebitAc.Items.Add(item1);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var efd = log.GetFlogDetail(stop, location, "Show", ex);
                        Flogger.WriteError(efd);
                    }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                    Flogger.WriteError(efd);
                }
            }                

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
            
        }

        protected void ddlInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            intBankAcc = int.Parse(ddlACNumber.SelectedValue.ToString());
            strInstrument = ddlInstrument.SelectedItem.ToString();

            dt = new DataTable();
            dt = objVoucher.GetChequeOrAdvice(intBankAcc, int.Parse(hdnUnit.Value), strInstrument);
            if (dt.Rows.Count > 0)
            {
                txtNo.Text = dt.Rows[0]["strCode"].ToString();
            }
            else
            {
                txtNo.Text = "";
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

                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = ddlDebitAc.SelectedItem.ToString().Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    accname = temp1[0].ToString();
                }
                catch { accname = ""; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select For Loan.');", true); return; }



                narration = txtNarration.Text;
                debit = txtAmount.Text;
                credit = "0";

                if (accname == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Account Head Selected.');", true); return;
                }
                try
                {
                    if (decimal.Parse(txtAmount.Text) <= 0)
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

        protected decimal debitgrandtotal = 0;
        protected decimal creditgrandtotal = 0;
        protected void dgvReportForPaymentV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    debitgrandtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblDebit")).Text);
                    creditgrandtotal += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblCredit")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        protected void btnSaveBP_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSaveBP_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BankPay.aspx btnSaveBP_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intUnitID = int.Parse(hdnBillUnitID.Value);
                    strCCName = ddlCostCenter.SelectedItem.ToString();
                    intCCID = int.Parse(ddlCostCenter.SelectedValue.ToString());
                    intBank = int.Parse(ddlBank.SelectedValue.ToString());
                    intBankAcc = int.Parse(ddlACNumber.SelectedValue.ToString());
                    strInstrument = txtNo.Text;
                    dteInstrumentDate = DateTime.Parse(txtDate.Text);
                    dteVoucherDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    intUserID = int.Parse(hdnEnroll.Value);
                    strPayTo = ddlPayTo.SelectedItem.ToString();
                    intBillID = int.Parse(hdnBillID.Value);
                    strBillCode = txtEntryCode.Text;
                    monApproveAmount = decimal.Parse(txtApproveAmount.Text);
                    monVoucherTotal = decimal.Parse(txtVoucherIssued.Text);
                    strNarration = txtNarration.Text;

                    decimal Gross = 0;
                    if (dgvReportForPaymentV.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvReportForPaymentV.Rows.Count; i++)
                        {
                            Gross = Gross + Convert.ToDecimal(((Label)dgvReportForPaymentV.Rows[i].FindControl("lblDebit")).Text.ToString());
                        }
                    }

                    if (Gross > (monApproveAmount - monVoucherTotal))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Total voucher amount Cannot be greater than approved amount.');", true); return;
                    }


                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("BPVoucher");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<BPVoucher>" + xmlString + "</BPVoucher>";
                        xml = xmlString;
                    }
                    catch { }
                    strInstrumentNo = ddlInstrument.SelectedItem.ToString();

                    //Final In Insert                                 
                    string message = objVoucher.InsertPaymentVoucherBP(intUnitID, strCCName, intCCID, intBank, intBankAcc, strInstrument, dteInstrumentDate, dteVoucherDate, intUserID, strPayTo, intBillID, strBillCode, monApproveAmount, monVoucherTotal, strNarration, xml, strInstrumentNo);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnSaveBP_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnSaveBP_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


















    }
}
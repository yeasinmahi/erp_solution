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
    public partial class JV : System.Web.UI.Page
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

        int intUnitID, intCCID, intBank, intBankAcc, intUserID, intBillID;
        string strCCName, strInstrument, strPayTo, strBillCode, strNarration, strInstrumentNo;
        DateTime dteInstrumentDate, dteVoucherDate;

        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/PaymentModule/Data/CPVoucher_" + hdnEnroll.Value + ".xml");

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
                ////txtPayTo.Text = party;
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
                    monApproveAmount = Math.Round(decimal.Parse(dt.Rows[0]["monApprove"].ToString()), 2);
                    monVoucherTotal = Math.Round(decimal.Parse(dt.Rows[0]["monVoucherTotal"].ToString()), 2);
                    monTotalAdvance = Math.Round(decimal.Parse(dt.Rows[0]["monAdvanceTotal"].ToString()), 2);
                    intAccID = int.Parse(dt.Rows[0]["intPartyCOA"].ToString());
                    strAccName = dt.Rows[0]["strPartyCOA"].ToString();
                    intCountPVoucher = int.Parse(dt.Rows[0]["intCountPVoucher"].ToString());
                    monLedgerBalance = Math.Round(decimal.Parse(dt.Rows[0]["monLedgerBalance"].ToString()), 2);
                    monNetPay = Math.Round(decimal.Parse(dt.Rows[0]["monNetPay"].ToString()), 2);
                }
                

                //ElseIf intCountPVoucher = 0 Then 'No Purchase Voucher inserted
                //If monTotalAdvance = 0 Then 'No Previous advance
                //    frmVoucherAccounts.MultiPage1(0).Visible = True
                //    frmVoucherAccounts.MultiPage1(1).Visible = True
                //    frmVoucherAccounts.MultiPage1(2).Visible = False
                //ElseIf monTotalAdvance<> 0 Then 'Previous advance given
                //    frmVoucherAccounts.MultiPage1(0).Visible = True
                //    frmVoucherAccounts.MultiPage1(1).Visible = True
                //    frmVoucherAccounts.MultiPage1(2).Visible = True
                //End If


                txtApproveAmount.Text = monApproveAmount.ToString();
                txtPreAdvance.Text = monTotalAdvance.ToString();
                txtVoucherIssued.Text = monVoucherTotal.ToString();

                try
                {
                    if (hdnBillType.Value == "1") // 'FOR ADVANCE PAYMENT
                    {
                        return;
                    }
                    else if (hdnBillType.Value == "2") // 'FOR PAYMENT AGAINST CREDIT PURCHASE BILL
                    {
                        if (intPartyType != 1)
                        {
                            ysnCreditor = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                            ddlAccHeadJournal.DataTextField = "strAccName";
                            ddlAccHeadJournal.DataValueField = "intAccID";
                            ddlAccHeadJournal.DataSource = dt;
                            ddlAccHeadJournal.DataBind();

                            ListItem item1 = new ListItem("", "0");
                            ddlAccHeadJournal.Items.Add(item1);
                            ddlAccHeadJournal.SelectedValue = "0";
                        }

                        //if (intAccID == 0)
                        //{
                        //    if (intPartyType == 1)
                        //    {
                        //        if (intCountPVoucher == 0)
                        //        {
                        //            ysnPurchase = true;
                        //            dt = new DataTable();
                        //            dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                        //            ddlAccHeadJournal.DataTextField = "strAccName";
                        //            ddlAccHeadJournal.DataValueField = "intAccID";
                        //            ddlAccHeadJournal.DataSource = dt;
                        //            ddlAccHeadJournal.DataBind();
                        //        }
                        //        else if (intCountPVoucher > 0)
                        //        {
                        //            ysnCreditor = true;
                        //            dt = new DataTable();
                        //            dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                        //            ddlAccHeadJournal.DataTextField = "strAccName";
                        //            ddlAccHeadJournal.DataValueField = "intAccID";
                        //            ddlAccHeadJournal.DataSource = dt;
                        //            ddlAccHeadJournal.DataBind();
                        //        }
                        //    }
                        //    else
                        //    {
                        //        ysnPurchase = true;
                        //        dt = new DataTable();
                        //        dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                        //        ddlAccHeadJournal.DataTextField = "strAccName";
                        //        ddlAccHeadJournal.DataValueField = "intAccID";
                        //        ddlAccHeadJournal.DataSource = dt;
                        //        ddlAccHeadJournal.DataBind();
                        //    }
                        //}
                        //else
                        //{
                        //    ListItem item1 = new ListItem(strAccName, intAccID.ToString());
                        //    ddlAccHeadJournal.Items.Add(item1);
                        //}

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
                        //ddlAccHeadJournal.SelectedItem.Text = strAccName;
                    }
                    else if (hdnBillType.Value == "3") // 'FOR PAYMENT AGAINST CASH PURCHASE BILL
                    {
                        if (intPartyType != 1)
                        {
                            ysnPurchase = true;
                            dt = new DataTable();
                            dt = objBillApp.GetPartyLedgerListByPartyTypeOthers(int.Parse(hdnBillUnitID.Value), ysnPurchase);
                            ddlAccHeadJournal.DataTextField = "strAccName";
                            ddlAccHeadJournal.DataValueField = "intAccID";
                            ddlAccHeadJournal.DataSource = dt;
                            ddlAccHeadJournal.DataBind();

                            ListItem item1 = new ListItem("", "0");
                            ddlAccHeadJournal.Items.Add(item1);
                            ddlAccHeadJournal.SelectedValue = "0";
                        }

                        //if (intAccID == 0)
                        //{
                        //    if (intPartyType == 1)
                        //    {
                        //        ysnCreditor = true;
                        //        dt = new DataTable();
                        //        dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                        //        ddlAccHeadJournal.DataTextField = "strAccName";
                        //        ddlAccHeadJournal.DataValueField = "intAccID";
                        //        ddlAccHeadJournal.DataSource = dt;
                        //        ddlAccHeadJournal.DataBind();
                        //    }
                        //    else
                        //    {
                        //        ysnPurchase = true;
                        //        dt = new DataTable();
                        //        dt = objBillApp.GetPartyLedgerListByPartyType1(int.Parse(hdnBillUnitID.Value), ysnCreditor);
                        //        ddlAccHeadJournal.DataTextField = "strAccName";
                        //        ddlAccHeadJournal.DataValueField = "intAccID";
                        //        ddlAccHeadJournal.DataSource = dt;
                        //        ddlAccHeadJournal.DataBind();
                        //    }
                        //}
                        //else
                        //{
                        //    ListItem item1 = new ListItem(strAccName, intAccID.ToString());
                        //    ddlAccHeadJournal.Items.Add(item1);
                        //}
                    }
                }
                catch { }
            }
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                accid = ddlAccHeadJournal.SelectedValue.ToString();
                accname = ddlAccHeadJournal.SelectedItem.ToString();

                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = ddlAccHeadJournal.SelectedItem.ToString().Split(ch1, StringSplitOptions.RemoveEmptyEntries);
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
                XmlNode rootNode = doc.SelectSingleNode("CPVoucher");
                XmlNode addItem = CreateItemNode(doc, accid, accname, narration, debit, credit);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CPVoucher");
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
            XmlNode dSftTm = doc.SelectSingleNode("CPVoucher");
            xmlString = dSftTm.InnerXml;
            xmlString = "<CPVoucher>" + xmlString + "</CPVoucher>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvReportForPaymentV.DataSource = ds; }
            else { dgvReportForPaymentV.DataSource = ""; }
            dgvReportForPaymentV.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string accid, string accname, string narration, string debit, string credit)
        {
            XmlNode node = doc.CreateElement("CPVoucher");

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
                XmlNode dSftTm = doc.SelectSingleNode("CPVoucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<CPVoucher>" + xmlString + "</CPVoucher>";
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
        
        protected decimal debitgtotal = 0;
        protected decimal creditgtotal = 0;
        protected void dgvReportForPaymentV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    debitgtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblDebit")).Text);
                    creditgtotal += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblCredit")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        protected void btnSaveJV_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    #region ===== New Code ================================
                    intUnitID = int.Parse(hdnBillUnitID.Value);
                    strNarration = txtNarration.Text;
                    if (strNarration == "")
                    {
                        return;
                    }
                    intUserID = int.Parse(hdnEnroll.Value);
                    dteVoucherDate = DateTime.Parse(txtVoucherDate.Text);
                    monApproveAmount = decimal.Parse(txtApproveAmount.Text);
                    monVoucherTotal = decimal.Parse(txtVoucherIssued.Text);

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

                    intBillID = int.Parse(hdnBillID.Value);
                    strBillCode = txtEntryCode.Text;

                    strCCName = ""; //ddlCostCenter.SelectedItem.ToString();
                    intCCID = 0; //int.Parse(ddlCostCenter.SelectedValue.ToString());
                    intBank = 0; //int.Parse(ddlBank.SelectedValue.ToString());
                    intBankAcc = 0; //int.Parse(ddlACNumber.SelectedValue.ToString());
                    strInstrument = ""; //txtNo.Text;
                    dteInstrumentDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));//DateTime.Parse(txtDate.Text);

                    /*
                        intUnit = Me.lblUnit.Caption
                        strNarration = Me.lstVoucherJournal.List(0, 2)
                        intUser = Sheets("Config").lblUserID.Caption
                        dteVoucherDate = Format(Me.DTPicker2.Value, "YYYY-MM-DD")

                        monApproveAmount = Val(Format(Me.lblAmount.Caption, "0.00"))
                        monVoucherTotal = Val(Format(Me.lblVoucherTotal.Caption, "0.00"))
                        intbillid = Me.lblBillID.Caption

                        monDrTotal = 0
                        monCrTotal = 0

                        For i = 0 To Me.lstVoucherJournal.ListCount - 1 Step 1
                            monDrTotal = monDrTotal + Val(Me.lstVoucherJournal.List(i, 3))
                            monCrTotal = monCrTotal + Val(Me.lstVoucherJournal.List(i, 4))
                        Next i

                        monBalance = monDrTotal - monCrTotal
                        If monBalance<> 0 Then
                           MsgBox "Total of Debit and Credit Amount is not same.", vbCritical
                           Exit Sub
                       ElseIf monDrTotal = 0 Then
                           MsgBox "Total of Debit and Credit Amount is zero.", vbCritical
                           Exit Sub
                       End If
                        */
                    #endregion ============================================
                    

                    /*
                    if (txtPayTo.Text == "")
                    {
                        return;
                    }
                    strPayTo = txtPayTo.Text; //ddlPayTo.SelectedItem.ToString();
                    */


                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("CPVoucher");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<CPVoucher>" + xmlString + "</CPVoucher>";
                        xml = xmlString;
                    }
                    catch { }
                    strInstrumentNo = ""; //ddlInstrument.SelectedItem.ToString();

                    //Final In Insert                                 
                    string message = objVoucher.InsertPaymentVoucherCP(intUnitID, strCCName, intCCID, intBank, intBankAcc, strInstrument, dteInstrumentDate, dteVoucherDate, intUserID, strPayTo, intBillID, strBillCode, monApproveAmount, monVoucherTotal, strNarration, xml, strInstrumentNo);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
            }
            catch { }
        }


        #region ===== Radio Button Selection Change===================
        protected void rdoDr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDr.Checked == true)
            {
                rdoCr.Checked = false;
            }
        }
        protected void rdoCr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCr.Checked == true)
            {
                rdoDr.Checked = false;
            }
        }

        #endregion ===================================================



















    }
}
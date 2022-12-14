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
    public partial class POVoucherOfAFBL : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/POVoucherOfAFBL.aspx";
        string stop = "stopping PaymentModule/POVoucherOfAFBL.aspx";

        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        DateTime dteInsDate; decimal monAmount;
        string strEmail, strPayTo, strBillCode, strParty, strPO;
        int intUnitID, intBankID, intDrCOA, intBill, intUser, intBankAcc;
        string unitid, user, bankid, bankacc, insdate, payto, amount, drcoa, billcode, po, bill, party, tds;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/POVoucherOfAFBL.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/Voucher_" + hdnEnroll.Value + ".xml");
                if (!IsPostBack)
                {
                    File.Delete(filePathForXML);
                    dgvReportForPaymentV.DataSource = "";

                    dgvReportForPaymentV.DataBind();

                    if (hdnUnit.Value == "2" || hdnUnit.Value == "46" || hdnUnit.Value == "54" || hdnUnit.Value == "67" || hdnUnit.Value == "95")
                    {
                        try
                        {
                            dt = new DataTable();
                            dt = objVoucher.GetUserRollCheck(hdnEmail.Value);
                            if (dt.Rows.Count > 0)
                            {
                                hdnCount.Value = dt.Rows[0]["intCount"].ToString();
                            }

                            if (hdnCount.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                                return;
                            }
                        }
                        catch { }

                        try
                        {
                            dt = new DataTable();
                            dt = objVoucher.GetUnitList(int.Parse(hdnEnroll.Value));
                            if (dt.Rows.Count > 0)
                            {
                                ddlUnit.DataTextField = "strUnit";
                                ddlUnit.DataValueField = "intUnitID";
                                ddlUnit.DataSource = dt;
                                ddlUnit.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                                return;
                            }
                        }
                        catch { }

                        try
                        {
                            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                            dt = new DataTable();
                            dt = objVoucher.GetBankList(intUnitID);
                            if (dt.Rows.Count > 0)
                            {
                                ddlBank.DataTextField = "strBankName";
                                ddlBank.DataValueField = "intBankID";
                                ddlBank.DataSource = dt;
                                ddlBank.DataBind();
                            }
                        }
                        catch { }

                        try
                        {
                            intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                            dt = new DataTable();
                            dt = objVoucher.GetAccountList(intUnitID, intBankID);
                            if (dt.Rows.Count > 0)
                            {
                                ddlAccount.DataTextField = "strBankAccount";
                                ddlAccount.DataValueField = "intAccountID";
                                ddlAccount.DataSource = dt;
                                ddlAccount.DataBind();
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

            dt = new DataTable();
            dt = objVoucher.GetBankList(intUnitID);
            if (dt.Rows.Count > 0)
            {
                ddlBank.DataTextField = "strBankName";
                ddlBank.DataValueField = "intBankID";
                ddlBank.DataSource = dt;
                ddlBank.DataBind();
            }

            try
            {
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                dt = new DataTable();
                dt = objVoucher.GetAccountList(intUnitID, intBankID);
                if (dt.Rows.Count > 0)
                {
                    ddlAccount.DataTextField = "strBankAccount";
                    ddlAccount.DataValueField = "intAccountID";
                    ddlAccount.DataSource = dt;
                    ddlAccount.DataBind();
                }
            }
            catch { }

            try
            {
                dt = new DataTable();
                dt = objVoucher.GetBankAndAccNameForAFBL(intUnitID);
                if (dt.Rows.Count > 0)
                {
                    ddlBank.SelectedItem.Text = dt.Rows[0]["strBankName"].ToString();
                    ddlAccount.SelectedItem.Text = dt.Rows[0]["strAccountNo"].ToString();
                }
            }
            catch { }
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                dt = new DataTable();
                dt = objVoucher.GetAccountList(intUnitID, intBankID);
                if (dt.Rows.Count > 0)
                {
                    ddlAccount.DataTextField = "strBankAccount";
                    ddlAccount.DataValueField = "intAccountID";
                    ddlAccount.DataSource = dt;
                    ddlAccount.DataBind();
                }
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/POVoucherOfAFBL.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

            if (intUnitID == 2 || intUnitID == 46 || intUnitID == 54 || intUnitID == 67 || intUnitID == 95)
            {
                try
                {
                    dgvReportForPaymentV.DataSource = "";
                    dgvReportForPaymentV.DataBind();
                    dt = objVoucher.GetReportForPaymentVoucher(intUnitID);
                    if (dt.Rows.Count > 0)
                    {
                        dgvReportForPaymentV.DataSource = dt;
                        dgvReportForPaymentV.DataBind();
                    }
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnPrepareAllVoucher_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/POVoucherOfAFBL.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (intUnitID == 2 || intUnitID == 46 || intUnitID == 54 || intUnitID == 67 || intUnitID == 95)
                {
                    if (hdnconfirm.Value == "1")
                    {
                        intUnitID = int.Parse(hdnUnit.Value);
                        intUser = int.Parse(hdnEnroll.Value);
                        intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                        intBankAcc = int.Parse(ddlAccount.SelectedValue.ToString());

                        if (dgvReportForPaymentV.Rows.Count > 0)
                        {
                            for (int index = 0; index < dgvReportForPaymentV.Rows.Count; index++)
                            {
                                if (((CheckBox)dgvReportForPaymentV.Rows[index].FindControl("chkRow")).Checked == true)
                                {
                                    if (txtAllPayDate.Text == "")
                                    {
                                        insdate = ((TextBox)dgvReportForPaymentV.Rows[index].FindControl("txtPayDate")).Text.ToString();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            insdate = DateTime.Parse(txtAllPayDate.Text).ToString();
                                        }
                                        catch
                                        {
                                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Date is incorrect. Date Format (YYYY-MM-DD)');", true);
                                            return;
                                        }
                                    }

                                    //insdate = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblPayDate")).Text.ToString();
                                    payto = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblBankAccount")).Text.ToString();
                                    amount = decimal.Parse(((Label)dgvReportForPaymentV.Rows[index].FindControl("lblApproveAmount")).Text.ToString()).ToString();
                                    drcoa = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblCOA")).Text.ToString();
                                    billcode = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblRegNo")).Text.ToString();
                                    po = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblPOID")).Text.ToString();
                                    bill = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblID")).Text.ToString();
                                    party = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblPartyName")).Text.ToString();
                                    tds = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblTDS")).Text.ToString();

                                    if (strPayTo != "" || drcoa != "" || bill != "")
                                    {
                                        CreateVoucherXml(insdate, payto, amount, drcoa, billcode, po, bill, party, tds);
                                    }

                                    File.Delete(filePathForXML);
                                    LoadGrid();
                                }
                            }
                        }

                        if (dgvReportForPaymentV.Rows.Count > 0)
                        {
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("VoucherA");
                                string xmlString = dSftTm.InnerXml;
                                xmlString = "<VoucherA>" + xmlString + "</VoucherA>";
                                xml = xmlString;
                            }
                            catch { }
                            if (xml == "") { return; }
                        }

                        dt = new DataTable();
                        dt = objVoucher.InsertPOVoucherForAFBL(intUnitID, intUser, intBankID, intBankAcc, xml);
                        if (dt.Rows.Count > 0)
                        {
                            string msg = dt.Rows[0]["strVoucherCode"].ToString();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXml(string insdate, string payto, string amount, string drcoa, string billcode, string po, string bill, string party, string tds)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("VoucherA");
                XmlNode addItem = CreateItemNode(doc, insdate, payto, amount, drcoa, billcode, po, bill, party, tds);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("VoucherA");
                XmlNode addItem = CreateItemNode(doc, insdate, payto, amount, drcoa, billcode, po, bill, party, tds);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string insdate, string payto, string amount, string drcoa, string billcode, string po, string bill, string party, string tds)
        {
            XmlNode node = doc.CreateElement("VoucherA");
            XmlAttribute Insdate = doc.CreateAttribute("insdate"); Insdate.Value = insdate;
            XmlAttribute Payto = doc.CreateAttribute("payto"); Payto.Value = payto;
            XmlAttribute Amount = doc.CreateAttribute("amount"); Amount.Value = amount;
            XmlAttribute Drcoa = doc.CreateAttribute("drcoa"); Drcoa.Value = drcoa;
            XmlAttribute Billcode = doc.CreateAttribute("billcode"); Billcode.Value = billcode;
            XmlAttribute Po = doc.CreateAttribute("po"); Po.Value = po;
            XmlAttribute Bill = doc.CreateAttribute("bill"); Bill.Value = bill;
            XmlAttribute Party = doc.CreateAttribute("party"); Party.Value = party;
            XmlAttribute Tds = doc.CreateAttribute("Tds"); Party.Value = tds;

            node.Attributes.Append(Insdate);
            node.Attributes.Append(Payto);
            node.Attributes.Append(Amount);
            node.Attributes.Append(Drcoa);
            node.Attributes.Append(Billcode);
            node.Attributes.Append(Po);
            node.Attributes.Append(Bill);
            node.Attributes.Append(Party);
            node.Attributes.Append(Tds);
            return node;
        }
        protected void dgvReportForPaymentV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvReportForPaymentV.Rows[rowIndex];
        }


























    }
}
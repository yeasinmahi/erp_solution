using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;
using Utility;

namespace UI.PaymentModule
{
    public partial class VoucherForAdvice : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/VoucherForAdvice.aspx";
        string stop = "stopping PaymentModule/VoucherForAdvice.aspx";

        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        DateTime dteInsDate; decimal monAmount;        
        string strEmail, strPayTo, strBillCode, strParty, strPO;
        int intUnitID, intBankID, intDrCOA, intBill, intUser, intBankAcc;
        string unitid, user, bankid, bankacc, insdate, payto, amount, drcoa, billcode, po, bill, party;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/VoucherForAdvice.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/Voucher_" + hdnEnroll.Value + ".xml");
                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvReportForPaymentV.DataSource = ""; dgvReportForPaymentV.DataBind();
                    
                    if (!objVoucher.GetVoucherPermission(Enroll))
                    {
                        Toaster("You are not authorized to create payment voucher", Common.TosterType.Warning);
                        return;
                    }

                    try
                    {
                        dt = new DataTable();
                        dt = objVoucher.GetUserRollCheck(hdnEmail.Value);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["intCount"].ToString() == "0")
                            {
                                Toaster("You are not in authorized group", Common.TosterType.Warning);
                                return;
                            }
                        }
                        else
                        {
                            Toaster("Something error in data feaching.", Common.TosterType.Error);
                            return;
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        Toaster(ex.Message,Common.TosterType.Error);
                    }

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
                            Toaster("You have to get Unit permission to perform payment vouchar",Common.TosterType.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Toaster(ex.Message, Common.TosterType.Error);
                    }

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
                    catch (Exception ex)
                    {
                        Toaster(ex.Message, Common.TosterType.Error);
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
                    catch (Exception ex)
                    {
                        Toaster(ex.Message, Common.TosterType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
                Toaster(ex.Message, Common.TosterType.Error);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/VoucherForAdvice.aspx ddlUnit_SelectedIndexChanged", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

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
            File.Delete(filePathForXML); dgvReportForPaymentV.DataSource = ""; dgvReportForPaymentV.DataBind();

            fd = log.GetFlogDetail(stop, location, "ddlUnit_SelectedIndexChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
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
            var tracker = new PerfTracker("Performance on PaymentModule/VoucherForAdvice.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dgvReportForPaymentV.DataSource = "";
                dgvReportForPaymentV.DataBind();
                dt = objVoucher.GetReportForPaymentVoucher(intUnitID);
                if (dt.Rows.Count > 0)
                {
                    dgvReportForPaymentV.DataSource = dt;
                    dgvReportForPaymentV.DataBind();
                }            
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
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
            var tracker = new PerfTracker("Performance on PaymentModule/VoucherForAdvice.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intUser = int.Parse(hdnEnroll.Value);
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                intBankAcc = int.Parse(ddlAccount.SelectedValue.ToString());

                if (dgvReportForPaymentV.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvReportForPaymentV.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvReportForPaymentV.Rows[index].FindControl("chkRow")).Checked == true)
                        {
                            if(txtAllPayDate.Text == "")
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

                            payto = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblBankAccount")).Text.ToString();
                            amount = decimal.Parse(((Label)dgvReportForPaymentV.Rows[index].FindControl("lblApproveAmount")).Text.ToString()).ToString();
                            drcoa = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblCOA")).Text.ToString();
                            billcode = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblRegNo")).Text.ToString();
                            po = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblPOID")).Text.ToString();
                            bill = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblID")).Text.ToString();
                            party = ((Label)dgvReportForPaymentV.Rows[index].FindControl("lblPartyName")).Text.ToString();

                            if (payto != "" && drcoa != "" && bill != "")
                            {
                                CreateVoucherXml(insdate, payto, amount, drcoa, billcode, po, bill, party);
                            }
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
                dt = objVoucher.CreateVoucher(intUnitID, intUser, intBankID, intBankAcc, xml);
                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["strVoucherCode"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                File.Delete(filePathForXML);
                LoadGrid();                
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXml(string insdate, string payto, string amount, string drcoa, string billcode, string po, string bill, string party)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("VoucherA");
                XmlNode addItem = CreateItemNode(doc, insdate, payto, amount, drcoa, billcode, po, bill, party);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("VoucherA");
                XmlNode addItem = CreateItemNode(doc, insdate, payto, amount, drcoa, billcode, po, bill, party);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string insdate, string payto, string amount, string drcoa, string billcode, string po, string bill, string party)
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
            
            node.Attributes.Append(Insdate);
            node.Attributes.Append(Payto);
            node.Attributes.Append(Amount);
            node.Attributes.Append(Drcoa);
            node.Attributes.Append(Billcode);
            node.Attributes.Append(Po);
            node.Attributes.Append(Bill);
            node.Attributes.Append(Party);
            return node;
        }

        protected void dgvReportForPaymentV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvReportForPaymentV.Rows[rowIndex];

            //strSupplierName = (row.FindControl("lblPartyName") as Label).Text;
        }

































        }
    }
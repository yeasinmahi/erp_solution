using BLL.Accounts.Advice;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.Accounts.Advice
{
    public partial class PaymentAdvice : BasePage
    {
        DataTable dt; AdviceBLL bll = new AdviceBLL();
        int intID, intUnitID, intWork, ysnCompleted, intAdviceType, intBankType, intAutoID, intActionBy, intChillingID;
        string strAccountMandatory, strBankName, xmlpath,unitName,forUnit,unitAddress;
        private DateTime dteDate;
        string Id;
        private readonly char[] delimiterChars = { '[', ']' };
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Advice\\PaymentAdvice";
        string stop = "stopping Accounts\\Advice\\PaymentAdvice";
        string accountName, codeNo, bankName, branch, accountType, accountNo, amount, paymentInfo, comments, routingNo, instrumentNo, slNo, debitAccount, insertBy,voucherNo;

        UI.ClassFiles.PrintAdvice printVoucher = new UI.ClassFiles.PrintAdvice();
        string htmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Accounts/Advice/Data" +"PaymentAdvice"+ HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    //pnlUpperControl.DataBind();
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;

                    //HideControl();
                }
                catch
                { }
            }
        }

        protected void ddlAdviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //HideControl();
                intAdviceType = int.Parse(ddlAdviceType.SelectedValue.ToString());
                if (intAdviceType == 3)
                {
                    ddlChillingCenter.Visible = true;
                    lblChillingCenter.Visible = true;
                    dt = new DataTable();
                    dt = bll.GetChillingCenter();
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataBind();
                }
                else
                {
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;
                    ddlChillingCenter.DataSource = "";
                    ddlChillingCenter.DataBind();
                }
            }
            catch { }
        }

       

        protected void ddlBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //HideControl();
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetAccountDetails(intAutoID);
            //    lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
            //    lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
            //    lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();
            }
            catch { }
        }

        protected void ddlFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //HideControl();
                LoadAccountList();
                //dgvAdvice.UnLoad();
                //dgvAdviceIBBL.UnLoad();
                dgvReport.UnLoad();
            }
            catch { }
        }

        private void LoadAccountList()
        {
            //btnExport.Visible = false;
            //btnExportIBBL.Visible = false;
            //divExport.Visible = false;
            //divExportIBBL.Visible = false;
            intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            if (intBankType == 1 || intBankType == 3)
            {
                dt = new DataTable();
                dt = bll.GetIBBLBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();

                //divExport.Visible = false;
                //divExportIBBL.Visible = true;
                //btnExportIBBL.Visible = true;
                //btnExport.Visible = false;
            }
            
            else if (intBankType != 0)
            {
                dt = new DataTable();
                dt = bll.GetOtherBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();

                //divExport.Visible = true;
                //divExportIBBL.Visible = false;
                //btnExport.Visible = true;
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // HideControl();
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitAddress(intUnitID);
                //lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                //lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                //lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                LoadAccountList();
            }
            catch { }
        }

        //private void HideControl()
        //{
        //    lblUnitName.Visible = false;
        //    lblUnitAddress.Visible = false;
        //    lblTo.Visible = false;
        //    lblManager.Visible = false;
        //    lblBankName.Visible = false;
        //    lblBankAddress.Visible = false;
        //    lblSubject.Visible = false;
        //    lblDearSir.Visible = false;
        //    lblMailBody.Visible = false;
        //    lblDetails.Visible = false;
        //    lblWord.Visible = false;
        //    lblForUnit.Visible = false;
        //    lblAuth1.Visible = false;
        //    lblAuth2.Visible = false;
        //    lblAuth3.Visible = false;
        //    dgvAdvice.DataSource = "";
        //    dgvAdvice.DataBind();
        //    lblUnitIBBL.Visible = false;
        //    lblUnitIBBL.Visible = false;
        //    lblToIBBL.Visible = false;
        //    lblManagerIBBL.Visible = false;
        //    lblBankNameIBBL.Visible = false;
        //    lblBankAddressIBBL.Visible = false;
        //    lblSubjectIBBL.Visible = false;
        //    lblDearSirIBBL.Visible = false;
        //    lblMailBodyIBBL.Visible = false;
        //    lblDetailsIBBL.Visible = false;
        //    lblWordIBBL.Visible = false;
        //    lblForUnitIBBL.Visible = false;
        //    lblAuthIBBL1.Visible = false;
        //    lblAuthIBBL2.Visible = false;
        //    lblAuthIBBL3.Visible = false;
        //    dgvAdviceIBBL.DataSource = "";
        //    dgvAdviceIBBL.DataBind();
        //}

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
            
        }

        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Advice\\PaymentAdvice  Payment Advice Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
                intActionBy = int.Parse(hdnEnroll.Value.ToString());
                intAdviceType = int.Parse(ddlAdviceType.SelectedValue.ToString());
                if (intAdviceType == 3)
                {
                    intChillingID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                }
                else { intChillingID = 0; }

                if (intBankType == 0)
                {
                    return;
                }
                else if(intBankType==2)
                {
                    LoadGridExport();
                    
                }
                else //IBBL and Other
                {

                    LoadLabel();
                    dt = new DataTable();
                    dt = bll.GetPartyAdvice(intAdviceType, intActionBy, intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted, intChillingID);
                    LoadGridExport();

                }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void LoadGridExport()
        {
            try
            {
                Session["accountNo"] = null;
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
                intActionBy = int.Parse(hdnEnroll.Value.ToString());

                LoadLabel();

                if (intBankType == 0)
                {
                    return;
                }
                else if (intBankType == 1) //IBBL
                {

                    dt = new DataTable();
                    dt = bll.GetAdviceData(1, intActionBy);
                    //dgvAdviceIBBL.DataSource = dt;
                    //dgvAdviceIBBL.DataBind();
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                    //if (dgvAdviceIBBL.Rows.Count > 0)
                    //{
                    //    AdviceIBBLLabelShowHide();

                    //    intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                    //    dt = new DataTable();
                    //    dt = bll.GetAccountDetails(intAutoID);
                    //    lblBankNameIBBL.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                    //    lblBankAddressIBBL.Text = dt.Rows[0]["strBankAddress"].ToString();
                    //    lblMailBodyIBBL.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();

                    //    AmountFormat formatAmount = new AmountFormat();
                    //    string totalAmountInWord = formatAmount.GetTakaInWords(totalamountibbl, "", "Only");
                    //    lblWordIBBL.Text = "In Word: " + totalAmountInWord.ToString();
                    //    HdnValue.Value = "";

                    //}
                }
                else if (intBankType == 3) //Other
                {
                    dt = new DataTable();
                    dt = bll.GetAdviceData(2, intActionBy);
                    //dgvAdviceIBBL.DataSource = dt;
                    //dgvAdviceIBBL.DataBind();
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                    //if (dgvAdviceIBBL.Rows.Count > 0)
                    //{
                    //    AdviceIBBLLabelShowHide();

                    //    intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                    //    dt = new DataTable();
                    //    dt = bll.GetAccountDetails(intAutoID);
                    //    lblBankNameIBBL.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                    //    lblBankAddressIBBL.Text = dt.Rows[0]["strBankAddress"].ToString();
                    //    lblMailBodyIBBL.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();

                    //    AmountFormat formatAmount = new AmountFormat();
                    //    string totalAmountInWord = formatAmount.GetTakaInWords(totalamountibbl, "", "Only");
                    //    lblWordIBBL.Text = "In Word: " + totalAmountInWord.ToString();
                    //    HdnValue.Value = "";

                    //}
                }
                else if (intBankType == 2)//SCB
                {

                    dt = new DataTable();
                    dt = bll.GetPartyAdviceForSCB(intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted);

                    CheckScbBank();

                    //dgvAdvice.DataSource = dt;
                    //dgvAdvice.DataBind();
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                    //if (dgvAdvice.Rows.Count > 0)
                    //{

                    //    AdviceSCBLabelShowHide();

                    //    intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                    //    dt = new DataTable();
                        dt = bll.GetAccountDetails(intAutoID);
                    //    lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                    //    lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
                    //    lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our" + "<br/>" + "CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();

                    //    AmountFormat formatAmount = new AmountFormat();
                    //    string totalAmountInWord = formatAmount.GetTakaInWords(totalamount, "", "Only");
                    //    lblWord.Text = "In Word: " + totalAmountInWord.ToString();
                    //    HdnValue.Value = "";

                    //}
                }

            }
            catch { }
        }
        public void   LoadLabel()
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = bll.GetUnitAddress(intUnitID);
            //lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
            //lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
            //lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

            dteDate = DateTime.Parse(txtDate.Text.ToString());
            intWork = 0;
            strAccountMandatory = ddlMandatory.SelectedItem.ToString();
            strBankName = ddlFormat.SelectedItem.ToString();
            ysnCompleted = int.Parse(ddlVoucher.SelectedValue.ToString());
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //string bankName, unitId, accountId, insertBy;
            //bankName = ddlFormat.SelectedItem.Text;
            //unitId = ddlUnit.SelectedValue.ToString();
            //accountId = ddlBankAccount.SelectedValue.ToString();
            //insertBy = Enroll.ToString();
            //dteDate = DateTime.Parse(txtDate.Text.ToString());
            //string id ="0", voucherType="", userID="";
            //string type = "0";
            //int count =5;
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPopup('"+ id + "','"+ type.ToString() + "','"+ count.ToString()+ "');", true);
            
            PrintVoucherData();
        }

        private void PrintVoucherData()
        {
             

            
            string strCodeForbarCode="",unitID = "";
            string voucherType = "Debit Voucher";
            StringBuilder sb = new StringBuilder();

            if (dgvReport.Rows.Count > 0)
            { 
                foreach (GridViewRow row in dgvReport.Rows)
                { 
                    CheckBox check = (CheckBox)row.FindControl("chkRow");
                    if (check.Checked == true)
                    {
                        accountName = ((Label)row.FindControl("lblAccountName")).Text;
                        voucherNo = ((Label)row.FindControl("lblBPVoucher")).Text; 
                      string  userID = Enroll.ToString();
                        dt = bll.GetBankVoucherId(voucherNo, int.Parse(ddlUnit.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {
                             Id = dt.Rows[0]["intBankVoucherID"].ToString();
                        }
                        string img = "../../Content/Images/img/" + 2 + ".png";

                        htmlString = printVoucher.PrintBankVoucher(voucherType, Id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                        sb.Append("<table style=\"width: 100%;\">");
                        sb.Append("<tr>");
                        sb.Append("<td  style=\"text-align:left\" class=\"HeaderStyle2\">");
                        sb.Append("<td><img src='"+ img + "'");
                        sb.Append("</img>");
                        sb.Append("</td>");
                        sb.Append(htmlString);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                    }

                }
            }
            Session["htmlString"] = sb;
            htmlString = "0";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "VoucherPrint('" + htmlString + "');", true);

        }

        public void CheckScbBank()
        {
            string accountNo = ddlBankAccount.SelectedItem.Text;
            string[] arrayKey = accountNo.Split(delimiterChars);
            if (arrayKey.Length > 0)
            {
                string acNo = arrayKey[0];
                string bankName = arrayKey[1];
                if (bankName.ToLower().Equals("scb"))
                {
                    Session["accountNo"] = acNo;
                }
                else
                {
                    Session["accountNo"] = null;
                }

            }
            else
            {
                Session["accountNo"] = null;
            }
        }
       
        //public void AdviceSCBLabelShowHide()
        //{
        //    lblUnitName.Visible = true;
        //    lblUnitAddress.Visible = true;
        //    lblTo.Visible = true;
        //    lblManager.Visible = true;
        //    lblBankName.Visible = true;
        //    lblBankAddress.Visible = true;
        //    lblSubject.Visible = true;
        //    lblDearSir.Visible = true;
        //    lblMailBody.Visible = true;
        //    lblDetails.Visible = true;
        //    lblWord.Visible = true;
        //    lblForUnit.Visible = true;
        //    lblAuth1.Visible = true;
        //    lblAuth2.Visible = true;
        //    lblAuth3.Visible = true;
        //}
        //public void AdviceIBBLLabelShowHide()
        //{
        //    lblUnitIBBL.Visible = true;
        //    lblUnitIBBL.Visible = true;
        //    lblToIBBL.Visible = true;
        //    lblManagerIBBL.Visible = true;
        //    lblBankNameIBBL.Visible = true;
        //    lblBankAddressIBBL.Visible = true;
        //    lblSubjectIBBL.Visible = true;
        //    lblDearSirIBBL.Visible = true;
        //    lblMailBodyIBBL.Visible = true;
        //    lblDetailsIBBL.Visible = true;
        //    lblWordIBBL.Visible = true;
        //    lblForUnitIBBL.Visible = true;
        //    lblAuthIBBL1.Visible = true;
        //    lblAuthIBBL2.Visible = true;
        //    lblAuthIBBL3.Visible = true;
        //}
        protected decimal totalamount = 0;
        protected string accounttext;
        protected string routingtext;

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (dgvReport.Rows.Count > 0)
            {

                //for (int index = 0; index < dgvReport.Rows.Count; index++)
                //{
                foreach(GridViewRow row in dgvReport.Rows)
                {

                
                    CheckBox check = (CheckBox)row.FindControl("chkRow");
                    if (check.Checked == true)
                    {
                        accountName = ((Label)row.FindControl("lblAccountName")).Text;
                        codeNo = ((Label)row.FindControl("lblCodeNo")).Text;
                        bankName = ((Label)row.FindControl("lblBankName")).Text;
                        branch = ((Label)row.FindControl("lblBranch")).Text;
                        accountType = ((Label)row.FindControl("lblACType")).Text;
                        accountNo = ((Label)row.FindControl("lblAccountNo")).Text;
                        string Amount = ((Label)row.FindControl("lblAmount")).Text;
                        amount = Amount.Replace(",", "");
                        paymentInfo = ((Label)row.FindControl("lblPaymentInfo")).Text;
                        comments = ((Label)row.FindControl("lblComments")).Text;
                        routingNo = ((Label)row.FindControl("lblRoutingNo")).Text;
                        instrumentNo = ((Label)row.FindControl("btnInstrumentNo")).Text;
                        slNo = ((Label)row.FindControl("lblRowNumber")).Text;
                        voucherNo = ((Label)row.FindControl("lblBPVoucher")).Text;
                        try {
                            debitAccount = ((Label)row.FindControl("lblDebitAcc")).Text;
                        }
                        catch
                        {
                            debitAccount = "0";
                        }
                        
                        insertBy = Enroll.ToString();
                        CreateXml(accountName, codeNo, bankName, branch, accountType, accountNo, amount, paymentInfo, comments, routingNo, instrumentNo, slNo, debitAccount, insertBy, voucherNo);
                        check.Checked = false;
                    }

                }
            }

            if (hdnconfirm.Value == "1")
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode node = doc.SelectSingleNode("AdviceEntry");
                string xmlString = node.InnerXml;
                xmlString = "<AdviceEntry>" + xmlString + "</AdviceEntry>";

                dt = bll.PaymentAdviceEntry(2, Enroll,Convert.ToInt32(ddlUnit.SelectedValue),ddlFormat.SelectedItem.Text,xmlString);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submitted Successfully');", true);
                try
                {

                    File.Delete(xmlpath);
                    dgvReport.DataSource = null;
                    dgvReport.DataBind();
                }

                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                }
            }
        }
        protected void btnVoucher_Click(object sender, EventArgs e)
        {
            //string bankName, unitId, insertBy;
            //bankName = ddlFormat.SelectedItem.Text;
            //unitId = ddlUnit.SelectedValue.ToString();
            //insertBy = Enroll.ToString();
            PrintVoucherData();
            //Response.Redirect("VoucherPrint.aspx?adviceForBank="+ bankName.ToString() + "&unitId=" + unitId + "&insertBy="+insertBy);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "VoucherPrint('" + bankName.ToString() + "','" + unitId.ToString() + "','" + insertBy.ToString() + "');", true);

        }
        private void CreateXml(string accountName, string codeNo, string bankName, string branch, string accountType, string accountNo, string amount, string paymentInfo, string comments, string routingNo, string instrumentNo, string slNo, string debitAccount,string insertBy,string voucherNo)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("AdviceEntry");
                XmlNode addItem = CreateItemNode(doc, accountName, codeNo, bankName, branch, accountType, accountNo, amount, paymentInfo, comments, routingNo, instrumentNo, slNo, debitAccount, insertBy, voucherNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("AdviceEntry");
                XmlNode addItem = CreateItemNode(doc,accountName, codeNo,  bankName,  branch,  accountType,  accountNo,  amount,  paymentInfo,  comments,  routingNo,  instrumentNo,  slNo,  debitAccount, insertBy, voucherNo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string accountName, string codeNo, string bankName, string branch, string accountType, string accountNo,string amount,string paymentInfo,string comments,string routingNo,string instrumentNo,string slNo,string debitAccount,string insertBy,string voucherNo)
        {

            XmlNode node = doc.CreateElement("Advice");


            XmlAttribute AccountName = doc.CreateAttribute("accountName");
            AccountName.Value = accountName;
            XmlAttribute CodeNo = doc.CreateAttribute("codeNo");
            CodeNo.Value = codeNo;
            XmlAttribute BankName = doc.CreateAttribute("bankName");
            BankName.Value = bankName;
            XmlAttribute Branch = doc.CreateAttribute("branch");
            Branch.Value = branch;
            XmlAttribute AccountType = doc.CreateAttribute("accountType");
            AccountType.Value = accountType;
            XmlAttribute AccountNo = doc.CreateAttribute("accountNo");
            AccountNo.Value = accountNo;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;
            XmlAttribute PaymentInfo = doc.CreateAttribute("paymentInfo");
            PaymentInfo.Value = paymentInfo;
            XmlAttribute Comments = doc.CreateAttribute("comments");
            Comments.Value = comments;
            XmlAttribute RoutingNo = doc.CreateAttribute("routingNo");
            RoutingNo.Value = routingNo;
            XmlAttribute InstrumentNo = doc.CreateAttribute("instrumentNo");
            InstrumentNo.Value = instrumentNo;
            XmlAttribute SLNo = doc.CreateAttribute("slNo");
            SLNo.Value = slNo;
            XmlAttribute DebitAccount = doc.CreateAttribute("debitAccount");
            DebitAccount.Value = debitAccount;
            XmlAttribute InsertBy = doc.CreateAttribute("insertBy");
            InsertBy.Value = insertBy; 
            XmlAttribute VoucherNo = doc.CreateAttribute("voucherNo");
            VoucherNo.Value = voucherNo;
            node.Attributes.Append(AccountName);
            node.Attributes.Append(CodeNo);
            node.Attributes.Append(BankName);
            node.Attributes.Append(Branch);
            node.Attributes.Append(AccountType);
            node.Attributes.Append(AccountNo);
            node.Attributes.Append(Amount);
            node.Attributes.Append(PaymentInfo);
            node.Attributes.Append(Comments);
            node.Attributes.Append(RoutingNo);
            node.Attributes.Append(InstrumentNo);
            node.Attributes.Append(SLNo);
            node.Attributes.Append(DebitAccount);
            node.Attributes.Append(InsertBy);
            node.Attributes.Append(VoucherNo);
            return node;
        }

        protected void dgvAdvice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmount")).Text);
                    accounttext = ((Label)e.Row.Cells[5].FindControl("lblAccountNo")).Text;
                    Label lblNum = (Label)(e.Row.FindControl("lblAccountNo"));
                    lblNum.Text = "'" + accounttext;
                    routingtext = ((Label)e.Row.Cells[9].FindControl("lblRoutingNo")).Text;
                    Label lblNum2 = (Label)(e.Row.FindControl("lblRoutingNo"));
                    lblNum2.Text = "'" + routingtext;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lbl = (Label)(e.Row.FindControl("lblTTTotal"));
                    lbl.Text = String.Format("{0:n}", totalamount);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            ShowHideDebitCell(e);
        }
        protected decimal totalamountibbl = 0;
        protected string accounttextibbl;
        protected void dgvAdviceIBBL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamountibbl += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblAmount")).Text);
                    accounttextibbl = ((Label)e.Row.Cells[1].FindControl("lblAccountNo")).Text;
                    Label lblNumibbl = (Label)(e.Row.FindControl("lblAccountNo"));
                    lblNumibbl.Text = "'" + accounttextibbl;

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblibbl = (Label)(e.Row.FindControl("lblTTTotal"));
                    lblibbl.Text = String.Format("{0:n}", totalamountibbl);
                }
            }
            catch { }
        }

      

        protected void dgvReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowHideDebitCell(e);
        }
        public void ShowHideDebitCell(GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Session["accountNo"] != null)
                    {
                        ((Label)e.Row.FindControl("lblDebitAcc")).Text = "'"+Session["accountNo"].ToString();
                        e.Row.Cells[12].Visible = true;
                        e.Row.Cells[13].Visible = true;
                    }
                    else
                    {
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                    }

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Session["accountNo"] != null)
                    {
                        e.Row.Cells[12].Visible = true;
                        e.Row.Cells[13].Visible = true;
                    }
                    else
                    {
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        #region-------Previous code--------
        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReasonDiv();", true);
        //}
        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
        //        intActionBy = int.Parse(hdnEnroll.Value);
        //        bll.UpdateChqPrint(intUnitID, intActionBy);
        //    }
        //    catch { }
        //    string fileName = ddlAdviceType.SelectedItem.ToString() + " for " + ddlUnit.SelectedItem.ToString();
        //    string html = HdnValue.Value;
        //    ExportToExcel(ref html, fileName);

        //}
        //protected void btnExportIBBL_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
        //        intActionBy = int.Parse(hdnEnroll.Value);
        //        bll.UpdateChqPrint(intUnitID, intActionBy);
        //    }
        //    catch { }
        //    string fileName = ddlAdviceType.SelectedItem.ToString() + " for " + ddlUnit.SelectedItem.ToString();
        //    string html = HdnValueIBBL.Value;
        //    ExportToExcel(ref html, fileName);

        //}
        //public void ExportToExcel(ref string html, string fileName)
        //{
        //    html = html.Replace("&gt;", ">");
        //    html = html.Replace("&lt;", "<");
        //    HttpContext.Current.Response.ClearContent();
        //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
        //    HttpContext.Current.Response.ContentType = "application/xls";
        //    HttpContext.Current.Response.Write(html);
        //    HttpContext.Current.Response.End();
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    var fd = log.GetFlogDetail(start, location, "Delete", null);
        //    Flogger.WriteDiagnostic(fd);

        //    // starting performance tracker
        //    var tracker = new PerfTracker("Performance on Accounts\\Advice\\PaymentAdvice  Delete ", "", fd.UserName, fd.Location,
        //        fd.Product, fd.Layer);
        //    try
        //    {

        //        char[] delimiterChars = { '^' };
        //        string senderdata = ((Button)sender).CommandArgument.ToString();
        //        //string[] data = senderdata.Split(delimiterChars);
        //        int intID = int.Parse(senderdata.ToString());

        //        bll.DeleteData(intID);
        //        LoadGridExport();

        //    }
        //    catch (Exception ex)
        //    {
        //        var efd = log.GetFlogDetail(stop, location, "Delete", ex);
        //        Flogger.WriteError(efd);
        //    }



        //    fd = log.GetFlogDetail(stop, location, "Delete", null);
        //    Flogger.WriteDiagnostic(fd);
        //    // ends
        //    tracker.Stop();
        //}
        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        char[] delimiterChars = { '^' };
        //        string senderdata = ((Button)sender).CommandArgument.ToString();
        //        intID = int.Parse(senderdata.ToString());
        //    }
        //    catch { intID = 0; return; }
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDispatchPopup('" + intID.ToString() + "');", true);
        //}

        #endregion----------



    }

}
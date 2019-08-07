using BLL.Accounts.Advice;
using BLL.Accounts.Voucher;
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
        string strAccountMandatory, strBankName, xmlpath,unitName,forUnit,unitAddress, mail, PoNo, BillNo, poIssuerMail, PartyMail, msg;
        private DateTime dteDate;
        string Id;
        private readonly char[] delimiterChars = { '[', ']' };
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Advice\\PaymentAdvice";
        string stop = "stopping Accounts\\Advice\\PaymentAdvice";
        string accountName, codeNo, bankName, branch, accountType, accountNo, amount, paymentInfo, comments, routingNo, instrumentNo, slNo, debitAccount, insertBy,voucherNo;
        BankVoucher bankBll = new BankVoucher();
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
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;
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
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetAccountDetails(intAutoID);
            }
            catch { }
        }

        protected void ddlFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                LoadAccountList();
                dgvReport.UnLoad();
            }
            catch { }
        }

        private void LoadAccountList()
        {
           
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
            }
            
            else if (intBankType != 0)
            {
                dt = new DataTable();
                dt = bll.GetOtherBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();

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

                LoadAccountList();
                LoadGrid();
            }
            catch { }
        }


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
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                }
                else if (intBankType == 3) //Other
                {
                    dt = new DataTable();
                    dt = bll.GetAdviceData(2, intActionBy);
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                }
                else if (intBankType == 2)//SCB
                {

                    dt = new DataTable();
                    dt = bll.GetPartyAdviceForSCB(intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted);

                    CheckScbBank();

                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                    dt = new DataTable();
                    dt = bll.GetAccountDetails(intAutoID);
                  
                }

            }
            catch { }
        }
        public void   LoadLabel()
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = bll.GetUnitAddress(intUnitID);
            unitName = dt.Rows[0]["strDescription"].ToString();
            dteDate = DateTime.Parse(txtDate.Text.ToString());
            intWork = 0;
            strAccountMandatory = ddlMandatory.SelectedItem.ToString();
            strBankName = ddlFormat.SelectedItem.ToString();
            ysnCompleted = int.Parse(ddlVoucher.SelectedValue.ToString());
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string bankName, unitId, accountId, insertBy;
            bankName = ddlFormat.SelectedItem.Text;
            unitId = ddlUnit.SelectedValue.ToString();
            accountId = ddlBankAccount.SelectedValue.ToString();
            insertBy = Enroll.ToString();
            dteDate = DateTime.Parse(txtDate.Text.ToString());
            
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPopup('" + bankName + "','" + unitId + "','" + accountId + "','" + insertBy + "','" + dteDate + "');", true);


        }

        private void PrintVoucherData()
        {

            bankBll.DeleteVoucherData();


            string strCodeForbarCode="",unitID = "",VoucherID="";
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
                        //VoucherID = VoucherID + Id.ToString()+",";
                        //string img = "../../Content/Images/img/" + ddlUnit.SelectedValue.ToString() + ".png";

                        htmlString = printVoucher.PrintBankVoucher(voucherType, Id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                        //sb.Append("<table style=\"width: 100%;\">");
                        //sb.Append("<tr>");
                        //sb.Append("<td  style=\"text-align:left\" class=\"HeaderStyle2\">");
                        //sb.Append("<td><img src='"+ img + "'");
                        //sb.Append("</img>");
                        //sb.Append("</td>");
                        //sb.Append(htmlString);
                        //sb.Append("</td>");
                        //sb.Append("</tr>");
                        //sb.Append("</table>");
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
       
        protected decimal totalamount = 0;
        protected string accounttext;
        protected string routingtext;
        protected void btnPartyEmail_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                foreach (GridViewRow row in dgvReport.Rows)
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
                        
                        PartyMail = ((Label)row.FindControl("lblMail")).Text;
                        PoNo = ((Label)row.FindControl("lblPONo")).Text;
                        BillNo = ((Label)row.FindControl("lblBillNo")).Text;
                        poIssuerMail = ((Label)row.FindControl("lblPOIssuerMail")).Text;
                        dt = new DataTable();
                        dt = bll.GetUnitAddress(Convert.ToInt32(ddlUnit.SelectedValue));
                        unitName = dt.Rows[0]["strDescription"].ToString();
                        if (!String.IsNullOrEmpty(PartyMail))
                        {
                           string pmail = ((Label)row.FindControl("lblMail")).Text;
                            PartyMail = pmail + ";";
                        }
                        else
                        {
                            PartyMail = "";
                        }
                        mail = PartyMail + "" + poIssuerMail;
                        try
                        {
                            debitAccount = ((Label)row.FindControl("lblDebitAcc")).Text;
                        }
                        catch
                        {
                            debitAccount = "0";
                        }
                        string strDays ="";
                        if(ddlFormat.SelectedItem.Text!="IBBL")
                        {
                            strDays = "Two (02)";
                        }
                        else
                        {
                            strDays = "One (01)";
                        }
                        if(!String.IsNullOrEmpty(mail))
                        {
                            msg = bll.SendEmail(accountName, mail, bankName, branch, accountNo, Convert.ToDecimal(amount), PoNo, unitName, strDays, paymentInfo, BillNo, Convert.ToInt32(codeNo), UnitId);
                        }

                        check.Checked = false;
                    }

                }
            }
            Toaster(msg, "Party Advice", Common.TosterType.Success);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (dgvReport.Rows.Count > 0)
            {                
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
            PrintVoucherData();          
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



    }

}
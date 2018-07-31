using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Text;
using BLL;
using BLL.Accounts.Bank;
using DAL.Accounts.Voucher;
using BLL.Accounts.Voucher;
using System.Drawing;
using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using System.Web.Services;
using System.Web.Script.Services;
using UI.ClassFiles;
using GLOBAL_BLL;
using System.Net;

namespace UI.Accounts.Voucher
{
    public partial class VoucherEntry : BasePage
    {
        XmlManager xm = new XmlManager(); string advice = "Advice", adjustment = "Adjustment", VoucherFile, docfile;
        string[] arrayKey; char[] delimiterChars = { '[',']' };
        protected override void OnPreInit(EventArgs e)
        {
            //Session["sesUserID"] = "5";
            base.OnPreInit(e);
            if (!IsPostBack)
            {
                string rdoBtn = "rdo";
                bool isDR = false;
                //For Update
                if (Request.QueryString.Count > 0)
                {
                    hdnUnit.Value = Request.QueryString["unit"];
                    hdnVoucherID.Value = Request.QueryString["id"];
                    if (Request.QueryString["isDr"] == "true")
                    {
                        rdoBtn += "Dr";
                    }
                    else if (Request.QueryString["isDr"] == "false") { rdoBtn += "Cr"; }

                    if (Request.QueryString["type"] == "bn")
                    {
                        rdoBtn += "Bnk";
                    }
                    else if (Request.QueryString["type"] == "ch")
                    {
                        rdoBtn += "Csh";
                    }
                    else if (Request.QueryString["type"] == "jr") { rdoBtn += "Jr"; }
                    else { rdoBtn += "Con"; }

                    if (rdoBtn == "rdoDrBnk") { rdoDrBnk.Checked = true; isDR = true; }
                    else if (rdoBtn == "rdoCrBnk") { rdoCrBnk.Checked = true; isDR = false; }
                    else if (rdoBtn == "rdoDrCsh") { rdoDrCsh.Checked = true; isDR = true; }
                    else if (rdoBtn == "rdoCrCsh") { rdoCrCsh.Checked = true; isDR = false; }
                    else if (rdoBtn == "rdoJr") { rdoJr.Checked = true; }
                    else if (rdoBtn == "rdoCon") { rdoCon.Checked = true; }

                    hdnRdo.Value = rdoBtn;

                    rdoCrBnk.Enabled = false;
                    rdoCrCsh.Enabled = false;
                    rdoDrBnk.Enabled = false;
                    rdoDrCsh.Enabled = false;
                    rdoJr.Enabled = false;
                    rdoCon.Enabled = false;
                }

                //For Update
                if (hdnVoucherID.Value != "")
                {
                    if (File.Exists(GetXMLFilePath())) File.Delete(GetXMLFilePath());

                    //for bank voucher
                    if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk")
                    {
                        SetBankVoucherInfo(isDR);
                    }
                    //Cash voucher
                    else if (hdnRdo.Value == "rdoDrCsh" || hdnRdo.Value == "rdoCrCsh")
                    {
                        SetCashVoucherInfo(isDR);
                    }
                    //journal voucher
                    else if (hdnRdo.Value == "rdoJr")
                    {
                        SetJournalVoucherInfo();
                    }
                    //contra voucher
                    else if (hdnRdo.Value == "rdoCon")
                    {
                        SetContraVoucherInfo();
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
              
                pnlUpperControl.DataBind();
                //For Update
                if (hdnVoucherID.Value != "")
                {
                    RadioBtnChange(hdnRdo.Value);
                }
                else
                {
                    txtVoucherDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                }
                ddlCCntr.Enabled = false;
            }            
            else
            {
                

                if (txtCOA.Text.Length > 0)
                {
                    DataTable dtbl = new DataTable(); ChartOfAcc coaobj = new ChartOfAcc();
                    arrayKey = txtCOA.Text.Split(delimiterChars);
                    string code = arrayKey[1].ToString(); int unit = int.Parse(ddlUnit.SelectedValue.ToString());
                    dtbl = coaobj.GetIsExpenses(code, unit);
                    hdnisexpenses.Value = dtbl.Rows[0]["IsExpenses"].ToString();
                    if (dtbl.Rows[0]["IsExpenses"].ToString() == "1") { ddlCCntr.Enabled = true; }
                    else { ddlCCntr.Enabled = false; }
                    if (int.Parse(ddlUnit.SelectedValue.ToString()) == 105)
                    {
                        ddlCCntr.Enabled = true;
                    }
                }



            }

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

        #region Web Method
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCOAList(string prefixText, int count)
        {
            return ChartOfAccStaticDataProvider.GetCOADataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetDataForPayReceive(string prefixText, int count)
        {
            return BankContraChqBearerST.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetDataForDepositorBank(string prefixText, int count)
        {
            return DepositorBankInfo.BankList(prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetDataForDepositorBranch(string prefixText, int count)
        {
            return DepositorBankInfo.BranchList(prefixText);
        }

        #endregion

        #region Event Handler Button

        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            try
            {
                Budget bdg = new Budget(); DataTable strtdt = new DataTable();
                DateTime gdt = CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text);
                strtdt = bdg.GetAccountsStartDate(int.Parse(ddlUnit.SelectedValue.ToString()));
                DateTime pdt = DateTime.Parse(strtdt.Rows[0]["StartDate"].ToString());
                int rest = DateTime.Compare(gdt, pdt);
                if (rest >= 0)
                {
                    string strAmount = GetAmount(txtAmount.Text).ToString();
                    pnlAfterSave.Visible = false;
                    string drAmount = "", crAmount = "";

                    //bank & cash
                    if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoDrCsh") { drAmount = strAmount; }
                    else if (hdnRdo.Value == "rdoCrBnk" || hdnRdo.Value == "rdoCrCsh") { crAmount = strAmount; }
                    //contra
                    else if (hdnRdo.Value == "rdoCon" && rdoDrCrContra.SelectedValue == "0") { drAmount = strAmount; }
                    else if (hdnRdo.Value == "rdoCon" && rdoDrCrContra.SelectedValue == "1") { crAmount = strAmount; }
                    else if (hdnRdo.Value == "rdoCon" && rdoDrCrContra.SelectedValue == "2")
                    {
                        if (rdoContraDrCr.SelectedIndex == 0) drAmount = strAmount;
                        else crAmount = strAmount;
                    }
                    //journal
                    else if (rdoDrCr.SelectedIndex == 0) drAmount = strAmount;
                    else crAmount = strAmount;

                    if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") xm.CreateFirstRow(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue, ((hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoDrCsh") ? true : false), "bn", GetXMLFilePath());
                    else if (hdnRdo.Value == "rdoDrCsh" || hdnRdo.Value == "rdoCrCsh") xm.CreateFirstRow("", "", ((hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoDrCsh") ? true : false), "ch", GetXMLFilePath());
                    else if (hdnRdo.Value == "rdoCon") xm.CreateFirstRow(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue
                        , (rdoDrCrContra.SelectedValue == "0" ? true : (rdoDrCrContra.SelectedValue == "1") ? false : (rdoContraDrCr.SelectedIndex == 0 ? true : false))
                        , "cn", GetXMLFilePath());

                    string[][] items = null;
                    string coaCode = "", print = "";

                    if (txtCOA.Text.Trim() != "" && txtCOA.Visible)
                    {
                        char[] ch = { '[', ']' };
                        string[] temp = txtCOA.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                        coaCode = temp[temp.Length - 1];
                        print = temp[0];
                    }
                    else if (hdnRdo.Value == "rdoCon")
                    {
                        if (rdoDrCrContra.SelectedIndex == 2)
                        {
                            int? coa = null;
                            BankAccount ba = new BankAccount();
                            ba.GetCOAInfoByBankAccNo(ddlConAccount.SelectedValue, ddlUnit.SelectedValue, ref coa, ref print);

                            ChartOfAccTDS.TblAccountsChartOfAccRow row = ChartOfAccStaticDataProvider.GetCOA_ID_ByID(ddlUnit.SelectedValue, coa.ToString());

                            if (row != null) coaCode = row.strCode;
                            else coaCode = "";
                        }
                        else
                        {
                            coaCode = "0";
                        }
                    }

                    if (coaCode == "0")
                    {
                        if (hdnisexpenses.Value == "1")
                        { items = xm.CreateItems("Cash In Hand", "0", txtNarration.Text + " [" + ddlCCntr.SelectedItem.ToString() + "^" + ddlCCntr.SelectedValue.ToString() + "]", drAmount, crAmount); }
                        else { items = xm.CreateItems("Cash In Hand", "0", txtNarration.Text, drAmount, crAmount); }

                    }
                    else if (coaCode != "")
                    {
                        ChartOfAccTDS.TblAccountsChartOfAccRow row = ChartOfAccStaticDataProvider.GetCOA_ID_ByCode(ddlUnit.SelectedValue, coaCode);
                        if (row != null)
                        {
                            if (hdnisexpenses.Value == "1")
                            {
                                items = xm.CreateItems(row.strAccName
                                    , row.intAccID.ToString()
                                    , txtNarration.Text + " [" + ddlCCntr.SelectedItem.ToString() + "^" + ddlCCntr.SelectedValue.ToString() + "]", drAmount, crAmount);
                            }
                            else
                            {
                                items = xm.CreateItems(row.strAccName, row.intAccID.ToString(), txtNarration.Text, drAmount, crAmount);
                            }
                            if (hdnRdo.Value == "rdoCrBnk" || hdnRdo.Value == "rdoCrCsh")
                            {
                                txtPRPrint.Text = print;
                            }
                            else if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoDrCsh")
                            {
                                print = print.Trim();
                                if (BankContraChqBearerST.HasThisInName(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), print))
                                {
                                    txtPRPrint.Text = print;
                                }
                            }
                            else
                            {
                                txtPRPrint.Text = "";
                            }
                        }
                        else items = null;
                    }

                    if (items != null)
                    {
                        XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                        XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                        selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                        xmlDoc.Save(GetXMLFilePath());
                        if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") xm.ModifyFirstRow(drAmount, crAmount, GetXMLFilePath(), "bn");
                        else if (hdnRdo.Value == "rdoDrCsh" || hdnRdo.Value == "rdoCrCsh") xm.ModifyFirstRow(drAmount, crAmount, GetXMLFilePath(), "ch");
                        if (hdnRdo.Value == "rdoCon") xm.ModifyFirstRow(drAmount, crAmount, GetXMLFilePath(), "cn");
                        BindGrid(GetXMLFilePath());
                        txtCOA.Text = "";
                        txtCOA.Focus();
                    }


                    txtAmount.Text = "";

                    if (hdnRdo.Value == "rdoCon") { rdoContraDrCr.Enabled = false; }

                    ScriptManager.RegisterStartupScript(pnlJSScroll, pnlJSScroll.GetType(), "scrollPanel","scrollPanel();",true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry voucher is backdated.');", true); }
            }
            catch { }
        }


     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                try
                {
                    txtChqDateR.Enabled = true;
                    string a = txtChqDateR.Text.ToString();
                    string b = txtChqDateR.Text.ToString();

                    docfile = txtDocUpload.PostedFile.FileName.ToString();
                   
                }
                catch { }

               
                    string code = "", voucherID = hdnVoucherID.Value;
                    bool canRemoveGrid = true;

                    DataSet ds = new DataSet();
                    ds.ReadXml(GetXMLFilePath());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ds.WriteXml(GetXMLFilePathTemp());
                        }
                    }

                    try
                    {
                        if (hdnRdo.Value != "rdoJr")
                        {
                            ds = new DataSet();
                            ds.ReadXml(GetXMLFilePath());
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[0].Delete();
                                    ds.WriteXml(GetXMLFilePath());
                                }
                            }
                        }


                        XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                        XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);

                        string narration = "";
                        if (GridView1.Rows.Count > 0)
                        {
                            narration = ((TextBox)GridView1.FooterRow.Cells[1].Controls[1]).Text;
                        }

                        string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

                       DateTime chqDate;


                        //bank voucher
                        if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk")
                        {


                            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
                            if (hdnRdo.Value == "rdoDrBnk")
                            {
                                try
                                {
                                    chqDate = CommonClass.GetDateAtSQLDateFormat(txtChqDate.Text);
                                }
                                catch
                                {
                                    chqDate = DateTime.Now;
                                }

                                bv.InsertUpdateDr(xml
                                    , ref voucherID
                                    , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                                    , ddlBank.SelectedValue
                                    , ddlAccount.SelectedValue
                                    , txtCheckNo.Text
                                    , chqDate, narration, (rdoType.SelectedIndex == 0 ? true : false), (rdoType.SelectedIndex == 1 ? true : false)
                                    , (rdoType.SelectedIndex == 2 ? true : false)
                                    , /*hdnAccountIDPR.Value*/"", txtPRPrint.Text, CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), chkCheckNo.Checked, txtRemarks.Text, ref code);

                                if (voucherID == "0")
                                {
                                    canRemoveGrid = false;
                                }
                                else
                                {
                                    canRemoveGrid = true;
                                }


                                ViewAfterSave(canRemoveGrid, code, txtCheckNo.Text, txtPRPrint.Text, voucherID, "bn", true, true, false, ddlUnit.SelectedValue);
                                SetCheckNo("");
                            }
                            else if (hdnRdo.Value == "rdoCrBnk")
                            {
                                try
                                {
                                    chqDate = CommonClass.GetDateAtSQLDateFormat(txtChqDateR.Text);
                                }
                                catch
                                {
                                    chqDate = DateTime.Now;
                                }
                                bv.InsertUpdateCr(xml
                                    , ref voucherID
                                    , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                                    , ddlBank.SelectedValue, ddlAccount.SelectedValue
                                    , txtCheckNoR.Text
                                    , chqDate, narration, (rdoTypeR.SelectedIndex == 0 ? true : false), (rdoTypeR.SelectedIndex == 1 ? true : false), (rdoTypeR.SelectedIndex == 2 ? true : false)
                                    , (rdoTypeR.SelectedIndex == 3 ? true : false), (rdoTypeR.SelectedIndex == 5 ? true : false), (rdoTypeR.SelectedIndex == 6 ? true : false), (rdoTypeR.SelectedIndex == 4 ? true : false)
                                    , txtPRPrint.Text, CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), txtBank.Text, txtBranch.Text, txtDrawn.Text, txtRemarks.Text, ref code);


                                if (voucherID == "0")
                                {
                                    canRemoveGrid = false;
                                }
                                else
                                {
                                    canRemoveGrid = true;
                                }

                                ViewAfterSave(canRemoveGrid, code, txtCheckNoR.Text, txtPRPrint.Text, voucherID, "bn", false, false, true, ddlUnit.SelectedValue);
                            }
                        }
                        //cash voucher
                        else if (hdnRdo.Value == "rdoDrCsh" || hdnRdo.Value == "rdoCrCsh")
                        {
                            BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
                            if (hdnRdo.Value == "rdoDrCsh")
                            {
                                cv.InsertUpdateDr(xml, ref voucherID
                                    , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, narration, /*hdnAccountIDPR.Value*/"", txtPRPrint.Text, CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), ref code);

                                ViewAfterSave(canRemoveGrid, code, "", txtPRPrint.Text, voucherID, "ch", true, false, false, ddlUnit.SelectedValue);
                            }
                            else if (hdnRdo.Value == "rdoCrCsh")
                            {
                                cv.InsertUpdateCr(xml, ref voucherID
                                    , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, narration, /*hdnAccountIDPR.Value*/"", txtPRPrint.Text, CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), ref code);

                                ViewAfterSave(canRemoveGrid, code, "", txtPRPrint.Text, voucherID, "ch", false, false, true, ddlUnit.SelectedValue);
                            }
                        }
                        //contra voucher
                        else if (hdnRdo.Value == "rdoCon")
                        {
                            try
                            {
                                chqDate = CommonClass.GetDateAtSQLDateFormat(txtChqDate.Text);
                            }
                            catch
                            {
                                chqDate = DateTime.Now;
                            }

                            BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
                            if (rdoDrCrContra.SelectedIndex == 0)
                            {
                                cv.InsertUpdateContraBC(xml, ref voucherID, ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlAccount.SelectedValue
                                    , narration, Session[SessionParams.USER_ID].ToString(), CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text)
                                    , ref code, txtCheckNo.Text, (rdoType.SelectedIndex == 0 ? true : false), (rdoType.SelectedIndex == 1 ? true : false)
                                    , (rdoType.SelectedIndex == 2 ? true : false), chqDate, txtConPR.Text, chkCheckNo.Checked);


                                if (voucherID == "0")
                                {
                                    canRemoveGrid = false;
                                }
                                else
                                {
                                    canRemoveGrid = true;
                                }

                                ViewAfterSave(canRemoveGrid, code, "", "", voucherID, "cn", null, false, false, ddlUnit.SelectedValue);
                                SetCheckNo("");
                            }
                            else if (rdoDrCrContra.SelectedIndex == 1)
                            {
                                cv.InsertUpdateContraCB(xml, ref voucherID, ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlAccount.SelectedValue
                                    , narration, Session[SessionParams.USER_ID].ToString(), CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text)
                                    , ref code, txtConPR.Text);

                                if (voucherID == "0")
                                {
                                    canRemoveGrid = false;
                                }
                                else
                                {
                                    canRemoveGrid = true;
                                }
                                ViewAfterSave(canRemoveGrid, code, "", "", voucherID, "cn", null, false, false, ddlUnit.SelectedValue);
                                SetCheckNo("");
                            }
                            else if (rdoDrCrContra.SelectedIndex == 2)
                            {
                                cv.InsertUpdateContraBB(xml, ref voucherID, ddlUnit.SelectedValue, ddlBank.SelectedValue, ddlAccount.SelectedValue
                                    , narration, Session[SessionParams.USER_ID].ToString(), CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), bool.Parse(rdoContraDrCr.SelectedValue)
                                    , ref code, txtCheckNo.Text, (rdoType.SelectedIndex == 0 ? true : false), (rdoType.SelectedIndex == 1 ? true : false)
                                    , (rdoType.SelectedIndex == 2 ? true : false), chqDate, txtConPR.Text, chkCheckNo.Checked);

                                if (voucherID == "0")
                                {
                                    canRemoveGrid = false;
                                }
                                else
                                {
                                    canRemoveGrid = true;
                                }
                                ViewAfterSave(canRemoveGrid, code, "", "", voucherID, "cn", null, false, false, ddlUnit.SelectedValue);
                                SetCheckNo("");
                            }
                        }
                        //journal voucher
                        else if (hdnRdo.Value == "rdoJr")
                        {
                            BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
                            jv.InsertUpdate(xml, ref voucherID, Session[SessionParams.USER_ID].ToString()
                                , ddlUnit.SelectedValue, narration, CommonClass.GetDateAtSQLDateFormat(txtVoucherDate.Text), ref code);

                            ViewAfterSave(canRemoveGrid, code, "", "", voucherID, "jr", null, false, false, ddlUnit.SelectedValue);
                            rdoDrCr.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                    finally
                    {

                        if (canRemoveGrid)
                        {
                            if (File.Exists(GetXMLFilePath()))
                            {
                                File.Delete(GetXMLFilePath());
                            }

                            BindGrid(GetXMLFilePath());
                            RightSideVisible();
                            txtPRPrint.Text = "";
                            txtCheckNoR.Text = "";
                            txtCOA.Focus();

                            if (hdnVoucherID.Value == "")
                            {
                                Redirection();

                            }
                            else
                            {
                                Response.Redirect("Exit.aspx");
                            }
                            if (hdnRdo.Value == "rdoCon") { rdoContraDrCr.Enabled = true; }
                        }
                        else
                        {
                            ds = new DataSet();
                            ds.ReadXml(GetXMLFilePathTemp());
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ds.WriteXml(GetXMLFilePath());
                                }
                            }

                            BindGrid(GetXMLFilePath());
                        }

                        //GridFirstRowChange(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue);

                    }
                txtChqDateR.Enabled = false;

                if (docfile != "")
                {

                    try
                    {
                        VoucherFile = lblCVC.Text.ToString() + ddlUnit.SelectedValue.ToString() + Path.GetFileName(txtDocUpload.FileName.ToString());
                        txtDocUpload.SaveAs(Server.MapPath("~/Accounts/Voucher/Uploads/" + VoucherFile));
                        FileUploadFTP(Server.MapPath("~/Accounts/Voucher/Uploads/"), VoucherFile, "ftp://ftp.akij.net/VoucherUpload/", "erp@akij.net", "erp123");
                        File.Delete(Server.MapPath("~/Accounts/Voucher/Uploads/") + VoucherFile);

                        string VoucherID = voucherID.ToString();
                        string VoucherCode = lblCVC.Text.ToString();
                        int unit = int.Parse(ddlUnit.SelectedValue);
                        BLL.Accounts.Voucher.JournalVoucher objUpload = new BLL.Accounts.Voucher.JournalVoucher();
                        objUpload.VoucherDocUpload(VoucherCode, VoucherID, VoucherFile, unit);



                    }
                    catch { File.Delete(Server.MapPath("~/Accounts/Voucher/Uploads/") + VoucherFile); }
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Document Attachment');", true);
                }
                



                }
            catch (Exception ex) { }
        
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            FileInfo fileInfo = new FileInfo(localPath + fileName);
            FileStream fileStream = fileInfo.OpenRead();

            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];

            Stream uploadStream = requestFTPUploader.GetRequestStream();
            int contentLength = fileStream.Read(buffer, 0, bufferLength);

            while (contentLength != 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = fileStream.Read(buffer, 0, bufferLength);
            }

            uploadStream.Close();
            fileStream.Close();

            requestFTPUploader = null;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (File.Exists(GetXMLFilePath()))
            {
                File.Delete(GetXMLFilePath());
            }

            if (hdnVoucherID.Value == "")
            {
                Redirection();
                BindGrid(GetXMLFilePath());
                txtCOA.Focus();
            }
            else
            {
                Response.Redirect("Exit.aspx");
            }

            if (hdnRdo.Value == "rdoCon") { rdoContraDrCr.Enabled = true; }

            txtPRPrint.Text = "";
        }

        protected void btnCComplete_Click(object sender, EventArgs e)
        {
            //completed at only cash voucher
            char[] ch = { '#' };
            string[] str = btnCComplete.CommandArgument.Split(ch);

            if (str[1] == "bn")
            {
                BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
                bv.VoucherFinished(str[0], Session[SessionParams.USER_ID].ToString());


                if (str[2] == "true")
                {
                    bv.SaveDr(str[0], str[3], Session[SessionParams.USER_ID].ToString(), txtCompleteDate.Text + " 09:00 AM");
                }
                else
                {
                    bv.SaveCr(str[0], str[3], Session["sesUserID"].ToString(), txtCompleteDate.Text + " 09:00 AM");
                }

            }
            else if (str[1] == "ch")
            {
                BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
                cv.FinishedVoucher(Session[SessionParams.USER_ID].ToString(), str[0]);


                if (str[2] == "true")
                {
                    cv.SaveDr(str[0], str[3], Session[SessionParams.USER_ID].ToString(), txtCompleteDate.Text + " 09:00 AM");
                }
                else
                {
                    cv.SaveCr(str[0], str[3], Session[SessionParams.USER_ID].ToString(), txtCompleteDate.Text + " 09:00 AM");
                }

            }
            else if (str[1] == "cn")
            {
                BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
                cv.CompleteContra(Session[SessionParams.USER_ID].ToString(), str[0]);


                cv.Save(str[0], str[3], Session[SessionParams.USER_ID].ToString(), txtCompleteDate.Text + " 09:00 AM");

            }
            else if (str[1] == "jr")
            {
                BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
                jv.CompleteVoucher(Session[SessionParams.USER_ID].ToString(), str[0]);


                jv.Save(str[0], str[3], Session[SessionParams.USER_ID].ToString(), txtCompleteDate.Text + " 09:00 AM");

            }


            pnlAfterSave.Visible = false;
        }

        #endregion

        #region Event Handler Selection

        protected void rdo_CheckedChanged(object sender, EventArgs e)
        {
            hdnXMLFilePath.Value = "";
            RadioButton rdo = (RadioButton)sender;
            hdnRdo.Value = rdo.ID;
            RadioBtnChange(rdo.ID);

            txtCOA.Text = "";
            txtAmount.Text = "";
        }

        protected void rdoDrCrContra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDrCrContra.SelectedIndex == 0)
            {
                pnlCon.Visible = false;
                pnlCheque.Visible = true;
                pnlConPR.Visible = true;
            }
            else if (rdoDrCrContra.SelectedIndex == 1)
            {
                pnlCheque.Visible = false;
                pnlCon.Visible = false;
                pnlConPR.Visible = false;
            }
            else if (rdoDrCrContra.SelectedIndex == 2)
            {
                pnlCon.Visible = true;
                rdoContraDrCr.Enabled = true;
                pnlCheque.Visible = true;
                pnlConPR.Visible = true;
            }


            if (File.Exists(GetXMLFilePath()))
            {
                File.Delete(GetXMLFilePath());
            }

            BindGrid(GetXMLFilePath());
            RightSideVisible();
        }

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoType.SelectedIndex == 0)
            {
                chkCheckNo.Visible = true;
                chkCheckNo.Checked = false;
            }
            else
            {
                chkCheckNo.Visible = false;
            }

            SetCheckNo("");
        }

        protected void chkCheckNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckNo.Checked)
            {
                txtCheckNo.ReadOnly = false;
                txtCheckNo.Text = "";
            }
            else
            {
                txtCheckNo.ReadOnly = true;
            }

            SetCheckNo(hdnChequeNo.Value);
            GridFirstRowChange(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue);
        }

        #endregion

        #region Event Handler DropDownList

        protected void ddlBank_DataBound(object sender, EventArgs e)
        {
            if (hdnVoucherID.Value != "" && !IsPostBack)
            {
                for (int i = 0; i < ddlBank.Items.Count; i++)
                {
                    if (hdnBankID.Value == ddlBank.Items[i].Value)
                    {
                        ddlBank.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        protected void ddlAccount_DataBound(object sender, EventArgs e)
        {
            if (ddlAccount.Items.Count > 0)
            {
                GridFirstRowChange(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue);
            }

            if (hdnVoucherID.Value != "")
            {
                if (!IsPostBack)
                {
                    for (int i = 0; i < ddlAccount.Items.Count; i++)
                    {
                        if (hdnBankAccID.Value == ddlAccount.Items[i].Value)
                        {
                            ddlAccount.SelectedIndex = i;
                            SetCheckNo(hdnChequeNo.Value);
                            break;
                        }
                    }
                }
                else
                {
                    if (ddlAccount.SelectedValue == hdnBankAccID.Value)
                    {
                        SetCheckNo(hdnChequeNo.Value);
                    }
                    else
                    {
                        SetCheckNo("");
                    }
                }
            }
            else
            {
                SetCheckNo("");
            }
        }

        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccount.SelectedValue == hdnBankAccID.Value)
            {
                SetCheckNo(hdnChequeNo.Value);
            }
            else
            {
                SetCheckNo("");
            }
            GridFirstRowChange(ddlAccount.SelectedItem.Text, ddlAccount.SelectedValue);
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            if (hdnUnit.Value != "")
            {
                for (int i = 0; i < ddlUnit.Items.Count; i++)
                {
                    if (ddlUnit.Items[i].Value == hdnUnit.Value)
                    {
                        ddlUnit.SelectedIndex = i;
                        ddlUnit.Enabled = false;
                        break;
                    }
                }
            }

            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            Clearcontrols();
        }

        private void Clearcontrols()
        {
            try
            {
                rdoDrCr.SelectedIndex = 0;
                txtCOA.Text = "";
                txtAmount.Text = "";
            }
            catch { }
        }

        #endregion

        #region GridView

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            RightSideVisible();
            double drAmount = 0, crAmount = 0;
            string nrr = "";

            GetGridDrCrNarr(ref drAmount, ref crAmount, ref nrr, true);

            AmountFormat af = new AmountFormat();
            if (GridView1.Rows.Count > 0)
            {
                GridView1.FooterRow.Cells[2].Text = af.SetCommaInAmount(drAmount, "", "");
                GridView1.FooterRow.Cells[3].Text = af.SetCommaInAmount(crAmount, "", "");
                ((TextBox)GridView1.FooterRow.Cells[1].Controls[1]).Text = nrr;

                if (hdnRdo.Value == "rdoJr")
                {
                    txtAmount.Text = (Math.Abs((drAmount - crAmount))).ToString();
                }
                else
                {
                    //Color & Button modify
                    GridView1.Rows[0].BackColor = Color.AntiqueWhite;
                    GridView1.Rows[0].Cells[4].Controls.RemoveAt(1);
                    GridView1.Rows[0].Cells[5].Controls.RemoveAt(0);
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            DataSet ds = new DataSet();
            string cr = "", dr = "";
            ds.ReadXml(GetXMLFilePath());

            dr = "-" + (ds.Tables[0].Rows[e.RowIndex][xm.Debit].ToString() == "" ? "0" : ds.Tables[0].Rows[e.RowIndex][xm.Debit].ToString());
            cr = "-" + (ds.Tables[0].Rows[e.RowIndex][xm.Credit].ToString() == "" ? "0" : ds.Tables[0].Rows[e.RowIndex][xm.Credit].ToString());

            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.WriteXml(GetXMLFilePath());

            if (hdnRdo.Value != "rdoJr")
            {

                xm.ModifyFirstRow(dr, cr
                    , GetXMLFilePath()
                    , ((hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") ? "bn" : (hdnRdo.Value == "rdoCon" ? "cn" : "ch")));
            }

            BindGrid(GetXMLFilePath());
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BindGrid(GetXMLFilePath());
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            string nrr = ((TextBox)GridView1.Rows[index].Cells[1].Controls[1]).Text;
            string dr = ((TextBox)GridView1.Rows[index].Cells[2].Controls[1]).Text;
            string cr = ((TextBox)GridView1.Rows[index].Cells[3].Controls[1]).Text;


            e.Cancel = true;
            GridView1.EditIndex = -1;
            DataSet ds = new DataSet();
            ds.ReadXml(GetXMLFilePath());
            string drPre = ds.Tables[0].Rows[index][xm.Debit].ToString();
            string crPre = ds.Tables[0].Rows[index][xm.Credit].ToString();

            ds.Tables[0].Rows[index][xm.Debit] = dr;
            ds.Tables[0].Rows[index][xm.Credit] = cr;
            ds.Tables[0].Rows[index][xm.Narration] = nrr;
            ds.WriteXml(GetXMLFilePath());

            if (hdnRdo.Value != "rdoJr")
            {

                xm.ModifyFirstRow(drPre == "" ? "" : ("-" + drPre), crPre == "" ? "" : ("-" + crPre)
                    , GetXMLFilePath()
                    , ((hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") ? "bn" : (hdnRdo.Value == "rdoCon" ? "cn" : "ch")));

                xm.ModifyFirstRow(dr, cr
                    , GetXMLFilePath()
                    , ((hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") ? "bn" : (hdnRdo.Value == "rdoCon" ? "cn" : "ch")));
            }

            BindGrid(GetXMLFilePath());

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindGrid(GetXMLFilePath());
        }

        #endregion GridView

        #region Private Methods

        private void Redirection()
        {
            if (hdnVoucherID.Value != "")
            {
                if (hdnRdo.Value == "rdoDrBnk" || hdnRdo.Value == "rdoCrBnk") Response.Redirect("BankVoucher.aspx");
                else if (hdnRdo.Value == "rdoDrCsh" || hdnRdo.Value == "rdoCrCsh") Response.Redirect("CashVoucher.aspx");
                else if (hdnRdo.Value == "rdoJr") Response.Redirect("JournalVoucher.aspx");
                else if (hdnRdo.Value == "rdoCon") Response.Redirect("ContraVoucher.aspx");
            }
        }
        private void SetCheckNo(string chequeNo)
        {
            if (chequeNo == "")
            {
                if (rdoType.SelectedIndex == 0)
                {
                    if (hdnBankAccID.Value == ddlAccount.SelectedValue && hdnChequeNo.Value != advice && hdnChequeNo.Value != adjustment)
                    {
                        txtCheckNo.Text = hdnChequeNo.Value;
                    }
                    else
                    {
                        if (chkCheckNo.Checked)
                        {
                            txtCheckNo.Text = "";
                        }
                        else
                        {
                            BankCheck bc = new BankCheck();
                            txtCheckNo.Text = bc.GetCheckNo(ddlAccount.SelectedValue);
                        }
                    }
                }
                else if (rdoType.SelectedIndex == 1)
                {
                    BankCheck bc = new BankCheck();
                    advice = bc.GetAdviceNo(int.Parse(ddlUnit.SelectedValue.ToString())); 
                    txtCheckNo.Text = advice;
                }
                else if (rdoType.SelectedIndex == 2) {txtCheckNo.Text = adjustment;}
                else
                {
                    txtCheckNo.Text = "";
                }
            }
            else
            {
                if (hdnIsManualChqNo.Value == "false" && !chkCheckNo.Checked)
                {
                    txtCheckNo.Text = chequeNo;
                }
                else if (hdnIsManualChqNo.Value == "false" && chkCheckNo.Checked)
                {
                    txtCheckNo.Text = "";
                }
                else if (hdnIsManualChqNo.Value == "true" && chkCheckNo.Checked)
                {
                    txtCheckNo.Text = chequeNo;
                }
                else if (hdnIsManualChqNo.Value == "true" && !chkCheckNo.Checked)
                {
                    BankCheck bc = new BankCheck();
                    txtCheckNo.Text = bc.GetCheckNo(ddlAccount.SelectedValue);
                }
            }

        }
        private void RadioBtnChange(string buttonID)
        {
            if (!pnlMain.Visible)
            {
                pnlMain.Visible = true;
            }

            if (buttonID == "rdoDrBnk")
            {
                pnlBank.Visible = true;
                pnlCheque.Visible = true;
                pnlReceive.Visible = true;
                pnlBankR.Visible = false;
                pnlAccHead.Visible = true;
                pnlContra.Visible = false;
                pnlConPR.Visible = false;

                rdoDrCr.SelectedIndex = 0;
                rdoDrCr.Enabled = false;

                lblPR.Text = "Pay To";
                SetCheckNo("");
                rdoDrBnk.Checked = true;

                //APBML
                if (ddlUnit.SelectedValue == "1")
                {
                    txtNarration.Text = "Being the amount paid to ";
                }
            }
            else if (buttonID == "rdoCrBnk")
            {
                pnlBank.Visible = true;
                pnlCheque.Visible = false;
                pnlReceive.Visible = true;
                pnlBankR.Visible = true;
                pnlAccHead.Visible = true;
                pnlContra.Visible = false;
                pnlConPR.Visible = false;

                rdoDrCr.Enabled = false;
                rdoDrCr.SelectedIndex = 1;

                lblPR.Text = "Receive From";
                txtCheckNo.Text = "";
                rdoCrBnk.Checked = true;

                if (rdoTypeR.Attributes.Count <= 0)
                {
                    rdoTypeR.Attributes.Add("onclick", "ChangeRdoTypeR()");
                }

                //APBML
                if (ddlUnit.SelectedValue == "1")
                {
                    txtNarration.Text = "Being the amount received against Particle Board sales.";
                }
            }
            else if (buttonID == "rdoDrCsh")
            {
                pnlBank.Visible = false;
                pnlReceive.Visible = true;
                pnlBankR.Visible = false;
                pnlAccHead.Visible = true;
                pnlContra.Visible = false;
                pnlConPR.Visible = false;

                rdoDrCr.SelectedIndex = 0;
                rdoDrCr.Enabled = false;

                lblPR.Text = "Pay To";
                rdoDrCsh.Checked = true;

                //APBML
                if (ddlUnit.SelectedValue == "1")
                {
                    txtNarration.Text = "Being the amount paid to ";
                }
            }
            else if (buttonID == "rdoCrCsh")
            {
                pnlBank.Visible = false;
                pnlReceive.Visible = true;
                pnlBankR.Visible = false;
                pnlAccHead.Visible = true;
                pnlContra.Visible = false;
                pnlConPR.Visible = false;

                lblPR.Text = "Receive From";

                rdoDrCr.SelectedIndex = 1;
                rdoDrCr.Enabled = false;
                rdoCrCsh.Checked = true;

                //APBML
                if (ddlUnit.SelectedValue == "1")
                {
                    txtNarration.Text = "Being the amount received against Particle Board sales.";
                }
            }
            else if (buttonID == "rdoJr")
            {
                pnlBank.Visible = false;
                pnlReceive.Visible = false;
                pnlAccHead.Visible = true;
                pnlContra.Visible = false;
                pnlConPR.Visible = false;

                rdoDrCr.SelectedIndex = 0;
                rdoDrCr.Enabled = true;
                rdoJr.Checked = true;

                txtNarration.Text = "Being the amount ";
            }
            else if (buttonID == "rdoCon")
            {
                pnlCheque.Visible = true;
                pnlAccHead.Visible = false;
                pnlBank.Visible = true;
                pnlContra.Visible = true;
                pnlReceive.Visible = false;
                pnlConPR.Visible = true;

                txtNarration.Text = "Being the amount ";
            }
            else pnlBank.Visible = false;

            BindGrid(GetXMLFilePath());
            RightSideVisible();

        }
        private void ViewAfterSave(bool isSuccess, string code, string chqNo, string pr, string id, string type, bool? isDr, bool isChqPrint, bool isMRPrint, string unitID)
        {
            if (isSuccess)
            {
                pnlAfterSave.Visible = true;
                pnlErrorToSave.Visible = false;

                lblCVC.Text = code;
                lblCChq.Text = chqNo;
                lblCPR.Text = pr;

                lblCChqMr.Text = "";
                if (isChqPrint) lblCChqMr.Text = @"<a href=""#"" onclick=""ShowPopUp('../Print/PrintCheck.aspx?id=" + id + @"')""
                                                class=""link"">Cheque Print</a>";
                if (isMRPrint) lblCChqMr.Text = @"<a href=""#"" onclick=""ShowPopUp('../Print/PrintMR.aspx?id=" + id + @"&type=" + type + @"')""
                                                class=""link"">MR Print</a>";
                lblCDetails.Text = @"<a href=""#"" onclick=""ShowPopUp('VoucherDetails.aspx?id=" + id + @"&type=" + type + @"&isDr=" + isDr.ToString().ToLower() + @"')""
                                                class=""link"">Details</a>";
                lblCEdit.Text = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntryEdit.aspx?id=" + id + "&type=" + type + @"&isDr=" + isDr.ToString().ToLower() + "&unit=" + unitID + "')\"class=\"link\">Edit</a>";
                lblCVcrPrint.Text = @"<a href=""#"" onclick=""ShowPopUp('../Print/PrintVoucher.aspx?id=" + id + @"&type=" + type + @"&isDr=" + isDr.ToString().ToLower() + @"')""
                                                class=""link"">Voucher Print</a>";


                btnCComplete.Visible = true;
                btnCComplete.CommandArgument = id + "#" + type + "#" + isDr.ToString().ToLower() + "#" + unitID;
            }
            else
            {
                pnlAfterSave.Visible = false;
                pnlErrorToSave.Visible = true;
            }
        }

        private double GetAmount(string str)
        {
            string sign = "";
            char[] chP = { '+', '-' };
            string[] dataP;
            double amount = 0;
            double tmp = 0;

            dataP = str.Split(chP);

            for (int i = 0; i < dataP.Length; i++)
            {
                tmp = double.Parse(dataP[i]);

                if (sign == "")
                {
                    amount = tmp;
                }
                else
                {
                    if (sign == "+") amount += tmp;
                    else if (sign == "-") amount -= tmp;
                }

                if (dataP.Length - 1 > i)
                {
                    sign = str.Substring(dataP[i].Length, 1);
                    str = str.Substring(dataP[i].Length + 1);
                }
            }

            return amount;
        }

        #region Set For Update

        private void SetBankVoucherInfo(bool isDR)
        {

            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
            BankVoucherTDS.QryAccountsVoucherBankDataTable tblQ = bv.GetBankVoucherByID(hdnVoucherID.Value);

            if (hdnRdo.Value == "rdoCrBnk")
            {
                if (tblQ[0].ysnCheque) rdoTypeR.SelectedIndex = 0;
                else if (tblQ[0].ysnDemandDraft) rdoTypeR.SelectedIndex = 1;
                else if (tblQ[0].ysnPayOrder) rdoTypeR.SelectedIndex = 2;
                else if (tblQ[0].ysnDepositSlip) rdoTypeR.SelectedIndex = 3;
                else if (tblQ[0].ysnAdvance) rdoTypeR.SelectedIndex = 5;
                else if (tblQ[0].ysnAdjustment) rdoTypeR.SelectedIndex = 6;
                else if (tblQ[0].ysnOnline) rdoTypeR.SelectedIndex = 4;

                txtCheckNoR.Text = tblQ[0].strChequeNo;
            }
            else if (hdnRdo.Value == "rdoDrBnk")
            {
                if (tblQ[0].ysnCheque) rdoType.SelectedIndex = 0;
                else if (tblQ[0].ysnAdvance) rdoType.SelectedIndex = 1;
                else if (tblQ[0].ysnAdjustment) rdoType.SelectedIndex = 2;

                txtCheckNo.Text = tblQ[0].strChequeNo;
            }

            if (tblQ.Rows.Count > 0)
            {
                txtVoucherDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tblQ[0].dteVoucherDate);
                if (hdnRdo.Value == "rdoDrBnk")
                {
                    //hdnAccountIDPR.Value = (!tblQ[0].IsintPayToNull() ? tblQ[0].intPayTo.ToString() : "");
                    txtPRPrint.Text = tblQ[0].strPayToPrint;
                    hdnChequeNo.Value = tblQ[0].strChequeNo;
                    txtChqDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tblQ[0].dteChequeDate);
                    if (tblQ[0].ysnChqManualEntry)
                    {
                        chkCheckNo.Checked = true;
                        txtCheckNo.ReadOnly = false;
                        hdnIsManualChqNo.Value = "true";
                    }
                    else
                    {
                        hdnIsManualChqNo.Value = "false";
                    }
                }
                else
                {
                    //hdnAccountIDPR.Value = (!tblQ[0].IsintReceivedFromNull() ? tblQ[0].intReceivedFrom.ToString() : "");
                    txtPRPrint.Text = tblQ[0].strReceiveFromPrint;
                    txtCheckNoR.Text = tblQ[0].strChequeNo;
                    txtChqDateR.Text = CommonClass.GetShortDateAtLocalDateFormat(tblQ[0].dteChequeDate);
                    txtBank.Text = !tblQ[0].IsstrDepositorBankNull() ? tblQ[0].strDepositorBank : "";
                    txtBranch.Text = !tblQ[0].IsstrDepositorBranchNull() ? tblQ[0].strDepositorBranch : "";
                    txtDrawn.Text = !tblQ[0].IsstrDepositorDrawnNull() ? tblQ[0].strDepositorDrawn : "";
                }

                txtRemarks.Text = !tblQ[0].IsstrRemarksNull() ? tblQ[0].strRemarks : "";
                hdnBankAccID.Value = tblQ[0].intBankAccID.ToString();
                hdnBankID.Value = tblQ[0].intBankID.ToString();

                xm.CreateFirstRow(tblQ[0].strAccountNo, hdnBankAccID.Value, isDR, "bn", GetXMLFilePath());
                xm.ModifyFirstRow((isDR ? string.Format("{0:F2}", Math.Abs(tblQ[0].monAmount)) : ""), (isDR ? "" : string.Format("{0:F2}", Math.Abs(tblQ[0].monAmount))), GetXMLFilePath(), "bn");

                BankVoucherTDS.QryAccountsVoucherBankDetailsDataTable tbl = bv.GetBankVoucherDetailsByID(hdnVoucherID.Value);
                XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                string[][] items;
                string drAmount = "", crAmount = "";

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (tbl[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(tbl[i].monAmount)); drAmount = ""; }
                    else { drAmount = string.Format("{0:F2}", Math.Abs(tbl[i].monAmount)); crAmount = ""; }
                    items = xm.CreateItems(tbl[i].strAccName, tbl[i].intAccID.ToString(), tbl[i].strNarration, drAmount, crAmount);
                    if (items != null)
                    {
                        selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    }
                }
                xmlDoc.Save(GetXMLFilePath());
            }
        }

        private void SetCashVoucherInfo(bool isDR)
        {
            BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
            CashVoucherTDS.TblAccountsVoucherCashDataTable tbl = cv.GetCashVoucherByID(hdnVoucherID.Value);

            if (tbl.Rows.Count > 0)
            {
                txtVoucherDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tbl[0].dteVoucherDate);
                if (hdnRdo.Value == "rdoDrCsh")
                {
                    //hdnAccountIDPR.Value = (!tbl[0].IsintPayToNull() ? tbl[0].intPayTo.ToString() : "");
                    txtPRPrint.Text = tbl[0].strPayToPrint;
                }
                else
                {
                    //hdnAccountIDPR.Value = (!tbl[0].IsintReceivedFromNull() ? tbl[0].intReceivedFrom.ToString() : "");
                    txtPRPrint.Text = tbl[0].strReceiveFromPrint;
                }

                xm.CreateFirstRow("", "", isDR, "ch", GetXMLFilePath());
                xm.ModifyFirstRow((isDR ? string.Format("{0:F2}", Math.Abs(tbl[0].monAmount)) : ""), (isDR ? "" : string.Format("{0:F2}", Math.Abs(tbl[0].monAmount))), GetXMLFilePath(), "ch");

                XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                string[][] items;
                string drAmount = "", crAmount = "";

                CashVoucherTDS.QryAccountsVoucherCashDetailsDataTable table = cv.GetCashVoucherDetailsByID(hdnVoucherID.Value);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                    else { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                    items = xm.CreateItems(table[i].strAccName, table[i].intAccID.ToString(), table[i].strNarration, drAmount, crAmount);
                    if (items != null)
                    {
                        selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    }
                }
                xmlDoc.Save(GetXMLFilePath());
            }
        }

        private void SetJournalVoucherInfo()
        {
            BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();

            JournalVoucherTDS.TblAccountsVoucherJournalDataTable tbl = jv.GetJournalVoucherByID(hdnVoucherID.Value);
            txtVoucherDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tbl[0].dteVoucherDate);

            JournalVoucherTDS.QryAccountsVoucherJournalDetailsDataTable table = jv.GetJournalVoucherDetailsByID(hdnVoucherID.Value);


            XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
            XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

            string[][] items;
            string drAmount = "", crAmount = "";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                else { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                items = xm.CreateItems(table[i].strAccName, table[i].intAccID.ToString(), table[i].strNarration, drAmount, crAmount);
                if (items != null)
                {
                    selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                }
            }
            xmlDoc.Save(GetXMLFilePath());
        }

        private void SetContraVoucherInfo()
        {
            BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
            ContraVoucherTDS.QryAccountsVoucherContraDataTable tbl = cv.GetContraVoucherByID(hdnVoucherID.Value);

            if (tbl.Rows.Count > 0)
            {
                txtVoucherDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tbl[0].dteVoucherDate);
                txtChqDate.Text = CommonClass.GetShortDateAtLocalDateFormat(tbl[0].dteChequeDate);
                txtCheckNo.Text = tbl[0].strChequeNo;
                hdnChequeNo.Value = tbl[0].strChequeNo;
                txtConPR.Text = tbl[0].strChqBearer;
                chkCheckNo.Checked = tbl[0].ysnChqManualEntry;

                if (tbl[0].ysnCheque) rdoType.SelectedIndex = 0;
                else if (tbl[0].ysnAdvance) rdoType.SelectedIndex = 1;
                else if (tbl[0].ysnAdjustment) rdoType.SelectedIndex = 2;

                hdnBankID.Value = tbl[0].intBankID.ToString();
                hdnBankAccID.Value = tbl[0].intBankAccountID.ToString();

                if (tbl[0].intType == 0) rdoDrCrContra.SelectedIndex = 0;
                else if (tbl[0].intType == 1) rdoDrCrContra.SelectedIndex = 1;
                else if (tbl[0].intType == 2)
                {
                    rdoDrCrContra.SelectedIndex = 2;
                    pnlCon.Visible = true;
                    if (tbl[0].monAmount < 0) rdoContraDrCr.SelectedIndex = 0;
                    else rdoContraDrCr.SelectedIndex = 1;
                    rdoContraDrCr.Enabled = false;

                }
                rdoDrCrContra.Enabled = false;

                bool isDR = tbl[0].monAmount >= 0 ? false : true;
                xm.CreateFirstRow(tbl[0].strAccountNo, "", isDR, "cn", GetXMLFilePath());
                xm.ModifyFirstRow((isDR ? string.Format("{0:F2}", Math.Abs(tbl[0].monAmount)) : ""), (isDR ? "" : string.Format("{0:F2}", Math.Abs(tbl[0].monAmount))), GetXMLFilePath(), "cn");

                XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                string[][] items;
                string drAmount = "", crAmount = "";

                ContraVoucherTDS.TblAccountsVoucherContraDetailsDataTable table = cv.GetContraVoucherDetailsByID(hdnVoucherID.Value);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                    else { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                    items = xm.CreateItems(table[i].strAccName, table[i].intAccID.ToString(), table[i].strNarration, drAmount, crAmount);
                    if (items != null)
                    {
                        selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    }
                }
                xmlDoc.Save(GetXMLFilePath());
            }
        }

        #endregion

        #region XML

        private void GridFirstRowChange(string accText, string accID)
        {
            double drAmount = 0, crAmount = 0;
            string nrr = "";
            GetGridDrCrNarr(ref drAmount, ref crAmount, ref nrr, false);

            xm.ChangeFirstRow(GetXMLFilePath(), accText, accID);
            BindGrid(GetXMLFilePath());
        }
        private void BindGrid(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath)) xm.LoadXmlFile(xmlFilePath);

            XmlDataSource1.Dispose();
            XmlDataSource1.DataFile = xmlFilePath;
            GridView1.DataBind();
        }
        private void GetGridDrCrNarr(ref double drAmount, ref double crAmount, ref string narr, bool isNeedNarr)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (GridView1.Rows[i].Cells[2].Controls[1].GetType().Name == "Label")
                    {
                        string str = ((Label)GridView1.Rows[i].Cells[2].Controls[1]).Text.Trim();
                        if (str != "") drAmount += double.Parse(str);

                        str = ((Label)GridView1.Rows[i].Cells[3].Controls[1]).Text.Trim();
                        if (str != "") crAmount += double.Parse(str);

                        if (isNeedNarr)
                        {
                            str = ((Label)GridView1.Rows[i].Cells[1].Controls[1]).Text.Trim();
                            if (str != "")
                            {
                                //narr += str + ", ";
                                narr = str;
                            }
                        }
                    }
                    else
                    {
                        string str = ((TextBox)GridView1.Rows[i].Cells[2].Controls[1]).Text.Trim();
                        if (str != "") drAmount += double.Parse(str);

                        str = ((TextBox)GridView1.Rows[i].Cells[3].Controls[1]).Text.Trim();
                        if (str != "") crAmount += double.Parse(str);

                        if (isNeedNarr)
                        {
                            str = ((TextBox)GridView1.Rows[i].Cells[1].Controls[1]).Text.Trim();
                            if (str != "")
                            {
                                narr += str + ", ";
                            }
                        }
                    }
                }
            }

            hdnGridCrAmount.Value = crAmount.ToString();
            hdnGridDrAmount.Value = drAmount.ToString();
        }
        private void RightSideVisible()
        {
            if (hdnVoucherID.Value == "")
            {
                if (GridView1.Rows.Count > 0)
                {
                    if (pnlMain.Visible) pnlGrid.Visible = true;
                }
                else
                {
                    pnlGrid.Visible = false;
                }
            }
            else
            {
                pnlGrid.Visible = true;
            }
        }
        private string GetXMLFilePathTemp()
        {
            return Server.MapPath("") + "/Data/tmp_" + Session[SessionParams.USER_ID] + ".xml";
        }

       

        private string GetXMLFilePath()
        {
            if (!File.Exists(hdnXMLFilePath.Value))
            {
                string unit = "";
                unit = "" + hdnUnit.Value;
                if (unit == "") unit = ddlUnit.SelectedValue;

                string xmlFilePath = "";
                xmlFilePath = Server.MapPath("") + "/Data/" + Session[SessionParams.USER_ID] + "_" + unit + "_voucher";
                if (hdnRdo.Value == "rdoCrBnk") xmlFilePath += "CB";
                else if (hdnRdo.Value == "rdoCrCsh") xmlFilePath += "CC";
                else if (hdnRdo.Value == "rdoDrBnk") xmlFilePath += "DB";
                else if (hdnRdo.Value == "rdoDrCsh") xmlFilePath += "DC";
                else if (hdnRdo.Value == "rdoJr") xmlFilePath += "JR";
                else if (hdnRdo.Value == "rdoCon") xmlFilePath += "CN";
                xmlFilePath += ".xml";

                hdnXMLFilePath.Value = xmlFilePath;

                return xmlFilePath;
            }
            else
            {
                return hdnXMLFilePath.Value;
            }
        }

        #endregion

        protected void txtCOA_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

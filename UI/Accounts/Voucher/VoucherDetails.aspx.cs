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
using BLL.Accounts.Voucher;
using DAL.Accounts.Voucher;
using System.IO;
using System.Xml;
using BLL;
using System.Drawing;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Voucher
{
    public partial class VoucherDetails : BasePage
    {
        XmlManager xm = new XmlManager();
        string id = "";
        string rdoBtn = "rdo";
        string xmlFilePath = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Voucher\\VoucherDetails";
        string stop = "stopping Accounts\\Voucher\\VoucherDetails";

        protected override void OnPreInit(EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\VoucherDetails   show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                base.OnPreInit(e);

            //Session["sesUserID"] = "1";

            BankVoucherTDS.QryAccountsVoucherBankDataTable tblQ;
            bool isDR = false;

            if (Request.QueryString.Count > 0)
            {
                id = Request.QueryString["id"];
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
                else if (Request.QueryString["type"] == "cn")
                {
                    rdoBtn += "Cn";
                }
                else { rdoBtn += "Jr"; }

                if (rdoBtn == "rdoDrBnk") { isDR = true; }
                else if (rdoBtn == "rdoCrBnk") { isDR = false; }
                else if (rdoBtn == "rdoDrCsh") { isDR = true; }
                else if (rdoBtn == "rdoCrCsh") { isDR = false; }
            }

            //For Update
            if (id != "")
            {
                if (File.Exists(GetXMLFilePath())) File.Delete(GetXMLFilePath());

                //for bank voucher
                if (rdoBtn == "rdoDrBnk" || rdoBtn == "rdoCrBnk")
                {
                    if (rdoBtn == "rdoDrBnk") GridView1.Caption = "Bank Pay Voucher";
                    else GridView1.Caption = "Bank Receive Voucher";

                    BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
                    tblQ = bv.GetBankVoucherByID(id);

                    if (tblQ.Rows.Count > 0)
                    {
                        xm.CreateFirstRow((tblQ[0].strBankName + "  [" + tblQ[0].strAccountNo + "]"), tblQ[0].intBankAccID.ToString(), isDR, "bn", GetXMLFilePath(), "");
                        xm.ModifyFirstRow((isDR ? Math.Abs(tblQ[0].monAmount).ToString() : ""), (isDR ? "" : Math.Abs(tblQ[0].monAmount).ToString()), GetXMLFilePath(), "bn");

                        BankVoucherTDS.QryAccountsVoucherBankDetailsDataTable tbl = bv.GetBankVoucherDetailsByID(id);
                        XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                        XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                        string[][] items;
                        string drAmount = "", crAmount = "";

                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            if (tbl[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(tbl[i].monAmount)); drAmount = ""; }
                            else { drAmount = string.Format("{0:F2}", Math.Abs(tbl[i].monAmount)); crAmount = ""; }
                            items = xm.CreateItems(tbl[i].strAccName, tbl[i].intAccID.ToString(), tbl[i].strNarration, drAmount, crAmount, tbl[i].strCode);
                            if (items != null)
                            {
                                selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                            }
                        }
                        xmlDoc.Save(GetXMLFilePath());
                    }
                }
                //Cash voucher
                else if (rdoBtn == "rdoDrCsh" || rdoBtn == "rdoCrCsh")
                {
                    if (rdoBtn == "rdoDrCsh") GridView1.Caption = "Cash Pay Voucher";
                    else GridView1.Caption = "Cash Receive Voucher";

                    BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
                    CashVoucherTDS.TblAccountsVoucherCashDataTable tbl = cv.GetCashVoucherByID(id);
                    if (tbl.Rows.Count > 0)
                    {
                        xm.CreateFirstRow("", "", isDR, "ch", GetXMLFilePath(), "");
                        xm.ModifyFirstRow((isDR ? Math.Abs(tbl[0].monAmount).ToString() : ""), (isDR ? "" : Math.Abs(tbl[0].monAmount).ToString()), GetXMLFilePath(), "ch");

                        XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                        XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                        string[][] items;
                        string drAmount = "", crAmount = "";

                        CashVoucherTDS.QryAccountsVoucherCashDetailsDataTable table = cv.GetCashVoucherDetailsByID(id);

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (table[i].monAmount < 0) { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                            else { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                            items = xm.CreateItems(table[i].strAccName, table[i].intAccID.ToString(), table[i].strNarration, drAmount, crAmount, table[i].strCode);
                            if (items != null)
                            {
                                selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                            }
                        }
                        xmlDoc.Save(GetXMLFilePath());
                    }
                }
                //journal voucher
                else if (rdoBtn == "rdoJr")
                {
                    GridView1.Caption = "Journal Voucher";

                    BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
                    JournalVoucherTDS.QryAccountsVoucherJournalDetailsDataTable table = jv.GetJournalVoucherDetailsByID(id);

                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                    string[][] items;
                    string drAmount = "", crAmount = "";

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table[i].monAmount > 0) { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                        else { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                        items = xm.CreateItems(table[i].strAccName, table[i].intAccID.ToString(), table[i].strNarration, drAmount, crAmount, table[i].strCode);
                        if (items != null)
                        {
                            selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                        }
                    }
                    xmlDoc.Save(GetXMLFilePath());
                }
                //contra voucher
                else if (rdoBtn == "rdoCn")
                {
                    GridView1.Caption = "Journal Voucher";

                    BLL.Accounts.Voucher.ContraVoucher cnt = new BLL.Accounts.Voucher.ContraVoucher();
                    ContraVoucherTDS.QryAccountsVoucherContraDataTable table = cnt.GetContraVoucherByID(id);

                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXMLFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);

                    string[][] items;
                    string drAmount = "", crAmount = "";

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table[i].monAmount > 0) { drAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); crAmount = ""; }
                        else { crAmount = string.Format("{0:F2}", Math.Abs(table[i].monAmount)); drAmount = ""; }
                        items = xm.CreateItems(table[i].strAccountNo, table[i].intBankAccountID.ToString(), table[i].strNarration, drAmount, crAmount, table[i].strCode);
                        if (items != null)
                        {
                            selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                        }
                    }
                    xmlDoc.Save(GetXMLFilePath());
                }
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "show", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!File.Exists(xmlFilePath)) xm.LoadXmlFile(xmlFilePath);

            XmlDataSource1.Dispose();
            XmlDataSource1.DataFile = xmlFilePath;
            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            double drAmount = 0, crAmount = 0;

            GetGridDrCrNarr(ref drAmount, ref crAmount);

            AmountFormat af = new AmountFormat();
            if (GridView1.Rows.Count > 0)
            {
                GridView1.FooterRow.Cells[3].Text = af.SetCommaInAmount(drAmount, "", "");
                GridView1.FooterRow.Cells[4].Text = af.SetCommaInAmount(crAmount, "", "");
            }
        }

        private string GetXMLFilePath()
        {
            if (!File.Exists(xmlFilePath))
            {
                xmlFilePath = Server.MapPath("") + "/Data/" + Session[SessionParams.USER_ID] + "_voucher";
                if (rdoBtn == "rdoCrBnk") xmlFilePath += "CB";
                else if (rdoBtn == "rdoCrCsh") xmlFilePath += "CC";
                else if (rdoBtn == "rdoDrBnk") xmlFilePath += "DB";
                else if (rdoBtn == "rdoDrCsh") xmlFilePath += "DC";
                else if (rdoBtn == "rdoJr") xmlFilePath += "JR";
                xmlFilePath += "D.xml";

                return xmlFilePath;
            }
            else
            {
                return xmlFilePath;
            }
        }
        private void GetGridDrCrNarr(ref double drAmount, ref double crAmount)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    string str = ((Label)GridView1.Rows[i].Cells[3].Controls[1]).Text.Trim();
                    if (str != "") drAmount += double.Parse(str);

                    str = ((Label)GridView1.Rows[i].Cells[4].Controls[1]).Text.Trim();
                    if (str != "") crAmount += double.Parse(str);
                }
            }
        }
    }
}

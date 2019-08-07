using BLL.Accounts.Advice;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections;
using System.Collections.Generic;
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
using UI.ClassFiles;
using Utility;

namespace UI.Accounts.Advice
{
    public partial class VoucherPrint : BasePage
    {
        //UI.ClassFiles.Print printVoucher = new UI.ClassFiles.Print();
        string htmlString = "";
        SeriLog log = new SeriLog();
        AdviceBLL bll = new AdviceBLL();
        DataTable dtt = new DataTable();
        protected decimal totalSamount = 0, totalCamount=0;
        string location = "Accounts";
        string start = "starting Accounts\\Advice\\VoucherPrint";
        string stop = "stopping Accounts\\Advice\\VoucherPrint";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Request.QueryString.Count > 0)
            //{
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\Advice\\VoucherPrint  Voucher Print", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    string adviceForBank = Request.QueryString["adviceForBank"];
                    string intInsertBy = Request.QueryString["insertBy"];
                    string UnitId = Request.QueryString["unitId"];
                    string unitName = "";
                    string unitAddress = "";
                    string strCodeForbarCode = "";
                    string voucherCode = "";
                    bool isDebitVoucher = false;

                    dtt = bll.PaymentAdviceEntry(1, Convert.ToInt32(intInsertBy),Convert.ToInt32(UnitId), adviceForBank, "");

                    //List<string> voucherList = new List<string>(dtt.Rows.Count);

                    foreach(DataRow row in dtt.Rows){
                        //voucherList.Add((string)row["VoucherNo"]);
                        string voucher = (string)row["VoucherNo"];

                        DataTable dt = new DataTable();
                        dt = bll.GetVoucherPrintData(voucher,Convert.ToInt32(UnitId),0);

                        lblUnitAddress.Text = dt.Rows[0]["strUnitAddress"].ToString();
                        lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                        lblaccDetails.Text = dt.Rows[0]["strAccDetails"].ToString();
                        lblIntrumentNo.Text = dt.Rows[0]["strInstrument"].ToString();
                        lblIntrumentDate.Text = dt.Rows[0]["strInstrumentDate"].ToString();
                        lblVoucherNo.Text = dt.Rows[0]["strVoucher"].ToString();
                        lblVoucherDate.Text = dt.Rows[0]["strVoucherDate"].ToString();
                        lblDescription.Text = dt.Rows[0]["strNarration"].ToString();
                        
                        dt = new DataTable();
                        dt = bll.GetVoucherPrintData(voucher, Convert.ToInt32(UnitId), 1);

                        dgvAdvice.Loads(dt);

                        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Print();", true);

                }


                }
                catch(Exception ex)
                {
                    string msg = ex.Message;
                }
            }

        //}

        #region ---previous code------

        //         try
        //                {
        //                    isDebitVoucher = bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
        //    }
        //                catch
        //                {
        //                }


        ///*
        //string id = "13";
        //string type = "ch";//Bank > bn ,Cash > ch, Journal > jr
        //bool isDebitVoucher = true;//bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
        //*/
        //string voucherType = "";
        //                if (isDebitVoucher)
        //                {
        //                    voucherType = "Debit Voucher";
        //                }
        //                else
        //                {
        //                    voucherType = "Credit Voucher";
        //                }

        //                string unitID = "";
        //                if (type == "bn") // Bank Voucher
        //                {
        //                    voucherType = voucherType + " (BANK)";
        //                    htmlString = printVoucher.PrintBankVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
        //                }
        //                else if (type == "ch")// Cash Voucher
        //                {
        //                    voucherType = voucherType + " (CASH)";

        //                    htmlString = printVoucher.PrintCashVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);

        //                }
        //                else if (type == "cn")
        //                {
        //                    voucherType = "Contra";
        //                    htmlString = printVoucher.PrintContraVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
        //                }
        //                else // Journel Voucher
        //                {
        //                    voucherType = "Journal Voucher";
        //                    htmlString = printVoucher.PrintJournalVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
        //                }

        //                //string jsString = "<script type=\"text/javascript\">";
        //                //jsString = jsString + "DivItem(" + htmlString + ")";
        //                //jsString = "</script>";
        //                //Response.Write(jsString);
        //                //lblUnitName.Text = unitName.ToUpper();
        //                //lblUnitAddress.Text = unitAddress;
        //                //lblVoucherType.Text = "<br><br>" + voucherType;
        //                //strCodeForbarCode = strCodeForbarCode.Replace("-", "");
        //                //Image1.ImageUrl = "BarCodeHandler.ashx?info=" + strCodeForbarCode;
        //                //Image1.Width = 180;
        //                //Image1.Height = 50;

        //                ////logo image
        //                //Image2.ImageUrl = "../../Content/Images/img/" + unitID + ".png";
        //                ////Image2.Width = 180;
        //                ////Image2.Height = 50;
        //                //Label1.Text = htmlString;
        //                }
        //                catch (Exception ex)
        //                {
        //                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
        //Flogger.WriteError(efd);
        //                }



        //                fd = log.GetFlogDetail(stop, location, "Show", null);
        //                Flogger.WriteDiagnostic(fd);
        //                // ends
        //                tracker.Stop();

        #endregion

        protected void dgvAdvice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string replaceSamount = ((Label)e.Row.Cells[2].FindControl("lblSAccount")).Text.Replace(",", "");
                string replaceCamount = ((Label)e.Row.Cells[2].FindControl("lblSAccount")).Text.Replace(",", "");
                totalSamount += decimal.Parse(replaceSamount);
                totalCamount += decimal.Parse(replaceCamount);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
             if(totalCamount==totalSamount)
                {
                    Label lbls = (Label)(e.Row.FindControl("lblSTotal"));
                    lbls.Text = String.Format("{0:n}", totalSamount);
                    Label lblc = (Label)(e.Row.FindControl("lblCTotal"));
                    lblc.Text = String.Format("{0:n}", totalCamount);
                    AmountFormat formatAmount = new AmountFormat();
                    string totalAmountInWord = formatAmount.GetTakaInWords(totalCamount, "", "Only");
                   
                    lblMoneyToWord.Text = "In Word: " + totalAmountInWord.ToString(); 
                }
                
            }
        }
    }
}
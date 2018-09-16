using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class PrintVoucher : BasePage
    {
        UI.ClassFiles.Print printVoucher = new UI.ClassFiles.Print();
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        string htmlString = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\PartyPayment\\PrintVoucher";
        string stop = "stopping Accounts\\PartyPayment\\PrintVoucher";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\PrintVoucher   Page Load Report ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                //Session["sesUserID"] = "1";
                string userID = "" + Session[SessionParams.USER_ID];
            imgprepared.Visible = false; imgchecked.Visible = false; imgapproved.Visible = false; imgfinalapproved.Visible = false;
            if (Request.QueryString.Count > 0)
            {


                string id = Request.QueryString["id"];
                string type = Request.QueryString["type"];//Bank > bn ,Cash > ch, Journal > jr
                string unitName = "";
                string unitAddress = "";
                string strCodeForbarCode = "";
                string voucherCode = "";
                bool isDebitVoucher = false;

                try
                {
                    isDebitVoucher = bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
                }
                catch
                {
                }


                /*
                string id = "13";
                string type = "ch";//Bank > bn ,Cash > ch, Journal > jr
                bool isDebitVoucher = true;//bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
                */
                string voucherType = "";
                if (isDebitVoucher)
                {
                    voucherType = "Debit Voucher";
                }
                else
                {
                    voucherType = "Credit Voucher";
                }

                string unitID = "";
                if (type == "bn") // Bank Voucher
                {
                    voucherType = voucherType + " (BANK)";
                    htmlString = printVoucher.PrintBnkVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }
                else if (type == "ch")// Cash Voucher
                {
                    voucherType = voucherType + " (CASH)";

                    htmlString = printVoucher.PrintCashVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);

                }
                else if (type == "cn")
                {
                    voucherType = "Contra";
                    htmlString = printVoucher.PrintContraVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }
                else // Journel Voucher
                {
                    voucherType = "Journal Voucher";
                    htmlString = printVoucher.PrintJournalVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }

                lblUnitName.Text = unitName.ToUpper();
                lblUnitAddress.Text = unitAddress;
                lblVoucherType.Text = "<br><br>" + voucherType;
                strCodeForbarCode = strCodeForbarCode.Replace("-", "");
                Image1.ImageUrl = "../Print/BarCodeHandler.ashx?info=" + strCodeForbarCode;
                Image1.Width = 180;
                Image1.Height = 50;

                //logo image
                Image2.ImageUrl = "../../Content/Images/img/" + unitID + ".png";

                //1030,1036,1049,33093
                DataTable dtble = new DataTable();
                dtble = objPartyBill.GetSignatureDetails(int.Parse(id));
                string ppbyhtml = ""; string chkbyhtml = ""; string appbyhtml = ""; string fappbyhtml = ""; 
                if (dtble.Rows.Count > 0)
                {
                    if (dtble.Rows.Count == 1)
                    {
                        ppbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Prepared By :</b><br/>";
                        ppbyhtml = ppbyhtml + dtble.Rows[0]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["designation"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["dte"].ToString().ToUpper() + @"</td></tr></table>";
                        imgprepared.ImageUrl = "../../Content/Images/img/" + dtble.Rows[0]["code"].ToString() + ".png";
                        imgprepared.Visible = true;
                    }
                    else if (dtble.Rows.Count == 2)
                    {
                        ppbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Prepared By :</b><br/>";
                        ppbyhtml = ppbyhtml + dtble.Rows[0]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["designation"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["dte"].ToString().ToUpper() + @"</td></tr></table>";
                        imgprepared.ImageUrl = "../../Content/Images/img/" + dtble.Rows[0]["code"].ToString() + ".png";

                        chkbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Checked By :</b><br/>";
                        chkbyhtml = chkbyhtml + dtble.Rows[1]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[1]["designation"].ToString() + "<br/>"
                            + dtble.Rows[1]["dte"].ToString() + @"</td></tr></table>";
                        imgchecked.ImageUrl = "../../Content/Images/img/" + dtble.Rows[1]["code"].ToString() + ".png";
                        imgprepared.Visible = true; imgchecked.Visible = true;
                    }
                    else if (dtble.Rows.Count == 3)
                    {
                        ppbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Prepared By :</b><br/>";
                        ppbyhtml = ppbyhtml + dtble.Rows[0]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["designation"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["dte"].ToString().ToUpper() + @"</td></tr></table>";
                        imgprepared.ImageUrl = "../../Content/Images/img/" + dtble.Rows[0]["code"].ToString() + ".png";

                        chkbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Checked By :</b><br/>";
                        chkbyhtml = chkbyhtml + dtble.Rows[1]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[1]["designation"].ToString() + "<br/>"
                            + dtble.Rows[1]["dte"].ToString() + @"</td></tr></table>";
                        imgchecked.ImageUrl = "../../Content/Images/img/" + dtble.Rows[1]["code"].ToString() + ".png";

                        appbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Approved By :</b><br/>";
                        appbyhtml = appbyhtml + dtble.Rows[2]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[2]["designation"].ToString() + "<br/>"
                            + dtble.Rows[2]["dte"].ToString() + @"</td></tr></table>";
                        imgapproved.ImageUrl = "../../Content/Images/img/" + dtble.Rows[2]["code"].ToString() + ".png";
                        imgprepared.Visible = true; imgchecked.Visible = true; imgapproved.Visible = true;
                    }
                    else if (dtble.Rows.Count == 4)
                    {
                        ppbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Prepared By :</b><br/>";
                        ppbyhtml = ppbyhtml + dtble.Rows[0]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["designation"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[0]["dte"].ToString().ToUpper() + @"</td></tr></table>";
                        imgprepared.ImageUrl = "../../Content/Images/img/" + dtble.Rows[0]["code"].ToString() + ".png";

                        chkbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Checked By :</b><br/>";
                        chkbyhtml = chkbyhtml + dtble.Rows[1]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[1]["designation"].ToString() + "<br/>"
                            + dtble.Rows[1]["dte"].ToString() + @"</td></tr></table>";
                        imgchecked.ImageUrl = "../../Content/Images/img/" + dtble.Rows[1]["code"].ToString() + ".png";

                        appbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Approved By :</b><br/>";
                        appbyhtml = appbyhtml + dtble.Rows[2]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[2]["designation"].ToString() + "<br/>"
                            + dtble.Rows[2]["dte"].ToString() + @"</td></tr></table>";
                        imgapproved.ImageUrl = "../../Content/Images/img/" + dtble.Rows[2]["code"].ToString() + ".png";

                        fappbyhtml = @" <table border='0'><tr><td style='text-align: left; font-size:10px; width:20%'><b>Last Approved By :</b><br/>";
                        fappbyhtml = fappbyhtml + dtble.Rows[3]["name"].ToString().ToUpper() + "<br/>"
                            + dtble.Rows[3]["designation"].ToString() + "<br/>"
                            + dtble.Rows[3]["dte"].ToString() + @"</td></tr></table>";
                        imgfinalapproved.ImageUrl = "../../Content/Images/img/" + dtble.Rows[3]["code"].ToString() + ".png";

                        imgprepared.Visible = true; imgchecked.Visible = true; imgapproved.Visible = true; imgfinalapproved.Visible = true;
                    }

                }
                
                lblpreparedby.Text = ppbyhtml;
                lblCheckedby.Text = chkbyhtml;
                lblApprovedby.Text = appbyhtml;
                lblFinalApproved.Text = fappbyhtml;

                Label1.Text = htmlString;

            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
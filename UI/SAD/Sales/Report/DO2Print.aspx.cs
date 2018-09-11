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
using SAD_BLL.Sales.Report;
using SAD_DAL.Sales.Report;
using System.Text;
using UI.ClassFiles;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Sales.Report
{
    public partial class DO2Print : BasePage
    {
        protected StringBuilder sb = new StringBuilder();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\DO2Print";
        string stop = "stopping SAD\\Sales\\Report\\DO2Print";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\DO2Print Challan Print", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    decimal count = 0;
                decimal? extAmount = 0;

                DateTime date = new DateTime();
                char separator = '-';
                char[] sep = { separator };
                string unitName = "", unitAddress = "", userName = ""
                    , challanNo = "", customerName = "", customerPhone = "", delevaryAddress = "", other = ""
                    , vehicle = "", extra = "", propitor = "", driver = "", driverPh = "", charge = "", logistic = "", incentive = "";
                bool isLogBasedOnUOM = false, isCharBasedOnUOM = false, isIncenBasedOnUOM = false;

                Challan ch = new Challan();
                ChallanTDS.SprSalesChallanInfoDataTable table = ch.GetData(Request.QueryString["id"], Session[SessionParams.USER_ID].ToString(), separator.ToString()
                    , ref date, ref unitName, ref unitAddress, ref userName
                    , ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref other
                    , ref vehicle, ref extra, ref extAmount, ref propitor
                    , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                    , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM);

                if (table.Rows.Count > 0)
                {
                    lblUnitName.Text = unitName.ToUpper();
                    lblUnitAddr.Text = unitAddress;
                    lblDate.Text = CommonClass.GetShortDateAtLocalDateFormat(date);
                    lblTime.Text = CommonClass.GetTimeAtLocalDateFormat(date);
                    lblCusName.Text = customerName;
                    lblCusAddr.Text = delevaryAddress;
                    lblCusPhone.Text = customerPhone;
                    lblCusBuyer.Text = "";
                    lblChlNo.Text = challanNo;
                    lblVehicle.Text = vehicle;
                    lblCusBuyer.Text = propitor;
                    lblDriver.Text = driver;
                    lblDriverPhone.Text = driverPh;
                    lblNarration.Text = other;

                    imgCode.ImageUrl = "../../../Accounts/Print/BarCodeHandler.ashx?info=" + challanNo;
                    imgLogo.ImageUrl = "../../../Accounts/Print/Images/" + Request.QueryString["unit"] + ".png";

                    sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");

                    //string[] val = productCatagory.Split(sep);

                    sb.Append("<tr style=\"font-size:10px;background-color:#E0E0E0\">");
                    sb.Append("<th  style=\"width:50px;text-align:center\">SL. NO</th>");
                    /*for (int i = 0; i < val.Length; i++)
                    {
                        sb.Append("<td>" + val[i].ToUpper() + "</td>");
                    }*/
                    sb.Append("<th  style=\"width:550px;text-align:center\">PRODUCT DESCRIPTION</th>");
                    if (table[0].ysnShowPckUOM)
                    {
                        sb.Append("<th  style=\"width:100px;text-align:center\">PCK. QUANTITY</th>");
                        sb.Append("<th  style=\"width:100px;text-align:center\">SELL. QUANTITY</th>");
                    }
                    else
                    {
                        sb.Append("<th  style=\"width:100px;text-align:center\">UOM</th>");
                        sb.Append("<th  style=\"width:100px;text-align:center\">QUANTITY</th>");
                    }

                    sb.Append("<th  style=\"width:100px;text-align:center\">RATE</th>");
                    sb.Append("<th  style=\"width:100px;text-align:center\">CHARGE</th>");
                    sb.Append("<th  style=\"width:100px;text-align:center\">LOGISTIC</th>");
                    sb.Append("<th  style=\"width:100px;text-align:center\">INCENTIVE</th>");
                    sb.Append("<th  style=\"width:100px;text-align:center\">TOTAL</th>");
                    sb.Append("</tr>");


                    decimal totPrc = 0, totChrg = 0, totVhlPrc = 0, totIncn = 0, grTotal = 0;
                    decimal prc = 0, chrg = 0, vhlPrc = 0, incn = 0, total = 0;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        sb.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                        /*val = table[i].strProductFullName.Split(sep);
                        for (int j = 0; j < val.Length; j++)
                        {
                            sb.Append("<td>" + val[j] + "</td>");
                        }*/

                        prc = table[i].numQuantity * table[i].monPrice;

                        if (isLogBasedOnUOM) { vhlPrc = table[i].numQuantity * table[i].monVehicleVarPrice; }
                        else { vhlPrc = 0; }

                        if (isCharBasedOnUOM) { chrg = table[i].numQuantity * table[i].monExtraPrice; }
                        else { chrg = 0; }

                        if (isIncenBasedOnUOM) { incn = table[i].numQuantity * table[i].monIncentive; }
                        else { incn = 0; }

                        total = prc + vhlPrc + chrg - incn;

                        sb.Append("<td>" + table[i].strProductFullName + "</td>");
                        if (table[i].ysnShowPckUOM)
                        {
                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numPckQuantity) + " " + table[i].strPackUomShow + "</td>");

                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + " " + table[i].strUOMShow + "</td>");

                        }
                        else
                        {
                            sb.Append("<td>" + table[i].strUOMShow + "</td>");
                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + "</td>");
                        }

                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(prc) + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(chrg) + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(vhlPrc) + "</td>");

                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(incn) + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(total) + "</td></tr>");

                        count += table[i].numQuantity;

                        totChrg += chrg;
                        totPrc += prc;
                        totVhlPrc += vhlPrc;
                        totIncn += incn;

                        grTotal += total;

                    }

                    if (!isLogBasedOnUOM) { vhlPrc = table[0].monVehicleVarPrice; grTotal += vhlPrc; }
                    if (!isCharBasedOnUOM) { chrg = table[0].monExtraPrice; grTotal += chrg; }
                    if (!isIncenBasedOnUOM) { incn = table[0].monIncentive; grTotal += incn; }


                    /*for (int i = table.Rows.Count; i < 20; i++)
                    {
                        sb.Append("<tr style=\"height:20px;\"><td></td><td></td><td></td><td></td></tr>");
                    }*/

                    sb.Append("<tr>");
                    sb.Append("<th colspan=\"3\" style=\"font-size:10px;\">TOTAL: </td>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(count) + "</th>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(totPrc) + "</th>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(totChrg) + "</th>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(totVhlPrc) + "</th>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(totIncn) + "</th>");
                    sb.Append("<th style=\"text-align:right;  font-size:10px;\">" + CommonClass.GetFormettingNumber(grTotal) + "</th>");
                    sb.Append("</tr>");
                    sb.Append("</table>");

                    sb.Append("</br><table style=\"width:100%;\"  class=\"TablePR\">");
                    sb.Append("<tr style=\"font-size:10px;\">");
                    sb.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">CHARGE</th>");
                    sb.Append("<td  style=\"width:50px;text-align:center\">" + charge + "</td>");
                    sb.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">LOGISTIC</th>");
                    sb.Append("<td  style=\"width:50px;text-align:center\">" + logistic + "</td>");
                    sb.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">INCENTIVE</th>");
                    sb.Append("<td  style=\"width:50px;text-align:center\">" + incentive + "</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td colspan=\"6\" style=\"font-size:10px;\">VAT CHALLAN NO: </td></tr>");
                    sb.Append("</table>");

                    Panel1.DataBind();
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
        }
    }
}

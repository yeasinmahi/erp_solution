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
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Order
{
    public partial class Challan : System.Web.UI.Page
    {

        protected StringBuilder mainD = new StringBuilder();
        protected StringBuilder mainG = new StringBuilder();

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\Challan";
        string stop = "stopping SAD\\Order\\Challan";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderByTrip ot = new OrderByTrip();
                OrderByTripTDS.TblSalesOrderTripDataTable table = ot.GetDataByTrip(Request.QueryString["id"]);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        GetChallan(table[i].intId.ToString(), i);
                    }

                    pnlChallan.DataBind();
                    pnlGate.DataBind();
                }
            }
        }


        private void GetChallan(string id, int rowCount)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\Challan Challan get", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                #region

                StringBuilder tempD = new StringBuilder();
            StringBuilder tempG = new StringBuilder();

            tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
            tempG.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");


            StringBuilder sb = new StringBuilder();
            StringBuilder sbP = new StringBuilder();
            StringBuilder sbGT = new StringBuilder();
            StringBuilder sbT = new StringBuilder();

            string promItem = "";
            decimal count = 0, promCount = 0, total = 0, gross = 0;
            decimal? extAmount = 0;
            DateTime date = new DateTime();
            char separator = '-';
            char[] sep = { separator };
            string unitName = "", unitAddress = "", userName = ""
                , challanNo = "", doNo = "", customerName = "", customerPhone = ""
                , distributionPoint = "", contactAt = "", contactPhone = ""
                    , delevaryAddress = "", other = ""
                , vehicle = "", extra = "", driver = "", driverPh = "", charge = "", logistic = "", incentive = "";
            bool isLogBasedOnUOM = false, isCharBasedOnUOM = false, isIncenBasedOnUOM = false;

            SAD_BLL.Sales.Report.Challan ch = new SAD_BLL.Sales.Report.Challan();
            ChallanTDS.SprTripChallanInfoDataTable table = ch.GetTripData(id, Session["sesUserID"].ToString(), separator.ToString()
                , ref date, ref unitName, ref unitAddress, ref userName
                , ref challanNo, ref doNo, ref customerName, ref customerPhone, ref distributionPoint
            , ref contactAt, ref contactPhone, ref delevaryAddress, ref other
                , ref vehicle, ref extra, ref extAmount
                , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM);

            if (table.Rows.Count > 0)
            {
                tempD.Append(Banner("DELIVERY CHALLAN", challanNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh).ToString());

                tempG.Append(Banner("GATE PASS", challanNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh).ToString());


                tempD.Append("<tr><td colspan=\"5\">");
                tempG.Append("<tr><td colspan=\"5\">");

                sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                sbP.Append("<table style=\"width:100%;\"  class=\"TablePR\">");

                sb.Append(@"<tr style=""font-size:10px;background-color:#E0E0E0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                                PRODUCT DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                        </tr>");

                sbP.Append(@"</br><tr style=""font-size:10px;background-color:#FFFFFF"">
                                <th colspan=""5"" style=""text-align:left"">
                                P R O M O T I O N S</th>
                            </tr>
                            <tr style=""font-size:10px;background-color:#E0E0E0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                                PRODUCT DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                        </tr>");

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sb.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                    sb.Append("<td>" + table[i].strProductFullName + "</td>");
                    sb.Append("<td>" + table[i].strUOMShow + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + "</td>");
                    sb.Append("</tr>");

                    promItem = table[i].IsstrPromItemNameNull() ? "" : table[i].strPromItemName;


                    if (promItem != "")
                    {
                        sbP.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                        sbP.Append("<td>" + promItem + "</td>");
                        sbP.Append("<td>" + (table[i].IsstrPromUomNull() ? "" : table[i].strPromUom) + "</td>");
                        sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromotionNull() ? "" : (table[i].numPromotion <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromotion))) + "</td>");
                        sbP.Append("</tr>");
                        promCount += table[i].numPromotion;
                    }

                    count += table[i].numQuantity;

                    promItem = "";
                }



                sb.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + count + "</th></tr>");
                sb.Append("</table>");

                sbP.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + promCount + "</th></tr>");
                sbP.Append("</table>");

                sbGT.Append("</br><table style=\"width:100%;\"  class=\"TablePR\">");
                sbGT.Append("<tr style=\"background-color:#E0E0E0\"><th>GRAND TOTAL</th><th style=\"width:100px; text-align:right;\">" + (count + promCount) + "</th></tr>");
                sbGT.Append("</table>");

                if (promCount <= 0)
                {
                    sbP = new StringBuilder();
                    sbGT = new StringBuilder();
                }

                sbT.Append("</br><table style=\"width:100%;\"  class=\"TablePR\">");
                sbT.Append("<tr style=\"font-size:10px;\">");
                sbT.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">CHARGE</th>");
                sbT.Append("<td  style=\"width:50px;text-align:center\">" + charge + "</td>");
                sbT.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">LOGISTIC</th>");
                sbT.Append("<td  style=\"width:50px;text-align:center\">" + logistic + "</td>");
                sbT.Append("<th  style=\"width:50px;text-align:left;background-color:#E0E0E0\">INCENTIVE</th>");
                sbT.Append("<td  style=\"width:50px;text-align:center\">" + incentive + "</td>");
                sbT.Append("</tr>");
                sbT.Append("<tr><td colspan=\"6\" style=\"font-size:10px;\">VAT CHALLAN NO: </td></tr>");
                sbT.Append("</table>");
            }


            tempD.Append(sb.ToString());
            tempD.Append(sbP.ToString());
            tempD.Append(sbGT.ToString());
            tempD.Append(sbT.ToString());
            tempD.Append("</td></tr></table>");
            tempD.Append(Footer().ToString());

            tempG.Append(sb.ToString());
            tempG.Append(sbP.ToString());
            tempG.Append(sbGT.ToString());
            tempG.Append(sbT.ToString());
            tempG.Append("</td></tr></table>");
            tempG.Append(Footer().ToString());

            if (rowCount > 0)
            {
                mainD.Append("<div style=\"page-break-before:always;\"></div>");
                mainG.Append("<div style=\"page-break-before:always;\"></div>");
            }

            mainD.Append(tempD.ToString());
            mainG.Append(tempG.ToString());
                #endregion
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

        private StringBuilder Banner(string heading, string challanNo, string unitName, string unitAddr
            , string date, string customer, string time
            , string address, string vehicle, string contactPerson
            , string driver, string phone, string driverPhone)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(@"<tr>
                <td rowspan=""4"" align=""left"">
                <img alt=""Logo"" src=../../Accounts/Print/Images/" + Request.QueryString["unit"] + @".png />
                </td>
                <td colspan=""3""  style=""text-align:center; font-size:17px; font-weight:bold;"">
                    " + heading + @"</td>
                <td rowspan=""4"" align=""right"">                
                    <img alt=""Challan No"" height=""57px"" width=""150px"" src=../../Accounts/Print/BarCodeHandler.ashx?info=" + challanNo + @" />               
                </td>
            </tr>
            <tr>
                <td colspan=""3"" style=""text-align:center; font-size:13px;"">
                    " + unitName + @"
                </td>
            </tr>           
            <tr>
                <td colspan=""3"" style=""text-align:center; font-size:11px;"">
                    " + unitAddr + @"
                </td>
            </tr>
            <tr style=""height:30px;"">
                <td colspan=""5"">
                    &nbsp;</td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td style=""width:120px; font-size:12px; font-weight:bold;"">
                                                                                Challan No</td>
                <td colspan=""2"" style=""width:300px; font-size:12px; font-weight:bold;"">
                     " + challanNo + @"
                </td>               
                <td style=""width:100px;"">
                                        Date</td>
                <td style=""width:180px;"">
                     " + date + @"
                </td>
            </tr>
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td>
                                        Customer</td>
                <td colspan=""2"">
                    " + customer + @"
                </td>
                
                <td>
                                        Delivery Time</td>
                <td>
                    " + time + @"</td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td>
                                        Address</td>
                <td colspan=""2"">
                    " + address + @"
                </td>
                
                <td>
                                        Vehicle No</td>
                <td>
                    " + vehicle + @"
                </td>
            </tr>
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td>
                                        Contact Person</td>
                <td colspan=""2"">
                    " + contactPerson + @"
                </td>                
                <td>
                                        Driver</td>
                <td>
                    " + driver + @"</td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td>
                                        Contact No</td>
                <td colspan=""2"">
                    " + phone + @"
                </td>
                <td>
                                        Contact No</td>
                <td>
                    " + driverPhone + @"</td>
            </tr>
            <tr style=""height:30px;"">
                <td colspan=""5"">
                    &nbsp;</td>
            </tr>");
            return temp;
        }

        private StringBuilder Footer()
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">
            <tr>
                <td align=""left"" style="" padding-top:50px; font-size:11px; width:12%"">
                    Manager</td>
                <td align=""center"" style="" padding-top:50px; font-size:11px; width:12%"">
                    Officer</td>                
                <td align=""center"" style="" padding-top:50px; font-size:11px; width:12%"">
                    Supervisor</td>                
                <td align=""center"" style=""padding-top:50px; font-size:11px; width:22%"">
                    Driver's Signature</td>                
                <td align=""right""style="" padding-top:50px; font-size:11px; width:42%"">
                    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>
            </tr>
        </table>");

            return temp;
        }
    }
}
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
using LOGIS_BLL.Trip;
using UI.ClassFiles;
namespace UI.SAD.Order
{
    public partial class ChallanOneGP : BasePage
    {

        protected StringBuilder mainD = new StringBuilder();
        protected StringBuilder mainG = new StringBuilder();

        ChallanTDS.TblGatePassDataTable tblGP = new ChallanTDS.TblGatePassDataTable();
        DataRow dr;

        string userName = "", challanList = "", vehicle = "", driver = "", driverPh = ""
            , unitName = "", unitAddress = "";
        char separator = '-';
        DateTime date = new DateTime();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tripId = Request.QueryString["id"];
                OrderByTrip ot = new OrderByTrip();
                OrderByTripTDS.TblSalesOrderTripDataTable table = ot.GetDataByTrip(tripId);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        GetChallan(table[i].intId.ToString(), i);
                    }


                    mainG.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                    mainG.Append(BannerGate("LOADING SLIP", new Trip().GetTripCodeById(tripId), challanList, unitName, unitAddress
                        , CommonClass.GetShortDateAtLocalDateFormat(date), CommonClass.GetTimeAtLocalDateFormat(date)
                        , vehicle, driver, driverPh).ToString());

                    mainG.Append("<tr><td colspan=\"5\">");
                    mainG.Append("<table style=\"width:100%;\"  class=\"TablePR\">");

                    mainG.Append(@"<tr style=""font-size:10px;background-color:#E0E0E0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                                PRODUCT DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                            <th style=""width:100px;text-align:center"">
                                WEIGHT</th>
                        </tr>");



                    var rows = from tmp in tblGP
                               orderby tmp.strProductName
                               group tmp by new
                                {
                                    tmp.strProductName,
                                    tmp.strUOM
                                } into g
                               select new
                               {
                                   strProductName = g.Key.strProductName,
                                   strUOM = g.Key.strUOM,
                                   numQnt = g.Sum(col => col.numQnt),
                                   numWeight = g.Sum(col => col.numWeight)
                               };

                    decimal total = 0, totalWeight = 0;
                    int count = 1;
                    foreach (var row in rows)
                    {
                        mainG.Append("<tr style=\" font-size:10px;\"><td>" + count + @"</td>");
                        mainG.Append("<td>" + row.strProductName + "</td>");
                        mainG.Append("<td>" + row.strUOM + "</td>");
                        mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.numQnt) + "</td>");
                        mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.numWeight) + "</td>");
                        mainG.Append("</tr>");

                        count++;
                        total += row.numQnt;
                        totalWeight += row.numWeight;
                    }

                    mainG.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + total + "</th><th style=\"text-align:right;\">" + totalWeight + "</th></tr>");
                    mainG.Append("</table>");
                    mainG.Append("</td></tr></table>");
                    mainG.Append(Footer(false).ToString());

                    tblGP = null;

                    pnlChallan.DataBind();
                    pnlGate.DataBind();
                }
                else
                {

                    Trip ch = new Trip();
                    ch.GetGatePass(tripId, Session[SessionParams.USER_ID].ToString(), separator.ToString()
                , ref date, ref unitName, ref unitAddress, ref userName, ref vehicle, ref driver, ref driverPh);

                    mainG.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                    mainG.Append(BannerGate("LOADING SLIP", new Trip().GetTripCodeById(tripId), "No Challan", unitName, unitAddress
                        , CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now), CommonClass.GetTimeAtLocalDateFormat(DateTime.Now)
                        , vehicle, driver, driverPh).ToString());

                    mainG.Append("<tr><td colspan=\"5\">");
                    mainG.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    mainG.Append(@"<tr style=""font-size:10px;background-color:#E0E0E0"">
                            <td style=""width:20px;text-align:center"">
                                THIS IS AN EMPTY VECHICLE</td></tr></table>");
                    mainG.Append(Footer(false).ToString());
                    pnlGate.DataBind();
                }


            }

        }


        private void GetChallan(string id, int rowCount)
        {

            StringBuilder tempD = new StringBuilder();

            tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");


            StringBuilder sb = new StringBuilder();
            StringBuilder sbP = new StringBuilder();
            StringBuilder sbGT = new StringBuilder();
            StringBuilder sbT = new StringBuilder();

            //string promItem = "";
            decimal count = 0, promCount = 0;
            decimal wgt = 0, promWgt = 0;
            decimal? extAmount = 0;


            string challanNo = "", doNo = "", customerName = "", customerPhone = ""
                , distributionPoint = "", contactAt = "", contactPhone = ""
                    , delevaryAddress = "", other = ""
                , extra = "", charge = "", logistic = "", incentive = "";
            bool isLogBasedOnUOM = false, isCharBasedOnUOM = false, isIncenBasedOnUOM = false;

            SAD_BLL.Sales.Report.Challan ch = new SAD_BLL.Sales.Report.Challan();
            ChallanTDS.SprTripChallanInfoDataTable table = ch.GetTripData(id, Session[SessionParams.USER_ID].ToString(), separator.ToString()
                , ref date, ref unitName, ref unitAddress, ref userName
                , ref challanNo, ref doNo, ref customerName, ref customerPhone, ref distributionPoint
                , ref contactAt, ref contactPhone, ref delevaryAddress, ref other
                , ref vehicle, ref extra, ref extAmount
                , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM);

            if (table.Rows.Count > 0)
            {

                tempD.Append(Banner("DELIVERY CHALLAN", challanNo, doNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh).ToString());

                tempD.Append("<tr><td colspan=\"5\">");

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
                            <th style=""width:100px;text-align:center"">
                                WEIGHT</th>
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
                            <th style=""width:100px;text-align:center"">
                                WEIGHT</th>
                        </tr>");



                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sb.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                    sb.Append("<td>" + table[i].strProductFullName + "</td>");
                    sb.Append("<td>" + table[i].strUOMShow + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numWeight) + "</td>");
                    sb.Append("</tr>");

                    dr = tblGP.NewTblGatePassRow();
                    dr["strProductName"] = table[i].strProductFullName;
                    dr["strUOM"] = table[i].strUOMShow;
                    dr["numQnt"] = table[i].numQuantity;
                    dr["numWeight"] = table[i].numWeight;
                    dr["numVolume"] = 0;
                    tblGP.Rows.Add(dr);

                    //promItem = table[i].IsstrPromItemNameNull() ? "" : table[i].strPromItemName;


                    if ((table[i].IsnumPromotionNull() ? 0 : table[i].numPromotion) > 0)
                    {
                        sbP.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                        sbP.Append("<td>" + (table[i].IsstrPromItemNameNull() ? "" : table[i].strPromItemName) + "</td>");
                        sbP.Append("<td>" + (table[i].IsstrPromUomNull() ? "" : table[i].strPromUom) + "</td>");
                        sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromotionNull() ? "" : (table[i].numPromotion <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromotion))) + "</td>");
                        sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromWeightNull() ? "" : (table[i].numPromWeight <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromWeight))) + "</td>");
                        sbP.Append("</tr>");
                        promCount += table[i].numPromotion;
                        promWgt += table[i].numPromWeight;

                        dr = tblGP.NewTblGatePassRow();
                        dr["strProductName"] = table[i].strPromItemName;
                        dr["strUOM"] = table[i].strPromUom;
                        dr["numQnt"] = table[i].numPromotion;
                        dr["numWeight"] = table[i].numPromWeight;
                        dr["numVolume"] = 0;
                        tblGP.Rows.Add(dr);
                    }

                    count += table[i].numQuantity;
                    wgt += table[i].numWeight;

                    // promItem = "";
                }



                sb.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + count + "</th><th style=\"text-align:right;\">" + wgt + "</th></tr>");
                sb.Append("</table>");

                sbP.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + promCount + "</th><th style=\"text-align:right;\">" + promWgt + "</th></tr>");
                sbP.Append("</table>");

                sbGT.Append("</br><table style=\"width:100%;\"  class=\"TablePR\">");
                sbGT.Append("<tr style=\"background-color:#E0E0E0\"><th>GRAND TOTAL</th><th style=\"width:100px; text-align:right;\">" + (count + promCount) + "</th><th style=\"width:100px; text-align:right;\">" + (wgt + promWgt) + "</th></tr>");
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
            tempD.Append(Footer(true).ToString());

            if (rowCount > 0)
            {
                mainD.Append("<div style=\"page-break-before:always;\"></div>");
                challanList += " <b>|</b> " + challanNo;
            }
            else
            {
                challanList += challanNo;
            }

            mainD.Append(tempD.ToString());
        }

        private StringBuilder Banner(string heading, string challanNo, string doNo, string unitName, string unitAddr
            , string date, string customer, string time
            , string address, string vehicle, string contactPerson
            , string driver, string phone, string driverPhone)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(@"<tr>
                <td rowspan=""4"" align=""left"">
                <img alt=""Logo"" src=../../Content/images/img/" + Request.QueryString["unit"] + @".png />
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
            <tr style=""height:10px;"">
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
                                        Delivary Order</td>
                <td style=""width:180px;"">
                     " + doNo + @"
                </td>
            </tr>
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td>
                                        Customer</td>
                <td colspan=""2"">
                    " + customer + @"
                </td>
                <td style=""width:100px;"">
                                        Delivery At</td>
                <td style=""width:180px;"">
                     " + date + " " + time + @"
                </td>
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
            <tr style=""height:10px;"">
                <td colspan=""5"">
                    &nbsp;</td>
            </tr>");
            return temp;
        }

        private StringBuilder BannerGate(string heading, string tripNo, string challanNo, string unitName, string unitAddr
            , string date, string time
            , string vehicle, string driver, string driverPhone)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append(@"<tr>
                <td rowspan=""4"" align=""left"">
                <img alt=""Logo"" src=../../Content/images/img/" + Request.QueryString["unit"] + @".png />
                </td>
                <td colspan=""3""  style=""text-align:center; font-size:17px; font-weight:bold;"">
                    " + heading + @"</td>
                <td rowspan=""4"" align=""right"">                
                    <img alt=""Challan No"" height=""57px"" width=""150px"" src=../../Accounts/Print/BarCodeHandler.ashx?info=" + tripNo + @" />               
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
            <tr style=""height:10px;"">
                <td colspan=""5""></td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td style=""width:120px; font-size:12px; font-weight:bold;"">Trip No</td>
                <td colspan=""2"" style=""width:300px; font-size:12px; font-weight:bold;"">
                     " + tripNo + @"
                </td>
                <td>Slip Print At</td>
                <td>" + date + " " + time + @"</td>
            </tr>
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td style=""width:120px; font-size:10px;"">Challan No:  </td>
                <td colspan=""4"">
                    " + challanNo + @"</td>
            </tr>            
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td>
                                        Vehicle No</td>
                <td colspan=""4"">
                     " + vehicle + @"
                </td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td>Driver</td>
                <td colspan=""2"">
                    " + driver + @"
                </td>
                <td>Contact No</td>
                <td>" + driverPhone + @"</td>
            </tr>            
            <tr style=""height:10px;"">
                <td colspan=""5"">
                    &nbsp;</td>
            </tr>");
            return temp;
        }

        private StringBuilder Footer(bool isChallan)
        {
            StringBuilder temp = new StringBuilder();

            /*
             <td align=""center"" style="" padding-top:50px; font-size:11px; width:12%"">
                        Officer</td>                
                    <td align=""center"" style="" padding-top:50px; font-size:11px; width:12%"">
                        Supervisor</td>         
         
             */

            temp.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">
            <tr>
                <td align=""left"" style="" padding-top:50px; font-size:11px; width:30%"">
                    Officer</td>");

            if (isChallan)
            {
                temp.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
                    Driver's Signature</td>                
                <td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
                    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>");
            }

            temp.Append(@"</tr>
        </table>");

            return temp;
        }
    }
}
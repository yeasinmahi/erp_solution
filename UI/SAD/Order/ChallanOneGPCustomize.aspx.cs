﻿using GLOBAL_BLL;
using LOGIS_BLL.Trip;
using QRCoder;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using SAD_DAL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using static SAD_DAL.Sales.OrderByTripTDS;

namespace UI.SAD.Order
{
    public partial class ChallanOneGPCustomize : System.Web.UI.Page
    {
        protected StringBuilder mainD = new StringBuilder();
        protected StringBuilder mainG = new StringBuilder();

        ChallanTDS.TblGatePassDataTable tblGP = new ChallanTDS.TblGatePassDataTable();
        DataRow dr;

        string userName = "", challanList = "", vehicle = "", driver = "", driverPh = ""
            , unitName = "", unitAddress = "";
        char separator = '-';
        DateTime date = new DateTime();
        SalesView bll = new SalesView();
        SalesView bllsv = new SalesView();
        OrderByTrip ot = new OrderByTrip();
        DataTable dt = new DataTable(); string tripId;
        DataTable chdt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tripId = Request.QueryString["id"];

                SalesView bll = new SalesView();

                OrderByTripTDS.SprCustomerTripIdvsChallanDetaillsDataTable table = ot.GetDataByTripForPendingQnt(tripId);


                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        GetChallan(table[i].intId.ToString(), i, table[i].intcustomerid, table[i].ysnmaxchallan);
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
                                RATE</th>
                            <th style=""width:100px;text-align:center"">
                                PRICE</th>
                        </tr>");

                    var rows = from tmp in tblGP
                               orderby tmp.strProductName
                               group tmp by new
                               {
                                   tmp.strProductName,
                                   tmp.strUOM,
                                   tmp.ProductRate
                               } into g
                               select new
                               {
                                   strProductName = g.Key.strProductName,
                                   strUOM = g.Key.strUOM,
                                   numQnt = g.Sum(col => col.numQnt),
                                   ProductRate = g.Key.ProductRate,
                                   monPrice = g.Sum(col => Convert.ToDecimal(col.monPrice)),

                               };

                    decimal total = 0;
                    decimal totalWeight = 0;
                    int count = 1;
                    foreach (var row in rows)
                    {
                        mainG.Append("<tr style=\" font-size:10px;\"><td>" + count + @"</td>");
                        mainG.Append("<td>" + row.strProductName + "</td>");
                        mainG.Append("<td>" + row.strUOM + "</td>");
                        mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.numQnt) + "</td>");
                        mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.monPrice) + "</td>");
                        mainG.Append("<td>" + row.ProductRate + "</td>");

                        mainG.Append("</tr>");

                        count++;
                        total += row.numQnt;
                        totalWeight += row.monPrice;

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


        private void GetChallan(string id, int rowCount, int customerId, Boolean maxChallan)
        {

            SprCustomerTripIdvsChallanDetaillsDataTable tblcust = ot.GetDataByTripForPendingQnt(tripId);
            StringBuilder tempD = new StringBuilder();
            tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
            StringBuilder sb = new StringBuilder();
            StringBuilder sbP = new StringBuilder();
            StringBuilder sbGT = new StringBuilder();
            StringBuilder sbT = new StringBuilder();

            StringBuilder sbPending = new StringBuilder();
            StringBuilder sbtotaldelvparybase = new StringBuilder();



            //string promItem = "";
            decimal count = 0, promCount = 0;
            decimal wgt = 0, promWgt = 0;
            decimal? extAmount = 0;


            string challanNo = "", doNo = "", customerName = "", customerPhone = ""
                , distributionPoint = "", contactAt = "", contactPhone = ""
                    , delevaryAddress = "", other = ""
                , extra = "", charge = "", logistic = "", incentive = "";
            bool isLogBasedOnUOM = false, isCharBasedOnUOM = false, isIncenBasedOnUOM = false;
            string dodate;

            SAD_BLL.Sales.Report.Challan ch = new SAD_BLL.Sales.Report.Challan();
            ChallanTDS.SprTripChallanInfoCustomizeDataTable table = ch.GetTripDataCustomize(id, Session[SessionParams.USER_ID].ToString(), separator.ToString()
                , ref date, ref unitName, ref unitAddress, ref userName
                , ref challanNo, ref doNo, ref customerName, ref customerPhone, ref distributionPoint
                , ref contactAt, ref contactPhone, ref delevaryAddress, ref other
                , ref vehicle, ref extra, ref extAmount
                , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM);

            if (table.Rows.Count > 0)
            {

                //tempD.Append(Banner("DELIVERY CHALLAN", challanNo, doNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                //    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                //    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh).ToString());

                //tempD.Append("<tr><td colspan=\"5\">");

                //sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                //sbP.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                if (maxChallan)
                    tempD.Append(Banner("DELIVERY CHALLAN", challanNo, doNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh).ToString());

                {
                    sbPending.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    sbtotaldelvparybase.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    
                }


                if (maxChallan)
                {
                    sbPending.Append(@"<tr style=""font-size:10px;background-color:#A0A0A0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                               PENDING PRODUCT </th>
                            <th style=""width:67px;text-align:center"">
                              PENDING  D.O</th>
                             <th style=""width:67px;text-align:center"">
                               D. O Creation DATE</th>
                             <th style=""width:67px;text-align:center"">
                                                             RATE.</th>
                            <th style=""width:67px;text-align:center"">
                                PENDING QNT.</th>
                            
                            <th style=""width:100px;text-align:center"">
                              PENDING  AMOUNT</th>
                        </tr>");


                    sbtotaldelvparybase.Append(@"<tr style=""font-size:10px;background-color:#A0A0A0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                               DELIVERY PRODUCT </th>
                            <th style=""width:67px;text-align:center"">
                              DELIVERY  D.O</th>
                             <th style=""width:67px;text-align:center"">
                               D. O Creation DATE</th>
                             <th style=""width:67px;text-align:center"">
                                                             RATE.</th>
                            <th style=""width:67px;text-align:center"">
                                DELIVERY QNT.</th>
                            
                            <th style=""width:100px;text-align:center"">
                              DELIVERY  AMOUNT</th>
                        </tr>");


                //    temp.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
                //    Driver's Signature</td>                
                //<td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
                //    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>");

                }


                

                #region ********************************************** 
                if (maxChallan)
                {

                    dt = bllsv.getcustomerbasependingqnt(int.Parse(tripId), customerId);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string Product = dt.Rows[j]["strProductName"].ToString();
                        string Do = dt.Rows[j]["strCode"].ToString();
                        string PendingDate = dt.Rows[j]["dteDate"].ToString();
                        string PendingQty = dt.Rows[j]["numRestPieces"].ToString();
                        string pendingrate = dt.Rows[j]["rate"].ToString();
                        string Price = dt.Rows[j]["pendingqntpricevalue"].ToString();
                        sbPending.Append("<tr style=\" font-size:10px;\"><td>" + dt.Rows[j]["insl"] + @"</td>");
                        sbPending.Append("<td>" + Product + "</td>");
                        sbPending.Append("<td>" + Do + "</td>");
                        sbPending.Append("<td style=\"text-align:right\">" + PendingDate + "</td>");
                        sbPending.Append("<td style=\"text-align:right\">" + pendingrate + "</td>");
                        sbPending.Append("<td style=\"text-align:right\">" + PendingQty + "</td>");

                        sbPending.Append("<td style=\"text-align:right\">" + Price + "</td>");
                        sbPending.Append("</tr>");


                        //sbtotaldelvparybase.Append("<tr style=\" font-size:10px;\"><td>" + dt.Rows[j]["insl"] + @"</td>");
                        //sbtotaldelvparybase.Append("<td>" + Product + "</td>");
                        //sbtotaldelvparybase.Append("<td>" + Do + "</td>");
                        //sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + PendingDate + "</td>");
                        //sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + pendingrate + "</td>");
                        //sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + PendingQty + "</td>");

                        //sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + Price + "</td>");
                        //sbtotaldelvparybase.Append("</tr>");



                    }

                    chdt = bllsv.getcustomerbasetotalchallanqnt(int.Parse(tripId), customerId);
                    for (int K = 0; K < chdt.Rows.Count; K++)
                    {
                        string chProduct = chdt.Rows[K]["strProductName"].ToString();
                        string chDo = chdt.Rows[K]["strdonumber"].ToString();
                        string chDate = chdt.Rows[K]["dtedodate"].ToString();
                        string chQty = chdt.Rows[K]["decchallanqnt"].ToString();
                        string chrate = chdt.Rows[K]["rate"].ToString();
                        string chPrice = chdt.Rows[K]["monAmount"].ToString();
                        sbtotaldelvparybase.Append("<tr style=\" font-size:10px;\"><td>" + chdt.Rows[K]["intsl"] + @"</td>");
                        sbtotaldelvparybase.Append("<td>" + chProduct + "</td>");
                        sbtotaldelvparybase.Append("<td>" + chDo + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chDate + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chrate + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chQty + "</td>");

                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chPrice + "</td>");
                        sbtotaldelvparybase.Append("</tr>");





                    }


                    //tempD.Append("</td></tr></table>");
                    //tempD.Append(Footer(true).ToString());
                }




                #endregion*****************************************************
                //sbPending.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + 22 + "</th><th style=\"text-align:right;\">" + 232 + "</th></tr>");
                sbPending.Append("</table>");
                sbtotaldelvparybase.Append("</table>");

                if (maxChallan)
                {

                    tempD.Append("</td></tr></table>");
                    tempD.Append(Footer(true).ToString());
                }

            }


            tempD.Append(sb.ToString());
            tempD.Append(sbPending.ToString());
            tempD.Append(sbtotaldelvparybase.ToString());
            tempD.Append(sbP.ToString());
            tempD.Append(sbGT.ToString());
            tempD.Append(sbT.ToString());
            //tempD.Append("</td></tr></table>");
            //tempD.Append(Footer(true).ToString());

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

        private void geteachcustpending(string custid, int rowcount)
        {
           
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
                                        </td>
                <td style=""width:180px;"">
                    
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


            temp.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">
            <tr>
                <td align=""left"" style="" padding-top:50px; font-size:11px; width:30%"">
                    Officer</td>");
            temp.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
                    Driver's Signature</td>                
                <td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
                    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>");

            //if (isChallan)
            //{

            //    //temp.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
            //    //    Driver's Signature</td>                
            //    //<td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
            //    //    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>");

            //    //sbtotaldelvparybase.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
            //    //    Driver's Signature</td>                
            //    //<td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
            //    //    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>");

            //}

            temp.Append(@"</tr>
        </table>");

            return temp;
        }
    }
}
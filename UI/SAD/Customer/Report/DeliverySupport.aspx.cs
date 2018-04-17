using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Customer.Report;
using SAD_DAL.Customer.Report;
using System.Text;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using SAD_BLL.Sales.Report;
using SAD_DAL.Sales.Report;
using UI.ClassFiles;

namespace UI.SAD.Customer.Report
{
    public partial class DeliverySupport : BasePage
    {
        protected StringBuilder tempD = new StringBuilder();
        protected StringBuilder mainD = new StringBuilder();

        SAD_BLL.Customer.Report.DeliverySupport ds = new SAD_BLL.Customer.Report.DeliverySupport();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";
                pnlMarque.DataBind();
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            long? intID = null;
            DateTime? dteDate = null; DateTime? dteDateReq = null;
            string strInsertedBy = ""; DateTime? dteInsertionTime = null;
            string strModifieddBy = ""; DateTime? dteModificationTime = null;
            bool? ysnSOCompleted = null; string strSOCompletedBy = "";
            DateTime? dteSOComplitionTime = null; bool? ysnDOCompleted = null;
            string strDOCompletedBy = ""; DateTime? dteDOComplitionTime = null;
            string strSaleOffice = ""; string strShipPoint = "";
            string strCustomer = ""; string strPhone = "";
            string strDisPointName = ""; string strContactAt = "";
            string strContactPhone = ""; string strAddress = "";
            string strOther = ""; decimal? monTotalAmount = null;
            decimal? numReqQnty = null; decimal? numApprQnty = null;
            string strExtra = ""; decimal? monExtAmount = null;
            string strCharge = ""; decimal? monChargeAmount = null;
            string strIncentive = ""; decimal? monIncentiveAmount = null;
            string strCurrency = ""; string strLogistic = "", status = "";

            DeliverySupportTDS.SprCustomerServiceDODataTable tableDO = ds.InfoByDO(txtDO.Text.Trim(),
                        ddlUnit.SelectedValue,
                        Session[SessionParams.USER_ID].ToString(),
                       ref intID,
                       ref dteDate, ref dteDateReq,
                       ref strInsertedBy, ref dteInsertionTime,
                       ref strModifieddBy, ref dteModificationTime,
                       ref ysnSOCompleted, ref strSOCompletedBy,
                       ref dteSOComplitionTime, ref ysnDOCompleted,
                       ref strDOCompletedBy, ref dteDOComplitionTime,
                       ref strSaleOffice, ref strShipPoint,
                       ref strCustomer, ref strPhone,
                       ref strDisPointName, ref strContactAt,
                       ref strContactPhone, ref strAddress,
                       ref strOther, ref monTotalAmount,
                       ref numReqQnty, ref numApprQnty,
                       ref strExtra, ref monExtAmount,
                       ref strCharge, ref monChargeAmount,
                       ref strIncentive, ref monIncentiveAmount,
                       ref strCurrency, ref strLogistic, ref status);


            if (tableDO.Rows.Count > 0)
            {
                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");

                tempD.Append(@"<tr><td colspan=""4"" align=""center""> <b style=""color:#990000; font-size:18px;"">" + txtDO.Text.Trim() + @"</b>  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td style=""width:110px""> <b>Date</b>  </td>
                            <td style=""width:240px""> " + CommonClass.GetShortDateAtLocalDateFormat(dteDate) + @"  </td>
                            <td style=""width:110px""> <b>Req. Del. Date</b>  </td>
                            <td style=""width:240px""> " + CommonClass.GetDateAtLocalDateFormat(dteDateReq.Value) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Customer</b>  </td><td> " + strCustomer + @"  </td><td> <b>Dis. Point</b>  </td><td> " + strDisPointName + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Phone</b>  </td><td> " + strPhone + @"  </td><td> <b>Contact At</b>  </td><td> " + strContactAt + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Other Info</b>  </td><td> " + strOther + @"  </td><td> <b>Contact Phone</b>  </td><td> " + strContactPhone + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Address</b>  </td><td colspan=""3""> " + strAddress + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Status</b>  </td><td colspan=""3""> " + status + @"  </td></tr>");
                tempD.Append(@"<tr><td colspan=""4"">
                    <a class=""link"" href=""#"" id='dsdo' onclick=""Show('do')"">See More</a><a class=""link"" href=""#"" style=""display:none"" id='dhdo' onclick=""Hide('do')"">Hide</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a class=""link"" href=""#"" id='dsPdo' onclick=""Show('Pdo')"">See Product</a><a class=""link"" href=""#"" style=""display:none"" id='dhPdo' onclick=""Hide('Pdo')"">Hide Product</a>
                    </td></tr></table>");

                tempD.Append(@"<div id='do' style=""display:none""><table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td style=""width:110px""> <b>Req. Qnt</b>  </td>
                            <td style=""width:240px""> " + numReqQnty + @"  </td>
                            <td style=""width:110px""> <b>Appr. Qnt</b>  </td>
                            <td style=""width:240px""> " + numApprQnty + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Currency</b>  </td><td> " + strCurrency + @"  </td><td> <b>Amount</b>  </td><td> " + CommonClass.GetFormettingNumber(monTotalAmount) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Sales Off</b>  </td><td> " + strSaleOffice + @"  </td><td> <b>Ship Point</b>  </td><td> " + strShipPoint + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Ex. Charge</b>  </td><td> " + strExtra + @"  </td><td> <b>Amount</b>  </td><td> " + CommonClass.GetFormettingNumber(monExtAmount) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Charge</b>  </td><td> " + strCharge + @"  </td><td> <b>Amount</b>  </td><td> " + CommonClass.GetFormettingNumber(monChargeAmount) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Incentive</b>  </td><td> " + strIncentive + @"  </td><td> <b>Amount</b>  </td><td> " + CommonClass.GetFormettingNumber(monIncentiveAmount) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Logistic</b>  </td><td colspan=""3""> " + strLogistic + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Inserted By</b>  </td><td> " + strInsertedBy + @"  </td><td> <b>At</b>  </td><td> " + (dteModificationTime == null ? "" : CommonClass.GetDateAtLocalDateFormat(dteInsertionTime.Value)) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Modified By</b>  </td><td> " + strModifieddBy + @"  </td><td> <b>At</b>  </td><td> " + (dteModificationTime == null ? "" : CommonClass.GetDateAtLocalDateFormat(dteModificationTime.Value)) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Quat. By</b>  </td><td> " + strSOCompletedBy + @"  </td><td> <b>At</b>  </td><td> " + (dteSOComplitionTime == null ? "" : CommonClass.GetDateAtLocalDateFormat(dteSOComplitionTime.Value)) + @"  </td></tr>");
                tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>DO. By</b>  </td><td> " + strDOCompletedBy + @"  </td><td> <b>At</b>  </td><td> " + (dteDOComplitionTime == null ? "" : CommonClass.GetDateAtLocalDateFormat(dteDOComplitionTime.Value)) + @"  </td></tr>");

                tempD.Append(@"</table></div>");


                SalesOrderTDS.QrySalesOrderDetailsDataTable tbl = new SalesOrder().GetSalesOrderDetails(intID.ToString());

                if (tbl.Rows.Count > 0)
                {
                    decimal count = 0, promCount = 0;
                    decimal wgt = 0, promWgt = 0;

                    StringBuilder sb = new StringBuilder();
                    StringBuilder sbP = new StringBuilder();
                    StringBuilder sbGT = new StringBuilder();

                    sb.Append(@"<div id='Pdo' style=""display:none""></br><table  align=""center"" style=""width:700px;"">");
                    sbP.Append("<table  align=\"center\" style=\"width:700px;\">");

                    sb.Append(@"<tr style=""background-color:#9090FF; color:#FFFFFF"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                                PRODUCT DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                            <th style=""width:100px;text-align:center"">
                                APPR. QNT.</th>
                        </tr>");

                    sbP.Append(@"</br><tr style=""background-color:#FFFFFF"">
                                <th colspan=""5"" style=""text-align:left"">
                                P R O M O T I O N S</th>
                            </tr>
                            <tr style=""background-color:#E0E0E0"">
                            <th style=""width:20px;text-align:center"">
                                SL</th>
                            <th style=""text-align:center"">
                                PRODUCT DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>                            
                        </tr>");



                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        sb.Append("<tr style=\" \"><td>" + (i + 1) + "</td>");

                        sb.Append("<td>" + tbl[i].strProductName + "</td>");
                        sb.Append("<td>" + tbl[i].strUOM + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(tbl[i].numQuantity) + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(tbl[i].numApprQuantity) + "</td>");
                        sb.Append("</tr>");

                        if ((tbl[i].IsnumPromotionNull() ? 0 : tbl[i].numPromotion) > 0)
                        {
                            sbP.Append("<tr style=\" \"><td>" + (i + 1) + "</td>");

                            sbP.Append("<td>" + (tbl[i].IsstrPromItemNameNull() ? "" : tbl[i].strPromItemName) + "</td>");
                            sbP.Append("<td>" + (tbl[i].IsstrPromUomNull() ? "" : tbl[i].strPromUom) + "</td>");
                            sbP.Append("<td style=\"text-align:right\">" + (tbl[i].IsnumPromotionNull() ? "" : (tbl[i].numPromotion <= 0 ? "" : CommonClass.GetFormettingNumber(tbl[i].numPromotion))) + "</td>");
                            sbP.Append("</tr>");
                            promCount += tbl[i].numPromotion;
                        }

                        count += tbl[i].numQuantity;
                        wgt += tbl[i].numApprQuantity;
                    }



                    sb.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + count + "</th><th style=\"text-align:right;\">" + wgt + "</th></tr>");
                    sb.Append("</table>");

                    sbP.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + promCount + "</th></tr>");
                    sbP.Append("</table>");

                    sbGT.Append("<table align=\"center\" style=\"width:700px;\">");
                    sbGT.Append("<tr style=\"background-color:#E0E0E0\"><th>GRAND TOTAL</th><th style=\"width:100px; text-align:right;\">" + (count + promCount) + "</th><th style=\"width:100px; text-align:right;\">" + (wgt + promWgt) + "</th></tr>");
                    sbGT.Append("</table>");

                    if (promCount <= 0)
                    {
                        sbP = new StringBuilder();
                        sbGT = new StringBuilder();
                    }

                    tempD.Append(sb.ToString());
                    tempD.Append(sbP.ToString());
                    tempD.Append(sbGT.ToString());
                    tempD.Append("</div>");
                }


                OrderByTrip ot = new OrderByTrip();
                OrderByTripTDS.TblSalesOrderTripDataTable table = ot.GetDataBySO(intID.ToString());

                if (table.Rows.Count > 0)
                {
                    mainD.Append(@"<table align=""center""><tr><td><b style=""color:#990000; font-size:18px;"">ALL CHALLAN</b></td></tr></table>");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        GetChallan(table[i].intId.ToString(), i);
                    }
                }
            }
            else
            {
                tempD.Append(@"<table align=""center""><tr><td><b style=""color:#990000; font-size:18px;"">INVALID DELIVERY ORDER</b></td></tr></table>");
            }

            pnlDO.DataBind();
            pnlCH.DataBind();

        }

        private void GetChallan(string id, int rowCount)
        {
            string strChallanNo = "", strTripNo = "", strDriver = "", strContact = ""
                , strDrNid = "", strHealper = "", strUom = ""
                , strVehicle = "", strLogistic = "";
            bool? ysnCompleted = false;
            DateTime? dteInTime = null, dteOutTime = null, dteWgtIn = null, dteWgtOut = null;
            decimal? numEmpty = null, numLoaded = null, numCapacity = null;

            DeliverySupportTDS.SprCustomerServiceDODetailsDataTable table = ds.InfoByDODetails(id, Session["sesUserID"].ToString(), ref strChallanNo
                    , ref strTripNo, ref ysnCompleted, ref strVehicle, ref strLogistic
                    , ref dteInTime, ref dteOutTime, ref strDriver, ref strContact, ref strDrNid
                    , ref strHealper, ref strUom, ref numEmpty, ref numLoaded, ref numCapacity
                    , ref dteWgtIn, ref dteWgtOut);

            if (table.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbP = new StringBuilder();
                StringBuilder sbGT = new StringBuilder();

                decimal count = 0, promCount = 0;
                decimal wgt = 0, promWgt = 0;
                string status = "";

                if (dteOutTime != null) status = "Delivered from factory";
                else if (dteWgtOut != null) status = "Loaded. Waiting for delivery";
                else if (dteWgtIn != null) status = "Not Loaded. Waiting in quee for loading";
                else status = "Vehicle is in yeard";

                sb.Append(@"</br><table  align=""center"" style=""width:700px;"">
                <tr style=""background-color:#FF7777;"">
                    <td style=""font-weight:bold;width:110px"">
                                Challan No</td>
                    <td style=""width:240px; color:#990000;font-size:13px;"">
                         <b>" + strChallanNo + @"</b>
                    </td> 
                    <td style=""font-weight:bold;width:110px; "">
                                Trip No</td>
                    <td style=""width:240px"">
                         " + strTripNo + @"
                    </td>                                  
                </tr>            
                <tr style=""background-color:#D0D0FF;"">
                    <td style=""font-weight:bold;"">
                                Status</td>
                    <td colspan=""3"">
                         " + status + @"
                    </td>                                  
                </tr>
                <tr style=""background-color:#F0F0FF;"">
                    <td style=""font-weight:bold;"">
                                Vehicle</td>
                    <td>
                         " + strVehicle + @"
                    </td> 
                    <td style=""font-weight:bold;"">
                                Logistic By</td>
                    <td>
                         " + strLogistic + @"
                    </td>                                  
                </tr>
                <tr><td colspan=""4"">
                <a class=""link"" href=""#"" id='ds" + id + @"' onclick=""Show('" + id + @"')"">See More</a>
                <a class=""link"" href=""#"" style=""display:none"" id='dh" + id + @"' onclick=""Hide('" + id + @"')"">Hide</a>                
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a class=""link"" href=""#"" id='dsP" + id + @"' onclick=""Show('P" + id + @"')"">See Products</a>
                <a class=""link"" href=""#"" style=""display:none"" id='dhP" + id + @"' onclick=""Hide('P" + id + @"')"">Hide Products</a></td>
                </tr>
                </table>
                <div id='" + id + @"' style=""display:none"">                
                <table  align=""center"" style=""width:700px;"">                
                <tr style=""background-color:#D0D0FF;"">                
                    <td style=""font-weight:bold;width:110px"">
                        In Time</td>
                    <td style=""width:240px"">
                        " + CommonClass.GetDateAtLocalDateFormat(dteInTime) + @"
                    </td>
                     <td style=""font-weight:bold;width:110px;"">
                          Out Time</td>
                    <td style=""width:240px;"">
                         " + CommonClass.GetDateAtLocalDateFormat(dteOutTime) + @"
                    </td>
                </tr>                
                <tr style=""background-color:#F0F0FF;"">
                    <td style=""font-weight:bold;"">
                        Driver</td>
                    <td>
                        " + strDriver + @"</td>
                    <td style=""font-weight:bold;"">
                                           Healper</td>
                    <td colspan=""2"">
                        " + strHealper + @"
                    </td>                    
                </tr>
                 <tr style=""background-color:#D0D0FF;"">
                    <td style=""font-weight:bold;"">
                        N ID</td>
                    <td>
                        " + strDrNid + @"</td>
                    <td style=""font-weight:bold;"">
                                            Contact No</td>
                    <td colspan=""2"">
                        " + strContact + @"
                    </td>                    
                </tr>
                <tr style=""background-color:#F0F0FF;"">
                    <td style=""font-weight:bold;"">
                        UOM</td>
                    <td>
                        " + strUom + @"</td>
                    <td style=""font-weight:bold;"">
                         Empty Weight</td>
                    <td colspan=""2"">
                        " + numEmpty + @"
                    </td>                    
                </tr>
                <tr style=""background-color:#D0D0FF;"">
                    <td style=""font-weight:bold;"">
                        Loaded Weight</td>
                    <td>
                        " + numLoaded + @"</td>
                    <td style=""font-weight:bold;"">
                         Capacity</td>
                    <td colspan=""2"">
                        " + numCapacity + @"
                    </td>                    
                </tr>
                 <tr style=""background-color:#F0F0FF;"">
                    <td style=""font-weight:bold;"">
                        Wgt. Bridge In</td>
                    <td>
                        " + CommonClass.GetDateAtLocalDateFormat(dteWgtIn) + @"</td>
                    <td style=""font-weight:bold;"">
                         Wgt. Bridge Out</td>
                    <td colspan=""2"">
                        " + CommonClass.GetDateAtLocalDateFormat(dteWgtOut) + @"
                    </td>                    
                </tr>
                </table></div>");

                sb.Append(@"<div id='P" + id + @"' style=""display:none""></br><table  align=""center"" style=""width:700px;"" >");
                sbP.Append("<table  align=\"center\" style=\"width:700px;\">");

                sb.Append(@"<tr style=""background-color:#9090FF; color:#FFFFFF"">
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

                sbP.Append(@"</br><tr style=""background-color:#FFFFFF"">
                                <th colspan=""5"" style=""text-align:left"">
                                P R O M O T I O N S</th>
                            </tr>
                            <tr style=""background-color:#E0E0E0"">
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
                    sb.Append("<tr style=\" \"><td>" + table[i].intRowNumber + "</td>");

                    sb.Append("<td>" + table[i].strProductFullName + "</td>");
                    sb.Append("<td>" + table[i].strUOMShow + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numWeight) + "</td>");
                    sb.Append("</tr>");

                    if ((table[i].IsnumPromotionNull() ? 0 : table[i].numPromotion) > 0)
                    {
                        sbP.Append("<tr style=\" \"><td>" + table[i].intRowNumber + "</td>");

                        sbP.Append("<td>" + (table[i].IsstrPromItemNameNull() ? "" : table[i].strPromItemName) + "</td>");
                        sbP.Append("<td>" + (table[i].IsstrPromUomNull() ? "" : table[i].strPromUom) + "</td>");
                        sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromotionNull() ? "" : (table[i].numPromotion <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromotion))) + "</td>");
                        sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromWeightNull() ? "" : (table[i].numPromWeight <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromWeight))) + "</td>");
                        sbP.Append("</tr>");
                        promCount += table[i].numPromotion;
                        promWgt += table[i].numPromWeight;
                    }

                    count += table[i].numQuantity;
                    wgt += table[i].numWeight;
                }



                sb.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + count + "</th><th style=\"text-align:right;\">" + wgt + "</th></tr>");
                sb.Append("</table>");

                sbP.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + promCount + "</th><th style=\"text-align:right;\">" + promWgt + "</th></tr>");
                sbP.Append("</table>");

                sbGT.Append("<table align=\"center\" style=\"width:700px;\">");
                sbGT.Append("<tr style=\"background-color:#E0E0E0\"><th>GRAND TOTAL</th><th style=\"width:100px; text-align:right;\">" + (count + promCount) + "</th><th style=\"width:100px; text-align:right;\">" + (wgt + promWgt) + "</th></tr>");
                sbGT.Append("</table>");

                if (promCount <= 0)
                {
                    sbP = new StringBuilder();
                    sbGT = new StringBuilder();
                }

                mainD.Append(sb.ToString());
                mainD.Append(sbP.ToString());
                mainD.Append(sbGT.ToString());
                mainD.Append("</div>");
            }
        }
    }
}
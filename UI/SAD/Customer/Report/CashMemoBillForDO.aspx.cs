using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using SAD_BLL.Sales;
using SAD_DAL.Customer.Report;
using SAD_DAL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Customer.Report
{
    public partial class CashMemoBillForDO : System.Web.UI.Page
    {

        protected StringBuilder tempD = new StringBuilder();
        protected StringBuilder mainD = new StringBuilder();

        SAD_BLL.Customer.Report.DeliverySupport ds = new SAD_BLL.Customer.Report.DeliverySupport();
        SalesOrder bllso = new SalesOrder();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Customer\\Report\\CreditBalance";
        string stop = "stopping SAD\\Customer\\Report\\CreditBalance";
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
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Customer\\Report\\CreditBalance Delivery Support", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
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

                DataTable dt = new DataTable();
                StatementC bll = new StatementC();
                dt = bll.getdataforDOPrint(txtDO.Text.Trim());
                CheckDigit chk = new CheckDigit();
                string xcd = chk.Encode(dt.Rows[0][3].ToString());
              string  customercode = xcd;

                DataTable dtt = new DataTable();
                dtt = bllso.getdataDOAmount(txtDO.Text.Trim());

                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:18px;"">Akij Flour Mills Limited </b>  </td>
                            
                           </tr></table>");


                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;"">Akij House,198 Bir Uttam Mir Shawkat Sarak(Tejgaon Link Road),Tejgaon, Dhaka-1208 </b>  </td>
                            
                           </tr></table>");


                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;""> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>  </td>
                            
                           </tr></table>");

                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;""> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>  </td>
                            
                           </tr></table>");

                tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;"">Cash Memo Bill (Customer Copy) </b>  </td>
                            
                           </tr></table>");



                if (tableDO.Rows.Count > 0)
                {
                    tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                    
                    //tempD.Append(@"<tr><td colspan=""4"" align=""center""> <b style=""color:#990000; font-size:18px;"">" + txtDO.Text.Trim() + @"</b>  </td></tr>");
                    tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td style=""width:110px""> <b>Sales Order </b>  </td>
                            <td style=""width:240px""> " + CommonClass.GetShortDateAtLocalDateFormat(dteDate) + @"  </td>
                            <td style=""width:110px""> <b>Delivery Order (D.O)</b>  </td>
                            <td style=""width:110px"" align=""center""> <b style=""color:#990000; font-size:12px;"">" + txtDO.Text.Trim() + @"</b>  </td>
                           </tr>");
                    tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            <td> <b>Customer</b>  </td><td> " + strCustomer + @"  </td><td> <b>Party Code</b>  </td><td> " + customercode + @"  </td></tr>");
                    tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            <td> <b>Phone</b>  </td><td> " + strPhone + @"  </td><td> <b>Contact Person</b>  </td><td> " + strContactAt + @"  </td></tr>");
                    tempD.Append(@"<tr style=""background-color:#F0F0F0"">
                            
                            <td> <b>Address</b>  </td><td colspan=""3""> " + strAddress + @"  </td></tr>");
                    tempD.Append(@"<tr style=""background-color:#D0D0D0"">
                            </tr>");
                    tempD.Append(@"<tr><td colspan=""4"">
                 
                    <a class=""link"" href=""#"" id='dsPdo' onclick=""Show('Pdo')"">See Product</a><a class=""link"" href=""#"" style=""display:none"" id='dhPdo' onclick=""Hide('Pdo')"">Hide Product</a>
                    </td></tr></table>");

                 
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
                                Rate.</th>
                              <th style=""width:100px;text-align:center"">
                                Total Price(Tk.)</th>
                        </tr>");

                       



                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            sb.Append("<tr style=\" \"><td>" + (i + 1) + "</td>");

                            sb.Append("<td>" + tbl[i].strProductName + "</td>");
                            sb.Append("<td>" + tbl[i].strUOM + "</td>");
                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(tbl[i].numQuantity) + "</td>");
                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(tbl[i].monPrice) + "</td>");
                            sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(tbl[i].numQuantity* tbl[i].monPrice) + "</td>");
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
                            wgt += tbl[i].numApprQuantity* tbl[i].monPrice;
                        }



                        sb.Append("<tr style=\"background-color:#E0E0E0\">" +
                            "<th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + count + "</th>" +
                            "<th style =\"text-align:right;\">" +" "+ "</th>"+
                            "<th style=\"text-align:right;\">" + wgt + "</th></tr>");

                        sb.Append("</table>");
                   


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

                        tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                        tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;""> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>  </td>
                            
                           </tr></table>");

                        tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                        tempD.Append(@"<tr style="""">
                            <td style=""width:440px;text-align:center;""> <b style="" font-size:11px;""> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>  </td>
                            
                           </tr></table>");



                        string  amountinwords = dtt.Rows[0][19].ToString();
                        tempD.Append(@"<table style=""width:700px; text-align:left;"" align=""center"">");
                        //tempD.Append(@"<table style=""width:800px; text-align:center;"" align=""center"">");
                        tempD.Append(@"<tr style="""">
                       
                            <td style=""width:440px;text-align:left;""> <b style="" font-size:11px;""> In words:  " + amountinwords + @"</b>  </td>
                             
                            
                           </tr></table>");

                    }


                    OrderByTrip ot = new OrderByTrip();
                    OrderByTripTDS.TblSalesOrderTripDataTable table = ot.GetDataBySO(intID.ToString());

                    //if (table.Rows.Count > 0)
                    //{
                    //    mainD.Append(@"<table align=""center""><tr><td><b style=""color:#990000; font-size:18px;"">ALL CHALLAN</b></td></tr></table>");
                    //    for (int i = 0; i < table.Rows.Count; i++)
                    //    {
                    //        GetChallan(table[i].intId.ToString(), i);
                    //    }
                    //}
                }
                else
                {
                    tempD.Append(@"<table align=""center""><tr><td><b style=""color:#990000; font-size:18px;"">INVALID DELIVERY ORDER</b></td></tr></table>");
                }

                pnlDO.DataBind();
                pnlCH.DataBind();


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
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumberfourdigit(table[i].numQuantity) + "</td>");
                    sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumberfourdigit(table[i].numWeight) + "</td>");
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

                //sbP.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + promCount + "</th><th style=\"text-align:right;\">" + promWgt + "</th></tr>");
                //sbP.Append("</table>");

                //sbGT.Append("<table align=\"center\" style=\"width:700px;\">");
                //sbGT.Append("<tr style=\"background-color:#E0E0E0\"><th>GRAND TOTAL</th><th style=\"width:100px; text-align:right;\">" + (count + promCount) + "</th><th style=\"width:100px; text-align:right;\">" + (wgt + promWgt) + "</th></tr>");
                //sbGT.Append("</table>");

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
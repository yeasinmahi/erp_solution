using LOGIS_BLL.Trip;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using SAD_DAL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using static SAD_DAL.Sales.OrderByTripTDS;

namespace UI.SAD.Delivery
{
    public partial class PrintInvoice : System.Web.UI.Page
    {

        protected StringBuilder mainD = new StringBuilder();
        protected StringBuilder mainG = new StringBuilder();

        ChallanTDS.TblGatePassDataTable tblGP = new ChallanTDS.TblGatePassDataTable();
        DataRow dr;
        DateTime chDate;
        string userName = "", challanList = "", vehicle = "", driver = "", driverPh = ""
            , unitName = "", unitAddress = "";
        char separator = '-';
        DateTime date = new DateTime();
        SalesView bll = new SalesView();
        SalesView bllsv = new SalesView();
        OrderByTrip ot = new OrderByTrip();
        DataTable dt = new DataTable(); string tripId;
        DataTable chdt = new DataTable();
        DataTable dtprom = new DataTable();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
          
                try
                {

                    tripId = Request.QueryString["id"];

                    SalesView bll = new SalesView();

                    //OrderByTripTDS.SprCustomerTripIdvsChallanDetaillsDataTable table = ot.GetDataByTripForPendingQnt(tripId);
                    OrderByTripTDS.SprCustomerOrdervsChallanDetaillsDataTable table = ot.GetDataByInformation();

                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            //GetChallan(table[i].intId.ToString(), i, table[i].intcustomerid, table[i].ysnmaxchallan);
                            GetChallan(table[i].intSOId.ToString(), i, table[i].intcustomerid, table[i].ysnmaxchallan);
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
                              <th style=""width:20px;text-align:center"">
                                Challan</th>
                                 <th style=""width:20px;text-align:center"">
                                Date</th>

                            <th style=""text-align:center"">
                                Item DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                       
                            <th style=""width:100px;text-align:center"">
                                Rate</th>


                          
                            <th style=""width:100px;text-align:center"">
                                Amount</th>
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
                            mainG.Append("<td>" + "2019-01-01" + "</td>");
                            mainG.Append("<td>" + row.strProductName + "</td>");
                            mainG.Append("<td>" + row.strUOM + "</td>");
                            mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.numQnt) + "</td>");
                            mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.monPrice) + "</td>");
                            mainG.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(row.monPrice) + "</td>");

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
                        //pnlGate.DataBind();
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
                        //pnlGate.DataBind();
                    }
                }
                catch (Exception ex)
                {
                 

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

        
            StringBuilder sbtotaldelvparybase = new StringBuilder();
        

            //string promItem = "";
            decimal count = 0, promCount = 0;
            decimal wgt = 0, promWgt = 0;
            decimal? extAmount = 0;
            //decimal? chamount  = 0;

            string challanNo = "", doNo = "", customerName = "", customerPhone = ""
                , distributionPoint = "", contactAt = "", contactPhone = ""
                    , delevaryAddress = "", other = ""
                , extra = "", charge = "", logistic = "", incentive = "";
            bool isLogBasedOnUOM = false, isCharBasedOnUOM = false, isIncenBasedOnUOM = false;
            string dodate, chamount = "";
            SAD_BLL.Sales.Report.Challan ch = new SAD_BLL.Sales.Report.Challan();
            DataTable dtamnt = new DataTable();
           

            ChallanTDS.SprTripChallanInfoWithTotalAmntDataTable table = ch.GetTripDataCustomize1(id, Session[SessionParams.USER_ID].ToString(), separator.ToString()
               , ref date, ref unitName, ref unitAddress, ref userName
               , ref challanNo, ref doNo, ref customerName, ref customerPhone, ref distributionPoint
               , ref contactAt, ref contactPhone, ref delevaryAddress, ref other
               , ref vehicle, ref extra, ref extAmount
               , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
               , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM, ref chamount);

            if (table.Rows.Count > 0)
            {

                if (maxChallan)
                    tempD.Append(Banner("Invoice Copy", challanNo, doNo, unitName, unitAddress, CommonClass.GetShortDateAtLocalDateFormat(date)
                    , customerName, CommonClass.GetTimeAtLocalDateFormat(date)
                    , delevaryAddress, vehicle, contactAt, driver, contactPhone, driverPh, chamount).ToString());

                {

                    sbtotaldelvparybase.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                  
                }


                if (maxChallan)
                {
                    sbtotaldelvparybase.Append(@"<tr style=""font-size:10px;background-color:#A0A0A0"">
                           <th style=""width:20px;text-align:center"">
                                SL</th>
                              <th style=""width:20px;text-align:center"">
                                Challan</th>
                                 <th style=""width:20px;text-align:center"">
                                Date</th>

                            <th style=""text-align:center"">
                                Item DESCRIPTION</th>
                            <th style=""width:100px;text-align:center"">
                                UOM</th>
                            <th style=""width:100px;text-align:center"">
                                QNT.</th>
                       
                            <th style=""width:100px;text-align:center"">
                                Rate</th>


                          
                            <th style=""width:100px;text-align:center"">
                                Amount</th>
                        
                        </tr>");
        


                }


                #region ********************************************** 
                if (maxChallan)
                {

                    StringBuilder temp = new StringBuilder();
                    //getOrderbasetotalchallanqnt
                    chdt = bllsv.getcustomerbasetotalchallanqnt(int.Parse(tripId), customerId);


                    for (int K = 0; K < chdt.Rows.Count; K++)
                    {
                        string chProduct = chdt.Rows[K]["strProductName"].ToString();
                        string chDo = chdt.Rows[K]["strdonumber"].ToString();
                        try
                        {
                            string dtedate = chdt.Rows[K]["dtedodate"].ToString();
                            chDate = DateTime.Parse(chdt.Rows[K]["dtedodate"].ToString());
                        }
                        catch { }
                        //chDate = DateTime.Parse(dt.Rows[K]["dtedodate"].ToString());
                        string chNumber = chdt.Rows[K]["strchallannumber"].ToString();
                        string chQty = chdt.Rows[K]["decchallanqnt"].ToString();
                        string chrate = chdt.Rows[K]["rate"].ToString();
                        string chPrice = chdt.Rows[K]["monAmount"].ToString();

                        sbtotaldelvparybase.Append("<tr style=\" font-size:10px;\"><td>" + chdt.Rows[K]["intsl"] + @"</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chNumber + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chDate.ToString("yyyy-MM-dd") + "</td>");
                        sbtotaldelvparybase.Append("<td>" + chProduct + "</td>");
                        //sbtotaldelvparybase.Append("<td>" + chDo + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + "UOM" + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chQty + "</td>");
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chrate + "</td>");
                      
                        sbtotaldelvparybase.Append("<td style=\"text-align:right\">" + chPrice + "</td>");
                        sbtotaldelvparybase.Append("</tr>");





                    }

                





                }




                #endregion*****************************************************
                //sbPending.Append("<tr style=\"background-color:#E0E0E0\"><th colspan=\"3\">TOTAL</th><th style=\"text-align:right;\">" + 22 + "</th><th style=\"text-align:right;\">" + 232 + "</th></tr>");

                sbtotaldelvparybase.Append("</table>");
           
                if (maxChallan)
                {

                    tempD.Append("</td></tr></table>");

                }

            }


            tempD.Append(sb.ToString());
            tempD.Append(sbtotaldelvparybase.ToString());
           

            tempD.Append(sbP.ToString());
            tempD.Append(sbGT.ToString());
            tempD.Append(sbT.ToString());
        
            if (maxChallan)
            {


                tempD.Append(Footer(true).ToString());
            }

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
            , string driver, string phone, string driverPhone, string chamount)
        {
            StringBuilder temp = new StringBuilder();



            //challanNo
            temp.Append(@"<tr>
                <td rowspan=""4"" align=""left"">
                <img alt=""Logo""  height=""57px"" width=""150px"" src=../../Content/images/img/" + Request.QueryString["unit"] + @".png />
                </td>
                <td colspan=""3""  style=""text-align:center; font-size:17px; font-weight:bold;"">
                    " + heading + @"</td>
             
               <td rowspan=""4"" align=""right"">                
                 
                </td>
                 <td rowspan=""1"" align=""right"">                
             
                </td>
 



            </tr>
            <tr>
                <td colspan=""3"" style=""text-align:center; font-size:13px;"">
                    
                </td>
            </tr>           
            <tr>
                <td colspan=""3"" style=""text-align:center; font-size:11px;"">
                   
                </td>
            </tr>
            <tr style=""height:10px;"">
                <td colspan=""5"">
                    &nbsp;</td>
            </tr>
          
            <tr style=""font-size:10px; background-color:#E0E0E0;"">
                <td>
                                       Bill to Customer Name</td>
                <td colspan=""2"">
                    " + customer + @"
                </td>
                <td style=""width:100px;"">
                                        Ship To Party</td>
                <td style=""width:180px;"">
                     " + customer + @"
                </td>
            </tr>
            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td>
                                     Bill   Address</td>
                <td colspan=""2"">
                    " + address + @"
                </td>
                
                <td>
                                       Ship Address</td>
                <td>
                    " + address + @"
                </td>
            </tr>

            <tr style=""font-size:10px; background-color:#F0F0FF;"">
                <td>
                                        Bill Contact No</td>
                <td colspan=""2"">
                    " + phone + @"
                </td>
                  <td>
                                      Ship  Contact No</td>
                <td colspan=""2"">
                    " + phone + @"
                </td>

            </tr>
           
                <tr style=""font-size:10px; background-color:#F0F0FF;"">
                        <td style=""width:120px; font-size:12px; font-weight:bold;"">
                                                                                        Invoice #</td>
                        <td colspan=""2"" style=""width:300px; font-size:12px; font-weight:bold;"">
                                " + challanNo + @"
                        </td>               
                        <td style=""width:100px;"">
                                        Invoice Date         </td>
                        <td style=""width:180px;"">
                                " + "2019-05-30" + @"
                        </td>
                       
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
                <img alt=""Logo""  height=""57px"" width=""150px"" src=../../Content/images/img/" + Request.QueryString["unit"] + @".png />
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
                    Prepare By</td>");
            temp.Append(@"<td align=""center"" style=""padding-top:50px; font-size:11px; width:30%"">
                  Name</td>                
                <td align=""right""style="" padding-top:50px; font-size:11px; width:40%"">
                   Designation &nbsp;&nbsp;</td>");

           

            temp.Append(@"</tr>
        </table>");

            return temp;
        }
    }
}
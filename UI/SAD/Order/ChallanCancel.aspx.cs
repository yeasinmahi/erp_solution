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

namespace UI.SAD.Order
{
    public partial class ChallanCancel : BasePage
    {
        protected StringBuilder mainD = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["delid"] != null && Request.QueryString["delid"] != "")
                {
                    SAD_BLL.Sales.Report.Challan ch = new SAD_BLL.Sales.Report.Challan();
                    ch.Remove(Request.QueryString["delid"], Session[SessionParams.USER_ID].ToString());
                }
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
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
                    }
                }
            }
        }


        private void GetChallan(string id, int rowCount)
        {

            StringBuilder tempD = new StringBuilder();

            StringBuilder sb = new StringBuilder();
            StringBuilder sbP = new StringBuilder();
            StringBuilder sbT = new StringBuilder();

            string promItem = "";
            decimal count = 0, promCount = 0;
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
            ChallanTDS.SprTripChallanInfoDataTable table = ch.GetTripData(id, Session[SessionParams.USER_ID].ToString(), separator.ToString()
                , ref date, ref unitName, ref unitAddress, ref userName
                , ref challanNo, ref doNo, ref customerName, ref customerPhone, ref distributionPoint
            , ref contactAt, ref contactPhone, ref delevaryAddress, ref other
                , ref vehicle, ref extra, ref extAmount
                , ref driver, ref driverPh, ref charge, ref logistic, ref incentive
                , ref isLogBasedOnUOM, ref isCharBasedOnUOM, ref isIncenBasedOnUOM);

            if (table.Rows.Count > 0)
            {
                Button btn = new Button();

                sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                sbP.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                sb.Append(@"<tr>
                <td colspan=""2"" align=""center"" style=""text-align:center; font-size:17px; font-weight:bold; background-color:#AAAAFF"">
                " + challanNo + @"                
                </td>
                <td colspan=""2"" align=""center"" style=""text-align:center; font-size:17px; font-weight:bold; background-color:#FFEEEE"">                
                    <a href=""#"" onclick=""ShowPopUpE('ChallanCancel.aspx?delid=" + id + "&id=" + Request.QueryString["id"] + @"')""class=""link"">Cancel This Challan</a>
                </td>
            </tr>");


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

                if (promCount <= 0)
                {
                    sbP = new StringBuilder();
                }
            }


            tempD.Append(sb.ToString());
            tempD.Append(sbP.ToString());
            tempD.Append(sbT.ToString());

            if (rowCount > 0)
            {
                mainD.Append("<div style=\"page-break-before:always;\"></div></br>");
            }

            mainD.Append(tempD.ToString());
        }
    }
}
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
    public partial class DOPrint : BasePage
    {
        protected StringBuilder sb = new StringBuilder();
        protected StringBuilder sbP = new StringBuilder();
        protected StringBuilder sbGT = new StringBuilder();
        protected StringBuilder sbT = new StringBuilder();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\DOPrint";
        string stop = "stopping SAD\\Sales\\Report\\DOPrint";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\DOPrint Challan Print", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                //try
                //{

                    string promItem = "";
                decimal count = 0, promCount = 0, total = 0, gross = 0;
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

                    lblUnitName1.Text = unitName.ToUpper();
                    lblUnitAddr1.Text = unitAddress;
                    lblDate1.Text = CommonClass.GetShortDateAtLocalDateFormat(date);
                    lblTime1.Text = CommonClass.GetTimeAtLocalDateFormat(date);
                    lblCusName1.Text = customerName;
                    lblCusAddr1.Text = delevaryAddress;
                    lblCusPhone1.Text = customerPhone;
                    lblCusBuyer1.Text = "";
                    lblChlNo1.Text = challanNo;
                    lblVehicle1.Text = vehicle;
                    lblCusBuyer1.Text = propitor;
                    lblDriver1.Text = driver;
                    lblDriverPhone1.Text = driverPh;
                    lblNarration1.Text = other;

                    imgCode1.ImageUrl = "../../../Accounts/Print/BarCodeHandler.ashx?info=" + challanNo;
                    imgLogo1.ImageUrl = "../../../Accounts/Print/Images/" + Request.QueryString["unit"] + ".png";

                    sb.Append("<table style=\"width:100%;\"  class=\"TablePR\">");
                    sbP.Append("<table style=\"width:100%;\"  class=\"TablePR\">");

                    //string[] val = productCatagory.Split(sep);

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

                        /*val = table[i].strProductFullName.Split(sep);
                        for (int j = 0; j < val.Length; j++)
                        {
                            sb.Append("<td>" + val[j] + "</td>");
                        }*/

                        sb.Append("<td>" + table[i].strProductFullName + "</td>");
                        sb.Append("<td>" + table[i].strUOMShow + "</td>");
                        sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(table[i].numQuantity) + "</td>");
                        //total = table[i].numQuantity;
                        //sb.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(total) + "</td>");
                        sb.Append("</tr>");

                        promItem = table[i].IsstrPromItemNameNull() ? "" : table[i].strPromItemName;


                        if (promItem != "")
                        {
                            sbP.Append("<tr style=\" font-size:10px;\"><td>" + table[i].intRowNumber + "</td>");

                            sbP.Append("<td>" + promItem + "</td>");
                            sbP.Append("<td>" + (table[i].IsstrPromUomNull() ? "" : table[i].strPromUom) + "</td>");
                            sbP.Append("<td style=\"text-align:right\">" + (table[i].IsnumPromotionNull() ? "" : (table[i].numPromotion <= 0 ? "" : CommonClass.GetFormettingNumber(table[i].numPromotion))) + "</td>");
                            //total = table[i].IsnumPromotionNull() ? 0 : table[i].numPromotion;
                            //sbP.Append("<td style=\"text-align:right\">" + CommonClass.GetFormettingNumber(total) + "</td>");
                            sbP.Append("</tr>");

                        }

                        count += table[i].numQuantity;
                        promCount += table[i].numPromotion;
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

                    Panel1.DataBind();
                    Panel11.DataBind();
                }

                //}
                //catch (Exception ex)
                //{
                //    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                //    Flogger.WriteError(efd);
                //}

                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
        }
    }
}

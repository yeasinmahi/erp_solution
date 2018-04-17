using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class Previewall : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string innerTableHtml = ""; 
            BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
            string billid = Request.QueryString["BILLID"];
            string poid = Request.QueryString["POID"];
            string shpid = Request.QueryString["SHPID"];
            string viewtype = Request.QueryString["VTP"];   //Bill, Adjust, Vat, Po, Mrr

            #region ------------- Preview Bill ------------------
            if (poid != null && shpid != null && viewtype == "Bill")
            {
                DataTable objDT = new DataTable();
                objDT = objPartyBill.GetPartyBill(int.Parse(billid), int.Parse(poid), int.Parse(shpid));
                if (objDT.Rows.Count > 0)
                {
                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {
                        string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + objDT.Rows[row]["strFTPPath"].ToString();
                        innerTableHtml = innerTableHtml + @" <table border='0'>
                        <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='100%' Width='100%'></td></tr></table>";
                    }
                }
                else
                {                    
                    string imageUrl = ("../../Content/Images/img/ImageNotAvailable.jpg");
                    innerTableHtml = innerTableHtml + @" <table border='0'>
                    <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='50%' Width='50%'></td></tr></table>";
                }
            }
            #endregion

            #region ------------- Preview Adjust ------------------
            if (poid != null && shpid != null && viewtype == "Adjust")
            {
                DataTable objDT = new DataTable();
                objDT = objPartyBill.GetPartyAdjust(int.Parse(billid), int.Parse(poid), int.Parse(shpid));
                if (objDT.Rows.Count > 0)
                {
                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {
                        string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + objDT.Rows[row]["strFTPPath"].ToString();
                        innerTableHtml = innerTableHtml + @" <table border='0'>
                        <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='100%' Width='100%'></td></tr></table>";
                    }
                }
                else
                {
                    string imageUrl = ("../../Content/Images/img/ImageNotAvailable.jpg");
                    innerTableHtml = innerTableHtml + @" <table border='0'>
                    <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='50%' Width='50%'></td></tr></table>";
                }
            }
            #endregion

            #region ------------- Preview Vat ------------------
            if (poid != null && shpid != null && viewtype == "Vat")
            {
                DataTable objDT = new DataTable();
                objDT = objPartyBill.GetPartyVat(int.Parse(billid), int.Parse(poid), int.Parse(shpid));
                if (objDT.Rows.Count > 0)
                {
                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {
                        string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + objDT.Rows[row]["strFTPPath"].ToString();
                        innerTableHtml = innerTableHtml + @" <table border='0'>
                        <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='100%' Width='100%'></td></tr></table>";
                    }
                }
                else
                {
                    string imageUrl = ("../../Content/Images/img/ImageNotAvailable.jpg");
                    innerTableHtml = innerTableHtml + @" <table border='0'>
                    <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='50%' Width='50%'></td></tr></table>";
                }
            }
            #endregion

            #region ------------- Preview PO ------------------
            else if (poid != null && shpid != null && viewtype == "Po")
            {
                DataTable objDT = new DataTable();
                objDT = objPartyBill.GetPOList(int.Parse(poid), int.Parse(shpid));
                if (objDT.Rows.Count > 0)
                {
                    #region ----------- Set Data ------------
                    decimal Total = decimal.Parse(objDT.Compute("SUM(amnt)", string.Empty).ToString());
                    string total = "Total Amount : " + GetSubstringValue(Total.ToString());

                    string supplierName = objDT.Rows[0]["supplier"].ToString().ToUpper();
                    string podate = DateTime.Parse(objDT.Rows[0]["podate"].ToString()).ToString("dd-MM-yyyy");
                    int unit = int.Parse(objDT.Rows[0]["unit"].ToString());
                    DataTable unitinfo = objPartyBill.GetUnitInformation(unit);
                    string unitName = unitinfo.Rows[0]["strDescription"].ToString().ToUpper();
                    string unitAddress = unitinfo.Rows[0]["strAddress"].ToString().ToUpper();
                    string imageUrl = "../../Content/Images/img/" + unit + ".png";

                    innerTableHtml = @" <table border='0' style = 'width:650px;'>
                    <tr><td style='text-align: left; width:25%'>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @"></td>

                    <td colspan='5' style='text-align: center; font-size: 14px; font-weight: bold;' valign='top'>"; innerTableHtml = innerTableHtml + unitName +
                     @"<br/ style='font-size: 12px; font-weight: bold;'>" + unitAddress + @"<br/><br/></td></tr>

                    <tr><td style='text-align: right; font-size: 11px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"Supplier Name : </td>
                    <td colspan='5' style='text-align: left; font-size: 11px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + supplierName + @"</td></tr>
                    
                    <tr><td style='text-align: right; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"PO No. : </td>
                    <td colspan='5' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + poid + @"</td></tr>
                    <tr><td style='text-align: right; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"PO Date. : </td>
                    <td colspan='5' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + podate + @"</td></tr>                

                    <tr><td colspan='6'><hr /></td></tr>
                    <tr style='text-align:left; font-size: 11px; font-weight: bold; border:solid 1px #c0c0c0;'><td>"; innerTableHtml = innerTableHtml + @"Purpose</td>
                    <td style= 'Width:5%;'>SSL</td><td style= 'Width:40%;'>Item name</td><td style= 'Width:8%px;'>UOM</td><td style= 'Width:12%px;'>Quantity</td><td style= 'Width:13%;'>Amount</td></tr>
                    </table>";

                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {                        
                        string shipmentsl = objDT.Rows[row]["spid"].ToString();
                        string purpose = objDT.Rows[row]["purpose"].ToString();
                        string itemname = objDT.Rows[row]["itmname"].ToString();
                        string uom = objDT.Rows[row]["uom"].ToString();
                        string quantity = GetSubstringValue(objDT.Rows[row]["qnty"].ToString());
                        string amount = GetSubstringValue(objDT.Rows[row]["amnt"].ToString());

                        innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:649px; text-align: left; font-size: 11px; border:solid 1px #c0c0c0;'>
                        <tr><td style= 'Width:25%;'>"; innerTableHtml = innerTableHtml + purpose + @"</td>
                        <td style= 'Width:5%;'>"; innerTableHtml = innerTableHtml + shipmentsl + @"</td>
                        <td style= 'Width:40%;'>"; innerTableHtml = innerTableHtml + itemname + @"</td>
                        <td style= 'Width:7%;'>"; innerTableHtml = innerTableHtml + uom + @"</td>
                        <td style= 'Width:10%;'>"; innerTableHtml = innerTableHtml + quantity + @"</td>
                        <td style= 'Width:15%;'>"; innerTableHtml = innerTableHtml + amount + @"</td>
                        </tr>
                        </table>";
                    }
                    innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:649px; text-align: right; font-size: 11px; font-weight: bold;'>
                    <tr><td colspan='5'><hr /></td></tr><tr><td colspan='5'>"; innerTableHtml = innerTableHtml + total + @"</td></tr></table>";
                    #endregion
                }
            }
            #endregion

            #region ------------- Preview MRR ------------------
            else if (poid != null && shpid != null && viewtype == "Mrr")
            {
                DataTable objDT = new DataTable();
                objDT = objPartyBill.GetMrrList(int.Parse(poid), int.Parse(shpid));
                if (objDT.Rows.Count > 0)
                {
                    #region ----------- Set Data ------------
                    decimal Total = decimal.Parse(objDT.Compute("SUM(monBDTTotal)", string.Empty).ToString());
                    string total = "Total Amount : " + GetSubstringValue(Total.ToString());

                    string supplierName = objDT.Rows[0]["strSupplierName"].ToString().ToUpper();
                    string mrrno = objDT.Rows[0]["intMRRID"].ToString();
                    int unit = int.Parse(objDT.Rows[0]["intUnitID"].ToString());
                    DataTable unitinfo = objPartyBill.GetUnitInformation(unit);
                    string unitName = unitinfo.Rows[0]["strDescription"].ToString().ToUpper();
                    string unitAddress = unitinfo.Rows[0]["strAddress"].ToString().ToUpper();
                    string imageUrl = "../../Content/Images/img/" + unit + ".png";

                    innerTableHtml = @" <table border='0' style = 'width:650px;'>
                    <tr><td style='text-align: left; width:25%'>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @"></td>

                    <td colspan='5' style='text-align: center; font-size: 14px; font-weight: bold;' valign='top'>"; innerTableHtml = innerTableHtml + unitName +
                     @"<br/ style='font-size: 12px; font-weight: bold;'>" + unitAddress + @"<br/><br/></td></tr>

                    <tr><td style='text-align: right; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"PO No. : </td>
                    <td colspan='5' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + poid + @"</td></tr>

                    <tr><td style='text-align: right; font-size: 11px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"MRR No : </td>
                    <td colspan='5' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + mrrno + @"</td></tr>
                    
                    <tr><td style='text-align: right; font-size: 11px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + @"Supplier Name : </td>
                    <td colspan='5' style='text-align: left; font-size: 11px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + supplierName + @"</td></tr>
                    <tr><td colspan='6'><hr /></td></tr>

                    <tr style='text-align:left; font-size: 11px; font-weight: bold; border:solid 1px #c0c0c0;'><td>"; innerTableHtml = innerTableHtml + @"MRR Date</td>
                    <td style= 'Width:40%;'>Item name</td><td style= 'Width:8%;'>POQuty</td><td style= 'Width:8%;'>RcvQuty</td>
                    <td style= 'Width:8%;'>FCRate</td><td style= 'Width:10%;'>BDTTotal</td></tr>
                    </table>";

                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {
                        string[] dtemrr = Regex.Split(objDT.Rows[row]["dteMrr"].ToString()," ");
                        string itemname = objDT.Rows[row]["strItemnames"].ToString();
                        string numpo = GetSubstringValue(objDT.Rows[row]["numPOQty"].ToString());
                        string numrcv = GetSubstringValue(objDT.Rows[row]["numReceiveQty"].ToString());
                        string monfc = GetSubstringValue(objDT.Rows[row]["monFCRate"].ToString());
                        string monbdt = GetSubstringValue(objDT.Rows[row]["monBDTTotal"].ToString()); 

                        innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:649px; text-align: left; font-size: 11px; border:solid 1px #c0c0c0;'>
                        <tr><td style= 'Width:25%;'>"; innerTableHtml = innerTableHtml + dtemrr[0] + @"</td>
                        <td style= 'Width:40%;'>"; innerTableHtml = innerTableHtml + itemname + @"</td>
                        <td style= 'Width:8%;text-align: right;'>"; innerTableHtml = innerTableHtml + numpo + @"</td>
                        <td style= 'Width:8%;text-align: right;'>"; innerTableHtml = innerTableHtml + numrcv + @"</td>
                        <td style= 'Width:8%;text-align: right;'>"; innerTableHtml = innerTableHtml + monfc + @"</td>
                        <td style= 'Width:10%;text-align: right;'>"; innerTableHtml = innerTableHtml + monbdt + @"</td>
                        </tr>
                        </table>";
                    }
                    innerTableHtml = innerTableHtml + @" <table border='0' style = 'width:649px; text-align: right; font-size: 11px; font-weight: bold;'>
                    <tr><td colspan='5'><hr /></td></tr><tr><td colspan='5'>"; innerTableHtml = innerTableHtml + total + @"</td></tr></table>";
                    #endregion
                }
            }

            #endregion

            #region ------------- Preview Voucher ------------------            
            else { }
            #endregion

            #region ------------ Filter Div By InnerHTML ---------------
            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            createDiv.ID = "createDiv";
            createDiv.InnerHtml = innerTableHtml;
            createDiv.Attributes.Add("class", "dynamicDivbn");
            this.Controls.Add(createDiv);
            #endregion
        }

        private string GetSubstringValue(string gvnstring)
        {
            if (String.IsNullOrEmpty(gvnstring))
            {
                return gvnstring;
            }
            else
            {
                decimal number;
                Decimal.TryParse(gvnstring, out number);
                decimal returnDEC = Decimal.Round(number, 2);
                return returnDEC.ToString();
            }
        }



    }
}
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
using UI.ClassFiles;

namespace UI.Accounts.Print
{
    public partial class PrintAdvice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string unitID = Request.QueryString["unitID"].ToString();
            string vID = Request.QueryString["vID"].ToString();
            string vCode = Request.QueryString["vCode"].ToString();

            string unitName = "", unitAddress = "";
            string adviceNo = "", securityCode = "";
            DateTime? advicedate = null;
            UI.ClassFiles.Print pri = new UI.ClassFiles.Print();
            string tmpHtml = pri.PrintAdvice(vCode, int.Parse(vID), int.Parse(unitID),
                                            ref unitName, ref unitAddress, ref advicedate, ref adviceNo, ref securityCode);

            securityCode = vCode + securityCode;

            lblAdviceNo.Text = adviceNo;
            lblAdviceDate.Text = CommonClass.GetLonDateAtLocalDateFormat(advicedate);
            lblUnitName.Text = unitName;
            lblUnitAddress.Text = unitAddress;
            lblAdvice.Text = "Bank Advice";
            //lblVoucherType.Text = "<br><br>" + voucherType;
            string strCodeForbarCode = securityCode.Replace("-", "");
            Image1.ImageUrl = "BarCodeHandler.ashx?info=" + strCodeForbarCode;
            Image1.Width = 180;
            Image1.Height = 50;

            //logo image
            Image2.ImageUrl = "../../Content/images/img/" + unitID + ".png";
            //Image2.Width = 180;
            lblHtml.Text = tmpHtml;
        }
    }
}

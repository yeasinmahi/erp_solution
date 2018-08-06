using SAD_BLL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class PrintAccountsSV : BasePage
    {
        DataTable dt = new DataTable();
        UDTCLSalesBLL obj = new UDTCLSalesBLL();
        int unitId, salesId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                int  salesId = int.Parse(Request.QueryString["intId"].ToString());
                int unitId = int.Parse(Request.QueryString["intunit"].ToString());
                string htmlString = obj.SVPrintView(1, unitId, "", salesId);
                lblUnitName.Text = "United Dhaka Tobacco Company Ltd.".ToUpper();
                lblUnitAddress.Text = "Akij House,198,Bir Uttam Mir Shawkat Sarak,Tejgaon,Dhaka-1208";
                lblVoucherType.Text = "<br><br>" + "Sales Voucher";

                //strCodeForbarCode = strCodeForbarCode.Replace("-", "");
                //Image1.ImageUrl = "BarCodeHandler.ashx?info=" + strCodeForbarCode;

                Image1.Width = 180;
                Image1.Height = 50;

              // logo image
                Image2.ImageUrl = "../../Content/Images/img/" + 16 + ".png";
                //Image2.Width = 180;
                //Image2.Height = 50;
                Label1.Text = htmlString;
            }
        }
    }
}
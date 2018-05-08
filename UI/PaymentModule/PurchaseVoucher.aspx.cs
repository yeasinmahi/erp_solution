using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.PaymentModule
{
    public partial class PurchaseVoucher : System.Web.UI.Page
    {
       // Payment_All_Voucher_BLL objVouchar = new Payment_All_Voucher_BLL();
        DataTable dt = new DataTable(); int enroll;string xmlData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //dt = objVouchar.GetData(1, xmlData, 0, 0, DateTime.Now, enroll);
            }
            else { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string strType = ddlType.SelectedItem.ToString();

                if (strType == "Purchase Return")
                {

                }
                else if (strType == "Import Purchase Voucher")
                {
                }
                else if (strType == "Purchase")
                {
                }

            }
            catch { }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.TourPlan;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class CustomerBankGauranteeReport : BasePage
    {
        CustBankGauranteeBLL objbankGauranteeBLL = new CustBankGauranteeBLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVList.Visible = false;
            lbltitle.Visible = false;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GVList.Visible = true;
            lbltitle.Visible = true;       

        }
    }
}
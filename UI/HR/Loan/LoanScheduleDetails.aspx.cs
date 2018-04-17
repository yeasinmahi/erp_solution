using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Loan
{
    public partial class LoanScheduleDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnLoanApplicationId.Value = Request.QueryString["intLoanApplicationId"];
            if (!IsPostBack)
            {
                dgvLoanScheduleDetails.DataBind();
            }
        }
    }
}
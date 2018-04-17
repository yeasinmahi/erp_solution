using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using System.Data;
using UI.ClassFiles;


namespace UI.HR.Benifit
{
    public partial class PF_InvestmentMaturityDetails : BasePage
    {

        string numInvestmentDuration = "";
        string numInterestRate = "";

        PF_Maturity_BLL objPF_Maturity_BLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnInvestmentID.Value = Request.QueryString["intInvestmentID"];
                numInvestmentDuration = Request.QueryString["numInvestmentDuration"];
                numInterestRate = Request.QueryString["numInterestRate"];
                hdnSoftwareLoginId.Value = "1397"; //Request.QueryString["intLoginUserId"];
                LoadDefaultValue(numInvestmentDuration, numInterestRate);
            }
        }

        private void LoadDefaultValue(string numInvestmentDuration, string numInterestRate)
        {
            txtInvestmentDuration.Text = numInvestmentDuration;
            txtInterestRate.Text = numInterestRate;
        }

        protected void btnMaturedInvestment_Click(object sender, EventArgs e)
        {
            string strMaturityStatus = "";
            try
            {
                objPF_Maturity_BLL = new PF_Maturity_BLL();
                strMaturityStatus = objPF_Maturity_BLL.MaturedPfInvestment(int.Parse(hdnInvestmentID.Value), decimal.Parse(txtActualProfit.Text), decimal.Parse(txtActualDuration.Text), decimal.Parse(txtActualRate.Text), int.Parse(hdnSoftwareLoginId.Value));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strMaturityStatus + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentForm", "javascript:ReloadParent(); ", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! error has been occured.Please see error details.'" + ex.Message + ");", true);
            }
        }
    }
}
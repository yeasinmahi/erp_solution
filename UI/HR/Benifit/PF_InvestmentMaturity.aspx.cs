using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UI.HR.Benifit
{
    public partial class PF_InvestmentMaturity : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnPfUnitId.Value = "23";//Session[SessionParams.UNIT_ID.ToString()].ToString();
                dgvInvestmentMaturity.DataBind();
            }
        }
        protected void dgvInvestmentMaturity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / September-03-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvInvestmentMaturity, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }
        public string GetStr(object intInvestmentID, object numInvestmentDuration, object numInterestRate)
        {
            return "ShowInvestmentDetailsForMaturity('" + intInvestmentID.ToString() + "','" + numInvestmentDuration.ToString() + "','" + numInterestRate.ToString() + "','" + hdnLoginUserId.Value.ToString() + "')";
        }
    }
}
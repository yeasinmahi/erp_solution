using HR_BLL.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Tax
{
    public partial class TreasaryDeposite : BasePage
    {
        AbsentReport rpt = new AbsentReport(); string msgStatus; DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdncompleteded.Value = "False";
            }
            
        }

        #region  ------------------ DataBound and IndexChange Event Handaler ---------
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            monTaxAmount.Text = rpt.GetTotalTreasuryAmount(int.Parse(Session[SessionParams.CURRENT_UNIT].ToString())).ToString("0.00");
            dt = rpt.GetTreasuryInformation(int.Parse(ddlUnit.SelectedValue.ToString()), Convert.ToBoolean(hdncompleteded.Value));
            dgvtreasury.Columns[3].FooterText = dt.AsEnumerable().Select(x => x.Field<decimal>("TreasuryAmount")).Sum().ToString("0.00");
        }               
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            monTaxAmount.Text = rpt.GetTotalTreasuryAmount(int.Parse(Session[SessionParams.CURRENT_UNIT].ToString())).ToString("0.00");
            dt = rpt.GetTreasuryInformation(int.Parse(ddlUnit.SelectedValue.ToString()), Convert.ToBoolean(hdncompleteded.Value));
            dgvtreasury.Columns[3].FooterText = dt.AsEnumerable().Select(x => x.Field<decimal>("TreasuryAmount")).Sum().ToString("0.00");
        }
        protected void rdocompletestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdocompletestatus.SelectedValue == "false")//Value=False Means not completed
            { hdncompleteded.Value = "False"; dgvtreasury.Columns[4].Visible = true; btnSubmit.Enabled = true; }
            else //Value=True Means completed
            { hdncompleteded.Value = "True"; dgvtreasury.Columns[4].Visible = false; btnSubmit.Enabled = false; }

            dt = rpt.GetTreasuryInformation(int.Parse(ddlUnit.SelectedValue.ToString()), Convert.ToBoolean(hdncompleteded.Value));
            dgvtreasury.Columns[3].FooterText = dt.AsEnumerable().Select(x => x.Field<decimal>("TreasuryAmount")).Sum().ToString("0.00");
        }
        
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int unit = int.Parse(ddlUnit.SelectedValue.ToString());
                    string narration = txtNarration.Text;
                    decimal deposite = decimal.Parse(monTaxAmount.Text);
                    msgStatus = rpt.TreasuryInformation(unit, narration, deposite, usrid);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ msgStatus +"');", true);
                    monTaxAmount.Text = "0:00"; txtNarration.Text = ""; dgvtreasury.DataBind();
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry for this request.');", true); }
            }
        }

        public string CompleteTreasuryDeposite(string intAutoId,string UnitName, string TreasuryAmount)
        { return "CompleteTreasuryDeposite('" + intAutoId + "','" + UnitName + "','" + TreasuryAmount + "')"; }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (hdncomplete.Value == "1")
            {
                try
                {
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    string challanno = txtchallanno.Text;
                    rpt.CompleteTreasuryInformation(usrid, challanno, int.Parse(hdntreasuryID.Value.ToString()));
                    txtTreasuryAmount.Text = "0:00"; txtunit.Text = ""; txtchallanno.Text = "";
                    dgvtreasury.DataBind();
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry for this request.');", true); }
            }
        }
















    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Budget_BLL.Budget;
using UI.ClassFiles;

namespace UI.BudgetPlan
{
    public partial class CostCenterCorrection : System.Web.UI.Page
    {
        private int _enroll = 0;
        private Budget_Entry_BLL _bll = new Budget_Entry_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            _enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
           
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                LoadUnit(_enroll);
            }
            
            
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {

                _enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                HiddenField hdnSubledgerId = row.FindControl("hdnSubledgerId") as HiddenField;

                int intSubledgerId = int.Parse(hdnSubledgerId.Value);
                int intCostCenterId = int.Parse(ddlCostCenter.SelectedValue.ToString());
                string costcenter = ddlCostCenter.SelectedItem.ToString();
                int intUnitId = int.Parse(ddlUnit.SelectedValue.ToString());
                string msg = _bll.UpdateLedgerCostcenter(intUnitId, intSubledgerId, intCostCenterId, costcenter);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                LoadGrid();
            }
            catch { }
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            LoadGrid();
        }

        
        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int unitId = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                LoadCostCenter(_enroll, unitId);
                gridView.DataSource = "";
                gridView.DataBind();

            }
            catch { }
            


        }

        private void LoadGrid()
        {
            try
            {
                int unitId = 0;
                int costCentreId = 0;
                if (int.TryParse(ddlUnit.SelectedValue, out unitId))
                {
                    if (int.TryParse(ddlCostCenter.SelectedValue, out costCentreId))
                    {
                        string fromDateText = txtFromDate.Text;
                        string toDateText = txtToDate.Text;
                        DateTime fromDate, toDate;
                        if (!string.IsNullOrWhiteSpace(fromDateText))
                        {
                            if (!string.IsNullOrWhiteSpace(toDateText))
                            {
                                fromDate = DateTime.Parse(txtFromDate.Text);
                                toDate = DateTime.Parse(txtToDate.Text);
                                BindGrid(unitId, fromDate, toDate);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('To date can not be blank');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('From date can not be blank');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select cost center');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select unit first');", true);
                }
            }
            catch { }
           
        }

        private void BindGrid(int unitId, DateTime fromDate, DateTime toDate)
        {
            gridView.DataSource = _bll.GetCostCenterData(unitId, fromDate, toDate);
            gridView.DataBind();
        }
        private void LoadUnit(int enroll)
        {
            DataTable dt = _bll.GetUnitforCostCenter(enroll);
            ddlUnit.DataSource = dt;
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }
        private void LoadCostCenter(int enroll, int unitId)
        {
            DataTable dt = _bll.GetCostCenter(unitId, enroll);
            ddlCostCenter.DataSource = dt;
            ddlCostCenter.DataValueField = "intCostCenterID";
            ddlCostCenter.DataTextField = "strCCName";
            ddlCostCenter.DataBind();
        }

    }
}
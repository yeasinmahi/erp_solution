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
            //_enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            _enroll = 32897;
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnit(_enroll);
            }
            
            
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            LoadGrid();
        }

        
        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int unitId =  Convert.ToInt32(ddlUnit.SelectedItem.Value);
            LoadCostCenter(_enroll, unitId);
        }

        private void LoadGrid()
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
                            fromDate = Utility.DateTimeConverter.StringToDateTime(fromDateText, "dd/MM/yyyy");
                            toDate = Utility.DateTimeConverter.StringToDateTime(toDateText, "dd/MM/yyyy");
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
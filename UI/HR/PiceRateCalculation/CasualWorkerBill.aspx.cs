using System;
using System.Data;
using System.Web.UI.WebControls;
using HR_BLL.PiceRateCalculation;
using UI.ClassFiles;
using Utility;

namespace UI.HR.PiceRateCalculation
{
    public partial class CasualWorkerBill : BasePage
    {
        private readonly PiceRateCalculation_BLL _bll = new PiceRateCalculation_BLL();
        private DataTable _dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            DateTime date = txtDate.Text.ToDateTime("dd/MM/yyyy");
            _dt = _bll.GetAttendentEmployeeList(date);
            gridView.Loads(_dt);
        }
        protected void gridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.FindControl("ddlProductionType") is DropDownList ddlProductionType)
                {
                    _dt = _bll.GetProductList();
                    ddlProductionType.Loads(_dt, "Id", "ProductName");
                    ddlProductionType.SetSelectedValue("0");
                }
            }
        }

        protected void gridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int unitId = ddlUnit.SelectedValue();
            DateTime dateTime = txtDate.Text.ToDateTime("dd/MM/yyyy");
            foreach (GridViewRow row in gridView.Rows)
            {
                int employeeId = Convert.ToInt32((row.FindControl("lblEmpEnroll") as Label)?.Text);
                int quantity = Convert.ToInt32((row.FindControl("txtQuantity") as Label)?.Text);
                int productionId = Convert.ToInt32((row.FindControl("ddlProductionType") as DropDownList)?.SelectedValue());

                int empId = _bll.InsertCasualSalary(employeeId, unitId, dateTime.ToString("yyyy/MM/dd"), quantity, productionId);
            }
            
        }

        
    }
}
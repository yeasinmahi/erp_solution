using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
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
                HidePanel();
            }
        }
        
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            DateTime date = txtDate.Text.ToDateTime("dd/MM/yyyy");
            _dt = _bll.GetAttendentEmployeeList(date);
            gridView.Loads(_dt);
            HidePanel();
            SetVisibility("itemPanel2",false);
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

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            List<int> empIds= new List<int>();
            int unitId = ddlUnit.SelectedValue();
            DateTime dateTime = txtDate.Text.ToDateTime("dd/MM/yyyy");
            foreach (GridViewRow row in gridView.Rows)
            {

                if (int.TryParse((row.FindControl("txtQuantity") as TextBox)?.Text, out int quantity))
                {
                    int productionId = Convert.ToInt32((row.FindControl("ddlProductionType") as DropDownList)?.SelectedValue());
                    if (quantity == 0 || productionId == 0)
                    {
                        continue;
                    }
                    int employeeId = Convert.ToInt32((row.FindControl("lblEmpEnroll") as Label)?.Text);

                    int empId = _bll.InsertCasualSalary(employeeId, unitId, dateTime.ToString("yyyy/MM/dd"), quantity, productionId);
                    if (empId == 0)
                    {
                        empIds.Add(employeeId);

                    }
                }
                else
                {
                    // blank quantity
                }
                
            }

            if (empIds.Count > 0)
            {
                string empIdAsString = empIds.ToStringWithDelimiter(",");
                Toaster("Can not insert "+ empIdAsString+ ".",Common.TosterType.Warning);
            }
            else
            {
                Toaster("Insert successfully",Common.TosterType.Success);
            }
            UnloadAll();
            HidePanel();
        }

        protected void btnShowIndividualReport_OnClick(object sender, EventArgs e)
        {
            UnloadAll();
            lblHeader.Text = "Worker Bill Individual Report";
            string url;
            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/AMFL_Indivisual_Pice_Rate_Report" + "&EmpCode=" +txtEnroll.Text + "&dteStartDate=" + txtFDate.Text + "&dteEndDate=" + txtTDate.Text + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
            HidePanel();
        }

        protected void btnShowAllReport_OnClick(object sender, EventArgs e)
        {
            UnloadAll();
            int unitId = ddlUnit.SelectedValue();
            DateTime dateTime = txtFDate.Text.ToDateTime("yyyy-MM-dd");
            lblHeader.Text = "Worker Bill All Report";
            string url;
            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/AMFL_ALL_Pice_Rate_Report" + "&unitId=" + unitId + "&dteStartDate=" + txtFDate.Text + "&dteEndDate=" + txtTDate.Text + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
            HidePanel();
        }

        private void UnloadAll()
        {
            gridView.UnLoad();
            ///gridViewIndividualReport.UnLoad();
            //gridViewReport.UnLoad();
        }
        private void HidePanel()
        {
            SetVisibility("panel", gridView.Rows.Count > 0);
            //SetVisibility("itemPanel2", gridViewIndividualReport.Rows.Count > 0);
            //SetVisibility("itemPanel", gridViewReport.Rows.Count > 0);
        }

        protected void btnGenarateSalary_Click(object sender, EventArgs e)
        {
            int unitId = ddlUnit.SelectedValue();
            _dt = _bll.PiecesRateSalaryGenarate(3, 0, 0, 0, unitId, 0);
            if (_dt.Rows.Count > 0)
            {
                if (_dt.GetValue<int>("Column1") > 0)
                {
                    Toaster("Already Salary Generated This Month.");
                    return;
                }

            }
            _dt = _bll.PiecesRateSalaryGenarate(1, 0, 0, 0, unitId, 0);

            string message=string.Empty;
            _dt = _bll.PiecesRateSalaryGenarateFinal("", DateTime.Now.AddMonths(-1).FirstDay(), DateTime.Now.AddMonths(-1).LastDay(), unitId, Enroll, ref message);
            if (message.ToLower().Contains("success"))
            {
                Toaster("Salary Generated Successfully", Common.TosterType.Success);
                return;
            }
            Toaster("Salary Generated Failed", Common.TosterType.Error);
        }
    }
}
using HR_BLL.Global;
//using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Salary
{
    public partial class SupportingnAdvice : BasePage
    {
        HR_BLL.Salary.SalaryInfo salinfo = new HR_BLL.Salary.SalaryInfo();
        DataTable dtabl = new DataTable(); string xmlFilePath = "";
        string SaveFilepath = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); btnAdvice.Enabled = true; txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();"); btnShow.Text = "Show Report"; btnPrint.Visible = false;
                hdnField.Value = "0"; btnExport.Visible = false;
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                {
                    string strSearchKey = txtEmployeeSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                    {
                        LoadGrid(searchKey[1]);
                        hdfSearchBoxTextChange.Value = "false";
                    }
                }
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);
        }


        #region ------------- Click Event handaler -----------------
        private void LoadGrid(string empCode)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                int unit = int.Parse(ddlUnit.SelectedValue);
                int station = int.Parse(ddlJobStation.SelectedValue);
                DateTime dte = DateTime.Parse(txtDate.Text);
                string vwtyp = empCode;
                dtabl = salinfo.GetSalaryAdviceandSupporting(unit, station, dte, vwtyp);
                if (dtabl.Rows.Count > 0)
                {
                    dgvSupporting.DataSource = dtabl;
                    dgvSupporting.DataBind();
                    btnPrint.Visible = true;
                    btnExport.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to there is no data !!!');", true);
                }
            }
        }
        protected void btnAdvice_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            { }
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                if (hdnconfirm.Value == "1")
                {
                    int unit = int.Parse(ddlUnit.SelectedValue);
                    int station = int.Parse(ddlJobStation.SelectedValue);
                    DateTime dte = DateTime.Parse(txtDate.Text);
                    string vwtyp = "supporting";
                    dtabl = salinfo.GetSalaryAdviceandSupporting(unit, station, dte, vwtyp);
                    if (dtabl.Rows.Count > 0)
                    {
                        dgvSupporting.DataSource = dtabl;
                        dgvSupporting.DataBind();
                        ExportExcell();
                        btnPrint.Visible = true;
                        btnExport.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to there is no data !!!');", true);
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
        private void ExportExcell()
        {
            try
            {
                string GetFilepath = Server.MapPath("~/HR/Salary/TemplatesAdviceAndVouchar/SupportingTemplate.xlsx");
                int unit = int.Parse(ddlUnit.SelectedValue);
                int station = int.Parse(ddlJobStation.SelectedValue);
                DateTime dte = DateTime.Parse(txtDate.Text);
                string vwtyp = "supporting";
                dtabl = salinfo.GetSalaryAdviceandSupporting(unit, station, dte, vwtyp);

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook xlWB = xlApp.Workbooks.Open(GetFilepath, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet xlSheet = (Microsoft.Office.Interop.Excel._Worksheet)xlWB.Sheets[1];
                xlSheet.Cells[2, 2] = "Statement of Employees Salary of " + dte.ToString("MMMM") + "," + dte.ToString("yyyy") +
                " to be transfer to the respective Employee's Bank Account by debiting our CD Account No- " +
                dtabl.Rows[0]["strCDAccount"].ToString() + " as noted below.";
                int xlRow = 4;
                for (int i = 0; i < dtabl.Rows.Count; i++)
                {
                    xlSheet.Cells[xlRow, 2] = dtabl.Rows[i]["strEmployeeCode"].ToString();
                    xlSheet.Cells[xlRow, 3] = dtabl.Rows[i]["strEmployeeName"].ToString();
                    xlSheet.Cells[xlRow, 4] = dtabl.Rows[i]["strDepatrment"].ToString();
                    xlSheet.Cells[xlRow, 5] = dtabl.Rows[i]["strBankName"].ToString();
                    xlSheet.Cells[xlRow, 6] = dtabl.Rows[i]["strBranchName"].ToString();
                    xlSheet.Cells[xlRow, 7] = dtabl.Rows[i]["strBankAccountNo"].ToString();
                    xlSheet.Cells[xlRow, 8] = dtabl.Rows[i]["monTotalPayableSalary"].ToString();
                    xlRow++;
                }
                SaveFilepath = Server.MapPath("~/HR/Salary/FileExcell/" + ddlJobStation.SelectedItem.ToString() + "_Sal_" + dte.ToString("MMMM") + "," + dte.ToString("yyyy") + ".xlsx");
                xlWB.SaveAs(SaveFilepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlWB.Close(false, SaveFilepath, Type.Missing);
                xlApp.Quit();
            }
            catch (Exception ex) { ex.ToString(); }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "SupportingForPrint('" + ddlUnit.SelectedValue.ToString() + "','" + ddlJobStation.SelectedValue.ToString() + "','" + txtDate.Text + "','supporting');", true);
        }
        #endregion

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dte = DateTime.Parse(txtDate.Text);
                #region ============== Previous ================
                //string GetFilepath = Server.MapPath("~/HR/Salary/TemplatesAdviceAndVouchar/SupportingTemplate.xlsx");
                //int unit = int.Parse(ddlUnit.SelectedValue);
                //int station = int.Parse(ddlJobStation.SelectedValue);
                //string vwtyp = "supporting";
                //dtabl = salinfo.GetSalaryAdviceandSupporting(unit, station, dte, vwtyp);
                //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                //Microsoft.Office.Interop.Excel._Workbook xlWB = xlApp.Workbooks.Open(GetFilepath, Type.Missing, Type.Missing,
                //Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //Microsoft.Office.Interop.Excel._Worksheet xlSheet = (Microsoft.Office.Interop.Excel._Worksheet)xlWB.Sheets[1];
                //xlSheet.Cells[2, 2] = "Statement of Employees Salary of " + dte.ToString("MMMM") + "," + dte.ToString("yyyy") +
                //" to be transfer to the respective Employee's Bank Account by debiting our CD Account No- " +
                //dtabl.Rows[0]["strCDAccount"].ToString() + " as noted below.";
                //int xlRow = 4;
                //for (int i = 0; i < dtabl.Rows.Count; i++)
                //{
                //    xlSheet.Cells[xlRow, 2] = dtabl.Rows[i]["strEmployeeCode"].ToString();
                //    xlSheet.Cells[xlRow, 3] = dtabl.Rows[i]["strEmployeeName"].ToString();
                //    xlSheet.Cells[xlRow, 4] = dtabl.Rows[i]["strDepatrment"].ToString();
                //    xlSheet.Cells[xlRow, 5] = dtabl.Rows[i]["strBankName"].ToString();
                //    xlSheet.Cells[xlRow, 6] = dtabl.Rows[i]["strBranchName"].ToString();
                //    xlSheet.Cells[xlRow, 7] = dtabl.Rows[i]["strBankAccountNo"].ToString();
                //    xlSheet.Cells[xlRow, 8] = dtabl.Rows[i]["monTotalPayableSalary"].ToString();
                //    xlRow++;
                //}
                //SaveFilepath = Server.MapPath("~/HR/Salary/TemplatesAdviceAndVouchar/" + ddlJobStation.SelectedItem.ToString() + "_Sal_" + dte.ToString("MMMM") + "," + dte.ToString("yyyy") + ".xlsx");
                //xlWB.SaveAs(SaveFilepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //xlWB.Close(false, SaveFilepath, Type.Missing);
                //xlApp.Quit();

                #endregion

                SaveFilepath = Server.MapPath("~/HR/Salary/FileExcell/" + ddlJobStation.SelectedItem.ToString() + "_Sal_" + dte.ToString("MMMM") + "," + dte.ToString("yyyy") + ".xlsx");
                string name = Path.GetFileName(SaveFilepath);
                Response.ContentType = "application/ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
                Response.TransmitFile(SaveFilepath);
                //Response.WriteFile(SaveFilepath);
                Response.End();
                //File.Delete(SaveFilepath);
            }
            catch (Exception ex) { ex.ToString(); }
        }
        

    }
}
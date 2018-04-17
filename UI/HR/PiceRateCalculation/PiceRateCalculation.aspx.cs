using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Data;
using System.Text.RegularExpressions;
using HR_DAL.PiceRateCalculation;
using HR_BLL.PiceRateCalculation;
using UI.ClassFiles;

namespace UI.HR.PiceRateCalculation
{
    public partial class PiceRateCalculation : BasePage
    {
        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        PiceRateCalculation_BLL objPiceRateCalculation = new PiceRateCalculation_BLL();
        int? userID = null;
        static int intLoginUerId;
        static int intjobStationID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            if (!IsPostBack)
            {
                string srt = "";
                srt = "GotoNextFocus('" + btnAdd.ClientID + "',event);";
                txtProductionPerDay.Attributes.Add("onkeyPress", srt);

                //srt = "GotoNextFocus('" + txtSearchByName.ClientID + "',event);";
                //btnAdd.Attributes.Add("onkeyPress", srt);

                txtProductionPerDay.Attributes.Add("onblur", "CalculateTotalPayableAmount();");
                // txtRatePerUnit.Text = "2";
            }
            else
            {
                if (!String.IsNullOrEmpty(txtSearchByName.Text))
                {
                    string strSearchKey = txtSearchByName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    LoadDefultFieldValue(searchKey[1]);
                }
                else
                {
                    RefreshPage();
                }
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetAutoFillEmployeeListBySearchKey(string prefixText, int count)
        {
            return EmployeeBasicInfo.GetAutoFillPiceRateEmployeeListBySearchKey(prefixText, intLoginUerId);
        }
        private void LoadDefultFieldValue(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / June-18-2012
            //Modified   :   
            //Parameters :   employeeID
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {

                    DataTable oDT_EmpInfo = new DataTable();
                    oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(userID, empCode);
                    if (oDT_EmpInfo.Rows.Count > 0)
                    {
                        txtName.Text = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                        txtUnit.Text = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                        txtDepartment.Text = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();

                        txtRatePerUnit.Text = Math.Round(decimal.Parse(oDT_EmpInfo.Rows[0]["monSalary"].ToString()), 2).ToString();
                    }
                    txtProductionPerDay.Focus();
                }
            }
            catch
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert daily payable salary for pice rate employees
            //Created    :   Md. Yeasir Arafat / June-18-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,numDailyProduction,numRatePerUnit,totalPayable and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objPiceRateCalculation = new PiceRateCalculation_BLL();
                    string insertStatus = objPiceRateCalculation.InsertPiceRateData(intLoginUerId, hdfEmpCode.Value.ToString(), DateTime.Now, decimal.Parse(txtProductionPerDay.Text), decimal.Parse(txtRatePerUnit.Text), decimal.Parse(txtTotalPayablePerDay.Text));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                    RefreshControl();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to update daily payable salary for pice rate employees
            //Created    :   Md. Yeasir Arafat / June-19-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,numDailyProduction,numRatePerUnit,totalPayable and accept updateStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()) && !String.IsNullOrEmpty(hdnPiceRateGenerateDate.Value))
                {
                    objPiceRateCalculation = new PiceRateCalculation_BLL();
                    string updateStatus = objPiceRateCalculation.UpdatePiceRateData(intLoginUerId, hdfEmpCode.Value.ToString(), DateTime.Parse(hdnPiceRateGenerateDate.Value), decimal.Parse(txtProductionPerDay.Text), decimal.Parse(txtRatePerUnit.Text), decimal.Parse(txtTotalPayablePerDay.Text));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + updateStatus + "');", true);
                    RefreshControl();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry!Select row properly....');", true);
                }
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to update daily payable salary for pice rate employees
            //Created    :   Md. Yeasir Arafat / June-19-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,numDailyProduction,numRatePerUnit,totalPayable and accept deleteStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()) && !String.IsNullOrEmpty(hdnPiceRateGenerateDate.Value))
                {
                    objPiceRateCalculation = new PiceRateCalculation_BLL();
                    string deleteStatus = objPiceRateCalculation.DeletePiceRateData(intLoginUerId, hdfEmpCode.Value.ToString(), DateTime.Parse(hdnPiceRateGenerateDate.Value));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                    RefreshControl();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry!Select row properly....');", true);
                }
            }
            catch { }
        }

        private void RefreshControl()
        {
            txtProductionPerDay.Text = "";
            // txtRatePerUnit.Text = "";
            txtTotalPayablePerDay.Text = "";
            dgvPiceRate.DataBind();
        }
        protected void dgvPiceRate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / June-18-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPiceRate, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }
        protected void dgvPiceRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to reload field value by application id
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :

            try
            {
                if (dgvPiceRate.Rows.Count > 0)
                {
                    hdnPiceRateGenerateDate.Value = dgvPiceRate.SelectedRow.Cells[0].Text;
                    hdnEmployeeID.Value = ((HiddenField)dgvPiceRate.SelectedRow.Cells[1].FindControl("hdnEmployeeId")).Value.ToString();
                    txtProductionPerDay.Text = ((HiddenField)dgvPiceRate.SelectedRow.Cells[1].FindControl("hdnProductPerDay")).Value.ToString();
                    //txtRatePerUnit.Text = dgvPiceRate.SelectedRow.Cells[2].Text;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CalculateTotalPayableAmount", "javascript:CalculateTotalPayableAmount();", true);
                }
            }
            catch { }
        }
        private void RefreshPage()
        {
            try
            {
                txtDepartment.Text = "";
                txtDesignation.Text = "";
                txtName.Text = "";
                txtProductionPerDay.Text = "";
                txtRatePerUnit.Text = "";
                txtSearchByName.Text = "";
                txtTotalPayablePerDay.Text = "";
                txtUnit.Text = "";
                dgvPiceRate.DataBind();
                hdfEmpCode.Value = "";
                txtRatePerUnit.Text = "";
            }
            catch { }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Employee;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text.RegularExpressions;
using HR_BLL.Penalty;
using UI.ClassFiles;

namespace UI.HR.Penalty
{
    public partial class PenaltySetup : BasePage
    {
        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        HR_BLL.Penalty.Penalty objPenalty;
        int? userID = null;
        static int intLoginUerId;
        static int intjobStationID;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Load initial Feild variable 
            //Created    :   Md. Yeasir Arafat / July-01-2012
            //Modified   :   
            //Parameters : 

            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());//int.Parse(Session["sesUserId"].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            if (!IsPostBack)
            {
                hdnUserID.Value = null;//hdfUserID value set null cause this public leave application functions are only operate by empCode

                pnlUpperControl.DataBind();

                txtEffectedDate.Text = DateTime.Now.ToShortDateString();

                string srt = "";
                srt = "GotoNextFocus('" + txtEffectedDate.ClientID + "',event);";
                txtPenaltyAmount.Attributes.Add("onkeyPress", srt);

                srt = "GotoNextFocus('" + txtDescription.ClientID + "',event);";
                txtEffectedDate.Attributes.Add("onkeyPress", srt);

                srt = "GotoNextFocus('" + btnAdd.ClientID + "',event);";
                txtDescription.Attributes.Add("onkeyPress", srt);

                dgvPenaltyAmount.DataBind();
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
            return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        }
        private void LoadDefultFieldValue(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / June-03-2012
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
                        txtJobStatus.Text = oDT_EmpInfo.Rows[0]["strJobType"].ToString();
                    }
                }
                dgvPenaltyAmount.DataBind();
            }
            catch
            {

            }
        }
        private void RefreshPage()
        {
            try
            {
                // ClearFeild();
                //hdfEmpCode.Value = "";
                //hdnUserID.Value = "";

                txtDepartment.Text = "";
                txtDesignation.Text = "";
                txtJobStatus.Text = "";
                txtName.Text = "";
                txtUnit.Text = "";
                //txtSearchByName.Text = "";

                dgvPenaltyAmount.DataBind();
            }
            catch { }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert PENALTY  data
            //Created    :   MD. YEASIR ARFAT
            //Modified   :   
            //Parameters :   passing parameters intuserID,empCode,punishment amount ,punishment reason,effected date  and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objPenalty = new HR_BLL.Penalty.Penalty();
                    string insertStatus = objPenalty.InsertPunishmentData(null, hdfEmpCode.Value.ToString(), Decimal.Parse(txtPenaltyAmount.Text), txtDescription.Text, DateTime.Parse(txtEffectedDate.Text), intLoginUerId);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                    dgvPenaltyAmount.DataBind();
                    ClearFeild();
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
            //Summary    :   This function will use to Edit PENALTY  data
            //Created    :   MD. YEASIR ARFAT/July-01-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,empCode,punishment amount ,punishment reason,effected date  and accept updateStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objPenalty = new HR_BLL.Penalty.Penalty();
                    string updateStatus = objPenalty.UpdatePunishmentData(null, hdfEmpCode.Value.ToString(), Decimal.Parse(txtPenaltyAmount.Text), txtDescription.Text, DateTime.Parse(txtEffectedDate.Text), intLoginUerId);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + updateStatus + "');", true);
                    dgvPenaltyAmount.DataBind();
                    ClearFeild();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Delete PENALTY  data
            //Created    :   MD. YEASIR ARFAT/July-01-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,empCode,punishment amount ,punishment reason,effected date  and accept updateStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objPenalty = new HR_BLL.Penalty.Penalty();
                    string deleteStatus = objPenalty.DeletePunishmentData(null, hdfEmpCode.Value.ToString(), DateTime.Parse(txtEffectedDate.Text), intLoginUerId);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                    dgvPenaltyAmount.DataBind();
                    ClearFeild();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void dgvPenaltyAmount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   MD. YEASIR ARAFAT / JULY-01-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvPenaltyAmount, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }
        protected void dgvPenaltyAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Get Return Feild Value by Application ID From GridView Row Click
            //Created    :   MD. YEASIR ARAFAT/JUNE-01-2012
            //Modified   :   
            //Parameters :   

            try
            {
                ClearFeild();
                if (bool.Parse(((HiddenField)dgvPenaltyAmount.SelectedRow.Cells[3].FindControl("hdnEditable")).Value.ToString()))
                {
                    txtPenaltyAmount.Text = dgvPenaltyAmount.SelectedRow.Cells[0].Text;
                    txtEffectedDate.Text = DateTime.Parse(((HiddenField)dgvPenaltyAmount.SelectedRow.Cells[1].FindControl("hdnMonthID")).Value.ToString() + "/" + "1/" + dgvPenaltyAmount.SelectedRow.Cells[2].Text).ToShortDateString();
                    txtDescription.Text = dgvPenaltyAmount.SelectedRow.Cells[3].Text;
                }
            }
            catch
            { }
        }

        private void ClearFeild()
        {
            txtPenaltyAmount.Text = "";
            txtDescription.Text = "";
            txtEffectedDate.Text = DateTime.Now.ToShortDateString();
            dgvPenaltyAmount.DataBind();
        }
    }
}
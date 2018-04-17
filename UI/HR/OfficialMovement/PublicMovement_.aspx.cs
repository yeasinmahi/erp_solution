using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.OfficialMovement;
using HR_BLL.Employee;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Text.RegularExpressions;
using HR_BLL.Global;
using UI.ClassFiles;

namespace UI.HR.OfficialMovement
{
    public partial class PublicMovement : BasePage
    {
        #region Declare variable
        static int intLoginUerId;
        static int intjobStationID;
        HR_BLL.OfficialMovement.OfficialMovement objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        #endregion
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            //hdnUserID.Value = "2";
            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            if (!IsPostBack)
            {
                txtAddressDueToMovement.Attributes.Add("onkeyUp", "SearchAddressByGoogle();");

                txtFromDate.Attributes.Add("onblur", "CheckFromDateIsGreatterThanToDate()");
                txtToDate.Attributes.Add("onblur", "CheckFromDateIsGreatterThanToDate()");

                hdnUserID.Value = null;//Session["sesUserId"].ToString(); /*In this case userId should be zero.because this is public movement application only handeled by empCode*/
                ddlCountry.SelectedValue = "BD";//Load Bagladesh as defult countryDropdownList value
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
                ddlCountry.DataBind();
                CheckDistrictDropdoownVisibility();
            }
            else
            {

                //if (!String.IsNullOrEmpty(AutoCompleteBox.Text))
                //{
                //    string strSearchKey = AutoCompleteBox.Text;
                //    string[] searchKey = Regex.Split(strSearchKey, ",");
                //    hdfEmpCode.Value = searchKey[1];
                //    LoadPersonalInfromation(searchKey[1]);
                //    dgvOfficialMovementApplication.DataBind();
                //}
                //else
                //{
                //    RefreshPage();
                //}
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAutoFillEmployeeListBySearchKey(string prefixText, int count)
        {
            return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(intLoginUerId, intjobStationID, strSearchKey);
            return result;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert official movement application data
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,dateAppliedFromDate,dateAppliedToDate,strReason,strAddress,movementTypeId and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    string insertStatus = objOfficialMovement.SprInsertOfficialMovementApplication(null, hdfEmpCode.Value.ToString(), int.Parse(ddlTypesOfActivities.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), (ddlCountry.SelectedValue.ToString() == null ? "BD" : ddlCountry.SelectedValue.ToString()), txtAddressDueToMovement.Text, int.Parse(ddlDistrict.SelectedValue.ToString()), txtDescription.Text);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                    RefreshPage();
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
            //Summary    :   This function will use to update official movement application data
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID,dateAppliedFromDate,dateAppliedToDate,strReason,strAddress,movementTypeId and accept updateStatus

            try
            {
                if (dgvOfficialMovementApplication.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                    {
                        objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                        string updateStatus = objOfficialMovement.SprUdateOfficialMovementApplication(int.Parse(hdnApplicationID.Value.ToString()), null, hdfEmpCode.Value.ToString(), int.Parse(ddlTypesOfActivities.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), (ddlCountry.SelectedValue.ToString() == null ? "BD" : ddlCountry.SelectedValue.ToString()), txtAddressDueToMovement.Text, int.Parse(ddlDistrict.SelectedValue.ToString()), txtDescription.Text);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + updateStatus + "');", true);
                        RefreshPage();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                    }
                }
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to delete official movement application data
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID and accept deleteStatus

            try
            {
                if (dgvOfficialMovementApplication.Rows.Count > 0)
                {
                    if (bool.Parse(((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[7].FindControl("hdnEditable")).Value.ToString()))
                    {

                        if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                        {
                            objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                            string deleteStatus = objOfficialMovement.SprDeleteOfficialMovementApplication(int.Parse(hdnApplicationID.Value.ToString()), null, hdfEmpCode.Value.ToString());
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                            RefreshPage();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry!You can not delete approved data.');", true);
                    }
                }
            }
            catch { }
        }

        protected void dgvOfficialMovementApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters : 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvOfficialMovementApplication, "Select$" + e.Row.RowIndex);
                e.Row.Style.Add("cursor", "pointer");
            }
        }
        protected void dgvOfficialMovementApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to reload field value by application id
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   

            if (dgvOfficialMovementApplication.Rows.Count > 0)
            {
                if (bool.Parse(((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[7].FindControl("hdnEditable")).Value.ToString()))
                {


                    hdnApplicationID.Value = dgvOfficialMovementApplication.SelectedRow.Cells[0].Text;

                    ddlCountry.SelectedValue = ((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[1].FindControl("hdnCountryCode")).Value.ToString();
                    if (ddlCountry.SelectedValue.ToString() == "BD")
                    {
                        ddlDistrict.SelectedValue = ((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[1].FindControl("hdnDistrictID")).Value.ToString();
                    }
                    ddlTypesOfActivities.SelectedValue = ((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[1].FindControl("hdnMoveTypeID")).Value.ToString();

                    txtDescription.Text = dgvOfficialMovementApplication.SelectedRow.Cells[5].Text;

                    txtFromDate.Text = dgvOfficialMovementApplication.SelectedRow.Cells[3].Text;
                    txtToDate.Text = dgvOfficialMovementApplication.SelectedRow.Cells[4].Text;

                    txtAddressDueToMovement.Text = dgvOfficialMovementApplication.SelectedRow.Cells[6].Text;
                    CheckDistrictDropdoownVisibility();
                }
                else
                {
                    RefreshPage();
                }
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to visible country dropdownlist
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   

            CheckDistrictDropdoownVisibility();
        }
        #endregion
        #region Load and pageRefresh method

        private void LoadPersonalInfromation(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   employeeID
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {

                    DataTable oDT_EmpInfo = new DataTable();
                    oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(null, empCode);
                    if (oDT_EmpInfo.Rows.Count > 0)
                    {
                        txtName.Text = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                        txtUnit.Text = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                        txtDepartment.Text = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
                        txtJobStatus.Text = oDT_EmpInfo.Rows[0]["strJobType"].ToString();
                    }
                }
            }
            catch
            {

            }
        }
        private void CheckDistrictDropdoownVisibility()
        {
            //Summary    :   This function will use to visible country dropdownlist
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   

            try
            {
                //string dropdownListValues = ddlCountry.SelectedValue.ToString();
                //string[] countryCode = Regex.Split(dropdownListValues, "#");
                //if (countryCode[0].ToString() == "BD")
                if (ddlCountry.SelectedValue.ToString() == "BD")
                {
                    trDistrict.Visible = true;
                }
                else
                {
                    trDistrict.Visible = false;
                }
            }
            catch { }
        }
        private void RefreshPage()
        {
            //Summary    :   This function will use to refresh official movement application data
            //Created    :   Md. Yeasir Arafat / May-02-2012
            //Modified   :   
            //Parameters :   

            ddlCountry.SelectedValue = "BD";
            ddlCountry.DataBind();
            ddlDistrict.DataBind();
            ddlTypesOfActivities.DataBind();
            dgvOfficialMovementApplication.DataBind();
            txtAddressDueToMovement.Text = "";
            txtDescription.Text = "";
            txtFromDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = DateTime.Now.ToShortDateString();
            CheckDistrictDropdoownVisibility();

            //txtName.Text = "";
            //txtUnit.Text = "";
            //txtJobStatus.Text = "";
            //txtDesignation.Text = "";
        }
        #endregion

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearchByName.Text))
            {
                string strSearchKey = txtSearchByName.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdfEmpCode.Value = searchKey[1];
                LoadPersonalInfromation(searchKey[1]);
                dgvOfficialMovementApplication.DataBind();
            }
            else
            {
                RefreshPage();
            }
        }

    }
}
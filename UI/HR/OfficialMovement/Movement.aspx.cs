using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using HR_BLL.OfficialMovement;
using UI.ClassFiles;

namespace UI.HR.OfficialMovement
{
    public partial class Movement : BasePage
    {
        #region Declare variable
        HR_BLL.OfficialMovement.OfficialMovement objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();

        #endregion
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {

            hdnUserID.Value = "" + Session[SessionParams.USER_ID]; //"1056";
            if (!IsPostBack)
            {
                txtAddressDueToMovement.Attributes.Add("onkeyUp", "SearchAddressByGoogle();");

                txtFromDate.Attributes.Add("onblur", "CheckFromDateIsGreatterThanToDate()");
                txtToDate.Attributes.Add("onblur", "CheckFromDateIsGreatterThanToDate()");

                // hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
                ddlCountry.SelectedValue = "BD";//Load Bagladesh as defult countryDropdownList value
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
                ddlCountry.DataBind();
                CheckDistrictDropdoownVisibility();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert official movement application data
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,dateAppliedFromDate,dateAppliedToDate,strReason,strAddress,movementTypeId and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnUserID.Value.ToString()))
                {
                    objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    string insertStatus = objOfficialMovement.SprInsertOfficialMovementApplication(int.Parse(hdnUserID.Value.ToString()), null, int.Parse(ddlTypesOfActivities.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), ddlCountry.SelectedValue.ToString(), txtAddressDueToMovement.Text, int.Parse(ddlDistrict.SelectedValue.ToString()), txtDescription.Text);
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
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID,dateAppliedFromDate,dateAppliedToDate,strReason,strAddress,movementTypeId and accept updateStatus

            try
            {
                if (dgvOfficialMovementApplication.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(hdnUserID.Value.ToString()))
                    {
                        objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                        string updateStatus = objOfficialMovement.SprUdateOfficialMovementApplication(int.Parse(hdnApplicationID.Value.ToString()), int.Parse(hdnUserID.Value.ToString()), null, int.Parse(ddlTypesOfActivities.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), ddlCountry.SelectedValue.ToString(), txtAddressDueToMovement.Text, int.Parse(ddlDistrict.SelectedValue.ToString()), txtDescription.Text);
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
            //Created    :   Md. Yeasir Arafat / FEB-22-2012  
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID and accept deleteStatus

            try
            {
                if (dgvOfficialMovementApplication.Rows.Count > 0)
                {
                    if (bool.Parse(((HiddenField)dgvOfficialMovementApplication.SelectedRow.Cells[7].FindControl("hdnEditable")).Value.ToString()))
                    {

                        if (!String.IsNullOrEmpty(hdnUserID.Value.ToString()))
                        {
                            objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
                            string deleteStatus = objOfficialMovement.SprDeleteOfficialMovementApplication(int.Parse(hdnApplicationID.Value.ToString()), int.Parse(hdnUserID.Value.ToString()), null);
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
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
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
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
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
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
            //Modified   :   
            //Parameters :   

            CheckDistrictDropdoownVisibility();
        }
        #endregion
        #region Internal Method
        private void RefreshPage()
        {
            //Summary    :   This function will use to refresh official movement application data
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
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
        }
        private void CheckDistrictDropdoownVisibility()
        {
            //Summary    :   This function will use to visible country dropdownlist
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
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
        #endregion
    }
}
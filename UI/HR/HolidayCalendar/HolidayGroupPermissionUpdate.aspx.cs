using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;


namespace UI.HR.HolidayCalendar
{
    public partial class HolidayGroupPermissionUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET PRIMARY ATTRIBUTE FOR THE CONTROLS AND LOAD INITIAL VALUES
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   GET USER ID FROM SESSION 


            if (!IsPostBack)
            {
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();

                ddlHoliday.Attributes.Add("OnSelectedIndexChanged", "panSearch.Enabled = false;" + GetPostBackEventReference(ddlHoliday).ToString());
                ddlGroupID.Attributes.Add("OnSelectedIndexChanged", "panSearch.Enabled = false;" + GetPostBackEventReference(ddlGroupID).ToString());
                ddlJobstation.Attributes.Add("OnSelectedIndexChanged", "panSearch.Enabled = false;" + GetPostBackEventReference(ddlJobstation).ToString());
                ddlReligion.Attributes.Add("OnSelectedIndexChanged", "panSearch.Enabled = false;" + GetPostBackEventReference(ddlReligion).ToString());

                chkAllHoliday.Attributes.Add("oncheckedchanged", "panSearch.Enabled = false;" + GetPostBackEventReference(chkAllHoliday).ToString());
                chkAllGroup.Attributes.Add("oncheckedchanged", "panSearch.Enabled = false;" + GetPostBackEventReference(chkAllGroup).ToString());
                chkAllJobsation.Attributes.Add("oncheckedchanged", "panSearch.Enabled = false;" + GetPostBackEventReference(chkAllJobsation).ToString());
                chkAllReligion.Attributes.Add("oncheckedchanged", "panSearch.Enabled = false;" + GetPostBackEventReference(chkAllReligion).ToString());

                hdnHoliday.Value = ddlHoliday.SelectedValue;
                hdnGroupID.Value = ddlGroupID.SelectedValue;
                hdnjobsationId.Value = ddlJobstation.SelectedValue;
                hdnReligionId.Value = ddlReligion.SelectedValue;

                chkAllHoliday.Checked = true;
                chkAllGroup.Checked = true;
                chkAllJobsation.Checked = true;
                chkAllReligion.Checked = true;

                btnBackToSetupPage.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnBackToSetupPage).ToString());
                btnBackToSetupPage.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='RoyalBlue';");
                btnBackToSetupPage.Attributes.Add("onmouseout", "this.style.textDecoration='none';this.style.color='black';");
                btnBackToSetupPage.Style.Add("cursor", "pointer");
            }
        }
        #region Internal Cheking method
        protected void ddlHoliday_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllHoliday.Checked)
            {
                hdnHoliday.Value = "0";
            }
            else
            {
                hdnHoliday.Value = ddlHoliday.SelectedValue;
            }

            dgvHolliday.DataBind();
        }
        protected void ddlGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllGroup.Checked)
            {
                hdnGroupID.Value = "0";
            }
            else
            {
                hdnGroupID.Value = ddlGroupID.SelectedValue;
            }
            dgvHolliday.DataBind();
        }
        protected void ddlJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllJobsation.Checked)
            {
                hdnjobsationId.Value = "0";
            }
            else
            {
                hdnjobsationId.Value = ddlJobstation.SelectedValue;
            }
            dgvHolliday.DataBind();
        }
        protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllReligion.Checked)
            {
                hdnReligionId.Value = "0";
            }
            else
            {
                hdnReligionId.Value = ddlReligion.SelectedValue;
            }
            dgvHolliday.DataBind();
        }

        protected void chkAllHoliday_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllHoliday.Checked)
            {
                hdnHoliday.Value = "0";
            }
            else
            {
                hdnHoliday.Value = ddlHoliday.SelectedValue;
            }
            dgvHolliday.DataBind();
        }
        protected void chkAllGroup_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllGroup.Checked)
            {
                hdnGroupID.Value = "0";
            }
            else
            {
                hdnGroupID.Value = ddlGroupID.SelectedValue;
            }
            dgvHolliday.DataBind();
        }
        protected void chkAllJobsation_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllJobsation.Checked)
            {
                hdnjobsationId.Value = "0";
            }
            else
            {
                hdnjobsationId.Value = ddlJobstation.SelectedValue;
            }
            dgvHolliday.DataBind();
        }
        protected void chkAllReligion_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED FOR SET THE HIDDEN FIELD VALUE DUE TO CHANGE CHECK BOX FOR THE PURPOSE OF LOAD THE GRID
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            if (chkAllReligion.Checked)
            {
                hdnReligionId.Value = "0";
            }
            else
            {
                hdnReligionId.Value = ddlReligion.SelectedValue;
            }
            dgvHolliday.DataBind();
        }

        protected void dgvHolliday_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED TO ENABLE EDIT MODE FOR THE GRIDVIEW 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            dgvHolliday.EditIndex = -1;
            dgvHolliday.DataBind();
        }
        protected void dgvHolliday_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED TO ENABLE EDIT MODE FOR THE GRIDVIEW 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            dgvHolliday.EditIndex = e.NewEditIndex;
            dgvHolliday.DataBind();
        }
        protected void dgvHolliday_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED TO RELOAD THE GRID AFTER EDIT
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            dgvHolliday.EditIndex = -1;
            dgvHolliday.DataBind();
        }
        protected void dgvHolliday_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED TO RELOAD THE GRID AFTER DELETE
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            dgvHolliday.EditIndex = -1;
            dgvHolliday.DataBind();
        }
        protected void btnBackToSetupPage_Click(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION IS USED TO REDIRECT UPDATE PAGE TO THE HOLIDAY SETUP PAGE 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            Response.Redirect("~/HR/HolidayCalendar/HolidayGroupPermissionSetup.aspx");
        }

        protected void dgvHolliday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void dgvHolliday_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / May-14-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvHolliday, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }
        #endregion
    }
}
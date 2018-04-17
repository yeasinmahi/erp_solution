using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.HolidayCalendar;
using UI.ClassFiles;

namespace UI.HR.HolidayCalendar
{
    public partial class HolidaySetupPopup : BasePage
    {
        #region Decalre Object
        HolidaySetup objHolidayCalendar = new HolidaySetup();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnUserId.Value = /*"1056";*/ Session[SessionParams.USER_ID].ToString();
                string srt = "";
                srt = "GotoNextFocus('" + txtDescription.ClientID + "',event);";
                txtHolidayName.Attributes.Add("onkeyPress", srt);

                srt = "GotoNextFocus('" + btnAdd.ClientID + "',event);";
                txtDescription.Attributes.Add("onkeyPress", srt);

                btnAdd.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnAdd).ToString());
                btnEdit.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnEdit).ToString());
                btnDelete.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnDelete).ToString());

                btnBackToSetupPage.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='RoyalBlue';");
                btnBackToSetupPage.Attributes.Add("onmouseout", "this.style.textDecoration='none';this.style.color='black';");
                btnBackToSetupPage.Style.Add("cursor", "pointer");

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert Holiday data
            //Created    :   Md. Yeasir Arafat / May-10-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID, and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnUserId.Value.ToString()))
                {

                    objHolidayCalendar = new HolidaySetup();
                    string insertStatus = objHolidayCalendar.InsertHoliday(int.Parse(hdnUserId.Value), txtHolidayName.Text, txtDescription.Text);
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

        private void RefreshPage()
        {
            txtDescription.Text = "";
            txtHolidayName.Text = "";
            dgvHolliday.DataBind();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Edit Holiday data
            //Created    :   Md. Yeasir Arafat / May-10-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,holidayId,holiday Name,Description and accept updateStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnHolidayId.Value.ToString()))
                {

                    objHolidayCalendar = new HolidaySetup();
                    string updateStatus = objHolidayCalendar.UpdateHoliday(int.Parse(hdnUserId.Value.ToString()), int.Parse(hdnHolidayId.Value.ToString()), txtHolidayName.Text, txtDescription.Text);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + updateStatus + "');", true);
                    RefreshPage();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Holiday Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to delete Holiday data
            //Created    :   Md. Yeasir Arafat / May-10-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,intHolidayId and accept deleteStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnHolidayId.Value.ToString()))
                {

                    objHolidayCalendar = new HolidaySetup();
                    string deleteStatus = objHolidayCalendar.DeleteHoliday(int.Parse(hdnUserId.Value.ToString()), int.Parse(hdnHolidayId.Value.ToString()));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                    RefreshPage();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Holiday Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void dgvHolliday_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
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
        protected void dgvHolliday_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to reload field value by holiday id
            //Created    :   Md. Yeasir Arafat / May-10-2012
            //Modified   :   
            //Parameters :

            try
            {
                if (dgvHolliday.Rows.Count > 0)
                {
                    hdnHolidayId.Value = ((HiddenField)dgvHolliday.SelectedRow.Cells[0].FindControl("hdnHoliday")).Value.ToString();
                    txtHolidayName.Text = ((Label)dgvHolliday.SelectedRow.Cells[0].FindControl("lblHolidayName")).Text;
                    txtDescription.Text = dgvHolliday.SelectedRow.Cells[1].Text;
                }
            }
            catch { }
        }

    }
}
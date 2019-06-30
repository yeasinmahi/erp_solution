using System;
using HR_BLL.Leave;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using System.Data;
using System.Globalization;

namespace UI.HR.Leave
{
    public partial class PLLeaveEntry : BasePage
    {
        #region INIT
        int EmployeeId, LeaveTypeID, AppliedBy;
        string EmployeeCode,  LeaveReason, AddressDuetoLeave, PhoneDuetoLeave, Message;
        DateTime AppliedFrom, AppliedTo, JoiningDate;
        TimeSpan StartTime, EndTime;
        SeriLog log = new SeriLog();
        private readonly PLLeave plLeave = new PLLeave();
        private DataTable dt = new DataTable();
        string location = "HR";
        string start = "starting HR/Leave/PLLeaveEntry.aspx";
        string stop = "stopping HR/Leave/PLLeaveEntry.aspx";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDefaultData();
            }
        }
        #endregion

        #region Event
        protected void btnChangePLDate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string sms = "Change PL Date Button : " + ex.Message.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnSubmitPL_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Button btnSubmitPL = row.FindControl("btnSubmitPL") as Button;
                Label lblEmployeeEnroll = row.FindControl("lblEmployeeEnroll") as Label;
                Label lblEmployeeCode = row.FindControl("lblEmployeeCode") as Label;
                TextBox txtLeaveDate = row.FindControl("txtLeaveDate") as TextBox;
                Label lblJoiningDate = row.FindControl("lblJoiningDate") as Label;

                JoiningDate = DateTime.ParseExact(lblJoiningDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EmployeeId = Convert.ToInt32(lblEmployeeEnroll.Text);
                EmployeeCode = lblEmployeeCode.Text;
                AppliedFrom = DateTime.ParseExact(txtLeaveDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                AppliedTo = plLeave.GetPlToDate(JoiningDate, AppliedFrom);
                LeaveTypeID = 7;
                StartTime = TimeSpan.Parse("00:00:00");
                EndTime = TimeSpan.Parse("00:00:00");
                LeaveReason = "PL";
                AddressDuetoLeave = "PL";
                PhoneDuetoLeave = "PL";
                AppliedBy = Enroll;
                Message = plLeave.PLLeaveApplicationSubmit(EmployeeId, EmployeeCode, LeaveTypeID, AppliedFrom, AppliedTo, StartTime, EndTime, LeaveReason, AddressDuetoLeave, PhoneDuetoLeave, AppliedBy);
                Toaster(Message, Utility.Common.TosterType.Success);
                FillDefaultData();

            }
            catch (Exception ex)
            {
                string sms = "Submit PL Button : " + ex.Message.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }
        protected void dgvPLLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnSubmitPL = e.Row.FindControl("btnSubmitPL") as Button;
                Button btnChangePLDate = e.Row.FindControl("btnChangePLDate") as Button;
                TextBox txtLeaveDate = e.Row.FindControl("txtLeaveDate") as TextBox;
                if (txtLeaveDate.Text != string.Empty)
                {
                    btnSubmitPL.Visible = false;
                    btnChangePLDate.Visible = true;
                }
                else
                {
                    btnSubmitPL.Visible = true;
                    btnChangePLDate.Visible = false;
                }
            }
        }
        protected void btnChangePLDate_Click1(object sender, EventArgs e)
        {
            try
            {
               int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblEmployeeEnroll = row.FindControl("lblEmployeeEnroll") as Label;

                string PLLeaveEmpId = lblEmployeeEnroll.Text;

                Session["PLLeaveEmpId"] = PLLeaveEmpId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + PLLeaveEmpId + "');", true);
            }
            catch (Exception ex)
            {
                string sms = "Change PL Date Button : " + ex.Message.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }
        #endregion

        #region Method
        private void FillDefaultData()
        {
            txtJobStation.Text = JobStationName;
            hfJobStationId.Value = JobStationId.ToString();
            dt = plLeave.GetPLLeaveEnableEmployee(JobStationId);
            if(dt != null && dt.Rows.Count > 0)
            {
                dgvPLLeave.DataSource = dt;
                dgvPLLeave.DataBind();
            }
        }
        #endregion


    }
}
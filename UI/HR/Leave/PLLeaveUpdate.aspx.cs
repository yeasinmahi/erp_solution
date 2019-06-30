using HR_BLL.Leave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Leave
{
    public partial class PLLeaveUpdate : System.Web.UI.Page
    {
        #region INIT
        private int PLEmpEnroll, ActionBy, PLApplicationId, OldDays, NewDays, LeaveTypeId, spWork;
        private DateTime OldFromDate, OldToDate, NewfromDate, NewToDate;
        DataTable dt = new DataTable();
        private string dfile, xmlData;
        private readonly PLLeave pLLeave = new PLLeave();
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                PLEmpEnroll = int.Parse(Request.QueryString["PLLeaveEmpID"].ToString());
                hfEnroll.Value = PLEmpEnroll.ToString();
                FillData(PLEmpEnroll);
                
            }
        }
        #endregion

        #region Event
        protected void btnChangePLLeave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation() == true)
                {
                    bool result = ChangePLDate();
                    if (result)
                    {
                        Clear();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PL Leave Date Update Successfully.');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PL Leave Date Update Failed.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string sms = "Change PLLeave Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Method
        private void FillData(int Enroll)
        {
            dt = pLLeave.GetPLLeaveDataForDateChange(Enroll);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtOldPLFromDate.Text = dt.Rows[0]["ApprovedFromDate"].ToString();
                txtOldPLToDate.Text = dt.Rows[0]["ApprovedToDate"].ToString();
                hfApplicationId.Value = dt.Rows[0]["ApplicationID"].ToString();
                txtApplicationId.Text = dt.Rows[0]["ApplicationID"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This PL Leave Date Change is not Possible. Please Contact Support!');", true);
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txtNewFromDate.Text))
            {
                txtNewFromDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter New From Date!');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtNewToDate.Text))
            {
                txtNewToDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter New To Date!');", true);
                return false;
            }

            return true;
        }
        private bool ChangePLDate()
        {
            OldFromDate = DateTime.ParseExact(txtOldPLFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            OldToDate = DateTime.ParseExact(txtOldPLToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan span = OldToDate.Subtract(OldFromDate);
            OldDays = (int)span.TotalDays;
            NewfromDate = DateTime.ParseExact(txtNewFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            NewToDate = DateTime.ParseExact(txtNewToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan span2 = NewToDate.Subtract(NewfromDate);
            NewDays = (int)span2.TotalDays;
            PLEmpEnroll = int.Parse(hfEnroll.Value);
            PLApplicationId = int.Parse(txtApplicationId.Text);
            ActionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LeaveTypeId = 7;
            spWork = 1;

            //bool result = pLLeave.PLLeaveDateUpdate(OldFromDate, OldToDate, NewfromDate, NewToDate, PLEmpEnroll, PLApplicationId, ActionBy, LeaveTypeId, OldDays, NewDays, spWork);
            bool result = true;
            return result;
        }
        private void Clear()
        {
            txtNewFromDate.Text = string.Empty;
            txtNewToDate.Text = string.Empty;

        }
        #endregion



    }
}
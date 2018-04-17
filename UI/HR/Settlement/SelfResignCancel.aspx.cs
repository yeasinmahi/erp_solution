using HR_BLL.Settlement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Settlement
{
    public partial class SelfResignCancel : BasePage
    {
        SelfClass obj = new SelfClass();
        DataTable dt;

        int intEnroll; int intApproveBy; int intPart; decimal monAmount; string strRemarks; string strEmailAdd; string strCurrentAddress;
        DateTime dteSeparateDateTime; DateTime dteLastOfficeDate; DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason; int intSeparateInsertBy; int intSeparateType;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) { pnlUpperControl.DataBind();}
                intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                dt = new DataTable();
                dt = obj.GetSelfResignCancelData(intEnroll);

                txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
                txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
            }
            catch { }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = new DataTable();
            dt = obj.CheckSelfResignWithdraw(intEnroll);
            int intCheckID = int.Parse(dt.Rows[0]["intCheck"].ToString());

            if (intCheckID == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please do not try again.');", true);
            }
            else
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 2;
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    obj.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);

                    txtSupervisorName.Text = "";
                    txtSupervisorDesignation.Text = "";
                    txtEmpCode.Text = "";
                    txtEmpEnroll.Text = "";
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    txtDept.Text = "";
                    txtJobType.Text = "";
                    txtBasic.Text = "";
                    txtGross.Text = "";
                    txtJoiningDate.Text = "";
                    txtUnit.Text = "";
                    txtJobStation.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Withdraw Successfully');", true);
                }
            }


        }




    }
}
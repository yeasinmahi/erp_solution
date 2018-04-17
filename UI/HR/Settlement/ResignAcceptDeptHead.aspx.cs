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
    public partial class ResignAcceptDeptHead : BasePage
    {
        HRClass objhr = new HRClass();
        SelfClass objs = new SelfClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        int intSVID; int intEnroll; int intPart; int intApproveBy; decimal monAmount; string strRemarks;
        DateTime dteSeparateDateTime; DateTime dteLastOfficeDate; DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason; int intSeparateInsertBy; int intSeparateType;
        int intUnitID; string strEmailAdd; string strCurrentAddress;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) { pnlUpperControl.DataBind(); hdnconfirm.Value = "0"; }
            else
            {
                if (hdnconfirm.Value == "1") { DeptHeadAccept(); }
                else if (hdnconfirm.Value == "2") { DHReject(); }
            }LoadGrid();

        }

        public string FilterControls(string empcode, string enroll, string empname, string designation, string salary, string resignDate, string lastdate, string lastdateuser, string lastdateAuthority, string separateName, string reason)
        { return "Fillcontrols('" + empcode + "','" + enroll + "','" + empname + "','" + designation + "','" + salary + "','" + resignDate + "','" + lastdate + "','" + lastdateuser + "','" + lastdateAuthority + "','" + separateName + "','" + reason + "')"; }

        private void DeptHeadAccept()
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    dteLastOfficeDateByAuthority = DateTime.Parse(txtLastWorkingDateByAuthority.Text);
                    intEnroll = int.Parse(hdnID.Value);
                    intPart = 3;
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    objs.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
                    LoadGrid();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControls();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Accept Successfully.');", true);
                }
                catch { }

            }
        }
        private void DHReject()
        {
            if (hdnconfirm.Value == "2")
            {
                try
                {
                    intPart = 2;
                    intEnroll = int.Parse(hdnID.Value);
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    objs.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
                    LoadGrid();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControls();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Reject Successfully.');", true);
                }
                catch { }

            }
        }
        private void LoadGrid()
        {
            intSVID = int.Parse(Session[SessionParams.USER_ID].ToString());
            intPart = 1;

            dt = new DataTable();
            dt = obj.GetReportForAllUpdate(intPart, intSVID, intUnitID);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }







    }
}
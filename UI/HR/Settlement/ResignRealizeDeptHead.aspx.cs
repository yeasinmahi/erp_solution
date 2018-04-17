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
    public partial class ResignRealizeDeptHead : BasePage
    {
        HRClass objhr = new HRClass();
        SelfClass objs = new SelfClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        int intSVID; int intEnroll; decimal monAmount; string strRemarks;
        int intPart; int intApproveBy; DateTime dteSeparateDateTime; DateTime dteLastOfficeDate;
        DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason;
        int intSeparateInsertBy; int intSeparateType; int intUnitID; string strEmailAdd; string strCurrentAddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); hdnconfirm.Value = "0"; }
            else
            {
                if (hdnconfirm.Value == "1") { DeptHeadRealize(); }
            } LoadGrid(); 
        }

        private void LoadGrid()
        {
            intSVID = int.Parse(Session[SessionParams.USER_ID].ToString());
            intPart = 2;

            dt = new DataTable();
            dt = obj.GetReportForAllUpdate(intPart, intSVID, intUnitID);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }

        public string FilterControlsRealizeDeptHead(string empcode, string enroll, string empname, string designation, string salary, string resignDate, string lastdate, string lastdateuser, string lastdateAuthority, string separateName, string reason)
        { return "FilterControlsRealizeDeptHead('" + empcode + "','" + enroll + "','" + empname + "','" + designation + "','" + salary + "','" + resignDate + "','" + lastdate + "','" + lastdateuser + "','" + lastdateAuthority + "','" + separateName + "','" + reason + "')"; }

        private void DeptHeadRealize()
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (txtDeductSalary.Text == "")
                    {
                        monAmount = 0;
                    }
                    else
                    {
                        monAmount = decimal.Parse(txtDeductSalary.Text);
                    }

                    intPart = 4;
                    if (ddlRemarks.Text == "1") { strRemarks = "Perfectly handover job responsibility"; }
                    else if (ddlRemarks.Text == "2") { strRemarks = "Handover partial job responsibility"; }
                    else if (ddlRemarks.Text == "3") { strRemarks = "Lackings of Departmental head job handover cannot check properly"; }

                    intEnroll = int.Parse(hdnID.Value);
                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                    objs.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
                    LoadGrid();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControlsRealizeDeptHead();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Realize Successfully.');", true);
                }
                catch { }

            }
        }










    }
}
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
    public partial class AuditRealize : BasePage
    {
        HRClass objhr = new HRClass(); SelfClass objs = new SelfClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        int intSVID; int intEnroll; decimal monAmount; string strRemarks;
        int intPart; int intApproveBy; DateTime dteSeparateDateTime; DateTime dteLastOfficeDate;
        DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason;
        int intSeparateInsertBy; int intSeparateType; int intUnitID; string strEmailAdd; string strCurrentAddress;
        int intSeparationID; string strSeparationID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); LoadGrid();
            }
        }
        protected void Details_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);

            Session["enrollcheck"] = searchKey[0];
            Response.Redirect("AuditRealizeDetails.aspx");

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                intPart = 9;
                intEnroll = int.Parse(searchKey[0]);
                intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                objs.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Audit Realize Successfully.');", true);
                LoadGrid();

            }

        }

        private void LoadGrid()
        {
            intSVID = int.Parse(Session[SessionParams.USER_ID].ToString());
            intPart = 7;

            dt = new DataTable();
            dt = obj.GetReportForAllUpdate(intPart, intSVID, intUnitID);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }


        public string ViewDocList(string Id)
        {
            Session["controlID"] = "Id";
            return "ViewDocList('" + Id + "')";
        }




    }
}
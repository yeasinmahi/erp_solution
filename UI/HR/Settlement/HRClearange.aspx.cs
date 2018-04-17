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
    public partial class HRClearange : BasePage
    {
        HRClass objhr = new HRClass(); SelfClass objs = new SelfClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        int intSVID; int intEnroll; decimal monAmount; string strRemarks;
        int intJobStationID; int intPart; int intUnitID;
        int intApproveBy; DateTime dteSeparateDateTime; DateTime dteLastOfficeDate;
        DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason;
        int intSeparateInsertBy; int intSeparateType; string strEmailAdd; string strCurrentAddress;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {pnlUpperControl.DataBind(); LoadGrid(); }
        }

        protected void Details_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);

            Session["enrollcheck"] = searchKey[0];
            Response.Redirect("HRClearangeDetails.aspx");

        }

        private void LoadGrid()
        {
            intSVID = int.Parse(Session[SessionParams.USER_ID].ToString());
            intPart = 9;

            dt = new DataTable();
            dt = obj.GetReportForAllUpdate(intPart, intSVID, intUnitID);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }


    }
}
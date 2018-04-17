using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Visitors;
using UI.ClassFiles;

namespace UI.HR.Visitors
{
    public partial class VisitorReport : BasePage
    {
        VisitorsBLL objReport = new VisitorsBLL();
        DataTable dt = new DataTable();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objReport.viewjobstation(enroll);
                DdlJobStation.DataSource = dt;
                DdlJobStation.DataTextField = "strJobStationName";
                DdlJobStation.DataValueField = "intEmployeeJobStationId";
                DdlJobStation.DataBind();
                pnlUpperControl.DataBind();
            }
        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtefrom = DateTime.Parse(TxtDteFrom.Text);
                DateTime dteto = DateTime.Parse(TxtDteTo.Text);
                int jobid = int.Parse(DdlJobStation.SelectedValue.ToString());
                dt = objReport.VisitorInformationReport(jobid, dtefrom, dteto);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch { }
        } 
    }
}
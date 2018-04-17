using HR_BLL.Attendance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Attendance
{
    public partial class RealtimeAttendance : BasePage
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <02-09-2013>
        Description: <View Realtime Attendance>
        =============================================*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { pnlUpperControl.DataBind();}
            else
            {         }
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            DataTable dtbl = new DataTable();
            EmployeeAttendance objAttendance = new EmployeeAttendance();
            int unit = int.Parse(ddlUnit.SelectedValue.ToString());
            int station = int.Parse(ddlJobStation.SelectedValue.ToString());
            int shift = int.Parse(ddlPresentShift.SelectedValue.ToString());
            DateTime showdate = DateTime.Parse(txtDate.Text);
            string showtype = ddlType.SelectedValue.ToString();

            //dtbl = objAttendance.GetRealtimeAttendance(unit, station, shift, showdate, showtype);
            //dgvRealtimeSummary.DataSource = dtbl; 
        }


    }
}
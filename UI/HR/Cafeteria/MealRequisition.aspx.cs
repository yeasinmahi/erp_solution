using Dairy_BLL;
using HR_BLL.Cafeteria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Cafeteria
{
    public partial class MealRequisition : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Cafeteria/MealRequisition.aspx";
        string stop = "stopping HR/Cafeteria/MealRequisition.aspx";

        GlobalBLL obj = new GlobalBLL(); DataTable dt; int intEnroll;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Cafeteria/MealRequisition.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                PR.Checked = true; txtSearchEmp.Enabled = false;

                txtSearchEmp.Text = Session[SessionParams.USER_NAME].ToString() + "[" + Session[SessionParams.USER_ID].ToString() + "]";
                txtDesignation.Text = Session[SessionParams.DESIG_NAME].ToString();
                txtDept.Text = Session[SessionParams.DEPT_NAME].ToString();
                txtUnit.Text = Session[SessionParams.UNIT_NAME].ToString();
                txtJobType.Text = Session[SessionParams.JOBTYPE_NAME].ToString();
                txtJobStation.Text = Session[SessionParams.JOBSTATION_NAME].ToString();
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());            
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }

        protected void txtSearchEmp_TextChanged(object sender, EventArgs e) 
        {
            var fd = log.GetFlogDetail(start, location, "txtSearchEmp_TextChanged", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Cafeteria/MealRequisition.aspx txtSearchEmp_TextChanged", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            try
            {
                dt = new DataTable();
                dt = obj.GetEmpInfo(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                    txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                    txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                    txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                }                
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "txtSearchEmp_TextChanged", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "txtSearchEmp_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void PR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PR.Checked = true; PB.Checked = false; txtSearchEmp.Enabled = false;
                txtSearchEmp.Text = Session[SessionParams.USER_NAME].ToString() + "[" + Session[SessionParams.USER_ID].ToString() + "]";
                txtDesignation.Text = Session[SessionParams.DESIG_NAME].ToString();
                txtDept.Text = Session[SessionParams.DEPT_NAME].ToString();
                txtUnit.Text = Session[SessionParams.UNIT_NAME].ToString();
                txtJobType.Text = Session[SessionParams.JOBTYPE_NAME].ToString();
                txtJobStation.Text = Session[SessionParams.JOBSTATION_NAME].ToString();
            }
            catch { }
        }
        protected void PB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PR.Checked = false; PB.Checked = true; txtSearchEmp.Enabled = true;
                txtSearchEmp.Text = "";
                txtDesignation.Text = "";
                txtDept.Text = "";
                txtUnit.Text = "";
                txtJobType.Text = "";
                txtJobStation.Text = "";
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }


























    }
}
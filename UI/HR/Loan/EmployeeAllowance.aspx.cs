using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Loan
{
    public partial class EmployeeAllowance : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Loan/EmployeeAllowance.aspx";
        string stop = "stopping HR/Loan/EmployeeAllowance.aspx";

        HR_BLL.Loan.Loan allowance = new HR_BLL.Loan.Loan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                txtEffectiveDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdnsearch.Value = searchKey[1];
                    FillupControls(hdnsearch.Value);                    
                }
            }
        }

        private void FillupControls(string empcode)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/EmployeeAllowance.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);


            EmployeeRegistration objGetProfile = new EmployeeRegistration();
            DataTable objDT = new DataTable();
            objDT = objGetProfile.GetEmployeeProfileByEmpCode(empcode);
            if (objDT.Rows.Count > 0)
            {
                txtJobtype.Text = objDT.Rows[0]["strJobType"].ToString();
                txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
            }
            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void Action_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Action_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/EmployeeAllowance.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
            
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = senderdata.Split(',');
                hdnallowanceid.Value = searchKey[0].ToString();
                allowance.DeleteAllowance(int.Parse(hdnallowanceid.Value));
                dgvallowance.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Allowance has been successfully deleted.');", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            fd = log.GetFlogDetail(stop, location, "Action_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/EmployeeAllowance.aspx btnSave_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    int allowancetype = int.Parse(ddlAllowance.SelectedValue.ToString());
                    DateTime effectivedate = DateTime.Parse(txtEffectiveDate.Text);
                    decimal amount = decimal.Parse(txtAmount.Text);
                    if ((ddlAllowance.SelectedValue.ToString() == "13") ||
                        (ddlAllowance.SelectedValue.ToString() == "25") ||
                        (ddlAllowance.SelectedValue.ToString() == "26") ||
                        (ddlAllowance.SelectedValue.ToString() == "27") ||
                        (ddlAllowance.SelectedValue.ToString() == "28") ||
                        (ddlAllowance.SelectedValue.ToString() == "29") )
                    { amount = -amount; }
                    int userID = int.Parse(Session[SessionParams.USER_ID].ToString());

                    string msg = allowance.InsertAllowance(hdnsearch.Value, allowancetype, effectivedate, amount, userID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    dgvallowance.DataBind(); txtEffectiveDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtAmount.Text = "0.00";
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }

            fd = log.GetFlogDetail(stop, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }










    }
}
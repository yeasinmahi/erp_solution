using HR_BLL.Facilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Reports
{
    public partial class EmployeeDeduction : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Reports/EmployeeDeduction.aspx";
        string stop = "stopping HR/Reports/EmployeeDeduction.aspx";

        MobileFacilities bllobj = new MobileFacilities(); DataTable dt = new DataTable(); //string innerReportHtml = "";
        //string innerBodyHtml = ""; double pf = 0.00; double lwp = 0.00; double abs = 0.00; double lt = 0.00; 
        //double ln = 0.00; double tx = 0.00; double oth = 0.00;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Reports/EmployeeDeduction.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    dgvdeduction.DataBind();
                    #region --------- Table XML -------------
                    /*
                    string strSearchKey = txtFullName.Text;
                    if (strSearchKey.Length <= 0) { strSearchKey = "NULL,NULL"; }
                    string[] searchKey = Regex.Split(strSearchKey, ",");

                    dt = bllobj.GetEmployeeDeduction(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), searchKey[1], int.Parse(hdnenroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            //Code, Name, Gross, Pf, Lwp, Absent_, Late, Loan, Tax, OtherDeduction
                            innerBodyHtml = innerBodyHtml + @"
                            <tr style = 'font:normal 11px verdana;'>
                            <td class='tblrowodd' style = 'text-align:left; width:90px;'>" + dt.Rows[row]["Code"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:left; width:175px;'>" + dt.Rows[row]["Name"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Gross"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Pf"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Lwp"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Absent_"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Late"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Loan"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["Tax"].ToString() + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:80px;'>" + dt.Rows[row]["OtherDeduction"].ToString() + @"</td></tr>";
                            if (dt.Rows[row]["Pf"].ToString().Length > 0)
                                pf = pf + double.Parse(dt.Rows[row]["Pf"].ToString());
                            else pf = pf + 0.00;

                            if (dt.Rows[row]["Lwp"].ToString().Length > 0)
                                lwp = lwp + double.Parse(dt.Rows[row]["Lwp"].ToString());
                            else lwp = lwp + 0.00;

                            if (dt.Rows[row]["Absent_"].ToString().Length > 0)
                                abs = abs + double.Parse(dt.Rows[row]["Absent_"].ToString());
                            else abs = abs + 0.00;

                            if (dt.Rows[row]["Late"].ToString().Length > 0)
                                lt = lt + double.Parse(dt.Rows[row]["Late"].ToString());
                            else lt = lt + 0.00;

                            if (dt.Rows[row]["Loan"].ToString().Length > 0)
                                ln = ln + double.Parse(dt.Rows[row]["Loan"].ToString());
                            else ln = ln + 0.00;

                            if (dt.Rows[row]["Tax"].ToString().Length > 0)
                                tx = tx + double.Parse(dt.Rows[row]["Tax"].ToString());
                            else tx = tx + 0.00;

                            if (dt.Rows[row]["OtherDeduction"].ToString().Length > 0)
                                oth = oth + double.Parse(dt.Rows[row]["OtherDeduction"].ToString());
                            else oth = oth + 0.00;
                        }

                    //Code, Name, Gross, Pf, Lwp, Absent_, Late, Loan, Tax, OtherDeduction                            
                    innerReportHtml = @"<table style='text-align:center; width:100%; font:bold 11px verdana;'> 
                    <tr><td colspan='10' style='font-size:12px; background-color:#fae9e9'>" +
                    HttpContext.Current.Session[SessionParams.UNIT_NAME].ToString() + @"<br /> Employee Deduction Information <br /></td></tr>            
                    <tr class='tblroweven'><td>Code</td><td>Name</td><td>Gross</td>
                    <td>PF</td><td>LWP</td><td>Absent</td><td>Late</td><td>Loan</td><td>Tax</td><td>Others</td></tr>
                    <tr><td colspan='10'>"; innerReportHtml = innerReportHtml + innerBodyHtml + @"</td></tr>
                    <tr class='tblroweven' style = 'text-align:right;font:bold 12px verdana;color:Blue;'><td colspan='3'> Grand Total : </td>
                    <td>" + pf + "</td><td>" + lwp + "</td><td>" + abs + "</td><td>" + lt + "</td><td>" + ln + "</td><td>" + tx + "</td><td>" + oth + @"</td></tr></table>";
                    report.InnerHtml = innerReportHtml;                    
                    }*/
                    #endregion
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
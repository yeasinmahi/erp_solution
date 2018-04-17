using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;
using HR_BLL.Employee;
using System.Data;
using HR_BLL.Reports;
using Microsoft.Reporting.WebForms;
using HR_BLL.Global;
using UI.ClassFiles;


namespace UI.HR.Reports
{
    public partial class PublicSalaryStatementByEmployee : BasePage
    {
        static int intLoginUerId;
        static int intjobStationID;
        SalaryReportInfo objSalaryReportInfo = new SalaryReportInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to get employeeID by userId and than load report
            //Created    :   Md. Yeasir Arafat / Apr-21-2012
            //Modified   :   
            //Parameters :


            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        }
        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetAutoFillEmployeeListBySearchKey(string prefixText, int count)
        //{
        //    //Summary    :   This function will use to get data for auto suggetion searchbox
        //    //Created    :   Md. Yeasir Arafat / Apr-21-2012
        //    //Modified   :   
        //    //Parameters :

        //    return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        //}
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearchByName.Text))
            {
                string strSearchKey = txtSearchByName.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdfEmpCode.Value = searchKey[1];

                ShowReportDetails(hdfEmpCode.Value.ToString());
            }
        }

        private void ShowReportDetails(string strEmployeeCode)
        {
            //Summary    :   This function will use to show report 
            //Created    :   Md. Yeasir Arafat / June-05-2012
            //Modified   :   
            //Parameters 

            objSalaryReportInfo = new SalaryReportInfo();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objSalaryReportInfo.SalaryStatementByEmployeeId(null, strEmployeeCode);//here intUserId will be null because this form will be run by empcode

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/EmployeesSalaryStatement.rdlc");

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsSalaryStatement";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }

    }
}
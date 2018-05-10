using HR_BLL.Global;
using HR_BLL.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Inventory
{
    public partial class OverTimeIndivisualReprts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

            LoadOverTimeReport();
        }

        protected void grdvOverTimeReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOverTimeReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gdvJstopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        private void LoadFieldValue(int enroll)
        {
            try
            {
                if (enroll>0)
                {
                    OverTimeReport or = new OverTimeReport();
                    DataTable dt = new DataTable();
                    dt = or.EmployeeByEndroll(enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblEmployeeName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                        lblUnit.Text = dt.Rows[0]["strUnit"].ToString();
                        lblJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                        
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            txtFullName.AutoPostBack = false;
        }

        protected void txtFullName_TextChanged(object sender, EventArgs e)
        {
            string searchKey = txtFullName.Text;
            int enroll = 0;
            if (!String.IsNullOrWhiteSpace(searchKey)){
                if(Int32.TryParse(searchKey, out enroll))
                {
                    LoadFieldValue(enroll);
                }
            }
        }

        private void LoadOverTimeReport()
        {
            string searchKey = txtFullName.Text;
            DateTime date;
            int enroll = 0;
            if (!String.IsNullOrWhiteSpace(searchKey))
            {
                if (Int32.TryParse(searchKey, out enroll))
                {
                    date = DateTimeConverter.StringToDateTime(txtMonth.Text, "yyyy-MMMM");
                    if(DateTime.TryParse(txtMonth.Text, out date))
                    {
                        OverTimeReport or = new OverTimeReport();
                        DataTable dataTable = or.EmployeeOverTimeByEndroll(enroll, date);
                        grdvOverTimeReports.DataSource = or.EmployeeOverTimeByEndroll(enroll, date);
                        grdvOverTimeReports.DataBind();
                        
                    }
                }
                else
                {
                    // enroll error
                }
            }

                    
        }
    }
}
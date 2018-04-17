using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class OverTimeEntryReprts : BasePage
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

            txtFullName.Attributes.Add("onkeyUp", "SearchText();");
            hdnAction.Value = "0";
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

            Loadgrid();
        }

        private void Loadgrid()
        {
            int jobstationid= int.Parse(drdlArea.SelectedValue.ToString());
            int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
          
            
            if (rptTypeid == 1)               //Over time for individual user
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enrol = int.Parse(code);
                    dt = bll.getRptOverTime(1, enrol, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    gdvJstopsheet.DataSource = null;
                    gdvJstopsheet.DataBind();
                    grdvOverTimeReports.DataSource = dt;
                    grdvOverTimeReports.DataBind();

                 }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


           else if (rptTypeid == 2)               //Over time for Jobstation base top sheet
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    dt = bll.getRptOverTime(2, 0, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvOverTimeReports.DataSource = null;
                    grdvOverTimeReports.DataBind();
                    gdvJstopsheet.DataSource = dt;
                    gdvJstopsheet.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }













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
        protected void grdvOverTimeReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOverTimeReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvOverTimeReports.PageIndex = e.NewPageIndex;
            Loadgrid();
        }

        protected void gdvJstopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvJstopsheet.PageIndex = e.NewPageIndex;
            Loadgrid();
        }
    }
}
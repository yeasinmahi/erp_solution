using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.HR.TourPlan
{
    public partial class ReportsTourPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void loadgrid()
        {
            int areaID;
            try
            {areaID = int.Parse(drdlArea.SelectedValue.ToString());}
            catch { areaID = 0; }
            int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
         
                
                Int32 enroll = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());

           DataTable dt=new DataTable();
                HR_BLL.TourPlan.TourPlanning bll = new TourPlanning();
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    dt = bll.getRptForTourPlan(dteFromDate, dteToDate, unitid, enroll);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    grdvTourPlanReports.DataSource = dt;
                    grdvTourPlanReports.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

        protected void grdvTourPlanReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        
        }

        protected void grdvTourPlanReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        
        }

            

                


            }




         

            }





        
    

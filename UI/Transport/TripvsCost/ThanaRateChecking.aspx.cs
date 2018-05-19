using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport.TripvsCost
{
    public partial class ThanaRateChecking : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        LOGIS_BLL.Trip.Trip blltrip = new LOGIS_BLL.Trip.Trip();

        

        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;

        

        decimal totalcom;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //try { File.Delete(xmlpath); } catch { }
                txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int point =int.Parse (ddlShip.SelectedValue.ToString());
                reporttype = int.Parse(ddlReportType.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                if (reporttype == 1 )
                {
                    dt = blltrip.GetThanrate(point, dtFromDate, dtToDate, reporttype);
                    if (dt.Rows.Count > 0)
                    {
                        grdvThanratechecking.DataSource = dt;
                        grdvThanratechecking.DataBind();
                     
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

              

            }
            catch { }
        }
        //
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void drdlUnitName_DataBound(object sender, EventArgs e)
        {
            ddlShip.DataBind();
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
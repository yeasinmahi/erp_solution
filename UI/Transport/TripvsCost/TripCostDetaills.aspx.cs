using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Transport.TripvsCost
{
    public partial class TripCostDetaills : System.Web.UI.Page
    {
        DataTable dt = new DataTable();

        LOGIS_BLL.Trip.Trip blltrip = new LOGIS_BLL.Trip.Trip();
        string strDate; string strTodate; string name1; string untid; string ReportType, salofice;
        int rptyp,intunit;
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        protected void grdvTripvsChallanDetindividually_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strDate = Session["Date"].ToString();
                DateTime dtfrom = Convert.ToDateTime(strDate);
                strTodate = Session["DateTodate"].ToString();
                DateTime dtTo = Convert.ToDateTime(strTodate);
                name1 = Session["name1"].ToString();
                ReportType = Session["REPORTTYPE"].ToString();
                if (!IsPostBack)
                {
                    try { loadgrid(); }
                    catch { }}
            }
            catch { }
            }

        private void loadgrid()
        {
            try
            {
                ReportType = Session["REPORTTYPE"].ToString();
                strDate = Session["Date"].ToString();
                DateTime dtfrom = Convert.ToDateTime(strDate);
                strTodate = Session["DateTodate"].ToString();
                DateTime dtTo = Convert.ToDateTime(strTodate);
                name1 = Session["name1"].ToString();
                salofice= Session["salesoffice"].ToString();
                untid=Session["unitid"].ToString();
                intunit = int.Parse(untid);
                rptyp = int.Parse(ReportType);
                if (rptyp == 1|| rptyp == 2)
                {
                   
                    dt = blltrip.GetTripvsChallanDet(dtfrom, dtTo, salofice, intunit, rptyp, name1, "");
                    if (dt.Rows.Count > 0)
                    {
                        grdvTripvsChallanDetindividually.DataSource = dt;
                        grdvTripvsChallanDetindividually.DataBind();
                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

            }

            catch
            {
            }


        }

    }
}
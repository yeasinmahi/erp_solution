using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class FactoryAndGhatDelv : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, totalday, runningday; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        SalesOrder bll = new SalesOrder();



        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;
        decimal totalcom, selectedtotalcom = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                    txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                    //pnlUpperControl.DataBind();
                    hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    hdnemail.Value = HttpContext.Current.Session[SessionParams.EMAIL].ToString();

                }
                catch { }
            }
        }

        

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //try
            //{
            ////
            email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            int rpt= int.Parse(ddlReportType.SelectedValue.ToString());
            if (rpt == 1)
            {
                dt = bll.GetFactoryAndGhatDelv(dtFromDate, dtToDate);




                if (dt.Rows.Count > 0)
                {
                    grdvFactoryAndGhatDelv.DataSource = dt;
                    grdvFactoryAndGhatDelv.DataBind();
                    decimal factdelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("factory"));
                    decimal ghatdel = dt.AsEnumerable().Sum(row => row.Field<decimal>("ghat"));
                    decimal totaldelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));

                    grdvFactoryAndGhatDelv.FooterRow.Cells[1].Text = "total";
                    grdvFactoryAndGhatDelv.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    grdvFactoryAndGhatDelv.FooterRow.Cells[3].Text = factdelv.ToString("N2");
                    grdvFactoryAndGhatDelv.FooterRow.Cells[4].Text = ghatdel.ToString("N2");
                    grdvFactoryAndGhatDelv.FooterRow.Cells[5].Text = totaldelv.ToString("N2");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

            if (rpt == 2)
            {
                dt = bll.GetdataSalesINMT(dtFromDate);




                if (dt.Rows.Count > 0)
                {
                    grdvFactoryAndGhatDelv.DataSource = null;
                    grdvFactoryAndGhatDelv.DataBind();

                    grdvSalesinMT.DataSource = dt;
                    grdvSalesinMT.DataBind();
                    //decimal factdelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("factory"));
                    //decimal ghatdel = dt.AsEnumerable().Sum(row => row.Field<decimal>("ghat"));
                    //decimal totaldelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));

                    //grdvFactoryAndGhatDelv.FooterRow.Cells[1].Text = "total";
                    //grdvFactoryAndGhatDelv.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    //grdvFactoryAndGhatDelv.FooterRow.Cells[3].Text = factdelv.ToString("N2");
                    //grdvFactoryAndGhatDelv.FooterRow.Cells[4].Text = ghatdel.ToString("N2");
                    //grdvFactoryAndGhatDelv.FooterRow.Cells[5].Text = totaldelv.ToString("N2");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }



            //}
            //catch { }
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
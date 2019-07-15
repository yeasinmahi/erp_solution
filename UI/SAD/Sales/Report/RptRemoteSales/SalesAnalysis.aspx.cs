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
    public partial class SalesAnalysis : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, totalday,runningday; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
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
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

            try
            {
                grdvsalestrend.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("TADApay.xls", grdvsalestrend);
            }
            catch { }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            //try
            //{
                ////
                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtFromDate1 = dtFromDate.AddHours(06);


                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                DateTime dtToDate1 = dtToDate.AddHours(5).AddMinutes(59).AddSeconds(59).AddMilliseconds(997);

                DateTime fromdatemonthsales = new DateTime(dtFromDate1.Year, dtFromDate1.Month, 1);
                 DateTime fromdatemonthsales1 = fromdatemonthsales.AddHours(06);
                 DateTime todatemonthsales = dtToDate1;
          
                var month = new DateTime(dtFromDate.Year, dtFromDate.Month, 1);
                var first = month.AddMonths(-1);
                DateTime FromDateLastMonthSale = first.AddHours(06);
                var last = month.AddDays(+0);
                DateTime ToDateLastMonthSale= last.AddHours(5).AddMinutes(59).AddSeconds(59).AddMilliseconds(997);

              


            unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                totalday = int.Parse(txttotaltday.Text.ToString());
                runningday= int.Parse(txtRunningDay.Text.ToString());
                dt = bll.Getsalestrendinfo(unitid, fromdatemonthsales1, todatemonthsales, dtFromDate1, dtToDate1, FromDateLastMonthSale, ToDateLastMonthSale, totalday,runningday);
                if (dt.Rows.Count > 0)
                {
                    grdvsalestrend.DataSource = dt;
                    grdvsalestrend.DataBind();

                //decimal opc1day = dt.AsEnumerable().Sum(row => row.Field<decimal>("OPCQ1Day"));
                //grdvsalestrend.FooterRow.Cells[2].Text = "Total";
                //grdvsalestrend.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //grdvsalestrend.FooterRow.Cells[6].Text = opc1day.ToString("N2");

                //decimal pcc1day = dt.AsEnumerable().Sum(row => row.Field<decimal>("PCCQ1Day"));
                //grdvsalestrend.FooterRow.Cells[7].Text = pcc1day.ToString("N2");

                //decimal opcpcc1day = dt.AsEnumerable().Sum(row => row.Field<decimal>("PCCOPCQ1Day"));
                //grdvsalestrend.FooterRow.Cells[8].Text = opcpcc1day.ToString("N2");

                //decimal opc1month = dt.AsEnumerable().Sum(row => row.Field<decimal>("OPC1Month"));
                //grdvsalestrend.FooterRow.Cells[9].Text = opc1month.ToString("N2");

                //decimal pcc1month = dt.AsEnumerable().Sum(row => row.Field<decimal>("PCC1Month"));
                //grdvsalestrend.FooterRow.Cells[10].Text = pcc1month.ToString("N2");

                //decimal opcpcc1month = dt.AsEnumerable().Sum(row => row.Field<decimal>("total1Month"));
                //grdvsalestrend.FooterRow.Cells[11].Text = opcpcc1month.ToString("N2");


                //decimal target = dt.AsEnumerable().Sum(row => row.Field<decimal>("targ"));
                //grdvsalestrend.FooterRow.Cells[12].Text = target.ToString("N2");


                //decimal lastmonth = dt.AsEnumerable().Sum(row => row.Field<decimal>("SalesLastMonth"));
                //grdvsalestrend.FooterRow.Cells[17].Text = lastmonth.ToString("N2");


              

            }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            //}
            //catch { }


        }


    }
}
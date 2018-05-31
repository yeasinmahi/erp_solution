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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ////
                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                totalday = int.Parse(txttotaltday.Text.ToString());
                runningday= int.Parse(txtRunningDay.Text.ToString());
                dt = bll.Getsalestrendinfo(unitid,dtFromDate, dtToDate, dtFromDate, dtToDate, dtFromDate, dtToDate,totalday,runningday);
                if (dt.Rows.Count > 0)
                {
                    grdvsalestrend.DataSource = dt;
                    grdvsalestrend.DataBind();
                    //decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCashCommission1"));
                    //decimal totaldelvqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decTotalDelv1"));
                    //decimal totalcashdoqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decOnlyCashDOQnt1"));
                    //lblTotalcom.Visible = true;
                    //lbltotalcomamount.Text = Convert.ToString(txtTotalCommission);
                    //lblTotalcashdoqnt.Visible = true;
                    //lblcashdoqnt.Text = Convert.ToString(totalcashdoqnt);


                    ////txtTotalCommission = 

                    //grdvCashDOCommission.FooterRow.Cells[1].Text = "total";
                    //grdvCashDOCommission.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    //grdvCashDOCommission.FooterRow.Cells[5].Text = txtTotalCommission.ToString("N2");
                    //grdvCashDOCommission.FooterRow.Cells[4].Text = totaldelvqnt.ToString("N2");


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }


        }


    }
}
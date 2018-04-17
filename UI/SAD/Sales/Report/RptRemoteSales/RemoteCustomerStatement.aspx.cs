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
    public partial class RemoteCustomerStatement : BasePage
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind(); 
                txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            }
            else
            {
                // SetReport();
            }



        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        

        private void ShowReportDetails()
        {


            DataTable oDTReportData = new DataTable();
            
            SAD_BLL.Customer.Report.StatementC st = new SAD_BLL.Customer.Report.StatementC();
            try
            {

                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                string strSearchKey = txtFullName.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();



                string strCustname = strSearchKey;
                int intCOAid = int.Parse(code);

         
                oDTReportData = st.bllRemoteCustomerStatement(dtFromDate, dtToDate, intCOAid);

            }
            catch
            {

            }





            if (oDTReportData.Rows.Count > 0)
            {
                GridView1.DataSource = oDTReportData;
                GridView1.DataBind();
            }


            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowReportDetails();
        }

      

        protected void btnCustomerStatementRepot_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("Statement.xls", GridView1);
            }
            catch { }
        }
    }
}
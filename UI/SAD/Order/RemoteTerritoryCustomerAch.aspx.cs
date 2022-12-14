using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTerritoryCustomerAch : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTerritoryCustomerAch";
        string stop = "stopping SAD\\Order\\RemoteTerritoryCustomerAch";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }
        public void LoadData()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTerritoryCustomerAch Territory Customer Accievement Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DataTable oDTReportData = new DataTable();
                StatementC st = new StatementC();
                DateTime dteFromDate = DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                DateTime dteTodate = DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;
                String strEamilTSO = Session[SessionParams.EMAIL].ToString();
                oDTReportData = st.GetTerritoryCustomerAchbll(dteFromDate, dteTodate, strEamilTSO);
                GridView1.DataSource = oDTReportData;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // Check if row is data row, not header, footer etc.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValue = Convert.ToDecimal(e.Row.Cells[7].Text);


                if (CellValue > 79)
                {

                    e.Row.BackColor = System.Drawing.Color.Green;


                }
                else if (CellValue > 59)
                {


                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else
                    e.Row.BackColor = System.Drawing.Color.Red;


            }



        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
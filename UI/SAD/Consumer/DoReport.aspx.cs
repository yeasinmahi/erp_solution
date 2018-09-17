using System;
using System.Data;
using System.Web.UI;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class DoReport : System.Web.UI.Page
    {
        readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Consumer\\DoReport";
        string stop = "stopping SAD\\Consumer\\DoReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadSalesOffice();
            }
        }

        private void LoadGridView(DataTable source)
        {
            grdvDo.DataSource = source;
            grdvDo.DataBind();

        }

        protected void ddlReportType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string reportType = ddlReportType.SelectedItem.Value;
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
                DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
                string doNumber = doNumberTextBox.Text;
                int salesOfficeId = Convert.ToInt32(ddlsalesOffice.SelectedItem.Value);

                DataTable source = new DataTable();
                switch (reportType)
                {
                    case "TopShet":
                        source = _bll.GetDoTopSheet(fromDateTime, toDateTime);
                        break;
                    case "Specific":
                        source = _bll.GetDoByDoNumber(doNumber);
                        break;
                    case "SalesOffice":
                        source = _bll.GetDoBySalesId(salesOfficeId, fromDateTime, toDateTime);
                        break;
                }
                LoadGridView(source);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Check Input Properly." + exception.Message + "');", true);
            }
            
        }

        protected void LoadSalesOffice()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\DoReport Office Load", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                ddlsalesOffice.DataSource = _bll.GetSalesOffice();
            ddlsalesOffice.DataValueField = "intId";
            ddlsalesOffice.DataTextField = "strName";
            ddlsalesOffice.DataBind();
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

        protected void ddlsalesOffice_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
                DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
                int salesOfficeId = Convert.ToInt32(ddlsalesOffice.SelectedItem.Value);

                LoadGridView(_bll.GetDoBySalesId(salesOfficeId, fromDateTime, toDateTime));
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Check Input Properly."+exception.Message+"');", true);
            }
            
        }
    }
}
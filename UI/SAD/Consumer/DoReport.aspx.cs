using System;
using System.Data;
using System.Web.UI;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class DoReport : System.Web.UI.Page
    {
        readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
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
            ddlsalesOffice.DataSource = _bll.GetSalesOffice();
            ddlsalesOffice.DataValueField = "intId";
            ddlsalesOffice.DataTextField = "strName";
            ddlsalesOffice.DataBind();

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
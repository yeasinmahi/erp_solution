using System;
using System.Data;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class StarConsumeReport : System.Web.UI.Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string fromDate = Request.QueryString["fromDate"];
            string toDate = Request.QueryString["toDate"];
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-1);

            DataTable dataTable = _starConsumerEntryBll.GetStarConsumeReport(fromDateTime, toDateTime, email);
            grdvDoubleCashOfferReport.DataSource = dataTable;
            grdvDoubleCashOfferReport.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Consumer;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class TargetAcvReport : System.Web.UI.Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        string _filePathForXml = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "StarConsumerBill.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);

            DataTable dataTable = _starConsumerEntryBll.GetDistributorAndIhbSales(fromDateTime, toDateTime);
            grdv.DataSource = dataTable;
            grdv.DataBind();
        }
        
    }
}
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Consumer;
using UI.ClassFiles;
using Utility;

namespace UI.Transport.TripvsCost
{
    public partial class PumpFoodingBillReport : System.Web.UI.Page
    {
        StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUi();
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void showReport_OnClick(object sender, EventArgs e)
        {
            LoadGridView();
        }
        protected void inActive_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int intId = Convert.ToInt32(((HiddenField)gvr.FindControl("intID")).Value);
            DataTable dataTable = _bll.FoodBiilingInfo(3, 0, "", DateTime.Now, DateTime.Now, 0, intId);
            string message = dataTable.Rows[0]["Messages"].ToString();
            LoadGridView();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ message + "');", true);
        }
        private void LoadGridView()
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;

            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            //fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            //toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            int insertBy = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int unitId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            int reportType = Convert.ToInt32(ddlReportType.SelectedItem.Value);
            int enroll = 0;
            if (!String.IsNullOrWhiteSpace(enrollTxt.Text))
            {
                enroll = Convert.ToInt32(enrollTxt.Text);
            }

            DataTable dataTable = _bll.FoodBiilingInfo(reportType, insertBy, "",fromDateTime, toDateTime,unitId, enroll);
            if (reportType.Equals(1))
            {
                grdvTopSheet.DataSource = dataTable;
                grdvTopSheet.DataBind();

                grdvDetails.Visible = false;
                grdvTopSheet.Visible = true;
            }
            else if(reportType.Equals(2))
            {
                grdvDetails.DataSource = dataTable;
                grdvDetails.DataBind();

                grdvTopSheet.Visible = false;
                grdvDetails.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select report type properly');", true);
            }
           
        }

        private void LoadUi()
        {
            string reportType = ddlReportType.SelectedItem.Value;
            if (reportType.Equals("1"))
            {
                enrollTr.Visible = false;
            }
            else if (reportType.Equals("2"))
            {
                enrollTr.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select report type properly');", true);
            }
        }

        protected void ddlReportType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUi();
        }
    }
}
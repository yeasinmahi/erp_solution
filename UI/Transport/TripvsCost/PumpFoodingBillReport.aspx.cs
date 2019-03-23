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
    public partial class PumpFoodingBillReport : BasePage
    {
        StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        int enroll;
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
            if (string.IsNullOrWhiteSpace(fromDate))
            {
                Toaster("Please Input From Date", Common.TosterType.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(toDate))
            {
                Toaster("Please Input To Date", Common.TosterType.Warning);
                return;
            }
            DateTime fromDateTime = fromDate.ToDateTime("MM/dd/yyyy");
            //fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = toDate.ToDateTime("MM/dd/yyyy");
            //toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            int unitId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            int reportType = Convert.ToInt32(ddlReportType.SelectedItem.Value);
            int shippoint = int.Parse (ddlShip.SelectedValue.ToString());
            if (!string.IsNullOrWhiteSpace(enrollTxt.Text))
            {
                enroll = Convert.ToInt32(enrollTxt.Text);
            }

           
            if (reportType.Equals(1))
            {
                DataTable dataTable = _bll.FoodBiilingInfo(reportType, shippoint, "", fromDateTime, toDateTime, unitId, enroll);
                grdvTopSheet.Loads(dataTable);

                grdvsummery.Visible = false;
                grdvDetails.Visible = false;
                grdvTopSheet.Visible = true;
            }
            else if(reportType.Equals(2))
            {
                DataTable dataTable = _bll.FoodBiilingInfo(reportType, shippoint, "", fromDateTime, toDateTime, unitId, enroll);
                grdvDetails.Loads(dataTable);

                grdvsummery.Visible = false;
                grdvTopSheet.Visible = false;
                grdvDetails.Visible = true;
            }

            else if (reportType.Equals(4))
            {
                DataTable dataTable = _bll.FoodBiilingInfo(reportType, 0, "", fromDateTime, toDateTime, unitId, enroll);
                grdvsummery.Loads(dataTable);
             
                grdvTopSheet.Visible = false;
                grdvDetails.Visible = false;
                grdvsummery.Visible = true;

                //grdvsummery.FooterRow.Cells[3].Text = "total";
                //grdvsummery.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //decimal totalhour = dt.AsEnumerable().Sum(row => row.Field<decimal>("moncommission"));
                //decimal totalbill = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCollection"));
                //grdvsummery.FooterRow.Cells[4].Text = totalcollection.ToString("N2");
                //grdvsummery.FooterRow.Cells[5].Text = txtTotalCommission.ToString("N2");


            }
            else
            {
                Alert("Select report type properly");
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
          else  if (reportType.Equals("4"))
            {
                enrollTr.Visible = false;
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

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }
    }
}
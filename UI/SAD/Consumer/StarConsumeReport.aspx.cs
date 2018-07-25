using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class StarConsumeReport : System.Web.UI.Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void entry_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("StarConsumerEntry.aspx");
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            //string email = Request.QueryString["email"];
            //string fromDate = Request.QueryString["fromDate"];
            //string toDate = Request.QueryString["toDate"];
            string email = "ahmed.accl@akij.net";
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;

            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);

            DataTable dataTable = _starConsumerEntryBll.GetStarConsumeReport(fromDateTime, toDateTime, email);
            grdvDoubleCashOfferReport.DataSource = dataTable;
            grdvDoubleCashOfferReport.DataBind();
        }

        protected void update_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int intID = Convert.ToInt32(((HiddenField)gvr.FindControl("intID")).Value);
            int intSiteCardCode = Convert.ToInt32(((TextBox)gvr.FindControl("intSiteCardCode")).Text);
            decimal decQntForSiteCard = Convert.ToDecimal(((TextBox)gvr.FindControl("decQntForSiteCard")).Text);
            decimal decShopvsDelvQnt = Convert.ToDecimal(((TextBox)gvr.FindControl("decShopvsDelvQnt")).Text);
            decimal monEditedTotalCost = Convert.ToDecimal(((TextBox)gvr.FindControl("monEditedTotalCost")).Text);
            try
            {
                _starConsumerEntryBll.UpdateConsumerBill(intSiteCardCode, decQntForSiteCard, decShopvsDelvQnt, monEditedTotalCost, intID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successful');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update failed '"+ exception.Message + ");", true);
            }
            LoadGridView();

        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int intID = Convert.ToInt32(((HiddenField)gvr.FindControl("intID")).Value);

            _starConsumerEntryBll.DeactiveConsumerDoubleCashOffer(intID);
            LoadGridView();
        }
    }
}
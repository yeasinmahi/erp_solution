using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Consumer;
using UI.ClassFiles;
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
            
            string email = (HttpContext.Current.Session[SessionParams.EMAIL].ToString());
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;

            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            int rpttype = int.Parse(drdlRptchtype.SelectedValue.ToString());
            if (rpttype == 1)
            {
                DataTable dataTable = _starConsumerEntryBll.GetStarConsumeReport(fromDateTime, toDateTime, email);
                grdvDoubleCashOfferReport.DataSource = null;
                grdvDoubleCashOfferReport.DataBind();
                grdvupdateorDelete.DataSource = dataTable;
                grdvupdateorDelete.DataBind();
                
            }

            else if (rpttype == 2  || rpttype == 3)
            {
                DataTable dataTable = _starConsumerEntryBll.GetStarConsumeReport(fromDateTime, toDateTime, email);
                grdvupdateorDelete.DataSource = null;
                grdvupdateorDelete.DataBind();
                grdvDoubleCashOfferReport.DataSource = dataTable;
                grdvDoubleCashOfferReport.DataBind();
                
               
            }
            else { }

           
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
            
            DateTime dtins=Convert.ToDateTime(((HiddenField)gvr.FindControl("dteInsertionDate")).Value);
            DateTime allowdate = dtins.AddDays(3);
            DateTime chkdate = DateTime.Now;
            if (chkdate < allowdate)
            {
                try
                {
                    _starConsumerEntryBll.UpdateConsumerBill(intSiteCardCode, decQntForSiteCard, decShopvsDelvQnt, monEditedTotalCost, intID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successful');", true);
                }
                catch (Exception exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update failed '" + exception.Message + ");", true);
                }
                LoadGridView();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Date exceed for correction. You are allow for modification only for 72 hours form bill submit');", true); }

        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int intID = Convert.ToInt32(((HiddenField)gvr.FindControl("intID")).Value);
            DateTime dtins = Convert.ToDateTime(((HiddenField)gvr.FindControl("dteInsertionDate")).Value);
            DateTime allowdate = dtins.AddDays(3);
            DateTime chkdate = DateTime.Now;
            if (chkdate < allowdate)
            {
                _starConsumerEntryBll.DeactiveConsumerDoubleCashOffer(intID);
                LoadGridView();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Date exceed for correction. You are allow for modification only for 72 hours form bill submit time');", true); }

        }
    }
}
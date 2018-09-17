using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Consumer;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class StarConsumerEntry : Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        string _filePathForXml = String.Empty;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Consumer\\StarConsumerEntry";
        string stop = "stopping SAD\\Consumer\\StarConsumerEntry";
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "StarConsumerBill.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadTeritoryDropDown();
                LoadProgramDropDown();
            }
            XmlParser.DeleteFile(_filePathForXml);
        }
        private void LoadTeritoryDropDown()
        {
            DataTable dataTable =  _starConsumerEntryBll.GetTeritory("ahmed.accl@akij.net");
            ddlTeritory.DataSource = dataTable;
            ddlTeritory.DataValueField = "intID";
            ddlTeritory.DataTextField = "strText";
            ddlTeritory.DataBind();
        }
        private void LoadProgramDropDown()
        {
            DataTable dataTable = _starConsumerEntryBll.GetProgram();
            ddlProgram.DataSource = dataTable;
            ddlProgram.DataValueField = "intProgramID";
            ddlProgram.DataTextField = "strProgramName";
            ddlProgram.DataBind();
        }

        private void LoadDoubleCashOfferGridView(string teritory, DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = _starConsumerEntryBll.GetDoubleCashOffer(teritory, fromDate, toDate);
            grdvDoubleCashOffer.DataSource = dataTable;
            grdvDoubleCashOffer.DataBind();
        }
        protected void showReport_OnClick(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\StarConsumerEntry Show Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string teritoryName = ddlTeritory.SelectedItem.Text;
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            //string teritoryName = "Faridpur";
            //string fromDate = "05/01/2018";
            //string toDate = "07/01/2018";
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            
            LoadDoubleCashOfferGridView(teritoryName, fromDateTime, toDateTime);
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


        protected void add_OnClick(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\StarConsumerEntry Consumer Entry ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;


            int shopId = Convert.ToInt32(gvr.Cells[1].Text);
            string territoryName = ((HiddenField)gvr.FindControl("strTerritory")).Value;
            //int customerId = Convert.ToInt32(((Label)gvr.FindControl("dispId")).Value);
            int customerId = Convert.ToInt32(gvr.Cells[4].Text);
            double decShopvsDelvQnt = Convert.ToDouble(gvr.Cells[8].Text);
            double editedTotalCost = Convert.ToDouble(((TextBox)gvr.FindControl("commisionAmount")).Text);
            int siteCardCode = Convert.ToInt32(((TextBox)gvr.FindControl("siteCode")).Text);
            double qntForSiteCard = Convert.ToDouble(((TextBox)gvr.FindControl("quantity")).Text);
            string starUserDetaills = ((TextBox)gvr.FindControl("userDetails")).Text;
            int intProgramType = 6;
            int unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
            int insertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            string message;
            dynamic obj = new
            {
                intShopId = shopId,
                strTerritory = territoryName,
                intCustID = customerId,
                decShopvsDelvQnt = decShopvsDelvQnt,
                monEditedTotalCost = editedTotalCost,
                intSiteCardCode = siteCardCode,
                decQntForSiteCard = qntForSiteCard,
                strUserDetaills = starUserDetaills

            };

            if (XmlParser.CreateXml("StarConsumer", obj, _filePathForXml, out message))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_filePathForXml);
                message = _starConsumerEntryBll.InsertStarConsumerBill(doc.OuterXml, fromDateTime, toDateTime, insertBy, intProgramType, unitId,insertBy);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
            }
            XmlParser.DeleteFile(_filePathForXml);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        
        protected void showFullReport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("StarConsumeReport.aspx");
        }
    }
}
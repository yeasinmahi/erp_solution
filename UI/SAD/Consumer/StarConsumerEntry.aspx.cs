using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SAD_BLL.Consumer;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class StarConsumerEntry : Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        string _filePathForXml = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "StarConsumerBill.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadTeritoryDropDown();
                LoadProgramDropDown();
            }
            _filePathForXml.DeleteFile();
        }
        private void LoadTeritoryDropDown()
        {
            DataTable dataTable =  _starConsumerEntryBll.GetTeritory(HttpContext.Current.Session[SessionParams.EMAIL].ToString());
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
            string teritoryName = ddlTeritory.SelectedItem.Text;
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            //string teritoryName = "Faridpur";
            //string fromDate = "05/01/2018";
            //string toDate = "07/01/2018";
            DateTime fromDateTime = fromDate.ToDateTime("MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = toDate.ToDateTime("MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
            
            LoadDoubleCashOfferGridView(teritoryName, fromDateTime, toDateTime);
        }


        protected void add_OnClick(object sender, EventArgs e)
        {
           
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = fromDate.ToDateTime("MM/dd/yyyy");
                fromDateTime = fromDateTime.AddHours(6);
                DateTime toDateTime = toDate.ToDateTime("MM/dd/yyyy");
                toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
                //Get the button that raised the event
                Button btn = (Button)sender;

                //Get the row that contains this button
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;


            string edtcost = ((TextBox)gvr.FindControl("commisionAmount")).Text;
            string sitcod = ((TextBox)gvr.FindControl("commisionAmount")).Text;
            string starUserDetaills = ((TextBox)gvr.FindControl("userDetails")).Text;
            string edtqnt= ((TextBox)gvr.FindControl("quantity")).Text;

            if (edtcost == "" || sitcod == "" || starUserDetaills == "" || edtqnt=="")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('INPUT ARE NOT PROPERLY');", true);
            }
            else
            {
                int shopId = Convert.ToInt32(gvr.Cells[1].Text);
                string territoryName = ((HiddenField)gvr.FindControl("strTerritory")).Value;
                //int customerId = Convert.ToInt32(((Label)gvr.FindControl("dispId")).Value);
                int customerId = Convert.ToInt32(gvr.Cells[4].Text);
                double decShopvsDelvQnt = Convert.ToDouble(gvr.Cells[8].Text);
                

                double editedTotalCost = Convert.ToDouble(((TextBox)gvr.FindControl("commisionAmount")).Text);
                int siteCardCode = Convert.ToInt32(((TextBox)gvr.FindControl("siteCode")).Text);
                double qntForSiteCard = Convert.ToDouble(((TextBox)gvr.FindControl("quantity")).Text);

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
                    message = _starConsumerEntryBll.InsertStarConsumerBill(doc.OuterXml, fromDateTime, toDateTime, insertBy, intProgramType, unitId, insertBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
                }
                _filePathForXml.DeleteFile();
            }
            }
        

        
        protected void showFullReport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("StarConsumeReport.aspx");
        }
    }
}
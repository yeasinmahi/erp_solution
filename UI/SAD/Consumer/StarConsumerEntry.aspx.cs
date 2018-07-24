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
    public partial class StarConsumerEntry : System.Web.UI.Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        string filePathForXML = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "StarConsumerBill.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadTeritoryDropDown();
                LoadProgramDropDown();
            }
            DeleteFile();
        }

        protected void btnAddBikeCarUser_OnClickAddBikeCarUser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnSubmitBikeCar_OnClickCar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdvOvertimeEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdvOvertimeEntry_OnRowDeletingmeEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
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
            string teritoryName = ddlTeritory.SelectedItem.Text;
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            //string teritoryName = "Faridpur";
            //string fromDate = "05/01/2018";
            //string toDate = "07/01/2018";
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-1);
            
            LoadDoubleCashOfferGridView(teritoryName, fromDateTime, toDateTime);
        }


        protected void add_OnClick(object sender, EventArgs e)
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-1);
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;


            int shopId = Convert.ToInt32(((HiddenField) gvr.FindControl("dispId")).Value);
            string territoryName = ((HiddenField)gvr.FindControl("strTerritory")).Value;
            //int customerId = Convert.ToInt32(((Label)gvr.FindControl("dispId")).Value);
            int customerId = Convert.ToInt32(gvr.Cells[3].Text);
            double decShopvsDelvQnt = Convert.ToDouble(gvr.Cells[7].Text);
            double editedTotalCost = Convert.ToDouble(((TextBox)gvr.FindControl("commisionAmount")).Text);
            int siteCardCode = Convert.ToInt32(((TextBox)gvr.FindControl("siteCode")).Text);
            double qntForSiteCard = Convert.ToDouble(((TextBox)gvr.FindControl("quantity")).Text);
            string starUserDetaills = ((TextBox)gvr.FindControl("userDetails")).Text;
            int intProgramType = 6;
            int unitId = (int)HttpContext.Current.Session[SessionParams.UNIT_ID];
            int insertBy = (int) HttpContext.Current.Session[SessionParams.USER_ID];
            string message = String.Empty;
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

            if (XmlParser.CreateXml("StarConsumer", obj, filePathForXML, out message))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                message = _starConsumerEntryBll.InsertStarConsumerBill(doc.OuterXml, fromDateTime, toDateTime, insertBy, intProgramType, unitId,insertBy);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
            }
            DeleteFile();
        }

        private void DeleteFile()
        {
            try { File.Delete(filePathForXML); }
            catch { }
        }
        protected void showFullReport_OnClick(object sender, EventArgs e)
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            string email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            Response.Redirect("StarConsumeReport.aspx?email="+email+"&fromDate="+fromDate+"&toDate="+toDate);
        }
    }
}
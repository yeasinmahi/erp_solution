using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SAD_BLL.IHB;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.IHB
{
    public partial class DistributorManPowerInfo : System.Web.UI.Page
    {
        readonly DistributorManpowerBll _bll = new DistributorManpowerBll();
        private string _filePathForXml;

        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/IHB/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "AddCustomerIntoDistributorManpower.xml");
            if (!IsPostBack)
            {
                //LoadDistributorInfoGridView();
                LoadCustomerDropdown();
            }
        }

        protected void addCustomer_OnClick(object sender, EventArgs e)
        {
            AddCustomer();
        }

        protected void update_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            
            int customerId = Convert.ToInt32(gvr.Cells[2].Text);
            string strDistrManagerN = ((TextBox)gvr.FindControl("strDistrManagerN")).Text;
            string strSalesRepresentative1 = ((TextBox)gvr.FindControl("strSalesRepresentative1")).Text;
            string strSalesRepresentative2 = ((TextBox)gvr.FindControl("strSalesRepresentative2")).Text;
            int updateBy = 369116;
            DateTime updateDate = DateTime.Now;

            UpdateCustomerInfo(strDistrManagerN, strSalesRepresentative1, strSalesRepresentative2,updateBy,updateDate,customerId);
        }

        protected void getInfo_OnClick(object sender, EventArgs e)
        {
            LoadDistributorInfoGridView();
        }

        private void LoadDistributorInfoGridView()
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1);
            grdvDistributorManpower.DataSource = _bll.GetDistributorManpowerInfo(fromDateTime, toDateTime);
            grdvDistributorManpower.DataBind();
        }

        private void UpdateCustomerInfo(string distributorManager, string salesRepresentative1, string salesRepresentative2, int updateBy, DateTime updateDate, int customerId)
        {
            try
            {
                _bll.UpdateCustomerInfo(distributorManager, salesRepresentative1, salesRepresentative2, updateBy, updateDate, customerId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfuly Updated');", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Failed');", true);
            }
        }
        private void LoadCustomerDropdown()
        {
            ddlCustomer.DataSource = _bll.GetAllDistributor();
            ddlCustomer.DataValueField = "intCusID";
            ddlCustomer.DataTextField = "strName";
            ddlCustomer.DataBind();
        }

        private void AddCustomer()
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddHours(6).AddMilliseconds(-3);

            int intCustIDEntp = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
            string strManager = managerTextBox.Text;
            string strSalesRepresentive1 = salesRepresentative1TextBox.Text;
            string strSalesRepresentive2 = salesRepresentative1TextBox.Text;
            string message = String.Empty;
            int insertBy = 369116;
            int unitId = 4;
            dynamic obj = new
            {
                intCustIDEntp = intCustIDEntp,
                intsalesoficeid = 22,
                strManager = strManager,
                strSalesRepresentive1 = strSalesRepresentive1,
                strSalesRepresentive2 = strSalesRepresentive2
            };

            if (XmlParser.CreateXml("DistributorManpower", obj, _filePathForXml, out message))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_filePathForXml);
                message = _bll.InsertCustomerIntoDistributorManpower(doc.OuterXml, insertBy, unitId, fromDateTime, toDateTime);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
            }
            XmlParser.DeleteFile(_filePathForXml);
            LoadDistributorInfoGridView();
        }


    }
}
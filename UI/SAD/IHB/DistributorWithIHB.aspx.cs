using SAD_BLL.IHB;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.IHB
{

    public partial class DistributorWithIHB : Page
    {
        private DistributorWithIhbBll _bll = new DistributorWithIhbBll();
        private string _filePathForXml;

        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/IHB/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "DistributorWithIHB.xml");
            XmlParser.DeleteFile(_filePathForXml);
            if (!IsPostBack)
            {
                LoadRegion();
            }

        }

        protected void add_OnClick(object sender, EventArgs e)
        {
            string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");

            int intCustIDEntp = Convert.ToInt32(ddlDistributor.SelectedItem.Value);
            string CustIDEntpName = ddlDistributor.SelectedItem.Text;
            int intCustIDIHB = Convert.ToInt32(ddlIhb.SelectedItem.Value);
            string CustIDIHBName = ddlIhb.SelectedItem.Text;

            int unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
            int insertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            string message;
            DataTable dataTable = _bll.GetCustomerInfo(intCustIDIHB);
            if (dataTable.Rows.Count > 0)
            {
                int intSintSalesOfficeIHBACRDCustalesOffId = Convert.ToInt32(dataTable.Rows[0]["intSalesOffId"].ToString());
                string strIHBModifyPhone = dataTable.Rows[0]["phoneNumber"].ToString();

                dynamic obj = new
                {
                    intCustIDEntp = intCustIDEntp,
                    intCustIDIHB = intCustIDIHB,
                    intSintSalesOfficeIHBACRDCustalesOffId = intSintSalesOfficeIHBACRDCustalesOffId,
                    strIHBModifyPhone = strIHBModifyPhone
                };

                if (XmlParser.CreateXml("EnterprNihbbridge", obj, _filePathForXml, out message))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_filePathForXml);
                    message = _bll.InsertEnterpriseCustomerNihbCustmBridge(doc.OuterXml, fromDateTime, toDateTime, insertBy, unitId, insertBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadDataToGridView(CustIDEntpName, intCustIDEntp, CustIDIHBName,intCustIDIHB, intSintSalesOfficeIHBACRDCustalesOffId, strIHBModifyPhone);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
                }
                XmlParser.DeleteFile(_filePathForXml);
            }

        }

        private DataTable InitDatatable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("CustIDEntpName", typeof(string)));
            dt.Columns.Add(new DataColumn("intCustIDEntp", typeof(string)));
            dt.Columns.Add(new DataColumn("CustIDIHBName", typeof(string)));
            dt.Columns.Add(new DataColumn("intCustIDIHB", typeof(string)));
            dt.Columns.Add(new DataColumn("intSintSalesOfficeIHBACRDCustalesOffId", typeof(string)));
            dt.Columns.Add(new DataColumn("strIHBModifyPhone", typeof(string)));
            return dt;
        }
        private void LoadDataToGridView(string CustIDEntpName, int intCustIDEntp, string CustIDIHBName, int intCustIDIHB, int intSintSalesOfficeIHBACRDCustalesOffId, string strIHBModifyPhone)
        {
            DataTable dt =new DataTable();
            if (ViewState["CurrentTable"]==null)
            {
                dt = InitDatatable();
            }
            else
            {
                dt = (DataTable) ViewState["CurrentTable"];
            }
            DataRow dr = dt.NewRow();
            dr["CustIDEntpName"] = CustIDEntpName;
            dr["intCustIDEntp"] = intCustIDEntp;
            dr["CustIDIHBName"] = CustIDIHBName;
            dr["intCustIDIHB"] = intCustIDIHB;
            dr["intSintSalesOfficeIHBACRDCustalesOffId"] = intSintSalesOfficeIHBACRDCustalesOffId;
            dr["strIHBModifyPhone"] = strIHBModifyPhone;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            grdvCustomerWithIhb.DataSource = dt;
            grdvCustomerWithIhb.DataBind();
        }

        protected void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int regionId = Convert.ToInt32(ddlRegion.SelectedItem.Value);
            LoadArea(regionId);
        }
        protected void ddlArea_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int areaId = Convert.ToInt32(ddlArea.SelectedItem.Value);
            LoadTerritory(areaId);
        }

        protected void ddlTerritory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int territoryId = Convert.ToInt32(ddlTerritory.SelectedItem.Value);
            LoadDistributor(territoryId);
            LoadAcrd(territoryId);
        }
        public void LoadRegion()
        {
            ddlRegion.DataSource = _bll.GetRegion();
            ddlRegion.DataValueField = "intID";
            ddlRegion.DataTextField = "strText";
            ddlRegion.DataBind();
        }
        public void LoadArea(int regionId)
        {
            ddlArea.DataSource = _bll.GetArea(regionId);
            ddlArea.DataValueField = "intID";
            ddlArea.DataTextField = "strText";
            ddlArea.DataBind();
        }

        public void LoadTerritory(int areaId)
        {
            ddlTerritory.DataSource = _bll.GetTerritory(areaId);
            ddlTerritory.DataValueField = "intID";
            ddlTerritory.DataTextField = "strText";
            ddlTerritory.DataBind();
        }
        public void LoadDistributor(int territoryId)
        {
            ddlDistributor.DataSource = _bll.GetDistributor(territoryId);
            ddlDistributor.DataValueField = "intCusID";
            ddlDistributor.DataTextField = "strName";
            ddlDistributor.DataBind();
        }
        public void LoadAcrd(int territoryId)
        {
            ddlIhb.DataSource = _bll.GetAcrd(territoryId);
            ddlIhb.DataValueField = "intCusID";
            ddlIhb.DataTextField = "strName";
            ddlIhb.DataBind();
        }

        protected void report_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DistributorWithIhbReport.aspx");
        }
    }
}
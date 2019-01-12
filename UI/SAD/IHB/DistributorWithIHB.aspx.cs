using Flogging.Core;
using GLOBAL_BLL;
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
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\IHB\\DistributorWithIHB";
        string stop = "stopping SAD\\IHB\\DistributorWithIHB";
        DataTable dt = new DataTable();
        int intCustIDEntp, intCustIDIHB, unitId, insertBy;
        //bll = new SAD_BLL.Customer.Report.StatementC();

        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/IHB/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "DistributorWithIHB.xml");
            XmlParser.DeleteFile(_filePathForXml);
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadRegion();
            }

        }

        protected void add_OnClick(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on   SAD\\IHB\\DistributorWithIHB Add ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string fromDate = fromTextBox.Text;
            string toDate = toTextBox.Text;
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");

             intCustIDEntp = Convert.ToInt32(ddlDistributor.SelectedItem.Value);
            string CustIDEntpName = ddlDistributor.SelectedItem.Text;
             intCustIDIHB = Convert.ToInt32(ddlIhb.SelectedItem.Value);
            string CustIDIHBName = ddlIhb.SelectedItem.Text;

             unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
             insertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
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
                    //LoadDataToGridView(CustIDEntpName, intCustIDEntp, CustIDIHBName,intCustIDIHB, intSintSalesOfficeIHBACRDCustalesOffId, strIHBModifyPhone);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
                }
                XmlParser.DeleteFile(_filePathForXml);
            }
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

        protected void btnInactive_Click(object sender, EventArgs e)
        {
             intCustIDEntp = Convert.ToInt32(ddlDistributor.SelectedItem.Value);
             intCustIDIHB = Convert.ToInt32(ddlIhb.SelectedItem.Value);
             unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
             insertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());

            dt = _bll.updatedeletbrg(unitId, intCustIDEntp,1, insertBy, intCustIDIHB);
            string message = dt.Rows[0]["Messages"].ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            intCustIDEntp = Convert.ToInt32(ddlDistributor.SelectedItem.Value);
            intCustIDIHB = Convert.ToInt32(ddlIhb.SelectedItem.Value);
            unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
            insertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());

            dt = _bll.updatedeletbrg(unitId, intCustIDEntp, 2, insertBy, intCustIDIHB);
            string message = dt.Rows[0]["Messages"].ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

        }

    }
}
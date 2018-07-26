using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SAD_BLL.Consumer;
using SAD_BLL.Customer.Report;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class SubsidiaryJv : System.Web.UI.Page
    {
        StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        StatementC statement = new StatementC();
        private string _filePathForXml;

        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "subsidairyJv.xml");
        }

        protected void createSubsidiary_OnClick(object sender, EventArgs e)
        {
            string message = string.Empty;
            string strVcode = "voucherJV";
            string strPrefix = "JV";
            string glblnarration = "ACCL Cash D.O Commission from :" + fromTextBox.Text + "to " + toTextBox.Text;
            decimal totalCommision = Convert.ToDecimal(totalAmount.Value);
            //totalcom = Convert.ToDecimal(lbltotalcomamount.Text);

            int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intmainheadcoaid = 33855;
            int unitId = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

            foreach (GridViewRow gvr in grdv.Rows)
            {
                if (((CheckBox) gvr.FindControl("checkBox")).Checked)
                {
                    string customercoaid = gvr.Cells[6].Text;
                    string eachcustnarration = gvr.Cells[19].Text;
                    string eachcustamount = gvr.Cells[18].Text;
                    string customername = gvr.Cells[2].Text;
                    dynamic obj = new
                    {
                        customercoaid = customercoaid,
                        eachcustnarration = eachcustnarration,
                        eachcustamount = eachcustamount,
                        customername = customername

                    };
                    if (!XmlParser.CreateXml("RemoteCommission", "req", obj, _filePathForXml, out message))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('XmlFile-- " + message + "');", true);
                        break;
                    }
                }
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePathForXml);
            DataTable dt = statement.insertdataforsalescommissionjv(doc.OuterXml, unitId, strVcode, strPrefix, glblnarration, totalCommision, enroll, intmainheadcoaid);
            jvNumverLbl.Text = dt.Rows[0][2].ToString();
            XmlParser.DeleteFile(_filePathForXml);
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            DataTable source = new DataTable();
            try
            {
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
                fromDateTime = fromDateTime.AddHours(6);
                DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
                toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
                int salseOffice = Convert.ToInt32(ddlSalesOffice.SelectedItem.Value);
                int type = Convert.ToInt32(ddlType.SelectedItem.Value);

                
                if (type == 1)
                {
                    decimal factoryRate = Convert.ToDecimal(factoryRateTextBox.Text);
                    decimal ghatRate = Convert.ToDecimal(ghatRateTextBox.Text);
                    source = _bll.GetFactorySubsidiary(fromDateTime, toDateTime, salseOffice, factoryRate, ghatRate);
                }
                else if (type == 2)
                {
                    source = _bll.GetTransportSubsidiary(fromDateTime, toDateTime, salseOffice);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Type Properly');", true);
                }
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select All input Properly'"+exception.Message+");", true);
            }
            
            LoadGridView(source);
        }

        private void LoadGridView(DataTable source)
        {
            totalAmount.Value = source.AsEnumerable()
                .Sum(x => x.Field<decimal>("grandSubsidiary"))
                .ToString(CultureInfo.CurrentCulture);
            grdv.DataSource = source;
            grdv.DataBind();
        }
    }
}
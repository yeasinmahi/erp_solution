
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using SAD_BLL.Corporate_Sales;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Corporate_sales
{
    public partial class CorpBillByDamage : System.Web.UI.Page
    {
        OrderInput_BLL objOrder = new OrderInput_BLL();
        DataTable dt = new DataTable();


        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Corporate_sales\\CorpBillByDamage";
        string stop = "stopping SAD\\Corporate_sales\\CorpBillByDamage";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerName(string prefixText, int count)
        {
           // Int32 unit = Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString())
                 Int32 unit = Convert.ToInt32("2".ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetCustname(unit.ToString(), prefixText);

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKeyItem = txtItem.Text.Split(delimiterChars);

                string itemCust = ""; int itemCustID;
                string itemProduct = ""; int itemProductID;

                decimal total = Int32.Parse(0.ToString());
                itemCustID = Int32.Parse(arrayKeyItem[1].ToString());
                Session["itemCustID"] = itemCustID;
              
               

            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        { var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Corporate_sales\\CorpBillByDamage Save ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string challano = txtChallanno.Text;
            string pono = txtPONo.Text;
            string grnno = txtGRNno.Text;
            int Custid = int.Parse(Session["itemCustID"].ToString());
            DateTime dtedate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
           
            string address="sas";
            int enroll =int.Parse("1");

            objOrder.GetdamageReportbill(Custid, pono, grnno, dtedate, enroll,address, challano);


            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
            txtChallanno.Text = "";
            txtPONo.Text = "";
           
            txtGRNno.Text = "";
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

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
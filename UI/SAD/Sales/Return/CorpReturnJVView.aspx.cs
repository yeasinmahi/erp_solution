using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnJVView : Page
    {
        DataTable dt = new DataTable(); Bridge obj = new Bridge();
        int custid,  fk, productid; string challanno;
        decimal productqtysubmit;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Return\\CorpReturnJVView";
        string stop = "stopping SAD\\Sales\\Return\\CorpReturnJVView";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Sales\\Return\\CorpReturnJVView  Return JV", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    custid = int.Parse(HttpContext.Current.Session["CustId"].ToString());
                    challanno = (HttpContext.Current.Session["ChallanNo"].ToString());
                    dt = obj.GetDataForAppView(custid, challanno);
                    lblCustomer.Text = dt.Rows[0]["Customer"].ToString();
                    lblchalan.Text = dt.Rows[0]["strChallanNo"].ToString();
                    dgv.DataSource = dt;
                    dgv.DataBind();
                }
                catch (Exception ex)
                {
                    dgv.DataSource = ""; dgv.DataBind();
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();

                
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
           
          ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Closing.....');CloseWindow();", true);
           
        }


       
    }
}
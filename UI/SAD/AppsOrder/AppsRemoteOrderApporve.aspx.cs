using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.AppsOrder
{
    public partial class AppsRemoteOrderApporve : BasePage
    {
        DataTable dt = new DataTable();
        AppsSalesOrder_BLL objOrder = new AppsSalesOrder_BLL();

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\AppsOrder\\AppsRemoteOrderApporve";
        string stop = "stopping SAD\\AppsOrder\\AppsRemoteOrderApporve";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    pnlUpperControl.DataBind();
                    dt = objOrder.OrderSummeryView(8, "", enroll, "", unitid, DateTime.Now, DateTime.Now);
                    dgvOrder.DataSource = dt;
                    dgvOrder.DataBind();
                }
                catch { }
            }
        }

       

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\AppsOrder\\AppsRemoteOrderApporve Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                HiddenField lblSatelmentid = row.FindControl("hdnAutoID") as HiddenField;
                HiddenField lblCustomerid = row.FindControl("hdnCustid") as HiddenField;
                TextBox txtAdjust = row.FindControl("txtAdjValue") as TextBox;

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
    }
}
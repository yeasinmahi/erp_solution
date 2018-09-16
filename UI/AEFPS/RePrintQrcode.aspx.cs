using Flogging.Core;
using GLOBAL_BLL;
using MessagingToolkit.QRCode.Codec;
using QRCoder;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UI.ClassFiles;
namespace UI.AEFPS
{
    public partial class RePrintQrcode : System.Web.UI.Page
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        int enroll, mrrId, intWh; string ImagePath = "";

        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\RePrintQrcode";
        string stop = "stopping AEFPS\\RePrintQrcode";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DefaltLoad();
            }
            else
            {

            }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch { }

        }
        private void DefaltLoad()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\RePrintQrcode QR code Print", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                

                int itemid = int.Parse(TxtBatchNo.Text);
                dt = objRec.DataView(5, "", 0, itemid, DateTime.Now, enroll);
                dgvPrintView.DataSource = dt;
                dgvPrintView.DataBind();

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
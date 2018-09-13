using System;
using System.Web;
using System.Web.UI;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Consumer;
using UI.ClassFiles;

namespace UI.SAD.Consumer
{
    public partial class GhatEntry : System.Web.UI.Page
    {
        readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Consumer\\GhatEntry";
        string stop = "stopping SAD\\Consumer\\GhatEntry";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadGridView();
            }
        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\GhatEntry Get Entry Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string message = String.Empty;
            string ghatName = ghatNameTextBox.Text;
            string address = addressTextBox.Text;
            string contactPerson = contactPersonTextBox.Text;
            string contactNumber = contactNumberTextBox.Text;
            int enroll = 369116;
            int unitId = 4;
            if (!String.IsNullOrWhiteSpace(ghatName) || !String.IsNullOrWhiteSpace(address) || !String.IsNullOrWhiteSpace(contactPerson) || !String.IsNullOrWhiteSpace(contactNumber))
            {
                message = _bll.InsertGhat(ghatName, enroll, address, contactPerson, contactNumber, unitId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ message + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Input all data properly');", true);
            }
            LoadGridView();
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

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            int unitId = Convert.ToInt32(Session[SessionParams.UNIT_ID].ToString());
            grdv.DataSource = _bll.GetGhatInfo(unitId);
            grdv.DataBind();
        }
    }
}
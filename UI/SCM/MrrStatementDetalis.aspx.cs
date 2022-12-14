using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class MrrStatementDetalis : System.Web.UI.Page
    {
        private MrrReceive_BLL obj = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intWh, MrrId; private string dfile, xmlData;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\MrrStatementDetalis";
        private string stop = "stopping SCM\\MrrStatementDetalis";
        private string perform = "Performance on SCM\\MrrStatementDetalis";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                var tracker = new PerfTracker(perform + " " + "Pageload", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    MrrId = int.Parse(Request.QueryString["MrrId"].ToString());
                    lblMrrNo.Text = MrrId.ToString();
                    dt = obj.DataView(13, "", intWh, MrrId, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblChallan.Text = dt.Rows[0]["strExtnlReff"].ToString();
                        DateTime dtechallan = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                        lblChallanDate.Text = dtechallan.ToString("dd-MM-yyyy");
                        lblWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
                        lblSupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                        DateTime dteMrr = DateTime.Parse(dt.Rows[0]["dteDate"].ToString());
                        lblMrrDate.Text = dteMrr.ToString("dd-MM-yyyy");
                        lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                        string unit = dt.Rows[0]["intUnitID"].ToString();
                        imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                        lblMrrBy.Text = dt.Rows[0]["strName"].ToString();
                    }
                    else { }
                    dt = obj.DataView(14, "", intWh, MrrId, DateTime.Now, enroll);
                    dgvMrrDetlais.DataSource = dt;
                    dgvMrrDetlais.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "pageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            else
            { }
        }

        private double _totalAmount;
        protected void dgvMrrDetlais_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string amountText = ((Label) e.Row.FindControl("lblAmount")).Text;

                if (double.TryParse(amountText, out double amount))
                {
                    _totalAmount += amount;
                }
            }else if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label) e.Row.FindControl("lblTotalAmount")).Text = _totalAmount.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
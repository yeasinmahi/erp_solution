using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class IndentViewDetails : BasePage
    {

        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/IndentViewDetails.aspx";
        string stop = "stopping PaymentModule/IndentViewDetails.aspx";
        
        Indents_BLL objIndent = new Indents_BLL(); Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh, indentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/IndentViewDetails.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try
                {
                    try { hdnBillID.Value = Session["billid"].ToString(); } catch { }
                    int indentID = int.Parse(Request.QueryString["Id"].ToString());                    
                    dt = new DataTable();
                    dt = objBillApp.GetIndentViewDetails(indentID);
                    if (dt.Rows.Count > 0)
                    {
                        lblIndent.Text = indentID.ToString();
                        lbldteDue.Text = DateTime.Parse(dt.Rows[0]["dteDueDate"].ToString()).ToString("yyyy-MM-dd");
                        lbldteIndent.Text = DateTime.Parse(dt.Rows[0]["dteIndentDate"].ToString()).ToString("yyyy-MM-dd");
                        lblType.Text = dt.Rows[0]["strIndentType"].ToString();
                        lblWH.Text = dt.Rows[0]["strDescription"].ToString();
                    }
                    
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objIndent.IndentDetailsByIndentId(indentID);
                    if (dt.Rows.Count > 0)
                    {
                        lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                        lblIndentBY.Text = dt.Rows[0]["indentBy"].ToString();
                        lblApproveBy.Text = dt.Rows[0]["ApproveBY"].ToString();
                        string unit = dt.Rows[0]["intUnit"].ToString();
                        imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                    }
                    dgvIndentsDetalis.DataSource = dt;
                    dgvIndentsDetalis.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnBillDetails_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnBillDetails_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/IndentViewDetails.aspx btnBillDetails_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + hdnBillID.Value + "');", true);

            fd = log.GetFlogDetail(stop, location, "btnBillDetails_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }






















    }
}
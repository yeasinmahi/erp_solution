using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IndentStatusDetalis : BasePage
    {
        private Indents_BLL objIndent = new Indents_BLL();
        private DataTable dt = new DataTable();
        private int intwh, indentId;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IndentStatusDetalis";
        private string stop = "stopping SCM\\IndentStatusDetalis";
        private string perform = "Performance on SCM\\IndentStatusDetalis";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Page_Load", null);
                Flogger.WriteDiagnostic(fd);
                // starting performance tracker
                var tracker = new PerfTracker(perform + " " + "Page_Load", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);

                try
                {
                    string dteIndent = Request.QueryString["dteIndent"].ToString();
                    string dteDue = Request.QueryString["dteDue"].ToString();
                    string indentID = Request.QueryString["indentID"].ToString();
                    string dept = Request.QueryString["dept"].ToString();
                    string whname = Request.QueryString["whname"].ToString();
                    lblWH.Text = whname;
                    lblIndent.Text = indentID;
                    lbldteDue.Text = dteDue;
                    lbldteIndent.Text = dteIndent;
                    lblType.Text = dept;
                    
                    dt = objIndent.GetIndentItemDetails(int.Parse(indentID), out string message);
                    if (dt.Rows.Count > 0)
                    {
                        if (DateTime.TryParse(dt.Rows[0]["indentDate"].ToString(), out var indentDate) &&
                            DateTime.TryParse(dt.Rows[0]["ApproveDate"].ToString(), out var approveDate))
                        {
                            lblIndentBY.Text = dt.Rows[0]["indentBy"] + " [" +
                                               indentDate.ToString("D") + "]";
                            lblApproveBy.Text = dt.Rows[0]["ApproveBY"] + " [" +
                                                approveDate.ToString("D") + "]";
                        }
                        else
                        {
                            lblIndentBY.Text = dt.Rows[0]["indentBy"].ToString();
                            lblApproveBy.Text = dt.Rows[0]["ApproveBY"].ToString();
                        }

                        lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();

                        string unit = dt.Rows[0]["intUnit"].ToString();
                        int job = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                        if (job == 28)
                        {
                            imgUnit.ImageUrl = "/Content/images/img/" + "ag" + ".png".ToString();
                        }
                        else
                        {
                            imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                        }
                        if (lblApproveBy.Text.Length > 2 ||  whname.Contains("HO"))
                        {
                            imgApp.Visible = false;
                        }
                        else
                        {
                            imgApp.Visible = true;
                            imgUnit.ImageUrl = "/Content/images/img/" + "NotApproved" + ".png".ToString();
                            imgApp.ImageUrl = "/Content/images/img/" + "NotApproved" + ".png".ToString();
                        }
                    }
                    else
                    {
                        
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", message, true);
                        return;
                    }
                    dgvIndentsDetalis.DataSource = dt;
                    dgvIndentsDetalis.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            else
            { }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndentsDetalis.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("indents.xls", dgvIndentsDetalis);
            }
            catch { }
        }
    }
}
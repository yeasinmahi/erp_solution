using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoRegisterReport : BasePage
    {
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private DataTable dt = new DataTable();
        private int intWH, type, enroll;
        private int intID = 0;
        private int intNewType;
        private DateTime fDate, tDate;
        private string PoNo, MRRNo, BillNo;
        private string dept;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\PoRegisterReport";
        private string stop = "stopping SCM\\PoRegisterReport";

        //int indent = 0, po = 0, mrr = 0;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                //fDate = DateTime.Parse(txtDteFrom.Text.ToString());
                //tDate = DateTime.Parse(txtdteTo.Text.ToString());
                type = int.Parse(ddlType.SelectedValue);
                dept = ddlDept.SelectedItem.ToString();

                if (txtIndent.Text != "")
                {
                    intNewType = 1;
                    intID = Convert.ToInt32(txtIndent.Text.ToString());
                }
                else if (txtPO.Text != "")
                {
                    intNewType = 2;
                    intID = int.Parse(txtPO.Text.ToString());
                }
                else if (txtMrr.Text != "")
                {
                    intNewType = 3;
                    intID = int.Parse(txtMrr.Text.ToString());
                }
                dt = objPo.PoRegisterDataList(DateTime.Now, DateTime.Now, dept, 0, intNewType, intID, 1);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
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

        protected void lblMrrNo_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            LinkButton lblMrrNo = row.FindControl("lblMrrNo") as LinkButton;

            int Id = int.Parse(lblMrrNo.Text.ToString());

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewdetailsMrr('" + Id + "');", true);
        }

        protected void lblPoNos_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                LinkButton lblPoNos = row.FindControl("lblPoNos") as LinkButton;

                int Id = int.Parse(lblPoNos.Text.ToString());
                if (Id > 0)
                {
                    Session["pono"] = Id.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PoDetalisView.aspx');", true);
                }
            }
            catch { }
        }

        protected void lblBillNo_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            LinkButton lblBillNo = row.FindControl("lblBillNo") as LinkButton;

            int Id = int.Parse(lblBillNo.Text.ToString());

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + Id + "');", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objPo.GetPoData(1, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
                else { }
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

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStatement.DataSource = "";
                dgvStatement.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                fDate = DateTime.Parse(txtDteFrom.Text.ToString());
                tDate = DateTime.Parse(txtdteTo.Text.ToString());
                type = int.Parse(ddlType.SelectedValue);
                dept = ddlDept.SelectedItem.ToString();

                if (type == 4 || type == 5)
                {
                    dt = objPo.PoRegisterDataList(fDate, tDate, dept, intWH, 1, null, intNewType);
                }
                else
                {
                    dt = objPo.PoRegisterDataList(fDate, tDate, dept, intWH, type, null, null);
                }

                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
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

        protected void lblIndentNo_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            LinkButton lblIndent = row.FindControl("lblIndentNo") as LinkButton;

            int Id = int.Parse(lblIndent.Text.ToString());

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + Id + "');", true);
        }

        protected void dgvStatement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvStatement.Rows[rowIndex];

                PoNo = (row.FindControl("lblPoNos") as Label).Text;
                MRRNo = (row.FindControl("lblMrrNo") as Label).Text;
                BillNo = (row.FindControl("lblBillNo") as Label).Text;
                if (e.CommandName == "ViewPo")
                {
                    //Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                    //Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + PoNo + "');", true);
                }
                else if (e.CommandName == "ViewMRR")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + MRRNo + "');", true);
                }
                else if (e.CommandName == "ViewBill")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + BillNo + "');", true);
                }
            }
            catch { }
        }
    }
}
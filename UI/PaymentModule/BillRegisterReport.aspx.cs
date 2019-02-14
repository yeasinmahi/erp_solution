using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using Utility;

namespace UI.PaymentModule
{
    public partial class BillRegisterReport : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/BillRegisterReport.aspx";
        string stop = "stopping PaymentModule/BillRegisterReport.aspx";

        private readonly Payment_All_Voucher_BLL _bll = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intUnitID;
        DateTime dteFDate, dteTDate;
        string unitid, billid, entrycode, party, bank, bankacc, instrument, billtypeid, vdate;

        #endregion ====================================================================================

        protected void lblReff_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                string poNo = ((LinkButton)row.FindControl("lblReff")).Text;
                int id = 0;
                if (poNo.ToLower().Contains("po"))
                {
                    id = Common.GetOnlyNumberFromString(poNo);
                }
                if (id > 0)
                {
                    Session["pono"] = id.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "Registration('../SCM/PoDetalisView.aspx');", true);

                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void lblBillID_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                LinkButton lblBillNo = row.FindControl("lblBillID") as LinkButton;
                Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                int Id = int.Parse(lblBillNo.Text.ToString());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + Id + "');", true);
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillRegisterReport.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    dt = new DataTable();
                    dt = _bll.GetCount(Enroll);
                    int count = int.Parse(dt.Rows[0]["intCount"].ToString());
                    if (count == 1)
                    {
                        dt = _bll.GetUnitListForAll();
                        if (dt.Rows.Count > 0)
                        {
                            ddlUnit.DataTextField = "strUnit";
                            ddlUnit.DataValueField = "intUnitID";
                            ddlUnit.DataSource = dt;
                            ddlUnit.DataBind();
                            ddlUnit.Items.Insert(0, new ListItem("All Unit", "0"));
                        }
                    }
                    else if (count == 0)
                    {
                        dt = _bll.GetUnitList(Enroll);
                        if (dt.Rows.Count > 0)
                        {
                            ddlUnit.DataTextField = "strUnit";
                            ddlUnit.DataValueField = "intUnitID";
                            ddlUnit.DataSource = dt;
                            ddlUnit.DataBind();
                            ddlUnit.Items.Insert(0, new ListItem("All Unit", "0"));
                        }
                    }
                }
                else
                {
                    
                    if (dgvReport.Rows.Count > 0)
                    {
                        lblUnitName.Visible = true;
                        lblReportName.Visible = true;
                        lblFromToDate.Visible = true;
                    }
                    else
                    {
                        lblUnitName.Visible = false;
                        lblReportName.Visible = false;
                        lblFromToDate.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillRegisterReport.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = ddlUnit.SelectedValue();
                if (string.IsNullOrWhiteSpace(txtFrom.Text))
                {
                    Toaster("From Date " + Message.NotBlank.ToFriendlyString(), Common.TosterType.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTo.Text))
                {
                    Toaster("To Date " + Message.NotBlank.ToFriendlyString(), Common.TosterType.Warning);
                    return;
                }
                if (!DateTime.TryParse(txtFrom.Text, out dteFDate))
                {
                    Toaster("From " + Message.DateFormatError.ToFriendlyString(), Common.TosterType.Warning);
                    return;
                }
                if (!DateTime.TryParse(txtTo.Text, out dteTDate))
                {
                    Toaster("To " + Message.DateFormatError.ToFriendlyString(), Common.TosterType.Warning);
                    return;
                }

                lblUnitName.Text = ddlUnit.SelectedText();
                lblReportName.Text = "Bill Register Report";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");

                dt = _bll.GetBillRegisterForWeb(intUnitID, dteFDate, dteTDate);
                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblReportName.Visible = true;
                    lblFromToDate.Visible = true;

                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
                    dgvReport.UnLoad();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlUnit.SelectedItem.ToString();
            dgvReport.DataSource = "";
            dgvReport.DataBind();

            lblUnitName.Visible = false;
            lblReportName.Visible = false;
            lblFromToDate.Visible = false;
        }

        protected void dgvReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.CommandArgument.ToString()))
                {
                    return;
                }
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvReport.Rows[rowIndex];

                billid = (row.FindControl("lblBillID") as LinkButton).Text;
                party = (row.FindControl("lblPartyName") as Label).Text;

                if (e.CommandName == "View")
                {
                    Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                    Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + billid + "');", true);
                }
                if (e.CommandName == "Remove")
                {
                    string auditStatus = ((Label)row.FindControl("lblAuditStatus")).Text;
                    if (string.IsNullOrWhiteSpace(auditStatus))
                    {
                        _bll.RemoveBill(Enroll, int.Parse(billid), out string msg);
                        if (msg.ToLower().Contains("success"))
                        {
                            Toaster(msg, Common.TosterType.Success);
                            LoadGrid();
                        }
                        else
                        {
                            Toaster(msg, Common.TosterType.Warning);
                        }
                    }
                    else
                    {
                        Toaster("This Bill Already Approved. This bill can not be delete.", Common.TosterType.Warning);
                    }
                    //TODO:delete
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }


        protected void dgvReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[16].Visible = new Billing_BLL().IsPermitedToRemoveMrr(Enroll);

            }
            catch (Exception ex)
            {
                Toaster("Report Grid data bound problem. " + ex.Message, Common.TosterType.Error);
            }
        }
    }
}
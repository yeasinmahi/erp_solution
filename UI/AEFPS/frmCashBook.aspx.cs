using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Drawing.Printing;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.AEFPS
{
    public partial class frmCashBook : BasePage
    {
        int part,intWID,empid,intInsertby;
        DataTable dt;      
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtefdate, dtetdate;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\frmCashBook";
        string stop = "stopping AEFPS\\frmCashBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnEnroll.Value = (Session[SessionParams.USER_ID].ToString());
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();
            }
            else{ }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\frmCashBook Cash Book Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if ((txtfdate.Text != "") || (txttdate.Text != ""))
                {
                    if (ddlReporttype.SelectedValue == "1")
                    {
                        dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                        dtetdate = DateTime.Parse(txttdate.Text.ToString());
                        empid = int.Parse(hdnEnroll.Value.ToString());
                        intWID = int.Parse(ddlWH.SelectedValue);
                        lblWHName.Text = ddlWH.SelectedItem.ToString();
                        lblDate.Text ="Date From :"+ dtefdate.ToString("dd-MM-yyyy")+" To :"+ dtetdate.ToString("dd-MM-yyyy");
                        lblHeading.Text = "Cash Book";

                        part = 1;
                        dt = objAEFPS.getCashbook(dtefdate, dtetdate, intWID, part);
                        dgvRptTemp.DataSource = dt;
                        dgvRptTemp.DataBind();
                        part = 2;
                        dt = objAEFPS.getCashbook(dtefdate, dtetdate, intWID, part);

                        lblops.Text = Math.Round(decimal.Parse((dt.Rows[0]["ops"].ToString()))).ToString();
                        lblR.Text = Math.Round(decimal.Parse((dt.Rows[0]["Receive"].ToString()))).ToString();
                        lblCost.Text = Math.Round(decimal.Parse((dt.Rows[0]["Cost"].ToString()))).ToString();
                        lblCashinHand.Text = Math.Round(decimal.Parse((dt.Rows[0]["CashInHand"].ToString()))).ToString();
                        intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());

                       
                        Label2.Text = "Cost :";

                    }
                    else
                    {
                        intWID = int.Parse(ddlWH.SelectedValue);
                        dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                        dtetdate = DateTime.Parse(txttdate.Text.ToString());
                        part = 1;
                        dt = objAEFPS.getShopLedger(dtefdate, dtetdate, intWID, part);
                        lblWHName.Text = ddlWH.SelectedItem.ToString();
                        lblDate.Text = "Date From :" + dtefdate.ToString("dd-MM-yyyy") + " To :" + dtetdate.ToString("dd-MM-yyyy");
                        lblHeading.Text = "Shop Ledger";

                        dgvRptTemp.DataSource = dt;
                        dgvRptTemp.DataBind();
                        part = 2;
                        dt = objAEFPS.getShopLedger(dtefdate, dtetdate, intWID, part);
                        if (dt.Rows.Count > 0)
                        {
                            lblR.Text = dt.Rows[0]["mondebit"].ToString();
                            lblCost.Text = dt.Rows[0]["moncredit"].ToString();
                            Label2.Text = "Total Sales";
                        }
                        lblops.Visible = false;
                        lblR.Visible = true;
                        lblCost.Visible = true;
                        lblCashinHand.Visible = false;
                    }
                }
                else
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-Up Date');", true); }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected decimal Totaldebit = 0, Totalcredit=0;
        protected void dgvRptTemp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[2].FindControl("lblDebitss")).Text == "")
                {
                    Totaldebit += 0;
                }
                else
                {
                    Totaldebit += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblDebitss")).Text);
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[2].FindControl("lblmoncreditss")).Text == "")
                {
                    Totalcredit += 0;
                }
                else
                {
                    Totalcredit += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblmoncreditss")).Text);
                }
            }
        }
    }
}
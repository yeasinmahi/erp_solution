using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class AccountsPaymentOrder : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        protected double grdTotal = 0; protected double grdAdvance = 0; protected double grdThisbill = 0;
        string messageStatus = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\PartyPayment\\AccountsPaymentOrder";
        string stop = "stopping Accounts\\PartyPayment\\AccountsPaymentOrder";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); btnRejectAll.Enabled = false; btnApproveAll.Enabled = false;
                hdntype.Value = "CashCredit"; dgvPaymentOrder.Columns[3].Visible = false;
                dgvPaymentOrder.Columns[4].Visible = false;
            }
        }

        #region  ------------------ DataBound and IndexChange Event Handaler ---------

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void rdoviewtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoviewtype.SelectedValue)
            {
                case "CashCredit":
                    hdntype.Value = "CashCredit";
                    dgvPaymentOrder.Columns[3].Visible = false;
                    dgvPaymentOrder.Columns[4].Visible = false;
                    break;
                case "Adjustment":
                    hdntype.Value = "Adjustment";
                    dgvPaymentOrder.Columns[3].Visible = true;
                    dgvPaymentOrder.Columns[4].Visible = true;
                    break;
            }
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                int rowCount = dgvPaymentOrder.Rows.Count;
                if (rowCount > 0)
                {
                    btnRejectAll.Enabled = true; btnApproveAll.Enabled = true;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvPaymentOrder.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true); }
            }

            else
            {
                int rowCount = dgvPaymentOrder.Rows.Count;
                if (rowCount > 0)
                {
                    btnRejectAll.Enabled = false; btnApproveAll.Enabled = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvPaymentOrder.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }
        }
        public string GetJSShowBillADJUSTMENTVATPOMRR(object intBillID, object intPOID, object intShipmentID, object viewtype)
        { return "ShowBillVatPOMRR('" + intBillID.ToString() + "','" + intPOID.ToString() + "','" + intShipmentID.ToString() + "','" + viewtype.ToString() + "')"; }
        protected void dgvPaymentOrder_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                grdTotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lblAmount")).Text);
                grdAdvance += double.Parse(((Label)e.Row.Cells[3].FindControl("lblAdvance")).Text);
                grdThisbill += double.Parse(((Label)e.Row.Cells[4].FindControl("lblThisbill")).Text);
            }
        }

        #endregion

        #region ---------- Click Event Handaler -----------

        protected void Approve_Click(object sender, EventArgs e)
        {
            if (hdnAction.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Approve", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AccountsPaymentOrder   Approve ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    string billid = ((Button)sender).CommandArgument.ToString();
                    string remarks = txtRemarks.Text;
                    int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    messageStatus = objPartyBill.PartybillActionByManagement(int.Parse(billid), remarks, true, actionby);
                    if (messageStatus != "0")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messageStatus + "');", true); txtRemarks.Text = ""; }
                    else
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messageStatus + "');", true); }
                    dgvPaymentOrder.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Approve", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Approve", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }

        }
        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Approve", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AccountsPaymentOrder   Approve all ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                int rowCount = dgvPaymentOrder.Rows.Count; bool ysnChecked;
                if (rowCount > 0)
                {
                    if (hdnAction.Value == "1")
                    {
                        for (int i = 0; i < rowCount; i++)
                        {
                            ysnChecked = ((CheckBox)dgvPaymentOrder.Rows[i].Cells[0].Controls[0]).Checked;
                            if (ysnChecked)
                            {
                                string billid = ((HiddenField)dgvPaymentOrder.Rows[i].FindControl("hdnbillno")).Value.ToString();
                                string remarks = txtRemarks.Text;
                                int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                                messageStatus = objPartyBill.PartybillActionByManagement(int.Parse(billid), remarks, true, actionby);
                            }
                        }
                        txtRemarks.Text = "";
                        dgvPaymentOrder.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Approve", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Approve", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void Reject_Click(object sender, EventArgs e)
        {            
            if (hdnAction.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Reject", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AccountsPaymentOrder   Reject  ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    string billid = ((Button)sender).CommandArgument.ToString();
                    string remarks = txtRemarks.Text;
                    int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    messageStatus = objPartyBill.PartybillActionByManagement(int.Parse(billid), remarks, false, actionby);
                    if (messageStatus != "0")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messageStatus + "');", true); txtRemarks.Text = ""; }
                    else
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messageStatus + "');", true); }
                    dgvPaymentOrder.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Reject", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Reject", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
        }
        protected void btnRejectAll_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Reject", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AccountsPaymentOrder   Reject ALL  ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int rowCount = dgvPaymentOrder.Rows.Count; bool ysnChecked;
                if (rowCount > 0)
                {                    
                    if (hdnAction.Value == "1")
                    {
                        for (int i = 0; i < rowCount; i++)
                        {
                            ysnChecked = ((CheckBox)dgvPaymentOrder.Rows[i].Cells[0].Controls[0]).Checked;
                            if (ysnChecked)
                            {
                                string billid = ((HiddenField)dgvPaymentOrder.Rows[i].FindControl("hdnbillno")).Value.ToString();
                                string remarks = txtRemarks.Text;
                                int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                                messageStatus = objPartyBill.PartybillActionByManagement(int.Parse(billid), remarks, false, actionby);
                            }
                        }
                        txtRemarks.Text = "";
                        dgvPaymentOrder.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Reject", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Reject", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #endregion

    }
}
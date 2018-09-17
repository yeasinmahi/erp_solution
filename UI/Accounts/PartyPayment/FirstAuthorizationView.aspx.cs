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
    public partial class FirstAuthorizationView : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        string alertmsg = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\PartyPayment\\FirstAuthorizationView";
        string stop = "stopping Accounts\\PartyPayment\\FirstAuthorizationView";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdngobycode.Value = ""; btnAllAuthorize.Enabled = false; hdnprinted.Value = "False";
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "BP-" + pre + "-";
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
        protected void rdoViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (rdoViewType.SelectedValue)
            //{
            //    case "notcom":
            //        hdnviewstatus.Value = "true";
            //        hdnenable.Value = "true";
            //        hdndebit.Value = "true";
            //        break;
            //    case "com":
            //        hdnviewstatus.Value = "false";
            //        hdnenable.Value = "true";
            //        hdndebit.Value = "true";
            //        break;
            //}
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                int rowCount = dgvViewVoucher.Rows.Count;
                if (rowCount > 0)
                {
                    btnAllAuthorize.Enabled = true;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvViewVoucher.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true); }
            }

            else
            {
                int rowCount = dgvViewVoucher.Rows.Count;
                if (rowCount > 0)
                {
                    btnAllAuthorize.Enabled = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvViewVoucher.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }

        }
        public string GetJSShowBillVATPOMRR(object intBillID, object intPOID, object intShipmentID, object viewtype)
        { return "ShowBillVatPOMRR('" + intBillID.ToString() + "','" + intPOID.ToString() + "','" + intShipmentID.ToString() + "','" + viewtype.ToString() + "')"; }
        public string GetJSShowVoucher(object voucher, object type, object debit)
        {
            return "ShowVoucher('" + voucher.ToString() + "','" + type.ToString() + "','" + debit.ToString() + "')";
        }
       
        #endregion

        #region ---------- Click Event Handaler -----------

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 9) hdngobycode.Value = txtCode.Text;
            else hdngobycode.Value = "";
            dgvViewVoucher.DataBind();
        }

        protected void btnAllAuthorize_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "AllAuthorize", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\FirstAuthorizationView   btnAllAuthorize_Click ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int rowCount = dgvViewVoucher.Rows.Count; bool ysnChecked;
                    for (int i = 0; i < rowCount; i++)
                    {
                        ysnChecked = ((CheckBox)dgvViewVoucher.Rows[i].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                            int selectedvoucherid = int.Parse(((HiddenField)dgvViewVoucher.Rows[i].FindControl("hdnvoucherid")).Value.ToString());
                            alertmsg = objPartyBill.GetVoucherAuthorization(usrid, unitid, selectedvoucherid);                            
                        }
                    }
                    dgvViewVoucher.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "AllAuthorize", ex);
                    Flogger.WriteError(efd);
                    alertmsg = "Sorry to submit !!!."; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true);
                }



                fd = log.GetFlogDetail(stop, location, "AllAuthorize", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
               
            }
        }

        protected void Sign_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Authorize", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\FirstAuthorizationView   Sign_Click ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                    int selectedvoucherid = int.Parse(((Button)sender).CommandArgument.ToString());
                    alertmsg = objPartyBill.GetVoucherAuthorization(usrid, unitid, selectedvoucherid);
                    if (alertmsg == "0")
                    {   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true); }
                    //else
                    //{ ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true); }
                    dgvViewVoucher.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Authorize", ex);
                    Flogger.WriteError(efd);
                  
                }



                fd = log.GetFlogDetail(stop, location, "Authorize", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }

        }

        #endregion

        
    }
}
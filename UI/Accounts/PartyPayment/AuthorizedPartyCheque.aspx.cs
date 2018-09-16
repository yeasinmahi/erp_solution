using BLL.Accounts.Voucher;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class AuthorizedPartyCheque : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        string alertmsg = ""; StringBuilder selectedvoucherAdd = new StringBuilder(); int selectedvoucherid;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\PartyPayment\\AuthorizedPartyCheque";
        string stop = "stopping Accounts\\PartyPayment\\AuthorizedPartyCheque";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdngobycode.Value = ""; btnPrintAll.Enabled = false; hdnprinted.Value = "False"; //Value=False Means not printed and Value=True Means printed.
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "BP-" + pre + "-"; chkAccountpay.Checked = true; hdnaccountpay.Value = "bn";
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
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                int rowCount = dgvAuthorizedPartyCheque.Rows.Count;
                if (rowCount > 0)
                {
                    btnPrintAll.Enabled = true;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true);}
            }

            else
            {
                int rowCount = dgvAuthorizedPartyCheque.Rows.Count;
                if (rowCount > 0)
                {
                    btnPrintAll.Enabled = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }

        }
        protected void rdoprintstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoprintstatus.SelectedValue)
            {
                case "False":
                    hdnprinted.Value = "False"; //Value=False Means not printed
                    dgvAuthorizedPartyCheque.Columns[8].Visible = true;
                    chkAll.Visible = true; btnPrintAll.Visible=true;
                    break;
                case "True":
                    hdnprinted.Value = "True"; //Value=True Means printed
                    dgvAuthorizedPartyCheque.Columns[8].Visible = false;
                    chkAll.Visible = false; btnPrintAll.Visible=false;
                    break;
            }
        }
        protected void chkAccountpay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAccountpay.Checked == true)
            { hdnaccountpay.Value = "bn"; }
            else { hdnaccountpay.Value = "cn"; }
        }

        #endregion

        #region ---------- Click Event Handaler -----------

        protected void btnMChange_Click(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    VoucherRollback vr = new VoucherRollback();
            //    lblStatus.Text = vr.ChequeNoInterchange(ddlUnit.SelectedValue, txtCode1.Text, txtCode2.Text, Session[SessionParams.USER_ID].ToString());
            //    dgvAuthorizedPartyCheque.DataBind();
            //}
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 9) hdngobycode.Value = txtCode.Text;
            else hdngobycode.Value = "";
            dgvAuthorizedPartyCheque.DataBind();
        }
        protected void Print_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Print", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AuthorizedPartyCheque   Print ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                    int selectedvoucherid = int.Parse(((Button)sender).CommandArgument.ToString());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowSingleChequePrint('" + selectedvoucherid + "');", true);
                    objPartyBill.UpdatePrintStatusAndComplteAuthorization(selectedvoucherid, unitid, usrid );
                    dgvAuthorizedPartyCheque.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Print", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Print", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }

        }
        protected void btnPrintAll_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Print", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\PartyPayment\\AuthorizedPartyCheque   Print All ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int rowCount = dgvAuthorizedPartyCheque.Rows.Count; bool ysnChecked;
                    for (int i = 0; i < rowCount; i++)
                    {
                        ysnChecked = ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                            selectedvoucherid = int.Parse(((HiddenField)dgvAuthorizedPartyCheque.Rows[i].FindControl("hdnvoucherid")).Value.ToString());
                            objPartyBill.UpdatePrintStatusAndComplteAuthorization(selectedvoucherid, unitid, usrid);
                            selectedvoucherAdd.Append(selectedvoucherid.ToString() + ",");
                        }
                    }
                    string selectedvouchers = selectedvoucherAdd.Remove(selectedvoucherAdd.Length - 1, 1).ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowMultipleChequePrint('" + selectedvouchers + "','" + hdnaccountpay.Value + "');", true);
                    dgvAuthorizedPartyCheque.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Print", ex);
                    Flogger.WriteError(efd);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true);
                }



                fd = log.GetFlogDetail(stop, location, "Print", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
              
            }
        }

        #endregion

        

    }
}
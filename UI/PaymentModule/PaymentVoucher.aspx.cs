using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.PaymentModule
{
    public partial class PaymentVoucher : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/PaymentVoucher.aspx";
        string stop = "stopping PaymentModule/PaymentVoucher.aspx";

        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        int intDept, intType;
        string unitid, billid, entrycode, party, bank, bankacc, instrument, billtypeid, vdate;
        decimal monTotalAdvance;
        int intCountPVoucher;
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PaymentVoucher.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                
                if (!IsPostBack)
                {
                    #region ===== Permission Check ===========================================================
                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetCheckUserRoleForVoucher(hdnEmail.Value);
                        if (dt.Rows.Count > 0)
                        {
                            if (int.Parse(dt.Rows[0]["intCount"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                                return;
                            }
                        }
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }

                    hdnysnPay.Value = "0";
                    hdnysnDutyVoucher.Value = "0";
                    dt = new DataTable();
                    dt = objBillReg.GetUserInfoForPaymentModule(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        if (bool.Parse(dt.Rows[0]["ysnPay"].ToString()) == true)
                        {
                            hdnysnPay.Value = "1";                            
                        }
                        if (bool.Parse(dt.Rows[0]["ysnDutyVoucher"].ToString()) == true)
                        {
                            hdnysnDutyVoucher.Value = "1";
                        }                        
                    }
                    if(hdnysnPay.Value == "1")
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetPayTypeForPay1();
                        ddlType.DataTextField = "strPayType";
                        ddlType.DataValueField = "intPayType";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();
                    }
                    else if (hdnysnDutyVoucher.Value == "1")
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetPayTypeDutyVoucher1();
                        ddlType.DataTextField = "strPayType";
                        ddlType.DataValueField = "intPayType";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();
                    }

                    #endregion ====================================================================================
                    
                    dt = new DataTable();
                    dt = objBillReg.GetUnitListByUserID(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You are not authorized to create payment voucher.');", true);
                        return;
                    }
                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetBankInfoByUnitID(int.Parse(ddlUnit.SelectedValue.ToString()));
                        ddlBank.DataTextField = "strBankName";
                        ddlBank.DataValueField = "intBankID";
                        ddlBank.DataSource = dt;
                        ddlBank.DataBind();
                    }
                    catch { }

                    try
                    {
                        dt = new DataTable();
                        dt = objBillReg.GetAccountByBankID(int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlBank.SelectedValue.ToString()));
                        ddlACNumber.DataTextField = "strBankAccount";
                        ddlACNumber.DataValueField = "intAccountID";
                        ddlACNumber.DataSource = dt;
                        ddlACNumber.DataBind();
                    }
                    catch { }
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

        protected void dgvReportForPaymentV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvReportForPaymentV_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PaymentVoucher.aspx dgvReportForPaymentV_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvReportForPaymentV.Rows[rowIndex];

                unitid = ddlUnit.SelectedValue.ToString();
                billid = (row.FindControl("lblID") as Label).Text;
                entrycode = (row.FindControl("lblRegNo") as Label).Text;
                party = (row.FindControl("lblPartyName") as Label).Text;
                bank = ddlBank.SelectedValue.ToString();
                bankacc = ddlACNumber.SelectedValue.ToString();
                instrument = ddlInstrument.SelectedValue.ToString();
                billtypeid = ddlType.SelectedValue.ToString();

                try
                {
                    if (txtDate.Text != "")
                    {
                        vdate = DateTime.Parse(txtDate.Text).ToString();
                    }
                    else
                    {
                        vdate = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                    }
                }
                catch { vdate = DateTime.Now.ToString("yyyy-MM-dd").ToString(); }

                if (e.CommandName == "PV")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPrepareVoucher('" + unitid + "','" + billid + "','" + entrycode + "','" + party + "','" + bank + "','" + bankacc + "','" + instrument + "', '" + billtypeid + "', '" + vdate + "');", true);
                }
                else if (e.CommandName == "CP")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPrepareVoucherCP('" + unitid + "','" + billid + "','" + entrycode + "','" + party + "','" + bank + "','" + bankacc + "','" + instrument + "', '" + billtypeid + "');", true);
                }
                else if (e.CommandName == "JV")
                {
                    /*
                    Billing_BLL objBillApp = new Billing_BLL();
                    DataTable dtt = new DataTable();
                    dtt = objBillApp.GetBillInfoForBPVoucher(int.Parse(billid));
                    if (dtt.Rows.Count > 0)
                    {                        
                        monTotalAdvance = Math.Round(decimal.Parse(dtt.Rows[0]["monAdvanceTotal"].ToString()), 2);
                        intCountPVoucher = int.Parse(dtt.Rows[0]["intCountPVoucher"].ToString());                        
                    }

                    if (intCountPVoucher == 0)
                    {
                        if (monTotalAdvance == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('JV Not Possible.');", true); return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('JV Not Possible.');", true); return;
                    }
                    */
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPrepareVoucherJV('" + unitid + "','" + billid + "','" + entrycode + "','" + party + "','" + bank + "','" + bankacc + "','" + instrument + "', '" + billtypeid + "');", true);
                }
                else if (e.CommandName == "View")
                {
                    Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                    Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + billid + "');", true);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "dgvReportForPaymentV_RowCommand", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "dgvReportForPaymentV_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = objBillReg.GetBankInfoByUnitID(int.Parse(ddlUnit.SelectedValue.ToString()));
                ddlBank.DataTextField = "strBankName";
                ddlBank.DataValueField = "intBankID";
                ddlBank.DataSource = dt;
                ddlBank.DataBind();
            }
            catch { }

            try
            {
                dt = new DataTable();
                dt = objBillReg.GetAccountByBankID(int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlBank.SelectedValue.ToString()));
                ddlACNumber.DataTextField = "strBankAccount";
                ddlACNumber.DataValueField = "intAccountID";
                ddlACNumber.DataSource = dt;
                ddlACNumber.DataBind();
            }
            catch { }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = objBillReg.GetAccountByBankID(int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlBank.SelectedValue.ToString()));
                ddlACNumber.DataTextField = "strBankAccount";
                ddlACNumber.DataValueField = "intAccountID";
                ddlACNumber.DataSource = dt;
                ddlACNumber.DataBind();
            }
            catch { }
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
            var tracker = new PerfTracker("Performance on PaymentModule/PaymentVoucher.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intType = int.Parse(ddlType.SelectedValue.ToString());
                if (intType == 1) { intDept = 0; }
                else if (intType == 2) { intDept = 1; }
                else if (intType == 3) { intDept = 3; }
                else if (intType == 4) { intDept = 4; }
                

                if(hdnysnPay.Value == "1")
                {
                    intType = intType;
                }
                else if (hdnysnDutyVoucher.Value == "1" && intType == 2)
                {
                    intType = 4;
                }

                dt = new DataTable();
                dt = objBillReg.GetUnpaidBillList(int.Parse(ddlUnit.SelectedValue.ToString()), intDept);
                dgvReportForPaymentV.DataSource = dt;
                dgvReportForPaymentV.DataBind();
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
























    }
}
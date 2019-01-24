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
    public partial class BillDetails : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/BillDetails.aspx";
        string stop = "stopping PaymentModule/BillDetails.aspx";

        private readonly Billing_BLL _bll = new Billing_BLL();
        private DataTable _dt;
        
        int intPOID, intBillID, intMRRID;
        string strSPName, strPath;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID, intIndent; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = "";
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillDetails.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try
                {
                    hdnLevel.Value = "0";
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                    try
                    {
                        _dt = new DataTable();
                        _dt = _bll.GetUserInfoForAudit(int.Parse(hdnEnroll.Value));
                        if (bool.Parse(_dt.Rows[0]["ysnAudit2"].ToString()) == true)
                        {
                            hdnLevel.Value = "2";
                        }
                        else if (bool.Parse(_dt.Rows[0]["ysnAudit1"].ToString()) == true)
                        {
                            hdnLevel.Value = "1";
                        }
                    }
                    catch { }

                    try
                    {
                        intBillID = int.Parse(Request.QueryString["Id"]);
                        try { Session["billid"] = intBillID.ToString(); } catch { }
                        txtBillAmount.Text = Session["billamount"].ToString();
                        txtParty.Text = Session["party"].ToString();
                    }
                    catch
                    {
                        intBillID = int.Parse(Session["billid"].ToString());
                    }

                    if (hdnLevel.Value == "1")
                    {
                        _dt = new DataTable();
                        _dt = _bll.GetNetPayForLevel1(intBillID);
                        if (_dt.Rows.Count > 0)
                        {
                            txtNetAmount.Text = Math.Round(decimal.Parse(_dt.Rows[0]["monNetPay"].ToString()), 2).ToString();
                        }
                    }

                    if (hdnLevel.Value == "2")
                    {
                        _dt = new DataTable();
                        _dt = _bll.GetNetPayForLevel2(intBillID);
                        if (_dt.Rows.Count > 0)
                        {
                            txtNetAmount.Text = Math.Round(decimal.Parse(_dt.Rows[0]["monApproveAmount"].ToString()), 2).ToString();
                        }
                    }

                    try
                    {
                        _dt = new DataTable();
                        _dt = _bll.GetPOIDByBillID(intBillID);
                        if (_dt.Rows.Count > 0)
                        {
                            hdnPOID.Value = _dt.Rows[0]["strReffNo"].ToString();
                        }
                        if (hdnPOID.Value == "")
                        {
                            hdnPOID.Value = "0";
                        }
                    }
                    catch { hdnPOID.Value = "0"; }

                    txtPONo.Text = hdnPOID.Value;
                    txtBillID.Text = intBillID.ToString();
                    _dt = new DataTable();
                    _dt = _bll.GetPODate(int.Parse(hdnPOID.Value));
                    if (_dt.Rows.Count > 0)
                    {
                        txtPODate.Text = _dt.Rows[0]["dtePODate"].ToString();
                    }

                    _dt = new DataTable();
                    _dt = _bll.GetUnitInfoByBillID(intBillID);
                    if (_dt.Rows.Count > 0)
                    {
                        txtRegNo.Text = _dt.Rows[0]["strBillRegCode"].ToString();
                        hdnEntryType.Value = _dt.Rows[0]["intEntryType"].ToString();
                        txtNetPay.Text = Math.Round(decimal.Parse(_dt.Rows[0]["monNetPay"].ToString()), 2).ToString();
                        hdnUnitID.Value = _dt.Rows[0]["intUnitID"].ToString();
                    }

                    //Document List =========================================
                    _dt = new DataTable();
                    _dt = _bll.GetDocumentList(intBillID, int.Parse(hdnEntryType.Value));
                    if (_dt.Rows.Count > 0)
                    {
                        dgvDocList.DataSource = _dt;
                        dgvDocList.DataBind();
                    }
                    //Challan List =========================================
                    _dt = new DataTable();
                    _dt = _bll.GetChallanList(intBillID);
                    if (_dt.Rows.Count > 0)
                    {
                        dgvChallanList.DataSource = _dt;
                        dgvChallanList.DataBind();
                    }

                    //Item Details List =========================================
                    _dt = new DataTable();
                    _dt = _bll.GetItemDetailsByPO(int.Parse(hdnPOID.Value), true, intBillID);
                    if (_dt.Rows.Count > 0)
                    {
                        dgvBillReport.DataSource = _dt;
                        dgvBillReport.DataBind();
                    }

                    //Indent List =========================================
                    _dt = new DataTable();
                    if (int.Parse(hdnPOID.Value) > 0)
                    {
                        _dt = _bll.GetIndentList(int.Parse(hdnPOID.Value));
                        if (_dt.Rows.Count > 0)
                        {
                            dgvIndentList.DataSource = _dt;
                            dgvIndentList.DataBind();
                        }
                    }
                    

                    _dt = new DataTable();
                    _dt = _bll.GetVoucherListByBillID(intBillID);
                    if (_dt.Rows.Count > 0)
                    {
                        dgvVoucherList.DataSource = _dt;
                        dgvVoucherList.DataBind();
                    }
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

        #region===== Grid View Load For Report =========================================================
        /*
        private void LoadGrid()
        {
            try
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intUserID = int.Parse(temp1[1].ToString());
                }
                catch { intUserID = 0; return; }

                dgvLoan.DataSource = "";
                dgvLoan.DataBind();
                intPart = 1;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intUserID);
                dgvLoan.DataSource = dt;
                dgvLoan.DataBind();
            }
            catch (Exception ex) { throw ex; }
        }
        */
        protected decimal vatgrandtotal = 0;
        protected decimal aitgrandtotal = 0;
        protected decimal ggrandtotal = 0;
        protected void dgvBillReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    vatgrandtotal += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblVAT")).Text);
                    aitgrandtotal += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblAIT")).Text);
                    ggrandtotal += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblGTotal")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        protected decimal mrrtkgrandtotal = 0;
        protected decimal vouchertkgrandtotal = 0;
        protected void dgvChallanList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    mrrtkgrandtotal += decimal.Parse(((Label) e.Row.Cells[2].FindControl("lblMRRTK")).Text);
                    vouchertkgrandtotal += decimal.Parse(((Label) e.Row.Cells[4].FindControl("lblVoucherTK")).Text);
                }
                catch (Exception ex)
                {
                    Toaster(Message.ParsingProblem.ToFriendlyString()+" :"+ex.Message,Common.TosterType.Error);
                }
                
            }
            try
            {
                e.Row.Cells[6].Visible = _bll.IsPermitedToRemoveMrr(Enroll);

            }
            catch (Exception exception)
            {

            }
        }
        #endregion======================================================================================

        #region===== Grid View Row Command Action ======================================================
        protected void dgvBillReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvBillReport_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillDetails.aspx dgvBillReport_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "PrePrice")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvBillReport.Rows[rowIndex];

                try
                {
                    Session["itemname"] = (row.FindControl("lblItemName") as Label).Text;
                    string strItemID = (row.FindControl("lblItemID") as Label).Text;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPriceListPopup('" + strItemID + "');", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            fd = log.GetFlogDetail(stop, location, "dgvBillReport_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void dgvDocList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvDocList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillDetails.aspx dgvDocList_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "DocS")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvDocList.Rows[rowIndex];

                try
                {
                    strPath = (row.FindControl("lblFTPPath") as Label).Text;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocumentPopup('" + strPath + "');", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            fd = log.GetFlogDetail(stop, location, "dgvDocList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void dgvChallanList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvChallanList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillDetails.aspx dgvChallanList_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "ChallanS")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvChallanList.Rows[rowIndex];

                try
                {
                    intMRRID = int.Parse((row.FindControl("lblMRR") as Label).Text);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewMRRDetailsPopup('" + intMRRID.ToString() + "');", true);                                       
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
            if (e.CommandName == "RemoveMrr")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvChallanList.Rows[rowIndex];
                string bill = txtBillID.Text;
                if (string.IsNullOrWhiteSpace(bill))
                {
                    Toaster("Bill ID not found", Common.TosterType.Error);
                    return;
                }
                if (int.TryParse(bill, out int billId))
                {
                    try
                    {
                        intMRRID = int.Parse((row.FindControl("lblMRR") as Label)?.Text);
                        string message = _bll.RemoveMrr(Enroll, intMRRID, billId);
                        if (message.ToLower().Contains("success"))
                        {
                            Toaster(Message.RemoveSuccess.ToFriendlyString(), Common.TosterType.Success);
                        }
                        else
                        {
                            Toaster(Message.RemoveFailed.ToFriendlyString(), Common.TosterType.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Toaster(ex.Message, Common.TosterType.Error);
                    }
                }
                else
                {
                    Toaster("Bill ID parsing problem.", Common.TosterType.Error);
                }
                
            }

            fd = log.GetFlogDetail(stop, location, "dgvChallanList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void dgvIndentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvIndentList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/BillDetails.aspx dgvIndentList_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "IndentS")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvIndentList.Rows[rowIndex];

                try
                {
                    intIndent = int.Parse((row.FindControl("lblIndent") as Label).Text);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewInDetailsPopup('" + intIndent.ToString() + "');", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            fd = log.GetFlogDetail(stop, location, "dgvIndentList_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        /*
        protected void dgvVoucherList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VoucherS")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvVoucherList.Rows[rowIndex];

                try
                {

                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }
        */
        #endregion======================================================================================


































    }
}
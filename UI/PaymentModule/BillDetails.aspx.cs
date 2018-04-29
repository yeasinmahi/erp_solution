using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class BillDetails : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt;
        
        int intPOID, intBillID, intMRRID;
        string strSPName, strPath;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID, intIndent; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = "";
        #endregion ====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnLevel.Value = "0";
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = new DataTable();
                dt = objBillApp.GetUserInfoForAudit(int.Parse(hdnEnroll.Value));
                if (bool.Parse(dt.Rows[0]["ysnAudit2"].ToString()) == true)
                {
                    hdnLevel.Value = "2";
                }
                else if (bool.Parse(dt.Rows[0]["ysnAudit1"].ToString()) == true)
                {
                    hdnLevel.Value = "1";
                }
                
                try
                {
                    intBillID = int.Parse(Request.QueryString["Id"]);
                    Session["billid"] = intBillID.ToString();
                    txtBillAmount.Text = Session["billamount"].ToString();
                    txtParty.Text = Session["party"].ToString();
                }
                catch {
                    intBillID = int.Parse(Session["billid"].ToString());
                }

                if (hdnLevel.Value == "1")
                {
                    dt = new DataTable();
                    dt = objBillApp.GetNetPayForLevel1(intBillID);
                    if (dt.Rows.Count > 0)
                    {
                        txtNetAmount.Text = Math.Round(decimal.Parse(dt.Rows[0]["monNetPay"].ToString()),2).ToString();
                    }
                }

                if (hdnLevel.Value == "2")
                {
                    dt = new DataTable();
                    dt = objBillApp.GetNetPayForLevel2(intBillID);
                    if (dt.Rows.Count > 0)
                    {
                        txtNetAmount.Text = Math.Round(decimal.Parse(dt.Rows[0]["monApproveAmount"].ToString()),2).ToString();
                    }
                }

                dt = new DataTable();
                dt = objBillApp.GetPOIDByBillID(intBillID);
                if (dt.Rows.Count > 0)
                {
                    hdnPOID.Value = dt.Rows[0]["strReffNo"].ToString();
                }
                txtPONo.Text = hdnPOID.Value;
                txtBillID.Text = intBillID.ToString();
                dt = new DataTable();
                dt = objBillApp.GetPODate(int.Parse(hdnPOID.Value));
                if (dt.Rows.Count > 0)
                {                    
                    txtPODate.Text = dt.Rows[0]["dtePODate"].ToString();
                }
                
                dt = new DataTable();
                dt = objBillApp.GetUnitInfoByBillID(intBillID);
                if (dt.Rows.Count > 0)
                {
                    txtRegNo.Text = dt.Rows[0]["strBillRegCode"].ToString();
                    hdnEntryType.Value = dt.Rows[0]["intEntryType"].ToString();
                    txtNetPay.Text = Math.Round(decimal.Parse(dt.Rows[0]["monNetPay"].ToString()),2).ToString();
                    hdnUnitID.Value = dt.Rows[0]["intUnitID"].ToString();
                }

                //Document List =========================================
                dt = new DataTable();
                dt = objBillApp.GetDocumentList(intBillID, int.Parse(hdnEntryType.Value));
                if (dt.Rows.Count > 0)
                {
                    dgvDocList.DataSource = dt;
                    dgvDocList.DataBind();
                }
                //Challan List =========================================
                dt = new DataTable();
                dt = objBillApp.GetChallanList(intBillID);
                if (dt.Rows.Count > 0)
                {
                    dgvChallanList.DataSource = dt;
                    dgvChallanList.DataBind();
                }

                //Item Details List =========================================
                dt = new DataTable();
                dt = objBillApp.GetItemDetailsByPO(intPOID, true, intBillID);
                if (dt.Rows.Count > 0)
                {
                    dgvBillReport.DataSource = dt;
                    dgvBillReport.DataBind();
                }

                //Indent List =========================================
                dt = new DataTable();
                dt = objBillApp.GetIndentList(intPOID);
                if (dt.Rows.Count > 0)
                {
                    dgvIndentList.DataSource = dt;
                    dgvIndentList.DataBind();
                }

                dt = new DataTable();
                dt = objBillApp.GetVoucherListByBillID(intBillID);
                if (dt.Rows.Count > 0)
                {
                    dgvVoucherList.DataSource = dt;
                    dgvVoucherList.DataBind();
                }
                
            }
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
                    mrrtkgrandtotal += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblMRRTK")).Text);
                    vouchertkgrandtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblVoucherTK")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion======================================================================================

        #region===== Grid View Row Command Action ======================================================
        protected void dgvBillReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
        }

        protected void dgvDocList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
        }

        protected void dgvChallanList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
        }

        protected void dgvIndentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
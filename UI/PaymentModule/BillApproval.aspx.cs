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
    public partial class BillApproval : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        string filePathForXML, xmlString, xml, challan, mrrid, amount;
        int intUnitid, intPOID, intSuppid, intCOAID, intEnroll, intAction, intEntryType, intLevel, intBillID;
        string strPType, strReffNo, strSupplierName;
        DateTime dteFDate, dteTDate;

        #endregion ====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                ///filePathForXML = Server.MapPath("~/SCM/Data/MilkMRR_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    //File.Delete(filePathForXML);   
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    dt = objBillReg.GetAllUnit();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();
                }
            }
            catch { }
        }

        #region===== Show Button Action============ ===================================================
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            LoadGridSingle();            
        }
        private void LoadGridSingle()
        {
            try
            {
                strReffNo = txtBillRegNo.Text;

                dt = objBillReg.GetBillInfoByBillReg(strReffNo);
                dgvBillReport.DataSource = dt;
                dgvBillReport.DataBind();
            }
            catch { }
        }
        private void LoadGrid()
        {
            intUnitid = int.Parse(ddlUnit.SelectedValue.ToString());
            dteFDate = DateTime.Parse(txtFromDate.Text);
            dteTDate = DateTime.Parse(txtToDate.Text);
            intAction = int.Parse(ddlAction.SelectedValue.ToString());
            intEntryType = 1;
            intLevel = 1;

            dt = objBillReg.GetPaymentApprovalSummaryAllUnitForWeb(intUnitid, dteFDate, dteTDate, intAction, intEntryType, intLevel);
            dgvBillReport.DataSource = dt;
            dgvBillReport.DataBind();
        }
        #endregion=====================================================================================

        protected void dgvBillReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvBillReport.Rows[rowIndex];

            char[] ch1 = { ':', ':' };
            string[] temp1 = (row.FindControl("lblReff") as Label).Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
            string strPOCheck = temp1[0].ToString();
            try { intPOID = int.Parse(temp1[1].ToString());} catch { return; }

            if (e.CommandName == "S")
            {                
                try
                {                        
                    if (strPOCheck == "PO")
                    {
                        Session["pono"] = intPOID.ToString();//intBillID.ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('../SCM/PoDetalisView.aspx');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This is not a PO.');", true);
                        return;
                    }
                }
                catch { }                
            }
            else if (e.CommandName == "SD")
            {
                strSupplierName = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                intBillID = int.Parse((row.FindControl("lblID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + intBillID.ToString() + "');", true);
            }
                            
        }























    }
}
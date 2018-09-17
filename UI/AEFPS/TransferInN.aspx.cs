using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;
using System.IO;
using System.Data;
using System.Xml;
using SAD_BLL.AEFPS;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.AEFPS
{
    public partial class TransferInN : BasePage
    {
        #region ===== Variable Decliaration =======================================================
        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        DataTable dt;

        int intPart, intWHID, intEnroll, intItemID, intToWHID, intInsertBy;        
        decimal numQuantity, numStockQty;
        string strVoucher, xml;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;

        #endregion ================================================================================

        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\TransferInN";
        string stop = "stopping AEFPS\\TransferInN";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

                intPart = 1;
                intWHID = 0;
                intEnroll = int.Parse(hdnEnroll.Value);
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlFromWH.DataTextField = "strWH";
                ddlFromWH.DataValueField = "intInventoryWHID";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();

                intPart = 2;
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlToWHName.DataTextField = "strWH";
                ddlToWHName.DataValueField = "intInventoryWHID";
                ddlToWHName.DataSource = dt;
                ddlToWHName.DataBind();

                try
                {
                    intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                    intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                    dt = obj.GetVoucherForTransfer(intWHID, intToWHID);
                    ddlVoucherCode.DataTextField = "strVoucher";
                    ddlVoucherCode.DataValueField = "intTransferID";
                    ddlVoucherCode.DataSource = dt;
                    ddlVoucherCode.DataBind();
                }
                catch { }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
            }
        }        

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void ddlVoucherCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProduct.DataSource = "";
            dgvProduct.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
        }

        protected void ddlToWHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            VoucherDDL();
            dgvProduct.DataSource = "";
            dgvProduct.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
        }

        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\TransferInN Transfer Item Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intPart = 1;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                strVoucher = ddlVoucherCode.SelectedItem.ToString();
                dt = new DataTable();
                dt = obj.GetTransferOutInReport(intPart, intWHID, intToWHID, strVoucher);
                if (dt.Rows.Count > 0)
                {
                    dgvProduct.DataSource = dt;
                    dgvProduct.DataBind();
                }
                else
                {
                    dgvProduct.DataSource = "";
                    dgvProduct.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
                }
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

        protected decimal totalqty = 0;
        protected decimal totalamount = 0; 
        protected void dgvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblQty")).Text);
                    totalamount += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblAmount")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion======================================================================================

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on AEFPS\\TransferInN Transfer Item", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    intPart = 2;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                intEnroll = int.Parse(hdnEnroll.Value);
                strVoucher = ddlVoucherCode.SelectedItem.ToString();
                intInsertBy = int.Parse(hdnEnroll.Value);
                xml = "";

                //Final In Insert                        
                string message = obj.TransferFinalInsert(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                hdnconfirm.Value = "0";
                LoadGrid();
                VoucherDDL();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
        }

        private void VoucherDDL()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\TransferInN Voucher Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                dt = obj.GetVoucherForTransfer(intWHID, intToWHID);
                ddlVoucherCode.DataTextField = "strVoucher";
                ddlVoucherCode.DataValueField = "intTransferID";
                ddlVoucherCode.DataSource = dt;
                ddlVoucherCode.DataBind();
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






































    }
}
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

namespace UI.AEFPS
{
    public partial class TransferIn : BasePage
    {
        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        Receive_BLL objwh = new Receive_BLL();
        DataTable dt;

        int intID; int intWork;
        string filePathForXML, xmlString = "", xml;
        string masterid, mrrid, code, itemname, uom, sqty, price, tqty, amount;        
        int intPart, intWHID, intCount;
        string strSV, strQRCode, message, strVoucher, strQRCodeOld, strItemID, strItemIDOld, strBarcode;
        
        int intToWHID, intEnroll, intInsertBy;
        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/AEFPS/Data/Transfer_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                //File.Delete(filePathForXML); dgvTransferItem.DataSource = ""; dgvTransferItem.DataBind();
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
                    intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                    dt = obj.GetVoucherForTransferIn(intWHID);
                    ddlVoucher.DataTextField = "strVoucher";
                    ddlVoucher.DataSource = dt;
                    ddlVoucher.DataBind();
                }
                catch { }

                //Voucher();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void ddlVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTransferItem.DataSource = "";
            dgvTransferItem.DataBind();
        }
        private void Voucher()
        {
            try
            {
                intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                dt = obj.GetVoucherForTransferIn(intWHID);
                ddlVoucher.DataTextField = "strVoucher";
                ddlVoucher.DataValueField = "id";
                ddlVoucher.DataSource = dt;
                ddlVoucher.DataBind();
            }
            catch { }
        }
        protected void ddlToWHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                dt = obj.GetVoucherForTransferIn(intWHID);
                ddlVoucher.DataTextField = "strVoucher";
                ddlVoucher.DataSource = dt;
                ddlVoucher.DataBind();

                dgvTransferItem.DataSource = "";
                dgvTransferItem.DataBind();
            }
            catch { }
            //Voucher();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                strVoucher = ddlVoucher.SelectedItem.ToString();
                dt = new DataTable();
                dt = obj.GetDataForTransferIn(intWHID, strVoucher);
                dgvTransferItem.DataSource = dt;
                dgvTransferItem.DataBind();
            }
            catch { }

            //LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                strVoucher = ddlVoucher.SelectedItem.ToString();
                dt = new DataTable();
                dt = obj.GetDataForTransferIn(intWHID, strVoucher);
                dgvTransferItem.DataSource = dt;
                dgvTransferItem.DataBind();
            }
            catch { }
        }
        protected decimal totalqty = 0;
        protected decimal totalval = 0;
        protected void dgvTransferItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalqty += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblTQty")).Text);
                totalval += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblTotalVal")).Text);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 2;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                intEnroll = int.Parse(hdnEnroll.Value);
                strVoucher = ddlVoucher.SelectedItem.ToString();
                intInsertBy = int.Parse(hdnEnroll.Value);
                xml = "";


                //Final In Insert                        
                message = obj.InsertUpdateST(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                hdnconfirm.Value = "0";
                dgvTransferItem.DataSource = ""; dgvTransferItem.DataBind();

                try
                {
                    intWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                    dt = obj.GetVoucherForTransferIn(intWHID);
                    ddlVoucher.DataTextField = "strVoucher";
                    ddlVoucher.DataSource = dt;
                    ddlVoucher.DataBind();
                }
                catch { }
            }
        }






















    }
}
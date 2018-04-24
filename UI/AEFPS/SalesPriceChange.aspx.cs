 
using QRCoder;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class SalesPriceChange : BasePage
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        int enroll, mrrId, intWh, rack = 1, godown = 2, rackType; string ImagePath = "", rackId = "0", receiveQty;

      

        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/AEFPS/Data/Reca__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind(); }
                catch { }
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
            else
            {

            }
        }

        private void DefaltLoad()
        {
            try
            {

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                dt = objRec.DataView(17, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();

            }
            catch { }

        }

        protected void ddlMrrNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
           

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (int.Parse(hdnConfirm.Value) > 0)
                {

                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());

                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtSalesQty = row.FindControl("txtReceQty") as TextBox;
                    TextBox txtSalesPrice = row.FindControl("txtSalesPrice") as TextBox;
                    TextBox txtPrintQty = row.FindControl("txtPrtQty") as TextBox;
                    TextBox txtDteDate = row.FindControl("txtExpireDate") as TextBox;
                    Label lblItemMaster = row.FindControl("lblItemMaster") as Label;
                    Label lblRemainQty = row.FindControl("lblRemaingQty") as Label;
                    Label lblItem = row.FindControl("lblItemId") as Label;
                    Label lblItemName = row.FindControl("lblItemName") as Label;
                    string itemid = lblItem.Text.ToString();
                    string ItemName = lblItemName.Text.ToString();
                    string itmMaster = lblItemMaster.Text.ToString();
                    string ReceiveQty = txtSalesQty.Text.ToString();
                    string salseprice = txtSalesPrice.Text.ToString();
                    string dteDate = txtDteDate.Text.ToString();
                    decimal reminQty = decimal.Parse(lblRemainQty.Text.ToString());
                    string xmlunit = "<voucher><voucherentry itemId=" + '"' + itemid + '"' + " ItmMaster=" + '"' + itmMaster + '"' + " SalesPrice=" + '"' + salseprice + '"' + " ReceiveQty=" + '"' + ReceiveQty + '"' + " rackId=" + '"' + rackId + '"' + " RackType=" + '"' + rackType.ToString() + '"' + " dteDate=" + '"' + dteDate + '"' + "/></voucher>".ToString();
                     
                    if (decimal.Parse(salseprice) > 0)
                    {
                        string mrtg = objRec.MrrReceiveInsert(4, xmlunit, intWh, mrrId, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Receive Quantity Grater then Mrr Quantity);", true);
                    }

                    dt = objRec.DataView(3, "", intWh, mrrId, DateTime.Now, enroll);
                    dgvReceive.DataSource = dt;
                    dgvReceive.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Rack Type');", true);

                }
            }
            catch { }
        }

    }
}
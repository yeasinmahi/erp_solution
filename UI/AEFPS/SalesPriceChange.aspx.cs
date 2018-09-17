
using Flogging.Core;
using GLOBAL_BLL;
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
        int enroll, mrrId, intWh; string  receiveQty;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\SalesPriceChange";
        string stop = "stopping AEFPS\\SalesPriceChange";


        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
            else
            {

            }
        }

        private void DefaltLoad()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\SalesPriceChange Sales Price change Item Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(17, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                dt = objRec.DataView(18, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();

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

        protected void ddlMrrNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(18, "", intWh, mrrId, DateTime.Now, enroll);
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
                dt = objRec.DataView(17, "", intWh, 0, DateTime.Now, enroll);
                ddlMrrNo.DataSource = dt;
                ddlMrrNo.DataTextField = "strName";
                ddlMrrNo.DataValueField = "Id";
                ddlMrrNo.DataBind();

                mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());
                dt = objRec.DataView(18, "", intWh, mrrId, DateTime.Now, enroll);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }

      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\SalesPriceChange Sales Price change Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (int.Parse(hdnConfirm.Value) > 0)
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());

                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                     
                    TextBox txtSalesPrice = row.FindControl("txtSalesPrice") as TextBox;
                    
                    TextBox txtDteDate = row.FindControl("txtExpireDate") as TextBox;
                    Label lblItemMaster = row.FindControl("lblItemMaster") as Label;
                    Label lblAutoID = row.FindControl("lblAutoID") as Label;
                    Label lblStockQty = row.FindControl("lblStockQty") as Label;

                    Label lblItem = row.FindControl("lblItemId") as Label;
                    Label lblItemName = row.FindControl("lblItemName") as Label;
                    string itemid = lblItem.Text.ToString();
                    string ItemName = lblItemName.Text.ToString();
                    string itmMaster = lblItemMaster.Text.ToString(); 
                    string salseprice = txtSalesPrice.Text.ToString();
                    string dteDate = txtDteDate.Text.ToString();
                    string strAutoID = lblAutoID.Text.ToString();
                    decimal stockQty = decimal.Parse(lblStockQty.Text.ToString());

                    string xmlunit = "<voucher><voucherentry itemId=" + '"' + itemid + '"' + " ItmMaster=" + '"' + itmMaster + '"' + " SalesPrice=" + '"' + salseprice + '"' + " strAutoID=" + '"' + strAutoID + '"'  + " dteDate=" + '"' + dteDate + '"' + "/></voucher>".ToString();
                     
                    if (decimal.Parse(salseprice) > 0 && stockQty>0)
                    {
                        string mrtg = objRec.MrrReceiveInsert(19, xmlunit, intWh, mrrId, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Receive Quantity Grater then Mrr Quantity);", true);
                    }

                    dt = objRec.DataView(18, "", intWh, mrrId, DateTime.Now, enroll);
                    dgvReceive.DataSource = dt;
                    dgvReceive.DataBind();

                }

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
}
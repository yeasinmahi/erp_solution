using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class FinishedGoodEntry : System.Web.UI.Page
    {
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "";

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();

                     
                }

            }
            else { }

        }

        protected void btnViewProductionOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string dteFrom = txtFromDate.Text.ToString();
                string dteTo = txtToDate.Text.ToString();
                DateTime dteDate = DateTime.Parse(txtDate.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(6, xmlData, intwh, BomId, dteDate, enroll);
                dgvBom.DataSource = dt;
                dgvBom.DataBind();
            }
            catch{ }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch { }
        }

        protected void btnSaveFG_Click(object sender, EventArgs e)
        {
            try
            {
               // lblProductID,lblProductName,lblBomName,lblBatch,lblStartTime,lblEndTime,lblInvoice,lblSrNO,lblQuantity,lblLine
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductID = row.FindControl("lblProductID") as Label;
                Label lblProductName = row.FindControl("lblProductName") as Label;
                Label lblBomName = row.FindControl("lblBomName") as Label;
                Label lblBatch = row.FindControl("lblBatch") as Label;
                Label lblStartTime = row.FindControl("lblStartTime") as Label;
                Label lblEndTime = row.FindControl("lblEndTime") as Label;
                Label lblInvoice = row.FindControl("lblInvoice") as Label;
                Label lblSrNO = row.FindControl("lblSrNO") as Label;
                Label lblQuantity = row.FindControl("lblQuantity") as Label;
                Label lblLine = row.FindControl("lblLine") as Label;
                string productID = lblProductID.Text.ToString();
                string productName = lblProductName.Text.ToString();
                string whid = ddlWH.SelectedValue.ToString();
                string bomName = lblBomName.Text.ToString();
                string batchName = lblBatch.Text.ToString();
                string startTime = lblStartTime.Text.ToString();
                string endTime = lblEndTime.Text.ToString();
                string invoice = lblInvoice.Text.ToString();
                string srNo = lblSrNO.Text.ToString();
                string quantity = lblQuantity.Text.ToString();
                string line = lblLine.Text.ToString();

                



                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + productID + "','" + productName.ToString() + "','" + bomName + "','" + batchName + "','" + startTime + "','" + endTime + "','" + invoice.ToString() + "','" + srNo + "','" + quantity + "','" + whid + "');", true);

            }
            catch { }

        }
    }
}
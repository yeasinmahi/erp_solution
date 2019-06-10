using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.BOM
{
    public partial class FinishedGoodEntry : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId;
        private string xmlData;
        private int CheckItem = 1, intWh;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, Enroll);
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

        protected void btnInactive_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductID = row.FindControl("lblProductID") as Label;

                int producttionID = int.Parse(lblProductID.Text);
                string msg = objBom.BomPostData(17, xmlString, intWh, producttionID, DateTime.Now, Enroll);
                if (msg.ToLower().Contains("successful"))
                {
                    Toaster(msg, Common.TosterType.Success);
                    LoadGrid();

                }
                else
                {
                    Toaster(msg, Common.TosterType.Error);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnViewProductionOrder_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public void LoadGrid()
        {
            try
            {
                string dteFrom = txtFromDate.Text;
                string dteTo = txtToDate.Text;
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteDate = DateTime.Now;
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>";
                dt = objBom.GetBomData(6, xmlData, intwh, BomId, dteDate, Enroll);
                dgvBom.DataSource = dt;
                dgvBom.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvBom.UnLoad();
        }

        protected void btnSaveFG_Click(object sender, EventArgs e)
        {
            try
            {
                // lblProductID,lblProductName,lblBomName,lblBatch,lblStartTime,lblEndTime,lblInvoice,lblSrNO,lblQuantity,lblLine
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductId = row.FindControl("lblProductID") as Label;
                Label lblProductName = row.FindControl("lblProductName") as Label;
                Label lblBomName = row.FindControl("lblBomName") as Label;
                Label lblBatch = row.FindControl("lblBatch") as Label;
                Label lblStartTime = row.FindControl("lblStartTime") as Label;
                Label lblEndTime = row.FindControl("lblEndTime") as Label;
                Label lblInvoice = row.FindControl("lblInvoice") as Label;
                Label lblSrNo = row.FindControl("lblSrNO") as Label;
                Label lblQuantity = row.FindControl("lblQuantity") as Label;
                Label lblLine = row.FindControl("lblLine") as Label;
                Label lblItem = row.FindControl("lblItemID") as Label;
                string productId = lblProductId.Text;
                string product = lblProductName.Text;
                string whid = ddlWH.SelectedValue;
                string bom = lblBomName.Text;
                string batchName = lblBatch.Text;
                string startTime = lblStartTime.Text;
                string endTime = lblEndTime.Text;
                string invoice = lblInvoice.Text;
                string srNo = lblSrNo.Text;
                string quantity = lblQuantity.Text;
                string line = lblLine.Text;
                string itemId = lblItem.Text;
                string productName = product.Replace("\"", string.Empty).Replace("'", string.Empty);
                string bomName = bom.Replace("\"", string.Empty).Replace("'", string.Empty);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "Viewdetails('" + productId + "','" + productName + "','" + bomName + "','" + batchName + "','" +
                    startTime + "','" + endTime + "','" + invoice + "','" + srNo + "','" + quantity + "','" + whid +
                    "','" + itemId + "');", true);
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
    }
}
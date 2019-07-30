using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.BOM
{
    public partial class ProductionApproval : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId; private string xmlData;
        private int CheckItem = 1, intWh; private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";
        private InventoryTransfer_BLL InventoryTransfer_Obj = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objBom.GetBomData(20, xmlData, intwh, BomId, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["Id"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
            }
            else { }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductiontID = row.FindControl("lblProductiontID") as Label;
                Label lblItemID = row.FindControl("lblItemID") as Label;
                Label lblUnitID = row.FindControl("lblUnitID") as Label;
                int intProductiontID = int.Parse(lblProductiontID.Text);
                int ItemID = int.Parse(lblItemID.Text);
                int UnitID = int.Parse(lblUnitID.Text);
                

                string msg = InventoryTransfer_Obj.UpdateProductionApprove(ItemID, UnitID, intProductiontID, Enroll, 1);
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

        protected void btnClosed_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductiontID = row.FindControl("lblProductiontID") as Label;
                Label lblItemID = row.FindControl("lblItemID") as Label;
                Label lblUnitID = row.FindControl("lblUnitID") as Label;
                // int ProductID = int.Parse(lblProductID.Text);
                int intProductiontID = int.Parse(lblProductiontID.Text);
                int ItemID = int.Parse(lblItemID.Text);
                int UnitID = int.Parse(lblUnitID.Text);
                string msg = InventoryTransfer_Obj.UpdateProductionApprove(ItemID, UnitID, intProductiontID, Enroll, 2);
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

        protected void btnclose_Click(object sender, EventArgs e)
        {

            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Label lblProductiontID = row.FindControl("lblProductiontID") as Label;
            Label lblItemID = row.FindControl("lblItemID") as Label;
            Label lblUnitID = row.FindControl("lblUnitID") as Label;
            // int ProductID = int.Parse(lblProductID.Text);
            int intProductiontID = int.Parse(lblProductiontID.Text);
            int ItemID = int.Parse(lblItemID.Text);
            int UnitID = int.Parse(lblUnitID.Text);
            string msg = InventoryTransfer_Obj.UpdateProductionApprove(ItemID, UnitID, intProductiontID, Enroll, 2);
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

        public void LoadGrid()
        {
            try
            {
                string dteFrom = txtFromDate.Text;
                string dteTo = txtToDate.Text;
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteDate = DateTime.Now;
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>";

                int appType = Convert.ToInt32(rdoApprove.SelectedItem.Value);
                if (appType == 1)
                {
                    dgvBom.Columns[12].Visible = true;
                    dgvBom.Columns[13].Visible = false;
                }
                else if (appType == 2)
                {
                    dgvBom.Columns[12].Visible = true;
                    dgvBom.Columns[13].Visible = true;
                }
                else if (appType == 3)
                {
                    dgvBom.Columns[12].Visible = false;
                    dgvBom.Columns[13].Visible = false;
                }
                dt = objBom.GetBomData(19, xmlData, intwh, BomId, dteDate, appType);
                if (dt.Rows.Count > 0)
                {
                    dgvBom.DataSource = dt;
                    dgvBom.DataBind();
                }
                else
                {
                    dgvBom.UnLoad();
                    Toaster("There is no data", "Production Approval", Common.TosterType.Warning);
                }


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



    }
}
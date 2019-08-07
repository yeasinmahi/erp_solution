using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class ProductionOrderApproveNreject : System.Web.UI.Page
    {
        #region INIT
        private ProductionOrderBLL objPOBLL = new ProductionOrderBLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId,Enroll;
        private string xmlData;
        private int CheckItem = 1, intWh;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropdown();
            }
            else { }
        }
        #endregion

        #region Event
        protected void ddlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnShowProductionOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation() == true)
                {
                    LoadGridview();
                }

            }
            catch (Exception ex)
            {
                string sms = "Show Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }

        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblProductiontID = row.FindControl("lblProductiontID") as Label;
                HiddenField hfProductID = row.FindControl("hfProductID") as HiddenField;
                HiddenField hfUnitID = row.FindControl("hfUnitID") as HiddenField;
                int intProductiontID = int.Parse(lblProductiontID.Text);
                int ItemID = int.Parse(hfProductID.Value);
                int UnitID = int.Parse(hfUnitID.Value);


                //string msg = InventoryTransfer_Obj.UpdateProductionApprove(ItemID, UnitID, intProductiontID, Enroll, 1);
                //if (msg.ToLower().Contains("successful"))
                //{
                //    Toaster(msg, Common.TosterType.Success);
                //    LoadGrid();
                //}
                //else
                //{
                //    Toaster(msg, Common.TosterType.Error);
                //}

            }
            catch (Exception ex)
            {
                // Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnShowDetails_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Method
        private void LoadWarehouse()
        {
            DataTable dtWareHouse = new DataTable();
            try
            {
                Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dtWareHouse = objPOBLL.GetWareHouse(2, xmlData, intwh, BomId, DateTime.Now, Enroll);
                if (dtWareHouse.Rows.Count > 0)
                {
                    ddlWareHouse.DataSource = dtWareHouse;
                    ddlWareHouse.DataTextField = "strName";
                    ddlWareHouse.DataValueField = "Id";
                    ddlWareHouse.DataBind();
                }
                ddlWareHouse.Items.Insert(0, new ListItem("--- Select Ware House ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Ware House Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadUnit()
        {
            try
            {
                DataTable dtUnit = new DataTable();
                dtUnit = objPOBLL.GetUnitByWH(4, xmlString, intwh, 0, DateTime.Now, Enroll);
                if (dtUnit.Rows.Count > 0)
                {
                    hfUnitID.Value = dtUnit.Rows[0]["intunit"].ToString();
                    Session["unit"] = hfUnitID.Value.ToString();

                }
            }
            catch (Exception ex)
            {
                string sms = "Unit Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void FillDropdown()
        {
            try
            {
                LoadWarehouse();
                intwh = Convert.ToInt32(ddlWareHouse.SelectedValue) > 0 ? Convert.ToInt32(ddlWareHouse.SelectedValue) : 0;
                LoadUnit();
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadGridview()
        {
            try
            {
                string dteFrom = txtFromDate.Text;
                string dteTo = txtToDate.Text;
                //DateTime dteFrom = DateTime.ParseExact(txtFromDate.Text,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                //DateTime dteTo = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                intwh = int.Parse(ddlWareHouse.SelectedValue);
                DateTime dteDate = DateTime.Now;
                string xmlData = "<PrOr><PrOr dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></PrOr>";

                int appType = Convert.ToInt32(ddlDataFor.SelectedValue);
                if (appType == 1)
                {
                    dgvBom.Columns[12].Visible = true;//approve btn
                    dgvBom.Columns[13].Visible = false;//reject btn
                }
                else if (appType == 2)
                {
                    dgvBom.Columns[12].Visible = true;//approve btn
                    dgvBom.Columns[13].Visible = true;//reject btn
                }
                else if (appType == 3)
                {
                    dgvBom.Columns[12].Visible = false;//approve btn
                    dgvBom.Columns[13].Visible = false;//reject btn
                }
                dt = objPOBLL.ProductionOrderApproveReject(6, xmlData, intwh, BomId, dteDate, appType);
                if (dt.Rows.Count > 0)
                {
                    dgvBom.DataSource = dt;
                    dgvBom.DataBind();
                }
                else
                {
                    dgvBom.DataSource = null;
                    dgvBom.DataBind();
                }


            }
            catch (Exception ex)
            {
                string sms = "Gridview Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private bool Validation()
        {
            if (ddlWareHouse.SelectedValue == "-1")
            {
                ddlWareHouse.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Warehouse.');", true);
                return false;
            }

            if (ddlDataFor.SelectedValue == "-1")
            {
                ddlDataFor.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Data For.');", true);
                return false;
            }

            if (string.IsNullOrEmpty(txtFromDate.Text))
            {
                txtFromDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter From Date.');", true);
                return false;
            }

            if (string.IsNullOrEmpty(txtToDate.Text))
            {
                txtToDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter To Date.');", true);
                return false;
            }

            return true;
        }
        #endregion
    }
}
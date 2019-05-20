using SCM_BLL;
using SCM_DAL.ItemManagerStoreTDSTableAdapters;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ItemManagerPurchasePopUp : BasePage
    {
        #region INIT
        private MasterMaterialBLL bll = new MasterMaterialBLL();
        private DataTable dt;
        CommonTableAdapter commonTableAdapter = new CommonTableAdapter();
        ItemAddtoMasterFromTempTableAdapter itemAddtoMasterFromTempTableAdapter = new ItemAddtoMasterFromTempTableAdapter();
        private int intPart, intAutoID, intInsertBy, intLeadTime;
        private string strHSCode, strPOrigin, strPurchaseDescription;
        private decimal numMinOrderQuantity;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnItemID.Value = Request.QueryString["Id"];
                FillDropdown();
                LoadPopUp();
            }
        }
        #endregion

        #region Event
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validation() == true)
                {
                    FillPurchaseDeptData();
                    if (hdnconfirm.Value == "1")
                    {
                        dt = new DataTable();
                        dt = itemAddtoMasterFromTempTableAdapter.UpdateItemAddtoMasterFromTempTable(intAutoID, intPart, null, null, null, null, null, null, null, strHSCode,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, intInsertBy, DateTime.Now, true, false,
                            false, null, strPurchaseDescription, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            intLeadTime, numMinOrderQuantity, strPOrigin,null,null,null,null,null,null,null,null);

                        if (dt.Rows.Count > 0)
                        {
                            string msg = dt.Rows[0]["msg"].ToString();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                            hdnconfirm.Value = "0";
                            hdnItemID.Value = "0";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            
            
        }
        #endregion 

        #region Method
        private void FillDropdown()
        {
            DataTable dtItemUoM = new DataTable();
            DataTable dtOthersUoM = new DataTable();
            DataTable dtPalnt = new DataTable();
            try
            {
                dtItemUoM = commonTableAdapter.GetItemUoMData();
                dtOthersUoM = commonTableAdapter.GetOthersUoM();
                dtPalnt = commonTableAdapter.GetPlant(Convert.ToInt32(hdnUnit.Value));

                ddlUoMN.DataSource = dtItemUoM;
                ddlUoMN.DataTextField = "strUoM";
                ddlUoMN.DataValueField = "intUoM";
                ddlUoMN.DataBind();

                ddlAlterUoM.DataSource = dtItemUoM;
                ddlAlterUoM.DataTextField = "strUoM";
                ddlAlterUoM.DataValueField = "intUoM";
                ddlAlterUoM.DataBind();

                ddlIsMRP.Items.Insert(0, new ListItem("---Select Is MRP---", "-1"));
                ddlIsMRP.Items.Insert(1, new ListItem("Yes", "1"));
                ddlIsMRP.Items.Insert(2, new ListItem("No", "0"));

                ddlLengthUom.DataSource = dtOthersUoM;
                ddlLengthUom.DataTextField = "strUoM";
                ddlLengthUom.DataValueField = "intUoM";
                ddlLengthUom.DataBind();

                ddlWidthUom.DataSource = dtOthersUoM;
                ddlWidthUom.DataTextField = "strUoM";
                ddlWidthUom.DataValueField = "intUoM";
                ddlWidthUom.DataBind();

                ddlHeightUoM.DataSource = dtOthersUoM;
                ddlHeightUoM.DataTextField = "strUoM";
                ddlHeightUoM.DataValueField = "intUoM";
                ddlHeightUoM.DataBind();

                ddlIdUom.DataSource = dtOthersUoM;
                ddlIdUom.DataTextField = "strUoM";
                ddlIdUom.DataValueField = "intUoM";
                ddlIdUom.DataBind();

                ddlOdUom.DataSource = dtOthersUoM;
                ddlOdUom.DataTextField = "strUoM";
                ddlOdUom.DataValueField = "intUoM";
                ddlOdUom.DataBind();

                ddlPlant.DataSource = dtPalnt;
                ddlPlant.DataTextField = "strPlantName";
                ddlPlant.DataValueField = "intPlantID";
                ddlPlant.DataBind();

                ddlLengthUom.Items.Insert(0, new ListItem("---Select Length UoM---", "-1"));
                ddlHeightUoM.Items.Insert(0, new ListItem("---Select Height UoM---", "-1"));
                ddlWidthUom.Items.Insert(0, new ListItem("---Select ddlWidth UoM---", "-1"));
                ddlIdUom.Items.Insert(0, new ListItem("---Select ID UoM---", "-1"));
                ddlOdUom.Items.Insert(0, new ListItem("---Select OD UoM---", "-1"));
                ddlPlant.Items.Insert(0, new ListItem("---Select Plant---", "-1"));
            }
            catch { }
        }
        private void LoadPopUp()
        {
            dt = new DataTable();
            try
            {
                intAutoID = int.Parse(hdnItemID.Value);
                dt = itemAddtoMasterFromTempTableAdapter.GetItemDataForPurchaseApprover(intAutoID);
                if(dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        hfStoreMasterId.Value = dt.Rows[0]["intMasterID"].ToString();
                        txtItemName.Text = dt.Rows[0]["strItemName"].ToString();
                        if(!string.IsNullOrEmpty(dt.Rows[0]["intUOM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intUOM"]) > 0)
                        {
                            ddlUoMN.SelectedValue = dt.Rows[0]["intUOM"].ToString();
                        }
                        else
                        {
                            ddlUoMN.SelectedValue = "0";
                        }
                        txtColour.Text = !string.IsNullOrEmpty(dt.Rows[0]["strColour"].ToString()) ? dt.Rows[0]["strColour"].ToString() : string.Empty;
                        txtOriginn.Text = !string.IsNullOrEmpty(dt.Rows[0]["strOrigin"].ToString()) ? dt.Rows[0]["strOrigin"].ToString() : string.Empty;
                        txtPartNo.Text = !string.IsNullOrEmpty(dt.Rows[0]["strPart"].ToString()) ? dt.Rows[0]["strPart"].ToString() : string.Empty;
                        txtOtherSpec.Text = !string.IsNullOrEmpty(dt.Rows[0]["strOtherSpec"].ToString()) ? dt.Rows[0]["strOtherSpec"].ToString() : string.Empty;
                        txtModelNo.Text = !string.IsNullOrEmpty(dt.Rows[0]["strModel"].ToString()) ? dt.Rows[0]["strModel"].ToString() : string.Empty;
                        txtBrand.Text = !string.IsNullOrEmpty(dt.Rows[0]["strBrand"].ToString()) ? dt.Rows[0]["strBrand"].ToString() : string.Empty;
                        //txtLength.Text = !string.IsNullOrEmpty(dt.Rows[0]["numLength"].ToString()) ? dt.Rows[0]["numLength"].ToString() : string.Empty;
                        txtLength.Text = Convert.ToDecimal(dt.Rows[0]["numLength"].ToString())>0 ? dt.Rows[0]["numLength"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intlengthUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intlengthUoM"]) > 0)
                        {
                            ddlLengthUom.SelectedValue = dt.Rows[0]["intlengthUoM"].ToString();
                        }
                        else
                        {
                            ddlLengthUom.SelectedValue = "-1";
                        }
                        // txtWidth.Text = !string.IsNullOrEmpty(dt.Rows[0]["numWidth"].ToString()) ? dt.Rows[0]["numWidth"].ToString() : string.Empty;
                        txtWidth.Text = Convert.ToDecimal(dt.Rows[0]["numWidth"].ToString())>0 ? dt.Rows[0]["numWidth"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intWidthUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intWidthUoM"]) > 0)
                        {
                            ddlWidthUom.SelectedValue = dt.Rows[0]["intWidthUoM"].ToString();
                        }
                        else
                        {
                            ddlWidthUom.SelectedValue = "-1";
                        }
                        //txtHight.Text = !string.IsNullOrEmpty(dt.Rows[0]["numHight"].ToString()) ? dt.Rows[0]["numHight"].ToString() : string.Empty;
                        txtHight.Text = Convert.ToDecimal(dt.Rows[0]["numHight"].ToString())>0 ? dt.Rows[0]["numHight"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intHightUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intHightUoM"]) > 0)
                        {
                            ddlHeightUoM.SelectedValue = dt.Rows[0]["intHightUoM"].ToString();
                        }
                        else
                        {
                            ddlHeightUoM.SelectedValue = "-1";
                        }
                        //TextInnerDia.Text = !string.IsNullOrEmpty(dt.Rows[0]["numInnerDia"].ToString()) ? dt.Rows[0]["numInnerDia"].ToString() : string.Empty;
                        TextInnerDia.Text = Convert.ToDecimal(dt.Rows[0]["numInnerDia"].ToString())>0 ? dt.Rows[0]["numInnerDia"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intIDUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intIDUoM"]) > 0)
                        {
                            ddlIdUom.SelectedValue = dt.Rows[0]["intIDUoM"].ToString();
                        }
                        else
                        {
                            ddlIdUom.SelectedValue = "-1";
                        }
                        //TextOuterDia.Text = !string.IsNullOrEmpty(dt.Rows[0]["numOuterDia"].ToString()) ? dt.Rows[0]["numOuterDia"].ToString() : string.Empty;
                        TextOuterDia.Text = Convert.ToDecimal(dt.Rows[0]["numOuterDia"].ToString())>0 ? dt.Rows[0]["numOuterDia"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intODUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intODUoM"]) > 0)
                        {
                            ddlOdUom.SelectedValue = dt.Rows[0]["intODUoM"].ToString();
                        }
                        else
                        {
                            ddlOdUom.SelectedValue = "-1";
                        }
                        //TextGrossWt.Text = !string.IsNullOrEmpty(dt.Rows[0]["numGrossWt"].ToString()) ? dt.Rows[0]["numGrossWt"].ToString() : string.Empty;
                        //TextNetWt.Text = !string.IsNullOrEmpty(dt.Rows[0]["numNetWt"].ToString()) ? dt.Rows[0]["numNetWt"].ToString() : string.Empty;
                        TextGrossWt.Text = Convert.ToDecimal(dt.Rows[0]["numGrossWt"].ToString())>0 ? dt.Rows[0]["numGrossWt"].ToString() : string.Empty;
                        TextNetWt.Text = Convert.ToDecimal(dt.Rows[0]["numNetWt"].ToString())>0 ? dt.Rows[0]["numNetWt"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intAlterUoM"].ToString()) && Convert.ToInt32(dt.Rows[0]["intAlterUoM"]) > 0)
                        {
                            ddlAlterUoM.SelectedValue = dt.Rows[0]["intAlterUoM"].ToString();
                        }
                        else
                        {
                            ddlAlterUoM.SelectedValue = "-1";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["intPlantID"].ToString()) && Convert.ToInt32(dt.Rows[0]["intPlantID"]) > 0)
                        {
                            ddlPlant.SelectedValue = dt.Rows[0]["intPlantID"].ToString();
                        }
                        else
                        {
                            ddlPlant.SelectedValue = "-1";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["isMRP"].ToString()) && Convert.ToInt32(dt.Rows[0]["isMRP"]) > -1)
                        {
                            ddlIsMRP.SelectedValue = dt.Rows[0]["isMRP"].ToString();
                        }
                        else
                        {
                            ddlIsMRP.SelectedValue = "-1";
                        }
                        txtReOrderPoint.Text = !string.IsNullOrEmpty(dt.Rows[0]["numReorderPoint"].ToString()) ? dt.Rows[0]["numReorderPoint"].ToString() : string.Empty;
                        txtMinStock.Text = Convert.ToInt32(dt.Rows[0]["numMinimumStock"])>0 ? dt.Rows[0]["numMinimumStock"].ToString() : string.Empty;
                        txtMaxStock.Text = Convert.ToInt32(dt.Rows[0]["numMaximumStock"].ToString())>0 ? dt.Rows[0]["numMaximumStock"].ToString() : string.Empty;
                        txtSaftyStock.Text = Convert.ToInt32(dt.Rows[0]["numSafetyStock"].ToString())>0 ? dt.Rows[0]["numSafetyStock"].ToString() : string.Empty;
                    }
                }

               
            }
            catch { }
        }
        private void FillPurchaseDeptData()
        {
            try
            {
                intPart = 3;
                intAutoID = Convert.ToInt32(hfStoreMasterId.Value);
                strHSCode = !string.IsNullOrEmpty(txtCode.Text) ? txtCode.Text.Trim() : string.Empty;
                strPOrigin = !string.IsNullOrEmpty(txtPOrigin.Text) ? txtPOrigin.Text.Trim() : string.Empty;
                numMinOrderQuantity = !string.IsNullOrEmpty(txtMinOrderQty.Text) ? Convert.ToDecimal(txtMinOrderQty.Text) : 0;
                intLeadTime = !string.IsNullOrEmpty(txtLeadTime.Text) ? Convert.ToInt32(txtLeadTime.Text) : 0;
                strPurchaseDescription = !string.IsNullOrEmpty(txtPurchaseDescription.Text) ? txtPurchaseDescription.Text : string.Empty;
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
            }
            catch (Exception ex)
            {
               
            }
        }
        private bool Validation()
        {
            //if (string.IsNullOrEmpty(txtPurchaseDescription.Text))
            //{
            //    txtPurchaseDescription.Focus();
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Purchase Description');", true);
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtCode.Text))
            //{
            //    txtCode.Focus();
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter HS Code');", true);
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtPOrigin.Text))
            //{
            //    txtPOrigin.Focus();
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Purchase Origin');", true);
            //    return false;
            //}
            if (string.IsNullOrEmpty(txtLeadTime.Text))
            {
                txtLeadTime.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Lead Time');", true);
                return false;
            }


            return true;
        }
        private void Clear()
        {
            txtItemName.Text = string.Empty;
            txtColour.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtOriginn.Text = string.Empty;
            txtOtherSpec.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtWidth.Text = string.Empty;
            txtHight.Text = string.Empty;
            TextInnerDia.Text = string.Empty;
            TextOuterDia.Text = string.Empty;
            TextGrossWt.Text = string.Empty;
            TextNetWt.Text = string.Empty;
            txtReOrderPoint.Text = string.Empty;
            txtMinStock.Text = string.Empty;
            txtSaftyStock.Text = string.Empty;
            txtMaxStock.Text = string.Empty;
            ddlUoMN.SelectedValue = "0";
            ddlLengthUom.SelectedValue = "-1";
            ddlWidthUom.SelectedValue = "-1";
            ddlHeightUoM.SelectedValue = "-1";
            ddlIdUom.SelectedValue = "-1";
            ddlOdUom.SelectedValue = "-1";
            ddlAlterUoM.SelectedValue = "0";
            ddlPlant.SelectedValue = "-1";
            ddlIsMRP.SelectedValue = "-1";
            txtCode.Text = string.Empty;
            txtPOrigin.Text = string.Empty;
            txtMinOrderQty.Text = string.Empty;
            txtLeadTime.Text = string.Empty;
            txtPurchaseDescription.Text = string.Empty;
        }
        #endregion
    }
}
using SCM_BLL;
using SCM_DAL.ItemManagerStoreTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ItemManagerStoreNew : BasePage
    {
        #region INIT
        private MasterMaterialBLL bll = new MasterMaterialBLL();
        CommonTableAdapter commonTableAdapter = new CommonTableAdapter();
        ItemAddtoMasterFromTempTableAdapter itemAddtoMasterFromTempTableAdapter = new ItemAddtoMasterFromTempTableAdapter();
        private DataTable dt;
        private int intPart, intItemUOM, intLengthUoM, intWidthUoM, intHeightUoM, intInnerDiaUoM, intOuterDiaUoM, intAlterUoM, 
            intPlant, intIsMRR, intUserID;
        private string strMaterialName, strColour, strOrigin, strPartNumber, strOtherSpecification, strBrand, strModelNumber
            , strDescription, strItemUoM, strAlterUoM, strItemFullName,strPlant;
        private decimal numGrossWeight, numNetWeight, numReorderPoint, numMinStock, numMaxStock, numSaftyStock, numLength, 
            numWidth, numHeight, numInnerDia, numOuterDia;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                //intInsertBy = int.Parse(hdnEnroll.Value);

               // hdnItemID.Value = Request.QueryString["Id"];
               // intAutoID = int.Parse(hdnItemID.Value);
                FillDropdown();
            }
        }
        #endregion

        #region Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch;
            strSearch = txtSearch.Text;

            dt = new DataTable();
            dt = bll.GetItemListReport(strSearch);

            if (dt.Rows.Count > 0)
            {
                ItemList.DataSource = dt;
                ItemList.DataTextField = "strMaterialFullName";
                ItemList.DataValueField = "intMaterialID";
                ItemList.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Item Found !!');", true);
                ItemList.DataSource = "";
                ItemList.DataBind();
            }
        }
        protected void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //intUnitID = int.Parse(hdnUnit.Value.ToString());
                //intMasterID = int.Parse(ItemList.SelectedValue.ToString());

                //dt = new DataTable();
                //dt = bll.GetUnitCheck(intMasterID, intUnitID);
                //if (dt.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This item already included in this Unit.');", true);
                //    return;
                //}
                //dt = new DataTable();
                //dt = bll.GetMaterialDetails(intMasterID);

                //if (dt.Rows.Count == 1)
                //{
                //    hdnMaterialId.Value = intMasterID.ToString();
                //    txtBaseName.Text = dt.Rows[0]["strMaterialName"].ToString();
                //    txtDescription.Text = dt.Rows[0]["strDescription"].ToString();
                //    txtPart.Text = dt.Rows[0]["strPartNo"].ToString();
                //    txtModel.Text = dt.Rows[0]["strModelNo"].ToString();
                //    txtSerial.Text = dt.Rows[0]["strSerialNo"].ToString();
                //    txtBrand.Text = dt.Rows[0]["strBrand"].ToString();
                //    //ddlUOM.Text = dt.Rows[0]["strUoM"].ToString();

                //    txtBaseName.Enabled = false;
                //    txtDescription.Enabled = false;
                //    txtPart.Enabled = false;
                //    txtModel.Enabled = false;
                //    txtSerial.Enabled = false;
                //    txtBrand.Enabled = false;
                //    ddlUOM.Enabled = false;
                //}
                //else
                //{
                //    hdnMaterialId.Value = "0";
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something wrong.');", true);
                //}
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation() == true)
                {
                    FillDetailData();
                    if (hdnconfirm.Value == "1")
                    {
                        dt = itemAddtoMasterFromTempTableAdapter.InsertItemAddtoMasterTempTable(null,intPart,null,strMaterialName,strPartNumber,
                            strModelNumber,strBrand,strOtherSpecification,strOrigin,null,numMinStock,numMaxStock,numSaftyStock,intIsMRR,
                            numReorderPoint,intItemUOM,strItemUoM,intAlterUoM,strAlterUoM,intPlant,null,null,intUserID,true,intUserID,DateTime.Now,
                            null,null,null,null,false,false,false,strItemFullName,null,numLength,intLengthUoM,numWidth,intWidthUoM,numHeight,intHeightUoM,
                            numInnerDia,intInnerDiaUoM,numOuterDia,intOuterDiaUoM,strColour,numGrossWeight,numNetWeight,strOtherSpecification,
                            null,null,null,null,null,null,null,null,null,null,strPlant);


                        if (dt.Rows.Count > 0)
                        {
                            Clear();
                            string msg = dt.Rows[0]["msg"].ToString();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

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
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                txtItemName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Base Name must be filled.');", true);
                return false;
            }

            if (ddlUoMN.SelectedValue == "0")
            {
                ddlUoMN.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Product UoM');", true);
                return false;
            }
            return true;
        }
        private void FillDetailData()
        {
            try
            {
                intUserID = Convert.ToInt32(hdnEnroll.Value);
                strMaterialName = txtItemName.Text;
                strColour = !string.IsNullOrEmpty(txtColour.Text) ? txtColour.Text : string.Empty;
                strOrigin = !string.IsNullOrEmpty(txtOriginn.Text) ? txtOriginn.Text : string.Empty;
                strPartNumber = !string.IsNullOrEmpty(txtPartNo.Text) ? txtPartNo.Text : string.Empty;
                strOtherSpecification = !string.IsNullOrEmpty(txtOtherSpec.Text) ? txtOtherSpec.Text : string.Empty;
                strBrand = !string.IsNullOrEmpty(txtBrand.Text) ? txtBrand.Text : string.Empty;
                strModelNumber = !string.IsNullOrEmpty(txtModelNo.Text) ? txtModelNo.Text : string.Empty;
                numLength = !string.IsNullOrEmpty(txtLength.Text) ? Convert.ToDecimal(txtLength.Text) : 0;
                numWidth = !string.IsNullOrEmpty(txtWidth.Text) ? Convert.ToDecimal(txtWidth.Text) : 0;
                numHeight = !string.IsNullOrEmpty(txtHight.Text) ? Convert.ToDecimal(txtHight.Text) : 0;
                numInnerDia = !string.IsNullOrEmpty(TextInnerDia.Text) ? Convert.ToDecimal(TextInnerDia.Text) : 0;
                numOuterDia = !string.IsNullOrEmpty(TextOuterDia.Text) ? Convert.ToDecimal(TextOuterDia.Text) : 0;
                numGrossWeight = !string.IsNullOrEmpty(TextGrossWt.Text) ? Convert.ToDecimal(TextGrossWt.Text) : 0;
                numNetWeight = !string.IsNullOrEmpty(TextNetWt.Text) ? Convert.ToDecimal(TextNetWt.Text) : 0;
                numMinStock = !string.IsNullOrEmpty(txtMinStock.Text) ? Convert.ToDecimal(txtMinStock.Text) : 0;
                numMaxStock = !string.IsNullOrEmpty(txtMaxStock.Text) ? Convert.ToDecimal(txtMaxStock.Text) : 0;
                numSaftyStock = !string.IsNullOrEmpty(txtSaftyStock.Text) ? Convert.ToDecimal(txtSaftyStock.Text) : 0;
                numReorderPoint = !string.IsNullOrEmpty(txtReOrderPoint.Text) ? Convert.ToDecimal(txtReOrderPoint.Text) : 0;
                intPart = 2;
                intItemUOM = Convert.ToInt32(ddlUoMN.SelectedValue) > 0 ? Convert.ToInt32(ddlUoMN.SelectedValue) : 0;
                strItemUoM = ddlUoMN.SelectedItem.ToString();
                intLengthUoM = Convert.ToInt32(ddlLengthUom.SelectedValue) > 0 ? Convert.ToInt32(ddlLengthUom.SelectedValue) : 0;
                intWidthUoM = Convert.ToInt32(ddlWidthUom.SelectedValue) > 0 ? Convert.ToInt32(ddlWidthUom.SelectedValue) : 0;
                intHeightUoM = Convert.ToInt32(ddlHeightUoM.SelectedValue) > 0 ? Convert.ToInt32(ddlHeightUoM.SelectedValue) : 0;
                intInnerDiaUoM = Convert.ToInt32(ddlIdUom.SelectedValue) > 0 ? Convert.ToInt32(ddlIdUom.SelectedValue) : 0;
                intOuterDiaUoM = Convert.ToInt32(ddlOdUom.SelectedValue) > 0 ? Convert.ToInt32(ddlOdUom.SelectedValue) : 0;
                intAlterUoM = Convert.ToInt32(ddlAlterUoM.SelectedValue) > 0 ? Convert.ToInt32(ddlAlterUoM.SelectedValue) : 0;
                strAlterUoM = Convert.ToInt32(ddlAlterUoM.SelectedValue) > 0 ? ddlAlterUoM.SelectedItem.ToString() : string.Empty;
                intPlant = Convert.ToInt32(ddlPlant.SelectedValue) > 0 ? Convert.ToInt32(ddlPlant.SelectedValue) : 0;
                strPlant = Convert.ToInt32(ddlPlant.SelectedValue) > 0 ? ddlPlant.SelectedItem.ToString() : string.Empty;
                intIsMRR = Convert.ToInt32(ddlIsMRP.SelectedValue) > 0 ? Convert.ToInt32(ddlIsMRP.SelectedValue) : 0;
                strItemFullName = strMaterialName + "_Color-" + strColour + "_Origin-" + strOrigin + "_Part-" + strPartNumber
                                   + "_Brand-" + strBrand+"_Specification-"+ strOtherSpecification + "_Model-" + strModelNumber 
                                   +"_Plant-"+ strPlant+"_UoM-"+ strItemUoM;
            }
            catch (Exception ex)
            {
            }
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
        }
        #endregion
    }
}
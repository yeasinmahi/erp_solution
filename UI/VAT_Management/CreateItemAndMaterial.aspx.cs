using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using UI.ClassFiles;
using SAD_BLL.Vat;
using System.Windows.Forms;

namespace UI.VAT_Management
{
    public partial class CreateItemAndMaterial : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        string strVatItem, strUOM, strHSCode, strName, strUoM;
        int intUserID, intUOM, intPart, intUnitID, ysnFactory, intVATAccountID, intMaterialType;       
        bool ysnExempted;

        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVATAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }

                    intUnitID = int.Parse(hdnUnit.Value);
                    intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());

                    if (hdnysnFactory.Value == "1")
                    {
                        ysnFactory = 1;
                        intPart = 1;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlProduct.DataTextField = "strVatProductName";
                        ddlProduct.DataValueField = "intID";
                        ddlProduct.DataSource = dt;
                        ddlProduct.DataBind();

                        intPart = 2;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlMaterial.DataTextField = "strMaterialName";
                        ddlMaterial.DataValueField = "intMaterialID";
                        ddlMaterial.DataSource = dt;
                        ddlMaterial.DataBind();

                        intPart = 3;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlUOMM.DataTextField = "strUOM";
                        ddlUOMM.DataSource = dt;
                        ddlUOMM.DataBind();

                        intPart = 4;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlType.DataTextField = "strTypeName";
                        ddlType.DataValueField = "intMatTypeID";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();

                        intPart = 5;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlUOM.DataTextField = "strUOM";
                        ddlUOM.DataValueField = "intID";
                        ddlUOM.DataSource = dt;
                        ddlUOM.DataBind();
                    }
                    else if (hdnysnFactory.Value == "0")
                    {
                        ysnFactory = 0;
                        intPart = 6;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlMaterial.DataTextField = "strMaterialName";
                        ddlMaterial.DataValueField = "intMaterialID";
                        ddlMaterial.DataSource = dt;
                        ddlMaterial.DataBind();

                        intPart = 7;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlUOMM.DataTextField = "strUOM";
                        ddlUOMM.DataSource = dt;
                        ddlUOMM.DataBind();

                        intPart = 8;
                        dt = objvat.GetDropDownDataBindForCreateItemAndMaterial(intPart, intUnitID, ysnFactory, intVATAccountID);
                        ddlType.DataTextField = "strTypeName";
                        ddlType.DataValueField = "intMatTypeID";
                        ddlType.DataSource = dt;
                        ddlType.DataBind();
                    }
                }
            }
            catch { }
        }


        protected void cbTax_CheckedChanged(object sender, EventArgs e)
        {

            //if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{

            //}
            //if (hdnconfirmTax.Value == "1")
            //{
            //    cbTax.Checked = true;
            //}
            //else
            //{
            //    cbTax.Checked = false;
            //}

            //ClientScriptManager CSM = Page.ClientScript;
            //if (!ReturnValue())
            //{
            //    string strconfirm = "<script>if(!window.confirm('Are you sure?')){window.location.href='Default.aspx'}</script>";
            //    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
            //}
        }
        bool ReturnValue()
        {
            return false;
        }
        
        private void button3_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
            }
        }
            

        protected void btnUpdateUOM_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 1;
                    intUnitID = int.Parse(hdnUnit.Value);
                    strName = txtProduct.Text;
                    if(txtProduct.Text == "")
                    {
                        return;
                    }
                    intUserID = int.Parse(hdnEnroll.Value);
                    intUOM = int.Parse(ddlUOM.SelectedValue.ToString());
                    strUoM = ddlUOM.SelectedItem.ToString();
                    strHSCode = txtHSCode.Text;
                    ysnExempted = cbTax.Checked;
                    intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
                    intMaterialType = 0;

                    string message = objvat.InsertVatItemAndMaterial(intPart, intUnitID, strName, intUserID, intUOM, strUoM, strHSCode, ysnExempted, intVATAccountID, intMaterialType);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtProduct.Text = "";
                    txtHSCode.Text = "";
                }
            }
            catch { }
        }

        protected void btnCreateMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 2;
                    intUnitID = int.Parse(hdnUnit.Value);
                    strName = txtMaterial.Text;
                    if (txtMaterial.Text == "")
                    {
                        return;
                    }
                    intUserID = int.Parse(hdnEnroll.Value);
                    intUOM = 0; //int.Parse(ddlUOMM.SelectedValue.ToString());
                    strUoM = ddlUOMM.SelectedItem.ToString();
                    strHSCode = "";
                    ysnExempted = cbTaxM.Checked;
                    intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
                    intMaterialType = int.Parse(ddlType.SelectedValue.ToString());

                    string message = objvat.InsertVatItemAndMaterial(intPart, intUnitID, strName, intUserID, intUOM, strUoM, strHSCode, ysnExempted, intVATAccountID, intMaterialType);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtMaterial.Text = "";
                }
            }
            catch { }
        }   

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }




    }
}
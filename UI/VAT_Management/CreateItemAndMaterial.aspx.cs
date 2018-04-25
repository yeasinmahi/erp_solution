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

namespace UI.VAT_Management
{
    public partial class CreateItemAndMaterial : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        string strVatItem, strUOM, strHSCode;
        int intUserID, intUOM;
        
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

                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }
                    if(hdnysnFactory.Value == "0")
                    {

                    }







                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVATAccID.Value = ddlVatAccount.SelectedValue.ToString();
                }
            }
            catch { }
        }

        protected void btnUpdateUOM_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            //@intUnitID,@strVatItem,1,getdate(),@intUserID,@intUoM,@strUoM,@strHSCode,@ysnTaxExempted,@intVATAccountID
        }

        protected void btnCreateMaterial_Click(object sender, EventArgs e)
        {

        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }




    }
}
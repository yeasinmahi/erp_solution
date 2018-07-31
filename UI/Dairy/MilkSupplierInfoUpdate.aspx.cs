using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;

namespace UI.Dairy
{
    public partial class MilkSupplierInfoUpdate : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objM = new Task_BLL();
        DataTable dt;

 
        string strBankName, strBankBranchName, strBankAccountNo, strOrgAddress, strReprContactNo, strNationalIDNo;
        int intUnitID, intBankID, intDistrictID, intBranchID, intLastActionBy, intCCID, intSupplierID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetChillingCenterList(intUnitID);
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();

                    dt = obj.GetBankList();
                    ddlBank.DataTextField = "strBankName";
                    ddlBank.DataValueField = "intID";
                    ddlBank.DataSource = dt;
                    ddlBank.DataBind();

                    dt = obj.GetDistrictList();
                    ddlDistrict.DataTextField = "strDistrict";
                    ddlDistrict.DataValueField = "intDistrictID";
                    ddlDistrict.DataSource = dt;
                    ddlDistrict.DataBind();

                    intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                    intDistrictID = int.Parse(ddlDistrict.SelectedValue.ToString());

                    dt = obj.GetBranchList(intBankID, intDistrictID);
                    ddlBranch.DataTextField = "strBankBranchName";
                    ddlBranch.DataValueField = "intBranchID";
                    ddlBranch.DataSource = dt;
                    ddlBranch.DataBind();
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = objM.GetMilkSupplierInfoForUpdate(int.Parse(ddlChillingCenter.SelectedValue.ToString()), txtSearchCode.Text);
                if (dt.Rows.Count > 0)
                {
                    txtSuppCode.Text = dt.Rows[0]["strSupplierCode"].ToString();
                    txtSuppName.Text = dt.Rows[0]["strSupplierName"].ToString();                    
                    txtAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();                    
                    txtMobileNo.Text = dt.Rows[0]["strReprContactNo"].ToString();                    
                    txtNID.Text = dt.Rows[0]["strNationalIDNo"].ToString();
                    txtAccountNo.Text = dt.Rows[0]["strBankAccountNo"].ToString();                    
                    ddlBank.SelectedValue = dt.Rows[0]["intBankID"].ToString();
                    ddlDistrict.SelectedValue = dt.Rows[0]["intDistrictID"].ToString();                    
                    string strBranchID = dt.Rows[0]["intBranchID"].ToString();
                    hdnSuppID.Value = dt.Rows[0]["intSupplierID"].ToString();

                    dt = obj.GetBranchList(int.Parse(ddlBank.SelectedValue), int.Parse(ddlDistrict.SelectedValue));
                    ddlBranch.DataTextField = "strBankBranchName";
                    ddlBranch.DataValueField = "intBranchID";
                    ddlBranch.DataSource = dt;
                    ddlBranch.DataBind();

                    ddlBranch.SelectedValue = strBranchID;
                }
                else
                {
                    txtSuppCode.Text = "";
                    txtSuppName.Text = "";
                    ddlBank.SelectedValue = "0";
                    txtAddress.Text = "";
                    ddlDistrict.SelectedValue = "0";
                    txtMobileNo.Text = "";
                    ddlBranch.SelectedValue = "0";
                    txtNID.Text = "";
                    txtAccountNo.Text = "";
                    hdnSuppID.Value = "0";
                }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                strBankName = ddlBank.SelectedItem.ToString();
                strBankBranchName = ddlBranch.SelectedItem.ToString();
                strBankAccountNo = txtAccountNo.Text;
                strOrgAddress = txtAddress.Text;
                strReprContactNo = txtMobileNo.Text;
                strNationalIDNo = txtNID.Text;
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                intDistrictID = int.Parse(ddlDistrict.SelectedValue.ToString());
                intBranchID = int.Parse(ddlBranch.SelectedValue.ToString());
                intLastActionBy = int.Parse(hdnEnroll.Value);
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                intSupplierID = int.Parse(hdnSuppID.Value);

                string message = objM.UpdateSuppInfo(strBankName, strBankBranchName, strBankAccountNo, strOrgAddress, strReprContactNo, strNationalIDNo, intBankID, intDistrictID, intBranchID, intLastActionBy, intCCID, intSupplierID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                txtSuppCode.Text = "";
                txtSuppName.Text = "";
                ddlBank.SelectedValue = "0";
                txtAddress.Text = "";
                ddlDistrict.SelectedValue = "0";
                txtMobileNo.Text = "";
                ddlBranch.SelectedValue = "0";
                txtNID.Text = "";
                txtAccountNo.Text = "";
                hdnSuppID.Value = "0";
            }
            catch { }
        }

        #region===== Selection Change ========================================
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = obj.GetChillingCenterList(intUnitID);
                ddlChillingCenter.DataTextField = "strChillingCenterName";
                ddlChillingCenter.DataValueField = "intChillingCenterID";
                ddlChillingCenter.DataSource = dt;
                ddlChillingCenter.DataBind();
            }
            catch { }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                intDistrictID = int.Parse(ddlDistrict.SelectedValue.ToString());

                dt = obj.GetBranchList(intBankID, intDistrictID);
                ddlBranch.DataTextField = "strBankBranchName";
                ddlBranch.DataValueField = "intBranchID";
                ddlBranch.DataSource = dt;
                ddlBranch.DataBind();
            }
            catch { }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                intDistrictID = int.Parse(ddlDistrict.SelectedValue.ToString());

                dt = obj.GetBranchList(intBankID, intDistrictID);
                ddlBranch.DataTextField = "strBankBranchName";
                ddlBranch.DataValueField = "intBranchID";
                ddlBranch.DataSource = dt;
                ddlBranch.DataBind();
            }
            catch { }
        }

        #endregion ===========================================================





































    }
}
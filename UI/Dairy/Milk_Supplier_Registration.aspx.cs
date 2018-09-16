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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Dairy
{
    public partial class Milk_Supplier_Registration : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_Supplier_Registration.aspx";
        string stop = "stopping Dairy/Milk_Supplier_Registration.aspx";

        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID; int intBankID; int intDistrictID; int intBranchID; string strAccountNo; string strSuppCode;
        string strSuppName; string strAddress; string strNID; string strMobileNo; string strBankName; string strBranchName;
        int intInsertBy; 

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Supplier_Registration.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

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

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Supplier_Registration.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    if (txtSuppCode.Text != "") { strSuppCode = txtSuppCode.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Inpurt Supplier Code.');", true); return; }
                    if (txtSuppName.Text != "") { strSuppName = txtSuppName.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Inpurt Supplier Name.');", true); return; }
                    if (txtAddress.Text != "") { strAddress = txtAddress.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Inpurt Supplier Address.');", true); return; }
                    if (txtMobileNo.Text != "") { strMobileNo = txtMobileNo.Text; } else { strMobileNo = "00"; }
                    if (txtNID.Text != "") { strNID = txtNID.Text; } else { strNID = "00"; }
                    strBankName = ddlBank.SelectedItem.ToString();
                    intBankID = int.Parse(ddlBank.SelectedValue.ToString());
                    intDistrictID = int.Parse(ddlDistrict.SelectedValue.ToString());
                    intBranchID = int.Parse(ddlBranch.SelectedValue.ToString());
                    strBranchName = ddlBranch.SelectedItem.ToString();
                    if (txtAccountNo.Text != "") { strAccountNo = txtAccountNo.Text; } else { strAccountNo = "0000000000000"; }
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    //Final Insert
                    string message = obj.InsertSuppRegistration(strSuppCode, strSuppName, strAddress, strMobileNo, intInsertBy, intUnitID, strAccountNo, strNID, strBankName, strBranchName, intCCID, intBankID, intDistrictID, intBranchID);

                    txtSuppCode.Text = "";
                    txtSuppName.Text = "";
                    txtAddress.Text = "";
                    txtMobileNo.Text = "";
                    txtNID.Text = "";
                    txtAccountNo.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }





    }
}
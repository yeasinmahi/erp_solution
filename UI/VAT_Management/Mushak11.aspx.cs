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
using System.IO;
using System.Xml;

namespace UI.VAT_Management
{
    public partial class Mushak11 : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intVATAccountID, intVatChallanNo, intUserID, intUnitID;
        DateTime dteM11DateTime, dteChallanDate;
        string strChallanNo, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, strCustomerName;

        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVATAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    hdnysnFactory.Value = "0";
                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }

                    dt = new DataTable();
                    dt = objvat.GetVatAccAddressAndNumber(int.Parse(hdnEnroll.Value), int.Parse(hdnVATAccID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        lblAddress.Text = "Address : " + dt.Rows[0]["strAddress"].ToString();
                        lblVATReg.Text = "VAT Reg. No. " + dt.Rows[0]["strVATRegNo"].ToString();
                    }
                    
                    HttpContext.Current.Session["vataccid"] = hdnVATAccID.Value;
                }
            }
            catch { }
        }
        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
            intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
            HttpContext.Current.Session["vataccid"] = intVATAccountID.ToString();

            try
            {
                dt = new DataTable();
                dt = objvat.GetVatAccAddressAndNumber(int.Parse(hdnEnroll.Value), intVATAccountID);
                if (dt.Rows.Count > 0)
                {
                    lblAddress.Text = dt.Rows[0]["strAddress"].ToString();
                    lblVATReg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                }
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchChallanListForM11(string prefixText, int count)
        {
            Int32 intVatAcID = Convert.ToInt32(HttpContext.Current.Session["vataccid"].ToString());
            VAT_BLL objAutoSearch_BLL = new VAT_BLL();
            return objAutoSearch_BLL.AutoSearchChallanNoForM11(intVatAcID.ToString(), prefixText);
        }

        protected void btnM11Save_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtChallanSearch.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    strChallanNo = temp1[0].ToString();
                }
                catch { strChallanNo = ""; }

                if (strChallanNo == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Incorrect Challan No');", true);
                    return;
                }

                intVATAccountID = int.Parse(ddlVatAccount.SelectedValue.ToString());
                intUserID = int.Parse(hdnEnroll.Value);

                if (txtCustomerName.Text == "")
                {
                    strCustomerName = null;
                }
                else
                {
                    strCustomerName = txtCustomerName.Text;
                }

                if (txtFinalDestination.Text == "")
                {
                    strFinalDistanitionAddress = null;
                }
                else
                {
                    strFinalDistanitionAddress = txtFinalDestination.Text;
                }

                if (txtVehicleNo.Text == "")
                {
                    strVehicleRegNo = null;
                }
                else
                {
                    strVehicleRegNo = txtVehicleNo.Text;
                }

                if (txtCustomerVAT.Text == "")
                {
                    strCustVATRegNo = null;
                }
                else
                {
                    strCustVATRegNo = txtCustomerVAT.Text;
                }

                try
                {
                    if (txtChallanPaidDateTime.Text == "")
                    {
                        DateTime dteCheck = DateTime.Parse("1900-01-01".ToString());
                        dteM11DateTime = DateTime.Parse(dteCheck.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        dteM11DateTime = DateTime.Parse(txtChallanPaidDateTime.Text);
                    }
                }
                catch
                {
                    DateTime dteCheck = DateTime.Parse("1900-01-01".ToString());
                    dteM11DateTime = DateTime.Parse(dteCheck.ToString("yyyy-MM-dd"));
                }

                try
                {
                    dt = new DataTable();
                    dt = objvat.GetM11PrintGetM11Print(strChallanNo, intVATAccountID, strCustVATRegNo, strFinalDistanitionAddress, strVehicleRegNo, intVatChallanNo, dteM11DateTime, intUserID, dteChallanDate, intUnitID, strCustomerName);
                    txtChallanSearch.Text = "";
                    txtChallanPaidDateTime.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerVAT.Text = "";
                    txtFinalDestination.Text = "";
                    txtVehicleNo.Text = "";                    
                }
                catch (Exception ex) { ex.ToString(); }
            }
            catch (Exception ex) { ex.ToString(); }
        }

























    }
}
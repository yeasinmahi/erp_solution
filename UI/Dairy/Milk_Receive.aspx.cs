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
using System.Web.Services;
using System.Web.Script.Services;

namespace UI.Dairy
{
    public partial class Milk_Receive : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL(); 
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intAutoID;
        DateTime dteRDate; int intCCID; int intSuppID; string strSuppCodeNo; string strMorEve; decimal decRQty; decimal decRFP;
        string strAlcoholTest; decimal decCLR; decimal decTemperature; decimal decLactoReading; string strColourTest;
        decimal decAcidityTest; string strFormalinTest; string strSodaTest; string strSaltTest; string strSugarTest; 
        string strCOB; decimal decReceFatKgs; decimal monRRate; decimal monRBill; decimal monRCMcomm; decimal monRGrandTotal;
        int intInsertBy; int intUnitID; int intPONo;

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

                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    HttpContext.Current.Session["intCCID"] = ddlChillingCenter.SelectedValue.ToString();

                    dt = obj.GetSupplierCode(intCCID);
                    ddlSupplierCode.DataTextField = "strSupplierCode";
                    ddlSupplierCode.DataValueField = "intSupplierID";
                    ddlSupplierCode.DataSource = dt;
                    ddlSupplierCode.DataBind();

                    intSuppID = int.Parse(ddlSupplierCode.SelectedValue.ToString());

                    dt = new DataTable();
                    dt = obj.GetSupplierName(intSuppID);
                    if (dt.Rows.Count > 0)
                    {
                        txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
                    }

                    dt = obj.GetFatPercentList(intCCID);
                    ddlFatPercentage.DataTextField = "intFatPercentage";
                    ddlFatPercentage.DataValueField = "intAutoID";
                    ddlFatPercentage.DataSource = dt;
                    ddlFatPercentage.DataBind();

                    intAutoID = int.Parse(ddlFatPercentage.SelectedValue.ToString());
                    hdnFTP.Value = ddlFatPercentage.SelectedItem.ToString();
                    
                    dt = new DataTable();
                    dt = obj.GetRateAmount(intAutoID);
                    if (dt.Rows.Count > 0)
                    {
                        txtRate.Text = dt.Rows[0]["Rate"].ToString();
                        hdnCmComm.Value = dt.Rows[0]["monCMComm"].ToString(); 
                    }

                }
                catch
                { }
            }
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

                HttpContext.Current.Session["intCCID"] = ddlChillingCenter.SelectedValue.ToString();
            }
            catch { }

            try
            {
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

                dt = obj.GetSupplierCode(intCCID);
                ddlSupplierCode.DataTextField = "strSupplierCode";
                ddlSupplierCode.DataValueField = "intSupplierID";
                ddlSupplierCode.DataSource = dt;
                ddlSupplierCode.DataBind();
            }
            catch { }

            try
            {
                intSuppID = int.Parse(ddlSupplierCode.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetSupplierName(intSuppID);
                if (dt.Rows.Count > 0)
                {
                    txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
                }
            }
            catch { }

            try
            {
                dt = obj.GetFatPercentList(intCCID);
                ddlFatPercentage.DataTextField = "intFatPercentage";
                ddlFatPercentage.DataValueField = "intAutoID";
                ddlFatPercentage.DataSource = dt;
                ddlFatPercentage.DataBind();

                intAutoID = int.Parse(ddlFatPercentage.SelectedValue.ToString());
                hdnFTP.Value = ddlFatPercentage.SelectedItem.ToString();

                dt = new DataTable();
                dt = obj.GetRateAmount(intAutoID);
                if (dt.Rows.Count > 0)
                {
                    txtRate.Text = dt.Rows[0]["Rate"].ToString();
                    hdnCmComm.Value = dt.Rows[0]["monCMComm"].ToString(); 
                }
            }
            catch { }
        }
        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

            HttpContext.Current.Session["intCCID"] = ddlChillingCenter.SelectedValue.ToString();

            dt = obj.GetSupplierCode(intCCID);
            ddlSupplierCode.DataTextField = "strSupplierCode";
            ddlSupplierCode.DataValueField = "intSupplierID";
            ddlSupplierCode.DataSource = dt;
            ddlSupplierCode.DataBind();

            intSuppID = int.Parse(ddlSupplierCode.SelectedValue.ToString());

            dt = new DataTable();
            dt = obj.GetSupplierName(intSuppID);
            if (dt.Rows.Count > 0)
            {
                txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
            }

            dt = obj.GetFatPercentList(intCCID);
            ddlFatPercentage.DataTextField = "intFatPercentage";
            ddlFatPercentage.DataValueField = "intAutoID";
            ddlFatPercentage.DataSource = dt;
            ddlFatPercentage.DataBind();

            intAutoID = int.Parse(ddlFatPercentage.SelectedValue.ToString());
            hdnFTP.Value = ddlFatPercentage.SelectedItem.ToString();

            dt = new DataTable();
            dt = obj.GetRateAmount(intAutoID);
            if (dt.Rows.Count > 0)
            {
                txtRate.Text = dt.Rows[0]["Rate"].ToString();
                hdnCmComm.Value = dt.Rows[0]["monCMComm"].ToString(); 
            }

            //txtSearchSupp.Text = "";
        }
        protected void ddlSupplierCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            intSuppID = int.Parse(ddlSupplierCode.SelectedValue.ToString());

            dt = new DataTable();
            dt = obj.GetSupplierName(intSuppID);
            if (dt.Rows.Count > 0)
            {
                txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
            }
        }
        protected void ddlFatPercentage_SelectedIndexChanged(object sender, EventArgs e)
        {
            intAutoID = int.Parse(ddlFatPercentage.SelectedValue.ToString());
            hdnFTP.Value = ddlFatPercentage.SelectedItem.ToString();
            intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());

            dt = new DataTable();
            dt = obj.GetRateAmount(intAutoID);
            if (dt.Rows.Count > 0)
            {
                txtRate.Text = dt.Rows[0]["Rate"].ToString();
                hdnCmComm.Value = dt.Rows[0]["monCMComm"].ToString(); 
            }

            try { decRQty = decimal.Parse(txtQty.Text);}
            catch { decRQty = 0; }
            txtFatKgs.Text = (decRQty / 100 * decimal.Parse(hdnFTP.Value)).ToString();
            monRRate = decimal.Parse(txtRate.Text);            
            txtBillAmount.Text = (decRQty * monRRate).ToString();
            txtCMCommition.Text = (decRQty * decimal.Parse(hdnCmComm.Value)).ToString();
            txtGrandTotal.Text = ((decRQty * monRRate) + (decRQty * decimal.Parse(hdnCmComm.Value))).ToString();            
        }
        protected void btnReceive_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                    try { dteRDate = DateTime.Parse(txtReceiveDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Date.');", true); return; }
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    //char[] ch = { '[', ']' };
                    //string[] temp = txtSearchSupp.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    ////strSuppCodeNo = temp[temp.Length + 1];
                    //strSuppCodeNo = temp[1];                    
                    //string strName = temp[0];
                    //try { intSuppID = int.Parse(temp[temp.Length - 1].ToString()); }
                    //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Supplier Name.');", true); return; }
                    //if (intSuppID == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Supplier Name.');", true); return; }

                    intSuppID = int.Parse(ddlSupplierCode.SelectedValue.ToString());
                    if (intSuppID == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Supplier Name.');", true); return; }
                    strSuppCodeNo = ddlSupplierCode.SelectedItem.ToString();
                    
                    strMorEve = ddlMonEve.SelectedItem.ToString();
                    try { decRQty = decimal.Parse(txtQty.Text);}
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Receive Quantity.');", true); return; }                    
                    decRFP = decimal.Parse(ddlFatPercentage.SelectedItem.ToString());
                    strAlcoholTest = txtAlcoholTest.Text;
                    try { decCLR = decimal.Parse(txtCLR.Text); } catch { decCLR = 0; }
                    try { decTemperature = decimal.Parse(txtTemperature.Text); } catch { decTemperature = 0; }
                    try { decLactoReading = decimal.Parse(txtLactoReading.Text); } catch { decLactoReading = 0; }
                    strColourTest = txtColourTest.Text;
                    try { decAcidityTest = decimal.Parse(txtAcidityTest.Text); } catch { decAcidityTest = 0; }
                    strFormalinTest = txtFormalinTest.Text;
                    strSodaTest = txtSodaTest.Text;
                    strSaltTest = txtSaltTest.Text;
                    strSugarTest = txtSugarTest.Text;
                    strCOB = txtCOB.Text;
                    decReceFatKgs = decimal.Parse(txtFatKgs.Text);
                    monRRate = decimal.Parse(txtRate.Text);
                    monRBill = decRQty * monRRate;
                    if (monRBill == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Bill Amount.');", true); return; }
                    monRCMcomm = decimal.Parse(txtCMCommition.Text);
                    if (monRCMcomm == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check CM Commission Amount.');", true); return; }
                    monRGrandTotal = decimal.Parse(txtGrandTotal.Text);
                    if (monRGrandTotal == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Grand Total Amount.');", true); return; }
                    try { intPONo = int.Parse(txtPONo.Text); } catch { intPONo = 0; }

                    //Final Insert
                    string message = obj.InsertMilkReceive(dteRDate, intCCID, intSuppID, strSuppCodeNo, strMorEve, decRQty, decRFP,
                    strAlcoholTest, decCLR, decTemperature, decLactoReading, strColourTest, decAcidityTest, strFormalinTest, strSodaTest,
                    strSaltTest, strSugarTest, strCOB, decReceFatKgs, monRRate, monRBill, monRCMcomm, monRGrandTotal, intInsertBy,
                    intUnitID, intPONo);

                    txtQty.Text = "";
                    txtFatKgs.Text = "";
                    txtBillAmount.Text = "";
                    txtCMCommition.Text = "";
                    txtGrandTotal.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }             
        }


        //***********************************************************************************************************
        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {
            Int32 CCID = Convert.ToInt32(HttpContext.Current.Session["intCCID"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchChllingCenter(CCID.ToString(), prefixText);
        }

        

        //protected void txtSearchSupp_TextChanged(object sender, EventArgs e)
        //{
        //    GetResult();
        //}

        //private void GetResult()
        //{
        //    if (txtSearchSupp.Text.Trim() != "")
        //    {
        //        char[] ch = { '[', ']' };
        //        string[] temp = txtSearchSupp.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
        //        strSuppCodeNo = temp[temp.Length - 1];
        //        string strName = temp[0];
                
        //        //hdnCustomer.Value = temp[temp.Length - 1];
        //        //hdnCustomerText.Value = temp[0];
        //    }
        //}









    }
}
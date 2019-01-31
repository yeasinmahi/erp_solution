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

namespace UI.Transport
{
    public partial class AccidentRegisterEntry : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        DateTime dteAccidentDate; int intVehicleID; string strVehicleRegistrationNumber; int intUserUnitID; string strUserUnit; int intDriverEnroll;
        string strDriverName; string strTravelingRouteFrom; string strTravelingRouteTo; string strPlaceOfAccident; TimeSpan tmTimeOfAccident;
        string strAccidentType; string strDescription; string strLossIncurredByAccident; decimal monSettlementPenaltyPaid;
        decimal monSettlementPenaltyReceive; int intSettlementPenaltyChargedCompanyUnit; string strSettlementPenaltyChargedCompanyUnit;
        int intSettlementPenaltyChargedDutyDriver; string strSettlementPenaltyChargedDutyDriver; string strSupportVehicleRegNo;
        decimal numRecoveredGoodsOrMaterialsQty; decimal monRecoveredGoodsOrMaterialsValue; decimal numLossGoodOrMaterialsQty;
        decimal monLossGoodOrMaterialsValue; int intInvestigationReportedByEnroll; string strInvestigationReportedByName;
        string strInvestigationReportedByDesignation; int intInsertBy; DateTime dteDatet;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                    dt = obj.GetAllUnit();
                    ddlUserUnit.DataTextField = "strUnit";
                    ddlUserUnit.DataValueField = "intUnitID";
                    ddlUserUnit.DataSource = dt;
                    ddlUserUnit.DataBind();

                    dt = obj.GetAllUnit();
                    ddlSettlementPenaltyChargedtoCompany.DataTextField = "strUnit";
                    ddlSettlementPenaltyChargedtoCompany.DataValueField = "intUnitID";
                    ddlSettlementPenaltyChargedtoCompany.DataSource = dt;
                    ddlSettlementPenaltyChargedtoCompany.DataBind();
                }
                catch
                { }
            }
        }


        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchVehicleAsset(string prefixText, int count)
        {
            InternalTransportBLL objAutoSearch_BLL = new InternalTransportBLL();
            return objAutoSearch_BLL.AutoSearchVehicleAsset("8", prefixText);
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                    dteAccidentDate = DateTime.Parse(strDate.ToString());                  
                    intVehicleID = 0;
                    strVehicleRegistrationNumber = txtVehicleRegNo.Text;
                    intUserUnitID = int.Parse(ddlUserUnit.SelectedValue.ToString());
                    strUserUnit = ddlUserUnit.SelectedItem.ToString();
                    try { intDriverEnroll = int.Parse(txtDriverEnroll.Text); } catch { intDriverEnroll = 0; }
                    strDriverName = txtDriverName.Text;
                    strTravelingRouteFrom = txtTravelingRouteFrom.Text;
                    strTravelingRouteTo = txtTravelingRouteTo.Text;
                    strPlaceOfAccident = txtPlaceOfAccident.Text;
                    try
                    {
                        dteDatet = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", tmsReqTime.Hour, tmsReqTime.Minute, tmsReqTime.Second, tmsReqTime.AmPm));
                        tmTimeOfAccident = TimeSpan.Parse(dteDatet.ToString("HH:mm"));
                    }
                    catch { }
                    strAccidentType = ddlAccidentType.SelectedItem.ToString();
                    strDescription = txtDescription.Text;
                    strLossIncurredByAccident = ddlLossIncurredByAccident.SelectedItem.ToString();
                    try { monSettlementPenaltyPaid = decimal.Parse(txtSettlementPenaltyPaid.Text); } catch { monSettlementPenaltyPaid = 0; }
                    try { monSettlementPenaltyReceive = decimal.Parse(txtSettlementPenaltyReceive.Text); } catch { monSettlementPenaltyReceive = 0; }                    
                    intSettlementPenaltyChargedCompanyUnit = int.Parse(ddlSettlementPenaltyChargedtoCompany.SelectedValue.ToString());
                    strSettlementPenaltyChargedCompanyUnit = ddlSettlementPenaltyChargedtoCompany.SelectedItem.ToString();
                    intSettlementPenaltyChargedDutyDriver = 0; //int.Parse(txtSettlementPenaltyChargedtoDutyDriver.Text);
                    strSettlementPenaltyChargedDutyDriver = txtSettlementPenaltyChargedtoDutyDriver.Text;
                    strSupportVehicleRegNo = txtSupportVehicleRegistrationNumber.Text;
                    try { numRecoveredGoodsOrMaterialsQty = decimal.Parse(txtRecoveredGoodsMaterialsQuantity.Text); } catch { numRecoveredGoodsOrMaterialsQty = 0; }
                    try { monRecoveredGoodsOrMaterialsValue = decimal.Parse(txtRecoveredGoodsMaterialsValue.Text); } catch { monRecoveredGoodsOrMaterialsValue = 0; }
                    try { numLossGoodOrMaterialsQty = decimal.Parse(txtLossGoodsMaterialsQuantity.Text); } catch { numLossGoodOrMaterialsQty = 0; }
                    try { monLossGoodOrMaterialsValue = decimal.Parse(txtLossGoodsMaterialsValue.Text); } catch { monLossGoodOrMaterialsValue = 0; }                    
                    intInvestigationReportedByEnroll = 0;//int.Parse(txtInvestigationReportedByName.Text);
                    strInvestigationReportedByName = txtInvestigationReportedByName.Text;
                    strInvestigationReportedByDesignation = txtDesignation.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    //Final In Insert
                    string message = obj.InsertAccidentRegister(dteAccidentDate, intVehicleID, strVehicleRegistrationNumber, intUserUnitID, strUserUnit, intDriverEnroll, strDriverName, strTravelingRouteFrom, strTravelingRouteTo, strPlaceOfAccident, tmTimeOfAccident, strAccidentType, strDescription, strLossIncurredByAccident, monSettlementPenaltyPaid, monSettlementPenaltyReceive, intSettlementPenaltyChargedCompanyUnit, strSettlementPenaltyChargedCompanyUnit, intSettlementPenaltyChargedDutyDriver, strSettlementPenaltyChargedDutyDriver, strSupportVehicleRegNo, numRecoveredGoodsOrMaterialsQty, monRecoveredGoodsOrMaterialsValue, numLossGoodOrMaterialsQty, monLossGoodOrMaterialsValue, intInvestigationReportedByEnroll, strInvestigationReportedByName, strInvestigationReportedByDesignation, intInsertBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch
                {

                }
            }
        }

        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetSearchAssignedTo(string prefixText, int count)
        //{
        //    Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
        //    Global_BLL objAutoSearch_BLL = new Global_BLL();
        //    return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        //}

        //#region Web Method
        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetCOAList(string prefix, int count)
        //{
        //    return InternalTransportBLL.AutoSearchVehicleAsset();
        //}

        //#endregion Web Method










    }
}
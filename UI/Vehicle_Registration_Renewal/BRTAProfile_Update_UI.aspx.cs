using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.VehicleRegRenewal_BLL;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class BRTAProfile_Update_UI : BasePage
    {
        RegistrationRenewals_BLL objBRTA = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dt = new DataTable();
                dt = objBRTA.BrtaItemDropdown();
                DdlItem.DataSource = dt;
                DdlItem.DataTextField = "strItem";
                DdlItem.DataValueField = "intID";
                DdlItem.DataBind();
                pnlUpperControl.DataBind();
                
            }
        }

        protected void DdlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Int32 itemid=Int32.Parse(DdlItem.SelectedValue.ToString());
            dt=new DataTable();
            dt=objBRTA.detalisview(itemid);
            if(dt.Rows.Count>0)
            {
                TxtRegistrationFee.Text = dt.Rows[0]["monRegistrationFee"].ToString();
                TxtNamePlate.Text = dt.Rows[0]["monNamePlate"].ToString();
                TxtOwnerShipchange.Text = dt.Rows[0]["monOwnerShipChange"].ToString();
                TxtAddressChange.Text = dt.Rows[0]["monAddressChange"].ToString();
                TxtCertificateCopy.Text = dt.Rows[0]["monCertificateCopy"].ToString();
                TxtDuplicatedCertificate.Text = dt.Rows[0]["monDuplicateCertificate"].ToString();
                TxtRegistrationMisc.Text = dt.Rows[0]["monRegistrationMiscFee"].ToString();
                TxtTaxTokenFee.Text = dt.Rows[0]["monTaxTokenFeeWithVat"].ToString();
                TxtTaxTokenLateFine3_1.Text = dt.Rows[0]["monTaxTokenLatefinein3month10Percentage"].ToString();
                TxtTaxTokenLateFine6_2.Text = dt.Rows[0]["monTaxTokenLatefinein6month20Percentage"].ToString();
                TxtTaxTokenLate6_30.Text = dt.Rows[0]["monTaxTokenLatefinein6monthAvobe30Percentage"].ToString();
                TxtFitnessFee.Text = dt.Rows[0]["monFitnessfee"].ToString();
                TxtFitnessLate.Text = dt.Rows[0]["monFitnessLateFine"].ToString();
                TxtFitenessMisc.Text = dt.Rows[0]["monFitnessMiscellounes"].ToString();
                TxtAIT.Text = dt.Rows[0]["monAITFee"].ToString();
                TxtInsuranceFee.Text = dt.Rows[0]["monInsuranceFee"].ToString();
                TxtRoutePermit.Text = dt.Rows[0]["monRoutePermitFee"].ToString();
                TxtRoutepermitLateFine.Text = dt.Rows[0]["monRouteLateFine"].ToString();
                TxtRoutePermitMisc.Text = dt.Rows[0]["monRootPermiteMisce"].ToString();
                TxtBodyVat.Text = dt.Rows[0]["monBodyVatFee"].ToString();
                TxtDRC.Text = dt.Rows[0]["monDRC"].ToString();
            }

        }

        protected void BtnUpdatae_Click(object sender, EventArgs e)
        {
            Int32 itemid = Int32.Parse(DdlItem.SelectedValue.ToString());
            Int32 enroll=Int32.Parse(Session[SessionParams.USER_ID].ToString());
            decimal refistrationfee = decimal.Parse(TxtRegistrationFee.Text.ToString());
            decimal nameplate = decimal.Parse(TxtNamePlate.Text.ToString());
            decimal ownership = decimal.Parse(TxtOwnerShipchange.Text.ToString());
            decimal addresschange = decimal.Parse(TxtAddressChange.Text.ToString());
            decimal certificatecopy = decimal.Parse(TxtCertificateCopy.Text.ToString());
            decimal duplicatecertifite = decimal.Parse(TxtDuplicatedCertificate.Text.ToString());
            decimal registrationMisc = decimal.Parse(TxtRegistrationMisc.Text.ToString());
            decimal taxtokenfee = decimal.Parse(TxtTaxTokenFee.Text.ToString());
            decimal taxtokenLatefine3_1 = decimal.Parse(TxtTaxTokenLateFine3_1.Text.ToString());
            decimal taxtokenLatefine6_2 = decimal.Parse(TxtTaxTokenLateFine6_2.Text.ToString());
            decimal taxtokenLatefine6_3 = decimal.Parse(TxtTaxTokenLate6_30.Text.ToString());
            decimal fitenssfee = decimal.Parse(TxtFitnessFee.Text.ToString());
            decimal fitnessLate = decimal.Parse(TxtFitnessLate.Text.ToString());
            decimal fitnessMisc = decimal.Parse(TxtFitenessMisc.Text.ToString());
            decimal AIT = decimal.Parse(TxtAIT.Text.ToString());
           
            decimal insurancefee = decimal.Parse(TxtInsuranceFee.Text.ToString());
            decimal routepermit = decimal.Parse(TxtRoutePermit.Text.ToString());
            decimal routelatefine = decimal.Parse(TxtRoutepermitLateFine.Text.ToString());
            decimal routepermitMisc = decimal.Parse(TxtRoutePermitMisc.Text.ToString());
            decimal bodyvat = decimal.Parse(TxtBodyVat.Text.ToString());
            decimal DRC = decimal.Parse(TxtDRC.Text.ToString());
            dt = new DataTable();
            objBRTA.UpdateBRTAProfile(refistrationfee, nameplate, ownership, addresschange, certificatecopy, duplicatecertifite, registrationMisc, taxtokenfee,
            taxtokenLatefine3_1, taxtokenLatefine6_2, taxtokenLatefine6_3, fitenssfee, fitnessLate, fitnessMisc, AIT, insurancefee,
            routepermit, routelatefine, routepermitMisc, bodyvat, DRC, enroll, itemid);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Update BRTA Profile.');", true);
        }
    }
}
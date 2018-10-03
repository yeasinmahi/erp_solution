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
    public partial class Registration_UI :BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem; string sessionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                string ID = Session["strID"].ToString();
                string strAssetid = Session["strasset"].ToString();
             
                //string asset = Request.QueryString["strAssetID"];

                dt = new DataTable();
                dt = objRenewal.BrtaItemDropdown();
                ddlVechileType.DataSource = dt;
                ddlVechileType.DataTextField = "strItem";
                ddlVechileType.DataValueField = "intID";
                ddlVechileType.DataBind();

                dt = new DataTable();
             

                string assetid = strAssetid.ToString();

                dt = new DataTable();
               
                dt = objRenewal.unitnamewithAssetname(assetid);
                if (dt.Rows.Count > 0)
                {
                    txtVehicleName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    TxtUnit.Text = dt.Rows[0]["strVehicleRegisteredTo"].ToString();
                    try{ddlVechileType.SelectedItem.Text = dt.Rows[0]["strItem"].ToString();}
                    catch { }
                    txtRegistration.Text = dt.Rows[0]["monRegistrationFee"].ToString();
                    TxtNamePlate.Text = dt.Rows[0]["monNamePlate"].ToString();
                    TxtDrc.Text = dt.Rows[0]["monDRC"].ToString();
                    TxtOwnerShip.Text = dt.Rows[0]["monOwnerShipChange"].ToString();
                    TxtBodyVat.Text = dt.Rows[0]["monBodyVatFee"].ToString();
                    TxtAddress.Text = dt.Rows[0]["monAddressChange"].ToString();
                    TxtCertificate.Text = dt.Rows[0]["monCertificateCopy"].ToString();
                    TxtDuplicateCopy.Text = dt.Rows[0]["monDuplicateCertificate"].ToString();
                    TxtMiscellcuneces.Text = dt.Rows[0]["monRegistrationMiscFee"].ToString();
                    lbprsntus.Text= dt.Rows[0]["strUnit1"].ToString();
                    //ddlUnit.SelectedValue = dt.Rows[0]["intUnitID"].ToString();
                }
            }

        }

        protected void BtnRegistration_Click(object sender, EventArgs e)
        {
            decimal bodyvat, nameplate, drc, ownership, addresschange, certificate, duplicatedcopy, miscellounes; int expDay;
              
              

               string assetid = Session["strasset"].ToString();
                 expDay = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                DateTime dtereg = DateTime.Parse(txtDteRegistration.Text);
                decimal registrationTaka = decimal.Parse(txtRegistration.Text.ToString());
                string strtype = ddlVechileType.SelectedItem.ToString();
                int intType = int.Parse(ddlVechileType.SelectedValue.ToString());
                try {  nameplate = decimal.Parse(TxtNamePlate.Text.ToString()); }
                catch { nameplate = decimal.Parse(0.ToString()); }
                try {  drc = decimal.Parse(TxtDrc.Text.ToString()); }
                catch { drc = decimal.Parse(0.ToString()); }
                try {  ownership = decimal.Parse(TxtOwnerShip.Text.ToString()); }
              catch {  ownership = decimal.Parse(0.ToString()); }

                try { addresschange = decimal.Parse(TxtAddress.Text.ToString()); }
                catch { addresschange = decimal.Parse(0.ToString()); }

                try { bodyvat = decimal.Parse(TxtBodyVat.Text.ToString());}
                catch {  bodyvat = decimal.Parse(0.ToString()); }


                try{ certificate = decimal.Parse(TxtCertificate.Text.ToString());}
            catch {  certificate = decimal.Parse(0.ToString()); }
                try{ duplicatedcopy = decimal.Parse(TxtDuplicateCopy.Text.ToString());}
            catch {  duplicatedcopy = decimal.Parse(0.ToString()); }
                try { miscellounes = decimal.Parse(TxtMiscellcuneces.Text.ToString()); }

                catch { miscellounes = decimal.Parse(0.ToString()); }
                DateTime expairdate = DateTime.Parse("1990-01-01".ToString());
                DateTime nextExpairdate = DateTime.Parse("1990-01-01".ToString());
                string certificatedNo = "01".ToString();
                string unit = TxtUnit.Text.ToString();
                intItem = 1;
                dt=objRenewal.InsertVehicleRegistration(intItem,assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            if (dt.Rows.Count > 0){ ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true); }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('already exists');", true); }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 

            
        }
        
    
        
        protected void ddlVechileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            Int32 itemid = Int32.Parse(ddlVechileType.SelectedValue.ToString());
            dt = objRenewal.detalisview(itemid);
            if (dt.Rows.Count>0)
            {
                txtRegistration.Text = dt.Rows[0]["monRegistrationFee"].ToString();
                TxtNamePlate.Text = dt.Rows[0]["monNamePlate"].ToString();
                TxtDrc.Text = dt.Rows[0]["monDRC"].ToString();
                    TxtOwnerShip.Text = dt.Rows[0]["monOwnerShipChange"].ToString();
                    TxtBodyVat.Text = dt.Rows[0]["monBodyVatFee"].ToString();
                    TxtAddress.Text = dt.Rows[0]["monAddressChange"].ToString();
                    TxtCertificate.Text = dt.Rows[0]["monCertificateCopy"].ToString();
                    TxtDuplicateCopy.Text = dt.Rows[0]["monDuplicateCertificate"].ToString();
                    TxtMiscellcuneces.Text = dt.Rows[0]["monRegistrationMiscFee"].ToString();
            }
        }

      
    }
}
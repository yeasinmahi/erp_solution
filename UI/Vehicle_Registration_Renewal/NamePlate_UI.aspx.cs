using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.VehicleRegRenewal_BLL;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class NamePlate_UI : System.Web.UI.Page
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dt = new DataTable();
                string ID = Session["strID"].ToString();
                string strAssetid = Session["strasset"].ToString();
                string assetid = strAssetid.ToString();
                dt = objRenewal.unitnamewithAssetname(assetid);
                if (dt.Rows.Count > 0)
                {
                    TvehicleName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    try { TxtUnit.Text = dt.Rows[0]["strVehicleRegisteredTo"].ToString(); }
                    catch { };
                    try { TxtVehicleType.Text = dt.Rows[0]["strItem"].ToString(); }
                    catch { };
                    try { TxtNamePlate.Text = dt.Rows[0]["monNamePlate"].ToString(); }
                    catch { };
                   

                }
            }
            
          
        }
      
        protected void BtnNamePlate_Click(object sender, EventArgs e)
        {

            string assetid = Session["strasset"].ToString();

                DateTime dtereg = DateTime.Parse("1990-01-1".ToString());
                Int32 expDay = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                decimal registrationTaka = decimal.Parse(TxtNamePlate.Text.ToString());
                string strtype = TxtVehicleType.Text.ToString();
                Int32 intType = Int32.Parse(0.ToString());
                decimal nameplate = decimal.Parse(0.ToString());
                decimal drc = decimal.Parse(0.ToString());
                decimal ownership = decimal.Parse(0.ToString());
                decimal addresschange = decimal.Parse(0.ToString());
                decimal bodyvat = decimal.Parse(0.ToString());
                decimal certificate = decimal.Parse(0.ToString());
                decimal duplicatedcopy = decimal.Parse(0.ToString());
                decimal miscellounes = decimal.Parse(0.ToString());
                DateTime expairdate = DateTime.Parse("1990-01-1".ToString());
                DateTime nextExpairdate = DateTime.Parse("1990-01-1".ToString());
                string certificatedNo = "0".ToString();
                string unit = TxtUnit.Text.ToString();
                
                intItem = 6;
               dt= objRenewal.InsertVehicleNamePlate(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                    ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 


            
        }
    }
}
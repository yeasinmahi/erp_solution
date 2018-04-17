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

    public partial class RoutePermit : BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID = Session["strID"].ToString();
                string strAssetid = Session["strasset"].ToString();
                string assetid = strAssetid.ToString();

                dt = new DataTable();
             
                dt = objRenewal.unitnamewithAssetname(assetid);
                if (dt.Rows.Count > 0)
                {
                    txtVehicleName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    try { TxtUnit.Text = dt.Rows[0]["strVehicleRegisteredTo"].ToString(); }
                    catch { };
                    try { TxtRootPermit.Text = dt.Rows[0]["monRoutePermitFee"].ToString(); }
                    catch { };
                    try { TxtVehicleType.Text = dt.Rows[0]["strItem"].ToString(); }
                    catch { };
                    try { TxtLateFine.Text = dt.Rows[0]["monRouteLateFine"].ToString(); }
                    catch { };
                    TxtRootMisc.Text = dt.Rows[0]["monRootPermiteMisce"].ToString();
                    





                }
            }
        }


       
        protected void Brootpermit_Click(object sender, EventArgs e)
        {
            decimal nameplate, miscellounes;
            string assetid = Session["strasset"].ToString();

                DateTime dtereg = DateTime.Parse(TxtDteRenewal.Text.ToString());
                decimal registrationTaka = decimal.Parse(TxtRootPermit.Text.ToString());
                string strtype = TxtVehicleType.Text.ToString();
                Int32 intType = Int32.Parse(0.ToString());
                try { nameplate = decimal.Parse(TxtLateFine.Text.ToString()); }
                catch { nameplate = decimal.Parse(0.ToString()); }
                     //Late Fine
                decimal drc = decimal.Parse(0.ToString());
                decimal ownership = decimal.Parse(0.ToString());
                decimal addresschange = decimal.Parse(0.ToString());
                decimal bodyvat = decimal.Parse(0.ToString());
                decimal certificate = decimal.Parse(0.ToString());
                decimal duplicatedcopy = decimal.Parse(0.ToString());

            try { miscellounes = decimal.Parse(TxtRootMisc.Text.ToString()); }
            catch { miscellounes = decimal.Parse(0.ToString()); }

            DateTime expairdate = DateTime.Parse(TxtDteExp.Text);
                DateTime nextExpairdate = DateTime.Parse(TxtNextExapDate.Text);
                string certificatedNo = "01".ToString();
                string unit = TxtUnit.Text.ToString();
                Int32 expDay = Int32.Parse(0.ToString());
                intItem = 4;
                dt=objRenewal.InsertVehicleRootpermit(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                    ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 

            
        }
    }
}
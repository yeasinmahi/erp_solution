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
    public partial class Fitness_AIT_UI : BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
                 if(!IsPostBack)

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
                         try { TxtType.Text = dt.Rows[0]["strItem"].ToString(); }
                         catch { };
                         try { TxtFetness.Text = dt.Rows[0]["monFitnessfee"].ToString(); }
                         catch { };
                         try { TxtLateFine.Text = dt.Rows[0]["monFitnessLateFine"].ToString(); }
                         catch { };
                         try { TxtAIT.Text = dt.Rows[0]["monAITFee"].ToString(); }
                         catch { };
                         try { TxtMisccelnewss.Text = dt.Rows[0]["monFitnessMiscellounes"].ToString(); }
                         catch { };
                         lbprsntus.Text = dt.Rows[0]["strUnit1"].ToString();




                }
                    

                 }
        }
        

        protected void BtnFitness_Click(object sender, EventArgs e)
        {


            string assetid = Session["strasset"].ToString();
                Int32 expDay = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
          
                DateTime dtereg = DateTime.Parse(DteRenewalDate.Text);
                decimal registrationTaka = decimal.Parse(TxtFetness.Text.ToString());
                string strtype = TxtType.Text.ToString();
                Int32 intType = Int32.Parse(0.ToString());
                decimal nameplate = decimal.Parse(TxtLateFine.Text.ToString());
                decimal drc = decimal.Parse(0.ToString());
                decimal ownership = decimal.Parse(TxtAIT.Text.ToString());
                decimal addresschange = decimal.Parse(0.ToString());
                decimal bodyvat = decimal.Parse(0.ToString());
                decimal certificate = decimal.Parse(0.ToString());
                decimal duplicatedcopy = decimal.Parse(0.ToString());
                decimal miscellounes = decimal.Parse(TxtMisccelnewss.Text.ToString());
                DateTime expairdate = DateTime.Parse(TextExpDate.Text);
                DateTime nextExpairdate = DateTime.Parse(TxtNextExpDate.Text);
                string certificatedNo = "01".ToString();
                string unit = TxtUnit.Text.ToString();
                
                intItem = 3;
               dt=objRenewal.InsertVehicleFitness(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
               ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
            }
            else { }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 

        

        }
    }
}
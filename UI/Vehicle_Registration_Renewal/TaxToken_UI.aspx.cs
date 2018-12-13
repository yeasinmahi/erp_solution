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
    public partial class TaxToken_UI : System.Web.UI.Page
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
                dt = objRenewal.unitnamewithAssetname(assetid);
                if (dt.Rows.Count > 0)
                {
                    txtVehicleName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    try { TxtUnit.Text = dt.Rows[0]["strVehicleRegisteredTo"].ToString(); }
                    catch { };
                    try { TxtVehicleType.Text = dt.Rows[0]["strItem"].ToString(); }
                    catch { };
                    try { TxtToken.Text = dt.Rows[0]["monTaxTokenFeeWithVat"].ToString(); }
                    catch { };
                    try { TxtLateFine.Text = dt.Rows[0]["monTaxTokenLatefinein3month10Percentage"].ToString(); }
                    catch { };
                    lbprsntus.Text = dt.Rows[0]["strUnit1"].ToString();



                }
                

            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {
            //Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.AutoSearchVehicleNo(prefixText);
        }




        protected void BtnTaxToken_Click(object sender, EventArgs e)
        {


            string assetid = Session["strasset"].ToString();
            Int32 expDay = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            DateTime dtereg = DateTime.Parse(TxtDteRenewal.Text.ToString());
            decimal registrationTaka = decimal.Parse(TxtToken.Text.ToString());
            string strtype = TxtVehicleType.Text.ToString();
            Int32 intType = Int32.Parse(0.ToString());
            decimal nameplate = decimal.Parse(TxtLateFine.Text.ToString());
            decimal drc = decimal.Parse(0.ToString());
            decimal ownership = decimal.Parse(0.ToString());
            decimal addresschange = decimal.Parse(0.ToString());
            decimal bodyvat = decimal.Parse(0.ToString());
            decimal certificate = decimal.Parse(0.ToString());
            decimal duplicatedcopy = decimal.Parse(0.ToString());
            decimal miscellounes = decimal.Parse(TxtMiscellcuneces.Text.ToString());
            DateTime expairdate = DateTime.Parse(TxtDteExpDate.Text);
            DateTime nextExpairdate = DateTime.Parse(TxtNextExpDte.Text);
            string certificatedNo = "01".ToString();
            string unit = TxtUnit.Text.ToString();

            intItem = 2;
            dt = objRenewal.InsertVehicleTaxTokenInsert(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                 ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('already exists');", true);

            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        }



    }
}
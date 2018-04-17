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
    public partial class Insurance_UI : System.Web.UI.Page
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //DateTime nextexpdate = DateTime.Parse(TxtNextExpDte.Text);
                string ID = Session["strID"].ToString();
                string strAssetid = Session["strasset"].ToString();
                string assetid = strAssetid.ToString();



                dt = new DataTable();
                //string assetid=txtAssetID.Text.ToString();
                dt = objRenewal.unitnamewithAssetname(assetid);
                if (dt.Rows.Count > 0)
                {
                    txtVehicleName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    try { TxtUnit.Text = dt.Rows[0]["strVehicleRegisteredTo"].ToString(); }
                    catch { };
                    try { TxtInsurence.Text = dt.Rows[0]["monInsuranceFee"].ToString(); }
                    catch { };
                    try { TxtVehicleType.Text = dt.Rows[0]["strItem"].ToString(); }
                    catch { };
                    TxtInsuranceCompany.Text = "Rupali";
              }
                

             
               

            }
        }
       

      

        protected void BtnInsurance_Click(object sender, EventArgs e)
        {
           
             
              
               string assetid = Session["strasset"].ToString();
                Int32 expDay = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                DateTime dtereg = DateTime.Parse(TextRenwalDte.Text.ToString());
                decimal registrationTaka = decimal.Parse(TxtInsurence.Text.ToString());
                string strtype = TxtInsuranceCompany.Text.ToString();
                Int32 intType = Int32.Parse(0.ToString());
                decimal nameplate = decimal.Parse("0");//InsuranceCompany
                decimal drc = decimal.Parse(0.ToString());
                decimal ownership = decimal.Parse(0.ToString());
                decimal addresschange = decimal.Parse(0.ToString());
                decimal bodyvat = decimal.Parse(0.ToString());
                decimal certificate = decimal.Parse(0.ToString());
                decimal duplicatedcopy = decimal.Parse(0.ToString());
                decimal miscellounes = decimal.Parse(0.ToString());
                DateTime expairdate = DateTime.Parse("1990-01-1".ToString());
                DateTime nextExpairdate = DateTime.Parse(TextRenwalDte.Text.ToString());
                string certificatedNo = TxCertificateCopyNot.Text.ToString();
                string unit = TxtUnit.Text.ToString();
               
                intItem = 5;
               dt=objRenewal.InsertVehicleInsurance(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                    ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);


        }
    }
}
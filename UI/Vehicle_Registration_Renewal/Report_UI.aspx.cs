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
    public partial class Report_UI :BasePage
    {
        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem; string assetid;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
               
            dt = objRenewal.UnitNameGet();
            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataBind();
            pnlUpperControl.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("All", "0"));
            ddlShipPoint.Items.Insert(0, new ListItem("All", "0"));
          }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetNumber(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 Active = Int32.Parse(1.ToString());
            return objAutoSearch_BLL.SearchVehicleAssetData(Active, prefixText);

        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            DateTime expairdate, nextExpairdate;
            string unit = ddlUnit.SelectedItem.ToString();
            try { expairdate = DateTime.Parse(txtFromDate.Text); }
            catch { expairdate = DateTime.Parse("1990-01-01".ToString()); }
            try { nextExpairdate = DateTime.Parse(txtToDate.Text); }
            catch { nextExpairdate = DateTime.Parse("1990-01-01".ToString()); }

           
            Int32 expDay = Int32.Parse(ddlShipPoint.SelectedValue.ToString());
            //Service Type use expDay


            assetid = "0".ToString();

            DateTime dtereg = DateTime.Parse("1990-01-01".ToString());
            decimal registrationTaka = decimal.Parse("0".ToString());
            string strtype = ddlShipPoint.SelectedItem.ToString();
            Int32 intType = Int32.Parse(ddlShipPoint.SelectedValue.ToString());
            decimal nameplate = decimal.Parse("0".ToString());//InsuranceCompany
            decimal drc = decimal.Parse(0.ToString());
            decimal ownership = decimal.Parse(0.ToString());
            decimal addresschange = decimal.Parse(0.ToString());
            decimal bodyvat = decimal.Parse(0.ToString());
            decimal certificate = decimal.Parse(0.ToString());
            decimal duplicatedcopy = decimal.Parse(0.ToString());
            decimal miscellounes = decimal.Parse(0.ToString());

            string certificatedNo = "0".ToString();
            if (!String.IsNullOrEmpty(TxtName.Text))
            {
                string strSearchKey = TxtName.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];
                assetid = hdfEmpCode.Value.ToString();
                intItem = 11;
                dt = new DataTable();
                dt = objRenewal.ReportRegistrationView(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }

            else

            {
                intItem = 10;
                dt = new DataTable();
                dt = objRenewal.ReportRegistrationView(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
           
           

            
                
        }
        public string GetJSFunctionString(object AutoID, object intServiceID)
        {
            string str = "";
            str = AutoID.ToString() + ',' + intServiceID.ToString();
            return str;
        }
        protected void BtnDetails_Click(object sender, EventArgs e)
        {
            
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string ordernumber1 = datas[0].ToString();
                string ordernumber2 = datas[1].ToString();
              
                Int32 AutoID = Int32.Parse(ordernumber1.ToString());
                Session["AutoID"] = ordernumber1;
                Session["strasset"] = ordernumber2;

                if (ordernumber2 == "310078")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationReg('Detalis_Registration_UI.aspx');", true);
                }
                // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0] + "','" + datas[1] + "');", true);

                if (ordernumber2 == "310079")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationTax('Detalis_TaxToken_UI.aspx');", true);

                }

                if (ordernumber2 == "310080")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationFetness('Detalis_FitnessAIT_UI.aspx');", true);

                }
                if (ordernumber2 == "310081")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationRoot('Detalis_Rootpermit_UI.aspx');", true);
                }

                if (ordernumber2 == "310082")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationInsurance('Detalis_Insurance_UI.aspx');", true);
                }
                if (ordernumber2 == "310083")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationName('Detalis_NamePlate_UI.aspx');", true);
                }
                if (ordernumber2 == "310108")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationDRC('Detalis_DRC_UI.aspx');", true);

                }
            }
            catch { };
        
        
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string ordernumber1 = datas[0].ToString();
                string ordernumber2 = datas[1].ToString();

                Int32 AutoID = Int32.Parse(ordernumber1.ToString());
                Session["AutoID"] = ordernumber1;
                Session["strasset"] = ordernumber2;

                if (ordernumber2 == "310078")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationReg('Print_Registration_UI.aspx');", true);
                }
                // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0] + "','" + datas[1] + "');", true);

                if (ordernumber2 == "310079")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationTax('Print_TaxToken_UI.aspx');", true);

                }

                if (ordernumber2 == "310080")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationFetness('Print_FitnessAIT_UI.aspx');", true);

                }
                if (ordernumber2 == "310081")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationRoot('Print_Rootpermit_UI.aspx');", true);
                }

                if (ordernumber2 == "310082")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationInsurance('Print_Insurance_UI.aspx');", true);
                }
                if (ordernumber2 == "310083")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationName('Print_NamePlate_UI.aspx');", true);
                }
                if (ordernumber2 == "310108")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationDRC('Print_DRC_UI.aspx');", true);

                }
            }
            catch { };
        }
    }
}
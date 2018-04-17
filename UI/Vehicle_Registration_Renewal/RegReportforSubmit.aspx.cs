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
using System.Drawing;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class RegReportforSubmit : BasePage
    {

        RegistrationRenewals_BLL objRenewal = new RegistrationRenewals_BLL();
        DataTable dt = new DataTable();
        int intItem; string assetid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dt = objRenewal.UnitNameGet();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, new ListItem("All", "0"));
               
                pnlUpperControl.DataBind();
            }

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            DateTime nextExpairdate, expairdate;
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
            try {  expairdate = DateTime.Parse(txtFromDate.Text); }
            catch {  expairdate = DateTime.Parse("1990-01-01".ToString()); }
            try {  nextExpairdate = DateTime.Parse(txtToDate.Text); }
            catch {  nextExpairdate = DateTime.Parse("1990-01-01".ToString()); }
           
            string certificatedNo = "0".ToString();
            string unit = ddlUnit.SelectedItem.ToString();
            Int32 expDay = Int32.Parse(ddlUnit.SelectedValue.ToString());

            if (!String.IsNullOrEmpty(TxtAsset.Text))
            {
                string strSearchKey = TxtAsset.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];
                assetid = hdfEmpCode.Value.ToString();
                intItem = 8;
                dt = objRenewal.RegistrtionReportForSubmit(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                 ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            else
            {
                intItem = 9;
                dt = objRenewal.RegistrtionReportForSubmit(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                 ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
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
        public string GetJSFunctionString(object AutoID, object strAssetID)
        {
            string str = "";
            str = AutoID.ToString() + ',' + strAssetID.ToString();
            return str;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    var tes = (Label)e.Row.FindControl("lblServiceName");
            //    foreach (TableCell cell in e.Row.Cells)
            //    {
            //        if (tes.Text == "0" || tes.Text == "null" || tes.Text == "0.0000" || tes.Text == "")
            //        {
            //            cell.BackColor = Color.YellowGreen;
                       

            //        }
            //        else
            //        {
            //            cell.BackColor = Color.Empty;
            //        }
            //    }
            //}


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
                //string ordernumber3 = datas[2].ToString();
                Session["strID"] = ordernumber1;
                Session["strasset"] = ordernumber2;
                int type = int.Parse(ddlShipPoint.SelectedValue.ToString());
                if (type == 310078)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationReg('Registration_UI.aspx');", true);

                }
                else if (type == 310079)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationTax('TaxToken_UI.aspx');", true);

                }
                else if (type == 310080)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationFetness('Fitness_AIT_UI.aspx');", true);
                }
                else if (type == 310081)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationRoot('RoutePermit.aspx');", true);
                }
                else if (type == 310082)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationInsurance('Insurance_UI.aspx');", true);
                }
                else if (type == 310083)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationName('NamePlate_UI.aspx');", true);
                }
                else if (type == 310108)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationDRC('DRC_UI.aspx');", true);
                }


                
            }
            catch { };
        }

        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
    }
}
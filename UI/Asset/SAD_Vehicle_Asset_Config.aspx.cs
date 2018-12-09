using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Asset
{
    public partial class SAD_Vehicle_Asset_Config : System.Web.UI.Page
    {
        AssetParking_BLL objParking = new AssetParking_BLL();
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["vehicleType"] = ddlType.SelectedValue.ToString();
            }
            else
            {

            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehilcle(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            int type =int.Parse(HttpContext.Current.Session["vehicleType"].ToString());
            if (type == 1)
            {
                return objAutoSearch_BLL.GetStufVehicleList(Active, prefixText);
            }
            else
            {
                return objAutoSearch_BLL.GetInternalVehicleList(Active, prefixText);
            }
          

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetSearch(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
           
            return objAutoSearch_BLL.GetAssetVehicle(8, prefixText);
            


        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                Session["vehicleType"] = ddlType.SelectedValue.ToString();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtAssetId.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                int intAssetId = int.Parse(temp1[1].ToString()); 
                string vehicelNumber = txtVehicle.Text.ToString();
                string vehicleType = ddlType.SelectedValue.ToString();

                if (vehicelNumber.Length > 5 && intAssetId>0)
                {
                    if (vehicleType == "1")
                    {
                          msg = objParking.UpdateFuelLogVehicle(vehicelNumber, intAssetId);
                    }
                    else if (vehicleType == "2")
                    {
                          msg = objParking.UpdateSadVehicle(vehicelNumber, intAssetId);
                    }
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+msg+"');", true);
                }

            }
            catch { }
        }
    }
}
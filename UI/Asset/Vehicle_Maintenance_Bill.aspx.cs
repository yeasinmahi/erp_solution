using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.IO;

namespace UI.Asset
{
    public partial class Vehicle_Maintenance_Bill : BasePage
    {

        AssetMaintenance objBill = new AssetMaintenance();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Int32 Mnumber = Convert.ToInt32("0".ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


                intItem = 60;
                dt = objBill.ReportDetalisParts(intItem, Mnumber, intenroll, intjobid, intdept);
                dgview.DataSource = dt;
                dgview.DataBind();
              
                

               

                
            }
        }

        protected void BtnMDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                
                Session["intMaintenanceNo"] = ordernumber1;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ReportDetalis('Vehicle_Bill_Detalis_PopUp.aspx');", true);

            }
            catch { }
        }
    }
}
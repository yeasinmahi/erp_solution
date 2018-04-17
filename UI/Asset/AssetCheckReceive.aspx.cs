using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class AssetCheckReceive : BasePage
    {
        AssetInOut objCheck = new AssetInOut();
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType, intActionBy; string assetCode, strNaration, stringXml;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept   = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid  = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                LoadData();
                
                pnlUpperControl.DataBind();
            }
        }

        private void LoadData()
        {
            try
            {
                intResEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                
                dt = objCheck.AssetCheckInOutDataTable(4, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                dgvGetpassRecieve.DataSource = dt;//receive View
                dgvGetpassRecieve.DataBind();

                dt = objCheck.AssetCheckInOutDataTable(5, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                dgvStatus.DataSource = dt;//asset Summery
                dgvStatus.DataBind();
            }
            catch { }

        }
         


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int receiveID = int.Parse(searchKey[0].ToString());
                intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                string messages = objCheck.AssetCheckInOutAction(6, stringXml, receiveID, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messages + "');", true);
                LoadData();

            }
            catch { }

        }
    }
}
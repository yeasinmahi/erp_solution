using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;

using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;

namespace UI.Asset
{
    public partial class AssetCheckInOut :BasePage
    {

        AssetInOut objCheck = new AssetInOut();        
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType,intActionBy;string assetCode, strNaration,stringXml;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                LoadData();
                //   checkreport = objCheck.DgvReprotAllCheckinout();
                //  dgvservice.DataSource = checkreport;
                //  dgvservice.DataBind();
                pnlUpperControl.DataBind();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmployeeAutoSearch(string prefixText, int count)
        {           
                AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
                Boolean Active = true;
                return objAutoSearch_BLL.GetEmployeeLists(Active, prefixText);
                 
        }


        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string number = TxtAsset.Text.ToString();
                dt = objCheck.ShowassetData(number);
                if (dt.Rows.Count > 0)
                {
                    TxtName.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                    TxtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    TxtStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                    TxtNarration.Text = dt.Rows[0]["Detalis"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
            catch { }
        }

        

      

        protected void ddlWHidSt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWHiD = int.Parse(ddlWHidSt.SelectedValue);
                dt = objCheck.AssetCheckInOutDataTable(3, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                ddlResponsiblePersonSt.DataSource = dt;
                ddlResponsiblePersonSt.DataTextField = "strEmployeeName";
                ddlResponsiblePersonSt.DataValueField = "intEmployeeID";
                ddlResponsiblePersonSt.DataBind();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnInStoreDiv();", true);
            }
            catch { }
           

        }

        protected void ddlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWHiD = int.Parse(ddlWareHouse.SelectedValue);
                dt = objCheck.AssetCheckInOutDataTable(3, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                ddlResposiblePersonEx.DataSource = dt;
                ddlResposiblePersonEx.DataTextField = "strEmployeeName";
                ddlResposiblePersonEx.DataValueField = "intEmployeeID";
                ddlResposiblePersonEx.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnExpireDiv();", true);

            }
            catch { }
          
        }

        protected void DdlServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(DdlServiceType.SelectedItem.ToString()== "InUse")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnInUseDiv();", true);

            }
           else if(DdlServiceType.SelectedItem.ToString() == "InStore")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnInStoreDiv();", true);
            }
            else if (DdlServiceType.SelectedItem.ToString() == "Expire")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnExpireDiv();", true);
            }

        }

        protected void btnInUseAction_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtResponsibleInUse.Text.Split(delimiterChars);

                if (arrayKey.Length > 0)
                {
                    intResEnroll = int.Parse(arrayKey[1].ToString());
                    assetCode = TxtAsset.Text.ToString();
                    strNaration = txtInuseNaration.Text.ToString();
                    intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intType = 1;
                    string messages = objCheck.AssetCheckInOutAction(1, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messages + "');", true);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnInUseDiv();", true);
                }
            }
            catch { }

           
        }

        protected void btnInStore_Click(object sender, EventArgs e)
        {
            try
            {
                intWHiD = int.Parse(ddlWHidSt.SelectedValue);
                intResEnroll = int.Parse(ddlResponsiblePersonSt.SelectedValue);
                assetCode = TxtAsset.Text.ToString();
                strNaration = txtInStoreNaration.Text.ToString();
                intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                intType = 2;
                string messages = objCheck.AssetCheckInOutAction(1, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messages + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnInStoreDiv();", true);
            }
            catch { }
        }

        protected void btnExpire_Click(object sender, EventArgs e)
        {
            try
            {
               
                    

                    intWHiD = int.Parse(ddlWHidSt.SelectedValue);
                    intResEnroll = int.Parse(ddlResponsiblePersonSt.SelectedValue);
                    assetCode = TxtAsset.Text.ToString();
                    strNaration = txtInStoreNaration.Text.ToString();
                    intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    DateTime dteExpire = DateTime.Parse(txtDteExpire.Text);
                    intType = 3;
                    string messages = objCheck.AssetCheckInOutAction(1, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + messages + "');", true);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnExpireDiv();", true);
            }


            catch { }



        }

        private void LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objCheck.AssetCheckInOutDataTable(2, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                ddlWareHouse.DataSource = dt;
                ddlWareHouse.DataTextField = "strWareHoseName";
                ddlWareHouse.DataValueField = "intWHID";
                ddlWareHouse.DataBind();

                ddlWHidSt.DataSource = dt;
                ddlWHidSt.DataTextField = "strWareHoseName";
                ddlWHidSt.DataValueField = "intWHID";
                ddlWHidSt.DataBind();

                intWHiD = int.Parse(ddlWHidSt.SelectedValue);
                dt = objCheck.AssetCheckInOutDataTable(3, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                ddlResponsiblePersonSt.DataSource = dt;
                ddlResponsiblePersonSt.DataTextField = "strEmployeeName";
                ddlResponsiblePersonSt.DataValueField = "intEmployeeID";
                ddlResponsiblePersonSt.DataBind();
                               
                ddlResposiblePersonEx.DataSource = dt;
                ddlResposiblePersonEx.DataTextField = "strEmployeeName";
                ddlResposiblePersonEx.DataValueField = "intEmployeeID";
                ddlResposiblePersonEx.DataBind();

            }
            catch { }
           
            

        }
    }
}
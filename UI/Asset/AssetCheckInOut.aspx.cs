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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class AssetCheckInOut :BasePage
    {

        AssetInOut objCheck = new AssetInOut();        
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType,intActionBy;string assetCode,  number,strNaration,stringXml;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\AssetCheckInOut";
        string stop = "stopping Asset\\AssetCheckInOut";
       
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
                HttpContext.Current.Session["type"] = "1".ToString();
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
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetAutoSearch(string prefixText, int count)
        { 
 
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            int type = Convert.ToInt32(HttpContext.Current.Session["type"].ToString());
            if(type==1)
            {
                string[] a = new string[] { prefixText };
                return a;
            }
            else
            {
                return objAutoSearch_BLL.GetAssetItem(Active, prefixText);
            }
           

        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                int type = Convert.ToInt32(HttpContext.Current.Session["type"].ToString());
                if (type == 2)
                {
                    arrayKey = TxtAsset.Text.Split(delimiterChars);
                    string assetId = ""; string assetName = ""; string assetType = ""; int assetAutoId = 0;
                    if (arrayKey.Length > 0)
                    { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); number =(arrayKey[3].ToString()); assetType = arrayKey[5].ToString();}
                     
                }
                else
                {
                      number = TxtAsset.Text.ToString();
                }
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

        protected void radSearch_CheckedChanged(object sender, EventArgs e)
        {
             
            HttpContext.Current.Session["type"] = "2".ToString();
            TxtAsset.Text = "";
        }

        protected void radBarcode_CheckedChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Session["type"] = "1".ToString();
            TxtAsset.Text = "";
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
            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckInOut   btnInUseAction_Click ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();



        }

        protected void btnInStore_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckInOut   Save ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

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
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckInOut   Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();




        }
    }
}
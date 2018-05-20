using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using SCM_BLL;
using System.Data;
using SAD_BLL.AutoChallan;
using UI.ClassFiles;
using System.Xml;
using System.IO;


namespace UI.SCM.Transfer
{
    public partial class frmTransferReceive : BasePage
    {      
        int intShipid,Unitid,Productionid,autoid,intLocationid,intOutWHid,intWHID,intVid,intUomid, vid, enroll, itemid, intReff = 0,inttTransferTypeid;
        decimal Qty,Values,Stock;string xmlpath = "",UOM,msg,Remarks;
        DateTime dtedate;
        DataTable dt;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        TransferBLLNew TBLL = new TransferBLLNew();
        ExcelDataBLL objExcel = new ExcelDataBLL();     
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SCM/Data/TOrder_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                hdnEnroll.Value = "1";
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = TBLL.getWhbyuser(int.Parse(Session[SessionParams.USER_ID].ToString()));
                ddlshippoint.DataTextField = "strDescription";
                ddlshippoint.DataValueField = "intWHID";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                getLocation();
                getTransferInId();

            }
            else {  }
        }
        protected void ddlshippoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLocation();
        }
        private void getLocation()
        {
          //  dt = TBLL.getLocationList("553");
          //  ddlLocation.DataTextField = "strLocationName";
          //  ddlLocation.DataValueField = "intStoreLocationID";
           // ddlLocation.DataSource = dt;
           // ddlLocation.DataBind();
           
        }
        private void getLocations()
        {
            dt = TBLL.getLocationListof(ddlshippoint.SelectedValue.ToString());
            ddlLocation.DataTextField = "strLocationName";
            ddlLocation.DataValueField = "intStoreLocationID";
            ddlLocation.DataSource = dt;
            ddlLocation.DataBind();

        }

        protected void ddlProductionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = TBLL.getProductionItemList(int.Parse(ddlProductionList.SelectedValue));
            ddlItem.DataTextField = "strItem";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dt;
            ddlItem.DataBind();
           // getTransferInId();

            txtQty.Text = dt.Rows[0]["numSendStoreQty"].ToString();
            lblFromDate.Text = dt.Rows[0]["EntryTime"].ToString();
            hdnTransfromValue.Value = dt.Rows[0]["intAutoID"].ToString();

        }
       
       
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTransferInId();
        }
        protected void btnSave_Click(object sender, EventArgs e)
         {
                Unitid = int.Parse(Session[SessionParams.USER_ID].ToString());
                intReff = 0;
                intWHID = int.Parse(ddlshippoint.SelectedValue);
                Productionid= int.Parse(ddlProductionList.SelectedValue);
                intLocationid = int.Parse(ddlLocation.SelectedValue);
                itemid = int.Parse(ddlItem.SelectedValue);
                if(txtQty.Text=="0")
                { Qty = Decimal.Parse("0"); }
                else { Qty = Decimal.Parse(txtQty.Text); }
                Values = (decimal.Parse(hdnTransfromValue.Value));
                autoid = int.Parse(hdnTransfromValue.Value);
                dtedate =DateTime.Parse(lblFromDate.Text.ToString());
                dtedate =DateTime.Parse(dtedate.ToString("yyyy-mm-dd"));
                inttTransferTypeid = 1;
               
                TBLL.ReceiveEntry(autoid,itemid,dtedate,Qty,int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWHID, intLocationid);
                TBLL.ReceiveUpdate(Qty,Productionid, itemid,Unitid);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Receive');", true);  
          }     
        protected void ddlShipPointTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTransferInId();
        }       
        private void getTransferInId()
        {
            dt = TBLL.GetTransferReceive(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlProductionList.DataTextField = "intProductionID";
            ddlProductionList.DataValueField = "intProductionID";
            ddlProductionList.DataSource = dt;
            ddlProductionList.DataBind();
            dt = TBLL.getProductionItemList(int.Parse(ddlProductionList.SelectedValue));
            txtQty.Text = dt.Rows[0]["numSendStoreQty"].ToString();
            lblFromDate.Text = dt.Rows[0]["EntryTime"].ToString();
            hdnTransfromValue.Value = dt.Rows[0]["intAutoID"].ToString();


        }

    }
}

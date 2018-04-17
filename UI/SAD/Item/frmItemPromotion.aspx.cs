﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Item;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;

namespace UI.SAD.Item
{
    public partial class frmItemPromotion : System.Web.UI.Page
    {
        DataTable dt;int Custid,intActive,rptTYpe,intLineid,intGroupid,PUomId, ItemidSales,ItemidPromotion,Groupid, Rid, Aid,part,intUomid;        
        ItemPromotion objPromotion = new ItemPromotion();
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };  string ItemName,batchno, PromotionName, msg;
        DateTime dteFdate, dteTdate; decimal SalesQty, PromotionQty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                Datainitialization();               
            }
        }

        private void Datainitialization()
        {

            dt = objPromotion.getRegionList();
            ddlRegion.DataTextField = "strRegion";
            ddlRegion.DataValueField = "intRegionId";
            ddlRegion.DataSource = dt;
            ddlRegion.DataBind();

            dt = new DataTable();
            dt = objPromotion.getUom(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlUom.DataTextField = "struom";
            ddlUom.DataValueField = "intid";
            ddlUom.DataSource = dt;
            ddlUom.DataBind();
            ddlPUOM.DataTextField = "struom";
            ddlPUOM.DataValueField = "intid";
            ddlPUOM.DataSource = dt;
            ddlPUOM.DataBind();

            dt = new DataTable();
            dt = objPromotion.GetLine();
            ddlLine.DataTextField = "strFGGroupName";
            ddlLine.DataValueField = "intFGGroupID";
            ddlLine.DataSource = dt;
            ddlLine.DataBind();
            Arealist();

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetItem(prefixText);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] CustomerSearch(string prefixText, int count = 0)
        {
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetCstomer(prefixText);

        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arealist();
        }
        private void Arealist()
        {
            dt = objPromotion.GetareaName(int.Parse(ddlRegion.SelectedValue),int.Parse(ddlLine.SelectedValue));
            ddlAreaList.DataTextField = "strarea";
            ddlAreaList.DataValueField = "intareaid";
            ddlAreaList.DataSource = dt;
            ddlAreaList.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPromotionName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {

                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    Custid = int.Parse(arrayKeyItem[1].ToString());
                }
                else { Custid = int.Parse("0"); }
                arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                ItemidSales = int.Parse(arrayKeyItem[1].ToString());

                arrayKeyItem = txtPromotionItem.Text.Split(delimiterCharss);
                ItemidPromotion = int.Parse(arrayKeyItem[1].ToString());
                intUomid = int.Parse(ddlUom.SelectedValue);
                intLineid = int.Parse(ddlLine.SelectedValue);
                Rid = int.Parse(ddlRegion.SelectedValue);
                Aid = int.Parse(ddlAreaList.SelectedValue);
                Groupid = int.Parse(ddlPGroup.SelectedValue);
                dteFdate = DateTime.Parse(txtFrom.Text);
                if (txtTo.Text == "")
                { dteTdate = DateTime.Parse("2009-1-1"); }
                else { dteTdate = DateTime.Parse(txtTo.Text); }


                SalesQty = decimal.Parse(txtSalesQty.Text);
                PromotionQty = decimal.Parse(txtPromQty.Text);
                PUomId = int.Parse(ddlPUOM.Text);
                part = int.Parse(ddlPGroup.SelectedValue);
                PromotionName = txtPromotionName.Text;

                msg = objPromotion.getPromotionEntry(part, Custid, PromotionName, ItemidSales, intUomid, SalesQty, ItemidPromotion, PUomId, PromotionQty, int.Parse(Session[SessionParams.UNIT_ID].ToString()), dteFdate, dteTdate, Rid, Aid, intLineid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Entry Promotion Name');", true); }
            }
        protected void btnReport_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            if (int.Parse(ddlReportBy.SelectedValue) == 1)
            {
                if (txtSalesItem.Text != "")
                {
                    arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                    ItemidSales = int.Parse(arrayKeyItem[1].ToString());
                }
                else { ItemidSales = 0; }
                intActive = int.Parse(ddlReporType.SelectedValue);
                dt = objPromotion.getPromotionReport(intActive, 1, 0, ItemidSales);
            }
            else
            {
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    Custid = int.Parse(arrayKeyItem[1].ToString());
                }
                else { Custid = int.Parse("0"); }
                arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                ItemidSales = int.Parse(arrayKeyItem[1].ToString());

                intActive = int.Parse(ddlReporType.SelectedValue);
                dt = objPromotion.getPromotionReport(intActive, 2, Custid, ItemidSales);

            }
            dgvPromotionReport.DataSource = dt;
            dgvPromotionReport.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtPromotionName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    Custid = int.Parse(arrayKeyItem[1].ToString());
                }
                else { Custid = int.Parse("0"); }
                arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                ItemidSales = int.Parse(arrayKeyItem[1].ToString());
            }
            dteTdate =DateTime.Parse(txtTo.Text);
            batchno = txtPromotionName.Text;
            part =int.Parse(ddlCancelType.SelectedValue);
 

            objPromotion.getNationalPINactiveEnd(dteTdate, ItemidSales, batchno, Custid, part);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);

        }
    }
}
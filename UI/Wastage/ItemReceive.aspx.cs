using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projects_BLL;
using UI.ClassFiles;

namespace UI.Wastage
{
    public partial class ItemReceive : BasePage
    {
        WastageBLL objWastage = new WastageBLL();
        int intItemid, intTransactionTypeID,unitid,intinsertby, intWastageWareHouseID, intInOutReffID;
        int? intQty = null, intOutQty=null, intWHID=null, intSalesID=null, intCustromerID=null, intDeliveryChallanNo=null, intWeightIDNo=null,
        intDepartmentID=null, intTransferJobStationID=null, strRequisitionID=null, intTransferUnit=null, intTransferWastageWareHouseID=null;
        DateTime dteTransactionDate;
        string itemname, strRemarks, strSalesOrderNo; bool ? ysnActive=null, ysnIssueComplete=null;
        Decimal? monInRate = null, monInValue = null, monOutRate=null, monOutValue=null;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objWastage.getReffid();
                hdnReffid.Value = dt.Rows[0]["intReceiveID"].ToString();
                dt = objWastage.getWH(int.Parse(Session[SessionParams.USER_ID].ToString()));
                ddlWHName.DataTextField = "strWastageWareHouseName";
                ddlWHName.DataValueField = "intWastageWHID";
                ddlWHName.DataSource = dt;
                ddlWHName.DataBind();
                Itemlist();
            }
        }
        private void Itemlist()
        {
            dt = objWastage.ItemListRpt(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlItem.DataTextField = "strItemName";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dt;
            ddlItem.DataBind();
        }
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = objWastage.getIteminfo(ddlItem.SelectedValue);
            txtRate.Text = dt.Rows[0]["monRate"].ToString();
            txtUOM.Text = dt.Rows[0]["strUOM"].ToString();          
            hdnRate.Value = dt.Rows[0]["monRate"].ToString();         
            hdnuom.Value = dt.Rows[0]["struom"].ToString();
           
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((txtQty.Text != "")||(txtRecDate.Text!=""))
            {
                if (txtWeightID.Text == "")
                { intWeightIDNo = 0; }
                else { intWeightIDNo = int.Parse(txtWeightID.Text); }
                intItemid = int.Parse(ddlItem.SelectedValue);
                monInRate = decimal.Parse(hdnRate.Value);
                intQty = int.Parse(txtQty.Text);
                dteTransactionDate = DateTime.Parse(txtRecDate.Text);
                monInValue = intQty * monInRate;
                intTransactionTypeID = 1;
                unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                intinsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                ysnActive = true;
                strRemarks = txtRemarks.Text;
                intWeightIDNo = 0;
                intWastageWareHouseID = int.Parse(ddlWHName.SelectedValue);
                intInOutReffID = int.Parse(hdnReffid.Value);
                objWastage.getReceiveEntry(intInOutReffID, dteTransactionDate, intItemid, intQty, monInRate, monInValue, intOutQty, monOutRate, monOutValue, intTransactionTypeID, unitid, intinsertby, DateTime.Now, intWHID, ysnActive, strRemarks, ysnIssueComplete, intSalesID, intCustromerID, intDeliveryChallanNo, strSalesOrderNo, intWeightIDNo, intDepartmentID, intTransferJobStationID, strRequisitionID, intTransferUnit, intWastageWareHouseID, intTransferWastageWareHouseID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully.');", true);
                txtQty.Text = "";
                txtRate.Text = "";
                txtRecDate.Text = "";

            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Entry Qty.');", true); }
        }
    }
}
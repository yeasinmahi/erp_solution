using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;

namespace UI.Wastage
{
    public partial class frmAdjustment : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;
       
        string filePathForXML, xmlString, xml, itemid, uom, qty, rate, value, remarks,MRRNO;
        int intEnroll,intItemid, intTransactionTypeID, unitid, intinsertby, intWastageWareHouseID, intInOutReffID;
        int? intQty = null, intOutQty = null, intWHID = null, intSalesID = null, intCustromerID = null, intDeliveryChallanNo = null, intWeightIDNo = null,
        intDepartmentID = null, intTransferJobStationID = null, strRequisitionID = null, intTransferUnit = null, intTransferWastageWareHouseID = null;
        DateTime dteTransactionDate;
        string itemname, strRemarks, strSalesOrderNo; bool? ysnActive = null, ysnIssueComplete = null;
        Decimal? monInRate = null, monInValue = null, monOutRate = null, monOutValue = null;
       
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
           
            filePathForXML = Server.MapPath("~/Wastage/Data/SO_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    dt = new DataTable();
                    dt = obj.GetUnitList(int.Parse(hdnEnroll.Value));
                    ddlUnitName.DataTextField = "strUnit";
                    ddlUnitName.DataValueField = "intUnitID";
                    ddlUnitName.DataSource = dt;
                    ddlUnitName.DataBind();                 
                    WHlist();
                    Itemlist();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        private void Itemlist()
        {
            dt = obj.ItemListRpt(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlItem.DataTextField = "strItemName";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dt;
            ddlItem.DataBind();
        }
        private void WHlist()
        {
            dt = obj.getWHbyUnit(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWareHouseID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
        }
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = obj.getIteminfo(ddlItem.SelectedValue);
            txtRate.Text = dt.Rows[0]["monRate"].ToString(); 
            txtUOM.Text = dt.Rows[0]["strUOM"].ToString(); 
        }
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            if(txtQty.Text!="")
            {
                txtValue.Text = (decimal.Parse(txtQty.Text) * decimal.Parse(txtRate.Text)).ToString() ;
            }
        }
       
        #region ===== Item Add & Load Grid Action ===========================================================
       

        protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion ==========================================================================================

        #region ===== Submit Action =========================================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if ((txtQty.Text != "") && (txtRate.Text != ""))
                {
                    intItemid = int.Parse(ddlItem.SelectedValue);
                    monOutRate = decimal.Parse(txtRate.Text);
                    intOutQty = int.Parse(txtQty.Text);
                    dteTransactionDate = DateTime.Parse(txtSODate.Text);
                    monOutValue = intQty * monInRate;
                    intTransactionTypeID = 6;
                    unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    intinsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                    ysnActive = true;
                    strRemarks = txtRemarks.Text;
                    intWastageWareHouseID = int.Parse(ddlWHName.SelectedValue);
                    intInOutReffID = int.Parse("0");

                    obj.getReceiveEntry(intInOutReffID, dteTransactionDate, intItemid, intQty, monInRate, monInValue, intOutQty, monOutRate, monOutValue, intTransactionTypeID, unitid, intinsertby, DateTime.Now, intWHID, ysnActive, strRemarks, ysnIssueComplete, intSalesID, intCustromerID, intDeliveryChallanNo, strSalesOrderNo, intWeightIDNo, intDepartmentID, intTransferJobStationID, strRequisitionID, intTransferUnit, intWastageWareHouseID, intTransferWastageWareHouseID);
                    txtUOM.Text = "";
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtValue.Text = "";
                    txtRemarks.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully.');", true);
                }
            }
        }

        #endregion ==========================================================================================




























    }
}
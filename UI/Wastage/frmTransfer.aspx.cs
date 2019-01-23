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
    public partial class frmTransfer : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;
        string filePathForXML, strSalesOrderNo, strRemarks, xmlString,  itemid, uom, qty, rate, value, remarks,MRRNO;
        int intItemid, intTransactionTypeID, unitid, intinsertby, intWastageWareHouseID, intInOutReffID;
        int? intQty = null, intOutQty = null, intWHID = null, intSalesID = null, intCustromerID = null, intDeliveryChallanNo = null, intWeightIDNo = null,
        intDepartmentID = null, intTransferJobStationID = null, strRequisitionID = null, intTransferUnit = null, intTransferWastageWareHouseID = null;
        DateTime dteTransactionDate;
        bool? ysnActive = null, ysnIssueComplete = null;
        Decimal? monInRate = null, monInValue = null, monOutRate = null, monOutValue = null;
       
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Wastage/Data/SO_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                    dt = obj.GetUnitList(int.Parse(hdnEnroll.Value));
                    WHlist();
                    Itemlist();
                    DepartmentList();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void DepartmentList()
        {
            dt = obj.deptList();
            ddlDpt.DataTextField = "strDepatrment";
            ddlDpt.DataValueField = "intDepartmentID";
            ddlDpt.DataSource = dt;
            ddlDpt.DataBind();
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
            dt = obj.getWHALL();
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWHID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
            ddltowh.DataTextField = "strWastageWareHouseName";
            ddltowh.DataValueField = "intWastageWHID";
            ddltowh.DataSource = dt;
            ddltowh.DataBind();
        }
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = obj.getIteminfo(ddlItem.SelectedValue);
            txtRate.Text = dt.Rows[0]["monRate"].ToString(); 
            txtUOM.Text = dt.Rows[0]["strUOM"].ToString();
            dt = obj.getOpeningStock(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(ddlItem.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                hdnOpening.Value = dt.Rows[0]["intOpeningQty"].ToString();
            }
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
           
                if ((txtQty.Text != "") && (txtRate.Text != ""))
                {
                    intItemid = int.Parse(ddlItem.SelectedValue);
                if (txtRate.Text == "")
                { monOutRate = 0; }
                else
                {
                    monOutRate = decimal.Parse(txtRate.Text);
                }
                    
                    intOutQty = int.Parse(txtQty.Text);
                    dteTransactionDate = DateTime.Parse(txtSODate.Text);
                    monOutValue = intOutQty * monOutRate;
                    intTransactionTypeID = 4;
                    unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    intinsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                    
                    ysnActive = true;
                    strRemarks = txtRemarks.Text;
                    intWastageWareHouseID = int.Parse(ddlWHName.SelectedValue);
                    intTransferWastageWareHouseID = int.Parse(ddltowh.SelectedValue);
                    intDepartmentID = int.Parse(ddlDpt.SelectedValue);
                    if (txtRequNo.Text != "")
                    {
                        strRequisitionID = int.Parse(txtRequNo.Text);
                    }
                    else { strRequisitionID = 0; }
                    if (decimal.Parse(hdnOpening.Value) < decimal.Parse(txtQty.Text))
                    {
                        obj.getReceiveEntry(intInOutReffID, dteTransactionDate, intItemid, intQty, monInRate, monInValue, intOutQty, monOutRate, monOutValue, intTransactionTypeID, unitid, intinsertby, DateTime.Now, intWHID, ysnActive, strRemarks, ysnIssueComplete, intSalesID, intCustromerID, intDeliveryChallanNo, strSalesOrderNo, intWeightIDNo, intDepartmentID, int.Parse(Session[SessionParams.JOBSTATION_ID].ToString()), strRequisitionID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWastageWareHouseID, intTransferWastageWareHouseID);
                        txtUOM.Text = "";
                        txtQty.Text = "";
                        txtRate.Text = "";
                        txtValue.Text = "";
                        txtRemarks.Text = "";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Material Receive.');", true);
                    }

                }
            
        }

        #endregion ==========================================================================================




























    }
}
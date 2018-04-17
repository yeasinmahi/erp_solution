using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.WoodPurchase
{
    public partial class WoodMRRAMFL : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        string filePathForXML, strChallan, strMsg;
        int intEnroll, intWH, intPOID, intChallan, intSupplierID; string strDate;
        decimal numPOQty, numRecQty, monInstallment, monAdvance, monLoanReturnAmount, monLoanInstallmentAndReturn, monLoanAmount;
        DateTime dteReceiveDate, dteChallanDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //
                    filePathForXML = Server.MapPath("~/WoodPurchase/Data/LogMRR_" + hdnEnroll.Value + ".xml");

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    
                    LoadPO();
                    LoadChallan();
                    try
                    {
                        hdnDate.Value = ddlChallan.SelectedValue.ToString();
                    }
                    catch { }
                }
            }
            catch { }
        }

        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPO();
            LoadChallan();
        }

        protected void ddlPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChallan();
        }

        private void LoadChallan()
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetChallan(intPOID);
                ddlChallan.DataSource = dt;
                ddlChallan.DataTextField = "intChallan";
                ddlChallan.DataValueField = "dteChallanDate";
                ddlChallan.DataBind();

                dt = new DataTable();
                dt = bll.GetTotalPOQty(intPOID);
                if (dt.Rows.Count > 0)
                {
                    txtPOQty.Text = dt.Rows[0]["intQty"].ToString();
                }
                else
                {
                    txtPOQty.Text = "0";
                }


                dt = new DataTable();
                dt = bll.GetTotalPreReceive(intPOID);
                if (dt.Rows.Count > 0)
                {
                    txtPrereceive.Text = dt.Rows[0]["PreReceive"].ToString();
                }
                else
                {
                    txtPrereceive.Text = "0";
                }

                dt = new DataTable();
                dt = bll.GetSuppID(intPOID);
                if (dt.Rows.Count > 0)
                {
                    hdnSupplierID.Value = dt.Rows[0]["intSupplierID"].ToString();
                    txtLoan.Text = dt.Rows[0]["monInstallmentAmount"].ToString();
                }
                dgvReceive.DataSource = "";
                dgvReceive.DataBind();
                txtReceiveAmountCheck.Text = "";
                txtReceiveQty.Text = "";
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                strDate = hdnDate.Value.ToString();
                intChallan = int.Parse(ddlChallan.SelectedItem.ToString());

                dt = new DataTable();
                dt = bll.GetReportForSubmit(intPOID, strDate, intChallan);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();

                dt = new DataTable();
                dt = bll.GetTotalQtyAmount(intPOID, strDate, intChallan);
                txtReceiveQty.Text = dt.Rows[0]["numTotalQty"].ToString();
                txtReceiveAmountCheck.Text = dt.Rows[0]["TotalAmount"].ToString();
                
            }
            catch { }
        }

        protected void ddlChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnDate.Value = ddlChallan.SelectedValue.ToString();
            }
            catch { }
        }

        private void LoadPO()
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                
                dt = new DataTable();
                dt = bll.GetPOList(intWH);
                ddlPOList.DataSource = dt;
                ddlPOList.DataValueField = "intPOID";
                ddlPOList.DataTextField = "strSupplierName";
                ddlPOList.DataBind();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                numPOQty = decimal.Parse(txtPOQty.Text);
                numRecQty = decimal.Parse(txtPrereceive.Text);
                strDate = hdnDate.Value.ToString();
                dteChallanDate = DateTime.Parse(strDate.ToString());
                dteReceiveDate = DateTime.Now;
                intEnroll = int.Parse(hdnEnroll.Value.ToString());
                monInstallment = decimal.Parse(txtLoan.Text);
                monAdvance = decimal.Parse(txtAdvance.Text);
                intSupplierID = int.Parse(hdnSupplierID.Value.ToString());
                intChallan = int.Parse(ddlChallan.SelectedItem.ToString());
                strChallan = ddlChallan.SelectedItem.ToString();

                if (numPOQty <= numRecQty || dteChallanDate > dteReceiveDate)
                {
                    return;
                }
                dt = new DataTable();
                dt = bll.InsertFinalMRRAMFL(intPOID, intSupplierID, intEnroll, dteReceiveDate, strChallan, dteChallanDate, intChallan, monInstallment, monAdvance);
                strMsg = dt.Rows[0]["MessageBack"].ToString();

                if(monAdvance > 0 && strMsg != "Error")
                {
                    dt = new DataTable();
                    dt = bll.InsertJVAMFL(monAdvance, intSupplierID, intEnroll);
                    strMsg = "MRR NO : "+ strMsg + " Voucher Code No.- " + dt.Rows[0]["strVoucherCode"].ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strMsg + "');", true);
                }
                else if(strMsg != "Error")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + "MRR NO : " + strMsg + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strMsg + "');", true);
                }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something Wrong');", true); }
        }

    }
}
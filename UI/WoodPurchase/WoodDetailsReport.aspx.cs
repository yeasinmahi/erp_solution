using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.WoodPurchase
{
    public partial class WoodDetailsReport : BasePage
    {
        int intEnroll, intWH, intJobStation; DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        DateTime dteFromDate, dteToDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitJobStation(intWH);
                    hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                }
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text.ToString());
                dteToDate = DateTime.Parse(txtToDate.Text.ToString());
                intJobStation = int.Parse(hdnJobStaion.Value.ToString());
                dt = new DataTable();
                dt = bll.GetWoodReport(dteFromDate, dteToDate, intJobStation, 2, 0);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }

        protected decimal totalweight = 0;
        protected decimal deduction = 0;
        protected decimal netweight = 0;
        protected decimal totalamount = 0;
        protected decimal unloadingbill = 0;
        protected decimal netpayable = 0;
        
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalweight += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblTWeight")).Text);
                    deduction += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblDeduction")).Text);
                    netweight += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblNetWeight")).Text);
                    totalamount += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblTAmount")).Text);
                    unloadingbill += decimal.Parse(((Label)e.Row.Cells[16].FindControl("lblUnloading")).Text);
                    netpayable += decimal.Parse(((Label)e.Row.Cells[17].FindControl("lblNetPayable")).Text);
                }
            }
            catch { }
        }
        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
            }
            catch { }
        }

    }
}
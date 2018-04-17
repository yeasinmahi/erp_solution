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
    public partial class WoodTypeWiseReport : BasePage
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
                dt = bll.GetWoodReport(dteFromDate, dteToDate, intJobStation, 5, 0);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strStyle;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strStyle = ((Label)e.Row.Cells[1].FindControl("lblType")).Text;
                    if (strStyle == "Sub Total" || strStyle == "Grand Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.Gray;
                        e.Row.ForeColor = System.Drawing.Color.Black;
                        e.Row.Font.Bold = true;
                    }
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
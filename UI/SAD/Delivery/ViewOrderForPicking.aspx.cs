using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Delivery
{
    public partial class ViewOrderForPicking : BasePage
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DeliveryViewForPendingOrder";
        string stop = "stopping SAD\\Order\\DeliveryViewForPendingOrder";

        SalesOrderView obj = new SalesOrderView(); DataTable dt;
        int intColumnVisible; string strReportType;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
                dgvViewOrder.Columns[9].Visible = true;

                

                if (rdoComplete.SelectedValue == "1")
                {
                    dgvViewOrder.Columns[9].Visible = false;
                }

                try
                {
                    dt = new DataTable();
                    dt = obj.GetPickingCreateStatusData(ddlUnit.SelectedValue());
                    if (dt.Rows.Count > 0)
                    {
                        hdnPickingCreateStatus.Value = dt.Rows[0]["strPickingCreateStatus"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    Toaster(ex.Message,Common.TosterType.Error);
                }
                         

                dgvViewOrder.Columns[2].Visible = true;
                dgvViewOrder.Columns[3].Visible = true;

                if (hdnPickingCreateStatus.Value == "Customer Base")
                {
                    dgvViewOrder.Columns[2].Visible = false;
                    dgvViewOrder.Columns[3].Visible = false;
                }

            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            //dgvViewOrder.DataBind();
        }


        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            //ddlCusType.DataBind();
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlSo.DataBind();
            //ddlCusType.DataBind();
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
            ddlSo.DataBind();
            ddlCusType.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[ClassFiles.SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;

            dt = new DataTable();
            dt = obj.GetPickingCreateStatusData(int.Parse(ddlUnit.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                hdnPickingCreateStatus.Value = dt.Rows[0]["strPickingCreateStatus"].ToString();
            }
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 1) hdnCustomer.Value = temp[temp.Length - 1];
            else hdnCustomer.Value = "";
        }
                
        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvViewOrder.Columns[9].Visible = true;

            if (rdoComplete.SelectedValue == "1")
            {
                dgvViewOrder.Columns[9].Visible = false;
            }

            dgvViewOrder.Columns[2].Visible = true;
            dgvViewOrder.Columns[3].Visible = true;

            if (hdnPickingCreateStatus.Value == "Customer Base")
            {
                dgvViewOrder.Columns[2].Visible = false;
                dgvViewOrder.Columns[3].Visible = false;
            }
        }

        protected void Complete_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intCusID = searchKey[0].ToString();
            string intid = searchKey[1].ToString();
            string PopupType = "Picking";

            if (hdnPickingCreateStatus.Value == "Customer Base")
            {
                strReportType = "Customer_Base";
            }
            else
            {
                strReportType = "Order_Base";
            }
            string orderType = ddlOrderType.SelectedValue.ToString();
            string ShipPointID = ddlShip.SelectedValue;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PickingCustBase('" + intid + "', '" + intCusID + "', '" + strReportType + "', '" + ShipPointID + "', '" + PopupType + "','" + orderType + "' );", true);
        }

        protected void dgvViewOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dgvViewOrder.PageIndex = e.NewPageIndex;
        }



    }
}
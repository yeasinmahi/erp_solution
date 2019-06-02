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

namespace UI.SAD.Delivery
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DeliveryViewForPendingOrder";
        string stop = "stopping SAD\\Order\\DeliveryViewForPendingOrder";

        SalesOrderView obj = new SalesOrderView();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
                dgvViewOrder.Columns[11].Visible = false;
                dgvViewOrder.Columns[12].Visible = false;
                dgvViewOrder.Columns[13].Visible = false;
                dgvViewOrder.Columns[14].Visible = false;

                if (rdoComplete.SelectedValue == "1")
                {
                    dgvViewOrder.Columns[14].Visible = true;
                }
                else if (rdoComplete.SelectedValue == "2")
                {
                    dgvViewOrder.Columns[11].Visible = true;
                    dgvViewOrder.Columns[12].Visible = true;
                    dgvViewOrder.Columns[13].Visible = true;
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
            ddlCusType.DataBind();
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlSo.DataBind();
            ddlCusType.DataBind();
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
        
        protected void Complete_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intCustomerId = searchKey[0].ToString();
                string intid = searchKey[1].ToString();

                string message = obj.DOApprove(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(intid));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                dgvViewOrder.DataBind();
            }
            
        }

        protected void DO_Edit_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intCusID = searchKey[0].ToString();
            string intid = searchKey[1].ToString();
            string PopupType = "DO_Edit";
            string strReportType = "DO_Base";
            string ShipPointID = ddlShip.SelectedValue;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DO_Edit('" + intid + "', '" + intCusID + "', '" + strReportType + "', '" + ShipPointID + "', '" + PopupType + "');", true);
            dgvViewOrder.DataBind();
        }

        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvViewOrder.Columns[11].Visible = false;
            dgvViewOrder.Columns[12].Visible = false;
            dgvViewOrder.Columns[13].Visible = false;
            dgvViewOrder.Columns[14].Visible = false;

            if (rdoComplete.SelectedValue == "1")
            {
                dgvViewOrder.Columns[14].Visible = true;
            }
            else if (rdoComplete.SelectedValue == "2")
            {
                dgvViewOrder.Columns[11].Visible = true;
                dgvViewOrder.Columns[12].Visible = true;
                dgvViewOrder.Columns[13].Visible = true;
            }
        }

        protected void DO_Cancel_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intCustomerId = searchKey[0].ToString();
                string intid = searchKey[1].ToString();

                string message = obj.DOCancel(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(intid));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                dgvViewOrder.DataBind();
            }
        }

        protected void DO_Close_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intCustomerId = searchKey[0].ToString();
                string intid = searchKey[1].ToString();

                string message = obj.DOCancel(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(intid));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                dgvViewOrder.DataBind();
            }
        }

        protected void dgvViewOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dgvViewOrder.PageIndex = e.NewPageIndex;
        }


    }
}
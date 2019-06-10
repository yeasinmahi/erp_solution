using GLOBAL_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Delivery
{
    public partial class DeliveryOrderStatus :BasePage
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        int rpttype;

        SalesOrderView obj = new SalesOrderView();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
                rpttype = int.Parse(rdoComplete.SelectedValue.ToString());
           
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

            dgvDelvOrderStatus.DataBind();
        }


        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[ClassFiles.SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
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
        private void EnableDisable()
        {
            if (dgvDelvOrderStatus.Rows.Count > 0)
            {
                if (dgvDelvOrderStatus.Rows.Count == 1 && txtCode.Text.Length > 0)
                {
                    if (dgvDelvOrderStatus.Rows[0].RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            if (((CheckBox)dgvDelvOrderStatus.Rows[0].Cells[14].Controls[0]).Checked)
                            {
                                rdoComplete.SelectedIndex = 1;
                            }
                            else
                            {
                                rdoComplete.SelectedIndex = 0;
                            }
                        }
                        catch { }
                    }
                }
            }

            if (rdoComplete.SelectedIndex == 0)
            {
                //dgvDelvOrderStatus.Columns[10].Visible = true;
                dgvDelvOrderStatus.Columns[11].Visible = true;
                dgvDelvOrderStatus.Columns[12].Visible = true;
                dgvDelvOrderStatus.Columns[13].Visible = true;
            }
            else
            {
                //dgvDelvOrderStatus.Columns[10].Visible = false;
                dgvDelvOrderStatus.Columns[11].Visible = false;
                dgvDelvOrderStatus.Columns[12].Visible = false;
                dgvDelvOrderStatus.Columns[13].Visible = false;
            }

        }

        //protected void Complete_Click(object sender, EventArgs e)
        //{
        //    char[] delimiterChars = { ',' };
        //    string temp = ((Button)sender).CommandArgument.ToString();
        //    string[] searchKey = temp.Split(delimiterChars);
        //    string intCusID = searchKey[0].ToString();
        //    string intid = searchKey[1].ToString();
        //    string PopupType = "Picking";
        //    string strReportType = "DO_Base";
        //    string ShipPointID = ddlShip.SelectedValue;

        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Picking('" + intid + "', '" + intCusID + "', '" + strReportType + "', '" + ShipPointID + "', '" + PopupType + "');", true);
        //}

        //protected void Picking_Click(object sender, EventArgs e)
        //{
        //    char[] delimiterChars = { ',' };
        //    string temp = ((Button)sender).CommandArgument.ToString();
        //    string[] searchKey = temp.Split(delimiterChars);
        //    string intCusID = searchKey[0].ToString();
        //    string intid = searchKey[1].ToString();
        //    string PopupType = "Picking";
        //    string strReportType = "Customer_Base";
        //    string ShipPointID = ddlShip.SelectedValue;

        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PickingCustBase('" + intid + "', '" + intCusID + "', '" + strReportType + "', '" + ShipPointID + "', '" + PopupType + "');", true);
        //}

        protected void btnCompleted_Click(object sender, EventArgs e)
        {
      
            try
            {

                char[] ch = { '#' };
                string[] str = ((Button)sender).CommandArgument.Split(ch);
                string id = str[0];
                DateTime dt = DateTime.Parse(str[1]);

                SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
                sv.CompleteDO(id, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue);

                dgvDelvOrderStatus.DataBind();
            }
            catch (Exception ex)
            {
              

            }

         
        }

        protected void dgvDelvOrderStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    totPieces += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
            //    aprPieces += decimal.Parse(((Label)e.Row.Cells[8].Controls[1]).Text);
            //    totAmount += decimal.Parse(((Label)e.Row.Cells[9].Controls[1]).Text);
            //}
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";
            //string intid = voucherID;
            string PopupType = "DO_EDIT";
            string strReportType = "DO_Base";
            string ShipPointID = ddlShip.SelectedValue;
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PickingCustBase('" + intid + "', '" + intCusID + "', '" + strReportType + "', '" + ShipPointID + "', '" + PopupType + "');", true);

            switch (completed.ToString().ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('DeliveryEntry.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "&reporttype="+ strReportType + "&shippointid="+ ShipPointID + "&popuptype="+ PopupType + "')\"class=\"link\">Edit</a>";
                   



                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }
        protected void dgvDelvOrderStatus_DataBound(object sender, EventArgs e)
        {
            totAmount = 0;
            totPieces = 0;
            aprPieces = 0;
            EnableDisable();
        }

        protected void dgvDelvOrderStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
            sv.CancelDO(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            dgvDelvOrderStatus.DataBind();
        }


        
    }
}
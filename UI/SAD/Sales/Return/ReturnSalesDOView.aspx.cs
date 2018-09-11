using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Return
{
    public partial class ReturnSalesDOView : System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Return\\ReturnSalesDOView";
        string stop = "stopping SAD\\Sales\\Return\\ReturnSalesDOView";

        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "55";
                pnlMarque.DataBind();
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
            GridView1.DataBind();

            /*if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
            }
            else
            {
                rdoComplete.Enabled = true;
            }*/
        }

        protected void btnCompleted_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Return\\ReturnSalesDOView Do View", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                char[] ch = { '#' };
            string[] str = ((Button)sender).CommandArgument.Split(ch);
            string id = str[0];
            DateTime dt = DateTime.Parse(str[1]);

            SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
            sv.CompleteSalesReturnDO(id, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue);

            GridView1.DataBind();
            }
            catch (Exception ex)
            {

                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name or Product Name is not valid');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Return\\ReturnSalesDOView Do View", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                SAD_BLL.Sales.DelivaryView sv = new SAD_BLL.Sales.DelivaryView();
            sv.CancelSalesReturnDO(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
            }
            catch (Exception ex)
            {

                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name or Product Name is not valid');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";

            switch (completed.ToString().ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('Delivary.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totPieces += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
                aprPieces += decimal.Parse(((Label)e.Row.Cells[8].Controls[1]).Text);
                totAmount += decimal.Parse(((Label)e.Row.Cells[9].Controls[1]).Text);
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            totAmount = 0;
            totPieces = 0;
            aprPieces = 0;
            EnableDisable();
        }

        private void EnableDisable()
        {
            if (GridView1.Rows.Count > 0)
            {
                if (GridView1.Rows.Count == 1 && txtCode.Text.Length > 0)
                {
                    if (GridView1.Rows[0].RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            if (((CheckBox)GridView1.Rows[0].Cells[9].Controls[0]).Checked)
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
                GridView1.Columns[10].Visible = true;
                GridView1.Columns[11].Visible = true;
                GridView1.Columns[12].Visible = true;
            }
            else
            {
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
            }
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
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        /*private void GetCode()
        {
            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            ShipPoint sp = new ShipPoint();
            string str = sp.GetPrefix(ddlShip.SelectedValue);
            if (str == "")
            {
                txtCode.Text = "";
            }
            else
            {
                txtCode.Text = str + "-" + pre + "-";
            }
        }*/

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 1) hdnCustomer.Value = temp[temp.Length - 1];
            else hdnCustomer.Value = "";
        }
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            //GetCode();
        }
    }
}
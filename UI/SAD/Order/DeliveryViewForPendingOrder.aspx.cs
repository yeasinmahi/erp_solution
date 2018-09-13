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

namespace UI.SAD.Order
{
    public partial class DeliveryViewForPendingOrder : System.Web.UI.Page
    {

        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DeliveryViewForPendingOrder";
        string stop = "stopping SAD\\Order\\DeliveryViewForPendingOrder";
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
            loadgrid();
        }

        private void loadgrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\DeliveryViewForPendingOrder Challan Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SalesView bll = new SalesView();
            dt = bll.getUndelvqntTopsheetPartybase(9, unitid, fromDate, toDate, 0, 0, 0, 0, 0, 0);
            dgvCustomerVSPendingQnt.DataSource = dt;
            dgvCustomerVSPendingQnt.DataBind();
            decimal chq = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
            dgvCustomerVSPendingQnt.FooterRow.Cells[2].Text = "Total";
            dgvCustomerVSPendingQnt.FooterRow.Cells[3].Text = chq.ToString("N2");
            decimal doqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
            dgvCustomerVSPendingQnt.FooterRow.Cells[4].Text = doqnt.ToString("N2");
            decimal pednqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
            dgvCustomerVSPendingQnt.FooterRow.Cells[5].Text = pednqnt.ToString("N2");
            decimal pendvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
            dgvCustomerVSPendingQnt.FooterRow.Cells[6].Text = pendvalue.ToString("N2");
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
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

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    //if (e.Row.RowType == DataControlRowType.DataRow)
        //    //{
        //    //    totPieces += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
        //    //    aprPieces += decimal.Parse(((Label)e.Row.Cells[8].Controls[1]).Text);
        //    //    totAmount += decimal.Parse(((Label)e.Row.Cells[9].Controls[1]).Text);
        //    //}
        //}
        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
            
        //    EnableDisable();
        //}

      
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

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{

        //}
        protected string GetPrintLink(object voucherID, object completed)
        {
            string str = "";

            switch (("" + completed).ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('DeliveryOrderPendingAmountPrint.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Details</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void Complete_Click(object sender, EventArgs e)
        {

            //char[] delimiterChars = { ',' };
            //string temp1 = ((Button)sender).CommandArgument.ToString();
            //string temp = temp1.Replace("'", " ");
            //string[] searchKey = temp.Split(delimiterChars);
            //string customerid = searchKey[0].ToString();

            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string customerid = searchKey[0].ToString();
            int custmid = int.Parse(customerid);
            Session["intcustmid"] = custmid;
            string unit= searchKey[1].ToString();
            int unitid = int.Parse(unit);
            Session["unitid"] = unitid;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('DeliveryOrderPendingAmountPrint.aspx');", true);

        }

        protected void dgvCustomerVSPendingQnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCustomerVSPendingQnt.PageIndex = e.NewPageIndex;
            loadgrid();
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
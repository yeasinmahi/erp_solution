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
    public partial class QuationView : System.Web.UI.Page
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
            DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            dgvCustomerVSPendingQnt.DataBind();
        }

        //private void loadgrid()
        //{
        //    var fd = log.GetFlogDetail(start, location, "Show", null);
        //    Flogger.WriteDiagnostic(fd);

        //    // starting performance tracker
        //    var tracker = new PerfTracker("Performance on  SAD\\Order\\DeliveryViewForPendingOrder Challan Show", "", fd.UserName, fd.Location,
        //        fd.Product, fd.Layer);
        //    try
        //    {
        //        DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
        //        DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
        //        hdnFrom.Value = fromDate.ToString();
        //        hdnTo.Value = toDate.ToString();
        //        int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
        //        DataTable dt = new DataTable();
        //        SalesOrderView bll = new SalesOrderView();
        //        dt = bll.GetSalesQuation(9, unitid, fromDate, toDate, 0, 0, 0, 0, 0, 0);
        //        dgvCustomerVSPendingQnt.DataSource = dt;
        //        dgvCustomerVSPendingQnt.DataBind();
        //        decimal chq = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
        //        dgvCustomerVSPendingQnt.FooterRow.Cells[2].Text = "Total";
        //        dgvCustomerVSPendingQnt.FooterRow.Cells[3].Text = chq.ToString("N2");
        //        decimal doqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
        //        dgvCustomerVSPendingQnt.FooterRow.Cells[4].Text = doqnt.ToString("N2");
        //        decimal pednqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
        //        dgvCustomerVSPendingQnt.FooterRow.Cells[5].Text = pednqnt.ToString("N2");
        //        decimal pendvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
        //        dgvCustomerVSPendingQnt.FooterRow.Cells[6].Text = pendvalue.ToString("N2");
        //    }
        //    catch (Exception ex)
        //    {
        //        var efd = log.GetFlogDetail(stop, location, "Show", ex);
        //        Flogger.WriteError(efd);

        //    }

        //    fd = log.GetFlogDetail(stop, location, "Show", null);
        //    Flogger.WriteDiagnostic(fd);
        //    // ends
        //    tracker.Stop();
        //}


        protected void btnCancel_Click(object sender, EventArgs e)
        {

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

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{

        //}
      

       
        protected void Complete_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intCustomerId = searchKey[0].ToString();
        
            Session["intCustomerId"] = intCustomerId;
            string intid = searchKey[1].ToString();
         
            Session["intid"] = intid;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('QuatationToDOCreate.aspx');", true);

        }

        protected void dgvCustomerVSPendingQnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCustomerVSPendingQnt.PageIndex = e.NewPageIndex;
            //loadgrid();
        }

        protected void btneditqotn_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intCustomerId = searchKey[0].ToString();

            Session["intCustomerId"] = intCustomerId;
            string intid = searchKey[1].ToString();

            Session["intid"] = intid;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "EditPageQuotation('../Delivery/QuotationEdit.aspx');", true);

        }

        protected void dgvCustomerVSPendingQnt_DataBound(object sender, EventArgs e)
        {
            //totAmount = 0;
            //totPieces = 0;
            //aprPieces = 0;
            //EnableDisable();
        }
        //private void EnableDisable()
        //{
        //    if (dgvCustomerVSPendingQnt.Rows.Count > 0)
        //    {
        //        if (dgvCustomerVSPendingQnt.Rows.Count == 1 && txtCode.Text.Length > 0)
        //        {
        //            if (dgvCustomerVSPendingQnt.Rows[0].RowType == DataControlRowType.DataRow)
        //            {
        //                try
        //                {
        //                    if (((CheckBox)dgvCustomerVSPendingQnt.Rows[0].Cells[8].Controls[0]).Checked)
        //                    {
        //                        rdoComplete.SelectedIndex = 1;
        //                    }
        //                    else
        //                    {
        //                        rdoComplete.SelectedIndex = 0;
        //                    }
        //                }
        //                catch { }
        //            }
        //        }
        //    }

        //    //if (rdoComplete.SelectedIndex == 0)
        //    //{
        //    //    //dgvCustomerVSPendingQnt.Columns[9].Visible = true;
        //    //    //dgvCustomerVSPendingQnt.Columns[10].Visible = true;
        //    //    //dgvCustomerVSPendingQnt.Columns[12].Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    //dgvCustomerVSPendingQnt.Columns[9].Visible = false;
        //    //    //dgvCustomerVSPendingQnt.Columns[10].Visible = false;
        //    //    //dgvCustomerVSPendingQnt.Columns[12].Visible = false;
        //    //}
        //}

        protected void dgvCustomerVSPendingQnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    totPieces += decimal.Parse(((Label)e.Row.Cells[6].Controls[1]).Text);
            //    //aprPieces += decimal.Parse(((Label)e.Row.Cells[8].Controls[1]).Text);
            //    totAmount += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
            //}
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
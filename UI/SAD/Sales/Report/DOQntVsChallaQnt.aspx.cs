 using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
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

namespace UI.SAD.Sales.Report
{
    public partial class DOQntVsChallaQnt : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int prouductid, unitid, intmainheadcoaid, enrol; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll = new StatementC();
        SalesView bllsalesv = new SalesView();
        string path = "", unitName = "", unitAddress = "", cus = "", pro = "", frm = "", to = "", dateVal = "", dataSource = "";
        char[] ch = { '[', ']' };
        int rpttype; int custid;
        DateTime dtFromDate, dtToDate;


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));

            }
            else
            {
                //SetReport();
            }
        }

        protected void grdvDelvVSPendingTopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdUndelvQntwithDONumber_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValue = Convert.ToDecimal(e.Row.Cells[12].Text);




                if (CellValue > 0)
                {

                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                }


                else { e.Row.BackColor = System.Drawing.Color.SeaGreen; }
                   

            }
        }

        protected void grdvDelvVSPendingTopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }
        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {

             rpttype = int.Parse(drdlreporttype.SelectedValue.ToString());
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                cus = temp[temp.Length - 1];
            }
            catch { }
            frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
            to = txtTo.Text + " " + ddlTHour.SelectedValue;
             dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(frm).Value;
             dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(to).Value;
            unitid = int.Parse(ddlUnit.SelectedValue);
            int salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
          
           
            if (rpttype == 1) {
                custid = int.Parse(cus);
                dt = bll.GetDelvQntVsChallanQnt(dtFromDate, dtToDate, custid, unitid);
                if (dt.Rows.Count > 0)
                {
                    grdvundelvqnwithsalesamount.DataSource = null;
                    grdvundelvqnwithsalesamount.DataBind();
                    grdvDelvVSPendingTopsheet.DataSource = null;
                    grdvDelvVSPendingTopsheet.DataBind();
                    grdUndelvQntwithDONumber.DataSource = null;
                    grdUndelvQntwithDONumber.DataBind();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
            else if(rpttype == 2)
            {
                dt = bll.GetDelvQntVsChallanQntTopSheet(dtFromDate, dtToDate, unitid);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    grdvDelvVSPendingTopsheet.DataSource = dt;
                    grdvDelvVSPendingTopsheet.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
          
            else if (rpttype == 3 )
            {
               
                
                //dt = bll.GetUndelvQntWithDONumber(rpttype, salesoffice, customerid, unitid);
                dt = bllsalesv.getDOQntvsChallanqntwithpendingqnt(dtFromDate, dtToDate, salesoffice, 0, unitid,rpttype);
                if (dt.Rows.Count > 0)
                {
                    grdvundelvqnwithsalesamount.DataSource = null;
                    grdvundelvqnwithsalesamount.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    grdvDelvVSPendingTopsheet.DataSource = null;
                    grdvDelvVSPendingTopsheet.DataBind();
                    grdUndelvQntwithDONumber.DataSource = dt;
                    grdUndelvQntwithDONumber.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }

            else if ( rpttype == 5)
            {


                DataTable dt = new DataTable();
                dt = bllsalesv.getDOQntvsChallanqntwithpendingqnt(dtFromDate, dtToDate, salesoffice, 0, unitid, rpttype);
                if (dt.Rows.Count > 0)
                {
                    grdvundelvqnwithsalesamount.DataSource = null;
                    grdvundelvqnwithsalesamount.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    grdvDelvVSPendingTopsheet.DataSource = null;
                    grdvDelvVSPendingTopsheet.DataBind();
                    grdUndelvQntwithDONumber.DataSource = dt;
                    grdUndelvQntwithDONumber.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }


            else if (rpttype == 4)
            {

                dt = bll.GetUndelvQntWithSalesAmount(dtFromDate, dtToDate,  0, unitid,rpttype);
                if (dt.Rows.Count > 0)
                {
                    grdvDelvVSPendingTopsheet.DataSource = null;
                    grdvDelvVSPendingTopsheet.DataBind();
                    grdUndelvQntwithDONumber.DataSource = null;
                    grdUndelvQntwithDONumber.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    grdvundelvqnwithsalesamount.DataSource = dt;
                    grdvundelvqnwithsalesamount.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rpttype == 1) {
                try
                {
                    GridView1.AllowPaging = false;
                    ExportClass.Export("DOQNTVSchallan.xls", GridView1);
                }
                catch { }
            }
            else if (rpttype == 3)
            {
                try
                {
                    grdUndelvQntwithDONumber.AllowPaging = false;
                    ExportClass.Export("grdUndelvQntwithDONumber.xls", grdUndelvQntwithDONumber);
                }
                catch { }
            }


            else if (rpttype == 5)
            {
                try
                {
                    grdUndelvQntwithDONumber.AllowPaging = false;
                    ExportClass.Export("grdUndelvQntwithDONumber.xls", grdUndelvQntwithDONumber);
                }
                catch { }
            }
        }
    }
}
using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
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

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class VehicleLogisticCharge : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int prouductid, unitid, intmainheadcoaid, enrol; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll = new StatementC();
        string path = "", unitName = "", unitAddress = "", cus = "", pro = "", frm = "", to = "", dateVal = "", dataSource = "";
        string donmuber, challanmuber;
        int rpttype;

        char[] ch = { '[', ']' };




        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                //pnlMarque.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));

            }
            else
            {
                //SetReport();
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }
        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {


            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                cus = temp[temp.Length - 1];
            }
            catch { }
            frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
            to = txtTo.Text + " " + ddlTHour.SelectedValue;
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(frm).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(to).Value;
            unitid = int.Parse(ddlUnit.SelectedValue);
            int custid = int.Parse(cus);
            donmuber = txtchallanordo.Text;
            challanmuber= txtchallanordo.Text;
            donmuber = txtchallanordo.Text;
            rpttype = int.Parse(ddlreporttype.SelectedValue.ToString());
            if (donmuber.Length<=0 || donmuber == "")
            {
                donmuber = "0";
            }
            else
            {
                donmuber = txtchallanordo.Text;
            }
            if (challanmuber.Length <= 0 || challanmuber == "")
            {
                challanmuber = "0";
            }
            else
            {
                challanmuber = txtchallanordo.Text;
            }
            //customerid, int rpttype, string donumber, string challannumber, int unitid

            dt = bll.GetVehicleTransportmodeinchallan(dtFromDate, dtToDate, custid, rpttype,donmuber,challanmuber,unitid);
            if (dt.Rows.Count > 0)
            {
                grdvVheicleLogisticchargedetaills.DataSource = dt;
                grdvVheicleLogisticchargedetaills.DataBind();



            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


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
        protected void grdvVheicleLogisticchargedetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvVheicleLogisticchargedetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
using Purchase_BLL.VehicleRegRenewal_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class TransportMntCostReport : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
        int unitid; int inactiveby, vhclid;
        
        string path = "", unitName = "", unitAddress = "", vhclname = "", pro = "", frm = "", to = "", dateVal = "", dataSource = "";
        protected decimal grandtotalMnt = 0; protected decimal drvallow = 0; protected decimal homnts = 0; protected decimal workshpmnt = 0;
        protected decimal factmnt = 0; protected decimal grandtotal=0;

     

        protected decimal intTotalMillage1 = 0, interpcounttrip1 = 0, decerpcountdelv1 = 0, monerpcountlogisticcharge1 = 0, monTripFare1 = 0, monTotalTripFare1 = 0, monDieselTotalTk1 = 0, monCNGTotalTk1 = 0, totalfuelcost1 = 0, monTotalRouteEXP1 = 0, POL1 = 0;



        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtVheicleNumber.Attributes.Add("onkeyUp", "SearchText();");
                //try { File.Delete(filePathForXML); }
                //catch { }
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));
            }
        }

        [WebMethod]
        public static List<string> GetAutoserachingVheicleName(string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();

            List<string> result = new List<string>();
            result = bll.AutoSearchVheicleName(strSearchKey);
            return result;
        }

        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {
            int rpttype = int.Parse(drdlreporttype.SelectedValue.ToString());
            string[] temp = txtVheicleNumber.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                vhclname = temp[temp.Length - 1];
            }
            catch { }
            frm = txtFrom.Text + " " ;
            to = txtTo.Text + " " ;
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(frm).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(to).Value;
            unitid = int.Parse(ddlUnit.SelectedValue);

            if (rpttype == 2)
            {
                //vhclid = int.Parse(vhclname);
                dt = bll.GetOwnvhclMntCost(dtFromDate, dtToDate,  unitid, rpttype);
                if (dt.Rows.Count > 0)
                {
                    grdvOwnVhclIncomeExpense.DataSource = "";
                    grdvOwnVhclIncomeExpense.DataBind();
                    grdvMntcostentryReport.DataSource = dt;
                    grdvMntcostentryReport.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
            else if (rpttype == 3)
            {
                dt = bll.Getownvheicleincomeandexpense(dtFromDate, dtToDate, unitid, rpttype);
                if (dt.Rows.Count > 0)
                {
                    
                    grdvMntcostentryReport.DataSource = "";
                    grdvMntcostentryReport.DataBind();
                    grdvOwnVhclIncomeExpense.DataSource =dt;
                    grdvOwnVhclIncomeExpense.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void grdvMntcostentryReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { grandtotal += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblGrandTotal")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { drvallow += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lbldrvallownce")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { factmnt += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblfactorymnt")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { homnts += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblhomnt")).Text); }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { workshpmnt += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblcworkshp")).Text); }
            }
            catch { }
            
        }

        protected void grdvMntcostentryReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdvOwnVhclIncomeExpense_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOwnVhclIncomeExpense_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }
}
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport.TripvsCost
{
    public partial class TripCost : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        LOGIS_BLL.Trip.Trip blltrip = new LOGIS_BLL.Trip.Trip();
        StatementC bll = new StatementC();
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;
        decimal totalcom;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteCommission.xml");
            if (!IsPostBack)
            {
                try
                {
                    //try { File.Delete(xmlpath); } catch { }
                    txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                    txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                    //hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                salesofficelike = drdlShippingpoint.SelectedItem.Text.ToString();
                reporttype = int.Parse(ddlReportType.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                if (reporttype == 1 || reporttype == 2)
                {
                    dt = blltrip.GetTripvsCost(dtFromDate, dtToDate, salesofficelike, reporttype);
                    if (dt.Rows.Count > 0)
                    {
                        grdvTripVsTADA.DataSource = dt;
                        grdvTripVsTADA.DataBind();
                        decimal totalda = dt.AsEnumerable().Sum(row => row.Field<decimal>("da"));
                        decimal totalta = dt.AsEnumerable().Sum(row => row.Field<decimal>("ta"));
                        decimal totaltada = dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));
                        int totaltripcount = dt.AsEnumerable().Sum(row => row.Field<int>("totaltrip"));
                        grdvTripVsTADA.FooterRow.Cells[1].Text = "total";
                        grdvTripVsTADA.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                        grdvTripVsTADA.FooterRow.Cells[3].Text = totalda.ToString("N2");
                        grdvTripVsTADA.FooterRow.Cells[4].Text = totalta.ToString("N2");
                        grdvTripVsTADA.FooterRow.Cells[5].Text = totaltada.ToString("N2");
                        grdvTripVsTADA.FooterRow.Cells[2].Text = totaltripcount.ToString("N2");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                else if (reporttype == 3)
                {
                    //fromdate,  todate,  shippingpoinname,  unitid,  rpttypeid,  drivername,  helpername
                    dt = blltrip.GetTripvsChallanDet(dtFromDate, dtToDate, salesofficelike, unitid, reporttype, "", "");
                    if (dt.Rows.Count > 0)
                    {
                        grdvTripVsTADA.DataSource = "";
                        grdvTripVsTADA.DataBind();
                        grdvTripvsChallanDet.DataSource = dt;
                        grdvTripvsChallanDet.DataBind();
                        decimal totaldelivery = dt.AsEnumerable().Sum(row => row.Field<decimal>("decqntcft"));
                        grdvTripvsChallanDet.FooterRow.Cells[1].Text = "total";
                        grdvTripvsChallanDet.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                        grdvTripvsChallanDet.FooterRow.Cells[5].Text = totaldelivery.ToString("N2");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

            }
            catch { }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

            try
            {
                grdvTripVsTADA.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("TripvsCost.xls", grdvTripVsTADA);
            }
            catch { }

        }
        protected void Complete_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string  name1 = (searchKey[0].ToString());
            Session["name1"] = name1;
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            string strDate = dteFromDate.ToString();
            Session["Date"] = strDate;
            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string strTodate = dteTodate.ToString();
            Session["DateTodate"] = strTodate;
            int ReportType = int.Parse(ddlReportType.SelectedValue.ToString());
            Session["REPORTTYPE"] = ReportType;
            string salesoffice = drdlShippingpoint.SelectedItem.Text.ToString();
            Session["salesoffice"] = salesoffice;
            int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            Session["unitid"] = unitid;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('TripCostDetaills.aspx');", true);
        }

        protected void grdvTripvsChallanDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       


       
       

        protected void grdvTripVsTADA_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void drdlUnitName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            dt = blltrip.GetShippingPointNamet(unitid);
            drdlShippingpoint.DataSource = dt;
            drdlShippingpoint.DataTextField = "strName";
            drdlShippingpoint.DataValueField = "intId";
            drdlShippingpoint.DataBind();
        }
    }
}
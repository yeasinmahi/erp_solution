using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport.TripvsCost
{
    public partial class VheicleMonitoring : System.Web.UI.Page
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

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    dt = blltrip.GetVheicleMonitoringinfo(dtFromDate, dtToDate, unitid, reporttype);
                    if (dt.Rows.Count > 0)
                    {
                        grdvVhclMonitoring.DataSource = dt;
                        grdvVhclMonitoring.DataBind();
                        //decimal totalda = dt.AsEnumerable().Sum(row => row.Field<decimal>("da"));
                        //decimal totalta = dt.AsEnumerable().Sum(row => row.Field<decimal>("ta"));
                        //decimal totaltada = dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));
                        //int totaltripcount = dt.AsEnumerable().Sum(row => row.Field<int>("totaltrip"));
                        //grdvTripVsTADA.FooterRow.Cells[1].Text = "total";
                        //grdvTripVsTADA.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                        //grdvTripVsTADA.FooterRow.Cells[3].Text = totalda.ToString("N2");
                        //grdvTripVsTADA.FooterRow.Cells[4].Text = totalta.ToString("N2");
                        //grdvTripVsTADA.FooterRow.Cells[5].Text = totaltada.ToString("N2");
                        //grdvTripVsTADA.FooterRow.Cells[2].Text = totaltripcount.ToString("N2");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

          

            }
            catch { }
        }

        protected void grdvVhclMonitoring_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            reporttype = int.Parse(ddlReportType.SelectedValue.ToString());
            if (reporttype == 1)
            {
                grdvVhclMonitoring.Columns[0].Visible = true;
                grdvVhclMonitoring.Columns[1].Visible = true;
                grdvVhclMonitoring.Columns[2].Visible = true;
                grdvVhclMonitoring.Columns[3].Visible = true;
                grdvVhclMonitoring.Columns[4].Visible = true;
                grdvVhclMonitoring.Columns[5].Visible = true;
                grdvVhclMonitoring.Columns[6].Visible = true;
                grdvVhclMonitoring.Columns[7].Visible = true;
                grdvVhclMonitoring.Columns[8].Visible = true;
                grdvVhclMonitoring.Columns[9].Visible = true;
                grdvVhclMonitoring.Columns[10].Visible = true;
                grdvVhclMonitoring.Columns[11].Visible = true;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Decimal CellValueHour = Convert.ToDecimal(e.Row.Cells[10].Text);

                    e.Row.Attributes.Add("onmouseover",
                    "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                    if (CellValueHour == 0)
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
                    }


                }

            }
            else  if (reporttype == 2)
            {
                grdvVhclMonitoring.Columns[0].Visible = true;
                grdvVhclMonitoring.Columns[1].Visible = true;
                grdvVhclMonitoring.Columns[2].Visible = true;
                grdvVhclMonitoring.Columns[3].Visible = true;
                grdvVhclMonitoring.Columns[4].Visible = false;
                grdvVhclMonitoring.Columns[5].Visible = true;
                grdvVhclMonitoring.Columns[6].Visible = true;
                grdvVhclMonitoring.Columns[7].Visible = true;
                grdvVhclMonitoring.Columns[8].Visible = true;
                grdvVhclMonitoring.Columns[9].Visible = true;
                grdvVhclMonitoring.Columns[10].Visible = true;
                grdvVhclMonitoring.Columns[11].Visible = true;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Decimal CellValueHour = Convert.ToDecimal(e.Row.Cells[10].Text);

                    e.Row.Attributes.Add("onmouseover",
                    "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                    if (CellValueHour == 0)
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
                    }


                }
            }


         

        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                grdvVhclMonitoring.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("vheicle.xls", grdvVhclMonitoring);
            }
            catch { }
        }
    }
}
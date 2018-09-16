using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteCrBalance : BasePage
    {

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteCrBalance";
        string stop = "stopping SAD\\Order\\RemoteCrBalance";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                //pnlUpperControl.DataBind();
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);

            }
            else
            {
                //SetReport();
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
           // txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }
        private void ShowReportDetails()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteCrBalance Cr balance Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DataTable oDTReportData = new DataTable();
            StatementC st = new StatementC(); 
            oDTReportData = st.GetStatementByCustomerCreditBalanceRemote(txtTo.Text + " " + ddlTHour.SelectedValue,
            Session[SessionParams.EMAIL].ToString(), ddlUnit.SelectedValue, "", ddlSo.SelectedValue, ddlCusType.SelectedValue);



            if (oDTReportData.Rows.Count>0)
            {
                GridView1.DataSource=oDTReportData;
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValueOutstanding = Convert.ToDecimal(e.Row.Cells[5].Text);
              
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueOutstanding > 0)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                }

                else
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;

            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("Statement.xls", GridView1);
            }
            catch { }
        }
    }
}
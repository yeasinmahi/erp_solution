using Flogging.Core;
using GLOBAL_BLL;
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
    public partial class RemoteTADAApproveBySupervisorV2 :BasePage
    {

        decimal petrolcostBikeCar = 0; decimal octencostBikeCar = 0; decimal cngcostBikeCar = 0; decimal lubriantcostBikeCar = 0; decimal busfareBikeCar = 0; decimal RickfareBikeCar = 0; decimal cngfareBikeCar = 0; decimal trainfareBikeCar = 0; decimal airplanceBikeCar = 0; decimal othervhfareBikeCar = 0;
        decimal mntcostBikeCar = 0; decimal ferrytolBikeCar = 0; decimal owndaBikeCar = 0; decimal driverdaBikeCar = 0; decimal ownhotelBikeCar = 0; decimal driverhotelBikeCar = 0; decimal photocopyBikeCar = 0; decimal courierBikeCar = 0; decimal othercostBikeCar = 0;
        decimal totalcostBikeCar = 0;
        string filePathForXMLHRBIKECAR;
        string xmlStringHRBIKECAR = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADAApproveBySupervisorV2";
        string stop = "stopping SAD\\Order\\RemoteTADAApproveBySupervisorV2";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                ////---------xml----------
                //try { File.Delete(filePathForXMLHRBIKECAR); }
                //catch { }
                ////-----**----------//


            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        { var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAApproveBySupervisorV2 Show TADA Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int rptType = int.Parse(drdlReportType.SelectedValue.ToString());
            
            if (rptType == 1)
            {
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    dt = bll.getTADAApplicantInfoForApproveBySuperVisorV2(dteFromDate, dteToDate, enr);


                }

                catch
                {
                    //
                }

                if (dt.Rows.Count > 0)
                {
                    grdvForTADAApproveBYimmediateSupervisorV2.DataSource = dt;
                    grdvForTADAApproveBYimmediateSupervisorV2.DataBind();
                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
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

        protected void Complete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAApproveBySupervisorV2 Complete TADA ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            Int32 enrol1 = int.Parse(searchKey[0].ToString());
            Session["enrol1"] = enrol1;
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
           
            string strDate = dteFromDate.ToString();
            Session["Date"] = strDate;
            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string strTodate = dteTodate.ToString();
            Session["DateTodate"] = strTodate;
           
            int ReportType = int.Parse(drdlReportType.SelectedValue.ToString());
            Session["REPORTTYPE"] = ReportType;



            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('TADAAprvSingleEmployeeByImsSuperv.aspx');", true);
                //Response.Redirect("TADAAprvSingleEmployeeByImsSuperv.aspx");
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void grdvForAuditBillChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvForAuditBillChecking_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvForTADAApproveBYimmediateSupervisorV2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvForTADAApproveBYimmediateSupervisorV2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValueapplicant = Convert.ToDecimal(e.Row.Cells[4].Text);
                Decimal CellValueSupervisor = Convert.ToDecimal(e.Row.Cells[5].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueapplicant > CellValueSupervisor)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                }
               
                else
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;

            }
        }
    }
}
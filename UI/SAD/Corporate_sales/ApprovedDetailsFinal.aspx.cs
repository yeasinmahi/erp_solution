using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Corporate_sales
{
    public partial class ApprovedDetailsFinal : System.Web.UI.Page
    {
        DataTable dtReportdetails = new DataTable();
        OrderInput_BLL ReportOrder = new OrderInput_BLL();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Corporate_sales\\ApprovedDetailsFinal";
        string stop = "stopping SAD\\Corporate_sales\\ApprovedDetailsFinal";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on SAD\\Corporate_sales\\ApprovedDetailsFinal approve Final", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    int ordernumber = int.Parse(Session["order"].ToString());
                dtReportdetails = ReportOrder.getDetailsReport(ordernumber);

                dgvOrder.DataSource = dtReportdetails;
                dgvOrder.DataBind();

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
           
        }

        protected void dgvtrgt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected double TotalAmount = 0; protected double totalfreetotal = 0; protected double totalqtytotal = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Mlqctotal += int.Parse(((Label)e.Row.Cells[1].FindControl("lblMlqc")).Text);

                if (((TextBox)e.Row.Cells[1].FindControl("lblTotalAmount")).Text == "")
                {
                    TotalAmount += 0;
                }
                else
                {
                    TotalAmount += double.Parse(((TextBox)e.Row.Cells[1].FindControl("lblTotalAmount")).Text);
                }
               
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Corporate_sales\\ApprovedDetailsFinal Submit Approve", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DateTime dtedate = DateTime.Now;
            int unitid = int.Parse("2");
            int enroll = int.Parse("13");


            if (dgvOrder.Rows.Count > 0)
            {

                for (int index = 0; index < dgvOrder.Rows.Count; index++)
                {
                


                    Int32 totalcount = dgvOrder.Rows.Count;

                    string IntOrderNumber = "0";
                    Session["IntOrderNumber"] = IntOrderNumber;
                    string intproductid = ((Label)dgvOrder.Rows[index].FindControl("lblProductid")).Text.ToString();
                    string qty = ((TextBox)dgvOrder.Rows[index].FindControl("Quantity1")).Text.ToString();
                    string OrderNo = ((Label)dgvOrder.Rows[index].FindControl("lblintOrderNo")).Text.ToString();
                    string intShipPointId = ((Label)dgvOrder.Rows[index].FindControl("lblintShipPointId")).Text.ToString();
                    string intCusID = ((Label)dgvOrder.Rows[index].FindControl("lblintCusID")).Text.ToString();
                    string rate = ((HiddenField)dgvOrder.Rows[index].FindControl("rate")).Value.ToString();
                    
                    string pid = ((Label)dgvOrder.Rows[index].FindControl("lblProductid")).Text.ToString();
                    string paname = ((Label)dgvOrder.Rows[index].FindControl("lblstrProductName")).Text.ToString();
                    
                     string promUomtext = ((HiddenField)dgvOrder.Rows[index].FindControl("FreeUomTxt")).Value.ToString();
                    string promitemCOA = ((HiddenField)dgvOrder.Rows[index].FindControl("freeintCOAID")).Value.ToString();
                    string prompr = ((HiddenField)dgvOrder.Rows[index].FindControl("rate")).Value.ToString();
               

                    string intCustid = Session["Custid"].ToString();
                   
                    string pr = ((HiddenField)dgvOrder.Rows[index].FindControl("rate")).Value.ToString();
                    Decimal totalAmount = (((Convert.ToDecimal(qty.ToString()) * decimal.Parse(rate.ToString())) * decimal.Parse(qty.ToString()))) ;
                    // Freeqty = Math.Round(Freeqty);

                    ReportOrder.getinsertorderApp(unitid,intShipPointId,IntOrderNumber,intCustid,intproductid,qty,rate,totalAmount,dtedate,enroll);

                    ReportOrder.getorderupadate(IntOrderNumber);
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('sucessfully Approved.');", true);
        

                }
            }

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
    }
}
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
    public partial class GhatTransferChallanReceive : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\GhatTransferChallanReceive";
        string stop = "stopping SAD\\Order\\GhatTransferChallanReceive";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
              
            }
            else
            {

            }
        }

        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\GhatTransferChallanReceive Challan Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DataTable oDTReportData = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
          try
            {

                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                hdnunitid.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                int unit = int.Parse(drdlUnit.SelectedValue.ToString());
                int productid = int.Parse(drdlProductName.SelectedValue.ToString());
                int Shipingpointid = int.Parse(drdlGhat.SelectedValue.ToString());
                oDTReportData = bll.getGhatDeportDeliveryReceiveStatus(dtFromDate, dtToDate, Shipingpointid, unit, productid);


            }
            catch
            {

            }

            if (oDTReportData.Rows.Count > 0)
            {
                grdvTransferChallanReceive.DataSource = oDTReportData;
                grdvTransferChallanReceive.DataBind();
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

      

        protected void grdvTransferChallanReceive_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        public void btnRecieve_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\GhatTransferChallanReceive Challan Receive", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                hdnunitid.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
            int unit = Convert.ToInt32(hdnunitid.Value);
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intID = searchKey[0].ToString();
                int id = int.Parse(intID);
                //string accountid = searchKey[0].ToString();
                bool val = false;

                //string dtDate = searchKey[1].ToString();
                //DateTime dt = DateTime.Parse(dtDate.ToString());
                //string Challan = searchKey[2].ToString();
                //Int32 ch = Int32.Parse(Challan);

                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

              bll.TransferChallReceivestatusUpdate(unit, id, val);

              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully receive');", true);


            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fail to...');", true);
            tracker.Stop();
          

        }

        

       
    }
}
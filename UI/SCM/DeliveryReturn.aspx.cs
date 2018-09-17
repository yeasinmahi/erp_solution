using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class DeliveryReturn : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\DeliveryReturn";
        string stop = "stopping SCM\\DeliveryReturn";
        string perform = "Performance on SCM\\DeliveryReturn";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()); 
                
                dt = objPo.GetPoData(36, "", intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id"; 
                ddlWH.DataBind();
            }
            else
            { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " "+ "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                getDataBind();
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

        private void getDataBind()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int poId = int.Parse(txtPoNo.Text.ToString());
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objPo.GetPoData(31, "", intWh, poId, DateTime.Now, enroll);
                dgvDelivery.DataSource = dt;
                dgvDelivery.DataBind();
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

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform, "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnConfirm.Value == "1")
                {

                    int poid =int.Parse(txtPoNo.Text.ToString());
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                    TextBox txtReson = row.FindControl("txtReson") as TextBox;
                    Label lblitemId = row.FindControl("lblitemId") as Label;
                    Label lblPoQty = row.FindControl("lblPoQty") as Label;
                     
                   
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    double returnQty = double.Parse(txtReturnQty.Text.ToString());
                    string remarks = txtReson.Text.ToString();
                    string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty.ToString() + '"' + " remarks=" + '"' + remarks + '"' + " itemId=" + '"' + lblitemId.Text.ToString() + '"' + " poQty=" + '"' + lblPoQty.Text.ToString() + '"' + "/></voucher>".ToString();
                    if (returnQty > 0)
                    {
                        string msg = objPo.PoApprove(32, xmlData, intWh, poid, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        getDataBind();
                    } 
                }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
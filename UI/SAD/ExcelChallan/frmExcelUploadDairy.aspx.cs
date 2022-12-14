using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.ExcelChallan
{
    public partial class frmExcelUploadDairy : BasePage
    {     
        DataTable dt; int Custid;
        ExcelDataBLL objExcel = new ExcelDataBLL();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\ExcelChallan\\frmExcelUploadDairy";
        string stop = "stopping SAD\\ExcelChallan\\frmExcelUploadDairy";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = objExcel.getShippoint(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(Session[SessionParams.UNIT_ID].ToString()), true);
                ddlshippoint.DataTextField = "strName";
                ddlshippoint.DataValueField = "intShipPointId";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                dt = objExcel.getOfficebyShippoint(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(ddlshippoint.SelectedValue.ToString()), true);
                ddlOfficeName.DataTextField = "strName";
                ddlOfficeName.DataValueField = "intId";
                ddlOfficeName.DataSource = dt;
                ddlOfficeName.DataBind();
                dt.Clear();
            }
        }
        protected void btnDataView_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\ExcelChallan\\frmExcelUploadDairy Report for Delivery Order", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (txtFrom.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Date Select ');", true);

            }
            else { 
                dt = objExcel.UploadDataOrderDairy(int.Parse(ddlshippoint.SelectedValue), DateTime.Parse(txtFrom.Text));
                dgvExcelOrder.DataSource = dt;
                dgvExcelOrder.DataBind();
                dgvExcelOrder.Visible = true;
                dgvSlip.Visible = false;
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
        protected double Pendingtotal = 0; protected double TotalQtytotal = 0;
        protected void btnLoadingSlip_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\ExcelChallan\\frmExcelUploadDairy Loading Slip", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                dt = objExcel.getLoadingSlipView(int.Parse(ddlshippoint.SelectedValue));
            dgvSlip.DataSource = dt;
            dgvSlip.DataBind();
            dgvSlip.Visible = true;
            dgvExcelOrder.Visible = false;
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
        protected void dgvExcelOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[7].FindControl("lblqty")).Text == "")
                {
                    Pendingtotal += 0;
                }
                else
                {
                    Pendingtotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblqty")).Text);
                }
            }

        }
        protected void btnExcelProductView(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                hdnCustid.Value = searchKey[0].ToString();
                hdnCustname.Value = searchKey[1].ToString();
                Session["dtedate"] = txtFrom.Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowPopUpCust('frmLoadingSlipChallanDairy.aspx?');", true);
            }
            catch { }
        }
        protected void ViewSlipAll(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                hdnCustid.Value = searchKey[0].ToString();
                hdnSlipno.Value= searchKey[1].ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowPopUpCust('frmLoadingSlipChallan.aspx?');", true);
            }
            catch { }
        }
        protected void btnDelete(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\ExcelChallan\\frmExcelUploadDairy Order Delete", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Custid = int.Parse(searchKey[0].ToString());
                objExcel.getOrderdelete(Custid,int.Parse(ddlshippoint.SelectedValue));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);

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
        protected void btnOrderDelete(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Custid = int.Parse(searchKey[0].ToString());
                objExcel.getOrderSlipdelete(Custid, int.Parse(ddlshippoint.SelectedValue));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);

            }
            catch { }
        }

        protected void ddlshippoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
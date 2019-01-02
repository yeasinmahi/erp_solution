using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IssueItemByRequesition : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intwh;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IssueItemByRequesition";
        private string stop = "stopping SCM\\IssueItemByRequesition";
        private string perform = "Performance on SCM\\IssueItemByRequesition";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);

                var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            else
            { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(2, xmlData, intwh, 0, DateTime.Now, enroll);
                dgvReq.DataSource = dt;
                dgvReq.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // your code to get data
                // I assumed you are getting data in dataset using some query

                Label lblItem = (Label)e.Row.FindControl("lblItemIds");
                int Item = int.Parse(lblItem.Text);

                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(8, "", intwh, Item, 1);
                DropDownList ddlLocation = (e.Row.FindControl("ddlStoreLocation") as DropDownList);
                ddlLocation.DataSource = dt;
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataBind();
            }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblReqId = row.FindControl("lblReqId") as Label;
                int ReqId = int.Parse(lblReqId.Text);
                intwh = int.Parse(ddlWH.SelectedValue);

                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string Reqid = datas[0].ToString();
                string ReqCode = datas[1].ToString();
                string dteReqDate = datas[2].ToString();
                string strDepartmentName = datas[3].ToString();
                string strReqBy = datas[4].ToString();
                string strApproveBy = datas[5].ToString();

                string DeptID = datas[6].ToString();
                string SectionID = datas[7].ToString();
                string SectionName = datas[8].ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + Reqid + "','" + ReqCode.ToString() + "','" + dteReqDate + "','" + strDepartmentName + "','" + strReqBy + "','" + strApproveBy + "','" + intwh.ToString() + "','" + DeptID + "','" + SectionID + "','" + SectionName + "');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDetalis_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public string GetJSFunctionString(object ReqId, object ReqCode, object dteReqDate, object strDepartmentName, object strReqBy, object strApproveBy, object intDeptID, object intSectionID, object SectionName)
        {
            //  Eval("Id"),Eval("ReqCode"),Eval("dteReqDate"),Eval("strDepartmentName"),Eval("strReqBy"),Eval("strApproveBy"))
            string str = "";
            str = ReqId.ToString() + ',' + ReqCode.ToString() + "," + dteReqDate.ToString() + ',' + strDepartmentName.ToString() + ',' + strReqBy.ToString() + ',' + strApproveBy.ToString() + "," + intDeptID.ToString() + "," + intSectionID.ToString() + "," + SectionName.ToString();
            return str;
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvReq.DataSource = "";
                dgvReq.DataBind();
            }
            catch { }
        }
    }
}
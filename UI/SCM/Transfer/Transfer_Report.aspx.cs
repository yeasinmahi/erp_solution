using HR_DAL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.Transfer
{
    public partial class Transfer_Report : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitBll = new HR_BLL.Global.Unit();
        HR_BLL.Global.WareHouse wareHBLL = new HR_BLL.Global.WareHouse();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    LoadUnit();
                }
                catch { }
            }
            

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadToWH();
            LoadFromWH();
        }
        #region === DropDown Load===

        public void LoadUnit()
        {
            dt = unitBll.GetUnits(Enroll.ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        public void LoadFromWH()
        {
            dt = wareHBLL.GetWareHouseByUnit(Convert.ToInt32(ddlUnit.SelectedValue));
            ddlFWh.Loads(dt, "intWHID", "strWareHoseName");
        }
        public void LoadToWH()
        {
            dt = wareHBLL.GetWareHouseByUnit(Convert.ToInt32(ddlUnit.SelectedValue));
            ddlTWh.LoadWithAll(dt, "intWHID", "strWareHoseName");
        }

        #endregion = =========

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string fromTime = txtFormTime.Text;
            string toTime = txtToTime.Text;
            string url;
            if (string.IsNullOrWhiteSpace(fromTime) || string.IsNullOrWhiteSpace(toTime))
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/SCM/Transfer_Report" + "&unit=" + ddlUnit.SelectedItem.Value + "&toWH=" + ddlTWh.SelectedItem.Value + "&fromWH=" + ddlFWh.SelectedItem.Value + "&toDate=" + txtToDate.Text + "&fromDate=" + txtFromDate.Text +  "&rc:LinkTarget=_self";
            }
            else
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/SCM/Transfer_Report" + "&unit=" + ddlUnit.SelectedItem.Value + "&toWH=" + ddlTWh.SelectedItem.Value + "&fromWH=" + ddlFWh.SelectedItem.Value + "&fromDate=" + txtFromDate.Text + " " + fromTime + "&toDate=" + txtToDate.Text + " " + toTime + "&rc:LinkTarget=_self";
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }
    }
}
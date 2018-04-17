using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class ReportHallBooking : BasePage
    {
        string alertMessage = ""; int payStatus; string applicationStatus;
        TourPlanning bll = new TourPlanning();
        DataTable dt = new DataTable();
        int typeid, id, locationid, arprvby;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                loadgrid();
                hdnAction.Value = "0";
            }
            else
            {  }
        }

        private void loadgrid()
        {
            typeid = 3;
            locationid = 0;
            dt = bll.GetdataforConferenceRoom(typeid, locationid);
            if (dt.Rows.Count > 0) { dgvHallbookingUnapproveddata.DataSource = dt; dgvHallbookingUnapproveddata.DataBind(); }
            arprvby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if(arprvby==1050 || arprvby == 1052 || arprvby == 1054 || arprvby == 118506 || arprvby == 283833 || arprvby == 1272)
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = true;
                dgvHallbookingUnapproveddata.Columns[11].Visible = true;
            }
            else
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = false;
                dgvHallbookingUnapproveddata.Columns[11].Visible = false;
            }

        }

        #region eventhandler dropdown
        protected void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            try
            {
                int typeid = int.Parse(ddlist.SelectedValue);
                locationid = 0;
                dt = bll.GetdataforConferenceRoom(typeid, locationid);
                if (dt.Rows.Count > 0) { dgvHallbookingUnapproveddata.DataSource = dt; dgvHallbookingUnapproveddata.DataBind(); }

            }
            catch { }
            if (ddlist.SelectedValue == "3")
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = true;
                dgvHallbookingUnapproveddata.Columns[11].Visible = true;
            }
            else 
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = false;
                dgvHallbookingUnapproveddata.Columns[11].Visible = false;
            }
            if (arprvby == 1050 || arprvby == 1052 || arprvby == 1054 || arprvby == 118506)
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = true;
                dgvHallbookingUnapproveddata.Columns[11].Visible = true;
            }
            else
            {
                dgvHallbookingUnapproveddata.Columns[10].Visible = false;
                dgvHallbookingUnapproveddata.Columns[11].Visible = false;
            }
        }
        #endregion
        #region Button
        protected void btnApprove_Click(object sender, EventArgs e)
        {

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    for (int rowscount = 0; rowscount < dgvHallbookingUnapproveddata.Rows.Count; rowscount++)
                        {
                        char[] delimiterChars = { ',' };
                        string temp = ((Button)sender).CommandArgument.ToString();
                        string[] searchKey = temp.Split(delimiterChars);
                        string intIDtbl = searchKey[0].ToString();
                         id = int.Parse(intIDtbl);
                        arprvby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        break;
                        }
                    bool val = true;
                    bool cancel = false;
                    string message = bll.HallBookingApproveProcessed(id, val, cancel, arprvby);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    loadgrid();
                }
            }
            catch { }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {

                    for (int rowscount = 0; rowscount < dgvHallbookingUnapproveddata.Rows.Count; rowscount++)
                    {
                        char[] delimiterChars = { ',' };
                        string temp = ((Button)sender).CommandArgument.ToString();
                        string[] searchKey = temp.Split(delimiterChars);
                        string intIDtbl = searchKey[0].ToString();
                        id = int.Parse(intIDtbl);
                        arprvby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        break;
                    }
                    bool val = false;
                    bool cancel = true;
                    string message = bll.HallBookingApproveProcessed(id, val, cancel, arprvby);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    loadgrid();
                }
            }
            catch { }
        }
        #endregion

    }
}
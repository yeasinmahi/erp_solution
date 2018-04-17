using HR_BLL.Visitors;
using MKB.TimePicker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Visitors
{
    public partial class PublicBookingList : BasePage
    {
        VisitorsBLL vbll = new VisitorsBLL(); DataTable dt; string msg = "";
        int type = 0; int row = 0; int host = 0; int guest = 0; string visitor = ""; string vtype = ""; string address = ""; string narration = ""; string contact = "";
        DateTime visiting = DateTime.Now.Date; TimeSpan tmstart = TimeSpan.Parse("00.00:00"); TimeSpan tmend = TimeSpan.Parse("00.00:00"); bool wifi = false;
        bool notified = false; bool response = false; bool gcard = false; int bookingby = 0; int completeby = 0; int atc = 0; string vcardno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { pnlUpperControl.DataBind(); LoadGrid(); }
        }
        private void LoadGrid()
        {
            try
            {
                vcardno = "0";
                dt = new DataTable(); type = 3; bookingby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                if (dt.Rows.Count > 0) { dgvprb.DataSource = dt; dgvprb.DataBind(); }
            }
            catch { }
        }
        protected void CGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                int index = int.Parse(searchKey[0].ToString());
                if (searchKey[2].ToString() == "Yes" && searchKey[3].ToString() == "Pending")
                {
                    vcardno = (dgvprb.Rows[index].FindControl("txtVCardNo") as TextBox).Text.ToString();
                    address = (dgvprb.Rows[index].FindControl("txtLocation") as TextBox).Text.ToString();
                    contact = (dgvprb.Rows[index].FindControl("txtphn") as TextBox).Text.ToString();
                    //tmstart = TimeSpan.Parse((dgvprb.Rows[index].FindControl("tpkIn") as TimeSelector).Date.ToString("hh:mm:ss"));
                    tmstart = TimeSpan.Parse(DateTime.Now.Date.ToString("hh:mm:ss"));
                    dt = new DataTable(); gcard = true; type = 5; row = int.Parse(searchKey[1].ToString());
                    dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                    tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                    msg = dt.Rows[0]["Messages"].ToString();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Generate Successfully.');", true);
                }
            }
            catch { }
            LoadGrid();
        }
        protected void Complete_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                int index = int.Parse(searchKey[0].ToString());
                if (searchKey[2].ToString() == "Generated" && searchKey[3].ToString() == "Close")
                {
                    //tmend = TimeSpan.Parse((dgvprb.Rows[index].FindControl("tpkOut") as TimeSelector).Date.ToString("hh:mm:ss"));
                    tmend  = TimeSpan.Parse(DateTime.Now.Date.ToString("hh:mm:ss"));
                    vcardno = (dgvprb.Rows[index].FindControl("txtVCardNo") as TextBox).Text.ToString();
                    dt = new DataTable(); response = true; type = 6; row = int.Parse(searchKey[1].ToString());
                    completeby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                    tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                    msg = dt.Rows[0]["Messages"].ToString();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Close Successfully.');", true);
                }
            }
            catch { }
            LoadGrid();
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        { LoadGrid(); }

        protected void dgvprb_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (dgvprb.Rows.Count > 0)
            {
                for (int index = 0; index < dgvprb.Rows.Count; index++)
                {
                    //string reffid = ((TextBox)dgvprb.Rows[index].FindControl("txtVCardNo")).Text.ToString();
                    //if(reffid !="") { ((TextBox)dgvprb.Rows[index].FindControl("txtVCardNo")).Enabled = false; }
                }
            }
        }





    }
}
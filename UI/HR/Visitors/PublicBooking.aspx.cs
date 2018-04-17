using HR_BLL.Visitors;
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
    public partial class PublicBooking : BasePage
    {
        VisitorsBLL vbll = new VisitorsBLL(); string[] arrayKey; char[] delimiterChars = { '[', ']' }; DataTable dt; string msg = "";
        int type = 0; int row = 0; int host = 0; int guest = 0; string visitor = ""; string vtype = ""; string address = ""; string narration = ""; string contact = "";
        DateTime visiting = DateTime.Now.Date; TimeSpan tmstart = TimeSpan.Parse("00.00:00"); TimeSpan tmend = TimeSpan.Parse("00.00:00"); bool wifi = false;
        bool notified = false; bool response = false; bool gcard = false; int bookingby = 0; int completeby = 0; int atc = 0; string vcardno;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnbookingby.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            if (!IsPostBack) { pnlUpperControl.DataBind(); Clearcontrols(); }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    arrayKey = txtHost.Text.Split(delimiterChars);
                    if (arrayKey.Length == 7)
                    {  host = int.Parse(arrayKey[5].ToString());//Host Id
                    }
                    
                    arrayKey = txtGuest.Text.Split(delimiterChars);
                    if (arrayKey.Length == 7)
                    {
                        visitor = arrayKey[0].ToString();            //Visitor Name
                        vtype = arrayKey[1].ToString();            //Visitor Type
                        guest = int.Parse(arrayKey[5].ToString());//Visitor Id
                    }
                    else
                    {
                        visitor = arrayKey[0].ToString();//Visitor Name
                        vtype = "ANV"; //Visitor Type
                    }

                    vcardno = "0";
                    address = txtAddguest.Text; narration = txtNarration.Text; contact = txtContact.Text; atc=int.Parse(ddlCalendr.SelectedValue.ToString());
                    visiting = DateTime.Parse(txtVDate.Text); if (chkwifi.Checked == true) { wifi = true; } else { wifi = false; }
                    dt = new DataTable(); type = 0; bookingby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    tmstart = TimeSpan.Parse(tpkSTime.Hour.ToString() + ":" + tpkSTime.Minute.ToString() + ":" + tpkSTime.Second.ToString());
                    tmend = TimeSpan.Parse(tpkETime.Hour.ToString() + ":" + tpkETime.Minute.ToString() + ":" + tpkETime.Second.ToString());
                    dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                    tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                    msg = dt.Rows[0]["Messages"].ToString(); Clearcontrols();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }
        }
        private void Clearcontrols()
        {
            txtHost.Text = ""; txtGuest.Text = ""; txtAddguest.Text = ""; txtNarration.Text = ""; txtContact.Text = "";
            txtVDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); chkwifi.Checked = false; LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                vcardno = "0";
                dt = new DataTable(); type = 2; bookingby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                if (dt.Rows.Count > 0) { dgvprb.DataSource = dt; dgvprb.DataBind(); }
            }
            catch { }
        }
               

    }
}
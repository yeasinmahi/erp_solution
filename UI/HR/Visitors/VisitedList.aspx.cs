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
    public partial class VisitedList : BasePage
    {
        VisitorsBLL vbll = new VisitorsBLL(); DataTable dt; 
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
                dt = new DataTable(); type = 7; bookingby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = vbll.GetSetVisitorInformation(type, row, host, guest, visitor, vtype, address, narration, contact, visiting, tmstart,
                tmend, wifi, notified, response, gcard, bookingby, completeby, atc, vcardno);
                if (dt.Rows.Count > 0) { dgvprb.DataSource = dt; dgvprb.DataBind(); }
            }
            catch { }
        }
    }
}
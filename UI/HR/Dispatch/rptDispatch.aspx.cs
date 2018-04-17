using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using UI.ClassFiles;
using HR_BLL.Dispatch;

namespace UI.HR.Dispatch
{
    public partial class rptDispatch : BasePage
    {
        DispatchBLL objdp = new DispatchBLL();
        DataTable dt;

        string fdate; string tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try 
                { 
                    pnlUpperControl.DataBind(); txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch { }
            }            
        }

        protected void btnShow_Click(object sender, EventArgs e) { LoadGrid(); }

        private void LoadGrid()
        {
            try
            {
                fdate = txtFromDate.Text;
                tdate = txtToDate.Text;
                
                dt = new DataTable();
                dt = objdp.GetDispatchR(fdate, tdate);
                dgvReport.DataSource = dt; 
                dgvReport.DataBind();
            }
            catch { }
        }
        protected void btnDslVew_Click(object sender, CommandEventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);
            }
            catch { }
        }













    }
}
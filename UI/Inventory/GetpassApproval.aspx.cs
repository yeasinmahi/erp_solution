using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class GetpassApproval : BasePage
    {
        DaysOfWeek bll = new DaysOfWeek(); DataTable dtbl = new DataTable(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        protected void App_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Pending"))
                {
                    if (hdnconfirm.Value == "1")
                    {
                        string senderdata = ((Button)sender).CommandArgument.ToString();
                        dtbl = bll.CreateGetpass(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(senderdata), DateTime.Now, DateTime.Now);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dtbl.Rows[0]["Messages"].ToString() + "');", true);
                        Loadgrid();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this memo already approved.');", true);
                    Loadgrid();
                }

            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void Loadgrid()
        {
            try
            {
                dtbl = bll.CreateGetpass(1, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", 0, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                if (dtbl.Rows.Count > 0) { dgvlist.DataSource = dtbl; dgvlist.DataBind(); }
                else { dgvlist.DataSource = ""; dgvlist.DataBind(); }
            }
            catch { }
        }
        protected void Dtls_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0].ToString() + "','" + datas[1].ToString() + "');", true);
                Loadgrid();
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

    }
}
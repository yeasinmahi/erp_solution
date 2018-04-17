using HR_BLL.TourPlan;
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
    public partial class BrandItemReceivingConfirmation : System.Web.UI.Page
    {

        DataTable dtbl = new DataTable();
        TourPlanning bll = new TourPlanning();
        string qnt = "0.00"; string reqid;
        string xmlpath; string xmlString = ""; string innerReportHtml = ""; string innerBodyHtml = ""; int GrandTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/BrandItemsISSUEREQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); hdnuserid.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                //try { File.Delete(xmlpath); }
                //catch { }
            }
        }
        private void Loadgrid()
        {
            try
            {
                dtbl = bll.CreateStoreRequisitionForBrandItem(9, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", 0, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                if (dtbl.Rows.Count > 0)
                {
                    dgvBrandItemReceiveStatus.DataSource = dtbl; dgvBrandItemReceiveStatus.DataBind();

                }
                else { dgvBrandItemReceiveStatus.DataSource = ""; dgvBrandItemReceiveStatus.DataBind(); }
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {

        }

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBrandItemReceiveStatus.Rows.Count > 0)
                {
                    int rc = dgvBrandItemReceiveStatus.Rows.Count;
                    char[] delimiterChars = { ',' };
                    string temp = ((Button)sender).CommandArgument.ToString();
                    string[] searchKey = temp.Split(delimiterChars);
                    string intID = searchKey[0].ToString();
                    int reqid = int.Parse(intID);
                    bool val = false;
                    dtbl = bll.CreateStoreRequisitionForBrandItem(10, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", reqid, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                    string sts = "1";
                    sts = dtbl.Rows[0]["Messages"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('" + sts + "');", true);
                    Loadgrid();
                }
                else
                { }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }


    }
}

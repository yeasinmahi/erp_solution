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
    public partial class BradndItemRequisitonDetaills : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DaysOfWeek bll = new DaysOfWeek();
                TourPlanning bll = new TourPlanning();
                DataTable dtbl = new DataTable();
                string reqid = Request.QueryString["ID"];
                dtbl = bll.CreateStoreRequisitionForBrandItem(1, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Now, DateTime.Now);
                if (dtbl.Rows.Count > 0) { dgvlist.DataSource = dtbl; dgvlist.DataBind(); }
                else { dgvlist.DataSource = ""; dgvlist.DataBind(); }

            }
        }
    }
}
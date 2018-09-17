using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class TransferDelvOrderInactive : System.Web.UI.Page
    {
        string DONumber, strDO;
        int lvel, insertby, unit,shippointid;
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\TransferDelvOrderInactive";
        string stop = "stopping SAD\\Order\\TransferDelvOrderInactive";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
              
                //Loadgrid();

            }
            else
            {

            }
        }
        private void Loadgrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\TransferDelvOrderInactive Grid Load Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                unit = int.Parse(ddlUnit.SelectedValue.ToString());
                Session["unit"] = unit;
                try { DONumber = (txtdonumber.Text.ToString()); }
                catch { DONumber = "0"; }
                insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                lvel = 4;
                shippointid = int.Parse(ddlShip.SelectedValue.ToString());
                Session["shippointid"] = shippointid;
                dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, DONumber, lvel, insertby, shippointid);
                if (dt.Rows.Count > 0)
                {
                    grdvDelvOrderInactive.DataSource = dt;
                    grdvDelvOrderInactive.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        private void Loadgridaftersubmit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\TransferDelvOrderInactive  Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                unit = int.Parse(ddlUnit.SelectedValue.ToString());
                try { DONumber = (txtdonumber.Text.ToString()); }
                catch { DONumber = "0"; }
                insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                lvel = 6;
                unit = int.Parse(Session["unit"].ToString());
                shippointid = int.Parse(Session["shippointid"].ToString());
                dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, DONumber, lvel, insertby, shippointid);
                if (dt.Rows.Count > 0)
                {
                    grdvDelvOrderInactive.DataSource = dt;
                    grdvDelvOrderInactive.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }


     

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            ddlShip.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        protected void grdvDelvOrderInactive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string CellValuestatus = (e.Row.Cells[8].Text.ToString());
            e.Row.Attributes.Add("onmouseover",
            "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#A0BB0A';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            if (CellValuestatus == "active") { e.Row.BackColor = System.Drawing.Color.LightGreen; }
            else { e.Row.BackColor = System.Drawing.Color.LightCyan; }

        }



        protected void btnInactiveDO_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\TransferDelvOrderInactive  Submit Do", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            strDO = searchKey[0].ToString();
            insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            lvel = 5;
            unit = int.Parse(Session["unit"].ToString());
            shippointid = int.Parse(Session["shippointid"].ToString());
            dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, strDO, lvel, insertby, shippointid);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);
            Loadgridaftersubmit();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
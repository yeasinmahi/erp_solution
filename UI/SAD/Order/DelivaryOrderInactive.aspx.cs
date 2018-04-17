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
    public partial class DelivaryOrderInactive : BasePage
    {
        string DONumber, strDO;
        int lvel, insertby, unit;
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
       
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
            try
            {
                unit = int.Parse(drdlUnitName.SelectedValue.ToString());
                try { DONumber = (txtdonumber.Text.ToString()); }
                catch { DONumber = "0"; }
                insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                lvel = 1;
                dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, DONumber, lvel, insertby,0);
                if (dt.Rows.Count > 0)
                {
                    grdvDelvOrderInactive.DataSource = dt;
                    grdvDelvOrderInactive.DataBind();
                }
            }

            catch
            { }

        }
        private void Loadgridaftersubmit()
        {
            try
            {
                unit = int.Parse(drdlUnitName.SelectedValue.ToString());
                try { DONumber = (txtdonumber.Text.ToString()); }
                catch { DONumber = "0"; }
                insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                lvel = 3;
                dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, DONumber, lvel, insertby,0);
                if (dt.Rows.Count > 0)
                {
                    grdvDelvOrderInactive.DataSource = dt;
                    grdvDelvOrderInactive.DataBind();
                }
            }

            catch
            { }

        }


        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        protected void grdvDelvOrderInactive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string CellValuestatus = (e.Row.Cells[8].Text.ToString());
            e.Row.Attributes.Add("onmouseover",
            "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            if (CellValuestatus == "active") { e.Row.BackColor = System.Drawing.Color.Green; }
            else { e.Row.BackColor = System.Drawing.Color.Red; }

        }

   

        protected void btnInactiveDO_Click(object sender, EventArgs e)
        {
        char[] delimiterChars = { ',' };
        string temp = ((Button)sender).CommandArgument.ToString();
        string[] searchKey = temp.Split(delimiterChars);
        strDO = searchKey[0].ToString();
        insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
        lvel = 2;
        dt = bll.getdataDeliverayOrderInactiveforRemaningQnt(unit, strDO, lvel, insertby,0);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);
            Loadgridaftersubmit();
        }
    }
}
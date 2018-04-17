using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Purchase_BLL.Commercial;
using UI.ClassFiles;
using Purchase_BLL.SupplyChain;


namespace UI.Inventory
{
    public partial class SupplierFinal : BasePage
    {

        DataTable dt = new DataTable();
        CSM Suppliereport = new CSM();
        CSM report = new CSM();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = report.GetRequest1();
                dgvlist.DataSource = dt;
                dgvlist.DataBind();
            }
        }

        //protected void submit_Click(object sender, EventArgs e)
        //{
            
        //    dt = report.getReport();
        //    dgvlist.DataSource = dt;
        //    dgvlist.DataBind();


        //}
        protected void Complete_Click(object sender, EventArgs e)
        {

            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string msid = searchKey[0].ToString();
                string url = "SupplierEnlistment.aspx";
                Session["msid"] = msid;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('" + url + "','" + msid + "');", true);

            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

       
        }
        protected void dgvlist_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FCFDE4';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            }
        }
        protected void dgvlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        
    }
}
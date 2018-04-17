using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using SAD_BLL.AutoChallanBll;
using System.Text.RegularExpressions;
namespace UI.Factory
{
    public partial class MealMenuAdd : System.Web.UI.Page
    {
        challanandPending rReport = new challanandPending();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Showdata();


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           // String scaleid = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text;

            string mealitem = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text.ToString());
            int ids =int.Parse(((Label)GridView1.Rows[e.RowIndex].FindControl("Label2")).Text.ToString());
            rReport.updateReport(ids, mealitem);

            GridView1.EditIndex = -1;

          

            Showdata();

        }

        protected void txtenroll_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Showdata();

           


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            Showdata();
         
        }

        private void Showdata()
        {
            DataTable dtReport = new DataTable();
           
            string dayname = DropDownList1.SelectedItem.ToString();

            dtReport = rReport.getmenuReport(dayname);

            GridView1.DataSource = dtReport;
            GridView1.DataBind();
        }
    }
}
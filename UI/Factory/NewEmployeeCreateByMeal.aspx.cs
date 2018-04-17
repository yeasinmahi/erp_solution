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
    public partial class NewEmployeeCreateByMeal : System.Web.UI.Page
    {
        challanandPending Report = new challanandPending();
        DataTable DtReport = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            int enroll =int.Parse(txtenroll.Text.ToString());
            Decimal discount = Decimal.Parse(txtDiscount.Text.ToString());
            Decimal EmpContribute = Decimal.Parse(txtEmployeeContirbute.Text.ToString());
            Decimal total = Decimal.Parse(txttotal.Text.ToString());
            string temppermant = DropDownList1.SelectedValue.ToString();

            Report.getEmployeeSetup(enroll,temppermant, discount, EmpContribute, total);


            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
            txtDiscount.Text = "";
            txtEmployeeContirbute.Text = "";
            txttotal.Text = "";
            txtenroll.Text = "";



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          
           int enroll =int.Parse(txtenroll.Text.ToString());
            string temppermant = DropDownList1.SelectedValue.ToString();
            Report.getEmployeeCatagoryUpdate(enroll,temppermant);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SAD_BLL.Corporate_sales;
using System.Web.Script.Services;

namespace UI.SAD.Corporate_sales
{
    public partial class AFBLReconcile : BasePage
    {
        DataTable dt = new DataTable();
        DataTable chequee = new DataTable();
        DataTable dairydt = new DataTable();
        DataTable Dtlogin = new DataTable();
        DataTable dtcustname = new DataTable();
        DataTable dtrsmcustname = new DataTable();
        DataTable dtCount = new DataTable();
        DataTable dairydtrsmcustname = new DataTable();
 
        Bridge newreport = new Bridge();
        Bridge br = new Bridge();
        Bridge insertinfo = new Bridge();
      
        int enroll = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
               // enroll = int.Parse(2233.ToString());            
            }
        }

         
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            dairydt = newreport.getdairyreconsulationreport();
            dgvtrgt.DataSource = dairydt;
            dgvtrgt.DataBind();
        }

        protected void Complete_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 accountid = int.Parse(searchKey[0].ToString());
                Session["accountid"] = accountid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('UnfoundView.aspx');", true);
            }
            catch { }     
        }
    }
}
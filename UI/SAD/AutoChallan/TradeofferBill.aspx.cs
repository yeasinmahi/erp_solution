using HR_BLL.Global;
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
using HR_BLL;
using HR_BLL.BulkSMS;
using SAD_BLL.AutoChallanBll;

namespace UI.SAD.AutoChallan
{
    public partial class TradeofferBill : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        challanandPending Report = new challanandPending();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              int   enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
               // int enroll = int.Parse("1040");

              if (enroll != 1040)
              {
                  dtReport = Report.getTradeofferbill();
                  GridView1.DataSource = dtReport;
                  GridView1.DataBind();
              }
              else
              {
                  dtReport = new DataTable();
                  dtReport = Report.getTradeofferAccounts();
                  GridView2.DataSource = dtReport;
                  GridView2.DataBind();
              }
            
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;

                Report.getApprove(slipno);

              
             

            }
            catch { }


        }
        protected void Updates(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ApproveDetailsReport.aspx');", true);
            }
            catch { }


        }
        protected void Update1(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ApproveDetailsReport.aspx');", true);
            }
            catch { }


        }
    }
}
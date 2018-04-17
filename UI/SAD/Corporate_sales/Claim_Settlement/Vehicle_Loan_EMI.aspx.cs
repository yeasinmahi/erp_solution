using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL.Corporate_sales;

namespace UI.SAD.Corporate_sales.Claim_Settlement
{
    public partial class Vehicle_Loan_EMI : System.Web.UI.Page
    {
        Bridge obj = new Bridge(); int enroll=0; decimal total = 0, negtotal = 0;
        string emi,emi1, ttl, month, narrations, JVID, custid, COAid, CustName, vehiclepayid, custloanid, custloancoaid, CustLoanName, narration; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                get.Visible = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                get.Visible = true;
                DataTable dt = new DataTable();
                dt = obj.selectloanvehicle();
                gvdistlist.DataSource = dt;
                gvdistlist.DataBind();
            }
            catch { }
        }
        protected void get_Click(object sender, EventArgs e)
        {
            if (gvdistlist.Rows.Count > 0)
            {
                for (int index = 0; index < gvdistlist.Rows.Count; index++)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    custid = ((Label)gvdistlist.Rows[index].FindControl("lblintcustomerid")).Text.ToString();
                    vehiclepayid = ((Label)gvdistlist.Rows[index].FindControl("lblintvehiclepaymentid")).Text.ToString();
                    emi = ((Label)gvdistlist.Rows[index].FindControl("lblmonemi")).Text.ToString();
                    DateTime datetime = DateTime.Now;
                    narration = "Being vehicle monthly instalment amount :" + emi + " dedcut for The month of " + month ;
                    obj.insertdata(Convert.ToInt32(custid), Convert.ToInt32(vehiclepayid), Convert.ToDecimal(emi), datetime, enroll);
                }
                obj.JVCreateVehicleLoan();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Success');window.location.reload(true);", true);
            }
        }





















    }
}
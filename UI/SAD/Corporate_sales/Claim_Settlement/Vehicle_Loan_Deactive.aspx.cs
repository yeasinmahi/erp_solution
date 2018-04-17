using SAD_BLL.Corporate_sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Corporate_sales.Claim_Settlement
{
    public partial class Vehicle_Loan_Deactive : System.Web.UI.Page
    {
        Bridge obj = new Bridge(); string strcust, amount, COAid, AccName, negamount, ttl, vehiclepayid, payable;
        int custoid, custid; decimal decpayable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rightdiv.Visible = false;   
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] GetCust(string customer)
        {
            DataTable dt = new DataTable();
            List<string> item = new List<string>();
            Bridge obj = new Bridge();
            dt = obj.GetCustomer(customer);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strcust = dt.Rows[i]["customerinfo"].ToString();
                item.Add(strcust);
            }
            return item.ToArray();
        }

        protected void status_Click(object sender, EventArgs e)
        {
            try
            {
                custoid = int.Parse(hdfcustid.Value);
                DataTable dtblnc = new DataTable();
                dtblnc = obj.custbalance(custoid);
                try { tbxcustblnc.Text = dtblnc.Rows[0]["balance"].ToString(); } catch { tbxcustblnc.Text = "Null".ToString(); }

                if (rdhndovrtype.SelectedItem.Value == "1")
                {
                    try
                    {
                        custid = int.Parse(hdfcustid.Value);
                        DataTable dt = new DataTable();
                        dt = obj.fnlsttltocompany(custid);
                        gvfnlsttl.DataSource = dt;
                        gvfnlsttl.DataBind();
                        gvfnlsttl.Visible = true;
                        if (gvfnlsttl.Rows.Count > 0)
                        {
                            rightdiv.Visible = true;
                           
                        }
                    }
                    catch  { }
                }
                if (rdhndovrtype.SelectedItem.Value == "2")
                {
                    try
                    {
                        custid = int.Parse(hdfcustid.Value);
                        DataTable dt = new DataTable();
                        dt = obj.fnlsttltocustomer(custid);
                        gvfnlsttl.DataSource = dt;
                        gvfnlsttl.DataBind();
                        gvfnlsttl.Visible = true;
                        if (gvfnlsttl.Rows.Count > 0)
                        {
                            rightdiv.Visible = true;
                           
                        }
                    }
                    catch {}
                }
                else {  }
            }
            catch { }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            try
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                DateTime datetime = DateTime.Now;
                custid = int.Parse(hdfcustid.Value);
                Button btn = (Button)sender;
                string[] CommandArgument = btn.CommandArgument.Split(',');
                vehiclepayid = CommandArgument[1];
                payable = CommandArgument[2];
                decpayable = Convert.ToDecimal(payable);
                if (rdhndovrtype.SelectedItem.Value == "2")
                    {
                       decpayable = (decpayable * -1);
                    }
                obj.settleclose(custid);
                obj.insertdata(Convert.ToInt32(custid), Convert.ToInt32(vehiclepayid), Convert.ToDecimal(decpayable), datetime, enroll);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Success');window.location.reload(true);", true);
            }

             catch { }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);

        }

   
    }
}
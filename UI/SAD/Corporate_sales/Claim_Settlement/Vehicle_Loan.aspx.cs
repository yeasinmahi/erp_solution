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
    public partial class Vehicle_Loan : System.Web.UI.Page
    {
        Bridge obj = new Bridge(); int enroll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //enroll = int.Parse(2233.ToString());
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] GetCustomer(string customer)
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] GetLoanCustomer(string customer)
        {
            DataTable dt = new DataTable();
            List<string> item = new List<string>();
            Bridge obj = new Bridge();
            dt = obj.GetLoanCustomer(customer);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strcust = dt.Rows[i]["customerinfo"].ToString();
                item.Add(strcust);
            }
            return item.ToArray();
        }

        protected void txtvclprc_TextChanged(object sender, EventArgs e)
        {
            Decimal price = 0;
            Decimal downpayment = 0;
            Decimal depriciation = 0;
            Decimal emi = 0;
            price = Convert.ToDecimal(String.IsNullOrEmpty(txtvclprc.Text) ? "0" : txtvclprc.Text);
            Decimal life = Convert.ToDecimal(String.IsNullOrEmpty(txtuselif.Text) ? "0" : txtuselif.Text);
            try { depriciation = Math.Round((price / life), 0); }
            catch { depriciation = 0; }
            txtdepm.Text = Convert.ToString(depriciation);
            downpayment = Convert.ToDecimal(String.IsNullOrEmpty(txtdwnpay.Text) ? "0" : txtdwnpay.Text);
            Decimal loanmonth = Convert.ToDecimal(String.IsNullOrEmpty(txtloanmnt.Text) ? "0" : txtloanmnt.Text);
            try { emi = Math.Round(((price - downpayment) / loanmonth), 0); }
            catch { emi = 0; }
            txtemi.Text = Convert.ToString(emi);
        }

        protected void txtdwnpay_TextChanged(object sender, EventArgs e)
        {
            Decimal price = 0;
            Decimal downpayment = 0;
            Decimal depriciation = 0;
            Decimal emi = 0;
            price = Convert.ToDecimal(String.IsNullOrEmpty(txtvclprc.Text) ? "0" : txtvclprc.Text);
            Decimal life = Convert.ToDecimal(String.IsNullOrEmpty(txtuselif.Text) ? "0" : txtuselif.Text);
            try { depriciation = Math.Round((price / life), 0); }
            catch { depriciation = 0; }
            txtdepm.Text = Convert.ToString(depriciation);
            downpayment = Convert.ToDecimal(String.IsNullOrEmpty(txtdwnpay.Text) ? "0" : txtdwnpay.Text);
            Decimal loanmonth = Convert.ToDecimal(String.IsNullOrEmpty(txtloanmnt.Text) ? "0" : txtloanmnt.Text);
            try { emi = Math.Round(((price - downpayment) / loanmonth), 0); }
            catch { emi = 0; }
            txtemi.Text = Convert.ToString(emi);
        }
       
        protected void txtuselif_TextChanged(object sender, EventArgs e)
        {
            Decimal price = 0;
            Decimal depriciation = 0;
            price = Convert.ToDecimal(String.IsNullOrEmpty(txtvclprc.Text)? "0":txtvclprc.Text);
            Decimal life = Convert.ToDecimal(String.IsNullOrEmpty(txtuselif.Text)?"0":txtuselif.Text);
            try { depriciation = Math.Round((price / life), 0); }
            catch {  depriciation = 0; }
            txtdepm.Text = Convert.ToString(depriciation);

        }
        protected void txtloanmnt_TextChanged(object sender, EventArgs e)
        {
            Decimal price = 0;
            Decimal downpayment = 0;
            Decimal emi = 0;
            price = Convert.ToDecimal(String.IsNullOrEmpty(txtvclprc.Text) ? "0" : txtvclprc.Text);
            downpayment = Convert.ToDecimal(String.IsNullOrEmpty(txtdwnpay.Text) ? "0" : txtdwnpay.Text);
            Decimal loanmonth = Convert.ToDecimal(String.IsNullOrEmpty(txtloanmnt.Text) ? "0" : txtloanmnt.Text);
            try { emi = Math.Round(((price - downpayment) / loanmonth), 0); }
            catch { emi = 0; }
            txtemi.Text = Convert.ToString(emi);
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
            DataTable dtvehicleid = new DataTable();
            dtvehicleid = obj.getscopeid();
            string lastid = dtvehicleid.Rows[0]["introwid"].ToString();
            int vehiclescopeid = Convert.ToInt32(lastid) + 1;  
            string strcustid = hdfcustid.Value;
            int custid = Convert.ToInt32(hdfcustid.Value);
            int vehiclepaymentid = Convert.ToInt32(custid + "" +vehiclescopeid);
            int intcustloanid = int.Parse(hdncustvehicleid.Value);
            string strvehiclechesisno = txtchno.Text;
            string strmodelno = txtmodelnno.Text;
            DateTime dtdeliverydate = Convert.ToDateTime(txtHOvrDate.Text);
            decimal monvehicleprice = Convert.ToDecimal(txtvclprc.Text);
            decimal downpayment = Convert.ToDecimal(txtdwnpay.Text);
            decimal monusefullife = Convert.ToDecimal(txtuselif.Text);
            decimal monloanperiod = Convert.ToDecimal(txtloanmnt.Text);
            decimal mondepreciation = Convert.ToDecimal(txtdepm.Text);
            decimal monemi = Convert.ToDecimal(txtemi.Text);
            int insertedby = enroll;
            DateTime dtdatetimenow = DateTime.Now;
            obj.insertvehicle(custid, vehiclepaymentid, intcustloanid, strvehiclechesisno, strmodelno, dtdeliverydate, monvehicleprice, downpayment, monusefullife, monloanperiod, mondepreciation, monemi, insertedby, dtdatetimenow);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfull');window.location.reload(true);", true);
            }
            catch {  }
        }

       

       
    }
}
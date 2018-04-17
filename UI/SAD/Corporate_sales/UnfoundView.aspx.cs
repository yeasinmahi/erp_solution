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

namespace UI.SAD.Corporate_sales
{
    public partial class UnfoundView : BasePage
    {
        DataTable dt = new DataTable();
        DataTable chequee = new DataTable();
        DataTable accountno = new DataTable();
        DataTable dairydt = new DataTable();
        DataTable Dtlogin = new DataTable();
        DataTable dtcustname = new DataTable();
        DataTable dtrsmcustname = new DataTable();
        DataTable dtCount = new DataTable();
        DataTable dairydtrsmcustname = new DataTable();
        Bridge newreport = new Bridge();
        Bridge br = new Bridge();
        Bridge insertinfo = new Bridge();
        Int32 permissionnumber; string strnaration; Int32 intaccountid; string dtedatenew; string cheque; decimal amount; int enroll = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {
               
            intaccountid = Convert.ToInt32(Session["accountid"].ToString());

            dt = newreport.getaccountinfo(intaccountid);
        
            dtedatenew = Convert.ToString(dt.Rows[0]["dteDate"].ToString());
            strnaration = Convert.ToString(dt.Rows[0]["strParticulars"].ToString());
            cheque = Convert.ToString(dt.Rows[0]["strChequeNo"].ToString());
            amount = Convert.ToDecimal(dt.Rows[0]["monAmount"].ToString());
            Session["intaccountid"] = intaccountid;
            Session["dtedate"] = dtedatenew;
            Session["strnaration"] = strnaration;
            Session["cheque"] = cheque;
            Session["amount"] = amount;
            Session["bankaccountid"] = Session["bankaccountid"];
   
            TextBox1.Text = Convert.ToString(intaccountid.ToString());

            TextBox4.Text = Convert.ToString(amount.ToString());
            TextBox2.Text = Convert.ToString(dtedatenew.ToString());
            TextBox3.Text = Convert.ToString(strnaration.ToString());

            Button1.Visible = true;
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] GetCustomer(string customer)
        {
            DataTable dt = new DataTable();
            List<string> item = new List<string>();
            Bridge obj = new Bridge();
            dt = obj.GetDist(customer);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strcust = dt.Rows[i]["distributorinfo"].ToString();
                item.Add(strcust);
            }
            return item.ToArray();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Int32 id = int.Parse(Session["intaccountid"].ToString());
            accountno = newreport.getbankaccountno(id);
            string bankaccountid = accountno.Rows[0]["strAccountNo"].ToString();


            Int64 intid = Convert.ToInt64(id);
            decimal finalamount = decimal.Parse(Session["amount"].ToString());
            DateTime dtedate = DateTime.Parse(Session["dtedate"].ToString());
            cheque = (Session["cheque"].ToString());
            enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int custid = Convert.ToInt32(hdfcustid.Value);
            string customerid = Convert.ToString(custid.ToString());
            decimal monamount = Convert.ToDecimal(finalamount.ToString());
            if (cheque == "")
            {
                cheque = "000";
            }
            else
            {
                cheque = (Session["cheque"].ToString());
            }
            string inputcheque = TextBox5.Text;
            chequee = newreport.getchequee(cheque, inputcheque);
            string finalChequeinput = chequee.Rows[0]["input"].ToString();
            string finalCheque = chequee.Rows[0]["bank"].ToString();
            DateTime dttodatecount = DateTime.Today;
            string dtetodatecount = Convert.ToString(dttodatecount);
            dtCount = newreport.GetCheckDistCount(custid, dtetodatecount);
            Int32 checkcount = Convert.ToInt32(dtCount.Rows[0]["count"].ToString());

            if (checkcount < 1)
            {


                if ((Convert.ToString(bankaccountid.ToString()) == Convert.ToString("20502130100077512".ToString())) || (Convert.ToString(bankaccountid.ToString()) == Convert.ToString("20501090100915113".ToString())))
                {
                    if (finalCheque == finalChequeinput)
                    {
                        enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                        string nnaration = (Session["strnaration"].ToString());
                        string naration = nnaration + dtedate;
                        Int32 intunitid = Convert.ToInt32("2");

                        br.updatestatement(nnaration, customerid, intid);
                        string dtedepositdate = Convert.ToString(dtedate);
                        insertinfo.insertunfoundinfo(enroll, custid, cheque, dtedepositdate, monamount, id);
                        br.insertReconsulation(intunitid, enroll, custid, monamount, naration);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error Chequee No !');", true);
                    }
                }
                else
                {

                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                    string nnaration = (Session["strnaration"].ToString());
                    string naration = nnaration + dtedate;
                    Int32 intunitid = Convert.ToInt32("2");

                    br.updatestatement(nnaration, customerid, intid);
                    string dtedepositdate = Convert.ToString(dtedate);
                    insertinfo.insertunfoundinfo(enroll, custid, cheque, dtedepositdate, monamount, id);
                    br.insertReconsulation(intunitid, enroll, custid, monamount, naration);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";

                }


            }
        }
    }
}
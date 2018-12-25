using HR_BLL.Employee;
using HR_DAL.Employee;
using SAD_BLL.Sales;
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
    public partial class BillSubmitPendingToCustomerDet : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int custmid, salesofid;
        DateTime fromdate, todate;
        SalesView bll = new SalesView();
        EmployeeDetails bllh =new EmployeeDetails();
        DataTable dt = new DataTable();
        string custid, dtfrm, dtto, sofid;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String test = DateTime.Now.ToString("dd/MM/yyyy");
                lbldate.Text = test;
                

                custid = Session["intcustid"].ToString();
                dtfrm = Session["dtfromdate"].ToString();
                dtto = Session["dtetodate"].ToString();
                sofid = Session["intsalesoffice"].ToString();
                fromdate = DateTime.Parse(dtfrm);
                todate= DateTime.Parse(dtto);
                dt= bll.GetdataforBillSubmission(3, 4, fromdate, todate, int.Parse(sofid), int.Parse(custid), "", 0);

                if (dt.Rows.Count > 0)
                {

                   
                    dgbCustomerprintcopy.DataSource = dt;
                    dgbCustomerprintcopy.DataBind();

                    string prchqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqntprimary")).ToString();
                    string prchamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanamoutnprim")).ToString();
                    string rtnqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decrtnqnt")).ToString();
                    string netqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("billqnt")).ToString();
                    string netamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("billamount")).ToString();
                    dgbCustomerprintcopy.FooterRow.Cells[4].Text = "Total";
                    dgbCustomerprintcopy.FooterRow.Cells[6].Text = prchqnt.ToString();
                    //dgbCustomerprintcopy.FooterRow.Cells[7].Text = prchamount.ToString();
                    //dgbCustomerprintcopy.FooterRow.Cells[8].Text = rtnqnt.ToString();
                    dgbCustomerprintcopy.FooterRow.Cells[7].Text = netqnt.ToString();
                    dgbCustomerprintcopy.FooterRow.Cells[9].Text = netamount.ToString();
                }
                lblcustomername.Text = dt.Rows[0][2].ToString();
                lblcustmainadr.Text = dt.Rows[0][18].ToString();
                int enrol= int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = bllh.getEmployeeDetails(enrol);
                lblSubmittedby.Text = dt.Rows[0][0].ToString();
                lblsubmittedDesg.Text = dt.Rows[0][1].ToString();

               
               
            }
        }


        public static string AmountToWord(int number)
        {
            if (number == 0) return "Zero";

            if (number == -2147483648)
                return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
"Five " ,"Six ", "Seven ", "Eight ", "Nine "};

            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
"Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};

            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
"Seventy ","Eighty ", "Ninety "};

            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs

            //You can increase as per your need.

            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }


            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;

                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens

                if (h > 0) sb.Append(words0[h] + "Hundred ");

                if (u > 0 || t > 0)
                {
                    if (h == 0)
                        sb.Append("");
                    else
                        if (h > 0 || i == 0) sb.Append(" ");


                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }

                if (i != 0) sb.Append(words3[i - 1]);

            }
            return sb.ToString().TrimEnd() + " Taka only";

        }





        protected void dgbCustomerprintcopy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected decimal Drgrandtotal = 0; protected decimal Crgrandtotal = 0; protected decimal qtytotal = 0;

        protected void dgbCustomerprintcopy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Crgrandtotal += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblCrGrandTotal")).Text);
                //qtytotal += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblqtyTotal")).Text);
                Session["Crgrandtotal"] = Crgrandtotal;

            }

            int netamount = int.Parse(Crgrandtotal.ToString());
            string words = AmountToWord(netamount);
           
            lbldataQuantity.Text = words;
        }


        

    }
}
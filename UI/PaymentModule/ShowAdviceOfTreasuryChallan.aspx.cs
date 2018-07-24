using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL.Payment;
using System.Data;

namespace UI.PaymentModule
{
    public partial class ShowAdviceOfTreasuryChallan : BasePage
    {
        TreasuryChallanBLL objtreasuryChallanBLL = new TreasuryChallanBLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            int intVatAcc = int.Parse(Request.QueryString["id"]);
            //dt = objtreasuryChallanBLL.GetDetails(intVatAcc);

            //lblDescription.Text=dt.Rows[0]["strDescription"].ToString();
            //Label1.Text= dt.Rows[2]["strDescription"].ToString();
            //Label2.Text = dt.Rows[3]["strDescription"].ToString();
            //Label3.Text = dt.Rows[4]["strDescription"].ToString();
            //Label4.Text = dt.Rows[8]["strDescription"].ToString();
            //Label5.Text = dt.Rows[10]["strDescription"].ToString();
            //Label7.Text = dt.Rows[11]["strDescription"].ToString();
            //Label8.Text = dt.Rows[13]["strDescription"].ToString();

            int intType = 1;

            dt = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            lblDescription.Text = dt.Rows[0]["strDescription"].ToString();
            Label1.Text = dt.Rows[2]["strDescription"].ToString();
            Label2.Text = dt.Rows[3]["strDescription"].ToString();
            Label3.Text = dt.Rows[4]["strDescription"].ToString();
            Label4.Text = dt.Rows[8]["strDescription"].ToString();
            Label5.Text = dt.Rows[10]["strDescription"].ToString();
            Label7.Text = dt.Rows[11]["strDescription"].ToString();
            Label8.Text = dt.Rows[13]["strDescription"].ToString();

            DataTable dt1 = new DataTable();
            intType = 2;
            dt1 = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            DataTable dt2 = new DataTable();
            intType = 3;
            dt2 = objtreasuryChallanBLL.ShowAdvice(intVatAcc, intType);
            Label9.Text = dt2.Rows[0]["strMoney"].ToString();
        }
        decimal totalamount = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int reportType = int.Parse(DdlReport.SelectedItem.Value);
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monAmount"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label amountLabel = e.Row.FindControl("lblTotal") as Label;

                if (amountLabel != null)
                {
                    amountLabel.Text = totalamount.ToString();
                }

            }
        }



















    }
}
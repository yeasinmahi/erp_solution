using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnFTYUpdate : Page
    {
        DataTable dt = new DataTable(); Bridge obj = new Bridge();
        int custid,  fk, productid; string challanno;
        decimal productqtysubmit;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                try
                {
                    custid = int.Parse(HttpContext.Current.Session["CustId"].ToString());
                    challanno = (HttpContext.Current.Session["ChallanNo"].ToString());
                    dt = obj.GetDataForFtyCount(custid, challanno);
                    lblCustomer.Text = dt.Rows[0]["Customer"].ToString();
                    lblchalan.Text = dt.Rows[0]["strChallanNo"].ToString();
                    dgv.DataSource = dt;
                    dgv.DataBind();
                }
                catch { dgv.DataSource = ""; dgv.DataBind(); }
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if((hdnconfirm.Value =="1") &&(dgv.Rows.Count > 0))
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    fk = int.Parse(((HiddenField)dgv.Rows[i].FindControl("hdfk")).Value.ToString());
                    productid = int.Parse(((HiddenField)dgv.Rows[i].FindControl("hdprodid")).Value.ToString());
                    string  productqty = ((TextBox)dgv.Rows[i].FindControl("txtftyrcv")).Text.ToString();
                    productqtysubmit = Decimal.Parse(productqty.ToString());
                    obj.InsertFtyRcvData( productqtysubmit, productid, fk);
                }
                   custid = int.Parse(HttpContext.Current.Session["CustId"].ToString());
                   challanno = (HttpContext.Current.Session["ChallanNo"].ToString());
                   obj.UpdateFtyRcv(custid, challanno);
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Success');CloseWindow();", true);
            }

            else { }
        }


       
    }
}
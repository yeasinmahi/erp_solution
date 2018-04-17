using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnWHUpdate : Page
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
                    dt = obj.GetDataForWHUpdate(custid, challanno);
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
                    string  partyqty = ((TextBox)dgv.Rows[i].FindControl("txtpartyrtn")).Text.ToString();
                    string whqty = ((TextBox)dgv.Rows[i].FindControl("txtwhcv")).Text.ToString();
                    decimal partyqtysubmit = Decimal.Parse(partyqty.ToString());
                    decimal whqtysubmit = Decimal.Parse(whqty.ToString());
                    obj.UpdateWHRcv(partyqtysubmit, whqtysubmit, productid, fk);
                }
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Success');CloseWindow();", true);
            }

            else { }
        }


       
    }
}
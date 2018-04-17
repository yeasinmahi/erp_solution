using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Data;
using SAD_BLL.Item;
using SAD_BLL.Customer;
using SAD_BLL.Corporate_sales;
using SAD_BLL.Corporate_Sales;

namespace UI.SAD.Sales.Return
{
    public partial class rptCorporateSalesReturn : BasePage
    {
        DataTable dt = new DataTable(); Bridge obj = new Bridge(); OrderInput_BLL objOrder = new OrderInput_BLL();
        string  strcustomername, strprodname; DateTime dtefrom, dteto; int intcustid, intprodid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // pnlUpperControl.DataBind();
                divinfo.Visible = false; btnExport.Visible = false;
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '[', ']' };
                string[] searchKey = txtSearch.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdncustid.Value = searchKey[1].ToString();
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name is not valid');", true); }
        }


        protected void txtprod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '[', ']' };
                string[] searchKeyProd = txtprod.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                hdnprodid.Value = searchKeyProd[1];
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Name is not valid');", true); }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomer(string prefixText, int count)
        {
            Int32 unit = 2;
            string customertype = "11", SO = "16";
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return CustomerInfoSt.GetCustomerDataForAutoFill(unit.ToString(), prefixText, customertype.ToString(), SO.ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProduct(string prefixText, int count)
        {
            Int32 unit = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return ItemSt.GetProductDataForAutoFill(unit.ToString(), prefixText);

        }

        protected double ttlsalesvalue = 0; protected double ttldamagevalue = 0; protected double ttlpercent = 0;
        protected double ttlclientrtn = 0; protected double ttlwhrcv = 0; protected double ttlcntwhvr = 0;
        protected double ttlftyrcv = 0; protected double ttlwhftyvar = 0; protected double ttlwhftyvarper = 0;
        protected double ttlcntwhvrper=0;
        protected void dgvrpt1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[1].FindControl("lblsalesvalue")).Text == "Total")
                {ttlsalesvalue += 0;}else{ttlsalesvalue += double.Parse(((Label)e.Row.Cells[1].FindControl("lblsalesvalue")).Text);}

                if (((Label)e.Row.Cells[2].FindControl("lbldamagevalue")).Text == "")
                { ttldamagevalue += 0; }else { ttldamagevalue += double.Parse(((Label)e.Row.Cells[2].FindControl("lbldamagevalue")).Text); }

                if (((Label)e.Row.Cells[3].FindControl("lblpercent")).Text == "")
                { ttlpercent += 0; } else { ttlpercent = Math.Round(ttldamagevalue/ttlsalesvalue*100,2); }

                if (((Label)e.Row.Cells[4].FindControl("lblclientrtn")).Text == "")
                { ttlclientrtn += 0; } else { ttlclientrtn += double.Parse(((Label)e.Row.Cells[4].FindControl("lblclientrtn")).Text); }

                if (((Label)e.Row.Cells[5].FindControl("lblwhrcv")).Text == "")
                { ttlwhrcv += 0; }else { ttlwhrcv += double.Parse(((Label)e.Row.Cells[5].FindControl("lblwhrcv")).Text); }

                if (((Label)e.Row.Cells[6].FindControl("lblcntwhvar")).Text == "")
                { ttlcntwhvr += 0; } else { ttlcntwhvr = ttlclientrtn- ttlwhrcv; ttlcntwhvrper = ttlcntwhvr / ttlclientrtn * 100; }

                if (((Label)e.Row.Cells[7].FindControl("lblftyrcv")).Text == "")
                { ttlftyrcv += 0; } else { ttlftyrcv += double.Parse(((Label)e.Row.Cells[7].FindControl("lblftyrcv")).Text); }

                if (((Label)e.Row.Cells[8].FindControl("lblwhftyvar")).Text == "")
                { ttlwhftyvar += 0; } else { ttlwhftyvar = ttlwhrcv - ttlftyrcv; ttlwhftyvarper = ttlwhftyvar / ttlwhrcv * 100; }

            }
        }


        protected void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
               
                lblfromdate.Text = txtfrmdte.Text; lbltodate.Text = txttodte.Text;
                strcustomername = txtSearch.Text; if (strcustomername == "") { lblcustname2.Text = "All"; } else { lblcustname2.Text = strcustomername; }
                strprodname = txtprod.Text; if (strprodname == "") { lblprodname2.Text = "All"; } else { lblprodname2.Text = strprodname; }
                dtefrom = Convert.ToDateTime(txtfrmdte.Text); dteto= Convert.ToDateTime(txttodte.Text);
                try { intcustid = int.Parse(hdncustid.Value); } catch { intcustid = 0; }
                try { intprodid = int.Parse(hdnprodid.Value); } catch { intprodid = 0; }
                dt = obj.GetCoprReturnReport(intcustid, intprodid, dtefrom, dteto);
                if (dt.Rows.Count > 0)
                {
                    divinfo.Visible = true; btnExport.Visible = true;
                    dgvrpt1.DataSource = dt;
                    dgvrpt1.DataBind();
                }
                else
                {
                    divinfo.Visible = false; btnExport.Visible = false;
                    dgvrpt1.DataSource = "";
                    dgvrpt1.DataBind();
                }
                
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error');", true); }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string html = HdnValue.Value;
            ExportToExcel(ref html, "MyReport");
        }
        public void ExportToExcel(ref string html, string fileName)
        {
            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }
























    }
}

       
      


       
       



















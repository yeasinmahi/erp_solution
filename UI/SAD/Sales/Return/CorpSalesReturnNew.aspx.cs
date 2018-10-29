using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SAD_BLL.Corporate_Sales;
namespace UI.SAD.Sales.Return
{
    public partial class CorpSalesReturnNew : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        #region========= auto search =========

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomer(string prefixText, int count)
        {
            Int32 unit = 2;
            string customertype = "11", SO = "16";
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return SAD_BLL.Customer.CustomerInfoSt.GetCustomerDataForAutoFill(unit.ToString(), prefixText, customertype.ToString(), SO.ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProduct(string prefixText, int count)
        {
            Int32 unit = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return SAD_BLL.Item.ItemSt.GetProductDataForAutoFill(unit.ToString(), prefixText);

        }

        #endregion============================

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (hdnprodid.Value != "") { strprodid = hdnprodid.Value; } else { }
            //    strprodname = txtprod.Text;
            //    strrtnqty = txtqty.Text; strwhrqty = txtwhqty.Text;
            //    if ((hdncustid.Value != "") && (hdnprodid.Value != ""))
            //    {
            //        dt = new DataTable();
            //        dt = obj.ProductPrice(Convert.ToInt32(hdnprodid.Value), Convert.ToInt32(hdncustid.Value), Convert.ToInt32(hdnUom.Value), 8);
            //        if (dt.Rows.Count > 0) { hdnprice.Value = dt.Rows[0]["Column1"].ToString(); }

            //    }

            //    if (hdncustid.Value != "")
            //    {
            //        if ((hdnprodid.Value != "") && (hdnprice.Value != ""))
            //        { CreateReturnXml(strprodid, strprodname, strrtnqty, strwhrqty, (Math.Round((decimal.Parse(hdnprice.Value) * int.Parse(strrtnqty)), 2).ToString())); }
            //        else { txtprod.Text = ""; txtqty.Text = ""; txtwhqty.Text = ""; }
            //    }
            //    else { txtSearch.Text = ""; }
            //    txtprod.Text = ""; txtqty.Text = ""; txtwhqty.Text = ""; strchallanno = "";


            //}
            //catch (Exception ex)
            //{

            //    var efd = log.GetFlogDetail(stop, location, "Add", ex);
            //    Flogger.WriteError(efd);
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Customer Name or Product Name is not valid');", true);
            //}
        }
    }
}
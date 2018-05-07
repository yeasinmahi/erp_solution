using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;

namespace UI.SAD.Vat
{
    public partial class rptFGVatInventory : BasePage
    {
        string Itemaneme;
        int? intItem = null; int Accid;
        DataTable dt;decimal numQty, monValue, monSD;
        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' }; string[] arrayKeyItem;
        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
               
               
                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtMatrialName.Text.Split(delimiterCharss);
            Itemaneme = (arrayKeyItem[0].ToString());
            intItem = int.Parse(arrayKeyItem[1].ToString());
            dt = objMush.getinventory(int.Parse(hdnAccno.Value), txtdtefdate.Text, txttodate.Text, intItem);
            dgvPurChaseRpt.DataSource = dt;
            dgvPurChaseRpt.DataBind();
        }

        protected double TotalOpening = 0; protected double TotalPurchase = 0;
        protected double TotalPurchasertn = 0; protected double TotalSales = 0; protected double TotalSalesrValue = 0; protected double TotalClosing = 0 ;
        protected void dgvProductRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[6].FindControl("lblOpening")).Text == "")
                {
                    TotalOpening += 0;
                }
                else
                {
                    TotalOpening += double.Parse(((Label)e.Row.Cells[6].FindControl("lblOpening")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblPurchasesd")).Text == "")
                {
                    TotalPurchase += 0;
                }
                else
                {
                    TotalPurchase += double.Parse(((Label)e.Row.Cells[6].FindControl("lblPurchasesd")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblPurchasesd")).Text == "")
                {
                    TotalPurchasertn += 0;
                }
                else
                {
                    TotalPurchasertn += double.Parse(((Label)e.Row.Cells[6].FindControl("lblPurchasesd")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblSales")).Text == "")
                {
                    TotalSalesrValue += 0;
                }
                else
                {
                    TotalSalesrValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblSales")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblReturnAmount")).Text == "")
                {
                    TotalSalesrValue += 0;
                }
                else
                {
                    TotalSalesrValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblReturnAmount")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblClosing")).Text == "")
                {
                    TotalClosing += 0;
                }
                else
                {
                    TotalClosing += double.Parse(((Label)e.Row.Cells[6].FindControl("lblClosing")).Text);
                }
            }

        }
     
              
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchMatrial(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] SupplierSearch(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSupplierList(prefixText, unitid);
        }

        #endregion * ********** End search **********

    }
}
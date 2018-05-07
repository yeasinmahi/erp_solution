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
    public partial class rptM11NotPostedM1718 : BasePage
    {
        string Itemaneme, dtefdate, dtetdate;
        int? intItem = null; int Accid;
        DataTable dt;decimal numQty, monValue, monSD;
        DateTime strM11DateChallan;
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
           
                dt = objMush.getM11M17M18report(int.Parse(hdnAccno.Value), txtdtefdate.Text, txttodate.Text);
                dgvRpt.DataSource = dt;
                dgvRpt.DataBind();
               
              
           
        }
       
        protected double TotalOpeningqty = 0, TotalOpeningValue = 0, TotalPurchaseQty = 0, TotalPurchaseValue = 0, TotalIssueQty=0
        , TotalIssueValue=0, TotalClosingQty=0, TotalClosingValue=0;
        protected void dgvm16_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[3].FindControl("lblOpeningQty")).Text == "")
                {
                    TotalOpeningqty += 0;
                }
                else
                {
                    TotalOpeningqty += double.Parse(((Label)e.Row.Cells[3].FindControl("lblOpeningQty")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblOpeningValue")).Text == "")
                {
                    TotalOpeningValue += 0;
                }
                else
                {
                    TotalOpeningValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblOpeningValue")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblPurchaseQty")).Text == "")
                {
                    TotalPurchaseQty += 0;
                }
                else
                {
                    TotalPurchaseQty += double.Parse(((Label)e.Row.Cells[6].FindControl("lblPurchaseQty")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblPurchaseValue")).Text == "")
                {
                    TotalPurchaseValue += 0;
                }
                else
                {
                    TotalPurchaseValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblPurchaseValue")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblIssueQty")).Text == "")
                {
                    TotalIssueQty += 0;
                }
                else
                {
                    TotalIssueQty += double.Parse(((Label)e.Row.Cells[6].FindControl("lblIssueQty")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblIssueValue")).Text == "")
                {
                    TotalIssueValue += 0;
                }
                else
                {
                    TotalIssueValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblIssueValue")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblClosingQty")).Text == "")
                {
                    TotalClosingQty += 0;
                }
                else
                {
                    TotalClosingQty += double.Parse(((Label)e.Row.Cells[6].FindControl("lblClosingQty")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblClosingValue")).Text == "")
                {
                    TotalClosingValue += 0;
                }
                else
                {
                    TotalClosingValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblClosingValue")).Text);
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
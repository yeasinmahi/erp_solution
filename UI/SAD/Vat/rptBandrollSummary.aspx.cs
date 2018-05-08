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
    public partial class rptBandrollSummary : BasePage
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
                if (dt.Rows.Count == 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }
                dt = objMush.getBandrollList(int.Parse(dt.Rows[0]["intVatPointID"].ToString()));
                ddlBandroll.DataTextField = "strBandrollName";
                ddlBandroll.DataValueField = "intBandrollID";
                ddlBandroll.DataSource = dt;
                ddlBandroll.DataBind();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            dt = objMush.getBrandrollSummary(int.Parse(hdnAccno.Value), txtdtefdate.Text, txttodate.Text, int.Parse(ddlShorby.SelectedValue), int.Parse(ddlBandroll.SelectedValue));
            dgvPurChaseRpt.DataSource = dt;
            dgvPurChaseRpt.DataBind();
        }
       
        protected double TotalQty=0, TotalValue = 0, TotalReject=0, TotalOpening=0, TotalReceive=0, Totaluse=0, TotalWastage=0, TotalnumClosing = 0;
        protected void dgvProductRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[3].FindControl("lblQuantity")).Text == "")
                {
                    TotalQty += 0;
                }
                else
                {
                    TotalQty += double.Parse(((Label)e.Row.Cells[3].FindControl("lblQuantity")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblvalue")).Text == "")
                {
                    TotalValue += 0;
                }
                else
                {
                    TotalValue += double.Parse(((Label)e.Row.Cells[6].FindControl("lblvalue")).Text);
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
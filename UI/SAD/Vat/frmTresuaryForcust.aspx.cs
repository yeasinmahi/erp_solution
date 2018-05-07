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
    public partial class frmTresuaryForcust : BasePage
    {
        string Itemaneme;
        int? intItem = null; int Accid;
        DataTable dt;decimal numQty, monValue, monSD;
        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' }; string[] arrayKeyItem;
        Mushok11 objMush = new Mushok11();bool ysnDay, ysnMaterial, ysnChallan;
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
                dt = objMush.getTresuaryForcust(int.Parse(hdnAccno.Value));


            }
        }

     
       
       
        protected double TotalDay7 = 0, TotalDay6 = 0, TotalDay5 = 0, TotalDay4= 0, TotalDay3= 0, TotalDay2 = 0, TotalDay1 = 0
        , TotalDay0 = 0,  TotalCurrentBalance=0, TotalNetPay=0;
        protected void dgvTresuryRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[3].FindControl("lblDay7")).Text == "")
                {
                    TotalDay7 += 0;
                }
                else
                {
                    TotalDay7 += double.Parse(((Label)e.Row.Cells[3].FindControl("lblDay7")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblDay6")).Text == "")
                {
                    TotalDay6 += 0;
                }
                else
                {
                    TotalDay6 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblDay6")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblDay5")).Text == "")
                {
                    TotalDay5 += 0;
                }
                else
                {
                    TotalDay5 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblDay5")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblDay4")).Text == "")
                {
                    TotalDay4 += 0;
                }
                else
                {
                    TotalDay4 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblDay4")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblday3")).Text == "")
                {
                    TotalDay3 += 0;
                }
                else
                {
                    TotalDay3 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblday3")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblday2s")).Text == "")
                {
                    TotalDay2 += 0;
                }
                else
                {
                    TotalDay2 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblday2")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblday1")).Text == "")
                {
                    TotalDay1 += 0;
                }
                else
                {
                    TotalDay1 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblday1")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblday0")).Text == "")
                {
                    TotalDay0 += 0;
                }
                else
                {
                    TotalDay0 += double.Parse(((Label)e.Row.Cells[6].FindControl("lblday0")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblcurrebalance")).Text == "")
                {
                    TotalCurrentBalance += 0;
                }
                else
                {
                    TotalCurrentBalance += double.Parse(((Label)e.Row.Cells[6].FindControl("lblcurrebalance")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblColumn1")).Text == "")
                {
                    TotalNetPay += 0;
                }
                else
                {
                    TotalNetPay += double.Parse(((Label)e.Row.Cells[6].FindControl("lblColumn1")).Text);
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